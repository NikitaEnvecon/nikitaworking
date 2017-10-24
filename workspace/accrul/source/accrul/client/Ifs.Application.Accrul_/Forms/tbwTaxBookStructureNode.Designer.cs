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
using Ifs.Application.Accrul;
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
	
	public partial class tbwTaxBookStructureNode
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		// Column: __colObjid
		// List Values
		// Message Actions
		// Column: __colObjversion
		// List Values
		// Message Actions
		public cColumn colCompany;
		public cColumn colStructureId;
		public cColumn colNameValue;
		public cColumn colDescription;
		public cColumn colLevelId;
		public cColumn colLevelDescription;
		public cColumn collLevelNo;
		public cColumn colItemAbove;
		public cLookupColumn colStructureItemType;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwTaxBookStructureNode));
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colStructureId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colNameValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colLevelId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colLevelDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.collLevelNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colItemAbove = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colStructureItemType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange__Company___, "menuTbwMethods_menuChange__Company___");
            this.menuTbwMethods_menuChange__Company___.Name = "menuTbwMethods_menuChange__Company___";
            this.menuTbwMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuTbwMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // colCompany
            // 
            this.colCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.MaxLength = 20;
            this.colCompany.Name = "colCompany";
            this.colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colCompany.NamedProperties.Put("FieldFlags", "67");
            this.colCompany.NamedProperties.Put("LovReference", "");
            this.colCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCompany.NamedProperties.Put("ResizableChildObject", "");
            this.colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colCompany.NamedProperties.Put("ValidateMethod", "");
            this.colCompany.Position = 3;
            // 
            // colStructureId
            // 
            this.colStructureId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colStructureId, "colStructureId");
            this.colStructureId.MaxLength = 20;
            this.colStructureId.Name = "colStructureId";
            this.colStructureId.NamedProperties.Put("EnumerateMethod", "");
            this.colStructureId.NamedProperties.Put("FieldFlags", "67");
            this.colStructureId.NamedProperties.Put("LovReference", "TAX_BOOK_STRUCTURE(COMPANY)");
            this.colStructureId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colStructureId.NamedProperties.Put("ResizeableChildObject", "");
            this.colStructureId.NamedProperties.Put("SqlColumn", "STRUCTURE_ID");
            this.colStructureId.NamedProperties.Put("ValidateMethod", "");
            this.colStructureId.Position = 4;
            // 
            // colNameValue
            // 
            this.colNameValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colNameValue.MaxLength = 10;
            this.colNameValue.Name = "colNameValue";
            this.colNameValue.NamedProperties.Put("EnumerateMethod", "");
            this.colNameValue.NamedProperties.Put("FieldFlags", "163");
            this.colNameValue.NamedProperties.Put("LovReference", "");
            this.colNameValue.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colNameValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colNameValue.NamedProperties.Put("SqlColumn", "NAME_VALUE");
            this.colNameValue.NamedProperties.Put("ValidateMethod", "");
            this.colNameValue.Position = 5;
            resources.ApplyResources(this.colNameValue, "colNameValue");
            // 
            // colDescription
            // 
            this.colDescription.MaxLength = 35;
            this.colDescription.Name = "colDescription";
            this.colDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colDescription.NamedProperties.Put("FieldFlags", "294");
            this.colDescription.NamedProperties.Put("LovReference", "");
            this.colDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colDescription.NamedProperties.Put("ValidateMethod", "");
            this.colDescription.Position = 6;
            resources.ApplyResources(this.colDescription, "colDescription");
            // 
            // colLevelId
            // 
            this.colLevelId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colLevelId.MaxLength = 10;
            this.colLevelId.Name = "colLevelId";
            this.colLevelId.NamedProperties.Put("EnumerateMethod", "");
            this.colLevelId.NamedProperties.Put("FieldFlags", "295");
            this.colLevelId.NamedProperties.Put("LovReference", "TAX_BOOK_STRUCTURE_LEVEL(COMPANY,STRUCTURE_ID)");
            this.colLevelId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colLevelId.NamedProperties.Put("ResizeableChildObject", "");
            this.colLevelId.NamedProperties.Put("SqlColumn", "LEVEL_ID");
            this.colLevelId.NamedProperties.Put("ValidateMethod", "");
            this.colLevelId.Position = 7;
            resources.ApplyResources(this.colLevelId, "colLevelId");
            // 
            // colLevelDescription
            // 
            this.colLevelDescription.Name = "colLevelDescription";
            this.colLevelDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colLevelDescription.NamedProperties.Put("FieldFlags", "304");
            this.colLevelDescription.NamedProperties.Put("LovReference", "");
            this.colLevelDescription.NamedProperties.Put("ParentName", "colLevelId");
            this.colLevelDescription.NamedProperties.Put("ResizableChildObject", "");
            this.colLevelDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colLevelDescription.NamedProperties.Put("SqlColumn", "TAX_BOOK_STRUCTURE_LEVEL_API.Get_Description(company,structure_id,LEVEL_ID)");
            this.colLevelDescription.NamedProperties.Put("ValidateMethod", "");
            this.colLevelDescription.Position = 8;
            resources.ApplyResources(this.colLevelDescription, "colLevelDescription");
            // 
            // collLevelNo
            // 
            this.collLevelNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.collLevelNo, "collLevelNo");
            this.collLevelNo.Name = "collLevelNo";
            this.collLevelNo.NamedProperties.Put("EnumerateMethod", "");
            this.collLevelNo.NamedProperties.Put("FieldFlags", "256");
            this.collLevelNo.NamedProperties.Put("LovReference", "");
            this.collLevelNo.NamedProperties.Put("ParentName", "colLevelId");
            this.collLevelNo.NamedProperties.Put("ResizableChildObject", "");
            this.collLevelNo.NamedProperties.Put("ResizeableChildObject", "");
            this.collLevelNo.NamedProperties.Put("SqlColumn", "TAX_BOOK_STRUCTURE_LEVEL_API.Get_Level_Position(company,structure_id,LEVEL_ID)");
            this.collLevelNo.NamedProperties.Put("ValidateMethod", "");
            this.collLevelNo.Position = 9;
            // 
            // colItemAbove
            // 
            this.colItemAbove.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colItemAbove.MaxLength = 10;
            this.colItemAbove.Name = "colItemAbove";
            this.colItemAbove.NamedProperties.Put("EnumerateMethod", "");
            this.colItemAbove.NamedProperties.Put("FieldFlags", "294");
            this.colItemAbove.NamedProperties.Put("LovReference", "TAX_BOOK_STRUCTURE_ITEM2(COMPANY,STRUCTURE_ID)");
            this.colItemAbove.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colItemAbove.NamedProperties.Put("ResizableChildObject", "");
            this.colItemAbove.NamedProperties.Put("ResizeableChildObject", "");
            this.colItemAbove.NamedProperties.Put("SqlColumn", "ITEM_ABOVE");
            this.colItemAbove.NamedProperties.Put("ValidateMethod", "");
            this.colItemAbove.Position = 10;
            resources.ApplyResources(this.colItemAbove, "colItemAbove");
            // 
            // colStructureItemType
            // 
            resources.ApplyResources(this.colStructureItemType, "colStructureItemType");
            this.colStructureItemType.MaxLength = 20;
            this.colStructureItemType.Name = "colStructureItemType";
            this.colStructureItemType.NamedProperties.Put("EnumerateMethod", "TAX_BOOK_STRUC_ITEM_TYPE_API.Enumerate");
            this.colStructureItemType.NamedProperties.Put("FieldFlags", "291");
            this.colStructureItemType.NamedProperties.Put("LovReference", "");
            this.colStructureItemType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colStructureItemType.NamedProperties.Put("ResizeableChildObject", "");
            this.colStructureItemType.NamedProperties.Put("SqlColumn", "STRUCTURE_ITEM_TYPE");
            this.colStructureItemType.NamedProperties.Put("ValidateMethod", "");
            this.colStructureItemType.Position = 11;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTbwMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // tbwTaxBookStructureNode
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colStructureId);
            this.Controls.Add(this.colNameValue);
            this.Controls.Add(this.colDescription);
            this.Controls.Add(this.colLevelId);
            this.Controls.Add(this.colLevelDescription);
            this.Controls.Add(this.collLevelNo);
            this.Controls.Add(this.colItemAbove);
            this.Controls.Add(this.colStructureItemType);
            this.Name = "tbwTaxBookStructureNode";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "TaxBookStructureItem");
            this.NamedProperties.Put("PackageName", "TAX_BOOK_STRUCTURE_ITEM_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizableChildObject", "");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "16833");
            this.NamedProperties.Put("ViewName", "TAX_BOOK_STRUCTURE_ITEM2");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwTaxBookStructureNode_WindowActions);
            this.Controls.SetChildIndex(this.colStructureItemType, 0);
            this.Controls.SetChildIndex(this.colItemAbove, 0);
            this.Controls.SetChildIndex(this.collLevelNo, 0);
            this.Controls.SetChildIndex(this.colLevelDescription, 0);
            this.Controls.SetChildIndex(this.colLevelId, 0);
            this.Controls.SetChildIndex(this.colDescription, 0);
            this.Controls.SetChildIndex(this.colNameValue, 0);
            this.Controls.SetChildIndex(this.colStructureId, 0);
            this.Controls.SetChildIndex(this.colCompany, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
	}
}
