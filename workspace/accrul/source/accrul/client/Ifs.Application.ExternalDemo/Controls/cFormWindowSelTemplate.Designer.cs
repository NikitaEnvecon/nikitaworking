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
	
	public partial class cFormWindowSelTemplate
	{
		#region Window Controls
		public cDataField dfsCompany;
		public cDataField dfsObjectGroupId;
		protected cBackgroundText labelcmbTemplateId;
		public cRecSelExtComboBox cmbTemplateId;
		protected cBackgroundText labeldfsTemplateDescription;
		public cDataField dfsTemplateDescription;
		protected cBackgroundText labelcmbOwnership;
		public cComboBox cmbOwnership;
		protected cBackgroundText labeldfsTemplateOwner;
		public cDataField dfsTemplateOwner;
        public cCheckBox cbDefault;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cFormWindowSelTemplate));
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsObjectGroupId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbTemplateId = new Ifs.Fnd.ApplicationForms.cRecSelExtComboBox();
            this.labeldfsTemplateDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTemplateDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbOwnership = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbOwnership = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfsTemplateOwner = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTemplateOwner = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbDefault = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.tblSelectionItems = new Ifs.Application.Accrul.cChildTableFin();
            this.tblSelectionItems_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_colsObjectGroupId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_colsTemplateId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_colnItemId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_colsSelectionObjectId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_colsSelectionObjIdDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_colsOperator = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblSelectionItems_colsFromValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_colsToValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_colsValueExist = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblSelectionItems_colsManualInput = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblSelectionItems_colsDataType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_colsOperatorDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_colsObjectViewName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_coldFromValueDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_coldToValueDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_colsDataTypeDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_colsObjectColId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_colsZoomWindow = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_colsZoomWindowColKey = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems_colsZoomWindowParentColKey = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectionItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.ImageList = null;
            // 
            // dfsCompany
            // 
            this.dfsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "67");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_PAY_INFO");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsObjectGroupId
            // 
            resources.ApplyResources(this.dfsObjectGroupId, "dfsObjectGroupId");
            this.dfsObjectGroupId.Name = "dfsObjectGroupId";
            this.dfsObjectGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsObjectGroupId.NamedProperties.Put("FieldFlags", "67");
            this.dfsObjectGroupId.NamedProperties.Put("LovReference", "");
            this.dfsObjectGroupId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsObjectGroupId.NamedProperties.Put("SqlColumn", "OBJECT_GROUP_ID");
            this.dfsObjectGroupId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbTemplateId
            // 
            resources.ApplyResources(this.labelcmbTemplateId, "labelcmbTemplateId");
            this.labelcmbTemplateId.Name = "labelcmbTemplateId";
            // 
            // cmbTemplateId
            // 
            resources.ApplyResources(this.cmbTemplateId, "cmbTemplateId");
            this.cmbTemplateId.Name = "cmbTemplateId";
            this.cmbTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.cmbTemplateId.NamedProperties.Put("FieldFlags", "163");
            this.cmbTemplateId.NamedProperties.Put("Format", "9");
            this.cmbTemplateId.NamedProperties.Put("LovReference", "");
            this.cmbTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbTemplateId.NamedProperties.Put("SqlColumn", "TEMPLATE_ID");
            this.cmbTemplateId.NamedProperties.Put("ValidateMethod", "");
            this.cmbTemplateId.NamedProperties.Put("XDataLength", "20");
            // 
            // labeldfsTemplateDescription
            // 
            resources.ApplyResources(this.labeldfsTemplateDescription, "labeldfsTemplateDescription");
            this.labeldfsTemplateDescription.Name = "labeldfsTemplateDescription";
            // 
            // dfsTemplateDescription
            // 
            resources.ApplyResources(this.dfsTemplateDescription, "dfsTemplateDescription");
            this.dfsTemplateDescription.Name = "dfsTemplateDescription";
            this.dfsTemplateDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTemplateDescription.NamedProperties.Put("FieldFlags", "295");
            this.dfsTemplateDescription.NamedProperties.Put("LovReference", "");
            this.dfsTemplateDescription.NamedProperties.Put("ParentName", "cmbTemplateId");
            this.dfsTemplateDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTemplateDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsTemplateDescription.NamedProperties.Put("ValidateMethod", "");
            this.dfsTemplateDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsTemplateDescription_WindowActions);
            // 
            // labelcmbOwnership
            // 
            resources.ApplyResources(this.labelcmbOwnership, "labelcmbOwnership");
            this.labelcmbOwnership.Name = "labelcmbOwnership";
            // 
            // cmbOwnership
            // 
            resources.ApplyResources(this.cmbOwnership, "cmbOwnership");
            this.cmbOwnership.Name = "cmbOwnership";
            this.cmbOwnership.NamedProperties.Put("EnumerateMethod", "Fin_Sel_Templ_Ownership_API.Enumerate");
            this.cmbOwnership.NamedProperties.Put("FieldFlags", "295");
            this.cmbOwnership.NamedProperties.Put("LovReference", "");
            this.cmbOwnership.NamedProperties.Put("ParentName", "cmbTemplateId");
            this.cmbOwnership.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbOwnership.NamedProperties.Put("SqlColumn", "OWNERSHIP");
            this.cmbOwnership.NamedProperties.Put("ValidateMethod", "");
            this.cmbOwnership.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbOwnership_WindowActions);
            // 
            // labeldfsTemplateOwner
            // 
            resources.ApplyResources(this.labeldfsTemplateOwner, "labeldfsTemplateOwner");
            this.labeldfsTemplateOwner.Name = "labeldfsTemplateOwner";
            // 
            // dfsTemplateOwner
            // 
            this.dfsTemplateOwner.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsTemplateOwner, "dfsTemplateOwner");
            this.dfsTemplateOwner.Name = "dfsTemplateOwner";
            this.dfsTemplateOwner.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTemplateOwner.NamedProperties.Put("FieldFlags", "289");
            this.dfsTemplateOwner.NamedProperties.Put("LovReference", "");
            this.dfsTemplateOwner.NamedProperties.Put("ParentName", "cmbTemplateId");
            this.dfsTemplateOwner.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTemplateOwner.NamedProperties.Put("SqlColumn", "OWNER");
            this.dfsTemplateOwner.NamedProperties.Put("ValidateMethod", "");
            this.dfsTemplateOwner.ReadOnly = true;
            // 
            // cbDefault
            // 
            resources.ApplyResources(this.cbDefault, "cbDefault");
            this.cbDefault.Name = "cbDefault";
            this.cbDefault.NamedProperties.Put("DataType", "5");
            this.cbDefault.NamedProperties.Put("EnumerateMethod", "");
            this.cbDefault.NamedProperties.Put("FieldFlags", "294");
            this.cbDefault.NamedProperties.Put("LovReference", "");
            this.cbDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.cbDefault.NamedProperties.Put("SqlColumn", "DEFAULT_TEMPLATE");
            this.cbDefault.NamedProperties.Put("ValidateMethod", "");
            this.cbDefault.NamedProperties.Put("XDataLength", "");
            this.cbDefault.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbDefault_WindowActions);
            // 
            // tblSelectionItems
            // 
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsCompany);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsObjectGroupId);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsTemplateId);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colnItemId);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsSelectionObjectId);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsSelectionObjIdDesc);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsOperator);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsFromValue);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsToValue);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsValueExist);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsManualInput);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsDataType);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsOperatorDb);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsObjectViewName);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_coldFromValueDate);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_coldToValueDate);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsDataTypeDb);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsObjectColId);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsZoomWindow);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsZoomWindowColKey);
            this.tblSelectionItems.Controls.Add(this.tblSelectionItems_colsZoomWindowParentColKey);
            resources.ApplyResources(this.tblSelectionItems, "tblSelectionItems");
            this.tblSelectionItems.Name = "tblSelectionItems";
            this.tblSelectionItems.NamedProperties.Put("DefaultOrderBy", "");
            this.tblSelectionItems.NamedProperties.Put("DefaultWhere", "");
            this.tblSelectionItems.NamedProperties.Put("LogicalUnit", "FinSelObjTemplDet");
            this.tblSelectionItems.NamedProperties.Put("PackageName", "FIN_SEL_OBJ_TEMPL_DET_API");
            this.tblSelectionItems.NamedProperties.Put("ResizeableChildObject", "MLMM");
            this.tblSelectionItems.NamedProperties.Put("ViewName", "FIN_SEL_OBJ_TEMPL_DET");
            this.tblSelectionItems.NamedProperties.Put("Warnings", "FALSE");
            this.tblSelectionItems.UserMethodEvent += new Ifs.Fnd.ApplicationForms.cMethodManager.UserMethodEventHandler(this.tblSelectionItems_UserMethodEvent);
            this.tblSelectionItems.DataSourceReferenceItemsEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataSourceReferenceItemsEventHandler(this.tblSelectionItems_DataSourceReferenceItemsEvent);
            this.tblSelectionItems.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblSelectionItems_WindowActions);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsZoomWindowParentColKey, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsZoomWindowColKey, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsZoomWindow, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsObjectColId, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsDataTypeDb, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_coldToValueDate, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_coldFromValueDate, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsObjectViewName, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsOperatorDb, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsDataType, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsManualInput, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsValueExist, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsToValue, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsFromValue, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsOperator, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsSelectionObjIdDesc, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsSelectionObjectId, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colnItemId, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsTemplateId, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsObjectGroupId, 0);
            this.tblSelectionItems.Controls.SetChildIndex(this.tblSelectionItems_colsCompany, 0);
            // 
            // tblSelectionItems_colsCompany
            // 
            this.tblSelectionItems_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblSelectionItems_colsCompany, "tblSelectionItems_colsCompany");
            this.tblSelectionItems_colsCompany.MaxLength = 20;
            this.tblSelectionItems_colsCompany.Name = "tblSelectionItems_colsCompany";
            this.tblSelectionItems_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblSelectionItems_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblSelectionItems_colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsCompany.Position = 3;
            // 
            // tblSelectionItems_colsObjectGroupId
            // 
            resources.ApplyResources(this.tblSelectionItems_colsObjectGroupId, "tblSelectionItems_colsObjectGroupId");
            this.tblSelectionItems_colsObjectGroupId.Name = "tblSelectionItems_colsObjectGroupId";
            this.tblSelectionItems_colsObjectGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsObjectGroupId.NamedProperties.Put("FieldFlags", "67");
            this.tblSelectionItems_colsObjectGroupId.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_colsObjectGroupId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsObjectGroupId.NamedProperties.Put("SqlColumn", "OBJECT_GROUP_ID");
            this.tblSelectionItems_colsObjectGroupId.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsObjectGroupId.Position = 4;
            // 
            // tblSelectionItems_colsTemplateId
            // 
            this.tblSelectionItems_colsTemplateId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblSelectionItems_colsTemplateId, "tblSelectionItems_colsTemplateId");
            this.tblSelectionItems_colsTemplateId.MaxLength = 20;
            this.tblSelectionItems_colsTemplateId.Name = "tblSelectionItems_colsTemplateId";
            this.tblSelectionItems_colsTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsTemplateId.NamedProperties.Put("FieldFlags", "67");
            this.tblSelectionItems_colsTemplateId.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_colsTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsTemplateId.NamedProperties.Put("SqlColumn", "TEMPLATE_ID");
            this.tblSelectionItems_colsTemplateId.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsTemplateId.Position = 5;
            // 
            // tblSelectionItems_colnItemId
            // 
            this.tblSelectionItems_colnItemId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblSelectionItems_colnItemId, "tblSelectionItems_colnItemId");
            this.tblSelectionItems_colnItemId.Name = "tblSelectionItems_colnItemId";
            this.tblSelectionItems_colnItemId.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colnItemId.NamedProperties.Put("FieldFlags", "130");
            this.tblSelectionItems_colnItemId.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_colnItemId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colnItemId.NamedProperties.Put("SqlColumn", "ITEM_ID");
            this.tblSelectionItems_colnItemId.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colnItemId.Position = 6;
            // 
            // tblSelectionItems_colsSelectionObjectId
            // 
            this.tblSelectionItems_colsSelectionObjectId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblSelectionItems_colsSelectionObjectId.Name = "tblSelectionItems_colsSelectionObjectId";
            this.tblSelectionItems_colsSelectionObjectId.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsSelectionObjectId.NamedProperties.Put("FieldFlags", "295");
            this.tblSelectionItems_colsSelectionObjectId.NamedProperties.Put("LovReference", "FIN_SEL_OBJECT_COMPANY(COMPANY,OBJECT_GROUP_ID)");
            this.tblSelectionItems_colsSelectionObjectId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsSelectionObjectId.NamedProperties.Put("SqlColumn", "SELECTION_OBJECT_ID");
            this.tblSelectionItems_colsSelectionObjectId.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsSelectionObjectId.Position = 7;
            resources.ApplyResources(this.tblSelectionItems_colsSelectionObjectId, "tblSelectionItems_colsSelectionObjectId");
            this.tblSelectionItems_colsSelectionObjectId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblSelectionItems_colsSelectionObjectId_WindowActions);
            // 
            // tblSelectionItems_colsSelectionObjIdDesc
            // 
            this.tblSelectionItems_colsSelectionObjIdDesc.MaxLength = 200;
            this.tblSelectionItems_colsSelectionObjIdDesc.Name = "tblSelectionItems_colsSelectionObjIdDesc";
            this.tblSelectionItems_colsSelectionObjIdDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsSelectionObjIdDesc.NamedProperties.Put("FieldFlags", "288");
            this.tblSelectionItems_colsSelectionObjIdDesc.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_colsSelectionObjIdDesc.NamedProperties.Put("ParentName", "tblSelectionItems.tblSelectionItems_colsSelectionObjectId");
            this.tblSelectionItems_colsSelectionObjIdDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsSelectionObjIdDesc.NamedProperties.Put("SqlColumn", "&AO.Fin_Sel_Object_API.Get_Comp_Sel_Obj_Desc__(COMPANY, SELECTION_OBJECT_ID)");
            this.tblSelectionItems_colsSelectionObjIdDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsSelectionObjIdDesc.Position = 8;
            resources.ApplyResources(this.tblSelectionItems_colsSelectionObjIdDesc, "tblSelectionItems_colsSelectionObjIdDesc");
            // 
            // tblSelectionItems_colsOperator
            // 
            this.tblSelectionItems_colsOperator.Name = "tblSelectionItems_colsOperator";
            this.tblSelectionItems_colsOperator.NamedProperties.Put("EnumerateMethod", "Fin_Sel_Object_Operator_API.Enumerate");
            this.tblSelectionItems_colsOperator.NamedProperties.Put("FieldFlags", "295");
            this.tblSelectionItems_colsOperator.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_colsOperator.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsOperator.NamedProperties.Put("SqlColumn", "SELECTION_OPERATOR");
            this.tblSelectionItems_colsOperator.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsOperator.Position = 9;
            resources.ApplyResources(this.tblSelectionItems_colsOperator, "tblSelectionItems_colsOperator");
            this.tblSelectionItems_colsOperator.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblSelectionItems_colsOperator_WindowActions);
            // 
            // tblSelectionItems_colsFromValue
            // 
            this.tblSelectionItems_colsFromValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblSelectionItems_colsFromValue.Name = "tblSelectionItems_colsFromValue";
            this.tblSelectionItems_colsFromValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsFromValue.NamedProperties.Put("FieldFlags", "294");
            this.tblSelectionItems_colsFromValue.NamedProperties.Put("LovReference", "COMPANY");
            this.tblSelectionItems_colsFromValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsFromValue.NamedProperties.Put("SqlColumn", "VALUE_FROM");
            this.tblSelectionItems_colsFromValue.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsFromValue.Position = 10;
            resources.ApplyResources(this.tblSelectionItems_colsFromValue, "tblSelectionItems_colsFromValue");
            this.tblSelectionItems_colsFromValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblSelectionItems_colsFromValue_WindowActions);
            // 
            // tblSelectionItems_colsToValue
            // 
            this.tblSelectionItems_colsToValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblSelectionItems_colsToValue.Name = "tblSelectionItems_colsToValue";
            this.tblSelectionItems_colsToValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsToValue.NamedProperties.Put("FieldFlags", "294");
            this.tblSelectionItems_colsToValue.NamedProperties.Put("LovReference", "COMPANY");
            this.tblSelectionItems_colsToValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsToValue.NamedProperties.Put("SqlColumn", "VALUE_TO");
            this.tblSelectionItems_colsToValue.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsToValue.Position = 11;
            resources.ApplyResources(this.tblSelectionItems_colsToValue, "tblSelectionItems_colsToValue");
            this.tblSelectionItems_colsToValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblSelectionItems_colsToValue_WindowActions);
            // 
            // tblSelectionItems_colsValueExist
            // 
            this.tblSelectionItems_colsValueExist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblSelectionItems_colsValueExist.MaxLength = 5;
            this.tblSelectionItems_colsValueExist.Name = "tblSelectionItems_colsValueExist";
            this.tblSelectionItems_colsValueExist.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsValueExist.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_colsValueExist.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsValueExist.NamedProperties.Put("SqlColumn", "&AO.Fin_Sel_Templ_Values_API.Is_Value_Exist(COMPANY,OBJECT_GROUP_ID,TEMPLATE_ID,I" +
                    "TEM_ID)");
            this.tblSelectionItems_colsValueExist.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsValueExist.Position = 12;
            resources.ApplyResources(this.tblSelectionItems_colsValueExist, "tblSelectionItems_colsValueExist");
            // 
            // tblSelectionItems_colsManualInput
            // 
            this.tblSelectionItems_colsManualInput.MaxLength = 20;
            this.tblSelectionItems_colsManualInput.Name = "tblSelectionItems_colsManualInput";
            this.tblSelectionItems_colsManualInput.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsManualInput.NamedProperties.Put("FieldFlags", "291");
            this.tblSelectionItems_colsManualInput.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_colsManualInput.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsManualInput.NamedProperties.Put("SqlColumn", "MANUAL_INPUT_DB");
            this.tblSelectionItems_colsManualInput.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsManualInput.Position = 13;
            resources.ApplyResources(this.tblSelectionItems_colsManualInput, "tblSelectionItems_colsManualInput");
            this.tblSelectionItems_colsManualInput.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblSelectionItems_colsManualInput_WindowActions);
            // 
            // tblSelectionItems_colsDataType
            // 
            resources.ApplyResources(this.tblSelectionItems_colsDataType, "tblSelectionItems_colsDataType");
            this.tblSelectionItems_colsDataType.Name = "tblSelectionItems_colsDataType";
            this.tblSelectionItems_colsDataType.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsDataType.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_colsDataType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsDataType.NamedProperties.Put("SqlColumn", "&AO.Fin_Sel_Object_API.Get_Data_Type(SELECTION_OBJECT_ID)");
            this.tblSelectionItems_colsDataType.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsDataType.Position = 14;
            // 
            // tblSelectionItems_colsOperatorDb
            // 
            resources.ApplyResources(this.tblSelectionItems_colsOperatorDb, "tblSelectionItems_colsOperatorDb");
            this.tblSelectionItems_colsOperatorDb.MaxLength = 20;
            this.tblSelectionItems_colsOperatorDb.Name = "tblSelectionItems_colsOperatorDb";
            this.tblSelectionItems_colsOperatorDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsOperatorDb.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_colsOperatorDb.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsOperatorDb.NamedProperties.Put("SqlColumn", "SELECTION_OPERATOR_DB");
            this.tblSelectionItems_colsOperatorDb.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsOperatorDb.Position = 15;
            // 
            // tblSelectionItems_colsObjectViewName
            // 
            resources.ApplyResources(this.tblSelectionItems_colsObjectViewName, "tblSelectionItems_colsObjectViewName");
            this.tblSelectionItems_colsObjectViewName.MaxLength = 200;
            this.tblSelectionItems_colsObjectViewName.Name = "tblSelectionItems_colsObjectViewName";
            this.tblSelectionItems_colsObjectViewName.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsObjectViewName.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_colsObjectViewName.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsObjectViewName.NamedProperties.Put("SqlColumn", "&AO.Fin_Sel_Object_API.Get_Lov_Reference(SELECTION_OBJECT_ID)");
            this.tblSelectionItems_colsObjectViewName.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsObjectViewName.Position = 16;
            // 
            // tblSelectionItems_coldFromValueDate
            // 
            this.tblSelectionItems_coldFromValueDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.tblSelectionItems_coldFromValueDate, "tblSelectionItems_coldFromValueDate");
            this.tblSelectionItems_coldFromValueDate.Format = "d";
            this.tblSelectionItems_coldFromValueDate.Name = "tblSelectionItems_coldFromValueDate";
            this.tblSelectionItems_coldFromValueDate.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_coldFromValueDate.NamedProperties.Put("FieldFlags", "262");
            this.tblSelectionItems_coldFromValueDate.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_coldFromValueDate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_coldFromValueDate.NamedProperties.Put("SqlColumn", "VALUE_FROM_DATE");
            this.tblSelectionItems_coldFromValueDate.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_coldFromValueDate.Position = 17;
            // 
            // tblSelectionItems_coldToValueDate
            // 
            this.tblSelectionItems_coldToValueDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.tblSelectionItems_coldToValueDate, "tblSelectionItems_coldToValueDate");
            this.tblSelectionItems_coldToValueDate.Format = "d";
            this.tblSelectionItems_coldToValueDate.Name = "tblSelectionItems_coldToValueDate";
            this.tblSelectionItems_coldToValueDate.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_coldToValueDate.NamedProperties.Put("FieldFlags", "262");
            this.tblSelectionItems_coldToValueDate.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_coldToValueDate.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_coldToValueDate.NamedProperties.Put("SqlColumn", "VALUE_TO_DATE");
            this.tblSelectionItems_coldToValueDate.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_coldToValueDate.Position = 18;
            // 
            // tblSelectionItems_colsDataTypeDb
            // 
            this.tblSelectionItems_colsDataTypeDb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblSelectionItems_colsDataTypeDb, "tblSelectionItems_colsDataTypeDb");
            this.tblSelectionItems_colsDataTypeDb.MaxLength = 20;
            this.tblSelectionItems_colsDataTypeDb.Name = "tblSelectionItems_colsDataTypeDb";
            this.tblSelectionItems_colsDataTypeDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsDataTypeDb.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_colsDataTypeDb.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsDataTypeDb.NamedProperties.Put("SqlColumn", "&AO.Fin_Sel_Object_API.Get_Data_Type_Db(SELECTION_OBJECT_ID)");
            this.tblSelectionItems_colsDataTypeDb.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsDataTypeDb.Position = 19;
            // 
            // tblSelectionItems_colsObjectColId
            // 
            this.tblSelectionItems_colsObjectColId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblSelectionItems_colsObjectColId, "tblSelectionItems_colsObjectColId");
            this.tblSelectionItems_colsObjectColId.MaxLength = 30;
            this.tblSelectionItems_colsObjectColId.Name = "tblSelectionItems_colsObjectColId";
            this.tblSelectionItems_colsObjectColId.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsObjectColId.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_colsObjectColId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsObjectColId.NamedProperties.Put("SqlColumn", "&AO.Fin_Sel_Object_API.Get_Object_Col_Id(SELECTION_OBJECT_ID)");
            this.tblSelectionItems_colsObjectColId.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsObjectColId.Position = 20;
            // 
            // tblSelectionItems_colsZoomWindow
            // 
            resources.ApplyResources(this.tblSelectionItems_colsZoomWindow, "tblSelectionItems_colsZoomWindow");
            this.tblSelectionItems_colsZoomWindow.Name = "tblSelectionItems_colsZoomWindow";
            this.tblSelectionItems_colsZoomWindow.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsZoomWindow.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_colsZoomWindow.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsZoomWindow.NamedProperties.Put("SqlColumn", "&AO.Fin_Sel_Object_API.Get_Zoom_Window(SELECTION_OBJECT_ID)");
            this.tblSelectionItems_colsZoomWindow.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsZoomWindow.Position = 21;
            // 
            // tblSelectionItems_colsZoomWindowColKey
            // 
            resources.ApplyResources(this.tblSelectionItems_colsZoomWindowColKey, "tblSelectionItems_colsZoomWindowColKey");
            this.tblSelectionItems_colsZoomWindowColKey.MaxLength = 30;
            this.tblSelectionItems_colsZoomWindowColKey.Name = "tblSelectionItems_colsZoomWindowColKey";
            this.tblSelectionItems_colsZoomWindowColKey.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsZoomWindowColKey.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_colsZoomWindowColKey.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsZoomWindowColKey.NamedProperties.Put("SqlColumn", "&AO.Fin_Sel_Object_API.Get_Zoom_Window_Col_Key(SELECTION_OBJECT_ID)");
            this.tblSelectionItems_colsZoomWindowColKey.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsZoomWindowColKey.Position = 22;
            // 
            // tblSelectionItems_colsZoomWindowParentColKey
            // 
            this.tblSelectionItems_colsZoomWindowParentColKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblSelectionItems_colsZoomWindowParentColKey, "tblSelectionItems_colsZoomWindowParentColKey");
            this.tblSelectionItems_colsZoomWindowParentColKey.MaxLength = 200;
            this.tblSelectionItems_colsZoomWindowParentColKey.Name = "tblSelectionItems_colsZoomWindowParentColKey";
            this.tblSelectionItems_colsZoomWindowParentColKey.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectionItems_colsZoomWindowParentColKey.NamedProperties.Put("LovReference", "");
            this.tblSelectionItems_colsZoomWindowParentColKey.NamedProperties.Put("ResizeableChildObject", "");
            this.tblSelectionItems_colsZoomWindowParentColKey.NamedProperties.Put("SqlColumn", "&AO.Fin_Sel_Object_API.Get_Zoom_Window_Parent_Col_Key(SELECTION_OBJECT_ID)");
            this.tblSelectionItems_colsZoomWindowParentColKey.NamedProperties.Put("ValidateMethod", "");
            this.tblSelectionItems_colsZoomWindowParentColKey.Position = 23;
            // 
            // cFormWindowSelTemplate
            // 
            this.AutoScaleBaseDpi = new System.Drawing.Size(106, 106);
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblSelectionItems);
            this.Controls.Add(this.cbDefault);
            this.Controls.Add(this.dfsTemplateOwner);
            this.Controls.Add(this.cmbOwnership);
            this.Controls.Add(this.dfsTemplateDescription);
            this.Controls.Add(this.cmbTemplateId);
            this.Controls.Add(this.dfsObjectGroupId);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.labeldfsTemplateOwner);
            this.Controls.Add(this.labelcmbOwnership);
            this.Controls.Add(this.labeldfsTemplateDescription);
            this.Controls.Add(this.labelcmbTemplateId);
            this.Name = "cFormWindowSelTemplate";
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cFormWindowSelTemplate_WindowActions);
            this.tblSelectionItems.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public cChildTableFin tblSelectionItems;
        protected cColumn tblSelectionItems_colsCompany;
        protected cColumn tblSelectionItems_colsObjectGroupId;
        protected cColumn tblSelectionItems_colsTemplateId;
        protected cColumn tblSelectionItems_colnItemId;
        protected cColumn tblSelectionItems_colsSelectionObjectId;
        protected cColumn tblSelectionItems_colsSelectionObjIdDesc;
        protected cLookupColumn tblSelectionItems_colsOperator;
        protected cColumn tblSelectionItems_colsFromValue;
        protected cColumn tblSelectionItems_colsToValue;
        protected cCheckBoxColumn tblSelectionItems_colsValueExist;
        protected cCheckBoxColumn tblSelectionItems_colsManualInput;
        protected cColumn tblSelectionItems_colsDataType;
        protected cColumn tblSelectionItems_colsOperatorDb;
        protected cColumn tblSelectionItems_colsObjectViewName;
        protected cColumn tblSelectionItems_coldFromValueDate;
        protected cColumn tblSelectionItems_coldToValueDate;
        protected cColumn tblSelectionItems_colsDataTypeDb;
        protected cColumn tblSelectionItems_colsObjectColId;
        protected cColumn tblSelectionItems_colsZoomWindow;
        protected cColumn tblSelectionItems_colsZoomWindowColKey;
        protected cColumn tblSelectionItems_colsZoomWindowParentColKey;

	}
}
