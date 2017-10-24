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
	
	public partial class tbwIntfaceReplDbObjects
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsIntfaceName;
		public cColumn colsObjectName;
		public cColumn colsObjectType;
		public cColumn colsHiddenSqlStatement;
		public cColumn colStatus;
		public cColumn colTableName;
		public cColumn colErrorText;
		public cColumn coldCreated;
		public cColumn coldLastDdlTime;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfaceReplDbObjects));
            this.menuTbwMethods_menuShow_Source_Text = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsIntfaceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsObjectName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsObjectType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsHiddenSqlStatement = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colStatus = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colTableName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colErrorText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldCreated = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldLastDdlTime = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Show = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuShow_Source_Text);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuShow_Source_Text
            // 
            resources.ApplyResources(this.menuTbwMethods_menuShow_Source_Text, "menuTbwMethods_menuShow_Source_Text");
            this.menuTbwMethods_menuShow_Source_Text.Name = "menuTbwMethods_menuShow_Source_Text";
            this.menuTbwMethods_menuShow_Source_Text.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Show_Execute);
            this.menuTbwMethods_menuShow_Source_Text.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Show_Inquire);
            // 
            // colsIntfaceName
            // 
            this.colsIntfaceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsIntfaceName.Name = "colsIntfaceName";
            this.colsIntfaceName.NamedProperties.Put("EnumerateMethod", "");
            this.colsIntfaceName.NamedProperties.Put("FieldFlags", "288");
            this.colsIntfaceName.NamedProperties.Put("LovReference", "");
            this.colsIntfaceName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsIntfaceName.NamedProperties.Put("SqlColumn", "INTFACE_NAME");
            this.colsIntfaceName.Position = 3;
            resources.ApplyResources(this.colsIntfaceName, "colsIntfaceName");
            // 
            // colsObjectName
            // 
            this.colsObjectName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsObjectName.MaxLength = 128;
            this.colsObjectName.Name = "colsObjectName";
            this.colsObjectName.NamedProperties.Put("EnumerateMethod", "");
            this.colsObjectName.NamedProperties.Put("FieldFlags", "288");
            this.colsObjectName.NamedProperties.Put("LovReference", "");
            this.colsObjectName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsObjectName.NamedProperties.Put("SqlColumn", "OBJECT_NAME");
            this.colsObjectName.Position = 4;
            resources.ApplyResources(this.colsObjectName, "colsObjectName");
            // 
            // colsObjectType
            // 
            this.colsObjectType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsObjectType.Name = "colsObjectType";
            this.colsObjectType.NamedProperties.Put("EnumerateMethod", "");
            this.colsObjectType.NamedProperties.Put("FieldFlags", "288");
            this.colsObjectType.NamedProperties.Put("LovReference", "");
            this.colsObjectType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsObjectType.NamedProperties.Put("SqlColumn", "OBJECT_TYPE");
            this.colsObjectType.Position = 5;
            resources.ApplyResources(this.colsObjectType, "colsObjectType");
            // 
            // colsHiddenSqlStatement
            // 
            resources.ApplyResources(this.colsHiddenSqlStatement, "colsHiddenSqlStatement");
            this.colsHiddenSqlStatement.MaxLength = 32000;
            this.colsHiddenSqlStatement.Name = "colsHiddenSqlStatement";
            this.colsHiddenSqlStatement.NamedProperties.Put("EnumerateMethod", "");
            this.colsHiddenSqlStatement.NamedProperties.Put("FieldFlags", "276");
            this.colsHiddenSqlStatement.NamedProperties.Put("LovReference", "");
            this.colsHiddenSqlStatement.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsHiddenSqlStatement.NamedProperties.Put("ResizeableChildObject", "");
            this.colsHiddenSqlStatement.NamedProperties.Put("SqlColumn", "");
            this.colsHiddenSqlStatement.NamedProperties.Put("ValidateMethod", "");
            this.colsHiddenSqlStatement.Position = 6;
            // 
            // colStatus
            // 
            this.colStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colStatus.MaxLength = 2000;
            this.colStatus.Name = "colStatus";
            this.colStatus.NamedProperties.Put("EnumerateMethod", "");
            this.colStatus.NamedProperties.Put("FieldFlags", "304");
            this.colStatus.NamedProperties.Put("LovReference", "");
            this.colStatus.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colStatus.NamedProperties.Put("SqlColumn", "STATUS");
            this.colStatus.Position = 7;
            resources.ApplyResources(this.colStatus, "colStatus");
            // 
            // colTableName
            // 
            this.colTableName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colTableName.MaxLength = 2000;
            this.colTableName.Name = "colTableName";
            this.colTableName.NamedProperties.Put("EnumerateMethod", "");
            this.colTableName.NamedProperties.Put("FieldFlags", "304");
            this.colTableName.NamedProperties.Put("LovReference", "");
            this.colTableName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colTableName.NamedProperties.Put("SqlColumn", "TABLE_NAME");
            this.colTableName.Position = 8;
            resources.ApplyResources(this.colTableName, "colTableName");
            // 
            // colErrorText
            // 
            this.colErrorText.MaxLength = 2000;
            this.colErrorText.Name = "colErrorText";
            this.colErrorText.NamedProperties.Put("EnumerateMethod", "");
            this.colErrorText.NamedProperties.Put("FieldFlags", "304");
            this.colErrorText.NamedProperties.Put("LovReference", "");
            this.colErrorText.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colErrorText.NamedProperties.Put("SqlColumn", "ERROR_TEXT");
            this.colErrorText.Position = 9;
            resources.ApplyResources(this.colErrorText, "colErrorText");
            // 
            // coldCreated
            // 
            this.coldCreated.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldCreated.Format = "G";
            this.coldCreated.Name = "coldCreated";
            this.coldCreated.NamedProperties.Put("EnumerateMethod", "");
            this.coldCreated.NamedProperties.Put("FieldFlags", "288");
            this.coldCreated.NamedProperties.Put("LovReference", "");
            this.coldCreated.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldCreated.NamedProperties.Put("SqlColumn", "CREATED");
            this.coldCreated.Position = 10;
            resources.ApplyResources(this.coldCreated, "coldCreated");
            // 
            // coldLastDdlTime
            // 
            this.coldLastDdlTime.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldLastDdlTime.Format = "G";
            this.coldLastDdlTime.Name = "coldLastDdlTime";
            this.coldLastDdlTime.NamedProperties.Put("EnumerateMethod", "");
            this.coldLastDdlTime.NamedProperties.Put("FieldFlags", "288");
            this.coldLastDdlTime.NamedProperties.Put("LovReference", "");
            this.coldLastDdlTime.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldLastDdlTime.NamedProperties.Put("SqlColumn", "LAST_DDL_TIME");
            this.coldLastDdlTime.Position = 11;
            resources.ApplyResources(this.coldLastDdlTime, "coldLastDdlTime");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Show});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Show
            // 
            this.menuItem_Show.Command = this.menuTbwMethods_menuShow_Source_Text;
            this.menuItem_Show.Name = "menuItem_Show";
            resources.ApplyResources(this.menuItem_Show, "menuItem_Show");
            this.menuItem_Show.Text = "Show Source Text";
            // 
            // tbwIntfaceReplDbObjects
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsIntfaceName);
            this.Controls.Add(this.colsObjectName);
            this.Controls.Add(this.colsObjectType);
            this.Controls.Add(this.colsHiddenSqlStatement);
            this.Controls.Add(this.colStatus);
            this.Controls.Add(this.colTableName);
            this.Controls.Add(this.colErrorText);
            this.Controls.Add(this.coldCreated);
            this.Controls.Add(this.coldLastDdlTime);
            this.Name = "tbwIntfaceReplDbObjects";
            this.NamedProperties.Put("DefaultOrderBy", "OBJECT_TYPE, OBJECT_NAME");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "intfaceReplDbObjects");
            this.NamedProperties.Put("PackageName", "INTFACE_REPL_DB_OBJECTS");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "0");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.NamedProperties.Put("ViewName", "INTFACE_REPL_DB_OBJECTS");
            this.Controls.SetChildIndex(this.coldLastDdlTime, 0);
            this.Controls.SetChildIndex(this.coldCreated, 0);
            this.Controls.SetChildIndex(this.colErrorText, 0);
            this.Controls.SetChildIndex(this.colTableName, 0);
            this.Controls.SetChildIndex(this.colStatus, 0);
            this.Controls.SetChildIndex(this.colsHiddenSqlStatement, 0);
            this.Controls.SetChildIndex(this.colsObjectType, 0);
            this.Controls.SetChildIndex(this.colsObjectName, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuShow_Source_Text;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Show;
	}
}
