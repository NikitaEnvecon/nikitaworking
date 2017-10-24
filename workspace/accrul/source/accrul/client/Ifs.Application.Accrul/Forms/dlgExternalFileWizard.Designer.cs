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
	
	public partial class dlgExternalFileWizard
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		// Step1
		protected cBackgroundText labeldfHeading;
		// Just because a data field is necessary to have a background text
		public cDataField dfHeading;
		// Bug 72340, Begin
		protected cBackgroundText labeldfHeadingVou;
		// Just because a data field is necessary to have a background text
		public cDataField dfHeadingVou;
		protected cBackgroundText labeldfHeadingCustInv;
		// Just because a data field is necessary to have a background text
		public cDataField dfHeadingCustInv;
		protected cBackgroundText labeldfHeadingSuppInv;
		// Just because a data field is necessary to have a background text
		public cDataField dfHeadingSuppInv;
		protected cBackgroundText labeldfHeadingCurrUpd;
		// Just because a data field is necessary to have a background text
		public cDataField dfHeadingCurrUpd;
		// Bug 92463 Begin
		protected cBackgroundText labeldfHeadingMandToPi;
		// Just because a data field is necessary to have a background text
		public cDataField dfHeadingMandToPi;
		// Bug 92463 End
		// Bug 72340, End
		// Bug 72340, Begin. Changed indentation of Top property.
		protected SalGroupBox gbProcess_Options;
		public cRadioButton rbOnline;
		public cRadioButton rbBatch;
		// Bug 72340, End
		// Step2
		protected SalGroupBox gbFile_Options;
		protected cBackgroundText labeldfsFileType;
		public cDataField dfsFileType;
		protected cBackgroundText labeldfsSetIdTest;
		// Bug 69856 Changed F1-properties to "Required"
		public cDataField dfsSetIdTest;
		protected cBackgroundText labeldfsFileTemplateId;
		public cDataField dfsFileTemplateId;
		public cCheckBox cbInput;
		public cCheckBox cbOutput;
		protected cBackgroundText labeldfsFileName;
		public cDataField dfsFileName;
		public cPushButton pbBrowse;
		// Step3
		protected cBackgroundText labeldfsFileType2;
		public cDataField dfsFileType2;
		public cDataField dfsFileTypeDescription;
		protected cBackgroundText labeldfsSetId2;
		public cDataField dfsSetId2;
		public cDataField dfsSetIdDescription;
        // Bug 73298 Begin - Changed the derived base class.
		// Bug 73298 End.
		protected cBackgroundText labeldfsHelpText;
		public cDataField dfsHelpText;
		public cDataFieldFin dfdLoadDate;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgExternalFileWizard));
            this.labeldfHeading = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfHeading = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfHeadingVou = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfHeadingVou = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfHeadingCustInv = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfHeadingCustInv = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfHeadingSuppInv = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfHeadingSuppInv = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfHeadingCurrUpd = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfHeadingCurrUpd = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfHeadingMandToPi = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfHeadingMandToPi = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbProcess_Options = new PPJ.Runtime.Windows.SalGroupBox();
            this.rbOnline = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.rbBatch = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.gbFile_Options = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfsFileType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSetIdTest = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSetIdTest = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsFileTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbInput = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbOutput = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfsFileName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbBrowse = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.labeldfsFileType2 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileType2 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsFileTypeDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSetId2 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSetId2 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsSetIdDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsHelpText = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsHelpText = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfdLoadDate = new Ifs.Application.Accrul.cDataFieldFin();
            this.step1 = new Ifs.Fnd.ApplicationForms.@__cWizardStep();
            this.step2 = new Ifs.Fnd.ApplicationForms.@__cWizardStep();
            this.step3 = new Ifs.Fnd.ApplicationForms.@__cWizardStep();
            this.step4 = new Ifs.Fnd.ApplicationForms.@__cWizardStep();
            this.tblExternalFileParam = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblExternalFileParam_colsFileType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileParam_colsParamId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileParam_colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileParam_colsValue = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblExternalFileParam_colsBrowsableField = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileParam_colsHelpText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileParam_colnParamNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileParam_colsInputableAtLoad = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileParam_colsMandatoryParam = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileParam_colsLovView = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExternalFileParam_colsEnumerateMethod = new Ifs.Fnd.ApplicationForms.cColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picWizard)).BeginInit();
            this.ToolBar.SuspendLayout();
            this.ClientArea.SuspendLayout();
            this.tblExternalFileParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbFinish
            // 
            resources.ApplyResources(this.pbFinish, "pbFinish");
            // 
            // pbNext
            // 
            resources.ApplyResources(this.pbNext, "pbNext");
            // 
            // pbBack
            // 
            resources.ApplyResources(this.pbBack, "pbBack");
            // 
            // pbCancel
            // 
            resources.ApplyResources(this.pbCancel, "pbCancel");
            // 
            // pbList
            // 
            resources.ApplyResources(this.pbList, "pbList");
            // 
            // picWizard
            // 
            resources.ApplyResources(this.picWizard, "picWizard");
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.dfdLoadDate);
            this.ClientArea.Controls.Add(this.dfsHelpText);
            this.ClientArea.Controls.Add(this.tblExternalFileParam);
            this.ClientArea.Controls.Add(this.dfsSetIdDescription);
            this.ClientArea.Controls.Add(this.dfsSetId2);
            this.ClientArea.Controls.Add(this.dfsFileTypeDescription);
            this.ClientArea.Controls.Add(this.dfsFileType2);
            this.ClientArea.Controls.Add(this.pbBrowse);
            this.ClientArea.Controls.Add(this.dfsFileName);
            this.ClientArea.Controls.Add(this.cbOutput);
            this.ClientArea.Controls.Add(this.cbInput);
            this.ClientArea.Controls.Add(this.dfsFileTemplateId);
            this.ClientArea.Controls.Add(this.dfsSetIdTest);
            this.ClientArea.Controls.Add(this.dfsFileType);
            this.ClientArea.Controls.Add(this.rbBatch);
            this.ClientArea.Controls.Add(this.rbOnline);
            this.ClientArea.Controls.Add(this.dfHeadingMandToPi);
            this.ClientArea.Controls.Add(this.dfHeadingCurrUpd);
            this.ClientArea.Controls.Add(this.dfHeadingSuppInv);
            this.ClientArea.Controls.Add(this.dfHeadingCustInv);
            this.ClientArea.Controls.Add(this.dfHeadingVou);
            this.ClientArea.Controls.Add(this.dfHeading);
            this.ClientArea.Controls.Add(this.labeldfsHelpText);
            this.ClientArea.Controls.Add(this.labeldfsSetId2);
            this.ClientArea.Controls.Add(this.labeldfsFileType2);
            this.ClientArea.Controls.Add(this.labeldfsFileName);
            this.ClientArea.Controls.Add(this.labeldfsFileTemplateId);
            this.ClientArea.Controls.Add(this.labeldfsSetIdTest);
            this.ClientArea.Controls.Add(this.labeldfsFileType);
            this.ClientArea.Controls.Add(this.labeldfHeadingMandToPi);
            this.ClientArea.Controls.Add(this.labeldfHeadingCurrUpd);
            this.ClientArea.Controls.Add(this.labeldfHeadingSuppInv);
            this.ClientArea.Controls.Add(this.labeldfHeadingCustInv);
            this.ClientArea.Controls.Add(this.labeldfHeadingVou);
            this.ClientArea.Controls.Add(this.labeldfHeading);
            this.ClientArea.Controls.Add(this.gbFile_Options);
            this.ClientArea.Controls.Add(this.gbProcess_Options);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            this.ClientArea.Controls.SetChildIndex(this.picWizard, 0);
            this.ClientArea.Controls.SetChildIndex(this.gbProcess_Options, 0);
            this.ClientArea.Controls.SetChildIndex(this.gbFile_Options, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfHeading, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfHeadingVou, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfHeadingCustInv, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfHeadingSuppInv, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfHeadingCurrUpd, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfHeadingMandToPi, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsFileType, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsSetIdTest, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsFileTemplateId, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsFileName, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsFileType2, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsSetId2, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsHelpText, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfHeading, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfHeadingVou, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfHeadingCustInv, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfHeadingSuppInv, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfHeadingCurrUpd, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfHeadingMandToPi, 0);
            this.ClientArea.Controls.SetChildIndex(this.rbOnline, 0);
            this.ClientArea.Controls.SetChildIndex(this.rbBatch, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsFileType, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsSetIdTest, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsFileTemplateId, 0);
            this.ClientArea.Controls.SetChildIndex(this.cbInput, 0);
            this.ClientArea.Controls.SetChildIndex(this.cbOutput, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsFileName, 0);
            this.ClientArea.Controls.SetChildIndex(this.pbBrowse, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsFileType2, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsFileTypeDescription, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsSetId2, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsSetIdDescription, 0);
            this.ClientArea.Controls.SetChildIndex(this.tblExternalFileParam, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsHelpText, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfdLoadDate, 0);
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbBrowse);
            this.commandManager.ImageList = null;
            // 
            // labeldfHeading
            // 
            resources.ApplyResources(this.labeldfHeading, "labeldfHeading");
            this.labeldfHeading.Name = "labeldfHeading";
            // 
            // dfHeading
            // 
            resources.ApplyResources(this.dfHeading, "dfHeading");
            this.dfHeading.Name = "dfHeading";
            // 
            // labeldfHeadingVou
            // 
            resources.ApplyResources(this.labeldfHeadingVou, "labeldfHeadingVou");
            this.labeldfHeadingVou.Name = "labeldfHeadingVou";
            // 
            // dfHeadingVou
            // 
            resources.ApplyResources(this.dfHeadingVou, "dfHeadingVou");
            this.dfHeadingVou.Name = "dfHeadingVou";
            // 
            // labeldfHeadingCustInv
            // 
            resources.ApplyResources(this.labeldfHeadingCustInv, "labeldfHeadingCustInv");
            this.labeldfHeadingCustInv.Name = "labeldfHeadingCustInv";
            // 
            // dfHeadingCustInv
            // 
            resources.ApplyResources(this.dfHeadingCustInv, "dfHeadingCustInv");
            this.dfHeadingCustInv.Name = "dfHeadingCustInv";
            // 
            // labeldfHeadingSuppInv
            // 
            resources.ApplyResources(this.labeldfHeadingSuppInv, "labeldfHeadingSuppInv");
            this.labeldfHeadingSuppInv.Name = "labeldfHeadingSuppInv";
            // 
            // dfHeadingSuppInv
            // 
            resources.ApplyResources(this.dfHeadingSuppInv, "dfHeadingSuppInv");
            this.dfHeadingSuppInv.Name = "dfHeadingSuppInv";
            // 
            // labeldfHeadingCurrUpd
            // 
            resources.ApplyResources(this.labeldfHeadingCurrUpd, "labeldfHeadingCurrUpd");
            this.labeldfHeadingCurrUpd.Name = "labeldfHeadingCurrUpd";
            // 
            // dfHeadingCurrUpd
            // 
            resources.ApplyResources(this.dfHeadingCurrUpd, "dfHeadingCurrUpd");
            this.dfHeadingCurrUpd.Name = "dfHeadingCurrUpd";
            // 
            // labeldfHeadingMandToPi
            // 
            resources.ApplyResources(this.labeldfHeadingMandToPi, "labeldfHeadingMandToPi");
            this.labeldfHeadingMandToPi.Name = "labeldfHeadingMandToPi";
            // 
            // dfHeadingMandToPi
            // 
            resources.ApplyResources(this.dfHeadingMandToPi, "dfHeadingMandToPi");
            this.dfHeadingMandToPi.Name = "dfHeadingMandToPi";
            // 
            // gbProcess_Options
            // 
            resources.ApplyResources(this.gbProcess_Options, "gbProcess_Options");
            this.gbProcess_Options.Name = "gbProcess_Options";
            this.gbProcess_Options.TabStop = false;
            // 
            // rbOnline
            // 
            resources.ApplyResources(this.rbOnline, "rbOnline");
            this.rbOnline.Name = "rbOnline";
            // 
            // rbBatch
            // 
            resources.ApplyResources(this.rbBatch, "rbBatch");
            this.rbBatch.Name = "rbBatch";
            // 
            // gbFile_Options
            // 
            resources.ApplyResources(this.gbFile_Options, "gbFile_Options");
            this.gbFile_Options.Name = "gbFile_Options";
            this.gbFile_Options.TabStop = false;
            // 
            // labeldfsFileType
            // 
            resources.ApplyResources(this.labeldfsFileType, "labeldfsFileType");
            this.labeldfsFileType.Name = "labeldfsFileType";
            // 
            // dfsFileType
            // 
            resources.ApplyResources(this.dfsFileType, "dfsFileType");
            this.dfsFileType.Name = "dfsFileType";
            this.dfsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileType.NamedProperties.Put("FieldFlags", "294");
            this.dfsFileType.NamedProperties.Put("LovReference", "EXT_FILE_TYPE_USABLE");
            this.dfsFileType.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.dfsFileType.NamedProperties.Put("ValidateMethod", "");
            this.dfsFileType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsFileType_WindowActions);
            // 
            // labeldfsSetIdTest
            // 
            resources.ApplyResources(this.labeldfsSetIdTest, "labeldfsSetIdTest");
            this.labeldfsSetIdTest.Name = "labeldfsSetIdTest";
            // 
            // dfsSetIdTest
            // 
            resources.ApplyResources(this.dfsSetIdTest, "dfsSetIdTest");
            this.dfsSetIdTest.Name = "dfsSetIdTest";
            this.dfsSetIdTest.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSetIdTest.NamedProperties.Put("FieldFlags", "263");
            this.dfsSetIdTest.NamedProperties.Put("LovReference", "EXT_TYPE_PARAM_SET(FILE_TYPE)");
            this.dfsSetIdTest.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsSetIdTest.NamedProperties.Put("SqlColumn", "SET_ID");
            this.dfsSetIdTest.NamedProperties.Put("ValidateMethod", "");
            this.dfsSetIdTest.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsSetIdTest_WindowActions);
            // 
            // labeldfsFileTemplateId
            // 
            resources.ApplyResources(this.labeldfsFileTemplateId, "labeldfsFileTemplateId");
            this.labeldfsFileTemplateId.Name = "labeldfsFileTemplateId";
            // 
            // dfsFileTemplateId
            // 
            resources.ApplyResources(this.dfsFileTemplateId, "dfsFileTemplateId");
            this.dfsFileTemplateId.Name = "dfsFileTemplateId";
            this.dfsFileTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileTemplateId.NamedProperties.Put("FieldFlags", "294");
            this.dfsFileTemplateId.NamedProperties.Put("LovReference", "EXT_FILE_TEMPLATE_LOV2(FILE_TYPE)");
            this.dfsFileTemplateId.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.dfsFileTemplateId.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE_ID");
            this.dfsFileTemplateId.NamedProperties.Put("ValidateMethod", "");
            this.dfsFileTemplateId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsFileTemplateId_WindowActions);
            // 
            // cbInput
            // 
            resources.ApplyResources(this.cbInput, "cbInput");
            this.cbInput.Name = "cbInput";
            this.cbInput.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbInput_WindowActions);
            // 
            // cbOutput
            // 
            resources.ApplyResources(this.cbOutput, "cbOutput");
            this.cbOutput.Name = "cbOutput";
            this.cbOutput.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbOutput_WindowActions);
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
            this.dfsFileName.NamedProperties.Put("FieldFlags", "260");
            this.dfsFileName.NamedProperties.Put("LovReference", "");
            this.dfsFileName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileName.NamedProperties.Put("SqlColumn", "");
            this.dfsFileName.NamedProperties.Put("ValidateMethod", "");
            this.dfsFileName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsFileName_WindowActions);
            // 
            // pbBrowse
            // 
            resources.ApplyResources(this.pbBrowse, "pbBrowse");
            this.pbBrowse.Name = "pbBrowse";
            this.pbBrowse.NamedProperties.Put("MethodId", "18385");
            this.pbBrowse.NamedProperties.Put("MethodParameter", "Browse");
            this.pbBrowse.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // labeldfsFileType2
            // 
            resources.ApplyResources(this.labeldfsFileType2, "labeldfsFileType2");
            this.labeldfsFileType2.Name = "labeldfsFileType2";
            // 
            // dfsFileType2
            // 
            this.dfsFileType2.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsFileType2, "dfsFileType2");
            this.dfsFileType2.Name = "dfsFileType2";
            this.dfsFileType2.ReadOnly = true;
            // 
            // dfsFileTypeDescription
            // 
            this.dfsFileTypeDescription.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsFileTypeDescription, "dfsFileTypeDescription");
            this.dfsFileTypeDescription.Name = "dfsFileTypeDescription";
            this.dfsFileTypeDescription.NamedProperties.Put("ResizeableChildObject", "LLCL");
            this.dfsFileTypeDescription.ReadOnly = true;
            // 
            // labeldfsSetId2
            // 
            resources.ApplyResources(this.labeldfsSetId2, "labeldfsSetId2");
            this.labeldfsSetId2.Name = "labeldfsSetId2";
            this.labeldfsSetId2.Click += new System.EventHandler(this.labeldfsSetId2_Click);
            // 
            // dfsSetId2
            // 
            this.dfsSetId2.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsSetId2, "dfsSetId2");
            this.dfsSetId2.Name = "dfsSetId2";
            this.dfsSetId2.ReadOnly = true;
            // 
            // dfsSetIdDescription
            // 
            this.dfsSetIdDescription.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsSetIdDescription, "dfsSetIdDescription");
            this.dfsSetIdDescription.Name = "dfsSetIdDescription";
            this.dfsSetIdDescription.NamedProperties.Put("ResizeableChildObject", "LLFL");
            this.dfsSetIdDescription.ReadOnly = true;
            // 
            // labeldfsHelpText
            // 
            resources.ApplyResources(this.labeldfsHelpText, "labeldfsHelpText");
            this.labeldfsHelpText.Name = "labeldfsHelpText";
            // 
            // dfsHelpText
            // 
            this.dfsHelpText.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsHelpText, "dfsHelpText");
            this.dfsHelpText.Name = "dfsHelpText";
            this.dfsHelpText.NamedProperties.Put("ResizeableChildObject", "LLFL");
            this.dfsHelpText.ReadOnly = true;
            // 
            // dfdLoadDate
            // 
            this.dfdLoadDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdLoadDate.Name = "dfdLoadDate";
            this.dfdLoadDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdLoadDate.NamedProperties.Put("LovReference", "");
            this.dfdLoadDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdLoadDate.NamedProperties.Put("SqlColumn", "");
            this.dfdLoadDate.NamedProperties.Put("ValidateMethod", "");
            resources.ApplyResources(this.dfdLoadDate, "dfdLoadDate");
            // 
            // step1
            // 
            this.step1.Controls = new string[] {
        "gbProcess_Options",
        "rbBatch",
        "rbOnline"};
            this.step1.StepDescription = "step1";
            resources.ApplyResources(this.step1, "step1");
            this.step1.UseInternalControls = true;
            // 
            // step2
            // 
            this.step2.Controls = new string[] {
        "cbInput",
        "cbOutput",
        "dfsFileName",
        "dfsFileTemplateId",
        "dfsFileType",
        "dfsSetIdTest",
        "gbFile_Options",
        "pbBrowse"};
            this.step2.StepDescription = "step2";
            resources.ApplyResources(this.step2, "step2");
            this.step2.UseInternalControls = true;
            // 
            // step3
            // 
            this.step3.Controls = new string[] {
        "dfsFileType2",
        "dfsFileTypeDescription",
        "dfsHelpText",
        "dfsSetId2",
        "dfsSetIdDescription",
        "tblExternalFileParam"};
            this.step3.StepDescription = "step3";
            resources.ApplyResources(this.step3, "step3");
            this.step3.UseInternalControls = true;
            // 
            // step4
            // 
            this.step4.Controls = new string[] {
        "dfsFileType2",
        "dfsFileTypeDescription",
        "dfsHelpText",
        "dfsSetId2",
        "dfsSetIdDescription",
        "tblExternalFileParam"};
            this.step4.StepDescription = "step4";
            resources.ApplyResources(this.step4, "step4");
            this.step4.UseInternalControls = true;
            // 
            // tblExternalFileParam
            // 
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsFileType);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsParamId);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsDescription);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsValue);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsBrowsableField);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsHelpText);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colnParamNo);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsInputableAtLoad);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsMandatoryParam);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsLovView);
            this.tblExternalFileParam.Controls.Add(this.tblExternalFileParam_colsEnumerateMethod);
            resources.ApplyResources(this.tblExternalFileParam, "tblExternalFileParam");
            this.tblExternalFileParam.Name = "tblExternalFileParam";
            this.tblExternalFileParam.NamedProperties.Put("DefaultOrderBy", "PARAM_NO");
            this.tblExternalFileParam.NamedProperties.Put("DefaultWhere", "");
            this.tblExternalFileParam.NamedProperties.Put("LogicalUnit", "ExtFileTypeParam");
            this.tblExternalFileParam.NamedProperties.Put("PackageName", "EXT_FILE_TYPE_PARAM_API");
            this.tblExternalFileParam.NamedProperties.Put("ResizeableChildObject", "LLFL");
            this.tblExternalFileParam.NamedProperties.Put("SourceFlags", "129");
            this.tblExternalFileParam.NamedProperties.Put("ViewName", "EXT_FILE_TYPE_PARAM_DIALOG");
            this.tblExternalFileParam.NamedProperties.Put("Warnings", "FALSE");
            this.tblExternalFileParam.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExternalFileParam_WindowActions);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsEnumerateMethod, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsLovView, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsMandatoryParam, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsInputableAtLoad, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colnParamNo, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsHelpText, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsBrowsableField, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsValue, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsDescription, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsParamId, 0);
            this.tblExternalFileParam.Controls.SetChildIndex(this.tblExternalFileParam_colsFileType, 0);
            // 
            // tblExternalFileParam_colsFileType
            // 
            resources.ApplyResources(this.tblExternalFileParam_colsFileType, "tblExternalFileParam_colsFileType");
            this.tblExternalFileParam_colsFileType.MaxLength = 30;
            this.tblExternalFileParam_colsFileType.Name = "tblExternalFileParam_colsFileType";
            this.tblExternalFileParam_colsFileType.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsFileType.NamedProperties.Put("FieldFlags", "97");
            this.tblExternalFileParam_colsFileType.NamedProperties.Put("LovReference", "EXT_FILE_MODULE_NAME");
            this.tblExternalFileParam_colsFileType.NamedProperties.Put("SqlColumn", "FILE_TYPE");
            this.tblExternalFileParam_colsFileType.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colsFileType.Position = 3;
            // 
            // tblExternalFileParam_colsParamId
            // 
            resources.ApplyResources(this.tblExternalFileParam_colsParamId, "tblExternalFileParam_colsParamId");
            this.tblExternalFileParam_colsParamId.MaxLength = 30;
            this.tblExternalFileParam_colsParamId.Name = "tblExternalFileParam_colsParamId";
            this.tblExternalFileParam_colsParamId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsParamId.NamedProperties.Put("FieldFlags", "289");
            this.tblExternalFileParam_colsParamId.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colsParamId.NamedProperties.Put("SqlColumn", "PARAM_ID");
            this.tblExternalFileParam_colsParamId.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colsParamId.Position = 4;
            // 
            // tblExternalFileParam_colsDescription
            // 
            resources.ApplyResources(this.tblExternalFileParam_colsDescription, "tblExternalFileParam_colsDescription");
            this.tblExternalFileParam_colsDescription.MaxLength = 200;
            this.tblExternalFileParam_colsDescription.Name = "tblExternalFileParam_colsDescription";
            this.tblExternalFileParam_colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsDescription.NamedProperties.Put("FieldFlags", "289");
            this.tblExternalFileParam_colsDescription.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.tblExternalFileParam_colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colsDescription.Position = 5;
            // 
            // tblExternalFileParam_colsValue
            // 
            this.tblExternalFileParam_colsValue.Name = "tblExternalFileParam_colsValue";
            this.tblExternalFileParam_colsValue.Position = 6;
            resources.ApplyResources(this.tblExternalFileParam_colsValue, "tblExternalFileParam_colsValue");
            this.tblExternalFileParam_colsValue.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExternalFileParam__colsValue_WindowActions);
            // 
            // tblExternalFileParam_colsBrowsableField
            // 
            resources.ApplyResources(this.tblExternalFileParam_colsBrowsableField, "tblExternalFileParam_colsBrowsableField");
            this.tblExternalFileParam_colsBrowsableField.MaxLength = 5;
            this.tblExternalFileParam_colsBrowsableField.Name = "tblExternalFileParam_colsBrowsableField";
            this.tblExternalFileParam_colsBrowsableField.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsBrowsableField.NamedProperties.Put("FieldFlags", "288");
            this.tblExternalFileParam_colsBrowsableField.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colsBrowsableField.NamedProperties.Put("SqlColumn", "BROWSABLE_FIELD");
            this.tblExternalFileParam_colsBrowsableField.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colsBrowsableField.Position = 7;
            // 
            // tblExternalFileParam_colsHelpText
            // 
            resources.ApplyResources(this.tblExternalFileParam_colsHelpText, "tblExternalFileParam_colsHelpText");
            this.tblExternalFileParam_colsHelpText.MaxLength = 200;
            this.tblExternalFileParam_colsHelpText.Name = "tblExternalFileParam_colsHelpText";
            this.tblExternalFileParam_colsHelpText.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsHelpText.NamedProperties.Put("FieldFlags", "288");
            this.tblExternalFileParam_colsHelpText.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colsHelpText.NamedProperties.Put("SqlColumn", "HELP_TEXT");
            this.tblExternalFileParam_colsHelpText.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colsHelpText.Position = 8;
            // 
            // tblExternalFileParam_colnParamNo
            // 
            this.tblExternalFileParam_colnParamNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblExternalFileParam_colnParamNo, "tblExternalFileParam_colnParamNo");
            this.tblExternalFileParam_colnParamNo.Name = "tblExternalFileParam_colnParamNo";
            this.tblExternalFileParam_colnParamNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colnParamNo.NamedProperties.Put("FieldFlags", "288");
            this.tblExternalFileParam_colnParamNo.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colnParamNo.NamedProperties.Put("SqlColumn", "PARAM_NO");
            this.tblExternalFileParam_colnParamNo.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colnParamNo.Position = 9;
            // 
            // tblExternalFileParam_colsInputableAtLoad
            // 
            resources.ApplyResources(this.tblExternalFileParam_colsInputableAtLoad, "tblExternalFileParam_colsInputableAtLoad");
            this.tblExternalFileParam_colsInputableAtLoad.MaxLength = 5;
            this.tblExternalFileParam_colsInputableAtLoad.Name = "tblExternalFileParam_colsInputableAtLoad";
            this.tblExternalFileParam_colsInputableAtLoad.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsInputableAtLoad.NamedProperties.Put("FieldFlags", "295");
            this.tblExternalFileParam_colsInputableAtLoad.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colsInputableAtLoad.NamedProperties.Put("SqlColumn", "INPUTABLE_AT_LOAD");
            this.tblExternalFileParam_colsInputableAtLoad.Position = 10;
            // 
            // tblExternalFileParam_colsMandatoryParam
            // 
            resources.ApplyResources(this.tblExternalFileParam_colsMandatoryParam, "tblExternalFileParam_colsMandatoryParam");
            this.tblExternalFileParam_colsMandatoryParam.MaxLength = 5;
            this.tblExternalFileParam_colsMandatoryParam.Name = "tblExternalFileParam_colsMandatoryParam";
            this.tblExternalFileParam_colsMandatoryParam.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsMandatoryParam.NamedProperties.Put("FieldFlags", "294");
            this.tblExternalFileParam_colsMandatoryParam.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colsMandatoryParam.NamedProperties.Put("SqlColumn", "MANDATORY_PARAM");
            this.tblExternalFileParam_colsMandatoryParam.Position = 11;
            // 
            // tblExternalFileParam_colsLovView
            // 
            this.tblExternalFileParam_colsLovView.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblExternalFileParam_colsLovView, "tblExternalFileParam_colsLovView");
            this.tblExternalFileParam_colsLovView.MaxLength = 200;
            this.tblExternalFileParam_colsLovView.Name = "tblExternalFileParam_colsLovView";
            this.tblExternalFileParam_colsLovView.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsLovView.NamedProperties.Put("FieldFlags", "294");
            this.tblExternalFileParam_colsLovView.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colsLovView.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExternalFileParam_colsLovView.NamedProperties.Put("SqlColumn", "LOV_VIEW");
            this.tblExternalFileParam_colsLovView.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colsLovView.Position = 12;
            // 
            // tblExternalFileParam_colsEnumerateMethod
            // 
            resources.ApplyResources(this.tblExternalFileParam_colsEnumerateMethod, "tblExternalFileParam_colsEnumerateMethod");
            this.tblExternalFileParam_colsEnumerateMethod.MaxLength = 200;
            this.tblExternalFileParam_colsEnumerateMethod.Name = "tblExternalFileParam_colsEnumerateMethod";
            this.tblExternalFileParam_colsEnumerateMethod.NamedProperties.Put("EnumerateMethod", "");
            this.tblExternalFileParam_colsEnumerateMethod.NamedProperties.Put("FieldFlags", "290");
            this.tblExternalFileParam_colsEnumerateMethod.NamedProperties.Put("LovReference", "");
            this.tblExternalFileParam_colsEnumerateMethod.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExternalFileParam_colsEnumerateMethod.NamedProperties.Put("SqlColumn", "ENUMERATE_METHOD");
            this.tblExternalFileParam_colsEnumerateMethod.NamedProperties.Put("ValidateMethod", "");
            this.tblExternalFileParam_colsEnumerateMethod.Position = 13;
            // 
            // dlgExternalFileWizard
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgExternalFileWizard";
            this.NamedProperties.Put("Module", "%");
            this.NamedProperties.Put("SourceFlags", "449");
            this.ShowIcon = false;
            this.ShowList = true;
            this.ShowPicture = true;
            this.WizardSteps.Add(this.step1);
            this.WizardSteps.Add(this.step2);
            this.WizardSteps.Add(this.step3);
            this.WizardSteps.Add(this.step4);
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgExternalFileWizard_WindowActions);
            ((System.ComponentModel.ISupportInitialize)(this.picWizard)).EndInit();
            this.ToolBar.ResumeLayout(false);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
            this.tblExternalFileParam.ResumeLayout(false);
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

        protected __cWizardStep step1;
        protected __cWizardStep step2;
        protected __cWizardStep step3;
        protected __cWizardStep step4;
        public cChildTableFinBase tblExternalFileParam;
        protected cColumn tblExternalFileParam_colsFileType;
        protected cColumn tblExternalFileParam_colsParamId;
        protected cColumn tblExternalFileParam_colsDescription;
        protected cLookupColumn tblExternalFileParam_colsValue;
        protected cColumn tblExternalFileParam_colsBrowsableField;
        protected cColumn tblExternalFileParam_colsHelpText;
        protected cColumn tblExternalFileParam_colnParamNo;
        protected cColumn tblExternalFileParam_colsInputableAtLoad;
        protected cColumn tblExternalFileParam_colsMandatoryParam;
        protected cColumn tblExternalFileParam_colsLovView;
        protected cColumn tblExternalFileParam_colsEnumerateMethod;
	}
}
