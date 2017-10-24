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
	
	public partial class tbwIntfaceDefaultRules
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsRuleId;
		public cColumn colsProcedureName;
		public cColumn colsDescription;
		public cColumn colsRuleValue;
		public cLookupColumn colsRuleFlag;
		public cLookupColumn colsValueFlag;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfaceDefaultRules));
            this.colsRuleId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsProcedureName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsRuleValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsRuleFlag = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsValueFlag = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.SuspendLayout();
            // 
            // colsRuleId
            // 
            this.colsRuleId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsRuleId.MaxLength = 20;
            this.colsRuleId.Name = "colsRuleId";
            this.colsRuleId.NamedProperties.Put("EnumerateMethod", "");
            this.colsRuleId.NamedProperties.Put("FieldFlags", "163");
            this.colsRuleId.NamedProperties.Put("LovReference", "");
            this.colsRuleId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsRuleId.NamedProperties.Put("SqlColumn", "RULE_ID");
            this.colsRuleId.Position = 3;
            resources.ApplyResources(this.colsRuleId, "colsRuleId");
            // 
            // colsProcedureName
            // 
            this.colsProcedureName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsProcedureName.Name = "colsProcedureName";
            this.colsProcedureName.NamedProperties.Put("EnumerateMethod", "");
            this.colsProcedureName.NamedProperties.Put("FieldFlags", "163");
            this.colsProcedureName.NamedProperties.Put("LovReference", "INTFACE_PROCEDURES");
            this.colsProcedureName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsProcedureName.NamedProperties.Put("SqlColumn", "PROCEDURE_NAME");
            this.colsProcedureName.Position = 4;
            resources.ApplyResources(this.colsProcedureName, "colsProcedureName");
            // 
            // colsDescription
            // 
            this.colsDescription.MaxLength = 4000;
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "291");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsDescription.Position = 5;
            resources.ApplyResources(this.colsDescription, "colsDescription");
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
            // colsValueFlag
            // 
            this.colsValueFlag.MaxLength = 200;
            this.colsValueFlag.Name = "colsValueFlag";
            this.colsValueFlag.NamedProperties.Put("EnumerateMethod", "INTFACE_RULE_VALUE_API.Enumerate");
            this.colsValueFlag.NamedProperties.Put("FieldFlags", "289");
            this.colsValueFlag.NamedProperties.Put("LovReference", "");
            this.colsValueFlag.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsValueFlag.NamedProperties.Put("SqlColumn", "VALUE_FLAG");
            this.colsValueFlag.Position = 8;
            resources.ApplyResources(this.colsValueFlag, "colsValueFlag");
            // 
            // tbwIntfaceDefaultRules
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsRuleId);
            this.Controls.Add(this.colsProcedureName);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsRuleValue);
            this.Controls.Add(this.colsRuleFlag);
            this.Controls.Add(this.colsValueFlag);
            this.Name = "tbwIntfaceDefaultRules";
            this.NamedProperties.Put("DefaultOrderBy", "PROCEDURE_NAME DESC, RULE_ID");
            this.NamedProperties.Put("DefaultWhere", "Intface_User_API.Get_Privilege(Fnd_Session_API.Get_FND_User) = Intface_Privilege_" +
                    "API.Get_Client_Value(1)");
            this.NamedProperties.Put("LogicalUnit", "IntfaceDefaultRules");
            this.NamedProperties.Put("PackageName", "Intface_Default_Rules_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "129");
            this.NamedProperties.Put("ViewName", "INTFACE_DEFAULT_RULES");
            this.Controls.SetChildIndex(this.colsValueFlag, 0);
            this.Controls.SetChildIndex(this.colsRuleFlag, 0);
            this.Controls.SetChildIndex(this.colsRuleValue, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsProcedureName, 0);
            this.Controls.SetChildIndex(this.colsRuleId, 0);
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
