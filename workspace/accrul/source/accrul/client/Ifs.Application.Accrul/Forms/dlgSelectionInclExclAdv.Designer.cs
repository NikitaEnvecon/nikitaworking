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
	
	public partial class dlgSelectionInclExclAdv
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls

        public cPushButton pbSave;
		public cPushButton pbCancel;
		public cPushButton pbLov;
		public cPushButton pbRemove;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgSelectionInclExclAdv));
            this.pbSave = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbLov = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbRemove = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.tblValues = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.tblValues_colCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblValues_colObjectGroupId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblValues_colTemplateId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblValues_colItemId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblValues_colValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblValues_colDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblValues_colStatus = new Ifs.Fnd.ApplicationForms.cColumn();
            this.ClientArea.SuspendLayout();
            this.tblValues.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbRemove);
            this.ClientArea.Controls.Add(this.pbLov);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbSave);
            this.ClientArea.Controls.Add(this.tblValues);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbRemove);
            this.commandManager.Components.Add(this.pbLov);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbSave);
            // 
            // pbSave
            // 
            resources.ApplyResources(this.pbSave, "pbSave");
            this.pbSave.Name = "pbSave";
            this.pbSave.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbSave_WindowActions);
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbCancel_WindowActions);
            // 
            // pbLov
            // 
            this.pbLov.AcceleratorKey = System.Windows.Forms.Keys.F8;
            resources.ApplyResources(this.pbLov, "pbLov");
            this.pbLov.Name = "pbLov";
            this.pbLov.NamedProperties.Put("MethodId", "18385");
            this.pbLov.NamedProperties.Put("MethodParameter", "LOV");
            this.pbLov.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbRemove
            // 
            resources.ApplyResources(this.pbRemove, "pbRemove");
            this.pbRemove.Name = "pbRemove";
            this.pbRemove.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbRemove_WindowActions);
            // 
            // tblValues
            // 
            resources.ApplyResources(this.tblValues, "tblValues");
            this.tblValues.Controls.Add(this.tblValues_colCompany);
            this.tblValues.Controls.Add(this.tblValues_colObjectGroupId);
            this.tblValues.Controls.Add(this.tblValues_colTemplateId);
            this.tblValues.Controls.Add(this.tblValues_colItemId);
            this.tblValues.Controls.Add(this.tblValues_colValue);
            this.tblValues.Controls.Add(this.tblValues_colDescription);
            this.tblValues.Controls.Add(this.tblValues_colStatus);
            this.tblValues.Name = "tblValues";
            this.tblValues.NamedProperties.Put("DefaultOrderBy", "");
            this.tblValues.NamedProperties.Put("DefaultWhere", @"COMPANY=:i_hWndFrame.dlgSelectionInclExclAdv.p_sCompany AND 
OBJECT_GROUP_ID=:i_hWndFrame.dlgSelectionInclExclAdv.p_sObjectGroupId AND
TEMPLATE_ID = :i_hWndFrame.dlgSelectionInclExclAdv.p_sTemplateId AND
ITEM_ID = :i_hWndFrame.dlgSelectionInclExclAdv.p_nItemId");
            this.tblValues.NamedProperties.Put("LogicalUnit", "FinSelTemplValues");
            this.tblValues.NamedProperties.Put("PackageName", "FIN_SEL_TEMPL_VALUES_API");
            this.tblValues.NamedProperties.Put("ResizeableChildObject", "0");
            this.tblValues.NamedProperties.Put("SourceFlags", "321");
            this.tblValues.NamedProperties.Put("ViewName", "FIN_SEL_TEMPL_VALUES");
            this.tblValues.NamedProperties.Put("Warnings", "FALSE");
            this.tblValues.DataSourceFormatSqlColumnUserEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalString>(this.tblValues_DataSourceFormatSqlColumnUserEvent);
            this.tblValues.DataSourceFormatSqlIntoUserEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalString>(this.tblValues_DataSourceFormatSqlIntoUserEvent);
            this.tblValues.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblValues_DataRecordGetDefaultsEvent);
            this.tblValues.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblValues_WindowActions);
            this.tblValues.Controls.SetChildIndex(this.tblValues_colStatus, 0);
            this.tblValues.Controls.SetChildIndex(this.tblValues_colDescription, 0);
            this.tblValues.Controls.SetChildIndex(this.tblValues_colValue, 0);
            this.tblValues.Controls.SetChildIndex(this.tblValues_colItemId, 0);
            this.tblValues.Controls.SetChildIndex(this.tblValues_colTemplateId, 0);
            this.tblValues.Controls.SetChildIndex(this.tblValues_colObjectGroupId, 0);
            this.tblValues.Controls.SetChildIndex(this.tblValues_colCompany, 0);
            // 
            // tblValues_colCompany
            // 
            resources.ApplyResources(this.tblValues_colCompany, "tblValues_colCompany");
            this.tblValues_colCompany.Name = "tblValues_colCompany";
            this.tblValues_colCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblValues_colCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblValues_colCompany.NamedProperties.Put("LovReference", "");
            this.tblValues_colCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblValues_colCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblValues_colCompany.Position = 3;
            // 
            // tblValues_colObjectGroupId
            // 
            resources.ApplyResources(this.tblValues_colObjectGroupId, "tblValues_colObjectGroupId");
            this.tblValues_colObjectGroupId.Name = "tblValues_colObjectGroupId";
            this.tblValues_colObjectGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.tblValues_colObjectGroupId.NamedProperties.Put("FieldFlags", "64");
            this.tblValues_colObjectGroupId.NamedProperties.Put("LovReference", "");
            this.tblValues_colObjectGroupId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblValues_colObjectGroupId.NamedProperties.Put("SqlColumn", "OBJECT_GROUP_ID");
            this.tblValues_colObjectGroupId.NamedProperties.Put("ValidateMethod", "");
            this.tblValues_colObjectGroupId.Position = 4;
            // 
            // tblValues_colTemplateId
            // 
            resources.ApplyResources(this.tblValues_colTemplateId, "tblValues_colTemplateId");
            this.tblValues_colTemplateId.MaxLength = 20;
            this.tblValues_colTemplateId.Name = "tblValues_colTemplateId";
            this.tblValues_colTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.tblValues_colTemplateId.NamedProperties.Put("FieldFlags", "67");
            this.tblValues_colTemplateId.NamedProperties.Put("LovReference", "");
            this.tblValues_colTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblValues_colTemplateId.NamedProperties.Put("SqlColumn", "TEMPLATE_ID");
            this.tblValues_colTemplateId.NamedProperties.Put("ValidateMethod", "");
            this.tblValues_colTemplateId.Position = 5;
            // 
            // tblValues_colItemId
            // 
            this.tblValues_colItemId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblValues_colItemId, "tblValues_colItemId");
            this.tblValues_colItemId.MaxLength = 10;
            this.tblValues_colItemId.Name = "tblValues_colItemId";
            this.tblValues_colItemId.NamedProperties.Put("EnumerateMethod", "");
            this.tblValues_colItemId.NamedProperties.Put("FieldFlags", "67");
            this.tblValues_colItemId.NamedProperties.Put("LovReference", "");
            this.tblValues_colItemId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblValues_colItemId.NamedProperties.Put("SqlColumn", "ITEM_ID");
            this.tblValues_colItemId.NamedProperties.Put("ValidateMethod", "");
            this.tblValues_colItemId.Position = 6;
            // 
            // tblValues_colValue
            // 
            this.tblValues_colValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblValues_colValue.MaxLength = 20;
            this.tblValues_colValue.Name = "tblValues_colValue";
            this.tblValues_colValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblValues_colValue.NamedProperties.Put("FieldFlags", "71");
            this.tblValues_colValue.NamedProperties.Put("LovReference", "");
            this.tblValues_colValue.NamedProperties.Put("ResizeableChildObject", "");
            this.tblValues_colValue.NamedProperties.Put("SqlColumn", "VALUE");
            this.tblValues_colValue.NamedProperties.Put("ValidateMethod", "");
            this.tblValues_colValue.Position = 7;
            resources.ApplyResources(this.tblValues_colValue, "tblValues_colValue");
            this.tblValues_colValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblValues_colValue_WindowActions);
            // 
            // tblValues_colDescription
            // 
            this.tblValues_colDescription.Name = "tblValues_colDescription";
            this.tblValues_colDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblValues_colDescription.NamedProperties.Put("FieldFlags", "258");
            this.tblValues_colDescription.NamedProperties.Put("LovReference", "");
            this.tblValues_colDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblValues_colDescription.NamedProperties.Put("SqlColumn", "NULL");
            this.tblValues_colDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblValues_colDescription.Position = 8;
            resources.ApplyResources(this.tblValues_colDescription, "tblValues_colDescription");
            this.tblValues_colDescription.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblValues_colDescription_WindowActions);
            // 
            // tblValues_colStatus
            // 
            resources.ApplyResources(this.tblValues_colStatus, "tblValues_colStatus");
            this.tblValues_colStatus.Name = "tblValues_colStatus";
            this.tblValues_colStatus.NamedProperties.Put("EnumerateMethod", "");
            this.tblValues_colStatus.NamedProperties.Put("LovReference", "");
            this.tblValues_colStatus.NamedProperties.Put("ResizeableChildObject", "");
            this.tblValues_colStatus.NamedProperties.Put("SqlColumn", "");
            this.tblValues_colStatus.NamedProperties.Put("ValidateMethod", "");
            this.tblValues_colStatus.Position = 9;
            // 
            // dlgSelectionInclExclAdv
            // 
            resources.ApplyResources(this, "$this");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "dlgSelectionInclExclAdv";
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgSelectionInclExclAdv_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.tblValues.ResumeLayout(false);
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

        public cChildTable tblValues;
        protected cColumn tblValues_colCompany;
        protected cColumn tblValues_colObjectGroupId;
        protected cColumn tblValues_colTemplateId;
        protected cColumn tblValues_colItemId;
        protected cColumn tblValues_colValue;
        protected cColumn tblValues_colDescription;
        protected cColumn tblValues_colStatus;
	}
}
