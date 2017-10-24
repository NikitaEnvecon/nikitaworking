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
//130305  AJPELK , BUG 107649, Merged bug , added new check box , cbRemoveEndSep.  
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
	
	public partial class frmExternalFileTemplateOut
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		// Bug 71319, Begin.
		public cDataField dfsFileTemplateId;
		public cComboBox cmbFileDirection;
		protected SalGroupBox gbCreation_Options;
		protected cBackgroundText labeldfsFileName;
		// Bug 79498 Increased length to 259
		// Bug 79498 Begin
		public cDataField dfsFileName;
		protected cBackgroundText labelcmbNameOption;
		public cComboBox cmbNameOption;
		protected cBackgroundText labeldfsOutputFilePath;
		// Bug 79498 Increased length to 256
		// Bug 79498 Begin
		public cDataField dfsOutputFilePath;
		protected cBackgroundText labeldfsOutputFilePathServer;
		// Bug 79498 Increased length to 256
		// Bug 79498 Begin
		public cDataField dfsOutputFilePathServer;
		protected cBackgroundText labeldfsNumberOutFillValue;
		// Bug 71319, Begin.
		public cDataField dfsNumberOutFillValue;
		// Bug 71319, Begin.
		public cCheckBoxFin cbOverwriteFile;
		// Bug 71319, Begin.
		public cCheckBoxFin cbCreateHeader;
		public cCheckBoxFin cbSystemDefined;
		protected cBackgroundText labeldfsApiToCall;
		// Bug 71319, Begin.
		public cDataField dfsApiToCall;
		protected cBackgroundText labeldfnRemoveDays;
		public cDataField dfnRemoveDays;
		public cCheckBox cbRemoveComplete;
		protected SalGroupBox gbRemove_Transaction_Options;
		protected cBackgroundText labeldfsCharacterSet;
		public cDataField dfsCharacterSet;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExternalFileTemplateOut));
            this.menuFrmMethods_menuExternal_File_Template_C_ontrol_ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsFileTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cmbFileDirection = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.gbCreation_Options = new PPJ.Runtime.Windows.SalGroupBox();
            this.cbRemoveEndSep = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfsFileName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbNameOption = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbNameOption = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfsOutputFilePath = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsOutputFilePath = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsOutputFilePathServer = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsOutputFilePathServer = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsNumberOutFillValue = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsNumberOutFillValue = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbOverwriteFile = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbCreateHeader = new Ifs.Application.Accrul.cCheckBoxFin();
            this.cbSystemDefined = new Ifs.Application.Accrul.cCheckBoxFin();
            this.labeldfsApiToCall = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsApiToCall = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfnRemoveDays = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnRemoveDays = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbRemoveComplete = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.gbRemove_Transaction_Options = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfsCharacterSet = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCharacterSet = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_External = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.gbCreation_Options.SuspendLayout();
            this.menuFrmMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menuExternal_File_Template_C_ontrol_);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            // 
            // menuFrmMethods_menuExternal_File_Template_C_ontrol_
            // 
            resources.ApplyResources(this.menuFrmMethods_menuExternal_File_Template_C_ontrol_, "menuFrmMethods_menuExternal_File_Template_C_ontrol_");
            this.menuFrmMethods_menuExternal_File_Template_C_ontrol_.Name = "menuFrmMethods_menuExternal_File_Template_C_ontrol_";
            this.menuFrmMethods_menuExternal_File_Template_C_ontrol_.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_External_Execute);
            this.menuFrmMethods_menuExternal_File_Template_C_ontrol_.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_External_Inquire);
            // 
            // dfsFileTemplateId
            // 
            resources.ApplyResources(this.dfsFileTemplateId, "dfsFileTemplateId");
            this.dfsFileTemplateId.Name = "dfsFileTemplateId";
            this.dfsFileTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileTemplateId.NamedProperties.Put("FieldFlags", "67");
            this.dfsFileTemplateId.NamedProperties.Put("LovReference", "EXT_FILE_TEMPLATE");
            this.dfsFileTemplateId.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE_ID");
            this.dfsFileTemplateId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsFileTemplateId_WindowActions);
            // 
            // cmbFileDirection
            // 
            resources.ApplyResources(this.cmbFileDirection, "cmbFileDirection");
            this.cmbFileDirection.Name = "cmbFileDirection";
            this.cmbFileDirection.NamedProperties.Put("EnumerateMethod", "FILE_DIRECTION_API.Enumerate");
            this.cmbFileDirection.NamedProperties.Put("FieldFlags", "135");
            this.cmbFileDirection.NamedProperties.Put("LovReference", "");
            this.cmbFileDirection.NamedProperties.Put("SqlColumn", "FILE_DIRECTION");
            this.cmbFileDirection.NamedProperties.Put("ValidateMethod", "");
            this.cmbFileDirection.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbFileDirection_WindowActions);
            // 
            // gbCreation_Options
            // 
            this.gbCreation_Options.Controls.Add(this.cbRemoveEndSep);
            resources.ApplyResources(this.gbCreation_Options, "gbCreation_Options");
            this.gbCreation_Options.Name = "gbCreation_Options";
            this.gbCreation_Options.TabStop = false;
            // 
            // cbRemoveEndSep
            // 
            resources.ApplyResources(this.cbRemoveEndSep, "cbRemoveEndSep");
            this.cbRemoveEndSep.Name = "cbRemoveEndSep";
            this.cbRemoveEndSep.NamedProperties.Put("EnumerateMethod", "");
            this.cbRemoveEndSep.NamedProperties.Put("FieldFlags", "294");
            this.cbRemoveEndSep.NamedProperties.Put("LovReference", "");
            this.cbRemoveEndSep.NamedProperties.Put("SqlColumn", "REMOVE_END_SEPARATOR");
            // 
            // labeldfsFileName
            // 
            resources.ApplyResources(this.labeldfsFileName, "labeldfsFileName");
            this.labeldfsFileName.Name = "labeldfsFileName";
            // 
            // dfsFileName
            // 
            resources.ApplyResources(this.dfsFileName, "dfsFileName");
            this.dfsFileName.Name = "dfsFileName";
            this.dfsFileName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileName.NamedProperties.Put("FieldFlags", "294");
            this.dfsFileName.NamedProperties.Put("LovReference", "");
            this.dfsFileName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileName.NamedProperties.Put("SqlColumn", "FILE_NAME");
            this.dfsFileName.NamedProperties.Put("ValidateMethod", "");
            this.dfsFileName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsFileName_WindowActions);
            // 
            // labelcmbNameOption
            // 
            resources.ApplyResources(this.labelcmbNameOption, "labelcmbNameOption");
            this.labelcmbNameOption.Name = "labelcmbNameOption";
            // 
            // cmbNameOption
            // 
            resources.ApplyResources(this.cmbNameOption, "cmbNameOption");
            this.cmbNameOption.Name = "cmbNameOption";
            this.cmbNameOption.NamedProperties.Put("EnumerateMethod", "EXT_FILE_NAME_OPTION_API.Enumerate");
            this.cmbNameOption.NamedProperties.Put("FieldFlags", "295");
            this.cmbNameOption.NamedProperties.Put("LovReference", "");
            this.cmbNameOption.NamedProperties.Put("SqlColumn", "NAME_OPTION");
            this.cmbNameOption.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbNameOption_WindowActions);
            // 
            // labeldfsOutputFilePath
            // 
            resources.ApplyResources(this.labeldfsOutputFilePath, "labeldfsOutputFilePath");
            this.labeldfsOutputFilePath.Name = "labeldfsOutputFilePath";
            // 
            // dfsOutputFilePath
            // 
            resources.ApplyResources(this.dfsOutputFilePath, "dfsOutputFilePath");
            this.dfsOutputFilePath.Name = "dfsOutputFilePath";
            this.dfsOutputFilePath.NamedProperties.Put("EnumerateMethod", "");
            this.dfsOutputFilePath.NamedProperties.Put("FieldFlags", "294");
            this.dfsOutputFilePath.NamedProperties.Put("LovReference", "");
            this.dfsOutputFilePath.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsOutputFilePath.NamedProperties.Put("SqlColumn", "FILE_PATH");
            this.dfsOutputFilePath.NamedProperties.Put("ValidateMethod", "");
            this.dfsOutputFilePath.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsOutputFilePath_WindowActions);
            // 
            // labeldfsOutputFilePathServer
            // 
            resources.ApplyResources(this.labeldfsOutputFilePathServer, "labeldfsOutputFilePathServer");
            this.labeldfsOutputFilePathServer.Name = "labeldfsOutputFilePathServer";
            // 
            // dfsOutputFilePathServer
            // 
            resources.ApplyResources(this.dfsOutputFilePathServer, "dfsOutputFilePathServer");
            this.dfsOutputFilePathServer.Name = "dfsOutputFilePathServer";
            this.dfsOutputFilePathServer.NamedProperties.Put("EnumerateMethod", "");
            this.dfsOutputFilePathServer.NamedProperties.Put("FieldFlags", "294");
            this.dfsOutputFilePathServer.NamedProperties.Put("LovReference", "");
            this.dfsOutputFilePathServer.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsOutputFilePathServer.NamedProperties.Put("SqlColumn", "FILE_PATH_SERVER");
            this.dfsOutputFilePathServer.NamedProperties.Put("ValidateMethod", "");
            this.dfsOutputFilePathServer.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsOutputFilePathServer_WindowActions);
            // 
            // labeldfsNumberOutFillValue
            // 
            resources.ApplyResources(this.labeldfsNumberOutFillValue, "labeldfsNumberOutFillValue");
            this.labeldfsNumberOutFillValue.Name = "labeldfsNumberOutFillValue";
            // 
            // dfsNumberOutFillValue
            // 
            resources.ApplyResources(this.dfsNumberOutFillValue, "dfsNumberOutFillValue");
            this.dfsNumberOutFillValue.Name = "dfsNumberOutFillValue";
            this.dfsNumberOutFillValue.NamedProperties.Put("EnumerateMethod", "");
            this.dfsNumberOutFillValue.NamedProperties.Put("FieldFlags", "294");
            this.dfsNumberOutFillValue.NamedProperties.Put("LovReference", "");
            this.dfsNumberOutFillValue.NamedProperties.Put("SqlColumn", "NUMBER_OUT_FILL_VALUE");
            this.dfsNumberOutFillValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsNumberOutFillValue_WindowActions);
            // 
            // cbOverwriteFile
            // 
            resources.ApplyResources(this.cbOverwriteFile, "cbOverwriteFile");
            this.cbOverwriteFile.Name = "cbOverwriteFile";
            this.cbOverwriteFile.NamedProperties.Put("DataType", "5");
            this.cbOverwriteFile.NamedProperties.Put("EnumerateMethod", "");
            this.cbOverwriteFile.NamedProperties.Put("FieldFlags", "295");
            this.cbOverwriteFile.NamedProperties.Put("LovReference", "");
            this.cbOverwriteFile.NamedProperties.Put("ResizeableChildObject", "");
            this.cbOverwriteFile.NamedProperties.Put("SqlColumn", "OVERWRITE_FILE");
            this.cbOverwriteFile.NamedProperties.Put("ValidateMethod", "");
            this.cbOverwriteFile.NamedProperties.Put("XDataLength", "5");
            this.cbOverwriteFile.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbOverwriteFile_WindowActions);
            this.cbOverwriteFile.CheckedChanged += new System.EventHandler(this.cbOverwriteFile_CheckedChanged);
            // 
            // cbCreateHeader
            // 
            resources.ApplyResources(this.cbCreateHeader, "cbCreateHeader");
            this.cbCreateHeader.Name = "cbCreateHeader";
            this.cbCreateHeader.NamedProperties.Put("DataType", "5");
            this.cbCreateHeader.NamedProperties.Put("EnumerateMethod", "");
            this.cbCreateHeader.NamedProperties.Put("FieldFlags", "295");
            this.cbCreateHeader.NamedProperties.Put("LovReference", "");
            this.cbCreateHeader.NamedProperties.Put("ResizeableChildObject", "");
            this.cbCreateHeader.NamedProperties.Put("SqlColumn", "CREATE_HEADER");
            this.cbCreateHeader.NamedProperties.Put("ValidateMethod", "");
            this.cbCreateHeader.NamedProperties.Put("XDataLength", "5");
            this.cbCreateHeader.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbCreateHeader_WindowActions);
            // 
            // cbSystemDefined
            // 
            resources.ApplyResources(this.cbSystemDefined, "cbSystemDefined");
            this.cbSystemDefined.Name = "cbSystemDefined";
            this.cbSystemDefined.NamedProperties.Put("DataType", "7");
            this.cbSystemDefined.NamedProperties.Put("EnumerateMethod", "");
            this.cbSystemDefined.NamedProperties.Put("FieldFlags", "291");
            this.cbSystemDefined.NamedProperties.Put("LovReference", "");
            this.cbSystemDefined.NamedProperties.Put("ParentName", "dfsFileTemplateId");
            this.cbSystemDefined.NamedProperties.Put("ResizeableChildObject", "");
            this.cbSystemDefined.NamedProperties.Put("SqlColumn", "EXT_FILE_TEMPLATE_API.Get_System_Defined(FILE_TEMPLATE_ID)");
            this.cbSystemDefined.NamedProperties.Put("ValidateMethod", "");
            this.cbSystemDefined.NamedProperties.Put("XDataLength", "2000");
            this.cbSystemDefined.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbSystemDefined_WindowActions);
            // 
            // labeldfsApiToCall
            // 
            resources.ApplyResources(this.labeldfsApiToCall, "labeldfsApiToCall");
            this.labeldfsApiToCall.Name = "labeldfsApiToCall";
            // 
            // dfsApiToCall
            // 
            resources.ApplyResources(this.dfsApiToCall, "dfsApiToCall");
            this.dfsApiToCall.Name = "dfsApiToCall";
            this.dfsApiToCall.NamedProperties.Put("EnumerateMethod", "");
            this.dfsApiToCall.NamedProperties.Put("FieldFlags", "294");
            this.dfsApiToCall.NamedProperties.Put("LovReference", "");
            this.dfsApiToCall.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsApiToCall.NamedProperties.Put("SqlColumn", "API_TO_CALL");
            this.dfsApiToCall.NamedProperties.Put("ValidateMethod", "");
            this.dfsApiToCall.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsApiToCall_WindowActions);
            // 
            // labeldfnRemoveDays
            // 
            resources.ApplyResources(this.labeldfnRemoveDays, "labeldfnRemoveDays");
            this.labeldfnRemoveDays.Name = "labeldfnRemoveDays";
            // 
            // dfnRemoveDays
            // 
            this.dfnRemoveDays.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnRemoveDays, "dfnRemoveDays");
            this.dfnRemoveDays.Name = "dfnRemoveDays";
            this.dfnRemoveDays.NamedProperties.Put("EnumerateMethod", "");
            this.dfnRemoveDays.NamedProperties.Put("FieldFlags", "294");
            this.dfnRemoveDays.NamedProperties.Put("LovReference", "");
            this.dfnRemoveDays.NamedProperties.Put("SqlColumn", "REMOVE_DAYS");
            // 
            // cbRemoveComplete
            // 
            resources.ApplyResources(this.cbRemoveComplete, "cbRemoveComplete");
            this.cbRemoveComplete.Name = "cbRemoveComplete";
            this.cbRemoveComplete.NamedProperties.Put("DataType", "5");
            this.cbRemoveComplete.NamedProperties.Put("EnumerateMethod", "");
            this.cbRemoveComplete.NamedProperties.Put("FieldFlags", "295");
            this.cbRemoveComplete.NamedProperties.Put("LovReference", "");
            this.cbRemoveComplete.NamedProperties.Put("ResizeableChildObject", "");
            this.cbRemoveComplete.NamedProperties.Put("SqlColumn", "REMOVE_COMPLETE");
            this.cbRemoveComplete.NamedProperties.Put("ValidateMethod", "");
            this.cbRemoveComplete.NamedProperties.Put("XDataLength", "5");
            // 
            // gbRemove_Transaction_Options
            // 
            resources.ApplyResources(this.gbRemove_Transaction_Options, "gbRemove_Transaction_Options");
            this.gbRemove_Transaction_Options.Name = "gbRemove_Transaction_Options";
            this.gbRemove_Transaction_Options.TabStop = false;
            // 
            // labeldfsCharacterSet
            // 
            resources.ApplyResources(this.labeldfsCharacterSet, "labeldfsCharacterSet");
            this.labeldfsCharacterSet.Name = "labeldfsCharacterSet";
            // 
            // dfsCharacterSet
            // 
            this.dfsCharacterSet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCharacterSet, "dfsCharacterSet");
            this.dfsCharacterSet.Name = "dfsCharacterSet";
            this.dfsCharacterSet.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCharacterSet.NamedProperties.Put("FieldFlags", "294");
            this.dfsCharacterSet.NamedProperties.Put("LovReference", "");
            this.dfsCharacterSet.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCharacterSet.NamedProperties.Put("SqlColumn", "CHARACTER_SET");
            this.dfsCharacterSet.NamedProperties.Put("ValidateMethod", "");
            this.dfsCharacterSet.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCharacterSet_WindowActions);
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_External});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_External
            // 
            this.menuItem_External.Command = this.menuFrmMethods_menuExternal_File_Template_C_ontrol_;
            this.menuItem_External.Name = "menuItem_External";
            resources.ApplyResources(this.menuItem_External, "menuItem_External");
            this.menuItem_External.Text = "External File Template C&ontrol...";
            // 
            // frmExternalFileTemplateOut
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfsCharacterSet);
            this.Controls.Add(this.cbRemoveComplete);
            this.Controls.Add(this.dfnRemoveDays);
            this.Controls.Add(this.dfsApiToCall);
            this.Controls.Add(this.cbSystemDefined);
            this.Controls.Add(this.cbCreateHeader);
            this.Controls.Add(this.cbOverwriteFile);
            this.Controls.Add(this.dfsNumberOutFillValue);
            this.Controls.Add(this.dfsOutputFilePathServer);
            this.Controls.Add(this.dfsOutputFilePath);
            this.Controls.Add(this.cmbNameOption);
            this.Controls.Add(this.dfsFileName);
            this.Controls.Add(this.cmbFileDirection);
            this.Controls.Add(this.dfsFileTemplateId);
            this.Controls.Add(this.labeldfsCharacterSet);
            this.Controls.Add(this.labeldfnRemoveDays);
            this.Controls.Add(this.labeldfsApiToCall);
            this.Controls.Add(this.labeldfsNumberOutFillValue);
            this.Controls.Add(this.labeldfsOutputFilePathServer);
            this.Controls.Add(this.labeldfsOutputFilePath);
            this.Controls.Add(this.labelcmbNameOption);
            this.Controls.Add(this.labeldfsFileName);
            this.Controls.Add(this.gbRemove_Transaction_Options);
            this.Controls.Add(this.gbCreation_Options);
            this.Name = "frmExternalFileTemplateOut";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "OutExtFileTemplateDir");
            this.NamedProperties.Put("PackageName", "OUT_EXT_FILE_TEMPLATE_DIR_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "OUT_EXT_FILE_TEMPLATE_DIR");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmExternalFileTemplateOut_WindowActions);
            this.gbCreation_Options.ResumeLayout(false);
            this.menuFrmMethods.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuExternal_File_Template_C_ontrol_;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_External;
        protected cCheckBox cbRemoveEndSep;
	}
}
