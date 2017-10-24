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
using PPJ.Runtime.Windows;

namespace Ifs.Application.Fndmig_
{

    public partial class frmIntfacePrUser
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Window Controls
        protected SalBackgroundText labelecmbIdentity;
        protected cRecSelExtComboBox ecmbIdentity;
        protected cChildTable tblIntfacePrUser;
        protected cColumn tblIntfacePrUser_colsIdentity;
        protected cColumn tblIntfacePrUser_colsIntfaceName;
        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntfacePrUser));
            this.labelecmbIdentity = new PPJ.Runtime.Windows.SalBackgroundText();
            this.ecmbIdentity = new Ifs.Fnd.ApplicationForms.cRecSelExtComboBox();
            this.tblIntfacePrUser = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.tblIntfacePrUser_colsIdentity = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntfacePrUser_colsIntfaceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblIntfacePrUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.ImageList = null;
            // 
            // labelecmbIdentity
            // 
            resources.ApplyResources(this.labelecmbIdentity, "labelecmbIdentity");
            this.labelecmbIdentity.Name = "labelecmbIdentity";
            // 
            // ecmbIdentity
            // 
            resources.ApplyResources(this.ecmbIdentity, "ecmbIdentity");
            this.ecmbIdentity.Name = "ecmbIdentity";
            this.ecmbIdentity.NamedProperties.Put("EnumerateMethod", "");
            this.ecmbIdentity.NamedProperties.Put("FieldFlags", "163");
            this.ecmbIdentity.NamedProperties.Put("Format", "9");
            this.ecmbIdentity.NamedProperties.Put("LovReference", "");
            this.ecmbIdentity.NamedProperties.Put("ResizeableChildObject", "");
            this.ecmbIdentity.NamedProperties.Put("SqlColumn", "IDENTITY");
            this.ecmbIdentity.NamedProperties.Put("ValidateMethod", "");
            this.ecmbIdentity.NamedProperties.Put("XDataLength", "30");
            // 
            // tblIntfacePrUser
            // 
            this.tblIntfacePrUser.Controls.Add(this.tblIntfacePrUser_colsIdentity);
            this.tblIntfacePrUser.Controls.Add(this.tblIntfacePrUser_colsIntfaceName);
            resources.ApplyResources(this.tblIntfacePrUser, "tblIntfacePrUser");
            this.tblIntfacePrUser.Name = "tblIntfacePrUser";
            this.tblIntfacePrUser.NamedProperties.Put("DefaultOrderBy", "");
            this.tblIntfacePrUser.NamedProperties.Put("DefaultWhere", "");
            this.tblIntfacePrUser.NamedProperties.Put("LogicalUnit", "IntfacePrUser");
            this.tblIntfacePrUser.NamedProperties.Put("PackageName", "Intface_Pr_User_API");
            this.tblIntfacePrUser.NamedProperties.Put("ResizeableChildObject", "MLMM");
            this.tblIntfacePrUser.NamedProperties.Put("ViewName", "INTFACE_PR_USER");
            this.tblIntfacePrUser.Controls.SetChildIndex(this.tblIntfacePrUser_colsIntfaceName, 0);
            this.tblIntfacePrUser.Controls.SetChildIndex(this.tblIntfacePrUser_colsIdentity, 0);
            // 
            // tblIntfacePrUser_colsIdentity
            // 
            this.tblIntfacePrUser_colsIdentity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblIntfacePrUser_colsIdentity, "tblIntfacePrUser_colsIdentity");
            this.tblIntfacePrUser_colsIdentity.MaxLength = 30;
            this.tblIntfacePrUser_colsIdentity.Name = "tblIntfacePrUser_colsIdentity";
            this.tblIntfacePrUser_colsIdentity.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntfacePrUser_colsIdentity.NamedProperties.Put("FieldFlags", "67");
            this.tblIntfacePrUser_colsIdentity.NamedProperties.Put("LovReference", "INTFACE_USER");
            this.tblIntfacePrUser_colsIdentity.NamedProperties.Put("SqlColumn", "IDENTITY");
            this.tblIntfacePrUser_colsIdentity.Position = 3;
            // 
            // tblIntfacePrUser_colsIntfaceName
            // 
            this.tblIntfacePrUser_colsIntfaceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblIntfacePrUser_colsIntfaceName.MaxLength = 30;
            this.tblIntfacePrUser_colsIntfaceName.Name = "tblIntfacePrUser_colsIntfaceName";
            this.tblIntfacePrUser_colsIntfaceName.NamedProperties.Put("EnumerateMethod", "");
            this.tblIntfacePrUser_colsIntfaceName.NamedProperties.Put("FieldFlags", "163");
            this.tblIntfacePrUser_colsIntfaceName.NamedProperties.Put("LovReference", "INTFACE_HEADER");
            this.tblIntfacePrUser_colsIntfaceName.NamedProperties.Put("SqlColumn", "INTFACE_NAME");
            this.tblIntfacePrUser_colsIntfaceName.Position = 4;
            resources.ApplyResources(this.tblIntfacePrUser_colsIntfaceName, "tblIntfacePrUser_colsIntfaceName");
            // 
            // frmIntfacePrUser
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblIntfacePrUser);
            this.Controls.Add(this.ecmbIdentity);
            this.Controls.Add(this.labelecmbIdentity);
            this.Name = "frmIntfacePrUser";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "Intface_User_API.Get_Privilege(Fnd_Session_API.Get_FND_User) = Intface_Privilege_" +
        "API.Get_Client_Value(1)");
            this.NamedProperties.Put("LogicalUnit", "IntfaceUser");
            this.NamedProperties.Put("PackageName", "Intface_User_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "INTFACE_USER");
            this.tblIntfacePrUser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
