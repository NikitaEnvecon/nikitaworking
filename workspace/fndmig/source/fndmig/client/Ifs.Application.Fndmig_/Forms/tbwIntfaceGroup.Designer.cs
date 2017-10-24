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

using Ifs.Fnd.ApplicationForms;

namespace Ifs.Application.Fndmig_
{
	
	public partial class tbwIntfaceGroup
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsGroupId;
		public cColumn colsDescription;
		public cColumn colNoteText;
		public cColumn colsExportGroup;
		public cCheckBoxColumn colsHideFlag;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfaceGroup));
            this.cmdExportGroup = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsGroupId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colNoteText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsExportGroup = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsHideFlag = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_ExportGroup = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.cmdExportGroup);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // cmdExportGroup
            // 
            resources.ApplyResources(this.cmdExportGroup, "cmdExportGroup");
            this.cmdExportGroup.Name = "cmdExportGroup";
            this.cmdExportGroup.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Export_Execute);
            this.cmdExportGroup.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Export_Inquire);
            // 
            // colsGroupId
            // 
            this.colsGroupId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsGroupId.MaxLength = 20;
            this.colsGroupId.Name = "colsGroupId";
            this.colsGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.colsGroupId.NamedProperties.Put("FieldFlags", "163");
            this.colsGroupId.NamedProperties.Put("LovReference", "");
            this.colsGroupId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsGroupId.NamedProperties.Put("SqlColumn", "GROUP_ID");
            this.colsGroupId.NamedProperties.Put("ValidateMethod", "");
            this.colsGroupId.Position = 3;
            resources.ApplyResources(this.colsGroupId, "colsGroupId");
            // 
            // colsDescription
            // 
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.Position = 4;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colNoteText
            // 
            this.colNoteText.MaxLength = 2000;
            this.colNoteText.Name = "colNoteText";
            this.colNoteText.NamedProperties.Put("EnumerateMethod", "");
            this.colNoteText.NamedProperties.Put("FieldFlags", "310");
            this.colNoteText.NamedProperties.Put("LovReference", "");
            this.colNoteText.NamedProperties.Put("SqlColumn", "NOTE_TEXT");
            this.colNoteText.Position = 5;
            resources.ApplyResources(this.colNoteText, "colNoteText");
            // 
            // colsExportGroup
            // 
            resources.ApplyResources(this.colsExportGroup, "colsExportGroup");
            this.colsExportGroup.Name = "colsExportGroup";
            this.colsExportGroup.Position = 6;
            // 
            // colsHideFlag
            // 
            this.colsHideFlag.MaxLength = 5;
            this.colsHideFlag.Name = "colsHideFlag";
            this.colsHideFlag.NamedProperties.Put("EnumerateMethod", "");
            this.colsHideFlag.NamedProperties.Put("FieldFlags", "294");
            this.colsHideFlag.NamedProperties.Put("LovReference", "");
            this.colsHideFlag.NamedProperties.Put("ResizeableChildObject", "");
            this.colsHideFlag.NamedProperties.Put("SqlColumn", "HIDE_FLAG");
            this.colsHideFlag.NamedProperties.Put("ValidateMethod", "");
            this.colsHideFlag.Position = 7;
            resources.ApplyResources(this.colsHideFlag, "colsHideFlag");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_ExportGroup});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_ExportGroup
            // 
            this.menuItem_ExportGroup.Command = this.cmdExportGroup;
            this.menuItem_ExportGroup.Name = "menuItem_ExportGroup";
            resources.ApplyResources(this.menuItem_ExportGroup, "menuItem_ExportGroup");
            this.menuItem_ExportGroup.Text = "&Export Group...";
            // 
            // tbwIntfaceGroup
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsGroupId);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colNoteText);
            this.Controls.Add(this.colsExportGroup);
            this.Controls.Add(this.colsHideFlag);
            this.Name = "tbwIntfaceGroup";
            this.NamedProperties.Put("DefaultOrderBy", "GROUP_ID");
            this.NamedProperties.Put("DefaultWhere", "Intface_User_API.Get_Privilege(Fnd_Session_API.Get_FND_User) = Intface_Privilege_" +
        "API.Get_Client_Value(1)");
            this.NamedProperties.Put("LogicalUnit", "IntfaceGroup");
            this.NamedProperties.Put("PackageName", "INTFACE_GROUP_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.NamedProperties.Put("ViewName", "INTFACE_GROUP");
            this.Controls.SetChildIndex(this.colsHideFlag, 0);
            this.Controls.SetChildIndex(this.colsExportGroup, 0);
            this.Controls.SetChildIndex(this.colNoteText, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsGroupId, 0);
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

        public Fnd.Windows.Forms.FndCommand cmdExportGroup;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_ExportGroup;
	}
}
