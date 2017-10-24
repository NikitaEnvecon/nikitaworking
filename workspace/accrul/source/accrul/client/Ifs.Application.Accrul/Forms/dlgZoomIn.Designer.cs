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
	
	public partial class dlgZoomIn
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected SalGroupBox gbZoom_in_Information;
		protected cBackgroundText labeldfBGHeader;
		public cDataField dfBGHeader;
		public cCheckBoxFin cbPeriod;
		public cCheckBoxFin cbAccountType;
		public cCheckBoxFin cbAccountGroup;
		public cCheckBoxFin cbAttribute;
		public cCheckBoxFin cbAccount;
		public cCheckBoxFin cbCode_B;
		public cCheckBoxFin cbCode_C;
		public cCheckBoxFin cbCode_D;
		public cCheckBoxFin cbCode_E;
		public cCheckBoxFin cbCode_F;
		public cCheckBoxFin cbCode_G;
		public cCheckBoxFin cbCode_H;
		public cCheckBoxFin cbCode_I;
		public cCheckBoxFin cbCode_J;
		public cPushButton pbOK;
		public cPushButton pbCancel;
		// Bug 85079, Removed pbQuery
		protected SalGroupBox gbBalance_Type;
		public cCheckBoxFin cbNormal;
		public cCheckBoxFin cbSimulation;
		protected SalGroupBox gbHold_Table;
		public cCheckBoxFin cbIncludeHold;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgZoomIn));
            this.gbZoom_in_Information = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfBGHeader = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfBGHeader = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbPeriod = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbAccountType = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbAccountGroup = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbAttribute = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbAccount = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbCode_B = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbCode_C = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbCode_D = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbCode_E = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbCode_F = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbCode_G = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbCode_H = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbCode_I = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbCode_J = new Ifs.Application.Accrul.cCheckBoxFin();
            this.pbOK = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.gbBalance_Type = new PPJ.Runtime.Windows.SalGroupBox();
            this.cbNormal = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbSimulation = new Ifs.Application.Accrul.cCheckBoxFin();
            this.gbHold_Table = new PPJ.Runtime.Windows.SalGroupBox();
            this.cbIncludeHold = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbIgnoreDescription = new Ifs.Application.Accrul.cCheckBoxFin();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.cbIgnoreDescription);
            this.ClientArea.Controls.Add(this.cbIncludeHold);
            this.ClientArea.Controls.Add(this.cbSimulation);
            this.ClientArea.Controls.Add(this.cbNormal);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOK);
            this.ClientArea.Controls.Add(this.cbCode_J);
            this.ClientArea.Controls.Add(this.cbCode_I);
            this.ClientArea.Controls.Add(this.cbCode_H);
            this.ClientArea.Controls.Add(this.cbCode_G);
            this.ClientArea.Controls.Add(this.cbCode_F);
            this.ClientArea.Controls.Add(this.cbCode_E);
            this.ClientArea.Controls.Add(this.cbCode_D);
            this.ClientArea.Controls.Add(this.cbCode_C);
            this.ClientArea.Controls.Add(this.cbCode_B);
            this.ClientArea.Controls.Add(this.cbAccount);
            this.ClientArea.Controls.Add(this.cbAttribute);
            this.ClientArea.Controls.Add(this.cbAccountGroup);
            this.ClientArea.Controls.Add(this.cbAccountType);
            this.ClientArea.Controls.Add(this.cbPeriod);
            this.ClientArea.Controls.Add(this.dfBGHeader);
            this.ClientArea.Controls.Add(this.labeldfBGHeader);
            this.ClientArea.Controls.Add(this.gbHold_Table);
            this.ClientArea.Controls.Add(this.gbBalance_Type);
            this.ClientArea.Controls.Add(this.gbZoom_in_Information);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOK);
            // 
            // gbZoom_in_Information
            // 
            resources.ApplyResources(this.gbZoom_in_Information, "gbZoom_in_Information");
            this.gbZoom_in_Information.Name = "gbZoom_in_Information";
            this.gbZoom_in_Information.TabStop = false;
            // 
            // labeldfBGHeader
            // 
            resources.ApplyResources(this.labeldfBGHeader, "labeldfBGHeader");
            this.labeldfBGHeader.Name = "labeldfBGHeader";
            // 
            // dfBGHeader
            // 
            resources.ApplyResources(this.dfBGHeader, "dfBGHeader");
            this.dfBGHeader.Name = "dfBGHeader";
            // 
            // cbPeriod
            // 
            resources.ApplyResources(this.cbPeriod, "cbPeriod");
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.NamedProperties.Put("DataType", "5");
            this.cbPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.cbPeriod.NamedProperties.Put("FieldFlags", "258");
            this.cbPeriod.NamedProperties.Put("LovReference", "");
            this.cbPeriod.NamedProperties.Put("ParentName", "");
            this.cbPeriod.NamedProperties.Put("SqlColumn", "");
            this.cbPeriod.NamedProperties.Put("ValidateMethod", "");
            this.cbPeriod.NamedProperties.Put("XDataLength", "");
            // 
            // cbAccountType
            // 
            resources.ApplyResources(this.cbAccountType, "cbAccountType");
            this.cbAccountType.Name = "cbAccountType";
            this.cbAccountType.NamedProperties.Put("DataType", "5");
            this.cbAccountType.NamedProperties.Put("EnumerateMethod", "");
            this.cbAccountType.NamedProperties.Put("FieldFlags", "258");
            this.cbAccountType.NamedProperties.Put("LovReference", "");
            this.cbAccountType.NamedProperties.Put("ParentName", "");
            this.cbAccountType.NamedProperties.Put("SqlColumn", "");
            this.cbAccountType.NamedProperties.Put("ValidateMethod", "");
            this.cbAccountType.NamedProperties.Put("XDataLength", "");
            // 
            // cbAccountGroup
            // 
            resources.ApplyResources(this.cbAccountGroup, "cbAccountGroup");
            this.cbAccountGroup.Name = "cbAccountGroup";
            this.cbAccountGroup.NamedProperties.Put("DataType", "5");
            this.cbAccountGroup.NamedProperties.Put("EnumerateMethod", "");
            this.cbAccountGroup.NamedProperties.Put("FieldFlags", "258");
            this.cbAccountGroup.NamedProperties.Put("LovReference", "");
            this.cbAccountGroup.NamedProperties.Put("ParentName", "");
            this.cbAccountGroup.NamedProperties.Put("SqlColumn", "");
            this.cbAccountGroup.NamedProperties.Put("ValidateMethod", "");
            this.cbAccountGroup.NamedProperties.Put("XDataLength", "");
            // 
            // cbAttribute
            // 
            resources.ApplyResources(this.cbAttribute, "cbAttribute");
            this.cbAttribute.Name = "cbAttribute";
            this.cbAttribute.NamedProperties.Put("DataType", "5");
            this.cbAttribute.NamedProperties.Put("EnumerateMethod", "");
            this.cbAttribute.NamedProperties.Put("FieldFlags", "258");
            this.cbAttribute.NamedProperties.Put("LovReference", "");
            this.cbAttribute.NamedProperties.Put("ParentName", "");
            this.cbAttribute.NamedProperties.Put("SqlColumn", "");
            this.cbAttribute.NamedProperties.Put("ValidateMethod", "");
            this.cbAttribute.NamedProperties.Put("XDataLength", "");
            // 
            // cbAccount
            // 
            resources.ApplyResources(this.cbAccount, "cbAccount");
            this.cbAccount.Name = "cbAccount";
            this.cbAccount.NamedProperties.Put("DataType", "5");
            this.cbAccount.NamedProperties.Put("EnumerateMethod", "");
            this.cbAccount.NamedProperties.Put("FieldFlags", "258");
            this.cbAccount.NamedProperties.Put("LovReference", "");
            this.cbAccount.NamedProperties.Put("SqlColumn", "");
            this.cbAccount.NamedProperties.Put("ValidateMethod", "");
            this.cbAccount.NamedProperties.Put("XDataLength", "");
            // 
            // cbCode_B
            // 
            resources.ApplyResources(this.cbCode_B, "cbCode_B");
            this.cbCode_B.Name = "cbCode_B";
            this.cbCode_B.NamedProperties.Put("DataType", "5");
            this.cbCode_B.NamedProperties.Put("EnumerateMethod", "");
            this.cbCode_B.NamedProperties.Put("FieldFlags", "258");
            this.cbCode_B.NamedProperties.Put("LovReference", "");
            this.cbCode_B.NamedProperties.Put("ParentName", "");
            this.cbCode_B.NamedProperties.Put("SqlColumn", "");
            this.cbCode_B.NamedProperties.Put("ValidateMethod", "");
            this.cbCode_B.NamedProperties.Put("XDataLength", "");
            // 
            // cbCode_C
            // 
            resources.ApplyResources(this.cbCode_C, "cbCode_C");
            this.cbCode_C.Name = "cbCode_C";
            this.cbCode_C.NamedProperties.Put("DataType", "5");
            this.cbCode_C.NamedProperties.Put("EnumerateMethod", "");
            this.cbCode_C.NamedProperties.Put("FieldFlags", "258");
            this.cbCode_C.NamedProperties.Put("LovReference", "");
            this.cbCode_C.NamedProperties.Put("ParentName", "");
            this.cbCode_C.NamedProperties.Put("SqlColumn", "");
            this.cbCode_C.NamedProperties.Put("ValidateMethod", "");
            this.cbCode_C.NamedProperties.Put("XDataLength", "");
            // 
            // cbCode_D
            // 
            resources.ApplyResources(this.cbCode_D, "cbCode_D");
            this.cbCode_D.Name = "cbCode_D";
            this.cbCode_D.NamedProperties.Put("DataType", "5");
            this.cbCode_D.NamedProperties.Put("EnumerateMethod", "");
            this.cbCode_D.NamedProperties.Put("FieldFlags", "258");
            this.cbCode_D.NamedProperties.Put("LovReference", "");
            this.cbCode_D.NamedProperties.Put("ParentName", "");
            this.cbCode_D.NamedProperties.Put("SqlColumn", "");
            this.cbCode_D.NamedProperties.Put("ValidateMethod", "");
            this.cbCode_D.NamedProperties.Put("XDataLength", "");
            // 
            // cbCode_E
            // 
            resources.ApplyResources(this.cbCode_E, "cbCode_E");
            this.cbCode_E.Name = "cbCode_E";
            this.cbCode_E.NamedProperties.Put("DataType", "5");
            this.cbCode_E.NamedProperties.Put("EnumerateMethod", "");
            this.cbCode_E.NamedProperties.Put("FieldFlags", "258");
            this.cbCode_E.NamedProperties.Put("LovReference", "");
            this.cbCode_E.NamedProperties.Put("ParentName", "");
            this.cbCode_E.NamedProperties.Put("SqlColumn", "");
            this.cbCode_E.NamedProperties.Put("ValidateMethod", "");
            this.cbCode_E.NamedProperties.Put("XDataLength", "");
            // 
            // cbCode_F
            // 
            resources.ApplyResources(this.cbCode_F, "cbCode_F");
            this.cbCode_F.Name = "cbCode_F";
            this.cbCode_F.NamedProperties.Put("DataType", "5");
            this.cbCode_F.NamedProperties.Put("EnumerateMethod", "");
            this.cbCode_F.NamedProperties.Put("FieldFlags", "258");
            this.cbCode_F.NamedProperties.Put("LovReference", "");
            this.cbCode_F.NamedProperties.Put("ParentName", "");
            this.cbCode_F.NamedProperties.Put("SqlColumn", "");
            this.cbCode_F.NamedProperties.Put("ValidateMethod", "");
            this.cbCode_F.NamedProperties.Put("XDataLength", "");
            // 
            // cbCode_G
            // 
            resources.ApplyResources(this.cbCode_G, "cbCode_G");
            this.cbCode_G.Name = "cbCode_G";
            this.cbCode_G.NamedProperties.Put("DataType", "5");
            this.cbCode_G.NamedProperties.Put("EnumerateMethod", "");
            this.cbCode_G.NamedProperties.Put("FieldFlags", "258");
            this.cbCode_G.NamedProperties.Put("LovReference", "");
            this.cbCode_G.NamedProperties.Put("ParentName", "");
            this.cbCode_G.NamedProperties.Put("SqlColumn", "");
            this.cbCode_G.NamedProperties.Put("ValidateMethod", "");
            this.cbCode_G.NamedProperties.Put("XDataLength", "");
            // 
            // cbCode_H
            // 
            resources.ApplyResources(this.cbCode_H, "cbCode_H");
            this.cbCode_H.Name = "cbCode_H";
            this.cbCode_H.NamedProperties.Put("DataType", "5");
            this.cbCode_H.NamedProperties.Put("EnumerateMethod", "");
            this.cbCode_H.NamedProperties.Put("FieldFlags", "258");
            this.cbCode_H.NamedProperties.Put("LovReference", "");
            this.cbCode_H.NamedProperties.Put("ParentName", "");
            this.cbCode_H.NamedProperties.Put("SqlColumn", "");
            this.cbCode_H.NamedProperties.Put("ValidateMethod", "");
            this.cbCode_H.NamedProperties.Put("XDataLength", "");
            // 
            // cbCode_I
            // 
            resources.ApplyResources(this.cbCode_I, "cbCode_I");
            this.cbCode_I.Name = "cbCode_I";
            this.cbCode_I.NamedProperties.Put("DataType", "5");
            this.cbCode_I.NamedProperties.Put("EnumerateMethod", "");
            this.cbCode_I.NamedProperties.Put("FieldFlags", "258");
            this.cbCode_I.NamedProperties.Put("LovReference", "");
            this.cbCode_I.NamedProperties.Put("ParentName", "");
            this.cbCode_I.NamedProperties.Put("SqlColumn", "");
            this.cbCode_I.NamedProperties.Put("ValidateMethod", "");
            this.cbCode_I.NamedProperties.Put("XDataLength", "");
            // 
            // cbCode_J
            // 
            resources.ApplyResources(this.cbCode_J, "cbCode_J");
            this.cbCode_J.Name = "cbCode_J";
            this.cbCode_J.NamedProperties.Put("DataType", "5");
            this.cbCode_J.NamedProperties.Put("EnumerateMethod", "");
            this.cbCode_J.NamedProperties.Put("FieldFlags", "258");
            this.cbCode_J.NamedProperties.Put("LovReference", "");
            this.cbCode_J.NamedProperties.Put("SqlColumn", "");
            this.cbCode_J.NamedProperties.Put("ValidateMethod", "");
            this.cbCode_J.NamedProperties.Put("XDataLength", "");
            // 
            // pbOK
            // 
            this.pbOK.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOK, "pbOK");
            this.pbOK.Name = "pbOK";
            this.pbOK.NamedProperties.Put("MethodId", "18385");
            this.pbOK.NamedProperties.Put("MethodParameter", "OK");
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "CANCEL");
            // 
            // gbBalance_Type
            // 
            resources.ApplyResources(this.gbBalance_Type, "gbBalance_Type");
            this.gbBalance_Type.Name = "gbBalance_Type";
            this.gbBalance_Type.TabStop = false;
            // 
            // cbNormal
            // 
            resources.ApplyResources(this.cbNormal, "cbNormal");
            this.cbNormal.Name = "cbNormal";
            this.cbNormal.NamedProperties.Put("DataType", "5");
            this.cbNormal.NamedProperties.Put("EnumerateMethod", "");
            this.cbNormal.NamedProperties.Put("FieldFlags", "258");
            this.cbNormal.NamedProperties.Put("LovReference", "");
            this.cbNormal.NamedProperties.Put("SqlColumn", "");
            this.cbNormal.NamedProperties.Put("ValidateMethod", "");
            this.cbNormal.NamedProperties.Put("XDataLength", "");
            // 
            // cbSimulation
            // 
            resources.ApplyResources(this.cbSimulation, "cbSimulation");
            this.cbSimulation.Name = "cbSimulation";
            this.cbSimulation.NamedProperties.Put("DataType", "5");
            this.cbSimulation.NamedProperties.Put("EnumerateMethod", "");
            this.cbSimulation.NamedProperties.Put("FieldFlags", "258");
            this.cbSimulation.NamedProperties.Put("LovReference", "");
            this.cbSimulation.NamedProperties.Put("SqlColumn", "");
            this.cbSimulation.NamedProperties.Put("ValidateMethod", "");
            this.cbSimulation.NamedProperties.Put("XDataLength", "");
            // 
            // gbHold_Table
            // 
            resources.ApplyResources(this.gbHold_Table, "gbHold_Table");
            this.gbHold_Table.Name = "gbHold_Table";
            this.gbHold_Table.TabStop = false;
            // 
            // cbIncludeHold
            // 
            resources.ApplyResources(this.cbIncludeHold, "cbIncludeHold");
            this.cbIncludeHold.Name = "cbIncludeHold";
            this.cbIncludeHold.NamedProperties.Put("DataType", "5");
            this.cbIncludeHold.NamedProperties.Put("EnumerateMethod", "");
            this.cbIncludeHold.NamedProperties.Put("FieldFlags", "258");
            this.cbIncludeHold.NamedProperties.Put("LovReference", "");
            this.cbIncludeHold.NamedProperties.Put("SqlColumn", "");
            this.cbIncludeHold.NamedProperties.Put("ValidateMethod", "");
            this.cbIncludeHold.NamedProperties.Put("XDataLength", "");
            // 
            // cbIgnoreDescription
            // 
            resources.ApplyResources(this.cbIgnoreDescription, "cbIgnoreDescription");
            this.cbIgnoreDescription.Name = "cbIgnoreDescription";
            this.cbIgnoreDescription.NamedProperties.Put("DataType", "5");
            this.cbIgnoreDescription.NamedProperties.Put("EnumerateMethod", "");
            this.cbIgnoreDescription.NamedProperties.Put("FieldFlags", "258");
            this.cbIgnoreDescription.NamedProperties.Put("LovReference", "");
            this.cbIgnoreDescription.NamedProperties.Put("SqlColumn", "");
            this.cbIgnoreDescription.NamedProperties.Put("ValidateMethod", "");
            this.cbIgnoreDescription.NamedProperties.Put("XDataLength", "");
            // 
            // dlgZoomIn
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgZoomIn";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgZoomIn_WindowActions);
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

        public cCheckBoxFin cbIgnoreDescription;
	}
}
