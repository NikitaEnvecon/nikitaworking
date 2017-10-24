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
	
	public partial class dlgExtNewUserData
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataField dfsCompany;
		protected SalGroupBox gbNew_User_Data;
		protected cBackgroundText labeldfsUserId;
		public cDataField dfsUserId;
		protected cBackgroundText labeldfsUserGroup;
		public cDataField dfsUserGroup;
		public cPushButton pbOk;
		public cPushButton pbCancel;
		public cPushButton pbList;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgExtNewUserData));
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbNew_User_Data = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfsUserId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsUserId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsUserGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsUserGroup = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbList = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbList);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.dfsUserGroup);
            this.ClientArea.Controls.Add(this.dfsUserId);
            this.ClientArea.Controls.Add(this.dfsCompany);
            this.ClientArea.Controls.Add(this.labeldfsUserGroup);
            this.ClientArea.Controls.Add(this.labeldfsUserId);
            this.ClientArea.Controls.Add(this.gbNew_User_Data);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbList);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // dfsCompany
            // 
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("LovReference", "");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbNew_User_Data
            // 
            resources.ApplyResources(this.gbNew_User_Data, "gbNew_User_Data");
            this.gbNew_User_Data.Name = "gbNew_User_Data";
            this.gbNew_User_Data.TabStop = false;
            // 
            // labeldfsUserId
            // 
            resources.ApplyResources(this.labeldfsUserId, "labeldfsUserId");
            this.labeldfsUserId.Name = "labeldfsUserId";
            // 
            // dfsUserId
            // 
            this.dfsUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsUserId, "dfsUserId");
            this.dfsUserId.Name = "dfsUserId";
            this.dfsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsUserId.NamedProperties.Put("FieldFlags", "260");
            this.dfsUserId.NamedProperties.Put("LovReference", "USER_FINANCE(COMPANY)");
            this.dfsUserId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsUserId.NamedProperties.Put("SqlColumn", "USER_ID");
            this.dfsUserId.NamedProperties.Put("ValidateMethod", "");
            this.dfsUserId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsUserId_WindowActions);
            // 
            // labeldfsUserGroup
            // 
            resources.ApplyResources(this.labeldfsUserGroup, "labeldfsUserGroup");
            this.labeldfsUserGroup.Name = "labeldfsUserGroup";
            // 
            // dfsUserGroup
            // 
            this.dfsUserGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsUserGroup, "dfsUserGroup");
            this.dfsUserGroup.Name = "dfsUserGroup";
            this.dfsUserGroup.NamedProperties.Put("EnumerateMethod", "");
            this.dfsUserGroup.NamedProperties.Put("FieldFlags", "260");
            this.dfsUserGroup.NamedProperties.Put("LovReference", "USER_GROUP_MEMBER_FINANCE2(COMPANY,USER_ID)");
            this.dfsUserGroup.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsUserGroup.NamedProperties.Put("SqlColumn", "USER_GROUP");
            this.dfsUserGroup.NamedProperties.Put("ValidateMethod", "");
            this.dfsUserGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsUserGroup_WindowActions);
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "Ok");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "Cancel");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbList
            // 
            this.pbList.AcceleratorKey = System.Windows.Forms.Keys.F8;
            resources.ApplyResources(this.pbList, "pbList");
            this.pbList.Name = "pbList";
            this.pbList.NamedProperties.Put("MethodId", "18385");
            this.pbList.NamedProperties.Put("MethodParameter", "List");
            this.pbList.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // dlgExtNewUserData
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgExtNewUserData";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtTransactions");
            this.NamedProperties.Put("PackageName", "EXT_TRANSACTIONS_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "EXT_TRANSACTIONS");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
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
