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
	
	public partial class frmTaxBookStructureView
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cTreeListBox lbStructure;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaxBookStructureView));
            this.lbStructure = new Ifs.Fnd.ApplicationForms.cTreeListBox();
            this.SuspendLayout();
            // 
            // lbStructure
            // 
            this.lbStructure.LineColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lbStructure, "lbStructure");
            this.lbStructure.Name = "lbStructure";
            this.lbStructure.NamedProperties.Put("AllowedEditing", "TRUE");
            this.lbStructure.NamedProperties.Put("AutoExpand", "FALSE");
            this.lbStructure.NamedProperties.Put("NodeCount", "2");
            this.lbStructure.NamedProperties.Put("NodeType0", "!0\n$NODELABEL=Node\n$NODEPICNOTSELECT=NavigatorIcon_Folder\n$NODEPICSELECT=Navigato" +
                    "rIcon_Folder\n$NODEDISATTRIB=NAME\n$NODEALLOWCUT=TRUE\n$NODEALLOWCOPY=FALSE\n$NODEPA" +
                    "STEFLAGS=!0\n-$0=2\n-$1=0\n-\n");
            this.lbStructure.NamedProperties.Put("NodeType1", "!1\n$NODELABEL=CodePart\n$NODEPICNOTSELECT=NavigatorIcon_Document\n$NODEPICSELECT=Na" +
                    "vigatorIcon_Document\n$NODEDISATTRIB=NAME\n$NODEALLOWCUT=TRUE\n$NODEALLOWCOPY=FALSE" +
                    "\n$NODEPASTEFLAGS=!1\n-$0=2\n-$1=0\n-\n");
            this.lbStructure.NamedProperties.Put("ResizeableChildObject", "LLRR");
            this.lbStructure.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.lbStructure_WindowActions);
            // 
            // frmTaxBookStructureView
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lbStructure);
            this.Name = "frmTaxBookStructureView";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "257");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmTaxBookStructureView_WindowActions);
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
