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
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Fndmig_
{
	
	public partial class tbwIntfaceRules
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsIntfaceName;
		public cColumn colsRuleId;
		public cColumn colsRuleDescription;
		public cColumn colsRuleValue;
		public cLookupColumn colsRuleFlag;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfaceRules));
            this.colsIntfaceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsRuleId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsRuleDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsRuleValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsRuleFlag = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.SuspendLayout();
            // 
            // colsIntfaceName
            // 
            this.colsIntfaceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsIntfaceName, "colsIntfaceName");
            this.colsIntfaceName.MaxLength = 30;
            this.colsIntfaceName.Name = "colsIntfaceName";
            this.colsIntfaceName.NamedProperties.Put("EnumerateMethod", "");
            this.colsIntfaceName.NamedProperties.Put("FieldFlags", "67");
            this.colsIntfaceName.NamedProperties.Put("LovReference", "INTFACE_HEADER");
            this.colsIntfaceName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsIntfaceName.NamedProperties.Put("SqlColumn", "INTFACE_NAME");
            this.colsIntfaceName.Position = 3;
            // 
            // colsRuleId
            // 
            this.colsRuleId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsRuleId.MaxLength = 20;
            this.colsRuleId.Name = "colsRuleId";
            this.colsRuleId.NamedProperties.Put("EnumerateMethod", "");
            this.colsRuleId.NamedProperties.Put("FieldFlags", "163");
            this.colsRuleId.NamedProperties.Put("LovReference", "INTFACE_RULES_LOV");
            this.colsRuleId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsRuleId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsRuleId.NamedProperties.Put("SqlColumn", "RULE_ID");
            this.colsRuleId.NamedProperties.Put("ValidateMethod", "");
            this.colsRuleId.Position = 4;
            resources.ApplyResources(this.colsRuleId, "colsRuleId");
            // 
            // colsRuleDescription
            // 
            this.colsRuleDescription.Name = "colsRuleDescription";
            this.colsRuleDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsRuleDescription.NamedProperties.Put("FieldFlags", "256");
            this.colsRuleDescription.NamedProperties.Put("LovReference", "");
            this.colsRuleDescription.NamedProperties.Put("ParentName", "colsRuleId");
            this.colsRuleDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsRuleDescription.NamedProperties.Put("SqlColumn", "&AO.Intface_Default_Rules_API.Get_Description(RULE_ID)");
            this.colsRuleDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsRuleDescription.Position = 5;
            resources.ApplyResources(this.colsRuleDescription, "colsRuleDescription");
            // 
            // colsRuleValue
            // 
            this.colsRuleValue.MaxLength = 2000;
            this.colsRuleValue.Name = "colsRuleValue";
            this.colsRuleValue.NamedProperties.Put("EnumerateMethod", "");
            this.colsRuleValue.NamedProperties.Put("FieldFlags", "310");
            this.colsRuleValue.NamedProperties.Put("LovReference", "");
            this.colsRuleValue.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsRuleValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colsRuleValue.NamedProperties.Put("SqlColumn", "RULE_VALUE");
            this.colsRuleValue.NamedProperties.Put("ValidateMethod", "");
            this.colsRuleValue.Position = 6;
            resources.ApplyResources(this.colsRuleValue, "colsRuleValue");
            // 
            // colsRuleFlag
            // 
            this.colsRuleFlag.MaxLength = 200;
            this.colsRuleFlag.Name = "colsRuleFlag";
            this.colsRuleFlag.NamedProperties.Put("EnumerateMethod", "INTFACE_RULE_FLAG_API.Enumerate");
            this.colsRuleFlag.NamedProperties.Put("FieldFlags", "295");
            this.colsRuleFlag.NamedProperties.Put("LovReference", "");
            this.colsRuleFlag.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsRuleFlag.NamedProperties.Put("SqlColumn", "RULE_FLAG");
            this.colsRuleFlag.Position = 7;
            resources.ApplyResources(this.colsRuleFlag, "colsRuleFlag");
            // 
            // tbwIntfaceRules
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsIntfaceName);
            this.Controls.Add(this.colsRuleId);
            this.Controls.Add(this.colsRuleDescription);
            this.Controls.Add(this.colsRuleValue);
            this.Controls.Add(this.colsRuleFlag);
            this.Name = "tbwIntfaceRules";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "IntfaceRules");
            this.NamedProperties.Put("PackageName", "Intface_Rules_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.NamedProperties.Put("ViewName", "INTFACE_RULES");
            this.Controls.SetChildIndex(this.colsRuleFlag, 0);
            this.Controls.SetChildIndex(this.colsRuleValue, 0);
            this.Controls.SetChildIndex(this.colsRuleDescription, 0);
            this.Controls.SetChildIndex(this.colsRuleId, 0);
            this.Controls.SetChildIndex(this.colsIntfaceName, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
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
