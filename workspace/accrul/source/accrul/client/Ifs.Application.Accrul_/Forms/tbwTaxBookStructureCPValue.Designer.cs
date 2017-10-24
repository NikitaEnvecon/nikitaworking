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
	
	public partial class tbwTaxBookStructureCPValue
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colCompany;
		public cColumn colStructureId;
		public cColumn colNameValue;
		public cColumn colValueDescription;
		public cColumn colLevelId;
		public cColumn colItemAbove;
		public cLookupColumn colStructureItemType;
		public cColumn colNodeDescription;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwTaxBookStructureCPValue));
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colStructureId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colNameValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colValueDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colLevelId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colItemAbove = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colStructureItemType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colNodeDescription = new Ifs.Fnd.ApplicationForms.cColumn();
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
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.MaxLength = 20;
            this.colCompany.Name = "colCompany";
            this.colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colCompany.NamedProperties.Put("FieldFlags", "67");
            this.colCompany.NamedProperties.Put("LovReference", "");
            this.colCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colCompany.NamedProperties.Put("ValidateMethod", "");
            this.colCompany.Position = 3;
            // 
            // colStructureId
            // 
            resources.ApplyResources(this.colStructureId, "colStructureId");
            this.colStructureId.MaxLength = 20;
            this.colStructureId.Name = "colStructureId";
            this.colStructureId.NamedProperties.Put("EnumerateMethod", "");
            this.colStructureId.NamedProperties.Put("FieldFlags", "67");
            this.colStructureId.NamedProperties.Put("LovReference", "TAX_BOOK_STRUCTURE(COMPANY)");
            this.colStructureId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colStructureId.NamedProperties.Put("ResizableChildObject", "");
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
            this.colNameValue.NamedProperties.Put("LovReference", "TAX_BOOK(COMPANY)");
            this.colNameValue.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colNameValue.NamedProperties.Put("ResizableChildObject", "");
            this.colNameValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colNameValue.NamedProperties.Put("SqlColumn", "NAME_VALUE");
            this.colNameValue.NamedProperties.Put("ValidateMethod", "");
            this.colNameValue.Position = 5;
            resources.ApplyResources(this.colNameValue, "colNameValue");
            this.colNameValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colNameValue_WindowActions);
            // 
            // colValueDescription
            // 
            this.colValueDescription.Name = "colValueDescription";
            this.colValueDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colValueDescription.NamedProperties.Put("FieldFlags", "256");
            this.colValueDescription.NamedProperties.Put("LovReference", "");
            this.colValueDescription.NamedProperties.Put("ParentName", "colNameValue");
            this.colValueDescription.NamedProperties.Put("ResizableChildObject", "");
            this.colValueDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colValueDescription.NamedProperties.Put("SqlColumn", "TAX_BOOK_API.Get_Description(COMPANY,NAME_VALUE)");
            this.colValueDescription.NamedProperties.Put("ValidateMethod", "");
            this.colValueDescription.Position = 6;
            resources.ApplyResources(this.colValueDescription, "colValueDescription");
            // 
            // colLevelId
            // 
            this.colLevelId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colLevelId, "colLevelId");
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
            // 
            // colItemAbove
            // 
            this.colItemAbove.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colItemAbove.MaxLength = 10;
            this.colItemAbove.Name = "colItemAbove";
            this.colItemAbove.NamedProperties.Put("EnumerateMethod", "");
            this.colItemAbove.NamedProperties.Put("FieldFlags", "295");
            this.colItemAbove.NamedProperties.Put("LovReference", "TAX_BOOK_STRUCTURE_ITEM2(COMPANY,STRUCTURE_ID)");
            this.colItemAbove.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colItemAbove.NamedProperties.Put("ResizableChildObject", "");
            this.colItemAbove.NamedProperties.Put("ResizeableChildObject", "");
            this.colItemAbove.NamedProperties.Put("SqlColumn", "ITEM_ABOVE");
            this.colItemAbove.NamedProperties.Put("ValidateMethod", "");
            this.colItemAbove.Position = 8;
            resources.ApplyResources(this.colItemAbove, "colItemAbove");
            // 
            // colStructureItemType
            // 
            resources.ApplyResources(this.colStructureItemType, "colStructureItemType");
            this.colStructureItemType.MaxLength = 20;
            this.colStructureItemType.Name = "colStructureItemType";
            this.colStructureItemType.NamedProperties.Put("EnumerateMethod", "TAX_BOOK_STRUC_ITEM_TYPE_API.Enumerate");
            this.colStructureItemType.NamedProperties.Put("FieldFlags", "263");
            this.colStructureItemType.NamedProperties.Put("LovReference", "");
            this.colStructureItemType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colStructureItemType.NamedProperties.Put("ResizableChildObject", "");
            this.colStructureItemType.NamedProperties.Put("ResizeableChildObject", "");
            this.colStructureItemType.NamedProperties.Put("SqlColumn", "STRUCTURE_ITEM_TYPE");
            this.colStructureItemType.NamedProperties.Put("ValidateMethod", "");
            this.colStructureItemType.Position = 9;
            // 
            // colNodeDescription
            // 
            this.colNodeDescription.Name = "colNodeDescription";
            this.colNodeDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colNodeDescription.NamedProperties.Put("FieldFlags", "256");
            this.colNodeDescription.NamedProperties.Put("LovReference", "");
            this.colNodeDescription.NamedProperties.Put("ParentName", "colItemAbove");
            this.colNodeDescription.NamedProperties.Put("ResizableChildObject", "");
            this.colNodeDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colNodeDescription.NamedProperties.Put("SqlColumn", "TAX_BOOK_STRUCTURE_ITEM_API.Get_Description(COMPANY,STRUCTURE_ID,ITEM_ABOVE)");
            this.colNodeDescription.NamedProperties.Put("ValidateMethod", "");
            this.colNodeDescription.Position = 10;
            resources.ApplyResources(this.colNodeDescription, "colNodeDescription");
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
            // tbwTaxBookStructureCPValue
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colCompany);
            this.Controls.Add(this.colStructureId);
            this.Controls.Add(this.colNameValue);
            this.Controls.Add(this.colValueDescription);
            this.Controls.Add(this.colLevelId);
            this.Controls.Add(this.colItemAbove);
            this.Controls.Add(this.colStructureItemType);
            this.Controls.Add(this.colNodeDescription);
            this.Name = "tbwTaxBookStructureCPValue";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "TaxBookStructureItem");
            this.NamedProperties.Put("PackageName", "TAX_BOOK_STRUCTURE_ITEM_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizableChildObject", "");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "16833");
            this.NamedProperties.Put("ViewName", "TAX_BOOK_STRUCTURE_ITEM3");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwTaxBookStructureCPValue_WindowActions);
            this.Controls.SetChildIndex(this.colNodeDescription, 0);
            this.Controls.SetChildIndex(this.colStructureItemType, 0);
            this.Controls.SetChildIndex(this.colItemAbove, 0);
            this.Controls.SetChildIndex(this.colLevelId, 0);
            this.Controls.SetChildIndex(this.colValueDescription, 0);
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
