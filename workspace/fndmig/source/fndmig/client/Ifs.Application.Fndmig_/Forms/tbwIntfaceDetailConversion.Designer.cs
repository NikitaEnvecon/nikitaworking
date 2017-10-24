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
	
	public partial class tbwIntfaceDetailConversion
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsIntfaceName;
		public cColumn colnPos;
		public cColumn colsColumnName;
		public cColumn colsColumnDescription;
		public cColumn colsColumnFlags;
		public cColumn colsDataType;
		public cColumn colnLength;
		public cColumn colsSourceColumn;
		public cColumn colsDefaultValue;
		public cColumn colDbClientValues;
		public cColumn colsConvListId;
		public cColumn colNoteText;
		public cLookupColumn colsChangeDefaults;
		public cColumn colnAttrSeq;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfaceDetailConversion));
            this.menuTbwMethods_menuConvert_columns___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsIntfaceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnPos = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsColumnName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsColumnDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsColumnFlags = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDataType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnLength = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSourceColumn = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDefaultValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDbClientValues = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsConvListId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colNoteText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsChangeDefaults = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colnAttrSeq = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Convert = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Translation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods_menuTranslation = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuConvert_columns___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuTranslation);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            this.commandManager.ImageList = null;
            // 
            // menuTbwMethods_menuConvert_columns___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuConvert_columns___, "menuTbwMethods_menuConvert_columns___");
            this.menuTbwMethods_menuConvert_columns___.Name = "menuTbwMethods_menuConvert_columns___";
            this.menuTbwMethods_menuConvert_columns___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Convert_Execute);
            this.menuTbwMethods_menuConvert_columns___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Convert_Inquire);
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
            this.colsIntfaceName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsIntfaceName.NamedProperties.Put("SqlColumn", "INTFACE_NAME");
            this.colsIntfaceName.NamedProperties.Put("ValidateMethod", "");
            this.colsIntfaceName.Position = 3;
            // 
            // colnPos
            // 
            this.colnPos.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnPos.Name = "colnPos";
            this.colnPos.NamedProperties.Put("EnumerateMethod", "");
            this.colnPos.NamedProperties.Put("FieldFlags", "295");
            this.colnPos.NamedProperties.Put("LovReference", "");
            this.colnPos.NamedProperties.Put("SqlColumn", "POS");
            this.colnPos.Position = 4;
            resources.ApplyResources(this.colnPos, "colnPos");
            // 
            // colsColumnName
            // 
            this.colsColumnName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsColumnName.MaxLength = 2000;
            this.colsColumnName.Name = "colsColumnName";
            this.colsColumnName.NamedProperties.Put("EnumerateMethod", "");
            this.colsColumnName.NamedProperties.Put("FieldFlags", "179");
            this.colsColumnName.NamedProperties.Put("LovReference", "");
            this.colsColumnName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsColumnName.NamedProperties.Put("SqlColumn", "COLUMN_NAME");
            this.colsColumnName.NamedProperties.Put("ValidateMethod", "");
            this.colsColumnName.Position = 5;
            resources.ApplyResources(this.colsColumnName, "colsColumnName");
            // 
            // colsColumnDescription
            // 
            this.colsColumnDescription.Name = "colsColumnDescription";
            this.colsColumnDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsColumnDescription.NamedProperties.Put("FieldFlags", "294");
            this.colsColumnDescription.NamedProperties.Put("LovReference", "");
            this.colsColumnDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsColumnDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsColumnDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsColumnDescription.Position = 6;
            resources.ApplyResources(this.colsColumnDescription, "colsColumnDescription");
            // 
            // colsColumnFlags
            // 
            this.colsColumnFlags.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsColumnFlags.MaxLength = 10;
            this.colsColumnFlags.Name = "colsColumnFlags";
            this.colsColumnFlags.NamedProperties.Put("EnumerateMethod", "");
            this.colsColumnFlags.NamedProperties.Put("FieldFlags", "290");
            this.colsColumnFlags.NamedProperties.Put("LovReference", "");
            this.colsColumnFlags.NamedProperties.Put("ResizeableChildObject", "");
            this.colsColumnFlags.NamedProperties.Put("SqlColumn", "FLAGS");
            this.colsColumnFlags.NamedProperties.Put("ValidateMethod", "");
            this.colsColumnFlags.Position = 7;
            resources.ApplyResources(this.colsColumnFlags, "colsColumnFlags");
            // 
            // colsDataType
            // 
            this.colsDataType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsDataType.MaxLength = 10;
            this.colsDataType.Name = "colsDataType";
            this.colsDataType.NamedProperties.Put("EnumerateMethod", "");
            this.colsDataType.NamedProperties.Put("FieldFlags", "295");
            this.colsDataType.NamedProperties.Put("LovReference", "");
            this.colsDataType.NamedProperties.Put("SqlColumn", "DATA_TYPE");
            this.colsDataType.Position = 8;
            resources.ApplyResources(this.colsDataType, "colsDataType");
            // 
            // colnLength
            // 
            this.colnLength.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnLength.Name = "colnLength";
            this.colnLength.NamedProperties.Put("EnumerateMethod", "");
            this.colnLength.NamedProperties.Put("FieldFlags", "295");
            this.colnLength.NamedProperties.Put("LovReference", "");
            this.colnLength.NamedProperties.Put("SqlColumn", "LENGTH");
            this.colnLength.Position = 9;
            resources.ApplyResources(this.colnLength, "colnLength");
            // 
            // colsSourceColumn
            // 
            this.colsSourceColumn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsSourceColumn.MaxLength = 2000;
            this.colsSourceColumn.Name = "colsSourceColumn";
            this.colsSourceColumn.NamedProperties.Put("EnumerateMethod", "");
            this.colsSourceColumn.NamedProperties.Put("FieldFlags", "310");
            this.colsSourceColumn.NamedProperties.Put("LovReference", "INTFACE_SOURCE_COL_LOV(INTFACE_HEADER_API.Get_Source_Name(INTFACE_NAME), INTFACE_" +
        "HEADER_API.Get_Source_Owner(INTFACE_NAME))");
            this.colsSourceColumn.NamedProperties.Put("ResizeableChildObject", "");
            this.colsSourceColumn.NamedProperties.Put("SqlColumn", "SOURCE_COLUMN");
            this.colsSourceColumn.NamedProperties.Put("ValidateMethod", "");
            this.colsSourceColumn.Position = 10;
            resources.ApplyResources(this.colsSourceColumn, "colsSourceColumn");
            // 
            // colsDefaultValue
            // 
            this.colsDefaultValue.MaxLength = 2000;
            this.colsDefaultValue.Name = "colsDefaultValue";
            this.colsDefaultValue.NamedProperties.Put("EnumerateMethod", "");
            this.colsDefaultValue.NamedProperties.Put("FieldFlags", "310");
            this.colsDefaultValue.NamedProperties.Put("LovReference", "");
            this.colsDefaultValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDefaultValue.NamedProperties.Put("SqlColumn", "DEFAULT_VALUE");
            this.colsDefaultValue.NamedProperties.Put("ValidateMethod", "");
            this.colsDefaultValue.Position = 11;
            resources.ApplyResources(this.colsDefaultValue, "colsDefaultValue");
            // 
            // colDbClientValues
            // 
            this.colDbClientValues.MaxLength = 2000;
            this.colDbClientValues.Name = "colDbClientValues";
            this.colDbClientValues.NamedProperties.Put("EnumerateMethod", "");
            this.colDbClientValues.NamedProperties.Put("FieldFlags", "306");
            this.colDbClientValues.NamedProperties.Put("LovReference", "");
            this.colDbClientValues.NamedProperties.Put("ResizeableChildObject", "");
            this.colDbClientValues.NamedProperties.Put("SqlColumn", "DB_CLIENT_VALUES");
            this.colDbClientValues.NamedProperties.Put("ValidateMethod", "");
            this.colDbClientValues.Position = 12;
            resources.ApplyResources(this.colDbClientValues, "colDbClientValues");
            // 
            // colsConvListId
            // 
            this.colsConvListId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsConvListId.Name = "colsConvListId";
            this.colsConvListId.NamedProperties.Put("EnumerateMethod", "");
            this.colsConvListId.NamedProperties.Put("FieldFlags", "294");
            this.colsConvListId.NamedProperties.Put("LovReference", "INTFACE_CONV_LIST");
            this.colsConvListId.NamedProperties.Put("SqlColumn", "CONV_LIST_ID");
            this.colsConvListId.NamedProperties.Put("ValidateMethod", "");
            this.colsConvListId.Position = 13;
            resources.ApplyResources(this.colsConvListId, "colsConvListId");
            // 
            // colNoteText
            // 
            this.colNoteText.MaxLength = 2000;
            this.colNoteText.Name = "colNoteText";
            this.colNoteText.NamedProperties.Put("EnumerateMethod", "");
            this.colNoteText.NamedProperties.Put("FieldFlags", "310");
            this.colNoteText.NamedProperties.Put("LovReference", "");
            this.colNoteText.NamedProperties.Put("SqlColumn", "NOTE_TEXT");
            this.colNoteText.Position = 14;
            resources.ApplyResources(this.colNoteText, "colNoteText");
            // 
            // colsChangeDefaults
            // 
            this.colsChangeDefaults.MaxLength = 200;
            this.colsChangeDefaults.Name = "colsChangeDefaults";
            this.colsChangeDefaults.NamedProperties.Put("EnumerateMethod", "INTFACE_CHANGE_DEFAULTS_API.Enumerate");
            this.colsChangeDefaults.NamedProperties.Put("FieldFlags", "295");
            this.colsChangeDefaults.NamedProperties.Put("LovReference", "");
            this.colsChangeDefaults.NamedProperties.Put("SqlColumn", "CHANGE_DEFAULTS");
            this.colsChangeDefaults.Position = 15;
            resources.ApplyResources(this.colsChangeDefaults, "colsChangeDefaults");
            // 
            // colnAttrSeq
            // 
            this.colnAttrSeq.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colnAttrSeq, "colnAttrSeq");
            this.colnAttrSeq.Name = "colnAttrSeq";
            this.colnAttrSeq.NamedProperties.Put("EnumerateMethod", "");
            this.colnAttrSeq.NamedProperties.Put("FieldFlags", "294");
            this.colnAttrSeq.NamedProperties.Put("LovReference", "");
            this.colnAttrSeq.NamedProperties.Put("ResizeableChildObject", "");
            this.colnAttrSeq.NamedProperties.Put("SqlColumn", "ATTR_SEQ");
            this.colnAttrSeq.NamedProperties.Put("ValidateMethod", "");
            this.colnAttrSeq.Position = 16;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Convert,
            this.menuItem_Translation});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Convert
            // 
            this.menuItem_Convert.Command = this.menuTbwMethods_menuConvert_columns___;
            this.menuItem_Convert.Name = "menuItem_Convert";
            resources.ApplyResources(this.menuItem_Convert, "menuItem_Convert");
            this.menuItem_Convert.Text = "Convert columns...";
            // 
            // menuItem_Translation
            // 
            this.menuItem_Translation.Command = this.menuTbwMethods_menuTranslation;
            this.menuItem_Translation.Name = "menuItem_Translation";
            resources.ApplyResources(this.menuItem_Translation, "menuItem_Translation");
            this.menuItem_Translation.Text = "&Translation...";
            // 
            // menuTbwMethods_menuTranslation
            // 
            resources.ApplyResources(this.menuTbwMethods_menuTranslation, "menuTbwMethods_menuTranslation");
            this.menuTbwMethods_menuTranslation.Name = "menuTbwMethods_menuTranslation";
            this.menuTbwMethods_menuTranslation.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuTbwMethods_menuTranslation_Execute);
            this.menuTbwMethods_menuTranslation.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuTbwMethods_menuTranslation_Inquire);
            // 
            // tbwIntfaceDetailConversion
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsIntfaceName);
            this.Controls.Add(this.colnPos);
            this.Controls.Add(this.colsColumnName);
            this.Controls.Add(this.colsColumnDescription);
            this.Controls.Add(this.colsColumnFlags);
            this.Controls.Add(this.colsDataType);
            this.Controls.Add(this.colnLength);
            this.Controls.Add(this.colsSourceColumn);
            this.Controls.Add(this.colsDefaultValue);
            this.Controls.Add(this.colDbClientValues);
            this.Controls.Add(this.colsConvListId);
            this.Controls.Add(this.colNoteText);
            this.Controls.Add(this.colsChangeDefaults);
            this.Controls.Add(this.colnAttrSeq);
            this.Name = "tbwIntfaceDetailConversion";
            this.NamedProperties.Put("DefaultOrderBy", "DECODE(POS, 0, 999, POS), DEFAULT_VALUE, DEFAULT_WHERE, ATTR_SEQ");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "IntfaceDetail");
            this.NamedProperties.Put("PackageName", "Intface_Detail_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "INTFACE_DETAIL");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.Controls.SetChildIndex(this.colnAttrSeq, 0);
            this.Controls.SetChildIndex(this.colsChangeDefaults, 0);
            this.Controls.SetChildIndex(this.colNoteText, 0);
            this.Controls.SetChildIndex(this.colsConvListId, 0);
            this.Controls.SetChildIndex(this.colDbClientValues, 0);
            this.Controls.SetChildIndex(this.colsDefaultValue, 0);
            this.Controls.SetChildIndex(this.colsSourceColumn, 0);
            this.Controls.SetChildIndex(this.colnLength, 0);
            this.Controls.SetChildIndex(this.colsDataType, 0);
            this.Controls.SetChildIndex(this.colsColumnFlags, 0);
            this.Controls.SetChildIndex(this.colsColumnDescription, 0);
            this.Controls.SetChildIndex(this.colsColumnName, 0);
            this.Controls.SetChildIndex(this.colnPos, 0);
            this.Controls.SetChildIndex(this.colsIntfaceName, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuConvert_columns___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Convert;
        protected Fnd.Windows.Forms.FndCommand menuTbwMethods_menuTranslation;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Translation;
	}
}
