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
	
	public partial class dlgReportSelTemplInfo
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataField dfCompany;
		public cDataField dfObjectGroupId;
		protected cBackgroundText labeldfTemplateID;
		public cDataField dfTemplateID;
		protected cBackgroundText labeldfTemplateDescription;
		public cDataField dfTemplateDescription;
		protected cBackgroundText labeldfTemplateOwnership;
		public cDataField dfTemplateOwnership;
		protected cBackgroundText labeldfTemplateOwner;
        public cDataField dfTemplateOwner;
		public cPushButton pbNew;
		public cPushButton pbRemove;
		public cPushButton pbSave;
		public cPushButton pbInclExcl;
		public cPushButton pbCreateTempl;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgReportSelTemplInfo));
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfObjectGroupId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfTemplateID = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfTemplateID = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfTemplateDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfTemplateDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfTemplateOwnership = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfTemplateOwnership = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfTemplateOwner = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfTemplateOwner = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbNew = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbRemove = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbSave = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbInclExcl = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCreateTempl = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.tblReportSelection = new Ifs.Application.Accrul.cChildTableObjectSelection();
            this.ClientArea.SuspendLayout();
            this.tblReportSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbCreateTempl);
            this.ClientArea.Controls.Add(this.pbInclExcl);
            this.ClientArea.Controls.Add(this.pbSave);
            this.ClientArea.Controls.Add(this.pbRemove);
            this.ClientArea.Controls.Add(this.pbNew);
            this.ClientArea.Controls.Add(this.tblReportSelection);
            this.ClientArea.Controls.Add(this.dfTemplateOwner);
            this.ClientArea.Controls.Add(this.dfTemplateOwnership);
            this.ClientArea.Controls.Add(this.dfTemplateDescription);
            this.ClientArea.Controls.Add(this.dfTemplateID);
            this.ClientArea.Controls.Add(this.dfObjectGroupId);
            this.ClientArea.Controls.Add(this.dfCompany);
            this.ClientArea.Controls.Add(this.labeldfTemplateOwner);
            this.ClientArea.Controls.Add(this.labeldfTemplateOwnership);
            this.ClientArea.Controls.Add(this.labeldfTemplateDescription);
            this.ClientArea.Controls.Add(this.labeldfTemplateID);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCreateTempl);
            this.commandManager.Components.Add(this.pbInclExcl);
            this.commandManager.Components.Add(this.pbSave);
            this.commandManager.Components.Add(this.pbRemove);
            this.commandManager.Components.Add(this.pbNew);
            this.commandManager.ImageList = null;
            // 
            // dfCompany
            // 
            resources.ApplyResources(this.dfCompany, "dfCompany");
            this.dfCompany.Name = "dfCompany";
            this.dfCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfCompany.NamedProperties.Put("FieldFlags", "64");
            this.dfCompany.NamedProperties.Put("LovReference", "");
            this.dfCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfObjectGroupId
            // 
            resources.ApplyResources(this.dfObjectGroupId, "dfObjectGroupId");
            this.dfObjectGroupId.Name = "dfObjectGroupId";
            this.dfObjectGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.dfObjectGroupId.NamedProperties.Put("LovReference", "");
            this.dfObjectGroupId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfObjectGroupId.NamedProperties.Put("SqlColumn", "OBJECT_GROUP_ID");
            this.dfObjectGroupId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfTemplateID
            // 
            resources.ApplyResources(this.labeldfTemplateID, "labeldfTemplateID");
            this.labeldfTemplateID.Name = "labeldfTemplateID";
            // 
            // dfTemplateID
            // 
            this.dfTemplateID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfTemplateID, "dfTemplateID");
            this.dfTemplateID.Name = "dfTemplateID";
            this.dfTemplateID.NamedProperties.Put("EnumerateMethod", "");
            this.dfTemplateID.NamedProperties.Put("FieldFlags", "262");
            this.dfTemplateID.NamedProperties.Put("LovReference", "FIN_SEL_OBJ_TEMPL(COMPANY,OBJECT_GROUP_ID)");
            this.dfTemplateID.NamedProperties.Put("ResizeableChildObject", "");
            this.dfTemplateID.NamedProperties.Put("SqlColumn", "TEMPLATE_ID");
            this.dfTemplateID.NamedProperties.Put("ValidateMethod", "");
            this.dfTemplateID.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfTemplateID_WindowActions);
            // 
            // labeldfTemplateDescription
            // 
            resources.ApplyResources(this.labeldfTemplateDescription, "labeldfTemplateDescription");
            this.labeldfTemplateDescription.Name = "labeldfTemplateDescription";
            // 
            // dfTemplateDescription
            // 
            resources.ApplyResources(this.dfTemplateDescription, "dfTemplateDescription");
            this.dfTemplateDescription.Name = "dfTemplateDescription";
            this.dfTemplateDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfTemplateDescription.NamedProperties.Put("LovReference", "");
            this.dfTemplateDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfTemplateDescription.NamedProperties.Put("SqlColumn", "");
            this.dfTemplateDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfTemplateOwnership
            // 
            resources.ApplyResources(this.labeldfTemplateOwnership, "labeldfTemplateOwnership");
            this.labeldfTemplateOwnership.Name = "labeldfTemplateOwnership";
            // 
            // dfTemplateOwnership
            // 
            resources.ApplyResources(this.dfTemplateOwnership, "dfTemplateOwnership");
            this.dfTemplateOwnership.Name = "dfTemplateOwnership";
            this.dfTemplateOwnership.NamedProperties.Put("EnumerateMethod", "");
            this.dfTemplateOwnership.NamedProperties.Put("LovReference", "");
            this.dfTemplateOwnership.NamedProperties.Put("ResizeableChildObject", "");
            this.dfTemplateOwnership.NamedProperties.Put("SqlColumn", "");
            this.dfTemplateOwnership.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfTemplateOwner
            // 
            resources.ApplyResources(this.labeldfTemplateOwner, "labeldfTemplateOwner");
            this.labeldfTemplateOwner.Name = "labeldfTemplateOwner";
            // 
            // dfTemplateOwner
            // 
            resources.ApplyResources(this.dfTemplateOwner, "dfTemplateOwner");
            this.dfTemplateOwner.Name = "dfTemplateOwner";
            this.dfTemplateOwner.NamedProperties.Put("EnumerateMethod", "");
            this.dfTemplateOwner.NamedProperties.Put("LovReference", "");
            this.dfTemplateOwner.NamedProperties.Put("ResizeableChildObject", "LLRR");
            this.dfTemplateOwner.NamedProperties.Put("SqlColumn", "");
            this.dfTemplateOwner.NamedProperties.Put("ValidateMethod", "");
            // 
            // pbNew
            // 
            resources.ApplyResources(this.pbNew, "pbNew");
            this.pbNew.Name = "pbNew";
            this.pbNew.NamedProperties.Put("MethodId", "18385");
            this.pbNew.NamedProperties.Put("MethodParameter", "New");
            this.pbNew.NamedProperties.Put("ResizeableChildObject", "LLLL");
            // 
            // pbRemove
            // 
            resources.ApplyResources(this.pbRemove, "pbRemove");
            this.pbRemove.Name = "pbRemove";
            this.pbRemove.NamedProperties.Put("MethodId", "18385");
            this.pbRemove.NamedProperties.Put("MethodParameter", "Remove");
            this.pbRemove.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbSave
            // 
            resources.ApplyResources(this.pbSave, "pbSave");
            this.pbSave.Name = "pbSave";
            this.pbSave.NamedProperties.Put("MethodId", "18385");
            this.pbSave.NamedProperties.Put("MethodParameter", "Save");
            this.pbSave.NamedProperties.Put("ResizeableChildObject", "LLLL");
            // 
            // pbInclExcl
            // 
            resources.ApplyResources(this.pbInclExcl, "pbInclExcl");
            this.pbInclExcl.Name = "pbInclExcl";
            this.pbInclExcl.NamedProperties.Put("MethodId", "18385");
            this.pbInclExcl.NamedProperties.Put("MethodParameter", "IncludeExclude");
            this.pbInclExcl.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCreateTempl
            // 
            resources.ApplyResources(this.pbCreateTempl, "pbCreateTempl");
            this.pbCreateTempl.Name = "pbCreateTempl";
            this.pbCreateTempl.NamedProperties.Put("MethodId", "18385");
            this.pbCreateTempl.NamedProperties.Put("MethodParameter", "CreateTempl");
            this.pbCreateTempl.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // tblReportSelection
            // 
            resources.ApplyResources(this.tblReportSelection, "tblReportSelection");
            // 
            // tblReportSelection.coldFromValueDate
            // 
            resources.ApplyResources(this.tblReportSelection.coldFromValueDate, "tblReportSelection.coldFromValueDate");
            // 
            // tblReportSelection.coldToValueDate
            // 
            resources.ApplyResources(this.tblReportSelection.coldToValueDate, "tblReportSelection.coldToValueDate");
            // 
            // tblReportSelection.colnFromValue
            // 
            resources.ApplyResources(this.tblReportSelection.colnFromValue, "tblReportSelection.colnFromValue");
            // 
            // tblReportSelection.colnItemId
            // 
            resources.ApplyResources(this.tblReportSelection.colnItemId, "tblReportSelection.colnItemId");
            // 
            // tblReportSelection.colnSelectionId
            // 
            resources.ApplyResources(this.tblReportSelection.colnSelectionId, "tblReportSelection.colnSelectionId");
            // 
            // tblReportSelection.colnToValue
            // 
            resources.ApplyResources(this.tblReportSelection.colnToValue, "tblReportSelection.colnToValue");
            // 
            // tblReportSelection.colsCompany
            // 
            resources.ApplyResources(this.tblReportSelection.colsCompany, "tblReportSelection.colsCompany");
            // 
            // tblReportSelection.colsDataTypeDb
            // 
            resources.ApplyResources(this.tblReportSelection.colsDataTypeDb, "tblReportSelection.colsDataTypeDb");
            // 
            // tblReportSelection.colsFromValue
            // 
            resources.ApplyResources(this.tblReportSelection.colsFromValue, "tblReportSelection.colsFromValue");
            // 
            // tblReportSelection.colsManualInput
            // 
            resources.ApplyResources(this.tblReportSelection.colsManualInput, "tblReportSelection.colsManualInput");
            // 
            // tblReportSelection.colsObjectGroupId
            // 
            resources.ApplyResources(this.tblReportSelection.colsObjectGroupId, "tblReportSelection.colsObjectGroupId");
            // 
            // tblReportSelection.colsObjectId
            // 
            resources.ApplyResources(this.tblReportSelection.colsObjectId, "tblReportSelection.colsObjectId");
            // 
            // tblReportSelection.colsObjectViewName
            // 
            resources.ApplyResources(this.tblReportSelection.colsObjectViewName, "tblReportSelection.colsObjectViewName");
            // 
            // tblReportSelection.colsOperator
            // 
            resources.ApplyResources(this.tblReportSelection.colsOperator, "tblReportSelection.colsOperator");
            // 
            // tblReportSelection.colsOperatorDb
            // 
            resources.ApplyResources(this.tblReportSelection.colsOperatorDb, "tblReportSelection.colsOperatorDb");
            // 
            // tblReportSelection.colsSelectionObjectId
            // 
            resources.ApplyResources(this.tblReportSelection.colsSelectionObjectId, "tblReportSelection.colsSelectionObjectId");
            // 
            // tblReportSelection.colsSelectionObjIdDesc
            // 
            resources.ApplyResources(this.tblReportSelection.colsSelectionObjIdDesc, "tblReportSelection.colsSelectionObjIdDesc");
            // 
            // tblReportSelection.colsToValue
            // 
            resources.ApplyResources(this.tblReportSelection.colsToValue, "tblReportSelection.colsToValue");
            // 
            // tblReportSelection.colsValueExist
            // 
            resources.ApplyResources(this.tblReportSelection.colsValueExist, "tblReportSelection.colsValueExist");
            this.tblReportSelection.Name = "tblReportSelection";
            this.tblReportSelection.NamedProperties.Put("DefaultOrderBy", "");
            this.tblReportSelection.NamedProperties.Put("DefaultWhere", "object_id = :i_hWndFrame.dlgReportSelTemplInfo.tblReportSelection.i_sObjectId and" +
        "\r\nselection_id = :i_hWndFrame.dlgReportSelTemplInfo.tblReportSelection.i_nSelect" +
        "ionId");
            this.tblReportSelection.NamedProperties.Put("LogicalUnit", "FinObjectSelection");
            this.tblReportSelection.NamedProperties.Put("PackageName", "FIN_OBJECT_SELECTION_API");
            this.tblReportSelection.NamedProperties.Put("ResizeableChildObject", "LLRR");
            this.tblReportSelection.NamedProperties.Put("ViewName", "FIN_OBJECT_SELECTION");
            this.tblReportSelection.NamedProperties.Put("Warnings", "FALSE");
            this.tblReportSelection.RefreshDialogButtonsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblReportSelection_RefreshDialogButtonsEvent);
            this.tblReportSelection.UserMethodEvent += new Ifs.Fnd.ApplicationForms.cMethodManager.UserMethodEventHandler(this.tblReportSelection_UserMethodEvent);
            this.tblReportSelection.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblReportSelection_WindowActions);
            // 
            // dlgReportSelTemplInfo
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "dlgReportSelTemplInfo";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "FinSelObjTempl");
            this.NamedProperties.Put("PackageName", "FIN_SEL_OBJ_TEMPL_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "FIN_SEL_OBJ_TEMPL");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgReportSelTemplInfo_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
            this.tblReportSelection.ResumeLayout(false);
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

        public cChildTableObjectSelection tblReportSelection;
	}
}
