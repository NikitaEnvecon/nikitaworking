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
using Ifs.Application.Accrul;
using Ifs.Application.Appsrv;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Accrul_
{
	
	public partial class dlgExtFileTemplDetFunc
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfFileTemplateId;
		public cDataField dfFileTemplateId;
		protected cBackgroundText labeldfsTemplateDescription;
		public cDataField dfsTemplateDescription;
		protected cBackgroundText labeldfsColumnId;
		public cDataField dfsColumnId;
		protected cBackgroundText labeldfsColumnDescription;
		public cDataField dfsColumnDescription;
        // Bug 73298 Begin - Changed the derived base class.
		// Bug 73298 End.
		public cPushButton pbNew;
		public cPushButton pbSave;
		public cPushButton pbRemove;
		public cPushButton pbList;
		public cPushButton pbClose;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgExtFileTemplDetFunc));
            this.labeldfFileTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFileTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsTemplateDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTemplateDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsColumnId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsColumnId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsColumnDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsColumnDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbNew = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbSave = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbRemove = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbList = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbClose = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.tblExtFileTemplDetFunc = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblExtFileTemplDetFunc_colsFileTemplateId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTemplDetFunc_colnRowNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTemplDetFunc_colnFunctionNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTemplDetFunc_colsMainFunction = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTemplDetFunc_colFunctionArgument = new Ifs.Fnd.ApplicationForms.cColumn();
            this.ClientArea.SuspendLayout();
            this.tblExtFileTemplDetFunc.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.Create = true;
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbClose);
            this.ClientArea.Controls.Add(this.pbList);
            this.ClientArea.Controls.Add(this.pbRemove);
            this.ClientArea.Controls.Add(this.pbSave);
            this.ClientArea.Controls.Add(this.pbNew);
            this.ClientArea.Controls.Add(this.tblExtFileTemplDetFunc);
            this.ClientArea.Controls.Add(this.dfsColumnDescription);
            this.ClientArea.Controls.Add(this.dfsColumnId);
            this.ClientArea.Controls.Add(this.dfsTemplateDescription);
            this.ClientArea.Controls.Add(this.dfFileTemplateId);
            this.ClientArea.Controls.Add(this.labeldfsColumnDescription);
            this.ClientArea.Controls.Add(this.labeldfsColumnId);
            this.ClientArea.Controls.Add(this.labeldfsTemplateDescription);
            this.ClientArea.Controls.Add(this.labeldfFileTemplateId);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbClose);
            this.commandManager.Components.Add(this.pbList);
            this.commandManager.Components.Add(this.pbRemove);
            this.commandManager.Components.Add(this.pbSave);
            this.commandManager.Components.Add(this.pbNew);
            // 
            // labeldfFileTemplateId
            // 
            resources.ApplyResources(this.labeldfFileTemplateId, "labeldfFileTemplateId");
            this.labeldfFileTemplateId.Name = "labeldfFileTemplateId";
            // 
            // dfFileTemplateId
            // 
            resources.ApplyResources(this.dfFileTemplateId, "dfFileTemplateId");
            this.dfFileTemplateId.Name = "dfFileTemplateId";
            this.dfFileTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.dfFileTemplateId.NamedProperties.Put("LovReference", "");
            this.dfFileTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfFileTemplateId.NamedProperties.Put("SqlColumn", "");
            this.dfFileTemplateId.NamedProperties.Put("ValidateMethod", "");
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
            this.dfsTemplateDescription.NamedProperties.Put("FieldFlags", "288");
            this.dfsTemplateDescription.NamedProperties.Put("LovReference", "");
            this.dfsTemplateDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTemplateDescription.NamedProperties.Put("SqlColumn", "");
            this.dfsTemplateDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsColumnId
            // 
            resources.ApplyResources(this.labeldfsColumnId, "labeldfsColumnId");
            this.labeldfsColumnId.Name = "labeldfsColumnId";
            // 
            // dfsColumnId
            // 
            resources.ApplyResources(this.dfsColumnId, "dfsColumnId");
            this.dfsColumnId.Name = "dfsColumnId";
            this.dfsColumnId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsColumnId.NamedProperties.Put("LovReference", "");
            this.dfsColumnId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsColumnId.NamedProperties.Put("SqlColumn", "");
            this.dfsColumnId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsColumnDescription
            // 
            resources.ApplyResources(this.labeldfsColumnDescription, "labeldfsColumnDescription");
            this.labeldfsColumnDescription.Name = "labeldfsColumnDescription";
            // 
            // dfsColumnDescription
            // 
            resources.ApplyResources(this.dfsColumnDescription, "dfsColumnDescription");
            this.dfsColumnDescription.Name = "dfsColumnDescription";
            this.dfsColumnDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsColumnDescription.NamedProperties.Put("FieldFlags", "288");
            this.dfsColumnDescription.NamedProperties.Put("LovReference", "");
            this.dfsColumnDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsColumnDescription.NamedProperties.Put("SqlColumn", "");
            this.dfsColumnDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // pbNew
            // 
            this.pbNew.AcceleratorKey = System.Windows.Forms.Keys.F5;
            resources.ApplyResources(this.pbNew, "pbNew");
            this.pbNew.Name = "pbNew";
            this.pbNew.NamedProperties.Put("MethodId", "18385");
            this.pbNew.NamedProperties.Put("MethodParameter", "New");
            this.pbNew.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbSave
            // 
            this.pbSave.AcceleratorKey = System.Windows.Forms.Keys.F12;
            resources.ApplyResources(this.pbSave, "pbSave");
            this.pbSave.Name = "pbSave";
            this.pbSave.NamedProperties.Put("MethodId", "18385");
            this.pbSave.NamedProperties.Put("MethodParameter", "Save");
            this.pbSave.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbRemove
            // 
            this.pbRemove.AcceleratorKey = System.Windows.Forms.Keys.F7;
            resources.ApplyResources(this.pbRemove, "pbRemove");
            this.pbRemove.Name = "pbRemove";
            this.pbRemove.NamedProperties.Put("MethodId", "18385");
            this.pbRemove.NamedProperties.Put("MethodParameter", "Remove");
            this.pbRemove.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbList
            // 
            this.pbList.AcceleratorKey = System.Windows.Forms.Keys.F8;
            resources.ApplyResources(this.pbList, "pbList");
            this.pbList.Name = "pbList";
            this.pbList.NamedProperties.Put("MethodId", "18385");
            this.pbList.NamedProperties.Put("MethodParameter", "List");
            this.pbList.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbClose
            // 
            this.pbClose.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbClose, "pbClose");
            this.pbClose.Name = "pbClose";
            this.pbClose.NamedProperties.Put("MethodId", "18385");
            this.pbClose.NamedProperties.Put("MethodParameter", "Close");
            this.pbClose.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // tblExtFileTemplDetFunc
            // 
            this.tblExtFileTemplDetFunc.Controls.Add(this.tblExtFileTemplDetFunc_colsFileTemplateId);
            this.tblExtFileTemplDetFunc.Controls.Add(this.tblExtFileTemplDetFunc_colnRowNo);
            this.tblExtFileTemplDetFunc.Controls.Add(this.tblExtFileTemplDetFunc_colnFunctionNo);
            this.tblExtFileTemplDetFunc.Controls.Add(this.tblExtFileTemplDetFunc_colsMainFunction);
            this.tblExtFileTemplDetFunc.Controls.Add(this.tblExtFileTemplDetFunc_colFunctionArgument);
            resources.ApplyResources(this.tblExtFileTemplDetFunc, "tblExtFileTemplDetFunc");
            this.tblExtFileTemplDetFunc.Name = "tblExtFileTemplDetFunc";
            this.tblExtFileTemplDetFunc.NamedProperties.Put("DefaultOrderBy", "");
            this.tblExtFileTemplDetFunc.NamedProperties.Put("DefaultWhere", "FILE_TEMPLATE_ID = :i_hWndFrame.dlgExtFileTemplDetFunc.sFileTemplateId\r\nand ROW_N" +
                    "O = :i_hWndFrame.dlgExtFileTemplDetFunc.nRowNo");
            this.tblExtFileTemplDetFunc.NamedProperties.Put("LogicalUnit", "ExtFileTemplDetFunc");
            this.tblExtFileTemplDetFunc.NamedProperties.Put("PackageName", "EXT_FILE_TEMPL_DET_FUNC_API");
            this.tblExtFileTemplDetFunc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTemplDetFunc.NamedProperties.Put("ViewName", "EXT_FILE_TEMPL_DET_FUNC");
            this.tblExtFileTemplDetFunc.NamedProperties.Put("Warnings", "FALSE");
            this.tblExtFileTemplDetFunc.MethodInvestigateStateEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalNumber>(this.tblExtFileTemplDetFunc_MethodInvestigateStateEvent);
            this.tblExtFileTemplDetFunc.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblExtFileTemplDetFunc_DataRecordGetDefaultsEvent);
            this.tblExtFileTemplDetFunc.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTemplDetFunc_WindowActions);
            this.tblExtFileTemplDetFunc.Controls.SetChildIndex(this.tblExtFileTemplDetFunc_colFunctionArgument, 0);
            this.tblExtFileTemplDetFunc.Controls.SetChildIndex(this.tblExtFileTemplDetFunc_colsMainFunction, 0);
            this.tblExtFileTemplDetFunc.Controls.SetChildIndex(this.tblExtFileTemplDetFunc_colnFunctionNo, 0);
            this.tblExtFileTemplDetFunc.Controls.SetChildIndex(this.tblExtFileTemplDetFunc_colnRowNo, 0);
            this.tblExtFileTemplDetFunc.Controls.SetChildIndex(this.tblExtFileTemplDetFunc_colsFileTemplateId, 0);
            // 
            // tblExtFileTemplDetFunc_colsFileTemplateId
            // 
            resources.ApplyResources(this.tblExtFileTemplDetFunc_colsFileTemplateId, "tblExtFileTemplDetFunc_colsFileTemplateId");
            this.tblExtFileTemplDetFunc_colsFileTemplateId.MaxLength = 30;
            this.tblExtFileTemplDetFunc_colsFileTemplateId.Name = "tblExtFileTemplDetFunc_colsFileTemplateId";
            this.tblExtFileTemplDetFunc_colsFileTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTemplDetFunc_colsFileTemplateId.NamedProperties.Put("FieldFlags", "67");
            this.tblExtFileTemplDetFunc_colsFileTemplateId.NamedProperties.Put("LovReference", "");
            this.tblExtFileTemplDetFunc_colsFileTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTemplDetFunc_colsFileTemplateId.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE_ID");
            this.tblExtFileTemplDetFunc_colsFileTemplateId.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTemplDetFunc_colsFileTemplateId.Position = 3;
            // 
            // tblExtFileTemplDetFunc_colnRowNo
            // 
            this.tblExtFileTemplDetFunc_colnRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblExtFileTemplDetFunc_colnRowNo, "tblExtFileTemplDetFunc_colnRowNo");
            this.tblExtFileTemplDetFunc_colnRowNo.Name = "tblExtFileTemplDetFunc_colnRowNo";
            this.tblExtFileTemplDetFunc_colnRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTemplDetFunc_colnRowNo.NamedProperties.Put("FieldFlags", "67");
            this.tblExtFileTemplDetFunc_colnRowNo.NamedProperties.Put("LovReference", "EXT_FILE_TEMPLATE_DETAIL(FILE_TEMPLATE_ID)");
            this.tblExtFileTemplDetFunc_colnRowNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTemplDetFunc_colnRowNo.NamedProperties.Put("SqlColumn", "ROW_NO");
            this.tblExtFileTemplDetFunc_colnRowNo.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTemplDetFunc_colnRowNo.Position = 4;
            // 
            // tblExtFileTemplDetFunc_colnFunctionNo
            // 
            this.tblExtFileTemplDetFunc_colnFunctionNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTemplDetFunc_colnFunctionNo.Name = "tblExtFileTemplDetFunc_colnFunctionNo";
            this.tblExtFileTemplDetFunc_colnFunctionNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTemplDetFunc_colnFunctionNo.NamedProperties.Put("FieldFlags", "163");
            this.tblExtFileTemplDetFunc_colnFunctionNo.NamedProperties.Put("LovReference", "");
            this.tblExtFileTemplDetFunc_colnFunctionNo.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTemplDetFunc_colnFunctionNo.NamedProperties.Put("SqlColumn", "FUNCTION_NO");
            this.tblExtFileTemplDetFunc_colnFunctionNo.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTemplDetFunc_colnFunctionNo.Position = 5;
            resources.ApplyResources(this.tblExtFileTemplDetFunc_colnFunctionNo, "tblExtFileTemplDetFunc_colnFunctionNo");
            // 
            // tblExtFileTemplDetFunc_colsMainFunction
            // 
            this.tblExtFileTemplDetFunc_colsMainFunction.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblExtFileTemplDetFunc_colsMainFunction.MaxLength = 50;
            this.tblExtFileTemplDetFunc_colsMainFunction.Name = "tblExtFileTemplDetFunc_colsMainFunction";
            this.tblExtFileTemplDetFunc_colsMainFunction.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTemplDetFunc_colsMainFunction.NamedProperties.Put("FieldFlags", "295");
            this.tblExtFileTemplDetFunc_colsMainFunction.NamedProperties.Put("LovReference", "EXT_FILE_FUNCTION");
            this.tblExtFileTemplDetFunc_colsMainFunction.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTemplDetFunc_colsMainFunction.NamedProperties.Put("SqlColumn", "MAIN_FUNCTION");
            this.tblExtFileTemplDetFunc_colsMainFunction.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTemplDetFunc_colsMainFunction.Position = 6;
            resources.ApplyResources(this.tblExtFileTemplDetFunc_colsMainFunction, "tblExtFileTemplDetFunc_colsMainFunction");
            // 
            // tblExtFileTemplDetFunc_colFunctionArgument
            // 
            this.tblExtFileTemplDetFunc_colFunctionArgument.MaxLength = 2000;
            this.tblExtFileTemplDetFunc_colFunctionArgument.Name = "tblExtFileTemplDetFunc_colFunctionArgument";
            this.tblExtFileTemplDetFunc_colFunctionArgument.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTemplDetFunc_colFunctionArgument.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTemplDetFunc_colFunctionArgument.NamedProperties.Put("LovReference", "");
            this.tblExtFileTemplDetFunc_colFunctionArgument.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTemplDetFunc_colFunctionArgument.NamedProperties.Put("SqlColumn", "FUNCTION_ARGUMENT");
            this.tblExtFileTemplDetFunc_colFunctionArgument.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTemplDetFunc_colFunctionArgument.Position = 7;
            resources.ApplyResources(this.tblExtFileTemplDetFunc_colFunctionArgument, "tblExtFileTemplDetFunc_colFunctionArgument");
            // 
            // dlgExtFileTemplDetFunc
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgExtFileTemplDetFunc";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgExtFileTemplDetFunc_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
            this.tblExtFileTemplDetFunc.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		
        public cChildTableFinBase tblExtFileTemplDetFunc;
        protected cColumn tblExtFileTemplDetFunc_colsFileTemplateId;
        protected cColumn tblExtFileTemplDetFunc_colnRowNo;
        protected cColumn tblExtFileTemplDetFunc_colnFunctionNo;
        protected cColumn tblExtFileTemplDetFunc_colsMainFunction;
        protected cColumn tblExtFileTemplDetFunc_colFunctionArgument;
		
		
	}
}
