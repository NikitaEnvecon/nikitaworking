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
	
	public partial class tbwIntfaceUser
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsIdentity;
		public cLookupColumn colsPrivilege;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfaceUser));
            this.menuItemPrUser = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsIdentity = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPrivilege = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_PrUser = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuItemPrUser);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuItemPrUser
            // 
            resources.ApplyResources(this.menuItemPrUser, "menuItemPrUser");
            this.menuItemPrUser.Name = "menuItemPrUser";
            this.menuItemPrUser.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Pr_Execute);
            this.menuItemPrUser.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Pr_Inquire);
            // 
            // colsIdentity
            // 
            this.colsIdentity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsIdentity.MaxLength = 30;
            this.colsIdentity.Name = "colsIdentity";
            this.colsIdentity.NamedProperties.Put("EnumerateMethod", "");
            this.colsIdentity.NamedProperties.Put("FieldFlags", "163");
            this.colsIdentity.NamedProperties.Put("LovReference", "FND_USER");
            this.colsIdentity.NamedProperties.Put("ResizeableChildObject", "");
            this.colsIdentity.NamedProperties.Put("SqlColumn", "IDENTITY");
            this.colsIdentity.NamedProperties.Put("ValidateMethod", "");
            this.colsIdentity.Position = 3;
            resources.ApplyResources(this.colsIdentity, "colsIdentity");
            // 
            // colsPrivilege
            // 
            this.colsPrivilege.MaxLength = 200;
            this.colsPrivilege.Name = "colsPrivilege";
            this.colsPrivilege.NamedProperties.Put("EnumerateMethod", "INTFACE_PRIVILEGE_API.Enumerate");
            this.colsPrivilege.NamedProperties.Put("FieldFlags", "295");
            this.colsPrivilege.NamedProperties.Put("LovReference", "");
            this.colsPrivilege.NamedProperties.Put("SqlColumn", "PRIVILEGE");
            this.colsPrivilege.Position = 4;
            resources.ApplyResources(this.colsPrivilege, "colsPrivilege");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_PrUser});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_PrUser
            // 
            this.menuItem_PrUser.Command = this.menuItemPrUser;
            this.menuItem_PrUser.Name = "menuItem_PrUser";
            resources.ApplyResources(this.menuItem_PrUser, "menuItem_PrUser");
            this.menuItem_PrUser.Text = "Pr &User...";
            // 
            // tbwIntfaceUser
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsIdentity);
            this.Controls.Add(this.colsPrivilege);
            this.Name = "tbwIntfaceUser";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "(Intface_User_API.Get_Privilege(Fnd_Session_API.Get_Fnd_User) = Intface_Privilege" +
        "_API.Get_Client_Value(1)\r\nOR Fnd_Session_API.Get_Fnd_User = Fnd_Session_API.get_" +
        "app_owner)");
            this.NamedProperties.Put("LogicalUnit", "IntfaceUser");
            this.NamedProperties.Put("PackageName", "Intface_User_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "INTFACE_USER");
            this.Controls.SetChildIndex(this.colsPrivilege, 0);
            this.Controls.SetChildIndex(this.colsIdentity, 0);
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

        public Fnd.Windows.Forms.FndCommand menuItemPrUser;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_PrUser;
	}
}
