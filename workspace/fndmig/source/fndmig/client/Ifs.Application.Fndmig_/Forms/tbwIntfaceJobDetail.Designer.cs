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
	
	public partial class tbwIntfaceJobDetail
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsIntfaceName;
		public cColumn colnLineNo;
		public cColumn colFileString;
		public cColumn colAttributeString;
		public cColumn colErrorMessage;
		public cColumn colnExecutionNo;
		public cColumn colsStatus;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfaceJobDetail));
            this.menuTbwMethods_menuLoad_File___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuExport_to_File___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsIntfaceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnLineNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colFileString = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAttributeString = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colErrorMessage = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnExecutionNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsStatus = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Load = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Export = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuLoad_File___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuExport_to_File___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuLoad_File___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuLoad_File___, "menuTbwMethods_menuLoad_File___");
            this.menuTbwMethods_menuLoad_File___.Name = "menuTbwMethods_menuLoad_File___";
            this.menuTbwMethods_menuLoad_File___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Load_Execute);
            this.menuTbwMethods_menuLoad_File___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Load_Inquire);
            // 
            // menuTbwMethods_menuExport_to_File___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuExport_to_File___, "menuTbwMethods_menuExport_to_File___");
            this.menuTbwMethods_menuExport_to_File___.Name = "menuTbwMethods_menuExport_to_File___";
            this.menuTbwMethods_menuExport_to_File___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Export_Execute);
            this.menuTbwMethods_menuExport_to_File___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Export_Inquire);
            // 
            // colsIntfaceName
            // 
            this.colsIntfaceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsIntfaceName, "colsIntfaceName");
            this.colsIntfaceName.MaxLength = 30;
            this.colsIntfaceName.Name = "colsIntfaceName";
            this.colsIntfaceName.NamedProperties.Put("EnumerateMethod", "");
            this.colsIntfaceName.NamedProperties.Put("FieldFlags", "67");
            this.colsIntfaceName.NamedProperties.Put("LovReference", "INTFACE_HEADER");
            this.colsIntfaceName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsIntfaceName.NamedProperties.Put("SqlColumn", "INTFACE_NAME");
            this.colsIntfaceName.Position = 3;
            // 
            // colnLineNo
            // 
            this.colnLineNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnLineNo.Name = "colnLineNo";
            this.colnLineNo.NamedProperties.Put("EnumerateMethod", "");
            this.colnLineNo.NamedProperties.Put("FieldFlags", "163");
            this.colnLineNo.NamedProperties.Put("LovReference", "");
            this.colnLineNo.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnLineNo.NamedProperties.Put("SqlColumn", "LINE_NO");
            this.colnLineNo.Position = 4;
            resources.ApplyResources(this.colnLineNo, "colnLineNo");
            // 
            // colFileString
            // 
            this.colFileString.MaxLength = 4000;
            this.colFileString.Name = "colFileString";
            this.colFileString.NamedProperties.Put("EnumerateMethod", "");
            this.colFileString.NamedProperties.Put("FieldFlags", "310");
            this.colFileString.NamedProperties.Put("LovReference", "");
            this.colFileString.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colFileString.NamedProperties.Put("SqlColumn", "FILE_STRING");
            this.colFileString.Position = 5;
            resources.ApplyResources(this.colFileString, "colFileString");
            // 
            // colAttributeString
            // 
            this.colAttributeString.MaxLength = 4000;
            this.colAttributeString.Name = "colAttributeString";
            this.colAttributeString.NamedProperties.Put("EnumerateMethod", "");
            this.colAttributeString.NamedProperties.Put("FieldFlags", "310");
            this.colAttributeString.NamedProperties.Put("LovReference", "");
            this.colAttributeString.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colAttributeString.NamedProperties.Put("SqlColumn", "ATTRIBUTE_STRING");
            this.colAttributeString.Position = 6;
            resources.ApplyResources(this.colAttributeString, "colAttributeString");
            // 
            // colErrorMessage
            // 
            this.colErrorMessage.MaxLength = 2000;
            this.colErrorMessage.Name = "colErrorMessage";
            this.colErrorMessage.NamedProperties.Put("EnumerateMethod", "");
            this.colErrorMessage.NamedProperties.Put("FieldFlags", "310");
            this.colErrorMessage.NamedProperties.Put("LovReference", "");
            this.colErrorMessage.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colErrorMessage.NamedProperties.Put("SqlColumn", "ERROR_MESSAGE");
            this.colErrorMessage.Position = 7;
            resources.ApplyResources(this.colErrorMessage, "colErrorMessage");
            // 
            // colnExecutionNo
            // 
            this.colnExecutionNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnExecutionNo.Name = "colnExecutionNo";
            this.colnExecutionNo.NamedProperties.Put("EnumerateMethod", "");
            this.colnExecutionNo.NamedProperties.Put("FieldFlags", "295");
            this.colnExecutionNo.NamedProperties.Put("LovReference", "");
            this.colnExecutionNo.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnExecutionNo.NamedProperties.Put("SqlColumn", "EXECUTION_NO");
            this.colnExecutionNo.Position = 8;
            resources.ApplyResources(this.colnExecutionNo, "colnExecutionNo");
            // 
            // colsStatus
            // 
            this.colsStatus.MaxLength = 200;
            this.colsStatus.Name = "colsStatus";
            this.colsStatus.NamedProperties.Put("EnumerateMethod", "");
            this.colsStatus.NamedProperties.Put("FieldFlags", "294");
            this.colsStatus.NamedProperties.Put("LovReference", "");
            this.colsStatus.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsStatus.NamedProperties.Put("ResizeableChildObject", "");
            this.colsStatus.NamedProperties.Put("SqlColumn", "STATUS");
            this.colsStatus.NamedProperties.Put("ValidateMethod", "");
            this.colsStatus.Position = 9;
            resources.ApplyResources(this.colsStatus, "colsStatus");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Load,
            this.menuItem_Export});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Load
            // 
            this.menuItem_Load.Command = this.menuTbwMethods_menuLoad_File___;
            this.menuItem_Load.Name = "menuItem_Load";
            resources.ApplyResources(this.menuItem_Load, "menuItem_Load");
            this.menuItem_Load.Text = "Load File...";
            // 
            // menuItem_Export
            // 
            this.menuItem_Export.Command = this.menuTbwMethods_menuExport_to_File___;
            this.menuItem_Export.Name = "menuItem_Export";
            resources.ApplyResources(this.menuItem_Export, "menuItem_Export");
            this.menuItem_Export.Text = "Export to File...";
            // 
            // tbwIntfaceJobDetail
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsIntfaceName);
            this.Controls.Add(this.colnLineNo);
            this.Controls.Add(this.colFileString);
            this.Controls.Add(this.colAttributeString);
            this.Controls.Add(this.colErrorMessage);
            this.Controls.Add(this.colnExecutionNo);
            this.Controls.Add(this.colsStatus);
            this.Name = "tbwIntfaceJobDetail";
            this.NamedProperties.Put("DefaultOrderBy", "LINE_NO ASC");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "IntfaceJobDetail");
            this.NamedProperties.Put("PackageName", "Intface_Job_Detail_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "448");
            this.NamedProperties.Put("ViewName", "INTFACE_JOB_DETAIL");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.Controls.SetChildIndex(this.colsStatus, 0);
            this.Controls.SetChildIndex(this.colnExecutionNo, 0);
            this.Controls.SetChildIndex(this.colErrorMessage, 0);
            this.Controls.SetChildIndex(this.colAttributeString, 0);
            this.Controls.SetChildIndex(this.colFileString, 0);
            this.Controls.SetChildIndex(this.colnLineNo, 0);
            this.Controls.SetChildIndex(this.colsIntfaceName, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuLoad_File___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuExport_to_File___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Load;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Export;
	}
}
