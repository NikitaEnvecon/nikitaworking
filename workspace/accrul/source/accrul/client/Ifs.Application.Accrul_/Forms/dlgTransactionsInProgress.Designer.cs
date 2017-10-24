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
	
	public partial class dlgTransactionsInProgress
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls

        public cPushButton pbCancel;
		public cPushButton pbOk;
		public cPushButton pbClosePeriod;
		public cPushButton pbCloseFinally;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgTransactionsInProgress));
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbClosePeriod = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCloseFinally = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.tblTransInProgress = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblTransInProgress_colsMessageType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblTransInProgress_colsMessageText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblTransInProgress_colsTransExist = new Ifs.Fnd.ApplicationForms.cColumn();
            this.ClientArea.SuspendLayout();
            this.tblTransInProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.Create = true;
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbCloseFinally);
            this.ClientArea.Controls.Add(this.pbClosePeriod);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.tblTransInProgress);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCloseFinally);
            this.commandManager.Components.Add(this.pbClosePeriod);
            this.commandManager.Components.Add(this.pbOk);
            this.commandManager.Components.Add(this.pbCancel);
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "Cancel");
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "OK");
            // 
            // pbClosePeriod
            // 
            resources.ApplyResources(this.pbClosePeriod, "pbClosePeriod");
            this.pbClosePeriod.Name = "pbClosePeriod";
            this.pbClosePeriod.NamedProperties.Put("MethodId", "18385");
            this.pbClosePeriod.NamedProperties.Put("MethodParameter", "ClosePeriod");
            this.pbClosePeriod.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCloseFinally
            // 
            resources.ApplyResources(this.pbCloseFinally, "pbCloseFinally");
            this.pbCloseFinally.Name = "pbCloseFinally";
            this.pbCloseFinally.NamedProperties.Put("MethodId", "18385");
            this.pbCloseFinally.NamedProperties.Put("MethodParameter", "CloseFinally");
            this.pbCloseFinally.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // tblTransInProgress
            // 
            this.tblTransInProgress.Controls.Add(this.tblTransInProgress_colsMessageType);
            this.tblTransInProgress.Controls.Add(this.tblTransInProgress_colsMessageText);
            this.tblTransInProgress.Controls.Add(this.tblTransInProgress_colsTransExist);
            resources.ApplyResources(this.tblTransInProgress, "tblTransInProgress");
            this.tblTransInProgress.Name = "tblTransInProgress";
            this.tblTransInProgress.NamedProperties.Put("DefaultOrderBy", "");
            this.tblTransInProgress.NamedProperties.Put("DefaultWhere", "");
            this.tblTransInProgress.NamedProperties.Put("LogicalUnit", "");
            this.tblTransInProgress.NamedProperties.Put("PackageName", "");
            this.tblTransInProgress.NamedProperties.Put("ResizeableChildObject", "FLFM");
            this.tblTransInProgress.NamedProperties.Put("SourceFlags", "1");
            this.tblTransInProgress.NamedProperties.Put("ViewName", "");
            this.tblTransInProgress.NamedProperties.Put("Warnings", "FALSE");
            this.tblTransInProgress.Controls.SetChildIndex(this.tblTransInProgress_colsTransExist, 0);
            this.tblTransInProgress.Controls.SetChildIndex(this.tblTransInProgress_colsMessageText, 0);
            this.tblTransInProgress.Controls.SetChildIndex(this.tblTransInProgress_colsMessageType, 0);
            // 
            // tblTransInProgress_colsMessageType
            // 
            this.tblTransInProgress_colsMessageType.Name = "tblTransInProgress_colsMessageType";
            this.tblTransInProgress_colsMessageType.Position = 3;
            resources.ApplyResources(this.tblTransInProgress_colsMessageType, "tblTransInProgress_colsMessageType");
            // 
            // tblTransInProgress_colsMessageText
            // 
            this.tblTransInProgress_colsMessageText.Name = "tblTransInProgress_colsMessageText";
            this.tblTransInProgress_colsMessageText.Position = 4;
            resources.ApplyResources(this.tblTransInProgress_colsMessageText, "tblTransInProgress_colsMessageText");
            // 
            // tblTransInProgress_colsTransExist
            // 
            this.tblTransInProgress_colsTransExist.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.tblTransInProgress_colsTransExist.CheckBox.CheckedValue = "TRUE";
            this.tblTransInProgress_colsTransExist.CheckBox.IgnoreCase = true;
            this.tblTransInProgress_colsTransExist.CheckBox.UncheckedValue = "FALSE";
            resources.ApplyResources(this.tblTransInProgress_colsTransExist, "tblTransInProgress_colsTransExist");
            this.tblTransInProgress_colsTransExist.Name = "tblTransInProgress_colsTransExist";
            this.tblTransInProgress_colsTransExist.Position = 5;
            // 
            // dlgTransactionsInProgress
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgTransactionsInProgress";
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgTransactionsInProgress_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.tblTransInProgress.ResumeLayout(false);
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

        public cChildTableFinBase tblTransInProgress;
        protected cColumn tblTransInProgress_colsMessageType;
        protected cColumn tblTransInProgress_colsMessageText;
        protected cColumn tblTransInProgress_colsTransExist;
		
	}
}
