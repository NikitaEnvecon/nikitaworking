#region Copyright (c) IFS Research & Development
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
#endregion
#region History
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.MdmBasicData
{

    public partial class tbwGeneral
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwGeneral));
            this.colsColumnName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDataType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDefaultValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFlags = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnLength = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsNoteText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colMandatory = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsTemplateId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnRevision = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsRequestNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.SuspendLayout();
            // 
            // __colObjversion
            // 
            this.@__colObjversion.Position = 8;
            // 
            // colsColumnName
            // 
            this.colsColumnName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsColumnName.MaxLength = 2000;
            this.colsColumnName.Name = "colsColumnName";
            this.colsColumnName.NamedProperties.Put("EnumerateMethod", "");
            this.colsColumnName.NamedProperties.Put("FieldFlags", "179");
            this.colsColumnName.NamedProperties.Put("LovReference", "");
            this.colsColumnName.NamedProperties.Put("SqlColumn", "COLUMN_NAME");
            this.colsColumnName.Position = 2;
            this.colsColumnName.ReadOnly = true;
            resources.ApplyResources(this.colsColumnName, "colsColumnName");
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
            this.colsDataType.Position = 4;
            this.colsDataType.ReadOnly = true;
            resources.ApplyResources(this.colsDataType, "colsDataType");
            // 
            // colsDefaultValue
            // 
            this.colsDefaultValue.MaxLength = 2000;
            this.colsDefaultValue.Name = "colsDefaultValue";
            this.colsDefaultValue.NamedProperties.Put("EnumerateMethod", "");
            this.colsDefaultValue.NamedProperties.Put("FieldFlags", "310");
            this.colsDefaultValue.NamedProperties.Put("LovReference", "");
            this.colsDefaultValue.NamedProperties.Put("SqlColumn", "DEFAULT_VALUE");
            this.colsDefaultValue.Position = 7;
            this.colsDefaultValue.ReadOnly = true;
            resources.ApplyResources(this.colsDefaultValue, "colsDefaultValue");
            // 
            // colsDescription
            // 
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "294");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.Position = 3;
            this.colsDescription.ReadOnly = true;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsFlags
            // 
            this.colsFlags.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsFlags.MaxLength = 10;
            this.colsFlags.Name = "colsFlags";
            this.colsFlags.NamedProperties.Put("EnumerateMethod", "");
            this.colsFlags.NamedProperties.Put("FieldFlags", "290");
            this.colsFlags.NamedProperties.Put("LovReference", "");
            this.colsFlags.NamedProperties.Put("SqlColumn", "FLAGS");
            this.colsFlags.Position = 6;
            this.colsFlags.ReadOnly = true;
            resources.ApplyResources(this.colsFlags, "colsFlags");
            // 
            // colnLength
            // 
            this.colnLength.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnLength.Name = "colnLength";
            this.colnLength.NamedProperties.Put("EnumerateMethod", "");
            this.colnLength.NamedProperties.Put("FieldFlags", "295");
            this.colnLength.NamedProperties.Put("Format", "");
            this.colnLength.NamedProperties.Put("LovReference", "");
            this.colnLength.NamedProperties.Put("SqlColumn", "LENGTH");
            this.colnLength.Position = 5;
            this.colnLength.ReadOnly = true;
            this.colnLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnLength, "colnLength");
            // 
            // colsNoteText
            // 
            this.colsNoteText.MaxLength = 2000;
            this.colsNoteText.Name = "colsNoteText";
            this.colsNoteText.NamedProperties.Put("EnumerateMethod", "");
            this.colsNoteText.NamedProperties.Put("FieldFlags", "310");
            this.colsNoteText.NamedProperties.Put("LovReference", "");
            this.colsNoteText.NamedProperties.Put("SqlColumn", "NOTE_TEXT");
            this.colsNoteText.Position = 10;
            this.colsNoteText.ReadOnly = true;
            resources.ApplyResources(this.colsNoteText, "colsNoteText");
            // 
            // colMandatory
            // 
            this.colMandatory.Name = "colMandatory";
            this.colMandatory.NamedProperties.Put("EnumerateMethod", "");
            this.colMandatory.NamedProperties.Put("FieldFlags", "292");
            this.colMandatory.NamedProperties.Put("LovReference", "");
            this.colMandatory.NamedProperties.Put("SqlColumn", "MANDATORY");
            this.colMandatory.Position = 9;
            this.colMandatory.ReadOnly = true;
            resources.ApplyResources(this.colMandatory, "colMandatory");
            // 
            // colsTemplateId
            // 
            this.colsTemplateId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsTemplateId.MaxLength = 30;
            this.colsTemplateId.Name = "colsTemplateId";
            this.colsTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.colsTemplateId.NamedProperties.Put("FieldFlags", "4195");
            this.colsTemplateId.NamedProperties.Put("LovReference", "");
            this.colsTemplateId.NamedProperties.Put("SqlColumn", "TEMPLATE_ID");
            this.colsTemplateId.Position = 13;
            resources.ApplyResources(this.colsTemplateId, "colsTemplateId");
            // 
            // colnRevision
            // 
            this.colnRevision.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnRevision.Name = "colnRevision";
            this.colnRevision.NamedProperties.Put("EnumerateMethod", "");
            this.colnRevision.NamedProperties.Put("FieldFlags", "4195");
            this.colnRevision.NamedProperties.Put("Format", "");
            this.colnRevision.NamedProperties.Put("LovReference", "MDM_BASIC_DATA_HEADER(TEMPLATE_ID)");
            this.colnRevision.NamedProperties.Put("SqlColumn", "REVISION");
            this.colnRevision.Position = 12;
            this.colnRevision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnRevision, "colnRevision");
            // 
            // colsRequestNo
            // 
            this.colsRequestNo.Name = "colsRequestNo";
            this.colsRequestNo.NamedProperties.Put("EnumerateMethod", "");
            this.colsRequestNo.NamedProperties.Put("FieldFlags", "4384");
            this.colsRequestNo.NamedProperties.Put("LovReference", "");
            this.colsRequestNo.NamedProperties.Put("SqlColumn", "REQUEST_NO");
            this.colsRequestNo.Position = 11;
            resources.ApplyResources(this.colsRequestNo, "colsRequestNo");
            // 
            // tbwGeneral
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsColumnName);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsDataType);
            this.Controls.Add(this.colnLength);
            this.Controls.Add(this.colsFlags);
            this.Controls.Add(this.colsDefaultValue);
            this.Controls.Add(this.colMandatory);
            this.Controls.Add(this.colsRequestNo);
            this.Controls.Add(this.colnRevision);
            this.Controls.Add(this.colsTemplateId);
            this.Controls.Add(this.colsNoteText);
            this.Name = "tbwGeneral";
            this.NamedProperties.Put("LogicalUnit", "MdmSourceMap");
            this.NamedProperties.Put("Module", "MDMGT");
            this.NamedProperties.Put("PackageName", "MDM_SOURCE_MAP_API");
            this.NamedProperties.Put("ViewName", "MDM_GENERAL");
            this.Controls.SetChildIndex(this.colsNoteText, 0);
            this.Controls.SetChildIndex(this.colsTemplateId, 0);
            this.Controls.SetChildIndex(this.colnRevision, 0);
            this.Controls.SetChildIndex(this.colsRequestNo, 0);
            this.Controls.SetChildIndex(this.colMandatory, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.colsDefaultValue, 0);
            this.Controls.SetChildIndex(this.colsFlags, 0);
            this.Controls.SetChildIndex(this.colnLength, 0);
            this.Controls.SetChildIndex(this.colsDataType, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsColumnName, 0);
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

        protected cColumn colsColumnName;
        protected cColumn colsDataType;
        protected cColumn colsDefaultValue;
        protected cColumn colsDescription;
        protected cColumn colsFlags;
        protected cColumn colnLength;
        protected cColumn colsNoteText;
        protected cCheckBoxColumn colMandatory;
        protected cColumn colsTemplateId;
        protected cColumn colnRevision;
        protected cColumn colsRequestNo;
    }
}
