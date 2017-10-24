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

namespace Ifs.Application.Accrul
{

    public partial class frmFooterDefinition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFooterDefinition));
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelFooterId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFooterDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelFooterDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnNoOfColumns = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelNoOfColumns = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.tblFields = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFieldId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsHeaderText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSystemDefine = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsFreeText = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.txtDummy = new System.Windows.Forms.TextBox();
            this.btTraceCan = new System.Windows.Forms.Button();
            this.cmbFooterId = new Ifs.Fnd.ApplicationForms.cRecSelExtComboBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.dfsColumn1Field = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelColumn1Field = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsColumn2Field = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelColumn2Field = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsColumn3Field = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelColumn3Field = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsColumn4Field = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelColumn4Field = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsColumn5Field = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelColumn5Field = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsColumn6Field = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelColumn6Field = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsColumn7Field = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelColumn7Field = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsColumn8Field = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelColumn8Field = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsColumn9Field = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelColumn9Field = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsColumn10Field = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelColumn10Field = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFreeText = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelFreeText = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelResult = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfResult = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelResulTextField = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfResultTextField = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsLastPosition = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelLastPosition = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsLastProfile = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelLastProfile = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.panelResult = new System.Windows.Forms.Panel();
            this.tblFields.SuspendLayout();
            this.panelResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // dfsCompany
            // 
            this.dfsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "67");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_PAY_INFO");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            // 
            // labelCompany
            // 
            resources.ApplyResources(this.labelCompany, "labelCompany");
            this.labelCompany.Name = "labelCompany";
            // 
            // labelFooterId
            // 
            resources.ApplyResources(this.labelFooterId, "labelFooterId");
            this.labelFooterId.Name = "labelFooterId";
            // 
            // dfsFooterDescription
            // 
            resources.ApplyResources(this.dfsFooterDescription, "dfsFooterDescription");
            this.dfsFooterDescription.Name = "dfsFooterDescription";
            this.dfsFooterDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFooterDescription.NamedProperties.Put("FieldFlags", "295");
            this.dfsFooterDescription.NamedProperties.Put("LovReference", "");
            this.dfsFooterDescription.NamedProperties.Put("ParentName", "cmbFooterId");
            this.dfsFooterDescription.NamedProperties.Put("SqlColumn", "FOOTER_DESCRIPTION");
            // 
            // labelFooterDescription
            // 
            resources.ApplyResources(this.labelFooterDescription, "labelFooterDescription");
            this.labelFooterDescription.Name = "labelFooterDescription";
            // 
            // dfnNoOfColumns
            // 
            this.dfnNoOfColumns.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnNoOfColumns, "dfnNoOfColumns");
            this.dfnNoOfColumns.Name = "dfnNoOfColumns";
            this.dfnNoOfColumns.NamedProperties.Put("EnumerateMethod", "");
            this.dfnNoOfColumns.NamedProperties.Put("FieldFlags", "291");
            this.dfnNoOfColumns.NamedProperties.Put("Format", "");
            this.dfnNoOfColumns.NamedProperties.Put("LovReference", "");
            this.dfnNoOfColumns.NamedProperties.Put("SqlColumn", "NO_OF_COLUMNS");
            this.dfnNoOfColumns.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfnNoOfColumns_WindowActions);
            // 
            // labelNoOfColumns
            // 
            resources.ApplyResources(this.labelNoOfColumns, "labelNoOfColumns");
            this.labelNoOfColumns.Name = "labelNoOfColumns";
            // 
            // tblFields
            // 
            this.tblFields.Controls.Add(this.colsCompany);
            this.tblFields.Controls.Add(this.colsFieldId);
            this.tblFields.Controls.Add(this.colsHeaderText);
            this.tblFields.Controls.Add(this.colsSystemDefine);
            this.tblFields.Controls.Add(this.colsFreeText);
            resources.ApplyResources(this.tblFields, "tblFields");
            this.tblFields.Name = "tblFields";
            this.tblFields.NamedProperties.Put("LogicalUnit", "FooterField");
            this.tblFields.NamedProperties.Put("PackageName", "FOOTER_FIELD_API");
            this.tblFields.NamedProperties.Put("SourceFlags", "448");
            this.tblFields.NamedProperties.Put("ViewName", "FOOTER_FIELD");
            this.tblFields.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblFields_WindowActions);
            this.tblFields.Controls.SetChildIndex(this.colsFreeText, 0);
            this.tblFields.Controls.SetChildIndex(this.colsSystemDefine, 0);
            this.tblFields.Controls.SetChildIndex(this.colsHeaderText, 0);
            this.tblFields.Controls.SetChildIndex(this.colsFieldId, 0);
            this.tblFields.Controls.SetChildIndex(this.colsCompany, 0);
            // 
            // colsCompany
            // 
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.colsCompany.NamedProperties.Put("LovReference", "COMPANY");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.Position = 3;
            resources.ApplyResources(this.colsCompany, "colsCompany");
            // 
            // colsFieldId
            // 
            this.colsFieldId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsFieldId.Name = "colsFieldId";
            this.colsFieldId.NamedProperties.Put("EnumerateMethod", "");
            this.colsFieldId.NamedProperties.Put("FieldFlags", "163");
            this.colsFieldId.NamedProperties.Put("LovReference", "");
            this.colsFieldId.NamedProperties.Put("SqlColumn", "FOOTER_FIELD_ID");
            this.colsFieldId.Position = 4;
            resources.ApplyResources(this.colsFieldId, "colsFieldId");
            // 
            // colsHeaderText
            // 
            this.colsHeaderText.Name = "colsHeaderText";
            this.colsHeaderText.NamedProperties.Put("EnumerateMethod", "");
            this.colsHeaderText.NamedProperties.Put("FieldFlags", "295");
            this.colsHeaderText.NamedProperties.Put("LovReference", "");
            this.colsHeaderText.NamedProperties.Put("SqlColumn", "FOOTER_FIELD_DESC");
            this.colsHeaderText.Position = 5;
            resources.ApplyResources(this.colsHeaderText, "colsHeaderText");
            // 
            // colsSystemDefine
            // 
            this.colsSystemDefine.MaxLength = 20;
            this.colsSystemDefine.Name = "colsSystemDefine";
            this.colsSystemDefine.NamedProperties.Put("EnumerateMethod", "");
            this.colsSystemDefine.NamedProperties.Put("FieldFlags", "288");
            this.colsSystemDefine.NamedProperties.Put("LovReference", "");
            this.colsSystemDefine.NamedProperties.Put("SqlColumn", "SYSTEM_DEFINED_DB");
            this.colsSystemDefine.Position = 6;
            resources.ApplyResources(this.colsSystemDefine, "colsSystemDefine");
            // 
            // colsFreeText
            // 
            this.colsFreeText.MaxLength = 20;
            this.colsFreeText.Name = "colsFreeText";
            this.colsFreeText.NamedProperties.Put("EnumerateMethod", "");
            this.colsFreeText.NamedProperties.Put("FieldFlags", "288");
            this.colsFreeText.NamedProperties.Put("LovReference", "");
            this.colsFreeText.NamedProperties.Put("SqlColumn", "FREE_TEXT_DB");
            this.colsFreeText.Position = 7;
            resources.ApplyResources(this.colsFreeText, "colsFreeText");
            // 
            // txtDummy
            // 
            resources.ApplyResources(this.txtDummy, "txtDummy");
            this.txtDummy.Name = "txtDummy";
            // 
            // btTraceCan
            // 
            this.btTraceCan.AllowDrop = true;
            this.btTraceCan.Image = global::Ifs.Application.Accrul.Properties.Resources.trashcan;
            resources.ApplyResources(this.btTraceCan, "btTraceCan");
            this.btTraceCan.Name = "btTraceCan";
            this.btTraceCan.UseVisualStyleBackColor = true;
            this.btTraceCan.DragDrop += new System.Windows.Forms.DragEventHandler(this.btTraceCan_DragDrop);
            this.btTraceCan.DragEnter += new System.Windows.Forms.DragEventHandler(this.btTraceCan_DragEnter);
            // 
            // cmbFooterId
            // 
            this.cmbFooterId.FormattingEnabled = true;
            resources.ApplyResources(this.cmbFooterId, "cmbFooterId");
            this.cmbFooterId.Name = "cmbFooterId";
            this.cmbFooterId.NamedProperties.Put("EnumerateMethod", "");
            this.cmbFooterId.NamedProperties.Put("FieldFlags", "163");
            this.cmbFooterId.NamedProperties.Put("Format", "9");
            this.cmbFooterId.NamedProperties.Put("LovReference", "");
            this.cmbFooterId.NamedProperties.Put("SqlColumn", "FOOTER_ID");
            this.cmbFooterId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbFooterId_WindowActions);
            // 
            // txtResult
            // 
            this.txtResult.AllowDrop = true;
            resources.ApplyResources(this.txtResult, "txtResult");
            this.txtResult.Name = "txtResult";
            this.txtResult.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtResult_DragDrop);
            this.txtResult.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtResult_DragEnter);
            this.txtResult.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtResult_MouseDown);
            // 
            // dfsColumn1Field
            // 
            resources.ApplyResources(this.dfsColumn1Field, "dfsColumn1Field");
            this.dfsColumn1Field.Name = "dfsColumn1Field";
            this.dfsColumn1Field.NamedProperties.Put("EnumerateMethod", "");
            this.dfsColumn1Field.NamedProperties.Put("FieldFlags", "310");
            this.dfsColumn1Field.NamedProperties.Put("LovReference", "");
            this.dfsColumn1Field.NamedProperties.Put("SqlColumn", "COLUMN1_FIELD");
            // 
            // labelColumn1Field
            // 
            resources.ApplyResources(this.labelColumn1Field, "labelColumn1Field");
            this.labelColumn1Field.Name = "labelColumn1Field";
            // 
            // dfsColumn2Field
            // 
            resources.ApplyResources(this.dfsColumn2Field, "dfsColumn2Field");
            this.dfsColumn2Field.Name = "dfsColumn2Field";
            this.dfsColumn2Field.NamedProperties.Put("EnumerateMethod", "");
            this.dfsColumn2Field.NamedProperties.Put("FieldFlags", "310");
            this.dfsColumn2Field.NamedProperties.Put("LovReference", "");
            this.dfsColumn2Field.NamedProperties.Put("SqlColumn", "COLUMN2_FIELD");
            // 
            // labelColumn2Field
            // 
            resources.ApplyResources(this.labelColumn2Field, "labelColumn2Field");
            this.labelColumn2Field.Name = "labelColumn2Field";
            // 
            // dfsColumn3Field
            // 
            resources.ApplyResources(this.dfsColumn3Field, "dfsColumn3Field");
            this.dfsColumn3Field.Name = "dfsColumn3Field";
            this.dfsColumn3Field.NamedProperties.Put("EnumerateMethod", "");
            this.dfsColumn3Field.NamedProperties.Put("FieldFlags", "310");
            this.dfsColumn3Field.NamedProperties.Put("LovReference", "");
            this.dfsColumn3Field.NamedProperties.Put("SqlColumn", "COLUMN3_FIELD");
            // 
            // labelColumn3Field
            // 
            resources.ApplyResources(this.labelColumn3Field, "labelColumn3Field");
            this.labelColumn3Field.Name = "labelColumn3Field";
            // 
            // dfsColumn4Field
            // 
            resources.ApplyResources(this.dfsColumn4Field, "dfsColumn4Field");
            this.dfsColumn4Field.Name = "dfsColumn4Field";
            this.dfsColumn4Field.NamedProperties.Put("EnumerateMethod", "");
            this.dfsColumn4Field.NamedProperties.Put("FieldFlags", "310");
            this.dfsColumn4Field.NamedProperties.Put("LovReference", "");
            this.dfsColumn4Field.NamedProperties.Put("SqlColumn", "COLUMN4_FIELD");
            // 
            // labelColumn4Field
            // 
            resources.ApplyResources(this.labelColumn4Field, "labelColumn4Field");
            this.labelColumn4Field.Name = "labelColumn4Field";
            // 
            // dfsColumn5Field
            // 
            resources.ApplyResources(this.dfsColumn5Field, "dfsColumn5Field");
            this.dfsColumn5Field.Name = "dfsColumn5Field";
            this.dfsColumn5Field.NamedProperties.Put("EnumerateMethod", "");
            this.dfsColumn5Field.NamedProperties.Put("FieldFlags", "310");
            this.dfsColumn5Field.NamedProperties.Put("LovReference", "");
            this.dfsColumn5Field.NamedProperties.Put("SqlColumn", "COLUMN5_FIELD");
            // 
            // labelColumn5Field
            // 
            resources.ApplyResources(this.labelColumn5Field, "labelColumn5Field");
            this.labelColumn5Field.Name = "labelColumn5Field";
            // 
            // dfsColumn6Field
            // 
            resources.ApplyResources(this.dfsColumn6Field, "dfsColumn6Field");
            this.dfsColumn6Field.Name = "dfsColumn6Field";
            this.dfsColumn6Field.NamedProperties.Put("EnumerateMethod", "");
            this.dfsColumn6Field.NamedProperties.Put("FieldFlags", "310");
            this.dfsColumn6Field.NamedProperties.Put("LovReference", "");
            this.dfsColumn6Field.NamedProperties.Put("SqlColumn", "COLUMN6_FIELD");
            // 
            // labelColumn6Field
            // 
            resources.ApplyResources(this.labelColumn6Field, "labelColumn6Field");
            this.labelColumn6Field.Name = "labelColumn6Field";
            // 
            // dfsColumn7Field
            // 
            resources.ApplyResources(this.dfsColumn7Field, "dfsColumn7Field");
            this.dfsColumn7Field.Name = "dfsColumn7Field";
            this.dfsColumn7Field.NamedProperties.Put("EnumerateMethod", "");
            this.dfsColumn7Field.NamedProperties.Put("FieldFlags", "310");
            this.dfsColumn7Field.NamedProperties.Put("LovReference", "");
            this.dfsColumn7Field.NamedProperties.Put("SqlColumn", "COLUMN7_FIELD");
            // 
            // labelColumn7Field
            // 
            resources.ApplyResources(this.labelColumn7Field, "labelColumn7Field");
            this.labelColumn7Field.Name = "labelColumn7Field";
            // 
            // dfsColumn8Field
            // 
            resources.ApplyResources(this.dfsColumn8Field, "dfsColumn8Field");
            this.dfsColumn8Field.Name = "dfsColumn8Field";
            this.dfsColumn8Field.NamedProperties.Put("EnumerateMethod", "");
            this.dfsColumn8Field.NamedProperties.Put("FieldFlags", "310");
            this.dfsColumn8Field.NamedProperties.Put("LovReference", "");
            this.dfsColumn8Field.NamedProperties.Put("SqlColumn", "COLUMN8_FIELD");
            // 
            // labelColumn8Field
            // 
            resources.ApplyResources(this.labelColumn8Field, "labelColumn8Field");
            this.labelColumn8Field.Name = "labelColumn8Field";
            // 
            // dfsColumn9Field
            // 
            resources.ApplyResources(this.dfsColumn9Field, "dfsColumn9Field");
            this.dfsColumn9Field.Name = "dfsColumn9Field";
            this.dfsColumn9Field.NamedProperties.Put("EnumerateMethod", "");
            this.dfsColumn9Field.NamedProperties.Put("FieldFlags", "310");
            this.dfsColumn9Field.NamedProperties.Put("LovReference", "");
            this.dfsColumn9Field.NamedProperties.Put("SqlColumn", "COLUMN9_FIELD");
            // 
            // labelColumn9Field
            // 
            resources.ApplyResources(this.labelColumn9Field, "labelColumn9Field");
            this.labelColumn9Field.Name = "labelColumn9Field";
            // 
            // dfsColumn10Field
            // 
            resources.ApplyResources(this.dfsColumn10Field, "dfsColumn10Field");
            this.dfsColumn10Field.Name = "dfsColumn10Field";
            this.dfsColumn10Field.NamedProperties.Put("EnumerateMethod", "");
            this.dfsColumn10Field.NamedProperties.Put("FieldFlags", "310");
            this.dfsColumn10Field.NamedProperties.Put("LovReference", "");
            this.dfsColumn10Field.NamedProperties.Put("SqlColumn", "COLUMN10_FIELD");
            // 
            // labelColumn10Field
            // 
            resources.ApplyResources(this.labelColumn10Field, "labelColumn10Field");
            this.labelColumn10Field.Name = "labelColumn10Field";
            // 
            // dfsFreeText
            // 
            resources.ApplyResources(this.dfsFreeText, "dfsFreeText");
            this.dfsFreeText.Name = "dfsFreeText";
            this.dfsFreeText.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFreeText.NamedProperties.Put("FieldFlags", "310");
            this.dfsFreeText.NamedProperties.Put("LovReference", "");
            this.dfsFreeText.NamedProperties.Put("SqlColumn", "FREE_TEXT");
            // 
            // labelFreeText
            // 
            resources.ApplyResources(this.labelFreeText, "labelFreeText");
            this.labelFreeText.Name = "labelFreeText";
            // 
            // labelResult
            // 
            resources.ApplyResources(this.labelResult, "labelResult");
            this.labelResult.Name = "labelResult";
            // 
            // dfResult
            // 
            resources.ApplyResources(this.dfResult, "dfResult");
            this.dfResult.Name = "dfResult";
            // 
            // labelResulTextField
            // 
            resources.ApplyResources(this.labelResulTextField, "labelResulTextField");
            this.labelResulTextField.Name = "labelResulTextField";
            // 
            // dfResultTextField
            // 
            resources.ApplyResources(this.dfResultTextField, "dfResultTextField");
            this.dfResultTextField.Name = "dfResultTextField";
            // 
            // dfsLastPosition
            // 
            resources.ApplyResources(this.dfsLastPosition, "dfsLastPosition");
            this.dfsLastPosition.Name = "dfsLastPosition";
            this.dfsLastPosition.NamedProperties.Put("EnumerateMethod", "");
            this.dfsLastPosition.NamedProperties.Put("FieldFlags", "310");
            this.dfsLastPosition.NamedProperties.Put("LovReference", "");
            this.dfsLastPosition.NamedProperties.Put("SqlColumn", "LAST_POSITION");
            // 
            // labelLastPosition
            // 
            resources.ApplyResources(this.labelLastPosition, "labelLastPosition");
            this.labelLastPosition.Name = "labelLastPosition";
            // 
            // dfsLastProfile
            // 
            resources.ApplyResources(this.dfsLastProfile, "dfsLastProfile");
            this.dfsLastProfile.Name = "dfsLastProfile";
            this.dfsLastProfile.NamedProperties.Put("EnumerateMethod", "");
            this.dfsLastProfile.NamedProperties.Put("FieldFlags", "310");
            this.dfsLastProfile.NamedProperties.Put("LovReference", "");
            this.dfsLastProfile.NamedProperties.Put("SqlColumn", "LAST_PROFILE");
            // 
            // labelLastProfile
            // 
            resources.ApplyResources(this.labelLastProfile, "labelLastProfile");
            this.labelLastProfile.Name = "labelLastProfile";
            // 
            // panelResult
            // 
            this.panelResult.BackColor = System.Drawing.SystemColors.Window;
            this.panelResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResult.Controls.Add(this.txtDummy);
            resources.ApplyResources(this.panelResult, "panelResult");
            this.panelResult.Name = "panelResult";
            // 
            // frmFooterDefinition
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panelResult);
            this.Controls.Add(this.dfsLastProfile);
            this.Controls.Add(this.labelLastProfile);
            this.Controls.Add(this.dfsLastPosition);
            this.Controls.Add(this.labelLastPosition);
            this.Controls.Add(this.dfResultTextField);
            this.Controls.Add(this.labelResulTextField);
            this.Controls.Add(this.dfResult);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.dfsFreeText);
            this.Controls.Add(this.labelFreeText);
            this.Controls.Add(this.dfsColumn10Field);
            this.Controls.Add(this.labelColumn10Field);
            this.Controls.Add(this.dfsColumn9Field);
            this.Controls.Add(this.labelColumn9Field);
            this.Controls.Add(this.dfsColumn8Field);
            this.Controls.Add(this.labelColumn8Field);
            this.Controls.Add(this.dfsColumn7Field);
            this.Controls.Add(this.labelColumn7Field);
            this.Controls.Add(this.dfsColumn6Field);
            this.Controls.Add(this.labelColumn6Field);
            this.Controls.Add(this.dfsColumn5Field);
            this.Controls.Add(this.labelColumn5Field);
            this.Controls.Add(this.dfsColumn4Field);
            this.Controls.Add(this.labelColumn4Field);
            this.Controls.Add(this.dfsColumn3Field);
            this.Controls.Add(this.labelColumn3Field);
            this.Controls.Add(this.dfsColumn2Field);
            this.Controls.Add(this.labelColumn2Field);
            this.Controls.Add(this.dfsColumn1Field);
            this.Controls.Add(this.labelColumn1Field);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.cmbFooterId);
            this.Controls.Add(this.btTraceCan);
            this.Controls.Add(this.tblFields);
            this.Controls.Add(this.dfnNoOfColumns);
            this.Controls.Add(this.labelNoOfColumns);
            this.Controls.Add(this.dfsFooterDescription);
            this.Controls.Add(this.labelFooterDescription);
            this.Controls.Add(this.labelFooterId);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labelCompany);
            this.Name = "frmFooterDefinition";
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "FooterDefinition");
            this.NamedProperties.Put("Module", "ACCRUL");
            this.NamedProperties.Put("PackageName", "FOOTER_DEFINITION_API");
            this.NamedProperties.Put("ViewName", "FOOTER_DEFINITION");
            this.tblFields.ResumeLayout(false);
            this.panelResult.ResumeLayout(false);
            this.panelResult.PerformLayout();
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

        protected cDataField dfsCompany;
        protected cBackgroundText labelCompany;
        protected cBackgroundText labelFooterId;
        protected cDataField dfsFooterDescription;
        protected cBackgroundText labelFooterDescription;
        protected cDataField dfnNoOfColumns;
        protected cBackgroundText labelNoOfColumns;
        protected cChildTable tblFields;
        protected cColumn colsCompany;
        protected cColumn colsFieldId;
        protected cColumn colsHeaderText;
        protected TextBox txtDummy;
        protected Button btTraceCan;
        protected cRecSelExtComboBox cmbFooterId;
        protected cCheckBoxColumn colsSystemDefine;
        protected cCheckBoxColumn colsFreeText;
        protected TextBox txtResult;
        protected cDataField dfsColumn1Field;
        protected cBackgroundText labelColumn1Field;
        protected cDataField dfsColumn2Field;
        protected cBackgroundText labelColumn2Field;
        protected cDataField dfsColumn3Field;
        protected cBackgroundText labelColumn3Field;
        protected cDataField dfsColumn4Field;
        protected cBackgroundText labelColumn4Field;
        protected cDataField dfsColumn5Field;
        protected cBackgroundText labelColumn5Field;
        protected cDataField dfsColumn6Field;
        protected cBackgroundText labelColumn6Field;
        protected cDataField dfsColumn7Field;
        protected cBackgroundText labelColumn7Field;
        protected cDataField dfsColumn8Field;
        protected cBackgroundText labelColumn8Field;
        protected cDataField dfsColumn9Field;
        protected cBackgroundText labelColumn9Field;
        protected cDataField dfsColumn10Field;
        protected cBackgroundText labelColumn10Field;
        protected cDataField dfsFreeText;
        protected cBackgroundText labelFreeText;
        protected cBackgroundText labelResult;
        protected cDataField dfResult;
        protected cBackgroundText labelResulTextField;
        protected cDataField dfResultTextField;
        protected cDataField dfsLastPosition;
        protected cBackgroundText labelLastPosition;
        protected cDataField dfsLastProfile;
        protected cBackgroundText labelLastProfile;
        protected Panel panelResult;
    }
}
