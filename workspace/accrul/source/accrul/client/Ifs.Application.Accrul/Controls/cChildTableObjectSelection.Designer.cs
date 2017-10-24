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
	
	public partial class cChildTableObjectSelection
	{
		#region Window Controls
		public cColumn colsCompany;
		public cColumn colsObjectGroupId;
		public cColumn colsObjectId;
		public cColumn colnSelectionId;
		public cColumn colnItemId;
		public cColumn colsSelectionObjectId;
		public cColumn colsSelectionObjIdDesc;
		public cLookupColumn colsOperator;
		public cColumn colsFromValue;
		public cColumn colsToValue;
		public cCheckBoxColumn colsValueExist;
		public cCheckBoxColumn colsManualInput;
		// invisible columns
		public cColumn colsOperatorDb;
		public cColumn colsDataTypeDb;
		public cColumn colsObjectViewName;
		public cColumn coldFromValueDate;
		public cColumn coldToValueDate;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cChildTableObjectSelection));
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsObjectGroupId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsObjectId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnSelectionId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnItemId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSelectionObjectId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSelectionObjIdDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsOperator = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsFromValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsToValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsValueExist = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsManualInput = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsOperatorDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDataTypeDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsObjectViewName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldFromValueDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldToValueDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnFromValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnToValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.SuspendLayout();
            // 
            // __colObjid
            // 
            this.@__colObjid.CheckBox.CheckedValue = "";
            this.@__colObjid.CheckBox.IgnoreCase = true;
            this.@__colObjid.CheckBox.UncheckedValue = "";
            this.@__colObjid.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.@__colObjid.ComboBox.Sorted = true;
            this.@__colObjid.PopupBox.Lines = 5;
            // 
            // __colObjversion
            // 
            this.@__colObjversion.CheckBox.CheckedValue = "";
            this.@__colObjversion.CheckBox.IgnoreCase = true;
            this.@__colObjversion.CheckBox.UncheckedValue = "";
            this.@__colObjversion.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.@__colObjversion.ComboBox.Sorted = true;
            this.@__colObjversion.PopupBox.Lines = 5;
            // 
            // colsCompany
            // 
            this.colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCompany.CheckBox.CheckedValue = "";
            this.colsCompany.CheckBox.IgnoreCase = true;
            this.colsCompany.CheckBox.UncheckedValue = "";
            this.colsCompany.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsCompany.ComboBox.Sorted = true;
            resources.ApplyResources(this.colsCompany, "colsCompany");
            this.colsCompany.MaxLength = 20;
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.colsCompany.NamedProperties.Put("LovReference", "");
            this.colsCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.PopupBox.Lines = 5;
            this.colsCompany.Position = 3;
            // 
            // colsObjectGroupId
            // 
            this.colsObjectGroupId.CheckBox.CheckedValue = "";
            this.colsObjectGroupId.CheckBox.IgnoreCase = true;
            this.colsObjectGroupId.CheckBox.UncheckedValue = "";
            this.colsObjectGroupId.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsObjectGroupId.ComboBox.Sorted = true;
            resources.ApplyResources(this.colsObjectGroupId, "colsObjectGroupId");
            this.colsObjectGroupId.Name = "colsObjectGroupId";
            this.colsObjectGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.colsObjectGroupId.NamedProperties.Put("FieldFlags", "67");
            this.colsObjectGroupId.NamedProperties.Put("LovReference", "");
            this.colsObjectGroupId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsObjectGroupId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsObjectGroupId.NamedProperties.Put("SqlColumn", "OBJECT_GROUP_ID");
            this.colsObjectGroupId.NamedProperties.Put("ValidateMethod", "");
            this.colsObjectGroupId.PopupBox.Lines = 5;
            this.colsObjectGroupId.Position = 4;
            // 
            // colsObjectId
            // 
            this.colsObjectId.CheckBox.CheckedValue = "";
            this.colsObjectId.CheckBox.IgnoreCase = true;
            this.colsObjectId.CheckBox.UncheckedValue = "";
            this.colsObjectId.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsObjectId.ComboBox.Sorted = true;
            resources.ApplyResources(this.colsObjectId, "colsObjectId");
            this.colsObjectId.Name = "colsObjectId";
            this.colsObjectId.NamedProperties.Put("EnumerateMethod", "");
            this.colsObjectId.NamedProperties.Put("FieldFlags", "67");
            this.colsObjectId.NamedProperties.Put("LovReference", "");
            this.colsObjectId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsObjectId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsObjectId.NamedProperties.Put("SqlColumn", "OBJECT_ID");
            this.colsObjectId.NamedProperties.Put("ValidateMethod", "");
            this.colsObjectId.PopupBox.Lines = 5;
            this.colsObjectId.Position = 5;
            // 
            // colnSelectionId
            // 
            this.colnSelectionId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colnSelectionId.CheckBox.CheckedValue = "";
            this.colnSelectionId.CheckBox.IgnoreCase = true;
            this.colnSelectionId.CheckBox.UncheckedValue = "";
            this.colnSelectionId.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colnSelectionId.ComboBox.Sorted = true;
            this.colnSelectionId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colnSelectionId, "colnSelectionId");
            this.colnSelectionId.MaxLength = 20;
            this.colnSelectionId.Name = "colnSelectionId";
            this.colnSelectionId.NamedProperties.Put("EnumerateMethod", "");
            this.colnSelectionId.NamedProperties.Put("FieldFlags", "131");
            this.colnSelectionId.NamedProperties.Put("LovReference", "");
            this.colnSelectionId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnSelectionId.NamedProperties.Put("ResizeableChildObject", "");
            this.colnSelectionId.NamedProperties.Put("SqlColumn", "SELECTION_ID");
            this.colnSelectionId.NamedProperties.Put("ValidateMethod", "");
            this.colnSelectionId.PopupBox.Lines = 5;
            this.colnSelectionId.Position = 6;
            // 
            // colnItemId
            // 
            this.colnItemId.CheckBox.CheckedValue = "";
            this.colnItemId.CheckBox.IgnoreCase = true;
            this.colnItemId.CheckBox.UncheckedValue = "";
            this.colnItemId.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colnItemId.ComboBox.Sorted = true;
            this.colnItemId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colnItemId, "colnItemId");
            this.colnItemId.Name = "colnItemId";
            this.colnItemId.NamedProperties.Put("EnumerateMethod", "");
            this.colnItemId.NamedProperties.Put("FieldFlags", "130");
            this.colnItemId.NamedProperties.Put("LovReference", "");
            this.colnItemId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnItemId.NamedProperties.Put("ResizeableChildObject", "");
            this.colnItemId.NamedProperties.Put("SqlColumn", "ITEM_ID");
            this.colnItemId.NamedProperties.Put("ValidateMethod", "");
            this.colnItemId.PopupBox.Lines = 5;
            this.colnItemId.Position = 7;
            // 
            // colsSelectionObjectId
            // 
            this.colsSelectionObjectId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsSelectionObjectId.CheckBox.CheckedValue = "";
            this.colsSelectionObjectId.CheckBox.IgnoreCase = true;
            this.colsSelectionObjectId.CheckBox.UncheckedValue = "";
            this.colsSelectionObjectId.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsSelectionObjectId.ComboBox.Sorted = true;
            this.colsSelectionObjectId.Name = "colsSelectionObjectId";
            this.colsSelectionObjectId.NamedProperties.Put("EnumerateMethod", "");
            this.colsSelectionObjectId.NamedProperties.Put("FieldFlags", "291");
            this.colsSelectionObjectId.NamedProperties.Put("LovReference", "FIN_SEL_OBJECT_COMPANY(COMPANY,OBJECT_GROUP_ID)");
            this.colsSelectionObjectId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSelectionObjectId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsSelectionObjectId.NamedProperties.Put("SqlColumn", "SELECTION_OBJECT_ID");
            this.colsSelectionObjectId.NamedProperties.Put("ValidateMethod", "");
            this.colsSelectionObjectId.PopupBox.Lines = 5;
            this.colsSelectionObjectId.Position = 8;
            resources.ApplyResources(this.colsSelectionObjectId, "colsSelectionObjectId");
            this.colsSelectionObjectId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsSelectionObjectId_WindowActions);
            // 
            // colsSelectionObjIdDesc
            // 
            this.colsSelectionObjIdDesc.CheckBox.CheckedValue = "";
            this.colsSelectionObjIdDesc.CheckBox.IgnoreCase = true;
            this.colsSelectionObjIdDesc.CheckBox.UncheckedValue = "";
            this.colsSelectionObjIdDesc.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsSelectionObjIdDesc.ComboBox.Sorted = true;
            this.colsSelectionObjIdDesc.MaxLength = 200;
            this.colsSelectionObjIdDesc.Name = "colsSelectionObjIdDesc";
            this.colsSelectionObjIdDesc.NamedProperties.Put("EnumerateMethod", "");
            this.colsSelectionObjIdDesc.NamedProperties.Put("FieldFlags", "288");
            this.colsSelectionObjIdDesc.NamedProperties.Put("LovReference", "");
            this.colsSelectionObjIdDesc.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSelectionObjIdDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.colsSelectionObjIdDesc.NamedProperties.Put("SqlColumn", "&AO.Fin_Sel_Object_API.Get_Comp_Sel_Obj_Desc__(COMPANY, SELECTION_OBJECT_ID)");
            this.colsSelectionObjIdDesc.NamedProperties.Put("ValidateMethod", "");
            this.colsSelectionObjIdDesc.PopupBox.Lines = 5;
            this.colsSelectionObjIdDesc.Position = 9;
            resources.ApplyResources(this.colsSelectionObjIdDesc, "colsSelectionObjIdDesc");
            // 
            // colsOperator
            // 
            this.colsOperator.CellType = PPJ.Runtime.Windows.CellType.ComboBox;
            this.colsOperator.CheckBox.CheckedValue = "";
            this.colsOperator.CheckBox.IgnoreCase = true;
            this.colsOperator.CheckBox.UncheckedValue = "";
            this.colsOperator.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colsOperator.ComboBox.Sorted = false;
            this.colsOperator.Name = "colsOperator";
            this.colsOperator.NamedProperties.Put("EnumerateMethod", "Fin_Sel_Object_Operator_API.Enumerate");
            this.colsOperator.NamedProperties.Put("FieldFlags", "295");
            this.colsOperator.NamedProperties.Put("LovReference", "");
            this.colsOperator.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsOperator.NamedProperties.Put("ResizeableChildObject", "");
            this.colsOperator.NamedProperties.Put("SqlColumn", "OPERATOR");
            this.colsOperator.NamedProperties.Put("ValidateMethod", "");
            this.colsOperator.PopupBox.Lines = 5;
            this.colsOperator.Position = 10;
            resources.ApplyResources(this.colsOperator, "colsOperator");
            this.colsOperator.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsOperator_WindowActions);
            // 
            // colsFromValue
            // 
            this.colsFromValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsFromValue.CheckBox.CheckedValue = "";
            this.colsFromValue.CheckBox.IgnoreCase = true;
            this.colsFromValue.CheckBox.UncheckedValue = "";
            this.colsFromValue.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsFromValue.ComboBox.Sorted = true;
            this.colsFromValue.Name = "colsFromValue";
            this.colsFromValue.NamedProperties.Put("EnumerateMethod", "");
            this.colsFromValue.NamedProperties.Put("FieldFlags", "294");
            this.colsFromValue.NamedProperties.Put("LovReference", "COMPANY");
            this.colsFromValue.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFromValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colsFromValue.NamedProperties.Put("SqlColumn", "VALUE_FROM");
            this.colsFromValue.NamedProperties.Put("ValidateMethod", "");
            this.colsFromValue.PopupBox.Lines = 5;
            this.colsFromValue.Position = 11;
            resources.ApplyResources(this.colsFromValue, "colsFromValue");
            this.colsFromValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsFromValue_WindowActions);
            // 
            // colsToValue
            // 
            this.colsToValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsToValue.CheckBox.CheckedValue = "";
            this.colsToValue.CheckBox.IgnoreCase = true;
            this.colsToValue.CheckBox.UncheckedValue = "";
            this.colsToValue.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsToValue.ComboBox.Sorted = true;
            this.colsToValue.Name = "colsToValue";
            this.colsToValue.NamedProperties.Put("EnumerateMethod", "");
            this.colsToValue.NamedProperties.Put("FieldFlags", "294");
            this.colsToValue.NamedProperties.Put("LovReference", "COMPANY");
            this.colsToValue.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsToValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colsToValue.NamedProperties.Put("SqlColumn", "VALUE_TO");
            this.colsToValue.NamedProperties.Put("ValidateMethod", "");
            this.colsToValue.PopupBox.Lines = 5;
            this.colsToValue.Position = 12;
            resources.ApplyResources(this.colsToValue, "colsToValue");
            this.colsToValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsToValue_WindowActions);
            // 
            // colsValueExist
            // 
            this.colsValueExist.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsValueExist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsValueExist.CheckBox.CheckedValue = "TRUE";
            this.colsValueExist.CheckBox.IgnoreCase = true;
            this.colsValueExist.CheckBox.UncheckedValue = "FALSE";
            this.colsValueExist.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsValueExist.ComboBox.Sorted = true;
            this.colsValueExist.MaxLength = 5;
            this.colsValueExist.Name = "colsValueExist";
            this.colsValueExist.NamedProperties.Put("EnumerateMethod", "");
            this.colsValueExist.NamedProperties.Put("FieldFlags", "256");
            this.colsValueExist.NamedProperties.Put("LovReference", "");
            this.colsValueExist.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsValueExist.NamedProperties.Put("ResizeableChildObject", "");
            this.colsValueExist.NamedProperties.Put("SqlColumn", "Fin_Obj_Selection_Values_API.Is_Value_Exist(COMPANY,OBJECT_GROUP_ID,OBJECT_ID,SEL" +
                    "ECTION_ID,ITEM_ID)");
            this.colsValueExist.NamedProperties.Put("ValidateMethod", "");
            this.colsValueExist.PopupBox.Lines = 5;
            this.colsValueExist.Position = 13;
            resources.ApplyResources(this.colsValueExist, "colsValueExist");
            // 
            // colsManualInput
            // 
            this.colsManualInput.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsManualInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsManualInput.CheckBox.CheckedValue = "TRUE";
            this.colsManualInput.CheckBox.IgnoreCase = true;
            this.colsManualInput.CheckBox.UncheckedValue = "FALSE";
            this.colsManualInput.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsManualInput.ComboBox.Sorted = true;
            this.colsManualInput.MaxLength = 5;
            this.colsManualInput.Name = "colsManualInput";
            this.colsManualInput.NamedProperties.Put("EnumerateMethod", "");
            this.colsManualInput.NamedProperties.Put("FieldFlags", "294");
            this.colsManualInput.NamedProperties.Put("LovReference", "");
            this.colsManualInput.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsManualInput.NamedProperties.Put("ResizeableChildObject", "");
            this.colsManualInput.NamedProperties.Put("SqlColumn", "MANUAL_INPUT");
            this.colsManualInput.NamedProperties.Put("ValidateMethod", "");
            this.colsManualInput.PopupBox.Lines = 5;
            this.colsManualInput.Position = 14;
            resources.ApplyResources(this.colsManualInput, "colsManualInput");
            this.colsManualInput.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsManualInput_WindowActions);
            // 
            // colsOperatorDb
            // 
            this.colsOperatorDb.CheckBox.CheckedValue = "";
            this.colsOperatorDb.CheckBox.IgnoreCase = true;
            this.colsOperatorDb.CheckBox.UncheckedValue = "";
            this.colsOperatorDb.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsOperatorDb.ComboBox.Sorted = true;
            resources.ApplyResources(this.colsOperatorDb, "colsOperatorDb");
            this.colsOperatorDb.Name = "colsOperatorDb";
            this.colsOperatorDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsOperatorDb.NamedProperties.Put("FieldFlags", "256");
            this.colsOperatorDb.NamedProperties.Put("LovReference", "");
            this.colsOperatorDb.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsOperatorDb.NamedProperties.Put("ResizeableChildObject", "");
            this.colsOperatorDb.NamedProperties.Put("SqlColumn", "OPERATOR_DB");
            this.colsOperatorDb.NamedProperties.Put("ValidateMethod", "");
            this.colsOperatorDb.PopupBox.Lines = 5;
            this.colsOperatorDb.Position = 15;
            // 
            // colsDataTypeDb
            // 
            this.colsDataTypeDb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsDataTypeDb.CheckBox.CheckedValue = "";
            this.colsDataTypeDb.CheckBox.IgnoreCase = true;
            this.colsDataTypeDb.CheckBox.UncheckedValue = "";
            this.colsDataTypeDb.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsDataTypeDb.ComboBox.Sorted = true;
            resources.ApplyResources(this.colsDataTypeDb, "colsDataTypeDb");
            this.colsDataTypeDb.MaxLength = 20;
            this.colsDataTypeDb.Name = "colsDataTypeDb";
            this.colsDataTypeDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsDataTypeDb.NamedProperties.Put("FieldFlags", "256");
            this.colsDataTypeDb.NamedProperties.Put("LovReference", "");
            this.colsDataTypeDb.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDataTypeDb.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDataTypeDb.NamedProperties.Put("SqlColumn", "&AO.Fin_Sel_Object_API.Get_Data_Type_Db(SELECTION_OBJECT_ID)");
            this.colsDataTypeDb.NamedProperties.Put("ValidateMethod", "");
            this.colsDataTypeDb.PopupBox.Lines = 5;
            this.colsDataTypeDb.Position = 16;
            // 
            // colsObjectViewName
            // 
            this.colsObjectViewName.CheckBox.CheckedValue = "";
            this.colsObjectViewName.CheckBox.IgnoreCase = true;
            this.colsObjectViewName.CheckBox.UncheckedValue = "";
            this.colsObjectViewName.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsObjectViewName.ComboBox.Sorted = true;
            resources.ApplyResources(this.colsObjectViewName, "colsObjectViewName");
            this.colsObjectViewName.Name = "colsObjectViewName";
            this.colsObjectViewName.NamedProperties.Put("EnumerateMethod", "");
            this.colsObjectViewName.NamedProperties.Put("FieldFlags", "256");
            this.colsObjectViewName.NamedProperties.Put("LovReference", "");
            this.colsObjectViewName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsObjectViewName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsObjectViewName.NamedProperties.Put("SqlColumn", "Fin_Sel_Object_API.Get_Lov_Reference(SELECTION_OBJECT_ID)");
            this.colsObjectViewName.NamedProperties.Put("ValidateMethod", "");
            this.colsObjectViewName.PopupBox.Lines = 5;
            this.colsObjectViewName.Position = 17;
            // 
            // coldFromValueDate
            // 
            this.coldFromValueDate.CheckBox.CheckedValue = "";
            this.coldFromValueDate.CheckBox.IgnoreCase = true;
            this.coldFromValueDate.CheckBox.UncheckedValue = "";
            this.coldFromValueDate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.coldFromValueDate.ComboBox.Sorted = true;
            this.coldFromValueDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.coldFromValueDate, "coldFromValueDate");
            this.coldFromValueDate.Format = "d";
            this.coldFromValueDate.Name = "coldFromValueDate";
            this.coldFromValueDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldFromValueDate.NamedProperties.Put("FieldFlags", "262");
            this.coldFromValueDate.NamedProperties.Put("LovReference", "");
            this.coldFromValueDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldFromValueDate.NamedProperties.Put("ResizeableChildObject", "");
            this.coldFromValueDate.NamedProperties.Put("SqlColumn", "VALUE_FROM_DATE");
            this.coldFromValueDate.NamedProperties.Put("ValidateMethod", "");
            this.coldFromValueDate.PopupBox.Lines = 5;
            this.coldFromValueDate.Position = 18;
            // 
            // coldToValueDate
            // 
            this.coldToValueDate.CheckBox.CheckedValue = "";
            this.coldToValueDate.CheckBox.IgnoreCase = true;
            this.coldToValueDate.CheckBox.UncheckedValue = "";
            this.coldToValueDate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.coldToValueDate.ComboBox.Sorted = true;
            this.coldToValueDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.coldToValueDate, "coldToValueDate");
            this.coldToValueDate.Format = "d";
            this.coldToValueDate.Name = "coldToValueDate";
            this.coldToValueDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldToValueDate.NamedProperties.Put("FieldFlags", "262");
            this.coldToValueDate.NamedProperties.Put("LovReference", "");
            this.coldToValueDate.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldToValueDate.NamedProperties.Put("ResizeableChildObject", "");
            this.coldToValueDate.NamedProperties.Put("SqlColumn", "VALUE_TO_DATE");
            this.coldToValueDate.NamedProperties.Put("ValidateMethod", "");
            this.coldToValueDate.PopupBox.Lines = 5;
            this.coldToValueDate.Position = 19;
            // 
            // colnFromValue
            // 
            this.colnFromValue.CheckBox.CheckedValue = "";
            this.colnFromValue.CheckBox.IgnoreCase = true;
            this.colnFromValue.CheckBox.UncheckedValue = "";
            this.colnFromValue.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colnFromValue.ComboBox.Sorted = true;
            this.colnFromValue.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnFromValue.Name = "colnFromValue";
            this.colnFromValue.NamedProperties.Put("EnumerateMethod", "");
            this.colnFromValue.NamedProperties.Put("FieldFlags", "288");
            this.colnFromValue.NamedProperties.Put("Format", "20");
            this.colnFromValue.NamedProperties.Put("LovReference", "");
            this.colnFromValue.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnFromValue.NamedProperties.Put("SqlColumn", "VALUE_FROM_NUMBER");
            this.colnFromValue.PopupBox.Lines = 5;
            this.colnFromValue.Position = 20;
            resources.ApplyResources(this.colnFromValue, "colnFromValue");
            // 
            // colnToValue
            // 
            this.colnToValue.CheckBox.CheckedValue = "";
            this.colnToValue.CheckBox.IgnoreCase = true;
            this.colnToValue.CheckBox.UncheckedValue = "";
            this.colnToValue.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colnToValue.ComboBox.Sorted = true;
            this.colnToValue.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnToValue.Name = "colnToValue";
            this.colnToValue.NamedProperties.Put("EnumerateMethod", "");
            this.colnToValue.NamedProperties.Put("FieldFlags", "294");
            this.colnToValue.NamedProperties.Put("Format", "20");
            this.colnToValue.NamedProperties.Put("LovReference", "");
            this.colnToValue.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnToValue.NamedProperties.Put("SqlColumn", "VALUE_TO_NUMBER");
            this.colnToValue.PopupBox.Lines = 5;
            this.colnToValue.Position = 21;
            resources.ApplyResources(this.colnToValue, "colnToValue");
            // 
            // cChildTableObjectSelection
            // 
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsObjectGroupId);
            this.Controls.Add(this.colsObjectId);
            this.Controls.Add(this.colnSelectionId);
            this.Controls.Add(this.colnItemId);
            this.Controls.Add(this.colsSelectionObjectId);
            this.Controls.Add(this.colsSelectionObjIdDesc);
            this.Controls.Add(this.colsOperator);
            this.Controls.Add(this.colsFromValue);
            this.Controls.Add(this.colsToValue);
            this.Controls.Add(this.colsValueExist);
            this.Controls.Add(this.colsManualInput);
            this.Controls.Add(this.colsOperatorDb);
            this.Controls.Add(this.colsDataTypeDb);
            this.Controls.Add(this.colsObjectViewName);
            this.Controls.Add(this.coldFromValueDate);
            this.Controls.Add(this.coldToValueDate);
            this.Controls.Add(this.colnFromValue);
            this.Controls.Add(this.colnToValue);
            this.Name = "cChildTableObjectSelection";
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("SourceFlags", "449");
            resources.ApplyResources(this, "$this");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cChildTableObjectSelection_WindowActions);
            this.Controls.SetChildIndex(this.colnToValue, 0);
            this.Controls.SetChildIndex(this.colnFromValue, 0);
            this.Controls.SetChildIndex(this.coldToValueDate, 0);
            this.Controls.SetChildIndex(this.coldFromValueDate, 0);
            this.Controls.SetChildIndex(this.colsObjectViewName, 0);
            this.Controls.SetChildIndex(this.colsDataTypeDb, 0);
            this.Controls.SetChildIndex(this.colsOperatorDb, 0);
            this.Controls.SetChildIndex(this.colsManualInput, 0);
            this.Controls.SetChildIndex(this.colsValueExist, 0);
            this.Controls.SetChildIndex(this.colsToValue, 0);
            this.Controls.SetChildIndex(this.colsFromValue, 0);
            this.Controls.SetChildIndex(this.colsOperator, 0);
            this.Controls.SetChildIndex(this.colsSelectionObjIdDesc, 0);
            this.Controls.SetChildIndex(this.colsSelectionObjectId, 0);
            this.Controls.SetChildIndex(this.colnItemId, 0);
            this.Controls.SetChildIndex(this.colnSelectionId, 0);
            this.Controls.SetChildIndex(this.colsObjectId, 0);
            this.Controls.SetChildIndex(this.colsObjectGroupId, 0);
            this.Controls.SetChildIndex(this.colsCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.ResumeLayout(false);

		}
		#endregion

        public cColumn colnFromValue;
        public cColumn colnToValue;
	}
}
