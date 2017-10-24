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
	
	public partial class tbwIntfaceMethodList
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsIntfaceName;
		public cColumn colnExecuteSeq;
		public cColumn colsViewName;
		public cLookupColumn colsAction;
		// (-) Unitor ALNO (CID 28637/02) Removed 'INTFACE_PREFIX_OPTION_API' from Reference in F1 properties BEGIN
		public cLookupColumn colsPrefixOption;
		// (-) Unitor ALNO (CID 28637/02) Removed 'INTFACE_PREFIX_OPTION_API' from Reference in F1 properties END
		public cColumn colsMethodName;
		public cCheckBoxColumn colsOnNew;
		public cCheckBoxColumn colsOnModify;
		public cColumn colsColumnName;
		public cColumn colsColumnValue;
		public cCheckBoxColumn colsOnNewMaster;
		public cCheckBoxColumn colOnFirstRow;
		public cColumn colNoteText;
		public cColumn colsSourceName;
		public cColumn colsHiddenSqlStatement;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfaceMethodList));
            this.menuTbwMethods_menu_Method_List_Attribute___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuShow_Procedure_Statement = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsIntfaceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnExecuteSeq = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsViewName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAction = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsPrefixOption = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsMethodName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsOnNew = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsOnModify = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsColumnName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsColumnValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsOnNewMaster = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colOnFirstRow = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colNoteText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSourceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsHiddenSqlStatement = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Method = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Show = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Method_List_Attribute___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuShow_Procedure_Statement);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menu_Method_List_Attribute___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Method_List_Attribute___, "menuTbwMethods_menu_Method_List_Attribute___");
            this.menuTbwMethods_menu_Method_List_Attribute___.Name = "menuTbwMethods_menu_Method_List_Attribute___";
            this.menuTbwMethods_menu_Method_List_Attribute___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Method_Execute);
            this.menuTbwMethods_menu_Method_List_Attribute___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Method_Inquire);
            // 
            // menuTbwMethods_menuShow_Procedure_Statement
            // 
            resources.ApplyResources(this.menuTbwMethods_menuShow_Procedure_Statement, "menuTbwMethods_menuShow_Procedure_Statement");
            this.menuTbwMethods_menuShow_Procedure_Statement.Name = "menuTbwMethods_menuShow_Procedure_Statement";
            this.menuTbwMethods_menuShow_Procedure_Statement.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Show_Execute);
            this.menuTbwMethods_menuShow_Procedure_Statement.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Show_Inquire);
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
            // colnExecuteSeq
            // 
            this.colnExecuteSeq.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnExecuteSeq.MaxLength = 0;
            this.colnExecuteSeq.Name = "colnExecuteSeq";
            this.colnExecuteSeq.NamedProperties.Put("EnumerateMethod", "");
            this.colnExecuteSeq.NamedProperties.Put("FieldFlags", "163");
            this.colnExecuteSeq.NamedProperties.Put("LovReference", "");
            this.colnExecuteSeq.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnExecuteSeq.NamedProperties.Put("SqlColumn", "EXECUTE_SEQ");
            this.colnExecuteSeq.Position = 4;
            resources.ApplyResources(this.colnExecuteSeq, "colnExecuteSeq");
            // 
            // colsViewName
            // 
            this.colsViewName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsViewName.Name = "colsViewName";
            this.colsViewName.NamedProperties.Put("EnumerateMethod", "");
            this.colsViewName.NamedProperties.Put("FieldFlags", "294");
            this.colsViewName.NamedProperties.Put("LovReference", "INTFACE_VIEWS");
            this.colsViewName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsViewName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsViewName.NamedProperties.Put("SqlColumn", "VIEW_NAME");
            this.colsViewName.NamedProperties.Put("ValidateMethod", "");
            this.colsViewName.Position = 5;
            resources.ApplyResources(this.colsViewName, "colsViewName");
            // 
            // colsAction
            // 
            this.colsAction.MaxLength = 200;
            this.colsAction.Name = "colsAction";
            this.colsAction.NamedProperties.Put("EnumerateMethod", "INTFACE_METHOD_ACTION_API.Enumerate");
            this.colsAction.NamedProperties.Put("FieldFlags", "295");
            this.colsAction.NamedProperties.Put("LovReference", "");
            this.colsAction.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsAction.NamedProperties.Put("SqlColumn", "ACTION");
            this.colsAction.Position = 6;
            resources.ApplyResources(this.colsAction, "colsAction");
            // 
            // colsPrefixOption
            // 
            this.colsPrefixOption.MaxLength = 200;
            this.colsPrefixOption.Name = "colsPrefixOption";
            this.colsPrefixOption.NamedProperties.Put("EnumerateMethod", "INTFACE_PREFIX_OPTION_API.Enumerate");
            this.colsPrefixOption.NamedProperties.Put("FieldFlags", "295");
            this.colsPrefixOption.NamedProperties.Put("LovReference", "");
            this.colsPrefixOption.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsPrefixOption.NamedProperties.Put("ResizeableChildObject", "");
            this.colsPrefixOption.NamedProperties.Put("SqlColumn", "PREFIX_OPTION");
            this.colsPrefixOption.NamedProperties.Put("ValidateMethod", "");
            this.colsPrefixOption.Position = 7;
            resources.ApplyResources(this.colsPrefixOption, "colsPrefixOption");
            // 
            // colsMethodName
            // 
            this.colsMethodName.Name = "colsMethodName";
            this.colsMethodName.NamedProperties.Put("EnumerateMethod", "");
            this.colsMethodName.NamedProperties.Put("FieldFlags", "290");
            this.colsMethodName.NamedProperties.Put("LovReference", "");
            this.colsMethodName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsMethodName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsMethodName.NamedProperties.Put("SqlColumn", "METHOD_NAME");
            this.colsMethodName.NamedProperties.Put("ValidateMethod", "");
            this.colsMethodName.Position = 8;
            resources.ApplyResources(this.colsMethodName, "colsMethodName");
            // 
            // colsOnNew
            // 
            this.colsOnNew.MaxLength = 5;
            this.colsOnNew.Name = "colsOnNew";
            this.colsOnNew.NamedProperties.Put("EnumerateMethod", "");
            this.colsOnNew.NamedProperties.Put("FieldFlags", "295");
            this.colsOnNew.NamedProperties.Put("LovReference", "");
            this.colsOnNew.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsOnNew.NamedProperties.Put("SqlColumn", "ON_NEW");
            this.colsOnNew.Position = 9;
            resources.ApplyResources(this.colsOnNew, "colsOnNew");
            // 
            // colsOnModify
            // 
            this.colsOnModify.MaxLength = 5;
            this.colsOnModify.Name = "colsOnModify";
            this.colsOnModify.NamedProperties.Put("EnumerateMethod", "");
            this.colsOnModify.NamedProperties.Put("FieldFlags", "295");
            this.colsOnModify.NamedProperties.Put("LovReference", "");
            this.colsOnModify.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsOnModify.NamedProperties.Put("SqlColumn", "ON_MODIFY");
            this.colsOnModify.Position = 10;
            resources.ApplyResources(this.colsOnModify, "colsOnModify");
            // 
            // colsColumnName
            // 
            this.colsColumnName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsColumnName.MaxLength = 2000;
            this.colsColumnName.Name = "colsColumnName";
            this.colsColumnName.NamedProperties.Put("EnumerateMethod", "");
            this.colsColumnName.NamedProperties.Put("FieldFlags", "294");
            this.colsColumnName.NamedProperties.Put("LovReference", "INTFACE_DETAIL_COL_LOV(INTFACE_NAME)");
            this.colsColumnName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsColumnName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsColumnName.NamedProperties.Put("SqlColumn", "COLUMN_NAME");
            this.colsColumnName.NamedProperties.Put("ValidateMethod", "");
            this.colsColumnName.Position = 11;
            resources.ApplyResources(this.colsColumnName, "colsColumnName");
            // 
            // colsColumnValue
            // 
            this.colsColumnValue.Name = "colsColumnValue";
            this.colsColumnValue.NamedProperties.Put("EnumerateMethod", "");
            this.colsColumnValue.NamedProperties.Put("FieldFlags", "294");
            this.colsColumnValue.NamedProperties.Put("LovReference", "");
            this.colsColumnValue.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsColumnValue.NamedProperties.Put("SqlColumn", "COLUMN_VALUE");
            this.colsColumnValue.Position = 12;
            resources.ApplyResources(this.colsColumnValue, "colsColumnValue");
            // 
            // colsOnNewMaster
            // 
            this.colsOnNewMaster.MaxLength = 5;
            this.colsOnNewMaster.Name = "colsOnNewMaster";
            this.colsOnNewMaster.NamedProperties.Put("EnumerateMethod", "");
            this.colsOnNewMaster.NamedProperties.Put("FieldFlags", "294");
            this.colsOnNewMaster.NamedProperties.Put("LovReference", "");
            this.colsOnNewMaster.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsOnNewMaster.NamedProperties.Put("ResizeableChildObject", "");
            this.colsOnNewMaster.NamedProperties.Put("SqlColumn", "ON_NEW_MASTER");
            this.colsOnNewMaster.NamedProperties.Put("ValidateMethod", "");
            this.colsOnNewMaster.Position = 13;
            resources.ApplyResources(this.colsOnNewMaster, "colsOnNewMaster");
            // 
            // colOnFirstRow
            // 
            this.colOnFirstRow.MaxLength = 5;
            this.colOnFirstRow.Name = "colOnFirstRow";
            this.colOnFirstRow.NamedProperties.Put("EnumerateMethod", "");
            this.colOnFirstRow.NamedProperties.Put("FieldFlags", "294");
            this.colOnFirstRow.NamedProperties.Put("LovReference", "");
            this.colOnFirstRow.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colOnFirstRow.NamedProperties.Put("ResizeableChildObject", "");
            this.colOnFirstRow.NamedProperties.Put("SqlColumn", "ON_FIRST_ROW");
            this.colOnFirstRow.NamedProperties.Put("ValidateMethod", "");
            this.colOnFirstRow.Position = 14;
            resources.ApplyResources(this.colOnFirstRow, "colOnFirstRow");
            // 
            // colNoteText
            // 
            this.colNoteText.MaxLength = 2000;
            this.colNoteText.Name = "colNoteText";
            this.colNoteText.NamedProperties.Put("EnumerateMethod", "");
            this.colNoteText.NamedProperties.Put("FieldFlags", "310");
            this.colNoteText.NamedProperties.Put("LovReference", "");
            this.colNoteText.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colNoteText.NamedProperties.Put("ResizeableChildObject", "");
            this.colNoteText.NamedProperties.Put("SqlColumn", "NOTE_TEXT");
            this.colNoteText.NamedProperties.Put("ValidateMethod", "");
            this.colNoteText.Position = 15;
            resources.ApplyResources(this.colNoteText, "colNoteText");
            // 
            // colsSourceName
            // 
            this.colsSourceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsSourceName.MaxLength = 2000;
            this.colsSourceName.Name = "colsSourceName";
            this.colsSourceName.NamedProperties.Put("EnumerateMethod", "");
            this.colsSourceName.NamedProperties.Put("FieldFlags", "294");
            this.colsSourceName.NamedProperties.Put("LovReference", "");
            this.colsSourceName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSourceName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsSourceName.NamedProperties.Put("SqlColumn", "SOURCE_NAME");
            this.colsSourceName.NamedProperties.Put("ValidateMethod", "");
            this.colsSourceName.Position = 16;
            resources.ApplyResources(this.colsSourceName, "colsSourceName");
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
            this.colsHiddenSqlStatement.Position = 17;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Method,
            this.menuItem_Show});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Method
            // 
            this.menuItem__Method.Command = this.menuTbwMethods_menu_Method_List_Attribute___;
            this.menuItem__Method.Name = "menuItem__Method";
            resources.ApplyResources(this.menuItem__Method, "menuItem__Method");
            this.menuItem__Method.Text = "&Method List Attribute...";
            // 
            // menuItem_Show
            // 
            this.menuItem_Show.Command = this.menuTbwMethods_menuShow_Procedure_Statement;
            this.menuItem_Show.Name = "menuItem_Show";
            resources.ApplyResources(this.menuItem_Show, "menuItem_Show");
            this.menuItem_Show.Text = "Show Procedure Statement";
            // 
            // tbwIntfaceMethodList
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsIntfaceName);
            this.Controls.Add(this.colnExecuteSeq);
            this.Controls.Add(this.colsViewName);
            this.Controls.Add(this.colsAction);
            this.Controls.Add(this.colsPrefixOption);
            this.Controls.Add(this.colsMethodName);
            this.Controls.Add(this.colsOnNew);
            this.Controls.Add(this.colsOnModify);
            this.Controls.Add(this.colsColumnName);
            this.Controls.Add(this.colsColumnValue);
            this.Controls.Add(this.colsOnNewMaster);
            this.Controls.Add(this.colOnFirstRow);
            this.Controls.Add(this.colNoteText);
            this.Controls.Add(this.colsSourceName);
            this.Controls.Add(this.colsHiddenSqlStatement);
            this.Name = "tbwIntfaceMethodList";
            this.NamedProperties.Put("DefaultOrderBy", "EXECUTE_SEQ");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "IntfaceMethodList");
            this.NamedProperties.Put("PackageName", "INTFACE_METHOD_LIST_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.NamedProperties.Put("ViewName", "INTFACE_METHOD_LIST");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwIntfaceMethodList_WindowActions);
            this.Controls.SetChildIndex(this.colsHiddenSqlStatement, 0);
            this.Controls.SetChildIndex(this.colsSourceName, 0);
            this.Controls.SetChildIndex(this.colNoteText, 0);
            this.Controls.SetChildIndex(this.colOnFirstRow, 0);
            this.Controls.SetChildIndex(this.colsOnNewMaster, 0);
            this.Controls.SetChildIndex(this.colsColumnValue, 0);
            this.Controls.SetChildIndex(this.colsColumnName, 0);
            this.Controls.SetChildIndex(this.colsOnModify, 0);
            this.Controls.SetChildIndex(this.colsOnNew, 0);
            this.Controls.SetChildIndex(this.colsMethodName, 0);
            this.Controls.SetChildIndex(this.colsPrefixOption, 0);
            this.Controls.SetChildIndex(this.colsAction, 0);
            this.Controls.SetChildIndex(this.colsViewName, 0);
            this.Controls.SetChildIndex(this.colnExecuteSeq, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Method_List_Attribute___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuShow_Procedure_Statement;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Method;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Show;
	}
}
