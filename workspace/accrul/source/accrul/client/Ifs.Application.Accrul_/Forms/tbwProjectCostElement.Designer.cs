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
//  Date    By      Notes
//  ----    ------  -------------------------------------------------------------------------------------  
//  120709  Waudlk  Bug 103945, Changed the Column type of colsElementTypeDb from cColumnFin to cColumn.
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
	
	public partial class tbwProjectCostElement
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsCompany;
		public cColumn colsProjectCostElement;
		public cColumn colsDescription;
		// MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,Start
		// MAKRLK, Twin Peaks,Project Follow-Up Elements for Revenue , Start. Made the column visible
		public cLookupColumn colsElementType;
		// MAKRLK, Twin Peaks,Project Follow-Up Elements for Revenue , End
		// MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,End
		public cCheckBoxColumn cbDefault;
		public cCheckBoxColumn cbObsolete;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwProjectCostElement));
            this.menuTbwMethods_menuTrans_lation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuChange__Company___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsProjectCostElement = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsElementType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.cbDefault = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.cbObsolete = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.tsMenuItemmenuTbwMethods_Toggle_Default_No_Base___ = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods_Toggle_Default_No_Base___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuItem_Translation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem_Change = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cbDefaultNoBase = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsElementTypeDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuTrans_lation___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuChange__Company___);
            this.commandManager.Commands.Add(this.menuTbwMethods_Toggle_Default_No_Base___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuTrans_lation___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuTrans_lation___, "menuTbwMethods_menuTrans_lation___");
            this.menuTbwMethods_menuTrans_lation___.Name = "menuTbwMethods_menuTrans_lation___";
            this.menuTbwMethods_menuTrans_lation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Translation_Execute);
            this.menuTbwMethods_menuTrans_lation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Translation_Inquire);
            // 
            // menuTbwMethods_menuChange__Company___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuChange__Company___, "menuTbwMethods_menuChange__Company___");
            this.menuTbwMethods_menuChange__Company___.Name = "menuTbwMethods_menuChange__Company___";
            this.menuTbwMethods_menuChange__Company___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Change_Execute);
            this.menuTbwMethods_menuChange__Company___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Change_Inquire);
            // 
            // colsCompany
            // 
            this.colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsCompany, "colsCompany");
            this.colsCompany.MaxLength = 20;
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.colsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.colsCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.Position = 3;
            // 
            // colsProjectCostElement
            // 
            this.colsProjectCostElement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsProjectCostElement.Name = "colsProjectCostElement";
            this.colsProjectCostElement.NamedProperties.Put("EnumerateMethod", "");
            this.colsProjectCostElement.NamedProperties.Put("FieldFlags", "163");
            this.colsProjectCostElement.NamedProperties.Put("LovReference", "");
            this.colsProjectCostElement.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsProjectCostElement.NamedProperties.Put("ResizeableChildObject", "");
            this.colsProjectCostElement.NamedProperties.Put("SqlColumn", "PROJECT_COST_ELEMENT");
            this.colsProjectCostElement.NamedProperties.Put("ValidateMethod", "");
            this.colsProjectCostElement.Position = 4;
            resources.ApplyResources(this.colsProjectCostElement, "colsProjectCostElement");
            // 
            // colsDescription
            // 
            this.colsDescription.MaxLength = 2000;
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsDescription.Position = 5;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsElementType
            // 
            this.colsElementType.MaxLength = 20;
            this.colsElementType.Name = "colsElementType";
            this.colsElementType.NamedProperties.Put("EnumerateMethod", "PRJ_FOLLOWUP_ELEMENT_TYPE_API.Enumerate");
            this.colsElementType.NamedProperties.Put("FieldFlags", "291");
            this.colsElementType.NamedProperties.Put("LovReference", "");
            this.colsElementType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsElementType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsElementType.NamedProperties.Put("SqlColumn", "ELEMENT_TYPE");
            this.colsElementType.NamedProperties.Put("ValidateMethod", "");
            this.colsElementType.Position = 6;
            resources.ApplyResources(this.colsElementType, "colsElementType");
            // 
            // cbDefault
            // 
            this.cbDefault.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cbDefault.MaxLength = 5;
            this.cbDefault.Name = "cbDefault";
            this.cbDefault.NamedProperties.Put("EnumerateMethod", "");
            this.cbDefault.NamedProperties.Put("FieldFlags", "294");
            this.cbDefault.NamedProperties.Put("LovReference", "");
            this.cbDefault.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.cbDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cbDefault.NamedProperties.Put("SqlColumn", "DEFAULT_COST_ELEMENT");
            this.cbDefault.NamedProperties.Put("ValidateMethod", "");
            this.cbDefault.Position = 7;
            resources.ApplyResources(this.cbDefault, "cbDefault");
            // 
            // cbObsolete
            // 
            this.cbObsolete.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cbObsolete.MaxLength = 5;
            this.cbObsolete.Name = "cbObsolete";
            this.cbObsolete.NamedProperties.Put("EnumerateMethod", "");
            this.cbObsolete.NamedProperties.Put("FieldFlags", "294");
            this.cbObsolete.NamedProperties.Put("LovReference", "");
            this.cbObsolete.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.cbObsolete.NamedProperties.Put("ResizeableChildObject", "");
            this.cbObsolete.NamedProperties.Put("SqlColumn", "OBSOLETE");
            this.cbObsolete.NamedProperties.Put("ValidateMethod", "");
            this.cbObsolete.Position = 9;
            resources.ApplyResources(this.cbObsolete, "cbObsolete");
            
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemmenuTbwMethods_Toggle_Default_No_Base___,
            this.menuItem_Translation,
            this.menuSeparator1,
            this.menuItem_Change});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // tsMenuItemmenuTbwMethods_Toggle_Default_No_Base___
            // 
            this.tsMenuItemmenuTbwMethods_Toggle_Default_No_Base___.Command = this.menuTbwMethods_Toggle_Default_No_Base___;
            this.tsMenuItemmenuTbwMethods_Toggle_Default_No_Base___.Name = "tsMenuItemmenuTbwMethods_Toggle_Default_No_Base___";
            resources.ApplyResources(this.tsMenuItemmenuTbwMethods_Toggle_Default_No_Base___, "tsMenuItemmenuTbwMethods_Toggle_Default_No_Base___");
            this.tsMenuItemmenuTbwMethods_Toggle_Default_No_Base___.Text = "Toggle Default No Base Value";
            // 
            // menuTbwMethods_Toggle_Default_No_Base___
            // 
            resources.ApplyResources(this.menuTbwMethods_Toggle_Default_No_Base___, "menuTbwMethods_Toggle_Default_No_Base___");
            this.menuTbwMethods_Toggle_Default_No_Base___.Name = "menuTbwMethods_Toggle_Default_No_Base___";
            this.menuTbwMethods_Toggle_Default_No_Base___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuTbwMethods_Toggle_Default_No_Base____Execute);
            this.menuTbwMethods_Toggle_Default_No_Base___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuTbwMethods_Toggle_Default_No_Base____Inquire);
            // 
            // menuItem_Translation
            // 
            this.menuItem_Translation.Command = this.menuTbwMethods_menuTrans_lation___;
            this.menuItem_Translation.Name = "menuItem_Translation";
            resources.ApplyResources(this.menuItem_Translation, "menuItem_Translation");
            this.menuItem_Translation.Text = "Trans&lation...";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            resources.ApplyResources(this.menuSeparator1, "menuSeparator1");
            // 
            // menuItem_Change
            // 
            this.menuItem_Change.Command = this.menuTbwMethods_menuChange__Company___;
            this.menuItem_Change.Name = "menuItem_Change";
            resources.ApplyResources(this.menuItem_Change, "menuItem_Change");
            this.menuItem_Change.Text = "Change &Company...";
            // 
            // cbDefaultNoBase
            // 
            this.cbDefaultNoBase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cbDefaultNoBase.MaxLength = 5;
            this.cbDefaultNoBase.Name = "cbDefaultNoBase";
            this.cbDefaultNoBase.NamedProperties.Put("EnumerateMethod", "");
            this.cbDefaultNoBase.NamedProperties.Put("FieldFlags", "288");
            this.cbDefaultNoBase.NamedProperties.Put("LovReference", "");
            this.cbDefaultNoBase.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.cbDefaultNoBase.NamedProperties.Put("SqlColumn", "DEFAULT_NO_BASE");
            this.cbDefaultNoBase.Position = 8;
            resources.ApplyResources(this.cbDefaultNoBase, "cbDefaultNoBase");
            // 
            // colsElementTypeDb
            // 
            resources.ApplyResources(this.colsElementTypeDb, "colsElementTypeDb");
            this.colsElementTypeDb.MaxLength = 20;
            this.colsElementTypeDb.Name = "colsElementTypeDb";
            this.colsElementTypeDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsElementTypeDb.NamedProperties.Put("FieldFlags", "256");
            this.colsElementTypeDb.NamedProperties.Put("LovReference", "");
            this.colsElementTypeDb.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsElementTypeDb.NamedProperties.Put("SqlColumn", "ELEMENT_TYPE_DB");
            this.colsElementTypeDb.Position = 10;
            // 
            // tbwProjectCostElement
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsProjectCostElement);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsElementType);
            this.Controls.Add(this.cbDefault);
            this.Controls.Add(this.cbDefaultNoBase);
            this.Controls.Add(this.cbObsolete);
            this.Controls.Add(this.colsElementTypeDb);
            this.Name = "tbwProjectCostElement";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY =:global.company ");
            this.NamedProperties.Put("LogicalUnit", "ProjectCostElement");
            this.NamedProperties.Put("PackageName", "PROJECT_COST_ELEMENT_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "PROJECT_COST_ELEMENT");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.Controls.SetChildIndex(this.colsElementTypeDb, 0);
            this.Controls.SetChildIndex(this.cbObsolete, 0);
            this.Controls.SetChildIndex(this.cbDefaultNoBase, 0);
            this.Controls.SetChildIndex(this.cbDefault, 0);
            this.Controls.SetChildIndex(this.colsElementType, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsProjectCostElement, 0);
            this.Controls.SetChildIndex(this.colsCompany, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuTrans_lation___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuChange__Company___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Translation;
        protected Fnd.Windows.Forms.FndToolStripSeparator menuSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Change;
        protected cCheckBoxColumn cbDefaultNoBase;
        protected Fnd.Windows.Forms.FndCommand menuTbwMethods_Toggle_Default_No_Base___;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemmenuTbwMethods_Toggle_Default_No_Base___;
        protected cColumn colsElementTypeDb;
	}
}
