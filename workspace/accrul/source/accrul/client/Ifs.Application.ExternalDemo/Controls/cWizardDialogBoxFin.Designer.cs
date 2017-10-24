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
using Ifs.Application.Appsrv;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Accrul
{
	
	public partial class cWizardDialogBoxFin
	{
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cWizardDialogBoxFin));
            ((System.ComponentModel.ISupportInitialize)(this.picWizard)).BeginInit();
            this.ToolBar.SuspendLayout();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbFinish
            // 
            this.pbFinish.NamedProperties.Put("MethodId", "18385");
            this.pbFinish.NamedProperties.Put("MethodIdStr", "");
            this.pbFinish.NamedProperties.Put("MethodParameter", "Finish");
            this.pbFinish.NamedProperties.Put("MethodParameterType", "String");
            this.pbFinish.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.pbFinish.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbNext
            // 
            this.pbNext.NamedProperties.Put("MethodId", "18385");
            this.pbNext.NamedProperties.Put("MethodIdStr", "");
            this.pbNext.NamedProperties.Put("MethodParameter", "Next");
            this.pbNext.NamedProperties.Put("MethodParameterType", "String");
            this.pbNext.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.pbNext.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbBack
            // 
            this.pbBack.NamedProperties.Put("MethodId", "18385");
            this.pbBack.NamedProperties.Put("MethodIdStr", "");
            this.pbBack.NamedProperties.Put("MethodParameter", "Back");
            this.pbBack.NamedProperties.Put("MethodParameterType", "String");
            this.pbBack.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.pbBack.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodIdStr", "");
            this.pbCancel.NamedProperties.Put("MethodParameter", "Cancel");
            this.pbCancel.NamedProperties.Put("MethodParameterType", "String");
            this.pbCancel.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbList
            // 
            this.pbList.NamedProperties.Put("MethodId", "18385");
            this.pbList.NamedProperties.Put("MethodIdStr", "");
            this.pbList.NamedProperties.Put("MethodParameter", "List");
            this.pbList.NamedProperties.Put("MethodParameterType", "String");
            this.pbList.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.pbList.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // cWizardDialogBoxFin
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "cWizardDialogBoxFin";
            this.NamedProperties.Put("Module", "%");
            this.NamedProperties.Put("SourceFlags", "449");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cWizardDialogBoxFin_WindowActions);
            ((System.ComponentModel.ISupportInitialize)(this.picWizard)).EndInit();
            this.ToolBar.ResumeLayout(false);
            this.ClientArea.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
	}
}
