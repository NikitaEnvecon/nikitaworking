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
	
	public partial class frmExternalFileTransactions
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labelcmdLoadFileId;
		public cRecListDataField cmdLoadFileId;
		protected cBackgroundText labeldfdLoadDate;
		public cDataField dfdLoadDate;
		public cDataField dfsCompany;
		protected cBackgroundText labeldfsFileType;
		public cDataField dfsFileType;
		protected cBackgroundText labeldfFileTypeName;
		public cDataField dfFileTypeName;
		protected cBackgroundText labeldfsSetIdTest;
		// Bug 69856 Start (Changed from dfsSetId to dfsSetIdTest)
		// Bug 69856 Start
		public cDataField dfsSetIdTest;
		// Bug 69856 End
		protected cBackgroundText labeldfSetIdName;
		// Bug 69856 (F1 Properties Changed from dfsSetId to dfsSetIdTest)
		public cDataField dfSetIdName;
		protected cBackgroundText labeldfsFileTemplateId;
		public cDataField dfsFileTemplateId;
		protected cBackgroundText labeldfFileTemplateIdName;
		public cDataField dfFileTemplateIdName;
		protected cBackgroundText labelcmbFileDirection;
		public cComboBox cmbFileDirection;
		public cDataField dfsMultiDirection;
		public SalPushbutton pbBrowser;
		protected cBackgroundText labeldfFileName;
		public cDataField dfFileName;
		protected cBackgroundText labeldfsUserId;
		public cDataField dfsUserId;
		protected cBackgroundText labeldfsState;
		public cDataField dfsState;
		// Non visible columns start
		public cDataField dfsStateDb;
		public cDataField dfsApiToCall;
		public cDataField dfsParameterString;
		public cDataField dfsFileDirectionDb;
		public cDataField dfsViewName;
		public cDataField dfsFormName;
		public cDataField dfsTargetDefaultMethod;
		// Non visible columns end
        // Bug 73298 Begin - Changed the derived base class.
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExternalFileTransactions));
            this.menuFrmMethods_menu_Load_Parameters___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_External_File_Log___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Input_File = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Input_File_menu_Load_External_Input_File = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Input_File_menu_Unpack_External_Input_File = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Input_File_menuCall__Input_Package_Method = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Input_File_menuComplete_Input__Flow = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Output_File = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Output_File_menuCall__Output_Package_Method = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Output_File_menu_Pack_External_Output_File = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Output_File_menuCreate_External__Output_File = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Output_File_menu_Complete_Output_Flow = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_External_File_Template___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menuR_emove_Transactions = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labelcmdLoadFileId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmdLoadFileId = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfdLoadDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdLoadDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsFileType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfFileTypeName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFileTypeName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSetIdTest = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSetIdTest = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfSetIdName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfSetIdName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsFileTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFileTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfFileTemplateIdName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFileTemplateIdName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbFileDirection = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbFileDirection = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.dfsMultiDirection = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbBrowser = new PPJ.Runtime.Windows.SalPushbutton();
            this.labeldfFileName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFileName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsUserId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsUserId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsState = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsState = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsStateDb = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsApiToCall = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsParameterString = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsFileDirectionDb = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsViewName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsFormName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsTargetDefaultMethod = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Load = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__External = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.popupMenu__Input = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Load_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Unpack = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Call = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Complete = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.popupMenu__Output = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Call_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Pack = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Create = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Complete = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__External_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Remove = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblExtFileTransColumn = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblExtFileTransColumn_colnRowNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColumn_colnLoadFileId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColumn_colsRecordTypeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTransColumn_colsC0 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC1 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC2 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC3 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC4 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC5 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC6 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC7 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC8 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC9 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC10 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC11 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC12 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC13 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC14 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC15 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC16 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC17 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC18 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC19 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC20 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC21 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC22 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC23 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC24 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC25 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC26 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC27 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC28 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC29 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC30 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC31 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC32 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC33 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC34 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC35 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC36 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC37 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC38 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC39 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC40 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC41 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC42 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC43 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC44 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC45 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC46 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC47 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC48 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC49 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC50 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC51 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC52 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC53 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC54 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC55 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC56 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC57 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC58 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC59 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC60 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC61 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC62 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC63 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC64 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC65 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC66 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC67 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC68 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC69 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC70 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC71 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC72 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC73 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC74 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC75 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC76 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC77 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC78 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC79 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC80 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC81 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC82 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC83 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC84 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC85 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC86 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC87 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC88 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC89 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC90 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC91 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC92 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC93 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC94 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC95 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC96 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC97 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC98 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC99 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC100 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC101 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC102 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC103 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC104 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC105 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC106 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC107 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC108 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC109 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC110 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC111 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC112 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC113 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC114 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC115 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC116 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC117 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC118 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC119 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC120 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC121 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC122 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC123 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC124 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC125 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC126 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC127 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC128 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC129 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC130 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC131 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC132 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC133 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC134 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC135 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC136 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC137 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC138 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC139 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC140 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC141 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC142 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC143 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC144 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC145 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC146 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC147 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC148 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC149 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC150 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC151 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC152 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC153 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC154 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC155 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC156 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC157 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC158 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC159 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC160 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC161 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC162 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC163 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC164 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC165 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC166 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC167 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC168 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC169 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC170 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC171 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC172 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC173 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC174 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC175 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC176 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC177 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC178 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC179 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC180 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC181 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC182 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC183 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC184 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC185 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC186 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC187 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC188 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC189 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC190 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC191 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC192 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC193 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC194 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC195 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC196 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC197 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC198 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colsC199 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN0 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN1 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN2 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN3 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN4 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN5 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN6 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN7 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN8 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN9 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN10 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN11 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN12 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN13 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN14 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN15 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN16 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN17 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN18 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN19 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN20 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN21 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN22 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN23 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN24 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN25 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN26 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN27 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN28 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN29 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN30 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN31 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN32 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN33 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN34 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN35 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN36 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN37 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN38 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN39 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN40 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN41 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN42 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN43 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN44 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN45 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN46 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN47 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN48 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN49 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN50 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN51 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN52 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN53 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN54 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN55 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN56 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN57 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN58 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN59 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN60 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN61 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN62 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN63 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN64 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN65 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN66 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN67 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN68 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN69 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN70 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN71 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN72 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN73 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN74 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN75 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN76 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN77 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN78 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN79 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN80 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN81 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN82 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN83 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN84 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN85 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN86 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN87 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN88 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN89 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN90 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN91 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN92 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN93 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN94 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN95 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN96 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN97 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN98 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_colnN99 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD1 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD2 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD3 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD4 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD5 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD6 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD7 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD8 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD9 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD10 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD11 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD12 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD13 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD14 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD15 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD16 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD17 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD18 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD19 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTransColumn_coldD20 = new Ifs.Application.Accrul.cColumnExtFileLoad();
            this.tblExtFileTrans = new Ifs.Application.Accrul.cChildTableFinBase();
            this.tblExtFileTrans_colnLoadFileId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTrans_colnRowNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTrans_colFileLine = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTrans_colsRowState = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblExtFileTrans_colnRecordSetNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTrans_colsRecordTypeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTrans_colErrorText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblExtFileTrans_colsControlId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuFrmMethods.SuspendLayout();
            this.tblExtFileTransColumn.SuspendLayout();
            this.tblExtFileTrans.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Load_Parameters___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_External_File_Log___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Input_File);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Input_File_menu_Load_External_Input_File);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Input_File_menu_Unpack_External_Input_File);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Input_File_menuCall__Input_Package_Method);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Input_File_menuComplete_Input__Flow);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Output_File);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Output_File_menuCall__Output_Package_Method);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Output_File_menu_Pack_External_Output_File);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Output_File_menuCreate_External__Output_File);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Output_File_menu_Complete_Output_Flow);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_External_File_Template___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menuR_emove_Transactions);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ImageList = null;
            // 
            // menuFrmMethods_menu_Load_Parameters___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Load_Parameters___, "menuFrmMethods_menu_Load_Parameters___");
            this.menuFrmMethods_menu_Load_Parameters___.Name = "menuFrmMethods_menu_Load_Parameters___";
            this.menuFrmMethods_menu_Load_Parameters___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Load_Execute);
            this.menuFrmMethods_menu_Load_Parameters___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Load_Inquire);
            // 
            // menuFrmMethods_menu_External_File_Log___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_External_File_Log___, "menuFrmMethods_menu_External_File_Log___");
            this.menuFrmMethods_menu_External_File_Log___.Name = "menuFrmMethods_menu_External_File_Log___";
            this.menuFrmMethods_menu_External_File_Log___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__External_Execute);
            this.menuFrmMethods_menu_External_File_Log___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__External_Inquire);
            // 
            // menuFrmMethods_menu_Input_File
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Input_File, "menuFrmMethods_menu_Input_File");
            this.menuFrmMethods_menu_Input_File.Name = "menuFrmMethods_menu_Input_File";
            this.menuFrmMethods_menu_Input_File.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.popupMenu__Input_Inquire);
            // 
            // menuFrmMethods_menu_Input_File_menu_Load_External_Input_File
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Input_File_menu_Load_External_Input_File, "menuFrmMethods_menu_Input_File_menu_Load_External_Input_File");
            this.menuFrmMethods_menu_Input_File_menu_Load_External_Input_File.Name = "menuFrmMethods_menu_Input_File_menu_Load_External_Input_File";
            this.menuFrmMethods_menu_Input_File_menu_Load_External_Input_File.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Load_1_Execute);
            this.menuFrmMethods_menu_Input_File_menu_Load_External_Input_File.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Load_1_Inquire);
            // 
            // menuFrmMethods_menu_Input_File_menu_Unpack_External_Input_File
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Input_File_menu_Unpack_External_Input_File, "menuFrmMethods_menu_Input_File_menu_Unpack_External_Input_File");
            this.menuFrmMethods_menu_Input_File_menu_Unpack_External_Input_File.Name = "menuFrmMethods_menu_Input_File_menu_Unpack_External_Input_File";
            this.menuFrmMethods_menu_Input_File_menu_Unpack_External_Input_File.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Unpack_Execute);
            this.menuFrmMethods_menu_Input_File_menu_Unpack_External_Input_File.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Unpack_Inquire);
            // 
            // menuFrmMethods_menu_Input_File_menuCall__Input_Package_Method
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Input_File_menuCall__Input_Package_Method, "menuFrmMethods_menu_Input_File_menuCall__Input_Package_Method");
            this.menuFrmMethods_menu_Input_File_menuCall__Input_Package_Method.Name = "menuFrmMethods_menu_Input_File_menuCall__Input_Package_Method";
            this.menuFrmMethods_menu_Input_File_menuCall__Input_Package_Method.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Call_Execute);
            this.menuFrmMethods_menu_Input_File_menuCall__Input_Package_Method.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Call_Inquire);
            // 
            // menuFrmMethods_menu_Input_File_menuComplete_Input__Flow
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Input_File_menuComplete_Input__Flow, "menuFrmMethods_menu_Input_File_menuComplete_Input__Flow");
            this.menuFrmMethods_menu_Input_File_menuComplete_Input__Flow.Name = "menuFrmMethods_menu_Input_File_menuComplete_Input__Flow";
            this.menuFrmMethods_menu_Input_File_menuComplete_Input__Flow.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Complete_Execute);
            this.menuFrmMethods_menu_Input_File_menuComplete_Input__Flow.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Complete_Inquire);
            // 
            // menuFrmMethods_menu_Output_File
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Output_File, "menuFrmMethods_menu_Output_File");
            this.menuFrmMethods_menu_Output_File.Name = "menuFrmMethods_menu_Output_File";
            this.menuFrmMethods_menu_Output_File.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.popupMenu__Output_Inquire);
            // 
            // menuFrmMethods_menu_Output_File_menuCall__Output_Package_Method
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Output_File_menuCall__Output_Package_Method, "menuFrmMethods_menu_Output_File_menuCall__Output_Package_Method");
            this.menuFrmMethods_menu_Output_File_menuCall__Output_Package_Method.Name = "menuFrmMethods_menu_Output_File_menuCall__Output_Package_Method";
            this.menuFrmMethods_menu_Output_File_menuCall__Output_Package_Method.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Call_1_Execute);
            this.menuFrmMethods_menu_Output_File_menuCall__Output_Package_Method.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Call_1_Inquire);
            // 
            // menuFrmMethods_menu_Output_File_menu_Pack_External_Output_File
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Output_File_menu_Pack_External_Output_File, "menuFrmMethods_menu_Output_File_menu_Pack_External_Output_File");
            this.menuFrmMethods_menu_Output_File_menu_Pack_External_Output_File.Name = "menuFrmMethods_menu_Output_File_menu_Pack_External_Output_File";
            this.menuFrmMethods_menu_Output_File_menu_Pack_External_Output_File.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Pack_Execute);
            this.menuFrmMethods_menu_Output_File_menu_Pack_External_Output_File.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Pack_Inquire);
            // 
            // menuFrmMethods_menu_Output_File_menuCreate_External__Output_File
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Output_File_menuCreate_External__Output_File, "menuFrmMethods_menu_Output_File_menuCreate_External__Output_File");
            this.menuFrmMethods_menu_Output_File_menuCreate_External__Output_File.Name = "menuFrmMethods_menu_Output_File_menuCreate_External__Output_File";
            this.menuFrmMethods_menu_Output_File_menuCreate_External__Output_File.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Create_Execute);
            this.menuFrmMethods_menu_Output_File_menuCreate_External__Output_File.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Create_Inquire);
            // 
            // menuFrmMethods_menu_Output_File_menu_Complete_Output_Flow
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Output_File_menu_Complete_Output_Flow, "menuFrmMethods_menu_Output_File_menu_Complete_Output_Flow");
            this.menuFrmMethods_menu_Output_File_menu_Complete_Output_Flow.Name = "menuFrmMethods_menu_Output_File_menu_Complete_Output_Flow";
            this.menuFrmMethods_menu_Output_File_menu_Complete_Output_Flow.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Complete_Execute);
            this.menuFrmMethods_menu_Output_File_menu_Complete_Output_Flow.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Complete_Inquire);
            // 
            // menuFrmMethods_menu_External_File_Template___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_External_File_Template___, "menuFrmMethods_menu_External_File_Template___");
            this.menuFrmMethods_menu_External_File_Template___.Name = "menuFrmMethods_menu_External_File_Template___";
            this.menuFrmMethods_menu_External_File_Template___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__External_1_Execute);
            this.menuFrmMethods_menu_External_File_Template___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__External_1_Inquire);
            // 
            // menuFrmMethods_menuR_emove_Transactions
            // 
            resources.ApplyResources(this.menuFrmMethods_menuR_emove_Transactions, "menuFrmMethods_menuR_emove_Transactions");
            this.menuFrmMethods_menuR_emove_Transactions.Name = "menuFrmMethods_menuR_emove_Transactions";
            this.menuFrmMethods_menuR_emove_Transactions.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Remove_Execute);
            this.menuFrmMethods_menuR_emove_Transactions.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Remove_Inquire);
            // 
            // labelcmdLoadFileId
            // 
            resources.ApplyResources(this.labelcmdLoadFileId, "labelcmdLoadFileId");
            this.labelcmdLoadFileId.Name = "labelcmdLoadFileId";
            // 
            // cmdLoadFileId
            // 
            resources.ApplyResources(this.cmdLoadFileId, "cmdLoadFileId");
            this.cmdLoadFileId.Name = "cmdLoadFileId";
            this.cmdLoadFileId.NamedProperties.Put("DataType", "3");
            this.cmdLoadFileId.NamedProperties.Put("EnumerateMethod", "");
            this.cmdLoadFileId.NamedProperties.Put("FieldFlags", "163");
            this.cmdLoadFileId.NamedProperties.Put("LovReference", "");
            this.cmdLoadFileId.NamedProperties.Put("ResizeableChildObject", "");
            this.cmdLoadFileId.NamedProperties.Put("SqlColumn", "LOAD_FILE_ID");
            this.cmdLoadFileId.NamedProperties.Put("ValidateMethod", "");
            this.cmdLoadFileId.NamedProperties.Put("XDataLength", "Class Default");
            this.cmdLoadFileId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmdLoadFileId_WindowActions);
            // 
            // labeldfdLoadDate
            // 
            resources.ApplyResources(this.labeldfdLoadDate, "labeldfdLoadDate");
            this.labeldfdLoadDate.Name = "labeldfdLoadDate";
            // 
            // dfdLoadDate
            // 
            this.dfdLoadDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.dfdLoadDate, "dfdLoadDate");
            this.dfdLoadDate.Format = "d";
            this.dfdLoadDate.Name = "dfdLoadDate";
            this.dfdLoadDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdLoadDate.NamedProperties.Put("FieldFlags", "295");
            this.dfdLoadDate.NamedProperties.Put("LovReference", "");
            this.dfdLoadDate.NamedProperties.Put("ParentName", "cmdLoadFileId");
            this.dfdLoadDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdLoadDate.NamedProperties.Put("SqlColumn", "LOAD_DATE");
            this.dfdLoadDate.NamedProperties.Put("ValidateMethod", "");
            this.dfdLoadDate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfdLoadDate_WindowActions);
            // 
            // dfsCompany
            // 
            this.dfsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "258");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            this.dfsCompany.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCompany_WindowActions);
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
            // labeldfFileTypeName
            // 
            resources.ApplyResources(this.labeldfFileTypeName, "labeldfFileTypeName");
            this.labeldfFileTypeName.Name = "labeldfFileTypeName";
            // 
            // dfFileTypeName
            // 
            this.dfFileTypeName.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfFileTypeName, "dfFileTypeName");
            this.dfFileTypeName.Name = "dfFileTypeName";
            this.dfFileTypeName.NamedProperties.Put("EnumerateMethod", "");
            this.dfFileTypeName.NamedProperties.Put("LovReference", "");
            this.dfFileTypeName.NamedProperties.Put("ParentName", "dfsFileType");
            this.dfFileTypeName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfFileTypeName.NamedProperties.Put("SqlColumn", "Ext_File_Type_API.Get_Description(FILE_TYPE)");
            this.dfFileTypeName.NamedProperties.Put("ValidateMethod", "");
            this.dfFileTypeName.ReadOnly = true;
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
            // labeldfSetIdName
            // 
            resources.ApplyResources(this.labeldfSetIdName, "labeldfSetIdName");
            this.labeldfSetIdName.Name = "labeldfSetIdName";
            // 
            // dfSetIdName
            // 
            this.dfSetIdName.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfSetIdName, "dfSetIdName");
            this.dfSetIdName.Name = "dfSetIdName";
            this.dfSetIdName.NamedProperties.Put("EnumerateMethod", "");
            this.dfSetIdName.NamedProperties.Put("LovReference", "");
            this.dfSetIdName.NamedProperties.Put("ParentName", "dfsSetIdTest");
            this.dfSetIdName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfSetIdName.NamedProperties.Put("SqlColumn", "Ext_Type_Param_Set_API.Get_Description(FILE_TYPE,SET_ID)");
            this.dfSetIdName.NamedProperties.Put("ValidateMethod", "");
            this.dfSetIdName.ReadOnly = true;
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
            this.dfsFileTemplateId.NamedProperties.Put("ParentName", "cmdLoadFileId");
            this.dfsFileTemplateId.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.dfsFileTemplateId.NamedProperties.Put("SqlColumn", "FILE_TEMPLATE_ID");
            this.dfsFileTemplateId.NamedProperties.Put("ValidateMethod", "");
            this.dfsFileTemplateId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsFileTemplateId_WindowActions);
            // 
            // labeldfFileTemplateIdName
            // 
            resources.ApplyResources(this.labeldfFileTemplateIdName, "labeldfFileTemplateIdName");
            this.labeldfFileTemplateIdName.Name = "labeldfFileTemplateIdName";
            // 
            // dfFileTemplateIdName
            // 
            this.dfFileTemplateIdName.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfFileTemplateIdName, "dfFileTemplateIdName");
            this.dfFileTemplateIdName.Name = "dfFileTemplateIdName";
            this.dfFileTemplateIdName.NamedProperties.Put("EnumerateMethod", "");
            this.dfFileTemplateIdName.NamedProperties.Put("LovReference", "");
            this.dfFileTemplateIdName.NamedProperties.Put("ParentName", "dfsFileTemplateId");
            this.dfFileTemplateIdName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfFileTemplateIdName.NamedProperties.Put("SqlColumn", "Ext_File_Template_API.Get_Description(FILE_TEMPLATE_ID)");
            this.dfFileTemplateIdName.NamedProperties.Put("ValidateMethod", "");
            this.dfFileTemplateIdName.ReadOnly = true;
            // 
            // labelcmbFileDirection
            // 
            resources.ApplyResources(this.labelcmbFileDirection, "labelcmbFileDirection");
            this.labelcmbFileDirection.Name = "labelcmbFileDirection";
            // 
            // cmbFileDirection
            // 
            resources.ApplyResources(this.cmbFileDirection, "cmbFileDirection");
            this.cmbFileDirection.Name = "cmbFileDirection";
            this.cmbFileDirection.NamedProperties.Put("EnumerateMethod", "FILE_DIRECTION_API.Enumerate");
            this.cmbFileDirection.NamedProperties.Put("FieldFlags", "295");
            this.cmbFileDirection.NamedProperties.Put("LovReference", "");
            this.cmbFileDirection.NamedProperties.Put("SqlColumn", "FILE_DIRECTION");
            this.cmbFileDirection.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbFileDirection_WindowActions);
            // 
            // dfsMultiDirection
            // 
            resources.ApplyResources(this.dfsMultiDirection, "dfsMultiDirection");
            this.dfsMultiDirection.Name = "dfsMultiDirection";
            this.dfsMultiDirection.NamedProperties.Put("EnumerateMethod", "");
            this.dfsMultiDirection.NamedProperties.Put("LovReference", "");
            this.dfsMultiDirection.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsMultiDirection.NamedProperties.Put("SqlColumn", "");
            this.dfsMultiDirection.NamedProperties.Put("ValidateMethod", "");
            // 
            // pbBrowser
            // 
            resources.ApplyResources(this.pbBrowser, "pbBrowser");
            this.pbBrowser.Name = "pbBrowser";
            this.pbBrowser.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbBrowser_WindowActions);
            // 
            // labeldfFileName
            // 
            resources.ApplyResources(this.labeldfFileName, "labeldfFileName");
            this.labeldfFileName.Name = "labeldfFileName";
            // 
            // dfFileName
            // 
            resources.ApplyResources(this.dfFileName, "dfFileName");
            this.dfFileName.Name = "dfFileName";
            this.dfFileName.NamedProperties.Put("EnumerateMethod", "");
            this.dfFileName.NamedProperties.Put("FieldFlags", "260");
            this.dfFileName.NamedProperties.Put("LovReference", "");
            this.dfFileName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfFileName.NamedProperties.Put("SqlColumn", "FILE_NAME");
            this.dfFileName.NamedProperties.Put("ValidateMethod", "");
            this.dfFileName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfFileName_WindowActions);
            // 
            // labeldfsUserId
            // 
            resources.ApplyResources(this.labeldfsUserId, "labeldfsUserId");
            this.labeldfsUserId.Name = "labeldfsUserId";
            // 
            // dfsUserId
            // 
            this.dfsUserId.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsUserId, "dfsUserId");
            this.dfsUserId.Name = "dfsUserId";
            this.dfsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsUserId.NamedProperties.Put("FieldFlags", "290");
            this.dfsUserId.NamedProperties.Put("LovReference", "");
            this.dfsUserId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsUserId.NamedProperties.Put("SqlColumn", "USER_ID");
            this.dfsUserId.NamedProperties.Put("ValidateMethod", "");
            this.dfsUserId.ReadOnly = true;
            // 
            // labeldfsState
            // 
            resources.ApplyResources(this.labeldfsState, "labeldfsState");
            this.labeldfsState.Name = "labeldfsState";
            // 
            // dfsState
            // 
            resources.ApplyResources(this.dfsState, "dfsState");
            this.dfsState.Name = "dfsState";
            this.dfsState.NamedProperties.Put("EnumerateMethod", "");
            this.dfsState.NamedProperties.Put("FieldFlags", "290");
            this.dfsState.NamedProperties.Put("LovReference", "");
            this.dfsState.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsState.NamedProperties.Put("SqlColumn", "STATE");
            this.dfsState.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsStateDb
            // 
            resources.ApplyResources(this.dfsStateDb, "dfsStateDb");
            this.dfsStateDb.Name = "dfsStateDb";
            this.dfsStateDb.NamedProperties.Put("EnumerateMethod", "");
            this.dfsStateDb.NamedProperties.Put("FieldFlags", "262");
            this.dfsStateDb.NamedProperties.Put("LovReference", "");
            this.dfsStateDb.NamedProperties.Put("SqlColumn", "STATE_DB");
            this.dfsStateDb.NamedProperties.Put("ValidateMethod", "");
            this.dfsStateDb.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsStateDb_WindowActions);
            // 
            // dfsApiToCall
            // 
            resources.ApplyResources(this.dfsApiToCall, "dfsApiToCall");
            this.dfsApiToCall.Name = "dfsApiToCall";
            this.dfsApiToCall.NamedProperties.Put("EnumerateMethod", "");
            this.dfsApiToCall.NamedProperties.Put("LovReference", "");
            this.dfsApiToCall.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsApiToCall.NamedProperties.Put("SqlColumn", "");
            this.dfsApiToCall.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsParameterString
            // 
            resources.ApplyResources(this.dfsParameterString, "dfsParameterString");
            this.dfsParameterString.Name = "dfsParameterString";
            this.dfsParameterString.NamedProperties.Put("EnumerateMethod", "");
            this.dfsParameterString.NamedProperties.Put("FieldFlags", "262");
            this.dfsParameterString.NamedProperties.Put("LovReference", "");
            this.dfsParameterString.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsParameterString.NamedProperties.Put("SqlColumn", "PARAMETER_STRING");
            this.dfsParameterString.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsFileDirectionDb
            // 
            resources.ApplyResources(this.dfsFileDirectionDb, "dfsFileDirectionDb");
            this.dfsFileDirectionDb.Name = "dfsFileDirectionDb";
            this.dfsFileDirectionDb.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFileDirectionDb.NamedProperties.Put("LovReference", "");
            this.dfsFileDirectionDb.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFileDirectionDb.NamedProperties.Put("SqlColumn", "FILE_DIRECTION_DB");
            this.dfsFileDirectionDb.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsViewName
            // 
            resources.ApplyResources(this.dfsViewName, "dfsViewName");
            this.dfsViewName.Name = "dfsViewName";
            this.dfsViewName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsViewName.NamedProperties.Put("FieldFlags", "276");
            this.dfsViewName.NamedProperties.Put("LovReference", "");
            this.dfsViewName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsViewName.NamedProperties.Put("SqlColumn", "");
            this.dfsViewName.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsFormName
            // 
            resources.ApplyResources(this.dfsFormName, "dfsFormName");
            this.dfsFormName.Name = "dfsFormName";
            this.dfsFormName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFormName.NamedProperties.Put("FieldFlags", "276");
            this.dfsFormName.NamedProperties.Put("LovReference", "");
            this.dfsFormName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFormName.NamedProperties.Put("SqlColumn", "");
            this.dfsFormName.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsTargetDefaultMethod
            // 
            resources.ApplyResources(this.dfsTargetDefaultMethod, "dfsTargetDefaultMethod");
            this.dfsTargetDefaultMethod.Name = "dfsTargetDefaultMethod";
            this.dfsTargetDefaultMethod.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTargetDefaultMethod.NamedProperties.Put("FieldFlags", "276");
            this.dfsTargetDefaultMethod.NamedProperties.Put("LovReference", "");
            this.dfsTargetDefaultMethod.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTargetDefaultMethod.NamedProperties.Put("SqlColumn", "");
            this.dfsTargetDefaultMethod.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Load,
            this.menuItem__External,
            this.popupMenu__Input,
            this.popupMenu__Output,
            this.menuItem__External_1,
            this.menuItem_Remove});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem__Load
            // 
            this.menuItem__Load.Command = this.menuFrmMethods_menu_Load_Parameters___;
            this.menuItem__Load.Name = "menuItem__Load";
            resources.ApplyResources(this.menuItem__Load, "menuItem__Load");
            this.menuItem__Load.Text = "&Load Parameters...";
            // 
            // menuItem__External
            // 
            this.menuItem__External.Command = this.menuFrmMethods_menu_External_File_Log___;
            this.menuItem__External.Name = "menuItem__External";
            resources.ApplyResources(this.menuItem__External, "menuItem__External");
            this.menuItem__External.Text = "&External File Log...";
            // 
            // popupMenu__Input
            // 
            this.popupMenu__Input.Command = this.menuFrmMethods_menu_Input_File;
            this.popupMenu__Input.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Load_1,
            this.menuItem__Unpack,
            this.menuItem_Call,
            this.menuItem_Complete});
            this.popupMenu__Input.Name = "popupMenu__Input";
            resources.ApplyResources(this.popupMenu__Input, "popupMenu__Input");
            this.popupMenu__Input.Text = "&Input File";
            // 
            // menuItem__Load_1
            // 
            this.menuItem__Load_1.Command = this.menuFrmMethods_menu_Input_File_menu_Load_External_Input_File;
            this.menuItem__Load_1.Name = "menuItem__Load_1";
            resources.ApplyResources(this.menuItem__Load_1, "menuItem__Load_1");
            this.menuItem__Load_1.Text = "&Load External Input File";
            // 
            // menuItem__Unpack
            // 
            this.menuItem__Unpack.Command = this.menuFrmMethods_menu_Input_File_menu_Unpack_External_Input_File;
            this.menuItem__Unpack.Name = "menuItem__Unpack";
            resources.ApplyResources(this.menuItem__Unpack, "menuItem__Unpack");
            this.menuItem__Unpack.Text = "&Unpack External Input File";
            // 
            // menuItem_Call
            // 
            this.menuItem_Call.Command = this.menuFrmMethods_menu_Input_File_menuCall__Input_Package_Method;
            this.menuItem_Call.Name = "menuItem_Call";
            resources.ApplyResources(this.menuItem_Call, "menuItem_Call");
            this.menuItem_Call.Text = "Call &Input Package Method";
            // 
            // menuItem_Complete
            // 
            this.menuItem_Complete.Command = this.menuFrmMethods_menu_Input_File_menuComplete_Input__Flow;
            this.menuItem_Complete.Name = "menuItem_Complete";
            resources.ApplyResources(this.menuItem_Complete, "menuItem_Complete");
            this.menuItem_Complete.Text = "Complete Input &Flow";
            // 
            // popupMenu__Output
            // 
            this.popupMenu__Output.Command = this.menuFrmMethods_menu_Output_File;
            this.popupMenu__Output.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Call_1,
            this.menuItem__Pack,
            this.menuItem_Create,
            this.menuItem__Complete});
            this.popupMenu__Output.Name = "popupMenu__Output";
            resources.ApplyResources(this.popupMenu__Output, "popupMenu__Output");
            this.popupMenu__Output.Text = "&Output File";
            // 
            // menuItem_Call_1
            // 
            this.menuItem_Call_1.Command = this.menuFrmMethods_menu_Output_File_menuCall__Output_Package_Method;
            this.menuItem_Call_1.Name = "menuItem_Call_1";
            resources.ApplyResources(this.menuItem_Call_1, "menuItem_Call_1");
            this.menuItem_Call_1.Text = "Call &Output Package Method";
            // 
            // menuItem__Pack
            // 
            this.menuItem__Pack.Command = this.menuFrmMethods_menu_Output_File_menu_Pack_External_Output_File;
            this.menuItem__Pack.Name = "menuItem__Pack";
            resources.ApplyResources(this.menuItem__Pack, "menuItem__Pack");
            this.menuItem__Pack.Text = "&Pack External Output File";
            // 
            // menuItem_Create
            // 
            this.menuItem_Create.Command = this.menuFrmMethods_menu_Output_File_menuCreate_External__Output_File;
            this.menuItem_Create.Name = "menuItem_Create";
            resources.ApplyResources(this.menuItem_Create, "menuItem_Create");
            this.menuItem_Create.Text = "Create External &Output File";
            // 
            // menuItem__Complete
            // 
            this.menuItem__Complete.Command = this.menuFrmMethods_menu_Output_File_menu_Complete_Output_Flow;
            this.menuItem__Complete.Name = "menuItem__Complete";
            resources.ApplyResources(this.menuItem__Complete, "menuItem__Complete");
            this.menuItem__Complete.Text = "&Complete Output Flow";
            // 
            // menuItem__External_1
            // 
            this.menuItem__External_1.Command = this.menuFrmMethods_menu_External_File_Template___;
            this.menuItem__External_1.Name = "menuItem__External_1";
            resources.ApplyResources(this.menuItem__External_1, "menuItem__External_1");
            this.menuItem__External_1.Text = "&External File Template...";
            // 
            // menuItem_Remove
            // 
            this.menuItem_Remove.Command = this.menuFrmMethods_menuR_emove_Transactions;
            this.menuItem_Remove.Name = "menuItem_Remove";
            resources.ApplyResources(this.menuItem_Remove, "menuItem_Remove");
            this.menuItem_Remove.Text = "R&emove Transactions";
            // 
            // tblExtFileTransColumn
            // 
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnRowNo);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnLoadFileId);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsRecordTypeId);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC0);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC1);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC2);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC3);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC4);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC5);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC6);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC7);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC8);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC9);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC10);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC11);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC12);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC13);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC14);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC15);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC16);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC17);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC18);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC19);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC20);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC21);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC22);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC23);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC24);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC25);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC26);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC27);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC28);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC29);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC30);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC31);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC32);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC33);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC34);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC35);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC36);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC37);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC38);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC39);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC40);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC41);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC42);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC43);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC44);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC45);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC46);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC47);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC48);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC49);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC50);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC51);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC52);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC53);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC54);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC55);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC56);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC57);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC58);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC59);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC60);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC61);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC62);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC63);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC64);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC65);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC66);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC67);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC68);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC69);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC70);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC71);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC72);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC73);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC74);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC75);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC76);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC77);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC78);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC79);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC80);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC81);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC82);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC83);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC84);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC85);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC86);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC87);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC88);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC89);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC90);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC91);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC92);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC93);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC94);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC95);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC96);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC97);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC98);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC99);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC100);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC101);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC102);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC103);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC104);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC105);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC106);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC107);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC108);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC109);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC110);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC111);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC112);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC113);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC114);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC115);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC116);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC117);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC118);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC119);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC120);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC121);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC122);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC123);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC124);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC125);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC126);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC127);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC128);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC129);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC130);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC131);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC132);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC133);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC134);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC135);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC136);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC137);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC138);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC139);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC140);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC141);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC142);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC143);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC144);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC145);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC146);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC147);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC148);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC149);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC150);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC151);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC152);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC153);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC154);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC155);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC156);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC157);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC158);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC159);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC160);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC161);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC162);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC163);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC164);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC165);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC166);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC167);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC168);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC169);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC170);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC171);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC172);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC173);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC174);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC175);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC176);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC177);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC178);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC179);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC180);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC181);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC182);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC183);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC184);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC185);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC186);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC187);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC188);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC189);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC190);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC191);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC192);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC193);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC194);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC195);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC196);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC197);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC198);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colsC199);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN0);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN1);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN2);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN3);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN4);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN5);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN6);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN7);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN8);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN9);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN10);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN11);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN12);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN13);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN14);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN15);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN16);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN17);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN18);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN19);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN20);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN21);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN22);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN23);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN24);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN25);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN26);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN27);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN28);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN29);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN30);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN31);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN32);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN33);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN34);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN35);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN36);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN37);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN38);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN39);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN40);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN41);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN42);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN43);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN44);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN45);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN46);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN47);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN48);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN49);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN50);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN51);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN52);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN53);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN54);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN55);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN56);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN57);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN58);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN59);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN60);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN61);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN62);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN63);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN64);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN65);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN66);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN67);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN68);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN69);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN70);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN71);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN72);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN73);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN74);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN75);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN76);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN77);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN78);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN79);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN80);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN81);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN82);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN83);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN84);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN85);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN86);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN87);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN88);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN89);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN90);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN91);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN92);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN93);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN94);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN95);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN96);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN97);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN98);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_colnN99);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD1);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD2);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD3);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD4);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD5);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD6);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD7);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD8);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD9);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD10);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD11);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD12);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD13);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD14);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD15);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD16);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD17);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD18);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD19);
            this.tblExtFileTransColumn.Controls.Add(this.tblExtFileTransColumn_coldD20);
            resources.ApplyResources(this.tblExtFileTransColumn, "tblExtFileTransColumn");
            this.tblExtFileTransColumn.Name = "tblExtFileTransColumn";
            this.tblExtFileTransColumn.NamedProperties.Put("DefaultOrderBy", "");
            this.tblExtFileTransColumn.NamedProperties.Put("DefaultWhere", "ROW_NO = :i_hWndFrame.frmExternalFileTransactions.tblExtFileTrans_colnRowNo\r\n");
            this.tblExtFileTransColumn.NamedProperties.Put("LogicalUnit", "ExtFileTrans");
            this.tblExtFileTransColumn.NamedProperties.Put("PackageName", "EXT_FILE_TRANS_API");
            this.tblExtFileTransColumn.NamedProperties.Put("ResizeableChildObject", "LRMM");
            this.tblExtFileTransColumn.NamedProperties.Put("SourceFlags", "1");
            this.tblExtFileTransColumn.NamedProperties.Put("ViewName", "EXT_FILE_TRANS");
            this.tblExtFileTransColumn.NamedProperties.Put("Warnings", "FALSE");
            this.tblExtFileTransColumn.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTransColumn_WindowActions);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD20, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD19, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD18, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD17, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD16, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD15, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD14, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD13, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD12, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD11, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD10, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD9, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD8, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD7, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD6, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD5, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD4, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD3, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD2, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_coldD1, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN99, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN98, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN97, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN96, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN95, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN94, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN93, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN92, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN91, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN90, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN89, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN88, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN87, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN86, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN85, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN84, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN83, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN82, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN81, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN80, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN79, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN78, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN77, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN76, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN75, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN74, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN73, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN72, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN71, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN70, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN69, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN68, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN67, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN66, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN65, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN64, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN63, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN62, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN61, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN60, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN59, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN58, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN57, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN56, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN55, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN54, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN53, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN52, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN51, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN50, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN49, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN48, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN47, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN46, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN45, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN44, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN43, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN42, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN41, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN40, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN39, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN38, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN37, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN36, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN35, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN34, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN33, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN32, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN31, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN30, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN29, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN28, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN27, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN26, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN25, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN24, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN23, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN22, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN21, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN20, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN19, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN18, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN17, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN16, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN15, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN14, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN13, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN12, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN11, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN10, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN9, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN8, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN7, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN6, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN5, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN4, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN3, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN2, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN1, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnN0, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC199, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC198, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC197, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC196, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC195, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC194, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC193, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC192, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC191, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC190, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC189, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC188, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC187, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC186, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC185, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC184, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC183, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC182, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC181, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC180, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC179, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC178, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC177, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC176, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC175, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC174, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC173, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC172, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC171, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC170, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC169, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC168, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC167, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC166, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC165, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC164, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC163, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC162, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC161, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC160, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC159, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC158, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC157, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC156, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC155, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC154, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC153, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC152, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC151, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC150, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC149, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC148, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC147, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC146, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC145, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC144, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC143, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC142, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC141, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC140, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC139, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC138, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC137, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC136, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC135, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC134, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC133, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC132, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC131, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC130, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC129, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC128, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC127, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC126, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC125, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC124, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC123, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC122, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC121, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC120, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC119, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC118, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC117, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC116, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC115, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC114, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC113, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC112, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC111, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC110, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC109, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC108, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC107, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC106, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC105, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC104, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC103, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC102, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC101, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC100, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC99, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC98, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC97, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC96, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC95, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC94, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC93, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC92, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC91, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC90, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC89, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC88, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC87, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC86, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC85, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC84, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC83, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC82, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC81, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC80, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC79, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC78, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC77, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC76, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC75, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC74, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC73, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC72, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC71, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC70, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC69, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC68, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC67, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC66, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC65, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC64, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC63, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC62, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC61, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC60, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC59, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC58, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC57, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC56, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC55, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC54, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC53, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC52, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC51, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC50, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC49, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC48, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC47, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC46, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC45, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC44, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC43, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC42, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC41, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC40, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC39, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC38, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC37, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC36, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC35, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC34, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC33, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC32, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC31, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC30, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC29, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC28, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC27, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC26, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC25, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC24, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC23, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC22, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC21, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC20, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC19, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC18, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC17, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC16, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC15, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC14, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC13, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC12, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC11, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC10, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC9, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC8, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC7, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC6, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC5, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC4, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC3, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC2, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC1, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsC0, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colsRecordTypeId, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnLoadFileId, 0);
            this.tblExtFileTransColumn.Controls.SetChildIndex(this.tblExtFileTransColumn_colnRowNo, 0);
            // 
            // tblExtFileTransColumn_colnRowNo
            // 
            this.tblExtFileTransColumn_colnRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblExtFileTransColumn_colnRowNo, "tblExtFileTransColumn_colnRowNo");
            this.tblExtFileTransColumn_colnRowNo.Name = "tblExtFileTransColumn_colnRowNo";
            this.tblExtFileTransColumn_colnRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnRowNo.NamedProperties.Put("FieldFlags", "163");
            this.tblExtFileTransColumn_colnRowNo.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnRowNo.NamedProperties.Put("SqlColumn", "ROW_NO");
            this.tblExtFileTransColumn_colnRowNo.Position = 3;
            // 
            // tblExtFileTransColumn_colnLoadFileId
            // 
            this.tblExtFileTransColumn_colnLoadFileId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblExtFileTransColumn_colnLoadFileId, "tblExtFileTransColumn_colnLoadFileId");
            this.tblExtFileTransColumn_colnLoadFileId.Name = "tblExtFileTransColumn_colnLoadFileId";
            this.tblExtFileTransColumn_colnLoadFileId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnLoadFileId.NamedProperties.Put("FieldFlags", "67");
            this.tblExtFileTransColumn_colnLoadFileId.NamedProperties.Put("LovReference", "EXT_FILE_LOAD");
            this.tblExtFileTransColumn_colnLoadFileId.NamedProperties.Put("SqlColumn", "LOAD_FILE_ID");
            this.tblExtFileTransColumn_colnLoadFileId.Position = 4;
            // 
            // tblExtFileTransColumn_colsRecordTypeId
            // 
            this.tblExtFileTransColumn_colsRecordTypeId.MaxLength = 200;
            this.tblExtFileTransColumn_colsRecordTypeId.Name = "tblExtFileTransColumn_colsRecordTypeId";
            this.tblExtFileTransColumn_colsRecordTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsRecordTypeId.NamedProperties.Put("FieldFlags", "98");
            this.tblExtFileTransColumn_colsRecordTypeId.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsRecordTypeId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsRecordTypeId.NamedProperties.Put("SqlColumn", "RECORD_TYPE_ID");
            this.tblExtFileTransColumn_colsRecordTypeId.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsRecordTypeId.Position = 5;
            resources.ApplyResources(this.tblExtFileTransColumn_colsRecordTypeId, "tblExtFileTransColumn_colsRecordTypeId");
            // 
            // tblExtFileTransColumn_colsC0
            // 
            this.tblExtFileTransColumn_colsC0.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC0.Name = "tblExtFileTransColumn_colsC0";
            this.tblExtFileTransColumn_colsC0.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC0.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC0.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC0.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC0.NamedProperties.Put("SqlColumn", "C0");
            this.tblExtFileTransColumn_colsC0.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC0.Position = 6;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC0, "tblExtFileTransColumn_colsC0");
            // 
            // tblExtFileTransColumn_colsC1
            // 
            this.tblExtFileTransColumn_colsC1.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC1.Name = "tblExtFileTransColumn_colsC1";
            this.tblExtFileTransColumn_colsC1.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC1.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC1.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC1.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC1.NamedProperties.Put("SqlColumn", "C1");
            this.tblExtFileTransColumn_colsC1.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC1.Position = 7;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC1, "tblExtFileTransColumn_colsC1");
            // 
            // tblExtFileTransColumn_colsC2
            // 
            this.tblExtFileTransColumn_colsC2.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC2.Name = "tblExtFileTransColumn_colsC2";
            this.tblExtFileTransColumn_colsC2.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC2.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC2.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC2.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC2.NamedProperties.Put("SqlColumn", "C2");
            this.tblExtFileTransColumn_colsC2.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC2.Position = 8;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC2, "tblExtFileTransColumn_colsC2");
            // 
            // tblExtFileTransColumn_colsC3
            // 
            this.tblExtFileTransColumn_colsC3.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC3.Name = "tblExtFileTransColumn_colsC3";
            this.tblExtFileTransColumn_colsC3.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC3.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC3.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC3.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC3.NamedProperties.Put("SqlColumn", "C3");
            this.tblExtFileTransColumn_colsC3.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC3.Position = 9;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC3, "tblExtFileTransColumn_colsC3");
            // 
            // tblExtFileTransColumn_colsC4
            // 
            this.tblExtFileTransColumn_colsC4.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC4.Name = "tblExtFileTransColumn_colsC4";
            this.tblExtFileTransColumn_colsC4.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC4.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC4.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC4.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC4.NamedProperties.Put("SqlColumn", "C4");
            this.tblExtFileTransColumn_colsC4.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC4.Position = 10;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC4, "tblExtFileTransColumn_colsC4");
            // 
            // tblExtFileTransColumn_colsC5
            // 
            this.tblExtFileTransColumn_colsC5.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC5.Name = "tblExtFileTransColumn_colsC5";
            this.tblExtFileTransColumn_colsC5.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC5.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC5.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC5.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC5.NamedProperties.Put("SqlColumn", "C5");
            this.tblExtFileTransColumn_colsC5.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC5.Position = 11;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC5, "tblExtFileTransColumn_colsC5");
            // 
            // tblExtFileTransColumn_colsC6
            // 
            this.tblExtFileTransColumn_colsC6.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC6.Name = "tblExtFileTransColumn_colsC6";
            this.tblExtFileTransColumn_colsC6.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC6.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC6.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC6.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC6.NamedProperties.Put("SqlColumn", "C6");
            this.tblExtFileTransColumn_colsC6.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC6.Position = 12;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC6, "tblExtFileTransColumn_colsC6");
            // 
            // tblExtFileTransColumn_colsC7
            // 
            this.tblExtFileTransColumn_colsC7.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC7.Name = "tblExtFileTransColumn_colsC7";
            this.tblExtFileTransColumn_colsC7.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC7.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC7.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC7.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC7.NamedProperties.Put("SqlColumn", "C7");
            this.tblExtFileTransColumn_colsC7.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC7.Position = 13;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC7, "tblExtFileTransColumn_colsC7");
            // 
            // tblExtFileTransColumn_colsC8
            // 
            this.tblExtFileTransColumn_colsC8.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC8.Name = "tblExtFileTransColumn_colsC8";
            this.tblExtFileTransColumn_colsC8.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC8.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC8.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC8.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC8.NamedProperties.Put("SqlColumn", "C8");
            this.tblExtFileTransColumn_colsC8.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC8.Position = 14;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC8, "tblExtFileTransColumn_colsC8");
            // 
            // tblExtFileTransColumn_colsC9
            // 
            this.tblExtFileTransColumn_colsC9.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC9.Name = "tblExtFileTransColumn_colsC9";
            this.tblExtFileTransColumn_colsC9.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC9.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC9.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC9.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC9.NamedProperties.Put("SqlColumn", "C9");
            this.tblExtFileTransColumn_colsC9.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC9.Position = 15;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC9, "tblExtFileTransColumn_colsC9");
            // 
            // tblExtFileTransColumn_colsC10
            // 
            this.tblExtFileTransColumn_colsC10.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC10.Name = "tblExtFileTransColumn_colsC10";
            this.tblExtFileTransColumn_colsC10.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC10.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC10.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC10.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC10.NamedProperties.Put("SqlColumn", "C10");
            this.tblExtFileTransColumn_colsC10.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC10.Position = 16;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC10, "tblExtFileTransColumn_colsC10");
            // 
            // tblExtFileTransColumn_colsC11
            // 
            this.tblExtFileTransColumn_colsC11.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC11.Name = "tblExtFileTransColumn_colsC11";
            this.tblExtFileTransColumn_colsC11.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC11.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC11.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC11.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC11.NamedProperties.Put("SqlColumn", "C11");
            this.tblExtFileTransColumn_colsC11.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC11.Position = 17;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC11, "tblExtFileTransColumn_colsC11");
            // 
            // tblExtFileTransColumn_colsC12
            // 
            this.tblExtFileTransColumn_colsC12.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC12.Name = "tblExtFileTransColumn_colsC12";
            this.tblExtFileTransColumn_colsC12.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC12.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC12.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC12.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC12.NamedProperties.Put("SqlColumn", "C12");
            this.tblExtFileTransColumn_colsC12.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC12.Position = 18;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC12, "tblExtFileTransColumn_colsC12");
            // 
            // tblExtFileTransColumn_colsC13
            // 
            this.tblExtFileTransColumn_colsC13.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC13.Name = "tblExtFileTransColumn_colsC13";
            this.tblExtFileTransColumn_colsC13.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC13.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC13.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC13.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC13.NamedProperties.Put("SqlColumn", "C13");
            this.tblExtFileTransColumn_colsC13.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC13.Position = 19;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC13, "tblExtFileTransColumn_colsC13");
            // 
            // tblExtFileTransColumn_colsC14
            // 
            this.tblExtFileTransColumn_colsC14.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC14.Name = "tblExtFileTransColumn_colsC14";
            this.tblExtFileTransColumn_colsC14.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC14.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC14.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC14.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC14.NamedProperties.Put("SqlColumn", "C14");
            this.tblExtFileTransColumn_colsC14.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC14.Position = 20;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC14, "tblExtFileTransColumn_colsC14");
            // 
            // tblExtFileTransColumn_colsC15
            // 
            this.tblExtFileTransColumn_colsC15.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC15.Name = "tblExtFileTransColumn_colsC15";
            this.tblExtFileTransColumn_colsC15.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC15.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC15.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC15.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC15.NamedProperties.Put("SqlColumn", "C15");
            this.tblExtFileTransColumn_colsC15.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC15.Position = 21;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC15, "tblExtFileTransColumn_colsC15");
            // 
            // tblExtFileTransColumn_colsC16
            // 
            this.tblExtFileTransColumn_colsC16.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC16.Name = "tblExtFileTransColumn_colsC16";
            this.tblExtFileTransColumn_colsC16.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC16.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC16.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC16.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC16.NamedProperties.Put("SqlColumn", "C16");
            this.tblExtFileTransColumn_colsC16.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC16.Position = 22;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC16, "tblExtFileTransColumn_colsC16");
            // 
            // tblExtFileTransColumn_colsC17
            // 
            this.tblExtFileTransColumn_colsC17.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC17.Name = "tblExtFileTransColumn_colsC17";
            this.tblExtFileTransColumn_colsC17.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC17.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC17.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC17.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC17.NamedProperties.Put("SqlColumn", "C17");
            this.tblExtFileTransColumn_colsC17.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC17.Position = 23;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC17, "tblExtFileTransColumn_colsC17");
            // 
            // tblExtFileTransColumn_colsC18
            // 
            this.tblExtFileTransColumn_colsC18.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC18.Name = "tblExtFileTransColumn_colsC18";
            this.tblExtFileTransColumn_colsC18.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC18.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC18.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC18.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC18.NamedProperties.Put("SqlColumn", "C18");
            this.tblExtFileTransColumn_colsC18.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC18.Position = 24;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC18, "tblExtFileTransColumn_colsC18");
            // 
            // tblExtFileTransColumn_colsC19
            // 
            this.tblExtFileTransColumn_colsC19.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC19.Name = "tblExtFileTransColumn_colsC19";
            this.tblExtFileTransColumn_colsC19.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC19.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC19.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC19.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC19.NamedProperties.Put("SqlColumn", "C19");
            this.tblExtFileTransColumn_colsC19.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC19.Position = 25;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC19, "tblExtFileTransColumn_colsC19");
            // 
            // tblExtFileTransColumn_colsC20
            // 
            this.tblExtFileTransColumn_colsC20.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC20.Name = "tblExtFileTransColumn_colsC20";
            this.tblExtFileTransColumn_colsC20.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC20.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC20.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC20.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC20.NamedProperties.Put("SqlColumn", "C20");
            this.tblExtFileTransColumn_colsC20.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC20.Position = 26;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC20, "tblExtFileTransColumn_colsC20");
            // 
            // tblExtFileTransColumn_colsC21
            // 
            this.tblExtFileTransColumn_colsC21.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC21.Name = "tblExtFileTransColumn_colsC21";
            this.tblExtFileTransColumn_colsC21.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC21.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC21.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC21.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC21.NamedProperties.Put("SqlColumn", "C21");
            this.tblExtFileTransColumn_colsC21.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC21.Position = 27;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC21, "tblExtFileTransColumn_colsC21");
            // 
            // tblExtFileTransColumn_colsC22
            // 
            this.tblExtFileTransColumn_colsC22.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC22.Name = "tblExtFileTransColumn_colsC22";
            this.tblExtFileTransColumn_colsC22.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC22.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC22.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC22.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC22.NamedProperties.Put("SqlColumn", "C22");
            this.tblExtFileTransColumn_colsC22.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC22.Position = 28;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC22, "tblExtFileTransColumn_colsC22");
            // 
            // tblExtFileTransColumn_colsC23
            // 
            this.tblExtFileTransColumn_colsC23.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC23.Name = "tblExtFileTransColumn_colsC23";
            this.tblExtFileTransColumn_colsC23.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC23.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC23.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC23.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC23.NamedProperties.Put("SqlColumn", "C23");
            this.tblExtFileTransColumn_colsC23.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC23.Position = 29;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC23, "tblExtFileTransColumn_colsC23");
            // 
            // tblExtFileTransColumn_colsC24
            // 
            this.tblExtFileTransColumn_colsC24.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC24.Name = "tblExtFileTransColumn_colsC24";
            this.tblExtFileTransColumn_colsC24.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC24.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC24.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC24.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC24.NamedProperties.Put("SqlColumn", "C24");
            this.tblExtFileTransColumn_colsC24.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC24.Position = 30;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC24, "tblExtFileTransColumn_colsC24");
            // 
            // tblExtFileTransColumn_colsC25
            // 
            this.tblExtFileTransColumn_colsC25.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC25.Name = "tblExtFileTransColumn_colsC25";
            this.tblExtFileTransColumn_colsC25.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC25.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC25.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC25.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC25.NamedProperties.Put("SqlColumn", "C25");
            this.tblExtFileTransColumn_colsC25.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC25.Position = 31;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC25, "tblExtFileTransColumn_colsC25");
            // 
            // tblExtFileTransColumn_colsC26
            // 
            this.tblExtFileTransColumn_colsC26.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC26.Name = "tblExtFileTransColumn_colsC26";
            this.tblExtFileTransColumn_colsC26.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC26.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC26.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC26.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC26.NamedProperties.Put("SqlColumn", "C26");
            this.tblExtFileTransColumn_colsC26.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC26.Position = 32;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC26, "tblExtFileTransColumn_colsC26");
            // 
            // tblExtFileTransColumn_colsC27
            // 
            this.tblExtFileTransColumn_colsC27.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC27.Name = "tblExtFileTransColumn_colsC27";
            this.tblExtFileTransColumn_colsC27.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC27.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC27.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC27.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC27.NamedProperties.Put("SqlColumn", "C27");
            this.tblExtFileTransColumn_colsC27.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC27.Position = 33;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC27, "tblExtFileTransColumn_colsC27");
            // 
            // tblExtFileTransColumn_colsC28
            // 
            this.tblExtFileTransColumn_colsC28.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC28.Name = "tblExtFileTransColumn_colsC28";
            this.tblExtFileTransColumn_colsC28.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC28.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC28.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC28.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC28.NamedProperties.Put("SqlColumn", "C28");
            this.tblExtFileTransColumn_colsC28.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC28.Position = 34;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC28, "tblExtFileTransColumn_colsC28");
            // 
            // tblExtFileTransColumn_colsC29
            // 
            this.tblExtFileTransColumn_colsC29.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC29.Name = "tblExtFileTransColumn_colsC29";
            this.tblExtFileTransColumn_colsC29.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC29.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC29.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC29.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC29.NamedProperties.Put("SqlColumn", "C29");
            this.tblExtFileTransColumn_colsC29.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC29.Position = 35;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC29, "tblExtFileTransColumn_colsC29");
            // 
            // tblExtFileTransColumn_colsC30
            // 
            this.tblExtFileTransColumn_colsC30.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC30.Name = "tblExtFileTransColumn_colsC30";
            this.tblExtFileTransColumn_colsC30.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC30.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC30.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC30.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC30.NamedProperties.Put("SqlColumn", "C30");
            this.tblExtFileTransColumn_colsC30.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC30.Position = 36;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC30, "tblExtFileTransColumn_colsC30");
            // 
            // tblExtFileTransColumn_colsC31
            // 
            this.tblExtFileTransColumn_colsC31.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC31.Name = "tblExtFileTransColumn_colsC31";
            this.tblExtFileTransColumn_colsC31.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC31.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC31.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC31.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC31.NamedProperties.Put("SqlColumn", "C31");
            this.tblExtFileTransColumn_colsC31.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC31.Position = 37;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC31, "tblExtFileTransColumn_colsC31");
            // 
            // tblExtFileTransColumn_colsC32
            // 
            this.tblExtFileTransColumn_colsC32.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC32.Name = "tblExtFileTransColumn_colsC32";
            this.tblExtFileTransColumn_colsC32.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC32.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC32.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC32.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC32.NamedProperties.Put("SqlColumn", "C32");
            this.tblExtFileTransColumn_colsC32.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC32.Position = 38;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC32, "tblExtFileTransColumn_colsC32");
            // 
            // tblExtFileTransColumn_colsC33
            // 
            this.tblExtFileTransColumn_colsC33.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC33.Name = "tblExtFileTransColumn_colsC33";
            this.tblExtFileTransColumn_colsC33.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC33.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC33.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC33.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC33.NamedProperties.Put("SqlColumn", "C33");
            this.tblExtFileTransColumn_colsC33.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC33.Position = 39;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC33, "tblExtFileTransColumn_colsC33");
            // 
            // tblExtFileTransColumn_colsC34
            // 
            this.tblExtFileTransColumn_colsC34.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC34.Name = "tblExtFileTransColumn_colsC34";
            this.tblExtFileTransColumn_colsC34.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC34.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC34.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC34.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC34.NamedProperties.Put("SqlColumn", "C34");
            this.tblExtFileTransColumn_colsC34.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC34.Position = 40;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC34, "tblExtFileTransColumn_colsC34");
            // 
            // tblExtFileTransColumn_colsC35
            // 
            this.tblExtFileTransColumn_colsC35.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC35.Name = "tblExtFileTransColumn_colsC35";
            this.tblExtFileTransColumn_colsC35.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC35.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC35.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC35.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC35.NamedProperties.Put("SqlColumn", "C35");
            this.tblExtFileTransColumn_colsC35.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC35.Position = 41;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC35, "tblExtFileTransColumn_colsC35");
            // 
            // tblExtFileTransColumn_colsC36
            // 
            this.tblExtFileTransColumn_colsC36.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC36.Name = "tblExtFileTransColumn_colsC36";
            this.tblExtFileTransColumn_colsC36.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC36.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC36.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC36.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC36.NamedProperties.Put("SqlColumn", "C36");
            this.tblExtFileTransColumn_colsC36.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC36.Position = 42;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC36, "tblExtFileTransColumn_colsC36");
            // 
            // tblExtFileTransColumn_colsC37
            // 
            this.tblExtFileTransColumn_colsC37.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC37.Name = "tblExtFileTransColumn_colsC37";
            this.tblExtFileTransColumn_colsC37.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC37.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC37.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC37.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC37.NamedProperties.Put("SqlColumn", "C37");
            this.tblExtFileTransColumn_colsC37.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC37.Position = 43;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC37, "tblExtFileTransColumn_colsC37");
            // 
            // tblExtFileTransColumn_colsC38
            // 
            this.tblExtFileTransColumn_colsC38.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC38.Name = "tblExtFileTransColumn_colsC38";
            this.tblExtFileTransColumn_colsC38.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC38.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC38.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC38.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC38.NamedProperties.Put("SqlColumn", "C38");
            this.tblExtFileTransColumn_colsC38.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC38.Position = 44;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC38, "tblExtFileTransColumn_colsC38");
            // 
            // tblExtFileTransColumn_colsC39
            // 
            this.tblExtFileTransColumn_colsC39.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC39.Name = "tblExtFileTransColumn_colsC39";
            this.tblExtFileTransColumn_colsC39.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC39.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC39.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC39.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC39.NamedProperties.Put("SqlColumn", "C39");
            this.tblExtFileTransColumn_colsC39.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC39.Position = 45;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC39, "tblExtFileTransColumn_colsC39");
            // 
            // tblExtFileTransColumn_colsC40
            // 
            this.tblExtFileTransColumn_colsC40.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC40.Name = "tblExtFileTransColumn_colsC40";
            this.tblExtFileTransColumn_colsC40.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC40.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC40.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC40.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC40.NamedProperties.Put("SqlColumn", "C40");
            this.tblExtFileTransColumn_colsC40.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC40.Position = 46;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC40, "tblExtFileTransColumn_colsC40");
            // 
            // tblExtFileTransColumn_colsC41
            // 
            this.tblExtFileTransColumn_colsC41.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC41.Name = "tblExtFileTransColumn_colsC41";
            this.tblExtFileTransColumn_colsC41.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC41.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC41.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC41.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC41.NamedProperties.Put("SqlColumn", "C41");
            this.tblExtFileTransColumn_colsC41.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC41.Position = 47;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC41, "tblExtFileTransColumn_colsC41");
            // 
            // tblExtFileTransColumn_colsC42
            // 
            this.tblExtFileTransColumn_colsC42.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC42.Name = "tblExtFileTransColumn_colsC42";
            this.tblExtFileTransColumn_colsC42.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC42.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC42.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC42.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC42.NamedProperties.Put("SqlColumn", "C42");
            this.tblExtFileTransColumn_colsC42.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC42.Position = 48;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC42, "tblExtFileTransColumn_colsC42");
            // 
            // tblExtFileTransColumn_colsC43
            // 
            this.tblExtFileTransColumn_colsC43.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC43.Name = "tblExtFileTransColumn_colsC43";
            this.tblExtFileTransColumn_colsC43.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC43.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC43.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC43.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC43.NamedProperties.Put("SqlColumn", "C43");
            this.tblExtFileTransColumn_colsC43.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC43.Position = 49;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC43, "tblExtFileTransColumn_colsC43");
            // 
            // tblExtFileTransColumn_colsC44
            // 
            this.tblExtFileTransColumn_colsC44.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC44.Name = "tblExtFileTransColumn_colsC44";
            this.tblExtFileTransColumn_colsC44.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC44.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC44.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC44.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC44.NamedProperties.Put("SqlColumn", "C44");
            this.tblExtFileTransColumn_colsC44.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC44.Position = 50;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC44, "tblExtFileTransColumn_colsC44");
            // 
            // tblExtFileTransColumn_colsC45
            // 
            this.tblExtFileTransColumn_colsC45.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC45.Name = "tblExtFileTransColumn_colsC45";
            this.tblExtFileTransColumn_colsC45.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC45.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC45.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC45.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC45.NamedProperties.Put("SqlColumn", "C45");
            this.tblExtFileTransColumn_colsC45.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC45.Position = 51;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC45, "tblExtFileTransColumn_colsC45");
            // 
            // tblExtFileTransColumn_colsC46
            // 
            this.tblExtFileTransColumn_colsC46.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC46.Name = "tblExtFileTransColumn_colsC46";
            this.tblExtFileTransColumn_colsC46.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC46.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC46.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC46.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC46.NamedProperties.Put("SqlColumn", "C46");
            this.tblExtFileTransColumn_colsC46.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC46.Position = 52;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC46, "tblExtFileTransColumn_colsC46");
            // 
            // tblExtFileTransColumn_colsC47
            // 
            this.tblExtFileTransColumn_colsC47.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC47.Name = "tblExtFileTransColumn_colsC47";
            this.tblExtFileTransColumn_colsC47.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC47.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC47.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC47.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC47.NamedProperties.Put("SqlColumn", "C47");
            this.tblExtFileTransColumn_colsC47.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC47.Position = 53;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC47, "tblExtFileTransColumn_colsC47");
            // 
            // tblExtFileTransColumn_colsC48
            // 
            this.tblExtFileTransColumn_colsC48.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC48.Name = "tblExtFileTransColumn_colsC48";
            this.tblExtFileTransColumn_colsC48.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC48.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC48.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC48.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC48.NamedProperties.Put("SqlColumn", "C48");
            this.tblExtFileTransColumn_colsC48.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC48.Position = 54;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC48, "tblExtFileTransColumn_colsC48");
            // 
            // tblExtFileTransColumn_colsC49
            // 
            this.tblExtFileTransColumn_colsC49.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC49.Name = "tblExtFileTransColumn_colsC49";
            this.tblExtFileTransColumn_colsC49.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC49.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC49.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC49.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC49.NamedProperties.Put("SqlColumn", "C49");
            this.tblExtFileTransColumn_colsC49.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC49.Position = 55;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC49, "tblExtFileTransColumn_colsC49");
            // 
            // tblExtFileTransColumn_colsC50
            // 
            this.tblExtFileTransColumn_colsC50.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC50.Name = "tblExtFileTransColumn_colsC50";
            this.tblExtFileTransColumn_colsC50.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC50.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC50.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC50.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC50.NamedProperties.Put("SqlColumn", "C50");
            this.tblExtFileTransColumn_colsC50.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC50.Position = 56;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC50, "tblExtFileTransColumn_colsC50");
            // 
            // tblExtFileTransColumn_colsC51
            // 
            this.tblExtFileTransColumn_colsC51.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC51.Name = "tblExtFileTransColumn_colsC51";
            this.tblExtFileTransColumn_colsC51.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC51.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC51.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC51.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC51.NamedProperties.Put("SqlColumn", "C51");
            this.tblExtFileTransColumn_colsC51.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC51.Position = 57;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC51, "tblExtFileTransColumn_colsC51");
            // 
            // tblExtFileTransColumn_colsC52
            // 
            this.tblExtFileTransColumn_colsC52.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC52.Name = "tblExtFileTransColumn_colsC52";
            this.tblExtFileTransColumn_colsC52.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC52.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC52.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC52.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC52.NamedProperties.Put("SqlColumn", "C52");
            this.tblExtFileTransColumn_colsC52.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC52.Position = 58;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC52, "tblExtFileTransColumn_colsC52");
            // 
            // tblExtFileTransColumn_colsC53
            // 
            this.tblExtFileTransColumn_colsC53.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC53.Name = "tblExtFileTransColumn_colsC53";
            this.tblExtFileTransColumn_colsC53.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC53.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC53.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC53.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC53.NamedProperties.Put("SqlColumn", "C53");
            this.tblExtFileTransColumn_colsC53.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC53.Position = 59;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC53, "tblExtFileTransColumn_colsC53");
            // 
            // tblExtFileTransColumn_colsC54
            // 
            this.tblExtFileTransColumn_colsC54.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC54.Name = "tblExtFileTransColumn_colsC54";
            this.tblExtFileTransColumn_colsC54.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC54.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC54.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC54.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC54.NamedProperties.Put("SqlColumn", "C54");
            this.tblExtFileTransColumn_colsC54.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC54.Position = 60;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC54, "tblExtFileTransColumn_colsC54");
            // 
            // tblExtFileTransColumn_colsC55
            // 
            this.tblExtFileTransColumn_colsC55.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC55.Name = "tblExtFileTransColumn_colsC55";
            this.tblExtFileTransColumn_colsC55.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC55.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC55.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC55.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC55.NamedProperties.Put("SqlColumn", "C55");
            this.tblExtFileTransColumn_colsC55.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC55.Position = 61;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC55, "tblExtFileTransColumn_colsC55");
            // 
            // tblExtFileTransColumn_colsC56
            // 
            this.tblExtFileTransColumn_colsC56.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC56.Name = "tblExtFileTransColumn_colsC56";
            this.tblExtFileTransColumn_colsC56.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC56.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC56.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC56.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC56.NamedProperties.Put("SqlColumn", "C56");
            this.tblExtFileTransColumn_colsC56.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC56.Position = 62;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC56, "tblExtFileTransColumn_colsC56");
            // 
            // tblExtFileTransColumn_colsC57
            // 
            this.tblExtFileTransColumn_colsC57.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC57.Name = "tblExtFileTransColumn_colsC57";
            this.tblExtFileTransColumn_colsC57.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC57.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC57.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC57.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC57.NamedProperties.Put("SqlColumn", "C57");
            this.tblExtFileTransColumn_colsC57.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC57.Position = 63;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC57, "tblExtFileTransColumn_colsC57");
            // 
            // tblExtFileTransColumn_colsC58
            // 
            this.tblExtFileTransColumn_colsC58.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC58.Name = "tblExtFileTransColumn_colsC58";
            this.tblExtFileTransColumn_colsC58.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC58.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC58.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC58.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC58.NamedProperties.Put("SqlColumn", "C58");
            this.tblExtFileTransColumn_colsC58.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC58.Position = 64;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC58, "tblExtFileTransColumn_colsC58");
            // 
            // tblExtFileTransColumn_colsC59
            // 
            this.tblExtFileTransColumn_colsC59.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC59.Name = "tblExtFileTransColumn_colsC59";
            this.tblExtFileTransColumn_colsC59.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC59.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC59.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC59.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC59.NamedProperties.Put("SqlColumn", "C59");
            this.tblExtFileTransColumn_colsC59.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC59.Position = 65;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC59, "tblExtFileTransColumn_colsC59");
            // 
            // tblExtFileTransColumn_colsC60
            // 
            this.tblExtFileTransColumn_colsC60.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC60.Name = "tblExtFileTransColumn_colsC60";
            this.tblExtFileTransColumn_colsC60.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC60.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC60.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC60.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC60.NamedProperties.Put("SqlColumn", "C60");
            this.tblExtFileTransColumn_colsC60.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC60.Position = 66;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC60, "tblExtFileTransColumn_colsC60");
            // 
            // tblExtFileTransColumn_colsC61
            // 
            this.tblExtFileTransColumn_colsC61.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC61.Name = "tblExtFileTransColumn_colsC61";
            this.tblExtFileTransColumn_colsC61.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC61.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC61.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC61.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC61.NamedProperties.Put("SqlColumn", "C61");
            this.tblExtFileTransColumn_colsC61.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC61.Position = 67;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC61, "tblExtFileTransColumn_colsC61");
            // 
            // tblExtFileTransColumn_colsC62
            // 
            this.tblExtFileTransColumn_colsC62.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC62.Name = "tblExtFileTransColumn_colsC62";
            this.tblExtFileTransColumn_colsC62.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC62.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC62.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC62.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC62.NamedProperties.Put("SqlColumn", "C62");
            this.tblExtFileTransColumn_colsC62.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC62.Position = 68;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC62, "tblExtFileTransColumn_colsC62");
            // 
            // tblExtFileTransColumn_colsC63
            // 
            this.tblExtFileTransColumn_colsC63.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC63.Name = "tblExtFileTransColumn_colsC63";
            this.tblExtFileTransColumn_colsC63.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC63.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC63.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC63.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC63.NamedProperties.Put("SqlColumn", "C63");
            this.tblExtFileTransColumn_colsC63.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC63.Position = 69;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC63, "tblExtFileTransColumn_colsC63");
            // 
            // tblExtFileTransColumn_colsC64
            // 
            this.tblExtFileTransColumn_colsC64.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC64.Name = "tblExtFileTransColumn_colsC64";
            this.tblExtFileTransColumn_colsC64.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC64.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC64.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC64.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC64.NamedProperties.Put("SqlColumn", "C64");
            this.tblExtFileTransColumn_colsC64.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC64.Position = 70;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC64, "tblExtFileTransColumn_colsC64");
            // 
            // tblExtFileTransColumn_colsC65
            // 
            this.tblExtFileTransColumn_colsC65.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC65.Name = "tblExtFileTransColumn_colsC65";
            this.tblExtFileTransColumn_colsC65.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC65.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC65.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC65.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC65.NamedProperties.Put("SqlColumn", "C65");
            this.tblExtFileTransColumn_colsC65.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC65.Position = 71;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC65, "tblExtFileTransColumn_colsC65");
            // 
            // tblExtFileTransColumn_colsC66
            // 
            this.tblExtFileTransColumn_colsC66.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC66.Name = "tblExtFileTransColumn_colsC66";
            this.tblExtFileTransColumn_colsC66.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC66.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC66.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC66.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC66.NamedProperties.Put("SqlColumn", "C66");
            this.tblExtFileTransColumn_colsC66.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC66.Position = 72;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC66, "tblExtFileTransColumn_colsC66");
            // 
            // tblExtFileTransColumn_colsC67
            // 
            this.tblExtFileTransColumn_colsC67.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC67.Name = "tblExtFileTransColumn_colsC67";
            this.tblExtFileTransColumn_colsC67.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC67.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC67.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC67.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC67.NamedProperties.Put("SqlColumn", "C67");
            this.tblExtFileTransColumn_colsC67.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC67.Position = 73;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC67, "tblExtFileTransColumn_colsC67");
            // 
            // tblExtFileTransColumn_colsC68
            // 
            this.tblExtFileTransColumn_colsC68.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC68.Name = "tblExtFileTransColumn_colsC68";
            this.tblExtFileTransColumn_colsC68.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC68.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC68.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC68.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC68.NamedProperties.Put("SqlColumn", "C68");
            this.tblExtFileTransColumn_colsC68.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC68.Position = 74;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC68, "tblExtFileTransColumn_colsC68");
            // 
            // tblExtFileTransColumn_colsC69
            // 
            this.tblExtFileTransColumn_colsC69.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC69.Name = "tblExtFileTransColumn_colsC69";
            this.tblExtFileTransColumn_colsC69.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC69.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC69.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC69.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC69.NamedProperties.Put("SqlColumn", "C69");
            this.tblExtFileTransColumn_colsC69.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC69.Position = 75;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC69, "tblExtFileTransColumn_colsC69");
            // 
            // tblExtFileTransColumn_colsC70
            // 
            this.tblExtFileTransColumn_colsC70.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC70.Name = "tblExtFileTransColumn_colsC70";
            this.tblExtFileTransColumn_colsC70.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC70.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC70.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC70.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC70.NamedProperties.Put("SqlColumn", "C70");
            this.tblExtFileTransColumn_colsC70.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC70.Position = 76;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC70, "tblExtFileTransColumn_colsC70");
            // 
            // tblExtFileTransColumn_colsC71
            // 
            this.tblExtFileTransColumn_colsC71.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC71.Name = "tblExtFileTransColumn_colsC71";
            this.tblExtFileTransColumn_colsC71.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC71.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC71.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC71.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC71.NamedProperties.Put("SqlColumn", "C71");
            this.tblExtFileTransColumn_colsC71.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC71.Position = 77;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC71, "tblExtFileTransColumn_colsC71");
            // 
            // tblExtFileTransColumn_colsC72
            // 
            this.tblExtFileTransColumn_colsC72.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC72.Name = "tblExtFileTransColumn_colsC72";
            this.tblExtFileTransColumn_colsC72.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC72.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC72.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC72.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC72.NamedProperties.Put("SqlColumn", "C72");
            this.tblExtFileTransColumn_colsC72.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC72.Position = 78;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC72, "tblExtFileTransColumn_colsC72");
            // 
            // tblExtFileTransColumn_colsC73
            // 
            this.tblExtFileTransColumn_colsC73.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC73.Name = "tblExtFileTransColumn_colsC73";
            this.tblExtFileTransColumn_colsC73.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC73.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC73.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC73.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC73.NamedProperties.Put("SqlColumn", "C73");
            this.tblExtFileTransColumn_colsC73.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC73.Position = 79;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC73, "tblExtFileTransColumn_colsC73");
            // 
            // tblExtFileTransColumn_colsC74
            // 
            this.tblExtFileTransColumn_colsC74.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC74.Name = "tblExtFileTransColumn_colsC74";
            this.tblExtFileTransColumn_colsC74.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC74.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC74.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC74.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC74.NamedProperties.Put("SqlColumn", "C74");
            this.tblExtFileTransColumn_colsC74.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC74.Position = 80;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC74, "tblExtFileTransColumn_colsC74");
            // 
            // tblExtFileTransColumn_colsC75
            // 
            this.tblExtFileTransColumn_colsC75.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC75.Name = "tblExtFileTransColumn_colsC75";
            this.tblExtFileTransColumn_colsC75.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC75.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC75.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC75.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC75.NamedProperties.Put("SqlColumn", "C75");
            this.tblExtFileTransColumn_colsC75.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC75.Position = 81;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC75, "tblExtFileTransColumn_colsC75");
            // 
            // tblExtFileTransColumn_colsC76
            // 
            this.tblExtFileTransColumn_colsC76.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC76.Name = "tblExtFileTransColumn_colsC76";
            this.tblExtFileTransColumn_colsC76.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC76.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC76.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC76.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC76.NamedProperties.Put("SqlColumn", "C76");
            this.tblExtFileTransColumn_colsC76.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC76.Position = 82;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC76, "tblExtFileTransColumn_colsC76");
            // 
            // tblExtFileTransColumn_colsC77
            // 
            this.tblExtFileTransColumn_colsC77.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC77.Name = "tblExtFileTransColumn_colsC77";
            this.tblExtFileTransColumn_colsC77.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC77.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC77.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC77.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC77.NamedProperties.Put("SqlColumn", "C77");
            this.tblExtFileTransColumn_colsC77.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC77.Position = 83;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC77, "tblExtFileTransColumn_colsC77");
            // 
            // tblExtFileTransColumn_colsC78
            // 
            this.tblExtFileTransColumn_colsC78.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC78.Name = "tblExtFileTransColumn_colsC78";
            this.tblExtFileTransColumn_colsC78.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC78.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC78.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC78.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC78.NamedProperties.Put("SqlColumn", "C78");
            this.tblExtFileTransColumn_colsC78.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC78.Position = 84;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC78, "tblExtFileTransColumn_colsC78");
            // 
            // tblExtFileTransColumn_colsC79
            // 
            this.tblExtFileTransColumn_colsC79.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC79.Name = "tblExtFileTransColumn_colsC79";
            this.tblExtFileTransColumn_colsC79.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC79.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC79.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC79.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC79.NamedProperties.Put("SqlColumn", "C79");
            this.tblExtFileTransColumn_colsC79.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC79.Position = 85;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC79, "tblExtFileTransColumn_colsC79");
            // 
            // tblExtFileTransColumn_colsC80
            // 
            this.tblExtFileTransColumn_colsC80.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC80.Name = "tblExtFileTransColumn_colsC80";
            this.tblExtFileTransColumn_colsC80.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC80.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC80.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC80.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC80.NamedProperties.Put("SqlColumn", "C80");
            this.tblExtFileTransColumn_colsC80.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC80.Position = 86;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC80, "tblExtFileTransColumn_colsC80");
            // 
            // tblExtFileTransColumn_colsC81
            // 
            this.tblExtFileTransColumn_colsC81.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC81.Name = "tblExtFileTransColumn_colsC81";
            this.tblExtFileTransColumn_colsC81.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC81.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC81.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC81.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC81.NamedProperties.Put("SqlColumn", "C81");
            this.tblExtFileTransColumn_colsC81.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC81.Position = 87;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC81, "tblExtFileTransColumn_colsC81");
            // 
            // tblExtFileTransColumn_colsC82
            // 
            this.tblExtFileTransColumn_colsC82.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC82.Name = "tblExtFileTransColumn_colsC82";
            this.tblExtFileTransColumn_colsC82.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC82.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC82.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC82.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC82.NamedProperties.Put("SqlColumn", "C82");
            this.tblExtFileTransColumn_colsC82.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC82.Position = 88;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC82, "tblExtFileTransColumn_colsC82");
            // 
            // tblExtFileTransColumn_colsC83
            // 
            this.tblExtFileTransColumn_colsC83.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC83.Name = "tblExtFileTransColumn_colsC83";
            this.tblExtFileTransColumn_colsC83.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC83.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC83.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC83.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC83.NamedProperties.Put("SqlColumn", "C83");
            this.tblExtFileTransColumn_colsC83.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC83.Position = 89;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC83, "tblExtFileTransColumn_colsC83");
            // 
            // tblExtFileTransColumn_colsC84
            // 
            this.tblExtFileTransColumn_colsC84.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC84.Name = "tblExtFileTransColumn_colsC84";
            this.tblExtFileTransColumn_colsC84.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC84.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC84.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC84.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC84.NamedProperties.Put("SqlColumn", "C84");
            this.tblExtFileTransColumn_colsC84.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC84.Position = 90;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC84, "tblExtFileTransColumn_colsC84");
            // 
            // tblExtFileTransColumn_colsC85
            // 
            this.tblExtFileTransColumn_colsC85.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC85.Name = "tblExtFileTransColumn_colsC85";
            this.tblExtFileTransColumn_colsC85.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC85.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC85.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC85.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC85.NamedProperties.Put("SqlColumn", "C85");
            this.tblExtFileTransColumn_colsC85.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC85.Position = 91;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC85, "tblExtFileTransColumn_colsC85");
            // 
            // tblExtFileTransColumn_colsC86
            // 
            this.tblExtFileTransColumn_colsC86.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC86.Name = "tblExtFileTransColumn_colsC86";
            this.tblExtFileTransColumn_colsC86.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC86.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC86.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC86.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC86.NamedProperties.Put("SqlColumn", "C86");
            this.tblExtFileTransColumn_colsC86.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC86.Position = 92;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC86, "tblExtFileTransColumn_colsC86");
            // 
            // tblExtFileTransColumn_colsC87
            // 
            this.tblExtFileTransColumn_colsC87.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC87.Name = "tblExtFileTransColumn_colsC87";
            this.tblExtFileTransColumn_colsC87.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC87.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC87.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC87.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC87.NamedProperties.Put("SqlColumn", "C87");
            this.tblExtFileTransColumn_colsC87.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC87.Position = 93;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC87, "tblExtFileTransColumn_colsC87");
            // 
            // tblExtFileTransColumn_colsC88
            // 
            this.tblExtFileTransColumn_colsC88.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC88.Name = "tblExtFileTransColumn_colsC88";
            this.tblExtFileTransColumn_colsC88.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC88.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC88.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC88.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC88.NamedProperties.Put("SqlColumn", "C88");
            this.tblExtFileTransColumn_colsC88.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC88.Position = 94;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC88, "tblExtFileTransColumn_colsC88");
            // 
            // tblExtFileTransColumn_colsC89
            // 
            this.tblExtFileTransColumn_colsC89.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC89.Name = "tblExtFileTransColumn_colsC89";
            this.tblExtFileTransColumn_colsC89.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC89.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC89.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC89.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC89.NamedProperties.Put("SqlColumn", "C89");
            this.tblExtFileTransColumn_colsC89.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC89.Position = 95;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC89, "tblExtFileTransColumn_colsC89");
            // 
            // tblExtFileTransColumn_colsC90
            // 
            this.tblExtFileTransColumn_colsC90.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC90.Name = "tblExtFileTransColumn_colsC90";
            this.tblExtFileTransColumn_colsC90.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC90.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC90.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC90.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC90.NamedProperties.Put("SqlColumn", "C90");
            this.tblExtFileTransColumn_colsC90.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC90.Position = 96;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC90, "tblExtFileTransColumn_colsC90");
            // 
            // tblExtFileTransColumn_colsC91
            // 
            this.tblExtFileTransColumn_colsC91.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC91.Name = "tblExtFileTransColumn_colsC91";
            this.tblExtFileTransColumn_colsC91.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC91.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC91.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC91.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC91.NamedProperties.Put("SqlColumn", "C91");
            this.tblExtFileTransColumn_colsC91.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC91.Position = 97;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC91, "tblExtFileTransColumn_colsC91");
            // 
            // tblExtFileTransColumn_colsC92
            // 
            this.tblExtFileTransColumn_colsC92.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC92.Name = "tblExtFileTransColumn_colsC92";
            this.tblExtFileTransColumn_colsC92.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC92.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC92.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC92.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC92.NamedProperties.Put("SqlColumn", "C92");
            this.tblExtFileTransColumn_colsC92.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC92.Position = 98;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC92, "tblExtFileTransColumn_colsC92");
            // 
            // tblExtFileTransColumn_colsC93
            // 
            this.tblExtFileTransColumn_colsC93.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC93.Name = "tblExtFileTransColumn_colsC93";
            this.tblExtFileTransColumn_colsC93.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC93.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC93.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC93.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC93.NamedProperties.Put("SqlColumn", "C93");
            this.tblExtFileTransColumn_colsC93.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC93.Position = 99;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC93, "tblExtFileTransColumn_colsC93");
            // 
            // tblExtFileTransColumn_colsC94
            // 
            this.tblExtFileTransColumn_colsC94.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC94.Name = "tblExtFileTransColumn_colsC94";
            this.tblExtFileTransColumn_colsC94.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC94.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC94.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC94.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC94.NamedProperties.Put("SqlColumn", "C94");
            this.tblExtFileTransColumn_colsC94.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC94.Position = 100;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC94, "tblExtFileTransColumn_colsC94");
            // 
            // tblExtFileTransColumn_colsC95
            // 
            this.tblExtFileTransColumn_colsC95.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC95.Name = "tblExtFileTransColumn_colsC95";
            this.tblExtFileTransColumn_colsC95.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC95.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC95.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC95.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC95.NamedProperties.Put("SqlColumn", "C95");
            this.tblExtFileTransColumn_colsC95.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC95.Position = 101;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC95, "tblExtFileTransColumn_colsC95");
            // 
            // tblExtFileTransColumn_colsC96
            // 
            this.tblExtFileTransColumn_colsC96.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC96.Name = "tblExtFileTransColumn_colsC96";
            this.tblExtFileTransColumn_colsC96.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC96.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC96.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC96.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC96.NamedProperties.Put("SqlColumn", "C96");
            this.tblExtFileTransColumn_colsC96.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC96.Position = 102;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC96, "tblExtFileTransColumn_colsC96");
            // 
            // tblExtFileTransColumn_colsC97
            // 
            this.tblExtFileTransColumn_colsC97.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC97.Name = "tblExtFileTransColumn_colsC97";
            this.tblExtFileTransColumn_colsC97.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC97.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC97.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC97.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC97.NamedProperties.Put("SqlColumn", "C97");
            this.tblExtFileTransColumn_colsC97.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC97.Position = 103;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC97, "tblExtFileTransColumn_colsC97");
            // 
            // tblExtFileTransColumn_colsC98
            // 
            this.tblExtFileTransColumn_colsC98.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC98.Name = "tblExtFileTransColumn_colsC98";
            this.tblExtFileTransColumn_colsC98.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC98.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC98.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC98.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC98.NamedProperties.Put("SqlColumn", "C98");
            this.tblExtFileTransColumn_colsC98.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC98.Position = 104;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC98, "tblExtFileTransColumn_colsC98");
            // 
            // tblExtFileTransColumn_colsC99
            // 
            this.tblExtFileTransColumn_colsC99.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC99.Name = "tblExtFileTransColumn_colsC99";
            this.tblExtFileTransColumn_colsC99.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC99.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC99.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC99.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colsC99.NamedProperties.Put("SqlColumn", "C99");
            this.tblExtFileTransColumn_colsC99.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colsC99.Position = 105;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC99, "tblExtFileTransColumn_colsC99");
            // 
            // tblExtFileTransColumn_colsC100
            // 
            this.tblExtFileTransColumn_colsC100.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC100.Name = "tblExtFileTransColumn_colsC100";
            this.tblExtFileTransColumn_colsC100.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC100.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC100.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC100.NamedProperties.Put("SqlColumn", "C100");
            this.tblExtFileTransColumn_colsC100.Position = 106;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC100, "tblExtFileTransColumn_colsC100");
            // 
            // tblExtFileTransColumn_colsC101
            // 
            this.tblExtFileTransColumn_colsC101.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC101.Name = "tblExtFileTransColumn_colsC101";
            this.tblExtFileTransColumn_colsC101.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC101.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC101.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC101.NamedProperties.Put("SqlColumn", "C101");
            this.tblExtFileTransColumn_colsC101.Position = 107;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC101, "tblExtFileTransColumn_colsC101");
            // 
            // tblExtFileTransColumn_colsC102
            // 
            this.tblExtFileTransColumn_colsC102.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC102.Name = "tblExtFileTransColumn_colsC102";
            this.tblExtFileTransColumn_colsC102.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC102.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC102.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC102.NamedProperties.Put("SqlColumn", "C102");
            this.tblExtFileTransColumn_colsC102.Position = 108;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC102, "tblExtFileTransColumn_colsC102");
            // 
            // tblExtFileTransColumn_colsC103
            // 
            this.tblExtFileTransColumn_colsC103.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC103.Name = "tblExtFileTransColumn_colsC103";
            this.tblExtFileTransColumn_colsC103.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC103.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC103.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC103.NamedProperties.Put("SqlColumn", "C103");
            this.tblExtFileTransColumn_colsC103.Position = 109;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC103, "tblExtFileTransColumn_colsC103");
            // 
            // tblExtFileTransColumn_colsC104
            // 
            this.tblExtFileTransColumn_colsC104.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC104.Name = "tblExtFileTransColumn_colsC104";
            this.tblExtFileTransColumn_colsC104.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC104.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC104.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC104.NamedProperties.Put("SqlColumn", "C104");
            this.tblExtFileTransColumn_colsC104.Position = 110;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC104, "tblExtFileTransColumn_colsC104");
            // 
            // tblExtFileTransColumn_colsC105
            // 
            this.tblExtFileTransColumn_colsC105.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC105.Name = "tblExtFileTransColumn_colsC105";
            this.tblExtFileTransColumn_colsC105.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC105.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC105.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC105.NamedProperties.Put("SqlColumn", "C105");
            this.tblExtFileTransColumn_colsC105.Position = 111;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC105, "tblExtFileTransColumn_colsC105");
            // 
            // tblExtFileTransColumn_colsC106
            // 
            this.tblExtFileTransColumn_colsC106.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC106.Name = "tblExtFileTransColumn_colsC106";
            this.tblExtFileTransColumn_colsC106.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC106.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC106.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC106.NamedProperties.Put("SqlColumn", "C106");
            this.tblExtFileTransColumn_colsC106.Position = 112;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC106, "tblExtFileTransColumn_colsC106");
            // 
            // tblExtFileTransColumn_colsC107
            // 
            this.tblExtFileTransColumn_colsC107.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC107.Name = "tblExtFileTransColumn_colsC107";
            this.tblExtFileTransColumn_colsC107.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC107.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC107.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC107.NamedProperties.Put("SqlColumn", "C107");
            this.tblExtFileTransColumn_colsC107.Position = 113;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC107, "tblExtFileTransColumn_colsC107");
            // 
            // tblExtFileTransColumn_colsC108
            // 
            this.tblExtFileTransColumn_colsC108.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC108.Name = "tblExtFileTransColumn_colsC108";
            this.tblExtFileTransColumn_colsC108.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC108.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC108.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC108.NamedProperties.Put("SqlColumn", "C108");
            this.tblExtFileTransColumn_colsC108.Position = 114;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC108, "tblExtFileTransColumn_colsC108");
            // 
            // tblExtFileTransColumn_colsC109
            // 
            this.tblExtFileTransColumn_colsC109.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC109.Name = "tblExtFileTransColumn_colsC109";
            this.tblExtFileTransColumn_colsC109.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC109.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC109.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC109.NamedProperties.Put("SqlColumn", "C109");
            this.tblExtFileTransColumn_colsC109.Position = 115;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC109, "tblExtFileTransColumn_colsC109");
            // 
            // tblExtFileTransColumn_colsC110
            // 
            this.tblExtFileTransColumn_colsC110.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC110.Name = "tblExtFileTransColumn_colsC110";
            this.tblExtFileTransColumn_colsC110.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC110.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC110.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC110.NamedProperties.Put("SqlColumn", "C110");
            this.tblExtFileTransColumn_colsC110.Position = 116;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC110, "tblExtFileTransColumn_colsC110");
            // 
            // tblExtFileTransColumn_colsC111
            // 
            this.tblExtFileTransColumn_colsC111.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC111.Name = "tblExtFileTransColumn_colsC111";
            this.tblExtFileTransColumn_colsC111.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC111.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC111.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC111.NamedProperties.Put("SqlColumn", "C111");
            this.tblExtFileTransColumn_colsC111.Position = 117;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC111, "tblExtFileTransColumn_colsC111");
            // 
            // tblExtFileTransColumn_colsC112
            // 
            this.tblExtFileTransColumn_colsC112.MaxLength = 4000;
            this.tblExtFileTransColumn_colsC112.Name = "tblExtFileTransColumn_colsC112";
            this.tblExtFileTransColumn_colsC112.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC112.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC112.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC112.NamedProperties.Put("SqlColumn", "C112");
            this.tblExtFileTransColumn_colsC112.Position = 118;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC112, "tblExtFileTransColumn_colsC112");
            // 
            // tblExtFileTransColumn_colsC113
            // 
            this.tblExtFileTransColumn_colsC113.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC113.Name = "tblExtFileTransColumn_colsC113";
            this.tblExtFileTransColumn_colsC113.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC113.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC113.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC113.NamedProperties.Put("SqlColumn", "C113");
            this.tblExtFileTransColumn_colsC113.Position = 119;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC113, "tblExtFileTransColumn_colsC113");
            // 
            // tblExtFileTransColumn_colsC114
            // 
            this.tblExtFileTransColumn_colsC114.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC114.Name = "tblExtFileTransColumn_colsC114";
            this.tblExtFileTransColumn_colsC114.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC114.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC114.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC114.NamedProperties.Put("SqlColumn", "C114");
            this.tblExtFileTransColumn_colsC114.Position = 120;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC114, "tblExtFileTransColumn_colsC114");
            // 
            // tblExtFileTransColumn_colsC115
            // 
            this.tblExtFileTransColumn_colsC115.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC115.Name = "tblExtFileTransColumn_colsC115";
            this.tblExtFileTransColumn_colsC115.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC115.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC115.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC115.NamedProperties.Put("SqlColumn", "C115");
            this.tblExtFileTransColumn_colsC115.Position = 121;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC115, "tblExtFileTransColumn_colsC115");
            // 
            // tblExtFileTransColumn_colsC116
            // 
            this.tblExtFileTransColumn_colsC116.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC116.Name = "tblExtFileTransColumn_colsC116";
            this.tblExtFileTransColumn_colsC116.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC116.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC116.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC116.NamedProperties.Put("SqlColumn", "C116");
            this.tblExtFileTransColumn_colsC116.Position = 122;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC116, "tblExtFileTransColumn_colsC116");
            // 
            // tblExtFileTransColumn_colsC117
            // 
            this.tblExtFileTransColumn_colsC117.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC117.Name = "tblExtFileTransColumn_colsC117";
            this.tblExtFileTransColumn_colsC117.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC117.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC117.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC117.NamedProperties.Put("SqlColumn", "C117");
            this.tblExtFileTransColumn_colsC117.Position = 123;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC117, "tblExtFileTransColumn_colsC117");
            // 
            // tblExtFileTransColumn_colsC118
            // 
            this.tblExtFileTransColumn_colsC118.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC118.Name = "tblExtFileTransColumn_colsC118";
            this.tblExtFileTransColumn_colsC118.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC118.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC118.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC118.NamedProperties.Put("SqlColumn", "C118");
            this.tblExtFileTransColumn_colsC118.Position = 124;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC118, "tblExtFileTransColumn_colsC118");
            // 
            // tblExtFileTransColumn_colsC119
            // 
            this.tblExtFileTransColumn_colsC119.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC119.Name = "tblExtFileTransColumn_colsC119";
            this.tblExtFileTransColumn_colsC119.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC119.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC119.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC119.NamedProperties.Put("SqlColumn", "C119");
            this.tblExtFileTransColumn_colsC119.Position = 125;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC119, "tblExtFileTransColumn_colsC119");
            // 
            // tblExtFileTransColumn_colsC120
            // 
            this.tblExtFileTransColumn_colsC120.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC120.Name = "tblExtFileTransColumn_colsC120";
            this.tblExtFileTransColumn_colsC120.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC120.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC120.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC120.NamedProperties.Put("SqlColumn", "C120");
            this.tblExtFileTransColumn_colsC120.Position = 126;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC120, "tblExtFileTransColumn_colsC120");
            // 
            // tblExtFileTransColumn_colsC121
            // 
            this.tblExtFileTransColumn_colsC121.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC121.Name = "tblExtFileTransColumn_colsC121";
            this.tblExtFileTransColumn_colsC121.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC121.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC121.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC121.NamedProperties.Put("SqlColumn", "C121");
            this.tblExtFileTransColumn_colsC121.Position = 127;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC121, "tblExtFileTransColumn_colsC121");
            // 
            // tblExtFileTransColumn_colsC122
            // 
            this.tblExtFileTransColumn_colsC122.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC122.Name = "tblExtFileTransColumn_colsC122";
            this.tblExtFileTransColumn_colsC122.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC122.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC122.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC122.NamedProperties.Put("SqlColumn", "C122");
            this.tblExtFileTransColumn_colsC122.Position = 128;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC122, "tblExtFileTransColumn_colsC122");
            // 
            // tblExtFileTransColumn_colsC123
            // 
            this.tblExtFileTransColumn_colsC123.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC123.Name = "tblExtFileTransColumn_colsC123";
            this.tblExtFileTransColumn_colsC123.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC123.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC123.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC123.NamedProperties.Put("SqlColumn", "C123");
            this.tblExtFileTransColumn_colsC123.Position = 129;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC123, "tblExtFileTransColumn_colsC123");
            // 
            // tblExtFileTransColumn_colsC124
            // 
            this.tblExtFileTransColumn_colsC124.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC124.Name = "tblExtFileTransColumn_colsC124";
            this.tblExtFileTransColumn_colsC124.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC124.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC124.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC124.NamedProperties.Put("SqlColumn", "C124");
            this.tblExtFileTransColumn_colsC124.Position = 130;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC124, "tblExtFileTransColumn_colsC124");
            // 
            // tblExtFileTransColumn_colsC125
            // 
            this.tblExtFileTransColumn_colsC125.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC125.Name = "tblExtFileTransColumn_colsC125";
            this.tblExtFileTransColumn_colsC125.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC125.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC125.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC125.NamedProperties.Put("SqlColumn", "C125");
            this.tblExtFileTransColumn_colsC125.Position = 131;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC125, "tblExtFileTransColumn_colsC125");
            // 
            // tblExtFileTransColumn_colsC126
            // 
            this.tblExtFileTransColumn_colsC126.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC126.Name = "tblExtFileTransColumn_colsC126";
            this.tblExtFileTransColumn_colsC126.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC126.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC126.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC126.NamedProperties.Put("SqlColumn", "C126");
            this.tblExtFileTransColumn_colsC126.Position = 132;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC126, "tblExtFileTransColumn_colsC126");
            // 
            // tblExtFileTransColumn_colsC127
            // 
            this.tblExtFileTransColumn_colsC127.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC127.Name = "tblExtFileTransColumn_colsC127";
            this.tblExtFileTransColumn_colsC127.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC127.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC127.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC127.NamedProperties.Put("SqlColumn", "C127");
            this.tblExtFileTransColumn_colsC127.Position = 133;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC127, "tblExtFileTransColumn_colsC127");
            // 
            // tblExtFileTransColumn_colsC128
            // 
            this.tblExtFileTransColumn_colsC128.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC128.Name = "tblExtFileTransColumn_colsC128";
            this.tblExtFileTransColumn_colsC128.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC128.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC128.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC128.NamedProperties.Put("SqlColumn", "C128");
            this.tblExtFileTransColumn_colsC128.Position = 134;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC128, "tblExtFileTransColumn_colsC128");
            // 
            // tblExtFileTransColumn_colsC129
            // 
            this.tblExtFileTransColumn_colsC129.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC129.Name = "tblExtFileTransColumn_colsC129";
            this.tblExtFileTransColumn_colsC129.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC129.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC129.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC129.NamedProperties.Put("SqlColumn", "C129");
            this.tblExtFileTransColumn_colsC129.Position = 135;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC129, "tblExtFileTransColumn_colsC129");
            // 
            // tblExtFileTransColumn_colsC130
            // 
            this.tblExtFileTransColumn_colsC130.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC130.Name = "tblExtFileTransColumn_colsC130";
            this.tblExtFileTransColumn_colsC130.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC130.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC130.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC130.NamedProperties.Put("SqlColumn", "C130");
            this.tblExtFileTransColumn_colsC130.Position = 136;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC130, "tblExtFileTransColumn_colsC130");
            // 
            // tblExtFileTransColumn_colsC131
            // 
            this.tblExtFileTransColumn_colsC131.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC131.Name = "tblExtFileTransColumn_colsC131";
            this.tblExtFileTransColumn_colsC131.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC131.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC131.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC131.NamedProperties.Put("SqlColumn", "C131");
            this.tblExtFileTransColumn_colsC131.Position = 137;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC131, "tblExtFileTransColumn_colsC131");
            // 
            // tblExtFileTransColumn_colsC132
            // 
            this.tblExtFileTransColumn_colsC132.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC132.Name = "tblExtFileTransColumn_colsC132";
            this.tblExtFileTransColumn_colsC132.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC132.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC132.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC132.NamedProperties.Put("SqlColumn", "C132");
            this.tblExtFileTransColumn_colsC132.Position = 138;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC132, "tblExtFileTransColumn_colsC132");
            // 
            // tblExtFileTransColumn_colsC133
            // 
            this.tblExtFileTransColumn_colsC133.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC133.Name = "tblExtFileTransColumn_colsC133";
            this.tblExtFileTransColumn_colsC133.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC133.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC133.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC133.NamedProperties.Put("SqlColumn", "C133");
            this.tblExtFileTransColumn_colsC133.Position = 139;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC133, "tblExtFileTransColumn_colsC133");
            // 
            // tblExtFileTransColumn_colsC134
            // 
            this.tblExtFileTransColumn_colsC134.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC134.Name = "tblExtFileTransColumn_colsC134";
            this.tblExtFileTransColumn_colsC134.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC134.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC134.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC134.NamedProperties.Put("SqlColumn", "C134");
            this.tblExtFileTransColumn_colsC134.Position = 140;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC134, "tblExtFileTransColumn_colsC134");
            // 
            // tblExtFileTransColumn_colsC135
            // 
            this.tblExtFileTransColumn_colsC135.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC135.Name = "tblExtFileTransColumn_colsC135";
            this.tblExtFileTransColumn_colsC135.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC135.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC135.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC135.NamedProperties.Put("SqlColumn", "C135");
            this.tblExtFileTransColumn_colsC135.Position = 141;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC135, "tblExtFileTransColumn_colsC135");
            // 
            // tblExtFileTransColumn_colsC136
            // 
            this.tblExtFileTransColumn_colsC136.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC136.Name = "tblExtFileTransColumn_colsC136";
            this.tblExtFileTransColumn_colsC136.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC136.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC136.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC136.NamedProperties.Put("SqlColumn", "C136");
            this.tblExtFileTransColumn_colsC136.Position = 142;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC136, "tblExtFileTransColumn_colsC136");
            // 
            // tblExtFileTransColumn_colsC137
            // 
            this.tblExtFileTransColumn_colsC137.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC137.Name = "tblExtFileTransColumn_colsC137";
            this.tblExtFileTransColumn_colsC137.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC137.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC137.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC137.NamedProperties.Put("SqlColumn", "C137");
            this.tblExtFileTransColumn_colsC137.Position = 143;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC137, "tblExtFileTransColumn_colsC137");
            // 
            // tblExtFileTransColumn_colsC138
            // 
            this.tblExtFileTransColumn_colsC138.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC138.Name = "tblExtFileTransColumn_colsC138";
            this.tblExtFileTransColumn_colsC138.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC138.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC138.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC138.NamedProperties.Put("SqlColumn", "C138");
            this.tblExtFileTransColumn_colsC138.Position = 144;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC138, "tblExtFileTransColumn_colsC138");
            // 
            // tblExtFileTransColumn_colsC139
            // 
            this.tblExtFileTransColumn_colsC139.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC139.Name = "tblExtFileTransColumn_colsC139";
            this.tblExtFileTransColumn_colsC139.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC139.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC139.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC139.NamedProperties.Put("SqlColumn", "C139");
            this.tblExtFileTransColumn_colsC139.Position = 145;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC139, "tblExtFileTransColumn_colsC139");
            // 
            // tblExtFileTransColumn_colsC140
            // 
            this.tblExtFileTransColumn_colsC140.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC140.Name = "tblExtFileTransColumn_colsC140";
            this.tblExtFileTransColumn_colsC140.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC140.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC140.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC140.NamedProperties.Put("SqlColumn", "C140");
            this.tblExtFileTransColumn_colsC140.Position = 146;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC140, "tblExtFileTransColumn_colsC140");
            // 
            // tblExtFileTransColumn_colsC141
            // 
            this.tblExtFileTransColumn_colsC141.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC141.Name = "tblExtFileTransColumn_colsC141";
            this.tblExtFileTransColumn_colsC141.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC141.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC141.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC141.NamedProperties.Put("SqlColumn", "C141");
            this.tblExtFileTransColumn_colsC141.Position = 147;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC141, "tblExtFileTransColumn_colsC141");
            // 
            // tblExtFileTransColumn_colsC142
            // 
            this.tblExtFileTransColumn_colsC142.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC142.Name = "tblExtFileTransColumn_colsC142";
            this.tblExtFileTransColumn_colsC142.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC142.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC142.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC142.NamedProperties.Put("SqlColumn", "C142");
            this.tblExtFileTransColumn_colsC142.Position = 148;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC142, "tblExtFileTransColumn_colsC142");
            // 
            // tblExtFileTransColumn_colsC143
            // 
            this.tblExtFileTransColumn_colsC143.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC143.Name = "tblExtFileTransColumn_colsC143";
            this.tblExtFileTransColumn_colsC143.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC143.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC143.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC143.NamedProperties.Put("SqlColumn", "C143");
            this.tblExtFileTransColumn_colsC143.Position = 149;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC143, "tblExtFileTransColumn_colsC143");
            // 
            // tblExtFileTransColumn_colsC144
            // 
            this.tblExtFileTransColumn_colsC144.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC144.Name = "tblExtFileTransColumn_colsC144";
            this.tblExtFileTransColumn_colsC144.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC144.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC144.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC144.NamedProperties.Put("SqlColumn", "C144");
            this.tblExtFileTransColumn_colsC144.Position = 150;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC144, "tblExtFileTransColumn_colsC144");
            // 
            // tblExtFileTransColumn_colsC145
            // 
            this.tblExtFileTransColumn_colsC145.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC145.Name = "tblExtFileTransColumn_colsC145";
            this.tblExtFileTransColumn_colsC145.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC145.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC145.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC145.NamedProperties.Put("SqlColumn", "C145");
            this.tblExtFileTransColumn_colsC145.Position = 151;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC145, "tblExtFileTransColumn_colsC145");
            // 
            // tblExtFileTransColumn_colsC146
            // 
            this.tblExtFileTransColumn_colsC146.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC146.Name = "tblExtFileTransColumn_colsC146";
            this.tblExtFileTransColumn_colsC146.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC146.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC146.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC146.NamedProperties.Put("SqlColumn", "C146");
            this.tblExtFileTransColumn_colsC146.Position = 152;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC146, "tblExtFileTransColumn_colsC146");
            // 
            // tblExtFileTransColumn_colsC147
            // 
            this.tblExtFileTransColumn_colsC147.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC147.Name = "tblExtFileTransColumn_colsC147";
            this.tblExtFileTransColumn_colsC147.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC147.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC147.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC147.NamedProperties.Put("SqlColumn", "C147");
            this.tblExtFileTransColumn_colsC147.Position = 153;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC147, "tblExtFileTransColumn_colsC147");
            // 
            // tblExtFileTransColumn_colsC148
            // 
            this.tblExtFileTransColumn_colsC148.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC148.Name = "tblExtFileTransColumn_colsC148";
            this.tblExtFileTransColumn_colsC148.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC148.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC148.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC148.NamedProperties.Put("SqlColumn", "C148");
            this.tblExtFileTransColumn_colsC148.Position = 154;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC148, "tblExtFileTransColumn_colsC148");
            // 
            // tblExtFileTransColumn_colsC149
            // 
            this.tblExtFileTransColumn_colsC149.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC149.Name = "tblExtFileTransColumn_colsC149";
            this.tblExtFileTransColumn_colsC149.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC149.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC149.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC149.NamedProperties.Put("SqlColumn", "C149");
            this.tblExtFileTransColumn_colsC149.Position = 155;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC149, "tblExtFileTransColumn_colsC149");
            // 
            // tblExtFileTransColumn_colsC150
            // 
            this.tblExtFileTransColumn_colsC150.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC150.Name = "tblExtFileTransColumn_colsC150";
            this.tblExtFileTransColumn_colsC150.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC150.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC150.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC150.NamedProperties.Put("SqlColumn", "C150");
            this.tblExtFileTransColumn_colsC150.Position = 156;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC150, "tblExtFileTransColumn_colsC150");
            // 
            // tblExtFileTransColumn_colsC151
            // 
            this.tblExtFileTransColumn_colsC151.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC151.Name = "tblExtFileTransColumn_colsC151";
            this.tblExtFileTransColumn_colsC151.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC151.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC151.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC151.NamedProperties.Put("SqlColumn", "C151");
            this.tblExtFileTransColumn_colsC151.Position = 157;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC151, "tblExtFileTransColumn_colsC151");
            // 
            // tblExtFileTransColumn_colsC152
            // 
            this.tblExtFileTransColumn_colsC152.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC152.Name = "tblExtFileTransColumn_colsC152";
            this.tblExtFileTransColumn_colsC152.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC152.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC152.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC152.NamedProperties.Put("SqlColumn", "C152");
            this.tblExtFileTransColumn_colsC152.Position = 158;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC152, "tblExtFileTransColumn_colsC152");
            // 
            // tblExtFileTransColumn_colsC153
            // 
            this.tblExtFileTransColumn_colsC153.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC153.Name = "tblExtFileTransColumn_colsC153";
            this.tblExtFileTransColumn_colsC153.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC153.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC153.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC153.NamedProperties.Put("SqlColumn", "C153");
            this.tblExtFileTransColumn_colsC153.Position = 159;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC153, "tblExtFileTransColumn_colsC153");
            // 
            // tblExtFileTransColumn_colsC154
            // 
            this.tblExtFileTransColumn_colsC154.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC154.Name = "tblExtFileTransColumn_colsC154";
            this.tblExtFileTransColumn_colsC154.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC154.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC154.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC154.NamedProperties.Put("SqlColumn", "C154");
            this.tblExtFileTransColumn_colsC154.Position = 160;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC154, "tblExtFileTransColumn_colsC154");
            // 
            // tblExtFileTransColumn_colsC155
            // 
            this.tblExtFileTransColumn_colsC155.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC155.Name = "tblExtFileTransColumn_colsC155";
            this.tblExtFileTransColumn_colsC155.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC155.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC155.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC155.NamedProperties.Put("SqlColumn", "C155");
            this.tblExtFileTransColumn_colsC155.Position = 161;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC155, "tblExtFileTransColumn_colsC155");
            // 
            // tblExtFileTransColumn_colsC156
            // 
            this.tblExtFileTransColumn_colsC156.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC156.Name = "tblExtFileTransColumn_colsC156";
            this.tblExtFileTransColumn_colsC156.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC156.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC156.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC156.NamedProperties.Put("SqlColumn", "C156");
            this.tblExtFileTransColumn_colsC156.Position = 162;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC156, "tblExtFileTransColumn_colsC156");
            // 
            // tblExtFileTransColumn_colsC157
            // 
            this.tblExtFileTransColumn_colsC157.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC157.Name = "tblExtFileTransColumn_colsC157";
            this.tblExtFileTransColumn_colsC157.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC157.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC157.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC157.NamedProperties.Put("SqlColumn", "C157");
            this.tblExtFileTransColumn_colsC157.Position = 163;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC157, "tblExtFileTransColumn_colsC157");
            // 
            // tblExtFileTransColumn_colsC158
            // 
            this.tblExtFileTransColumn_colsC158.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC158.Name = "tblExtFileTransColumn_colsC158";
            this.tblExtFileTransColumn_colsC158.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC158.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC158.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC158.NamedProperties.Put("SqlColumn", "C158");
            this.tblExtFileTransColumn_colsC158.Position = 164;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC158, "tblExtFileTransColumn_colsC158");
            // 
            // tblExtFileTransColumn_colsC159
            // 
            this.tblExtFileTransColumn_colsC159.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC159.Name = "tblExtFileTransColumn_colsC159";
            this.tblExtFileTransColumn_colsC159.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC159.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC159.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC159.NamedProperties.Put("SqlColumn", "C159");
            this.tblExtFileTransColumn_colsC159.Position = 165;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC159, "tblExtFileTransColumn_colsC159");
            // 
            // tblExtFileTransColumn_colsC160
            // 
            this.tblExtFileTransColumn_colsC160.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC160.Name = "tblExtFileTransColumn_colsC160";
            this.tblExtFileTransColumn_colsC160.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC160.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC160.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC160.NamedProperties.Put("SqlColumn", "C160");
            this.tblExtFileTransColumn_colsC160.Position = 166;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC160, "tblExtFileTransColumn_colsC160");
            // 
            // tblExtFileTransColumn_colsC161
            // 
            this.tblExtFileTransColumn_colsC161.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC161.Name = "tblExtFileTransColumn_colsC161";
            this.tblExtFileTransColumn_colsC161.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC161.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC161.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC161.NamedProperties.Put("SqlColumn", "C161");
            this.tblExtFileTransColumn_colsC161.Position = 167;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC161, "tblExtFileTransColumn_colsC161");
            // 
            // tblExtFileTransColumn_colsC162
            // 
            this.tblExtFileTransColumn_colsC162.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC162.Name = "tblExtFileTransColumn_colsC162";
            this.tblExtFileTransColumn_colsC162.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC162.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC162.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC162.NamedProperties.Put("SqlColumn", "C162");
            this.tblExtFileTransColumn_colsC162.Position = 168;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC162, "tblExtFileTransColumn_colsC162");
            // 
            // tblExtFileTransColumn_colsC163
            // 
            this.tblExtFileTransColumn_colsC163.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC163.Name = "tblExtFileTransColumn_colsC163";
            this.tblExtFileTransColumn_colsC163.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC163.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC163.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC163.NamedProperties.Put("SqlColumn", "C163");
            this.tblExtFileTransColumn_colsC163.Position = 169;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC163, "tblExtFileTransColumn_colsC163");
            // 
            // tblExtFileTransColumn_colsC164
            // 
            this.tblExtFileTransColumn_colsC164.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC164.Name = "tblExtFileTransColumn_colsC164";
            this.tblExtFileTransColumn_colsC164.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC164.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC164.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC164.NamedProperties.Put("SqlColumn", "C164");
            this.tblExtFileTransColumn_colsC164.Position = 170;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC164, "tblExtFileTransColumn_colsC164");
            // 
            // tblExtFileTransColumn_colsC165
            // 
            this.tblExtFileTransColumn_colsC165.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC165.Name = "tblExtFileTransColumn_colsC165";
            this.tblExtFileTransColumn_colsC165.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC165.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC165.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC165.NamedProperties.Put("SqlColumn", "C165");
            this.tblExtFileTransColumn_colsC165.Position = 171;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC165, "tblExtFileTransColumn_colsC165");
            // 
            // tblExtFileTransColumn_colsC166
            // 
            this.tblExtFileTransColumn_colsC166.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC166.Name = "tblExtFileTransColumn_colsC166";
            this.tblExtFileTransColumn_colsC166.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC166.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC166.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC166.NamedProperties.Put("SqlColumn", "C166");
            this.tblExtFileTransColumn_colsC166.Position = 172;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC166, "tblExtFileTransColumn_colsC166");
            // 
            // tblExtFileTransColumn_colsC167
            // 
            this.tblExtFileTransColumn_colsC167.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC167.Name = "tblExtFileTransColumn_colsC167";
            this.tblExtFileTransColumn_colsC167.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC167.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC167.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC167.NamedProperties.Put("SqlColumn", "C167");
            this.tblExtFileTransColumn_colsC167.Position = 173;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC167, "tblExtFileTransColumn_colsC167");
            // 
            // tblExtFileTransColumn_colsC168
            // 
            this.tblExtFileTransColumn_colsC168.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC168.Name = "tblExtFileTransColumn_colsC168";
            this.tblExtFileTransColumn_colsC168.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC168.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC168.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC168.NamedProperties.Put("SqlColumn", "C168");
            this.tblExtFileTransColumn_colsC168.Position = 174;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC168, "tblExtFileTransColumn_colsC168");
            // 
            // tblExtFileTransColumn_colsC169
            // 
            this.tblExtFileTransColumn_colsC169.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC169.Name = "tblExtFileTransColumn_colsC169";
            this.tblExtFileTransColumn_colsC169.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC169.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC169.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC169.NamedProperties.Put("SqlColumn", "C169");
            this.tblExtFileTransColumn_colsC169.Position = 175;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC169, "tblExtFileTransColumn_colsC169");
            // 
            // tblExtFileTransColumn_colsC170
            // 
            this.tblExtFileTransColumn_colsC170.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC170.Name = "tblExtFileTransColumn_colsC170";
            this.tblExtFileTransColumn_colsC170.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC170.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC170.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC170.NamedProperties.Put("SqlColumn", "C170");
            this.tblExtFileTransColumn_colsC170.Position = 176;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC170, "tblExtFileTransColumn_colsC170");
            // 
            // tblExtFileTransColumn_colsC171
            // 
            this.tblExtFileTransColumn_colsC171.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC171.Name = "tblExtFileTransColumn_colsC171";
            this.tblExtFileTransColumn_colsC171.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC171.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC171.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC171.NamedProperties.Put("SqlColumn", "C171");
            this.tblExtFileTransColumn_colsC171.Position = 177;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC171, "tblExtFileTransColumn_colsC171");
            // 
            // tblExtFileTransColumn_colsC172
            // 
            this.tblExtFileTransColumn_colsC172.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC172.Name = "tblExtFileTransColumn_colsC172";
            this.tblExtFileTransColumn_colsC172.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC172.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC172.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC172.NamedProperties.Put("SqlColumn", "C172");
            this.tblExtFileTransColumn_colsC172.Position = 178;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC172, "tblExtFileTransColumn_colsC172");
            // 
            // tblExtFileTransColumn_colsC173
            // 
            this.tblExtFileTransColumn_colsC173.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC173.Name = "tblExtFileTransColumn_colsC173";
            this.tblExtFileTransColumn_colsC173.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC173.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC173.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC173.NamedProperties.Put("SqlColumn", "C173");
            this.tblExtFileTransColumn_colsC173.Position = 179;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC173, "tblExtFileTransColumn_colsC173");
            // 
            // tblExtFileTransColumn_colsC174
            // 
            this.tblExtFileTransColumn_colsC174.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC174.Name = "tblExtFileTransColumn_colsC174";
            this.tblExtFileTransColumn_colsC174.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC174.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC174.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC174.NamedProperties.Put("SqlColumn", "C174");
            this.tblExtFileTransColumn_colsC174.Position = 180;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC174, "tblExtFileTransColumn_colsC174");
            // 
            // tblExtFileTransColumn_colsC175
            // 
            this.tblExtFileTransColumn_colsC175.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC175.Name = "tblExtFileTransColumn_colsC175";
            this.tblExtFileTransColumn_colsC175.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC175.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC175.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC175.NamedProperties.Put("SqlColumn", "C175");
            this.tblExtFileTransColumn_colsC175.Position = 181;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC175, "tblExtFileTransColumn_colsC175");
            // 
            // tblExtFileTransColumn_colsC176
            // 
            this.tblExtFileTransColumn_colsC176.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC176.Name = "tblExtFileTransColumn_colsC176";
            this.tblExtFileTransColumn_colsC176.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC176.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC176.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC176.NamedProperties.Put("SqlColumn", "C176");
            this.tblExtFileTransColumn_colsC176.Position = 182;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC176, "tblExtFileTransColumn_colsC176");
            // 
            // tblExtFileTransColumn_colsC177
            // 
            this.tblExtFileTransColumn_colsC177.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC177.Name = "tblExtFileTransColumn_colsC177";
            this.tblExtFileTransColumn_colsC177.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC177.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC177.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC177.NamedProperties.Put("SqlColumn", "C177");
            this.tblExtFileTransColumn_colsC177.Position = 183;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC177, "tblExtFileTransColumn_colsC177");
            // 
            // tblExtFileTransColumn_colsC178
            // 
            this.tblExtFileTransColumn_colsC178.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC178.Name = "tblExtFileTransColumn_colsC178";
            this.tblExtFileTransColumn_colsC178.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC178.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC178.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC178.NamedProperties.Put("SqlColumn", "C178");
            this.tblExtFileTransColumn_colsC178.Position = 184;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC178, "tblExtFileTransColumn_colsC178");
            // 
            // tblExtFileTransColumn_colsC179
            // 
            this.tblExtFileTransColumn_colsC179.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC179.Name = "tblExtFileTransColumn_colsC179";
            this.tblExtFileTransColumn_colsC179.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC179.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC179.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC179.NamedProperties.Put("SqlColumn", "C179");
            this.tblExtFileTransColumn_colsC179.Position = 185;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC179, "tblExtFileTransColumn_colsC179");
            // 
            // tblExtFileTransColumn_colsC180
            // 
            this.tblExtFileTransColumn_colsC180.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC180.Name = "tblExtFileTransColumn_colsC180";
            this.tblExtFileTransColumn_colsC180.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC180.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC180.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC180.NamedProperties.Put("SqlColumn", "C180");
            this.tblExtFileTransColumn_colsC180.Position = 186;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC180, "tblExtFileTransColumn_colsC180");
            // 
            // tblExtFileTransColumn_colsC181
            // 
            this.tblExtFileTransColumn_colsC181.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC181.Name = "tblExtFileTransColumn_colsC181";
            this.tblExtFileTransColumn_colsC181.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC181.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC181.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC181.NamedProperties.Put("SqlColumn", "C181");
            this.tblExtFileTransColumn_colsC181.Position = 187;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC181, "tblExtFileTransColumn_colsC181");
            // 
            // tblExtFileTransColumn_colsC182
            // 
            this.tblExtFileTransColumn_colsC182.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC182.Name = "tblExtFileTransColumn_colsC182";
            this.tblExtFileTransColumn_colsC182.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC182.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC182.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC182.NamedProperties.Put("SqlColumn", "C182");
            this.tblExtFileTransColumn_colsC182.Position = 188;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC182, "tblExtFileTransColumn_colsC182");
            // 
            // tblExtFileTransColumn_colsC183
            // 
            this.tblExtFileTransColumn_colsC183.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC183.Name = "tblExtFileTransColumn_colsC183";
            this.tblExtFileTransColumn_colsC183.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC183.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC183.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC183.NamedProperties.Put("SqlColumn", "C183");
            this.tblExtFileTransColumn_colsC183.Position = 189;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC183, "tblExtFileTransColumn_colsC183");
            // 
            // tblExtFileTransColumn_colsC184
            // 
            this.tblExtFileTransColumn_colsC184.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC184.Name = "tblExtFileTransColumn_colsC184";
            this.tblExtFileTransColumn_colsC184.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC184.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC184.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC184.NamedProperties.Put("SqlColumn", "C184");
            this.tblExtFileTransColumn_colsC184.Position = 190;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC184, "tblExtFileTransColumn_colsC184");
            // 
            // tblExtFileTransColumn_colsC185
            // 
            this.tblExtFileTransColumn_colsC185.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC185.Name = "tblExtFileTransColumn_colsC185";
            this.tblExtFileTransColumn_colsC185.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC185.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC185.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC185.NamedProperties.Put("SqlColumn", "C185");
            this.tblExtFileTransColumn_colsC185.Position = 191;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC185, "tblExtFileTransColumn_colsC185");
            // 
            // tblExtFileTransColumn_colsC186
            // 
            this.tblExtFileTransColumn_colsC186.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC186.Name = "tblExtFileTransColumn_colsC186";
            this.tblExtFileTransColumn_colsC186.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC186.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC186.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC186.NamedProperties.Put("SqlColumn", "C186");
            this.tblExtFileTransColumn_colsC186.Position = 192;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC186, "tblExtFileTransColumn_colsC186");
            // 
            // tblExtFileTransColumn_colsC187
            // 
            this.tblExtFileTransColumn_colsC187.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC187.Name = "tblExtFileTransColumn_colsC187";
            this.tblExtFileTransColumn_colsC187.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC187.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC187.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC187.NamedProperties.Put("SqlColumn", "C187");
            this.tblExtFileTransColumn_colsC187.Position = 193;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC187, "tblExtFileTransColumn_colsC187");
            // 
            // tblExtFileTransColumn_colsC188
            // 
            this.tblExtFileTransColumn_colsC188.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC188.Name = "tblExtFileTransColumn_colsC188";
            this.tblExtFileTransColumn_colsC188.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC188.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC188.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC188.NamedProperties.Put("SqlColumn", "C188");
            this.tblExtFileTransColumn_colsC188.Position = 194;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC188, "tblExtFileTransColumn_colsC188");
            // 
            // tblExtFileTransColumn_colsC189
            // 
            this.tblExtFileTransColumn_colsC189.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC189.Name = "tblExtFileTransColumn_colsC189";
            this.tblExtFileTransColumn_colsC189.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC189.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC189.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC189.NamedProperties.Put("SqlColumn", "C189");
            this.tblExtFileTransColumn_colsC189.Position = 195;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC189, "tblExtFileTransColumn_colsC189");
            // 
            // tblExtFileTransColumn_colsC190
            // 
            this.tblExtFileTransColumn_colsC190.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC190.Name = "tblExtFileTransColumn_colsC190";
            this.tblExtFileTransColumn_colsC190.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC190.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC190.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC190.NamedProperties.Put("SqlColumn", "C190");
            this.tblExtFileTransColumn_colsC190.Position = 196;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC190, "tblExtFileTransColumn_colsC190");
            // 
            // tblExtFileTransColumn_colsC191
            // 
            this.tblExtFileTransColumn_colsC191.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC191.Name = "tblExtFileTransColumn_colsC191";
            this.tblExtFileTransColumn_colsC191.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC191.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC191.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC191.NamedProperties.Put("SqlColumn", "C191");
            this.tblExtFileTransColumn_colsC191.Position = 197;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC191, "tblExtFileTransColumn_colsC191");
            // 
            // tblExtFileTransColumn_colsC192
            // 
            this.tblExtFileTransColumn_colsC192.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC192.Name = "tblExtFileTransColumn_colsC192";
            this.tblExtFileTransColumn_colsC192.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC192.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC192.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC192.NamedProperties.Put("SqlColumn", "C192");
            this.tblExtFileTransColumn_colsC192.Position = 198;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC192, "tblExtFileTransColumn_colsC192");
            // 
            // tblExtFileTransColumn_colsC193
            // 
            this.tblExtFileTransColumn_colsC193.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC193.Name = "tblExtFileTransColumn_colsC193";
            this.tblExtFileTransColumn_colsC193.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC193.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC193.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC193.NamedProperties.Put("SqlColumn", "C193");
            this.tblExtFileTransColumn_colsC193.Position = 199;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC193, "tblExtFileTransColumn_colsC193");
            // 
            // tblExtFileTransColumn_colsC194
            // 
            this.tblExtFileTransColumn_colsC194.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC194.Name = "tblExtFileTransColumn_colsC194";
            this.tblExtFileTransColumn_colsC194.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC194.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC194.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC194.NamedProperties.Put("SqlColumn", "C194");
            this.tblExtFileTransColumn_colsC194.Position = 200;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC194, "tblExtFileTransColumn_colsC194");
            // 
            // tblExtFileTransColumn_colsC195
            // 
            this.tblExtFileTransColumn_colsC195.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC195.Name = "tblExtFileTransColumn_colsC195";
            this.tblExtFileTransColumn_colsC195.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC195.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC195.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC195.NamedProperties.Put("SqlColumn", "C195");
            this.tblExtFileTransColumn_colsC195.Position = 201;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC195, "tblExtFileTransColumn_colsC195");
            // 
            // tblExtFileTransColumn_colsC196
            // 
            this.tblExtFileTransColumn_colsC196.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC196.Name = "tblExtFileTransColumn_colsC196";
            this.tblExtFileTransColumn_colsC196.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC196.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC196.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC196.NamedProperties.Put("SqlColumn", "C196");
            this.tblExtFileTransColumn_colsC196.Position = 202;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC196, "tblExtFileTransColumn_colsC196");
            // 
            // tblExtFileTransColumn_colsC197
            // 
            this.tblExtFileTransColumn_colsC197.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC197.Name = "tblExtFileTransColumn_colsC197";
            this.tblExtFileTransColumn_colsC197.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC197.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC197.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC197.NamedProperties.Put("SqlColumn", "C197");
            this.tblExtFileTransColumn_colsC197.Position = 203;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC197, "tblExtFileTransColumn_colsC197");
            // 
            // tblExtFileTransColumn_colsC198
            // 
            this.tblExtFileTransColumn_colsC198.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC198.Name = "tblExtFileTransColumn_colsC198";
            this.tblExtFileTransColumn_colsC198.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC198.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC198.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC198.NamedProperties.Put("SqlColumn", "C198");
            this.tblExtFileTransColumn_colsC198.Position = 204;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC198, "tblExtFileTransColumn_colsC198");
            // 
            // tblExtFileTransColumn_colsC199
            // 
            this.tblExtFileTransColumn_colsC199.MaxLength = 2000;
            this.tblExtFileTransColumn_colsC199.Name = "tblExtFileTransColumn_colsC199";
            this.tblExtFileTransColumn_colsC199.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colsC199.NamedProperties.Put("FieldFlags", "310");
            this.tblExtFileTransColumn_colsC199.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colsC199.NamedProperties.Put("SqlColumn", "C199");
            this.tblExtFileTransColumn_colsC199.Position = 205;
            resources.ApplyResources(this.tblExtFileTransColumn_colsC199, "tblExtFileTransColumn_colsC199");
            // 
            // tblExtFileTransColumn_colnN0
            // 
            this.tblExtFileTransColumn_colnN0.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN0.Name = "tblExtFileTransColumn_colnN0";
            this.tblExtFileTransColumn_colnN0.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN0.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN0.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN0.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN0.NamedProperties.Put("SqlColumn", "N0");
            this.tblExtFileTransColumn_colnN0.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN0.Position = 206;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN0, "tblExtFileTransColumn_colnN0");
            // 
            // tblExtFileTransColumn_colnN1
            // 
            this.tblExtFileTransColumn_colnN1.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN1.Name = "tblExtFileTransColumn_colnN1";
            this.tblExtFileTransColumn_colnN1.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN1.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN1.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN1.NamedProperties.Put("SqlColumn", "N1");
            this.tblExtFileTransColumn_colnN1.Position = 207;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN1, "tblExtFileTransColumn_colnN1");
            // 
            // tblExtFileTransColumn_colnN2
            // 
            this.tblExtFileTransColumn_colnN2.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN2.Name = "tblExtFileTransColumn_colnN2";
            this.tblExtFileTransColumn_colnN2.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN2.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN2.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN2.NamedProperties.Put("SqlColumn", "N2");
            this.tblExtFileTransColumn_colnN2.Position = 208;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN2, "tblExtFileTransColumn_colnN2");
            // 
            // tblExtFileTransColumn_colnN3
            // 
            this.tblExtFileTransColumn_colnN3.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN3.Name = "tblExtFileTransColumn_colnN3";
            this.tblExtFileTransColumn_colnN3.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN3.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN3.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN3.NamedProperties.Put("SqlColumn", "N3");
            this.tblExtFileTransColumn_colnN3.Position = 209;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN3, "tblExtFileTransColumn_colnN3");
            // 
            // tblExtFileTransColumn_colnN4
            // 
            this.tblExtFileTransColumn_colnN4.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN4.Name = "tblExtFileTransColumn_colnN4";
            this.tblExtFileTransColumn_colnN4.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN4.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN4.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN4.NamedProperties.Put("SqlColumn", "N4");
            this.tblExtFileTransColumn_colnN4.Position = 210;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN4, "tblExtFileTransColumn_colnN4");
            // 
            // tblExtFileTransColumn_colnN5
            // 
            this.tblExtFileTransColumn_colnN5.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN5.Name = "tblExtFileTransColumn_colnN5";
            this.tblExtFileTransColumn_colnN5.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN5.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN5.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN5.NamedProperties.Put("SqlColumn", "N5");
            this.tblExtFileTransColumn_colnN5.Position = 211;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN5, "tblExtFileTransColumn_colnN5");
            // 
            // tblExtFileTransColumn_colnN6
            // 
            this.tblExtFileTransColumn_colnN6.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN6.Name = "tblExtFileTransColumn_colnN6";
            this.tblExtFileTransColumn_colnN6.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN6.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN6.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN6.NamedProperties.Put("SqlColumn", "N6");
            this.tblExtFileTransColumn_colnN6.Position = 212;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN6, "tblExtFileTransColumn_colnN6");
            // 
            // tblExtFileTransColumn_colnN7
            // 
            this.tblExtFileTransColumn_colnN7.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN7.Name = "tblExtFileTransColumn_colnN7";
            this.tblExtFileTransColumn_colnN7.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN7.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN7.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN7.NamedProperties.Put("SqlColumn", "N7");
            this.tblExtFileTransColumn_colnN7.Position = 213;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN7, "tblExtFileTransColumn_colnN7");
            // 
            // tblExtFileTransColumn_colnN8
            // 
            this.tblExtFileTransColumn_colnN8.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN8.Name = "tblExtFileTransColumn_colnN8";
            this.tblExtFileTransColumn_colnN8.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN8.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN8.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN8.NamedProperties.Put("SqlColumn", "N8");
            this.tblExtFileTransColumn_colnN8.Position = 214;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN8, "tblExtFileTransColumn_colnN8");
            // 
            // tblExtFileTransColumn_colnN9
            // 
            this.tblExtFileTransColumn_colnN9.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN9.Name = "tblExtFileTransColumn_colnN9";
            this.tblExtFileTransColumn_colnN9.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN9.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN9.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN9.NamedProperties.Put("SqlColumn", "N9");
            this.tblExtFileTransColumn_colnN9.Position = 215;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN9, "tblExtFileTransColumn_colnN9");
            // 
            // tblExtFileTransColumn_colnN10
            // 
            this.tblExtFileTransColumn_colnN10.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN10.Name = "tblExtFileTransColumn_colnN10";
            this.tblExtFileTransColumn_colnN10.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN10.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN10.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN10.NamedProperties.Put("SqlColumn", "N10");
            this.tblExtFileTransColumn_colnN10.Position = 216;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN10, "tblExtFileTransColumn_colnN10");
            // 
            // tblExtFileTransColumn_colnN11
            // 
            this.tblExtFileTransColumn_colnN11.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN11.Name = "tblExtFileTransColumn_colnN11";
            this.tblExtFileTransColumn_colnN11.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN11.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN11.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN11.NamedProperties.Put("SqlColumn", "N11");
            this.tblExtFileTransColumn_colnN11.Position = 217;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN11, "tblExtFileTransColumn_colnN11");
            // 
            // tblExtFileTransColumn_colnN12
            // 
            this.tblExtFileTransColumn_colnN12.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN12.Name = "tblExtFileTransColumn_colnN12";
            this.tblExtFileTransColumn_colnN12.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN12.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN12.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN12.NamedProperties.Put("SqlColumn", "N12");
            this.tblExtFileTransColumn_colnN12.Position = 218;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN12, "tblExtFileTransColumn_colnN12");
            // 
            // tblExtFileTransColumn_colnN13
            // 
            this.tblExtFileTransColumn_colnN13.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN13.Name = "tblExtFileTransColumn_colnN13";
            this.tblExtFileTransColumn_colnN13.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN13.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN13.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN13.NamedProperties.Put("SqlColumn", "N13");
            this.tblExtFileTransColumn_colnN13.Position = 219;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN13, "tblExtFileTransColumn_colnN13");
            // 
            // tblExtFileTransColumn_colnN14
            // 
            this.tblExtFileTransColumn_colnN14.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN14.Name = "tblExtFileTransColumn_colnN14";
            this.tblExtFileTransColumn_colnN14.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN14.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN14.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN14.NamedProperties.Put("SqlColumn", "N14");
            this.tblExtFileTransColumn_colnN14.Position = 220;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN14, "tblExtFileTransColumn_colnN14");
            // 
            // tblExtFileTransColumn_colnN15
            // 
            this.tblExtFileTransColumn_colnN15.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN15.Name = "tblExtFileTransColumn_colnN15";
            this.tblExtFileTransColumn_colnN15.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN15.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN15.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN15.NamedProperties.Put("SqlColumn", "N15");
            this.tblExtFileTransColumn_colnN15.Position = 221;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN15, "tblExtFileTransColumn_colnN15");
            // 
            // tblExtFileTransColumn_colnN16
            // 
            this.tblExtFileTransColumn_colnN16.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN16.Name = "tblExtFileTransColumn_colnN16";
            this.tblExtFileTransColumn_colnN16.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN16.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN16.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN16.NamedProperties.Put("SqlColumn", "N16");
            this.tblExtFileTransColumn_colnN16.Position = 222;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN16, "tblExtFileTransColumn_colnN16");
            // 
            // tblExtFileTransColumn_colnN17
            // 
            this.tblExtFileTransColumn_colnN17.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN17.Name = "tblExtFileTransColumn_colnN17";
            this.tblExtFileTransColumn_colnN17.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN17.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN17.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN17.NamedProperties.Put("SqlColumn", "N17");
            this.tblExtFileTransColumn_colnN17.Position = 223;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN17, "tblExtFileTransColumn_colnN17");
            // 
            // tblExtFileTransColumn_colnN18
            // 
            this.tblExtFileTransColumn_colnN18.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN18.Name = "tblExtFileTransColumn_colnN18";
            this.tblExtFileTransColumn_colnN18.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN18.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN18.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN18.NamedProperties.Put("SqlColumn", "N18");
            this.tblExtFileTransColumn_colnN18.Position = 224;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN18, "tblExtFileTransColumn_colnN18");
            // 
            // tblExtFileTransColumn_colnN19
            // 
            this.tblExtFileTransColumn_colnN19.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN19.Name = "tblExtFileTransColumn_colnN19";
            this.tblExtFileTransColumn_colnN19.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN19.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN19.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN19.NamedProperties.Put("SqlColumn", "N19");
            this.tblExtFileTransColumn_colnN19.Position = 225;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN19, "tblExtFileTransColumn_colnN19");
            // 
            // tblExtFileTransColumn_colnN20
            // 
            this.tblExtFileTransColumn_colnN20.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN20.Name = "tblExtFileTransColumn_colnN20";
            this.tblExtFileTransColumn_colnN20.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN20.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN20.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN20.NamedProperties.Put("SqlColumn", "N20");
            this.tblExtFileTransColumn_colnN20.Position = 226;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN20, "tblExtFileTransColumn_colnN20");
            // 
            // tblExtFileTransColumn_colnN21
            // 
            this.tblExtFileTransColumn_colnN21.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN21.Name = "tblExtFileTransColumn_colnN21";
            this.tblExtFileTransColumn_colnN21.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN21.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN21.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN21.NamedProperties.Put("SqlColumn", "N21");
            this.tblExtFileTransColumn_colnN21.Position = 227;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN21, "tblExtFileTransColumn_colnN21");
            // 
            // tblExtFileTransColumn_colnN22
            // 
            this.tblExtFileTransColumn_colnN22.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN22.Name = "tblExtFileTransColumn_colnN22";
            this.tblExtFileTransColumn_colnN22.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN22.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN22.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN22.NamedProperties.Put("SqlColumn", "N22");
            this.tblExtFileTransColumn_colnN22.Position = 228;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN22, "tblExtFileTransColumn_colnN22");
            // 
            // tblExtFileTransColumn_colnN23
            // 
            this.tblExtFileTransColumn_colnN23.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN23.Name = "tblExtFileTransColumn_colnN23";
            this.tblExtFileTransColumn_colnN23.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN23.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN23.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN23.NamedProperties.Put("SqlColumn", "N23");
            this.tblExtFileTransColumn_colnN23.Position = 229;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN23, "tblExtFileTransColumn_colnN23");
            // 
            // tblExtFileTransColumn_colnN24
            // 
            this.tblExtFileTransColumn_colnN24.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN24.Name = "tblExtFileTransColumn_colnN24";
            this.tblExtFileTransColumn_colnN24.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN24.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN24.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN24.NamedProperties.Put("SqlColumn", "N24");
            this.tblExtFileTransColumn_colnN24.Position = 230;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN24, "tblExtFileTransColumn_colnN24");
            // 
            // tblExtFileTransColumn_colnN25
            // 
            this.tblExtFileTransColumn_colnN25.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN25.Name = "tblExtFileTransColumn_colnN25";
            this.tblExtFileTransColumn_colnN25.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN25.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN25.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN25.NamedProperties.Put("SqlColumn", "N25");
            this.tblExtFileTransColumn_colnN25.Position = 231;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN25, "tblExtFileTransColumn_colnN25");
            // 
            // tblExtFileTransColumn_colnN26
            // 
            this.tblExtFileTransColumn_colnN26.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN26.Name = "tblExtFileTransColumn_colnN26";
            this.tblExtFileTransColumn_colnN26.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN26.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN26.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN26.NamedProperties.Put("SqlColumn", "N26");
            this.tblExtFileTransColumn_colnN26.Position = 232;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN26, "tblExtFileTransColumn_colnN26");
            // 
            // tblExtFileTransColumn_colnN27
            // 
            this.tblExtFileTransColumn_colnN27.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN27.Name = "tblExtFileTransColumn_colnN27";
            this.tblExtFileTransColumn_colnN27.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN27.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN27.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN27.NamedProperties.Put("SqlColumn", "N27");
            this.tblExtFileTransColumn_colnN27.Position = 233;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN27, "tblExtFileTransColumn_colnN27");
            // 
            // tblExtFileTransColumn_colnN28
            // 
            this.tblExtFileTransColumn_colnN28.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN28.Name = "tblExtFileTransColumn_colnN28";
            this.tblExtFileTransColumn_colnN28.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN28.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN28.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN28.NamedProperties.Put("SqlColumn", "N28");
            this.tblExtFileTransColumn_colnN28.Position = 234;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN28, "tblExtFileTransColumn_colnN28");
            // 
            // tblExtFileTransColumn_colnN29
            // 
            this.tblExtFileTransColumn_colnN29.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN29.Name = "tblExtFileTransColumn_colnN29";
            this.tblExtFileTransColumn_colnN29.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN29.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN29.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN29.NamedProperties.Put("SqlColumn", "N29");
            this.tblExtFileTransColumn_colnN29.Position = 235;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN29, "tblExtFileTransColumn_colnN29");
            // 
            // tblExtFileTransColumn_colnN30
            // 
            this.tblExtFileTransColumn_colnN30.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN30.Name = "tblExtFileTransColumn_colnN30";
            this.tblExtFileTransColumn_colnN30.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN30.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN30.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN30.NamedProperties.Put("SqlColumn", "N30");
            this.tblExtFileTransColumn_colnN30.Position = 236;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN30, "tblExtFileTransColumn_colnN30");
            // 
            // tblExtFileTransColumn_colnN31
            // 
            this.tblExtFileTransColumn_colnN31.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN31.Name = "tblExtFileTransColumn_colnN31";
            this.tblExtFileTransColumn_colnN31.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN31.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN31.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN31.NamedProperties.Put("SqlColumn", "N31");
            this.tblExtFileTransColumn_colnN31.Position = 237;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN31, "tblExtFileTransColumn_colnN31");
            // 
            // tblExtFileTransColumn_colnN32
            // 
            this.tblExtFileTransColumn_colnN32.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN32.Name = "tblExtFileTransColumn_colnN32";
            this.tblExtFileTransColumn_colnN32.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN32.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN32.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN32.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN32.NamedProperties.Put("SqlColumn", "N32");
            this.tblExtFileTransColumn_colnN32.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN32.Position = 238;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN32, "tblExtFileTransColumn_colnN32");
            // 
            // tblExtFileTransColumn_colnN33
            // 
            this.tblExtFileTransColumn_colnN33.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN33.Name = "tblExtFileTransColumn_colnN33";
            this.tblExtFileTransColumn_colnN33.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN33.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN33.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN33.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN33.NamedProperties.Put("SqlColumn", "N33");
            this.tblExtFileTransColumn_colnN33.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN33.Position = 239;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN33, "tblExtFileTransColumn_colnN33");
            // 
            // tblExtFileTransColumn_colnN34
            // 
            this.tblExtFileTransColumn_colnN34.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN34.Name = "tblExtFileTransColumn_colnN34";
            this.tblExtFileTransColumn_colnN34.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN34.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN34.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN34.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN34.NamedProperties.Put("SqlColumn", "N34");
            this.tblExtFileTransColumn_colnN34.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN34.Position = 240;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN34, "tblExtFileTransColumn_colnN34");
            // 
            // tblExtFileTransColumn_colnN35
            // 
            this.tblExtFileTransColumn_colnN35.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN35.Name = "tblExtFileTransColumn_colnN35";
            this.tblExtFileTransColumn_colnN35.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN35.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN35.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN35.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN35.NamedProperties.Put("SqlColumn", "N35");
            this.tblExtFileTransColumn_colnN35.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN35.Position = 241;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN35, "tblExtFileTransColumn_colnN35");
            // 
            // tblExtFileTransColumn_colnN36
            // 
            this.tblExtFileTransColumn_colnN36.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN36.Name = "tblExtFileTransColumn_colnN36";
            this.tblExtFileTransColumn_colnN36.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN36.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN36.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN36.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN36.NamedProperties.Put("SqlColumn", "N36");
            this.tblExtFileTransColumn_colnN36.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN36.Position = 242;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN36, "tblExtFileTransColumn_colnN36");
            // 
            // tblExtFileTransColumn_colnN37
            // 
            this.tblExtFileTransColumn_colnN37.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN37.Name = "tblExtFileTransColumn_colnN37";
            this.tblExtFileTransColumn_colnN37.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN37.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN37.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN37.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN37.NamedProperties.Put("SqlColumn", "N37");
            this.tblExtFileTransColumn_colnN37.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN37.Position = 243;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN37, "tblExtFileTransColumn_colnN37");
            // 
            // tblExtFileTransColumn_colnN38
            // 
            this.tblExtFileTransColumn_colnN38.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN38.Name = "tblExtFileTransColumn_colnN38";
            this.tblExtFileTransColumn_colnN38.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN38.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN38.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN38.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN38.NamedProperties.Put("SqlColumn", "N38");
            this.tblExtFileTransColumn_colnN38.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN38.Position = 244;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN38, "tblExtFileTransColumn_colnN38");
            // 
            // tblExtFileTransColumn_colnN39
            // 
            this.tblExtFileTransColumn_colnN39.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN39.Name = "tblExtFileTransColumn_colnN39";
            this.tblExtFileTransColumn_colnN39.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN39.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN39.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN39.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN39.NamedProperties.Put("SqlColumn", "N39");
            this.tblExtFileTransColumn_colnN39.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN39.Position = 245;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN39, "tblExtFileTransColumn_colnN39");
            // 
            // tblExtFileTransColumn_colnN40
            // 
            this.tblExtFileTransColumn_colnN40.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN40.Name = "tblExtFileTransColumn_colnN40";
            this.tblExtFileTransColumn_colnN40.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN40.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN40.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN40.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN40.NamedProperties.Put("SqlColumn", "N40");
            this.tblExtFileTransColumn_colnN40.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN40.Position = 246;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN40, "tblExtFileTransColumn_colnN40");
            // 
            // tblExtFileTransColumn_colnN41
            // 
            this.tblExtFileTransColumn_colnN41.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN41.Name = "tblExtFileTransColumn_colnN41";
            this.tblExtFileTransColumn_colnN41.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN41.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN41.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN41.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN41.NamedProperties.Put("SqlColumn", "N41");
            this.tblExtFileTransColumn_colnN41.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN41.Position = 247;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN41, "tblExtFileTransColumn_colnN41");
            // 
            // tblExtFileTransColumn_colnN42
            // 
            this.tblExtFileTransColumn_colnN42.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN42.Name = "tblExtFileTransColumn_colnN42";
            this.tblExtFileTransColumn_colnN42.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN42.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN42.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN42.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN42.NamedProperties.Put("SqlColumn", "N42");
            this.tblExtFileTransColumn_colnN42.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN42.Position = 248;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN42, "tblExtFileTransColumn_colnN42");
            // 
            // tblExtFileTransColumn_colnN43
            // 
            this.tblExtFileTransColumn_colnN43.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN43.Name = "tblExtFileTransColumn_colnN43";
            this.tblExtFileTransColumn_colnN43.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN43.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN43.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN43.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN43.NamedProperties.Put("SqlColumn", "N43");
            this.tblExtFileTransColumn_colnN43.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN43.Position = 249;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN43, "tblExtFileTransColumn_colnN43");
            // 
            // tblExtFileTransColumn_colnN44
            // 
            this.tblExtFileTransColumn_colnN44.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN44.Name = "tblExtFileTransColumn_colnN44";
            this.tblExtFileTransColumn_colnN44.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN44.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN44.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN44.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN44.NamedProperties.Put("SqlColumn", "N44");
            this.tblExtFileTransColumn_colnN44.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN44.Position = 250;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN44, "tblExtFileTransColumn_colnN44");
            // 
            // tblExtFileTransColumn_colnN45
            // 
            this.tblExtFileTransColumn_colnN45.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN45.Name = "tblExtFileTransColumn_colnN45";
            this.tblExtFileTransColumn_colnN45.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN45.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN45.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN45.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN45.NamedProperties.Put("SqlColumn", "N45");
            this.tblExtFileTransColumn_colnN45.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN45.Position = 251;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN45, "tblExtFileTransColumn_colnN45");
            // 
            // tblExtFileTransColumn_colnN46
            // 
            this.tblExtFileTransColumn_colnN46.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN46.Name = "tblExtFileTransColumn_colnN46";
            this.tblExtFileTransColumn_colnN46.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN46.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN46.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN46.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN46.NamedProperties.Put("SqlColumn", "N46");
            this.tblExtFileTransColumn_colnN46.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN46.Position = 252;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN46, "tblExtFileTransColumn_colnN46");
            // 
            // tblExtFileTransColumn_colnN47
            // 
            this.tblExtFileTransColumn_colnN47.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN47.Name = "tblExtFileTransColumn_colnN47";
            this.tblExtFileTransColumn_colnN47.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN47.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN47.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN47.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN47.NamedProperties.Put("SqlColumn", "N47");
            this.tblExtFileTransColumn_colnN47.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN47.Position = 253;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN47, "tblExtFileTransColumn_colnN47");
            // 
            // tblExtFileTransColumn_colnN48
            // 
            this.tblExtFileTransColumn_colnN48.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN48.Name = "tblExtFileTransColumn_colnN48";
            this.tblExtFileTransColumn_colnN48.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN48.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN48.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN48.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN48.NamedProperties.Put("SqlColumn", "N48");
            this.tblExtFileTransColumn_colnN48.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN48.Position = 254;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN48, "tblExtFileTransColumn_colnN48");
            // 
            // tblExtFileTransColumn_colnN49
            // 
            this.tblExtFileTransColumn_colnN49.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN49.Name = "tblExtFileTransColumn_colnN49";
            this.tblExtFileTransColumn_colnN49.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN49.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN49.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN49.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN49.NamedProperties.Put("SqlColumn", "N49");
            this.tblExtFileTransColumn_colnN49.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN49.Position = 255;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN49, "tblExtFileTransColumn_colnN49");
            // 
            // tblExtFileTransColumn_colnN50
            // 
            this.tblExtFileTransColumn_colnN50.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN50.Name = "tblExtFileTransColumn_colnN50";
            this.tblExtFileTransColumn_colnN50.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN50.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN50.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN50.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN50.NamedProperties.Put("SqlColumn", "N50");
            this.tblExtFileTransColumn_colnN50.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN50.Position = 256;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN50, "tblExtFileTransColumn_colnN50");
            // 
            // tblExtFileTransColumn_colnN51
            // 
            this.tblExtFileTransColumn_colnN51.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN51.Name = "tblExtFileTransColumn_colnN51";
            this.tblExtFileTransColumn_colnN51.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN51.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN51.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN51.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN51.NamedProperties.Put("SqlColumn", "N51");
            this.tblExtFileTransColumn_colnN51.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN51.Position = 257;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN51, "tblExtFileTransColumn_colnN51");
            // 
            // tblExtFileTransColumn_colnN52
            // 
            this.tblExtFileTransColumn_colnN52.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN52.Name = "tblExtFileTransColumn_colnN52";
            this.tblExtFileTransColumn_colnN52.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN52.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN52.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN52.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN52.NamedProperties.Put("SqlColumn", "N52");
            this.tblExtFileTransColumn_colnN52.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN52.Position = 258;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN52, "tblExtFileTransColumn_colnN52");
            // 
            // tblExtFileTransColumn_colnN53
            // 
            this.tblExtFileTransColumn_colnN53.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN53.Name = "tblExtFileTransColumn_colnN53";
            this.tblExtFileTransColumn_colnN53.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN53.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN53.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN53.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN53.NamedProperties.Put("SqlColumn", "N53");
            this.tblExtFileTransColumn_colnN53.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN53.Position = 259;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN53, "tblExtFileTransColumn_colnN53");
            // 
            // tblExtFileTransColumn_colnN54
            // 
            this.tblExtFileTransColumn_colnN54.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN54.Name = "tblExtFileTransColumn_colnN54";
            this.tblExtFileTransColumn_colnN54.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN54.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN54.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN54.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN54.NamedProperties.Put("SqlColumn", "N54");
            this.tblExtFileTransColumn_colnN54.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN54.Position = 260;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN54, "tblExtFileTransColumn_colnN54");
            // 
            // tblExtFileTransColumn_colnN55
            // 
            this.tblExtFileTransColumn_colnN55.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN55.Name = "tblExtFileTransColumn_colnN55";
            this.tblExtFileTransColumn_colnN55.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN55.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN55.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN55.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN55.NamedProperties.Put("SqlColumn", "N55");
            this.tblExtFileTransColumn_colnN55.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN55.Position = 261;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN55, "tblExtFileTransColumn_colnN55");
            // 
            // tblExtFileTransColumn_colnN56
            // 
            this.tblExtFileTransColumn_colnN56.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN56.Name = "tblExtFileTransColumn_colnN56";
            this.tblExtFileTransColumn_colnN56.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN56.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN56.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN56.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN56.NamedProperties.Put("SqlColumn", "N56");
            this.tblExtFileTransColumn_colnN56.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN56.Position = 262;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN56, "tblExtFileTransColumn_colnN56");
            // 
            // tblExtFileTransColumn_colnN57
            // 
            this.tblExtFileTransColumn_colnN57.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN57.Name = "tblExtFileTransColumn_colnN57";
            this.tblExtFileTransColumn_colnN57.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN57.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN57.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN57.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN57.NamedProperties.Put("SqlColumn", "N57");
            this.tblExtFileTransColumn_colnN57.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN57.Position = 263;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN57, "tblExtFileTransColumn_colnN57");
            // 
            // tblExtFileTransColumn_colnN58
            // 
            this.tblExtFileTransColumn_colnN58.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN58.Name = "tblExtFileTransColumn_colnN58";
            this.tblExtFileTransColumn_colnN58.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN58.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN58.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN58.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN58.NamedProperties.Put("SqlColumn", "N58");
            this.tblExtFileTransColumn_colnN58.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN58.Position = 264;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN58, "tblExtFileTransColumn_colnN58");
            // 
            // tblExtFileTransColumn_colnN59
            // 
            this.tblExtFileTransColumn_colnN59.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN59.Name = "tblExtFileTransColumn_colnN59";
            this.tblExtFileTransColumn_colnN59.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN59.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN59.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN59.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN59.NamedProperties.Put("SqlColumn", "N59");
            this.tblExtFileTransColumn_colnN59.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN59.Position = 265;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN59, "tblExtFileTransColumn_colnN59");
            // 
            // tblExtFileTransColumn_colnN60
            // 
            this.tblExtFileTransColumn_colnN60.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN60.Name = "tblExtFileTransColumn_colnN60";
            this.tblExtFileTransColumn_colnN60.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN60.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN60.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN60.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN60.NamedProperties.Put("SqlColumn", "N60");
            this.tblExtFileTransColumn_colnN60.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN60.Position = 266;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN60, "tblExtFileTransColumn_colnN60");
            // 
            // tblExtFileTransColumn_colnN61
            // 
            this.tblExtFileTransColumn_colnN61.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN61.Name = "tblExtFileTransColumn_colnN61";
            this.tblExtFileTransColumn_colnN61.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN61.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN61.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN61.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN61.NamedProperties.Put("SqlColumn", "N61");
            this.tblExtFileTransColumn_colnN61.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN61.Position = 267;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN61, "tblExtFileTransColumn_colnN61");
            // 
            // tblExtFileTransColumn_colnN62
            // 
            this.tblExtFileTransColumn_colnN62.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN62.Name = "tblExtFileTransColumn_colnN62";
            this.tblExtFileTransColumn_colnN62.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN62.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN62.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN62.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN62.NamedProperties.Put("SqlColumn", "N62");
            this.tblExtFileTransColumn_colnN62.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN62.Position = 268;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN62, "tblExtFileTransColumn_colnN62");
            // 
            // tblExtFileTransColumn_colnN63
            // 
            this.tblExtFileTransColumn_colnN63.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN63.Name = "tblExtFileTransColumn_colnN63";
            this.tblExtFileTransColumn_colnN63.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN63.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN63.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN63.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN63.NamedProperties.Put("SqlColumn", "N63");
            this.tblExtFileTransColumn_colnN63.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN63.Position = 269;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN63, "tblExtFileTransColumn_colnN63");
            // 
            // tblExtFileTransColumn_colnN64
            // 
            this.tblExtFileTransColumn_colnN64.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN64.Name = "tblExtFileTransColumn_colnN64";
            this.tblExtFileTransColumn_colnN64.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN64.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN64.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN64.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN64.NamedProperties.Put("SqlColumn", "N64");
            this.tblExtFileTransColumn_colnN64.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN64.Position = 270;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN64, "tblExtFileTransColumn_colnN64");
            // 
            // tblExtFileTransColumn_colnN65
            // 
            this.tblExtFileTransColumn_colnN65.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN65.Name = "tblExtFileTransColumn_colnN65";
            this.tblExtFileTransColumn_colnN65.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN65.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN65.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN65.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN65.NamedProperties.Put("SqlColumn", "N65");
            this.tblExtFileTransColumn_colnN65.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN65.Position = 271;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN65, "tblExtFileTransColumn_colnN65");
            // 
            // tblExtFileTransColumn_colnN66
            // 
            this.tblExtFileTransColumn_colnN66.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN66.Name = "tblExtFileTransColumn_colnN66";
            this.tblExtFileTransColumn_colnN66.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN66.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN66.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN66.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN66.NamedProperties.Put("SqlColumn", "N66");
            this.tblExtFileTransColumn_colnN66.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN66.Position = 272;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN66, "tblExtFileTransColumn_colnN66");
            // 
            // tblExtFileTransColumn_colnN67
            // 
            this.tblExtFileTransColumn_colnN67.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN67.Name = "tblExtFileTransColumn_colnN67";
            this.tblExtFileTransColumn_colnN67.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN67.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN67.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN67.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN67.NamedProperties.Put("SqlColumn", "N67");
            this.tblExtFileTransColumn_colnN67.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN67.Position = 273;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN67, "tblExtFileTransColumn_colnN67");
            // 
            // tblExtFileTransColumn_colnN68
            // 
            this.tblExtFileTransColumn_colnN68.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN68.Name = "tblExtFileTransColumn_colnN68";
            this.tblExtFileTransColumn_colnN68.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN68.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN68.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN68.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN68.NamedProperties.Put("SqlColumn", "N68");
            this.tblExtFileTransColumn_colnN68.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN68.Position = 274;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN68, "tblExtFileTransColumn_colnN68");
            // 
            // tblExtFileTransColumn_colnN69
            // 
            this.tblExtFileTransColumn_colnN69.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN69.Name = "tblExtFileTransColumn_colnN69";
            this.tblExtFileTransColumn_colnN69.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN69.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN69.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN69.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN69.NamedProperties.Put("SqlColumn", "N69");
            this.tblExtFileTransColumn_colnN69.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN69.Position = 275;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN69, "tblExtFileTransColumn_colnN69");
            // 
            // tblExtFileTransColumn_colnN70
            // 
            this.tblExtFileTransColumn_colnN70.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN70.Name = "tblExtFileTransColumn_colnN70";
            this.tblExtFileTransColumn_colnN70.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN70.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN70.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN70.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN70.NamedProperties.Put("SqlColumn", "N70");
            this.tblExtFileTransColumn_colnN70.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN70.Position = 276;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN70, "tblExtFileTransColumn_colnN70");
            // 
            // tblExtFileTransColumn_colnN71
            // 
            this.tblExtFileTransColumn_colnN71.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN71.Name = "tblExtFileTransColumn_colnN71";
            this.tblExtFileTransColumn_colnN71.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN71.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN71.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN71.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN71.NamedProperties.Put("SqlColumn", "N71");
            this.tblExtFileTransColumn_colnN71.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN71.Position = 277;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN71, "tblExtFileTransColumn_colnN71");
            // 
            // tblExtFileTransColumn_colnN72
            // 
            this.tblExtFileTransColumn_colnN72.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN72.Name = "tblExtFileTransColumn_colnN72";
            this.tblExtFileTransColumn_colnN72.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN72.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN72.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN72.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN72.NamedProperties.Put("SqlColumn", "N72");
            this.tblExtFileTransColumn_colnN72.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN72.Position = 278;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN72, "tblExtFileTransColumn_colnN72");
            // 
            // tblExtFileTransColumn_colnN73
            // 
            this.tblExtFileTransColumn_colnN73.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN73.Name = "tblExtFileTransColumn_colnN73";
            this.tblExtFileTransColumn_colnN73.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN73.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN73.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN73.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN73.NamedProperties.Put("SqlColumn", "N73");
            this.tblExtFileTransColumn_colnN73.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN73.Position = 279;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN73, "tblExtFileTransColumn_colnN73");
            // 
            // tblExtFileTransColumn_colnN74
            // 
            this.tblExtFileTransColumn_colnN74.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN74.Name = "tblExtFileTransColumn_colnN74";
            this.tblExtFileTransColumn_colnN74.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN74.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN74.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN74.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN74.NamedProperties.Put("SqlColumn", "N74");
            this.tblExtFileTransColumn_colnN74.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN74.Position = 280;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN74, "tblExtFileTransColumn_colnN74");
            // 
            // tblExtFileTransColumn_colnN75
            // 
            this.tblExtFileTransColumn_colnN75.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN75.Name = "tblExtFileTransColumn_colnN75";
            this.tblExtFileTransColumn_colnN75.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN75.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN75.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN75.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN75.NamedProperties.Put("SqlColumn", "N75");
            this.tblExtFileTransColumn_colnN75.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN75.Position = 281;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN75, "tblExtFileTransColumn_colnN75");
            // 
            // tblExtFileTransColumn_colnN76
            // 
            this.tblExtFileTransColumn_colnN76.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN76.Name = "tblExtFileTransColumn_colnN76";
            this.tblExtFileTransColumn_colnN76.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN76.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN76.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN76.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN76.NamedProperties.Put("SqlColumn", "N76");
            this.tblExtFileTransColumn_colnN76.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN76.Position = 282;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN76, "tblExtFileTransColumn_colnN76");
            // 
            // tblExtFileTransColumn_colnN77
            // 
            this.tblExtFileTransColumn_colnN77.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN77.Name = "tblExtFileTransColumn_colnN77";
            this.tblExtFileTransColumn_colnN77.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN77.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN77.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN77.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN77.NamedProperties.Put("SqlColumn", "N77");
            this.tblExtFileTransColumn_colnN77.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN77.Position = 283;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN77, "tblExtFileTransColumn_colnN77");
            // 
            // tblExtFileTransColumn_colnN78
            // 
            this.tblExtFileTransColumn_colnN78.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN78.Name = "tblExtFileTransColumn_colnN78";
            this.tblExtFileTransColumn_colnN78.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN78.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN78.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN78.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN78.NamedProperties.Put("SqlColumn", "N78");
            this.tblExtFileTransColumn_colnN78.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN78.Position = 284;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN78, "tblExtFileTransColumn_colnN78");
            // 
            // tblExtFileTransColumn_colnN79
            // 
            this.tblExtFileTransColumn_colnN79.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN79.Name = "tblExtFileTransColumn_colnN79";
            this.tblExtFileTransColumn_colnN79.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN79.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN79.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN79.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN79.NamedProperties.Put("SqlColumn", "N79");
            this.tblExtFileTransColumn_colnN79.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN79.Position = 285;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN79, "tblExtFileTransColumn_colnN79");
            // 
            // tblExtFileTransColumn_colnN80
            // 
            this.tblExtFileTransColumn_colnN80.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN80.Name = "tblExtFileTransColumn_colnN80";
            this.tblExtFileTransColumn_colnN80.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN80.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN80.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN80.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN80.NamedProperties.Put("SqlColumn", "N80");
            this.tblExtFileTransColumn_colnN80.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN80.Position = 286;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN80, "tblExtFileTransColumn_colnN80");
            // 
            // tblExtFileTransColumn_colnN81
            // 
            this.tblExtFileTransColumn_colnN81.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN81.Name = "tblExtFileTransColumn_colnN81";
            this.tblExtFileTransColumn_colnN81.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN81.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN81.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN81.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN81.NamedProperties.Put("SqlColumn", "N81");
            this.tblExtFileTransColumn_colnN81.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN81.Position = 287;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN81, "tblExtFileTransColumn_colnN81");
            // 
            // tblExtFileTransColumn_colnN82
            // 
            this.tblExtFileTransColumn_colnN82.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN82.Name = "tblExtFileTransColumn_colnN82";
            this.tblExtFileTransColumn_colnN82.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN82.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN82.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN82.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN82.NamedProperties.Put("SqlColumn", "N82");
            this.tblExtFileTransColumn_colnN82.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN82.Position = 288;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN82, "tblExtFileTransColumn_colnN82");
            // 
            // tblExtFileTransColumn_colnN83
            // 
            this.tblExtFileTransColumn_colnN83.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN83.Name = "tblExtFileTransColumn_colnN83";
            this.tblExtFileTransColumn_colnN83.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN83.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN83.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN83.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN83.NamedProperties.Put("SqlColumn", "N83");
            this.tblExtFileTransColumn_colnN83.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN83.Position = 289;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN83, "tblExtFileTransColumn_colnN83");
            // 
            // tblExtFileTransColumn_colnN84
            // 
            this.tblExtFileTransColumn_colnN84.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN84.Name = "tblExtFileTransColumn_colnN84";
            this.tblExtFileTransColumn_colnN84.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN84.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN84.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN84.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN84.NamedProperties.Put("SqlColumn", "N84");
            this.tblExtFileTransColumn_colnN84.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN84.Position = 290;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN84, "tblExtFileTransColumn_colnN84");
            // 
            // tblExtFileTransColumn_colnN85
            // 
            this.tblExtFileTransColumn_colnN85.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN85.Name = "tblExtFileTransColumn_colnN85";
            this.tblExtFileTransColumn_colnN85.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN85.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN85.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN85.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN85.NamedProperties.Put("SqlColumn", "N85");
            this.tblExtFileTransColumn_colnN85.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN85.Position = 291;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN85, "tblExtFileTransColumn_colnN85");
            // 
            // tblExtFileTransColumn_colnN86
            // 
            this.tblExtFileTransColumn_colnN86.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN86.Name = "tblExtFileTransColumn_colnN86";
            this.tblExtFileTransColumn_colnN86.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN86.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN86.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN86.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN86.NamedProperties.Put("SqlColumn", "N86");
            this.tblExtFileTransColumn_colnN86.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN86.Position = 292;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN86, "tblExtFileTransColumn_colnN86");
            // 
            // tblExtFileTransColumn_colnN87
            // 
            this.tblExtFileTransColumn_colnN87.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN87.Name = "tblExtFileTransColumn_colnN87";
            this.tblExtFileTransColumn_colnN87.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN87.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN87.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN87.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN87.NamedProperties.Put("SqlColumn", "N87");
            this.tblExtFileTransColumn_colnN87.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN87.Position = 293;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN87, "tblExtFileTransColumn_colnN87");
            // 
            // tblExtFileTransColumn_colnN88
            // 
            this.tblExtFileTransColumn_colnN88.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN88.Name = "tblExtFileTransColumn_colnN88";
            this.tblExtFileTransColumn_colnN88.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN88.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN88.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN88.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN88.NamedProperties.Put("SqlColumn", "N88");
            this.tblExtFileTransColumn_colnN88.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN88.Position = 294;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN88, "tblExtFileTransColumn_colnN88");
            // 
            // tblExtFileTransColumn_colnN89
            // 
            this.tblExtFileTransColumn_colnN89.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN89.Name = "tblExtFileTransColumn_colnN89";
            this.tblExtFileTransColumn_colnN89.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN89.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN89.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN89.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN89.NamedProperties.Put("SqlColumn", "N89");
            this.tblExtFileTransColumn_colnN89.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN89.Position = 295;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN89, "tblExtFileTransColumn_colnN89");
            // 
            // tblExtFileTransColumn_colnN90
            // 
            this.tblExtFileTransColumn_colnN90.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN90.Name = "tblExtFileTransColumn_colnN90";
            this.tblExtFileTransColumn_colnN90.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN90.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN90.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN90.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN90.NamedProperties.Put("SqlColumn", "N90");
            this.tblExtFileTransColumn_colnN90.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN90.Position = 296;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN90, "tblExtFileTransColumn_colnN90");
            // 
            // tblExtFileTransColumn_colnN91
            // 
            this.tblExtFileTransColumn_colnN91.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN91.Name = "tblExtFileTransColumn_colnN91";
            this.tblExtFileTransColumn_colnN91.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN91.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN91.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN91.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN91.NamedProperties.Put("SqlColumn", "N91");
            this.tblExtFileTransColumn_colnN91.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN91.Position = 297;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN91, "tblExtFileTransColumn_colnN91");
            // 
            // tblExtFileTransColumn_colnN92
            // 
            this.tblExtFileTransColumn_colnN92.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN92.Name = "tblExtFileTransColumn_colnN92";
            this.tblExtFileTransColumn_colnN92.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN92.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN92.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN92.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN92.NamedProperties.Put("SqlColumn", "N92");
            this.tblExtFileTransColumn_colnN92.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN92.Position = 298;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN92, "tblExtFileTransColumn_colnN92");
            // 
            // tblExtFileTransColumn_colnN93
            // 
            this.tblExtFileTransColumn_colnN93.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN93.Name = "tblExtFileTransColumn_colnN93";
            this.tblExtFileTransColumn_colnN93.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN93.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN93.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN93.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN93.NamedProperties.Put("SqlColumn", "N93");
            this.tblExtFileTransColumn_colnN93.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN93.Position = 299;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN93, "tblExtFileTransColumn_colnN93");
            // 
            // tblExtFileTransColumn_colnN94
            // 
            this.tblExtFileTransColumn_colnN94.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN94.Name = "tblExtFileTransColumn_colnN94";
            this.tblExtFileTransColumn_colnN94.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN94.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN94.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN94.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN94.NamedProperties.Put("SqlColumn", "N94");
            this.tblExtFileTransColumn_colnN94.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN94.Position = 300;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN94, "tblExtFileTransColumn_colnN94");
            // 
            // tblExtFileTransColumn_colnN95
            // 
            this.tblExtFileTransColumn_colnN95.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN95.Name = "tblExtFileTransColumn_colnN95";
            this.tblExtFileTransColumn_colnN95.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN95.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN95.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN95.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN95.NamedProperties.Put("SqlColumn", "N95");
            this.tblExtFileTransColumn_colnN95.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN95.Position = 301;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN95, "tblExtFileTransColumn_colnN95");
            // 
            // tblExtFileTransColumn_colnN96
            // 
            this.tblExtFileTransColumn_colnN96.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN96.Name = "tblExtFileTransColumn_colnN96";
            this.tblExtFileTransColumn_colnN96.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN96.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN96.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN96.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN96.NamedProperties.Put("SqlColumn", "N96");
            this.tblExtFileTransColumn_colnN96.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN96.Position = 302;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN96, "tblExtFileTransColumn_colnN96");
            // 
            // tblExtFileTransColumn_colnN97
            // 
            this.tblExtFileTransColumn_colnN97.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN97.Name = "tblExtFileTransColumn_colnN97";
            this.tblExtFileTransColumn_colnN97.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN97.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN97.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN97.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN97.NamedProperties.Put("SqlColumn", "N97");
            this.tblExtFileTransColumn_colnN97.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN97.Position = 303;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN97, "tblExtFileTransColumn_colnN97");
            // 
            // tblExtFileTransColumn_colnN98
            // 
            this.tblExtFileTransColumn_colnN98.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN98.Name = "tblExtFileTransColumn_colnN98";
            this.tblExtFileTransColumn_colnN98.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN98.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN98.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN98.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN98.NamedProperties.Put("SqlColumn", "N98");
            this.tblExtFileTransColumn_colnN98.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN98.Position = 304;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN98, "tblExtFileTransColumn_colnN98");
            // 
            // tblExtFileTransColumn_colnN99
            // 
            this.tblExtFileTransColumn_colnN99.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTransColumn_colnN99.Name = "tblExtFileTransColumn_colnN99";
            this.tblExtFileTransColumn_colnN99.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_colnN99.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_colnN99.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_colnN99.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTransColumn_colnN99.NamedProperties.Put("SqlColumn", "N99");
            this.tblExtFileTransColumn_colnN99.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTransColumn_colnN99.Position = 305;
            resources.ApplyResources(this.tblExtFileTransColumn_colnN99, "tblExtFileTransColumn_colnN99");
            // 
            // tblExtFileTransColumn_coldD1
            // 
            this.tblExtFileTransColumn_coldD1.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD1.Format = "d";
            this.tblExtFileTransColumn_coldD1.Name = "tblExtFileTransColumn_coldD1";
            this.tblExtFileTransColumn_coldD1.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD1.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD1.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD1.NamedProperties.Put("SqlColumn", "D1");
            this.tblExtFileTransColumn_coldD1.Position = 306;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD1, "tblExtFileTransColumn_coldD1");
            // 
            // tblExtFileTransColumn_coldD2
            // 
            this.tblExtFileTransColumn_coldD2.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD2.Format = "d";
            this.tblExtFileTransColumn_coldD2.Name = "tblExtFileTransColumn_coldD2";
            this.tblExtFileTransColumn_coldD2.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD2.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD2.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD2.NamedProperties.Put("SqlColumn", "D2");
            this.tblExtFileTransColumn_coldD2.Position = 307;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD2, "tblExtFileTransColumn_coldD2");
            // 
            // tblExtFileTransColumn_coldD3
            // 
            this.tblExtFileTransColumn_coldD3.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD3.Format = "d";
            this.tblExtFileTransColumn_coldD3.Name = "tblExtFileTransColumn_coldD3";
            this.tblExtFileTransColumn_coldD3.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD3.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD3.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD3.NamedProperties.Put("SqlColumn", "D3");
            this.tblExtFileTransColumn_coldD3.Position = 308;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD3, "tblExtFileTransColumn_coldD3");
            // 
            // tblExtFileTransColumn_coldD4
            // 
            this.tblExtFileTransColumn_coldD4.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD4.Format = "d";
            this.tblExtFileTransColumn_coldD4.Name = "tblExtFileTransColumn_coldD4";
            this.tblExtFileTransColumn_coldD4.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD4.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD4.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD4.NamedProperties.Put("SqlColumn", "D4");
            this.tblExtFileTransColumn_coldD4.Position = 309;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD4, "tblExtFileTransColumn_coldD4");
            // 
            // tblExtFileTransColumn_coldD5
            // 
            this.tblExtFileTransColumn_coldD5.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD5.Format = "d";
            this.tblExtFileTransColumn_coldD5.Name = "tblExtFileTransColumn_coldD5";
            this.tblExtFileTransColumn_coldD5.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD5.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD5.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD5.NamedProperties.Put("SqlColumn", "D5");
            this.tblExtFileTransColumn_coldD5.Position = 310;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD5, "tblExtFileTransColumn_coldD5");
            // 
            // tblExtFileTransColumn_coldD6
            // 
            this.tblExtFileTransColumn_coldD6.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD6.Format = "d";
            this.tblExtFileTransColumn_coldD6.Name = "tblExtFileTransColumn_coldD6";
            this.tblExtFileTransColumn_coldD6.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD6.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD6.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD6.NamedProperties.Put("SqlColumn", "D6");
            this.tblExtFileTransColumn_coldD6.Position = 311;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD6, "tblExtFileTransColumn_coldD6");
            // 
            // tblExtFileTransColumn_coldD7
            // 
            this.tblExtFileTransColumn_coldD7.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD7.Format = "d";
            this.tblExtFileTransColumn_coldD7.Name = "tblExtFileTransColumn_coldD7";
            this.tblExtFileTransColumn_coldD7.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD7.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD7.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD7.NamedProperties.Put("SqlColumn", "D7");
            this.tblExtFileTransColumn_coldD7.Position = 312;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD7, "tblExtFileTransColumn_coldD7");
            // 
            // tblExtFileTransColumn_coldD8
            // 
            this.tblExtFileTransColumn_coldD8.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD8.Format = "d";
            this.tblExtFileTransColumn_coldD8.Name = "tblExtFileTransColumn_coldD8";
            this.tblExtFileTransColumn_coldD8.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD8.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD8.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD8.NamedProperties.Put("SqlColumn", "D8");
            this.tblExtFileTransColumn_coldD8.Position = 313;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD8, "tblExtFileTransColumn_coldD8");
            // 
            // tblExtFileTransColumn_coldD9
            // 
            this.tblExtFileTransColumn_coldD9.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD9.Format = "d";
            this.tblExtFileTransColumn_coldD9.Name = "tblExtFileTransColumn_coldD9";
            this.tblExtFileTransColumn_coldD9.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD9.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD9.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD9.NamedProperties.Put("SqlColumn", "D9");
            this.tblExtFileTransColumn_coldD9.Position = 314;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD9, "tblExtFileTransColumn_coldD9");
            // 
            // tblExtFileTransColumn_coldD10
            // 
            this.tblExtFileTransColumn_coldD10.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD10.Format = "d";
            this.tblExtFileTransColumn_coldD10.Name = "tblExtFileTransColumn_coldD10";
            this.tblExtFileTransColumn_coldD10.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD10.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD10.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD10.NamedProperties.Put("SqlColumn", "D10");
            this.tblExtFileTransColumn_coldD10.Position = 315;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD10, "tblExtFileTransColumn_coldD10");
            // 
            // tblExtFileTransColumn_coldD11
            // 
            this.tblExtFileTransColumn_coldD11.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD11.Format = "d";
            this.tblExtFileTransColumn_coldD11.Name = "tblExtFileTransColumn_coldD11";
            this.tblExtFileTransColumn_coldD11.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD11.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD11.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD11.NamedProperties.Put("SqlColumn", "D11");
            this.tblExtFileTransColumn_coldD11.Position = 316;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD11, "tblExtFileTransColumn_coldD11");
            // 
            // tblExtFileTransColumn_coldD12
            // 
            this.tblExtFileTransColumn_coldD12.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD12.Format = "d";
            this.tblExtFileTransColumn_coldD12.Name = "tblExtFileTransColumn_coldD12";
            this.tblExtFileTransColumn_coldD12.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD12.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD12.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD12.NamedProperties.Put("SqlColumn", "D12");
            this.tblExtFileTransColumn_coldD12.Position = 317;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD12, "tblExtFileTransColumn_coldD12");
            // 
            // tblExtFileTransColumn_coldD13
            // 
            this.tblExtFileTransColumn_coldD13.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD13.Format = "d";
            this.tblExtFileTransColumn_coldD13.Name = "tblExtFileTransColumn_coldD13";
            this.tblExtFileTransColumn_coldD13.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD13.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD13.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD13.NamedProperties.Put("SqlColumn", "D13");
            this.tblExtFileTransColumn_coldD13.Position = 318;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD13, "tblExtFileTransColumn_coldD13");
            // 
            // tblExtFileTransColumn_coldD14
            // 
            this.tblExtFileTransColumn_coldD14.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD14.Format = "d";
            this.tblExtFileTransColumn_coldD14.Name = "tblExtFileTransColumn_coldD14";
            this.tblExtFileTransColumn_coldD14.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD14.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD14.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD14.NamedProperties.Put("SqlColumn", "D14");
            this.tblExtFileTransColumn_coldD14.Position = 319;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD14, "tblExtFileTransColumn_coldD14");
            // 
            // tblExtFileTransColumn_coldD15
            // 
            this.tblExtFileTransColumn_coldD15.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD15.Format = "d";
            this.tblExtFileTransColumn_coldD15.Name = "tblExtFileTransColumn_coldD15";
            this.tblExtFileTransColumn_coldD15.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD15.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD15.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD15.NamedProperties.Put("SqlColumn", "D15");
            this.tblExtFileTransColumn_coldD15.Position = 320;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD15, "tblExtFileTransColumn_coldD15");
            // 
            // tblExtFileTransColumn_coldD16
            // 
            this.tblExtFileTransColumn_coldD16.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD16.Format = "d";
            this.tblExtFileTransColumn_coldD16.Name = "tblExtFileTransColumn_coldD16";
            this.tblExtFileTransColumn_coldD16.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD16.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD16.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD16.NamedProperties.Put("SqlColumn", "D16");
            this.tblExtFileTransColumn_coldD16.Position = 321;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD16, "tblExtFileTransColumn_coldD16");
            // 
            // tblExtFileTransColumn_coldD17
            // 
            this.tblExtFileTransColumn_coldD17.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD17.Format = "d";
            this.tblExtFileTransColumn_coldD17.Name = "tblExtFileTransColumn_coldD17";
            this.tblExtFileTransColumn_coldD17.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD17.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD17.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD17.NamedProperties.Put("SqlColumn", "D17");
            this.tblExtFileTransColumn_coldD17.Position = 322;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD17, "tblExtFileTransColumn_coldD17");
            // 
            // tblExtFileTransColumn_coldD18
            // 
            this.tblExtFileTransColumn_coldD18.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD18.Format = "d";
            this.tblExtFileTransColumn_coldD18.Name = "tblExtFileTransColumn_coldD18";
            this.tblExtFileTransColumn_coldD18.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD18.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD18.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD18.NamedProperties.Put("SqlColumn", "D18");
            this.tblExtFileTransColumn_coldD18.Position = 323;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD18, "tblExtFileTransColumn_coldD18");
            // 
            // tblExtFileTransColumn_coldD19
            // 
            this.tblExtFileTransColumn_coldD19.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD19.Format = "d";
            this.tblExtFileTransColumn_coldD19.Name = "tblExtFileTransColumn_coldD19";
            this.tblExtFileTransColumn_coldD19.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD19.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD19.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD19.NamedProperties.Put("SqlColumn", "D19");
            this.tblExtFileTransColumn_coldD19.Position = 324;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD19, "tblExtFileTransColumn_coldD19");
            // 
            // tblExtFileTransColumn_coldD20
            // 
            this.tblExtFileTransColumn_coldD20.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblExtFileTransColumn_coldD20.Format = "d";
            this.tblExtFileTransColumn_coldD20.Name = "tblExtFileTransColumn_coldD20";
            this.tblExtFileTransColumn_coldD20.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTransColumn_coldD20.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTransColumn_coldD20.NamedProperties.Put("LovReference", "");
            this.tblExtFileTransColumn_coldD20.NamedProperties.Put("SqlColumn", "D20");
            this.tblExtFileTransColumn_coldD20.Position = 325;
            resources.ApplyResources(this.tblExtFileTransColumn_coldD20, "tblExtFileTransColumn_coldD20");
            // 
            // tblExtFileTrans
            // 
            this.tblExtFileTrans.Controls.Add(this.tblExtFileTrans_colnLoadFileId);
            this.tblExtFileTrans.Controls.Add(this.tblExtFileTrans_colnRowNo);
            this.tblExtFileTrans.Controls.Add(this.tblExtFileTrans_colFileLine);
            this.tblExtFileTrans.Controls.Add(this.tblExtFileTrans_colsRowState);
            this.tblExtFileTrans.Controls.Add(this.tblExtFileTrans_colnRecordSetNo);
            this.tblExtFileTrans.Controls.Add(this.tblExtFileTrans_colsRecordTypeId);
            this.tblExtFileTrans.Controls.Add(this.tblExtFileTrans_colErrorText);
            this.tblExtFileTrans.Controls.Add(this.tblExtFileTrans_colsControlId);
            resources.ApplyResources(this.tblExtFileTrans, "tblExtFileTrans");
            this.tblExtFileTrans.Name = "tblExtFileTrans";
            this.tblExtFileTrans.NamedProperties.Put("DefaultOrderBy", "");
            this.tblExtFileTrans.NamedProperties.Put("DefaultWhere", "");
            this.tblExtFileTrans.NamedProperties.Put("LogicalUnit", "ExtFileTrans");
            this.tblExtFileTrans.NamedProperties.Put("PackageName", "EXT_FILE_TRANS_API");
            this.tblExtFileTrans.NamedProperties.Put("ResizeableChildObject", "LLMR");
            this.tblExtFileTrans.NamedProperties.Put("SourceFlags", "385");
            this.tblExtFileTrans.NamedProperties.Put("ViewName", "EXT_FILE_TRANS");
            this.tblExtFileTrans.NamedProperties.Put("Warnings", "FALSE");
            this.tblExtFileTrans.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblExtFileTrans_WindowActions);
            this.tblExtFileTrans.Controls.SetChildIndex(this.tblExtFileTrans_colsControlId, 0);
            this.tblExtFileTrans.Controls.SetChildIndex(this.tblExtFileTrans_colErrorText, 0);
            this.tblExtFileTrans.Controls.SetChildIndex(this.tblExtFileTrans_colsRecordTypeId, 0);
            this.tblExtFileTrans.Controls.SetChildIndex(this.tblExtFileTrans_colnRecordSetNo, 0);
            this.tblExtFileTrans.Controls.SetChildIndex(this.tblExtFileTrans_colsRowState, 0);
            this.tblExtFileTrans.Controls.SetChildIndex(this.tblExtFileTrans_colFileLine, 0);
            this.tblExtFileTrans.Controls.SetChildIndex(this.tblExtFileTrans_colnRowNo, 0);
            this.tblExtFileTrans.Controls.SetChildIndex(this.tblExtFileTrans_colnLoadFileId, 0);
            // 
            // tblExtFileTrans_colnLoadFileId
            // 
            this.tblExtFileTrans_colnLoadFileId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblExtFileTrans_colnLoadFileId, "tblExtFileTrans_colnLoadFileId");
            this.tblExtFileTrans_colnLoadFileId.Name = "tblExtFileTrans_colnLoadFileId";
            this.tblExtFileTrans_colnLoadFileId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTrans_colnLoadFileId.NamedProperties.Put("FieldFlags", "67");
            this.tblExtFileTrans_colnLoadFileId.NamedProperties.Put("LovReference", "EXT_FILE_LOAD");
            this.tblExtFileTrans_colnLoadFileId.NamedProperties.Put("SqlColumn", "LOAD_FILE_ID");
            this.tblExtFileTrans_colnLoadFileId.Position = 3;
            // 
            // tblExtFileTrans_colnRowNo
            // 
            this.tblExtFileTrans_colnRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTrans_colnRowNo.Name = "tblExtFileTrans_colnRowNo";
            this.tblExtFileTrans_colnRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTrans_colnRowNo.NamedProperties.Put("FieldFlags", "163");
            this.tblExtFileTrans_colnRowNo.NamedProperties.Put("LovReference", "");
            this.tblExtFileTrans_colnRowNo.NamedProperties.Put("SqlColumn", "ROW_NO");
            this.tblExtFileTrans_colnRowNo.Position = 4;
            resources.ApplyResources(this.tblExtFileTrans_colnRowNo, "tblExtFileTrans_colnRowNo");
            // 
            // tblExtFileTrans_colFileLine
            // 
            this.tblExtFileTrans_colFileLine.MaxLength = 2000;
            this.tblExtFileTrans_colFileLine.Name = "tblExtFileTrans_colFileLine";
            this.tblExtFileTrans_colFileLine.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTrans_colFileLine.NamedProperties.Put("FieldFlags", "311");
            this.tblExtFileTrans_colFileLine.NamedProperties.Put("LovReference", "");
            this.tblExtFileTrans_colFileLine.NamedProperties.Put("SqlColumn", "FILE_LINE");
            this.tblExtFileTrans_colFileLine.Position = 5;
            resources.ApplyResources(this.tblExtFileTrans_colFileLine, "tblExtFileTrans_colFileLine");
            // 
            // tblExtFileTrans_colsRowState
            // 
            resources.ApplyResources(this.tblExtFileTrans_colsRowState, "tblExtFileTrans_colsRowState");
            this.tblExtFileTrans_colsRowState.MaxLength = 200;
            this.tblExtFileTrans_colsRowState.Name = "tblExtFileTrans_colsRowState";
            this.tblExtFileTrans_colsRowState.NamedProperties.Put("EnumerateMethod", "EXT_FILE_ROW_STATE_API.Enumerate");
            this.tblExtFileTrans_colsRowState.NamedProperties.Put("FieldFlags", "291");
            this.tblExtFileTrans_colsRowState.NamedProperties.Put("LovReference", "");
            this.tblExtFileTrans_colsRowState.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTrans_colsRowState.NamedProperties.Put("SqlColumn", "ROW_STATE");
            this.tblExtFileTrans_colsRowState.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTrans_colsRowState.Position = 6;
            // 
            // tblExtFileTrans_colnRecordSetNo
            // 
            this.tblExtFileTrans_colnRecordSetNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblExtFileTrans_colnRecordSetNo.Name = "tblExtFileTrans_colnRecordSetNo";
            this.tblExtFileTrans_colnRecordSetNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTrans_colnRecordSetNo.NamedProperties.Put("FieldFlags", "295");
            this.tblExtFileTrans_colnRecordSetNo.NamedProperties.Put("LovReference", "");
            this.tblExtFileTrans_colnRecordSetNo.NamedProperties.Put("SqlColumn", "RECORD_SET_NO");
            this.tblExtFileTrans_colnRecordSetNo.Position = 7;
            resources.ApplyResources(this.tblExtFileTrans_colnRecordSetNo, "tblExtFileTrans_colnRecordSetNo");
            // 
            // tblExtFileTrans_colsRecordTypeId
            // 
            this.tblExtFileTrans_colsRecordTypeId.MaxLength = 200;
            this.tblExtFileTrans_colsRecordTypeId.Name = "tblExtFileTrans_colsRecordTypeId";
            this.tblExtFileTrans_colsRecordTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTrans_colsRecordTypeId.NamedProperties.Put("FieldFlags", "98");
            this.tblExtFileTrans_colsRecordTypeId.NamedProperties.Put("LovReference", "");
            this.tblExtFileTrans_colsRecordTypeId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTrans_colsRecordTypeId.NamedProperties.Put("SqlColumn", "RECORD_TYPE_ID");
            this.tblExtFileTrans_colsRecordTypeId.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTrans_colsRecordTypeId.Position = 8;
            resources.ApplyResources(this.tblExtFileTrans_colsRecordTypeId, "tblExtFileTrans_colsRecordTypeId");
            // 
            // tblExtFileTrans_colErrorText
            // 
            this.tblExtFileTrans_colErrorText.MaxLength = 2000;
            this.tblExtFileTrans_colErrorText.Name = "tblExtFileTrans_colErrorText";
            this.tblExtFileTrans_colErrorText.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTrans_colErrorText.NamedProperties.Put("FieldFlags", "306");
            this.tblExtFileTrans_colErrorText.NamedProperties.Put("LovReference", "");
            this.tblExtFileTrans_colErrorText.NamedProperties.Put("ResizeableChildObject", "");
            this.tblExtFileTrans_colErrorText.NamedProperties.Put("SqlColumn", "ERROR_TEXT");
            this.tblExtFileTrans_colErrorText.NamedProperties.Put("ValidateMethod", "");
            this.tblExtFileTrans_colErrorText.Position = 9;
            resources.ApplyResources(this.tblExtFileTrans_colErrorText, "tblExtFileTrans_colErrorText");
            // 
            // tblExtFileTrans_colsControlId
            // 
            this.tblExtFileTrans_colsControlId.MaxLength = 200;
            this.tblExtFileTrans_colsControlId.Name = "tblExtFileTrans_colsControlId";
            this.tblExtFileTrans_colsControlId.NamedProperties.Put("EnumerateMethod", "");
            this.tblExtFileTrans_colsControlId.NamedProperties.Put("FieldFlags", "294");
            this.tblExtFileTrans_colsControlId.NamedProperties.Put("LovReference", "");
            this.tblExtFileTrans_colsControlId.NamedProperties.Put("SqlColumn", "CONTROL_ID");
            this.tblExtFileTrans_colsControlId.Position = 10;
            resources.ApplyResources(this.tblExtFileTrans_colsControlId, "tblExtFileTrans_colsControlId");
            // 
            // frmExternalFileTransactions
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblExtFileTransColumn);
            this.Controls.Add(this.tblExtFileTrans);
            this.Controls.Add(this.dfsTargetDefaultMethod);
            this.Controls.Add(this.dfsFormName);
            this.Controls.Add(this.dfsViewName);
            this.Controls.Add(this.dfsFileDirectionDb);
            this.Controls.Add(this.dfsParameterString);
            this.Controls.Add(this.dfsApiToCall);
            this.Controls.Add(this.dfsStateDb);
            this.Controls.Add(this.dfsState);
            this.Controls.Add(this.dfsUserId);
            this.Controls.Add(this.dfFileName);
            this.Controls.Add(this.pbBrowser);
            this.Controls.Add(this.dfsMultiDirection);
            this.Controls.Add(this.cmbFileDirection);
            this.Controls.Add(this.dfFileTemplateIdName);
            this.Controls.Add(this.dfsFileTemplateId);
            this.Controls.Add(this.dfSetIdName);
            this.Controls.Add(this.dfsSetIdTest);
            this.Controls.Add(this.dfFileTypeName);
            this.Controls.Add(this.dfsFileType);
            this.Controls.Add(this.dfsCompany);
            this.Controls.Add(this.dfdLoadDate);
            this.Controls.Add(this.cmdLoadFileId);
            this.Controls.Add(this.labeldfsState);
            this.Controls.Add(this.labeldfsUserId);
            this.Controls.Add(this.labeldfFileName);
            this.Controls.Add(this.labelcmbFileDirection);
            this.Controls.Add(this.labeldfFileTemplateIdName);
            this.Controls.Add(this.labeldfsFileTemplateId);
            this.Controls.Add(this.labeldfSetIdName);
            this.Controls.Add(this.labeldfsSetIdTest);
            this.Controls.Add(this.labeldfFileTypeName);
            this.Controls.Add(this.labeldfsFileType);
            this.Controls.Add(this.labeldfdLoadDate);
            this.Controls.Add(this.labelcmdLoadFileId);
            this.Name = "frmExternalFileTransactions";
            this.NamedProperties.Put("DefaultOrderBy", "LOAD_FILE_ID DESC");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ExtFileLoad");
            this.NamedProperties.Put("PackageName", "EXT_FILE_LOAD_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "EXT_FILE_LOAD");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmExternalFileTransactions_WindowActions);
            this.menuFrmMethods.ResumeLayout(false);
            this.tblExtFileTransColumn.ResumeLayout(false);
            this.tblExtFileTrans.ResumeLayout(false);
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
		
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Load_Parameters___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_External_File_Log___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Input_File;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Input_File_menu_Load_External_Input_File;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Input_File_menu_Unpack_External_Input_File;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Input_File_menuCall__Input_Package_Method;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Input_File_menuComplete_Input__Flow;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Output_File;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Output_File_menuCall__Output_Package_Method;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Output_File_menu_Pack_External_Output_File;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Output_File_menuCreate_External__Output_File;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Output_File_menu_Complete_Output_Flow;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_External_File_Template___;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menuR_emove_Transactions;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Load;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__External;
        protected Fnd.Windows.Forms.FndToolStripMenuItem popupMenu__Input;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Load_1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Unpack;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Call;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Complete;
        protected Fnd.Windows.Forms.FndToolStripMenuItem popupMenu__Output;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Call_1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Pack;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Create;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Complete;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__External_1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Remove;
        public cChildTableFinBase tblExtFileTrans;
        protected cColumn tblExtFileTrans_colnLoadFileId;
        protected cColumn tblExtFileTrans_colnRowNo;
        protected cColumn tblExtFileTrans_colFileLine;
        protected cLookupColumn tblExtFileTrans_colsRowState;
        protected cColumn tblExtFileTrans_colnRecordSetNo;
        protected cColumn tblExtFileTrans_colsRecordTypeId;
        protected cColumn tblExtFileTrans_colErrorText;
        protected cColumn tblExtFileTrans_colsControlId;
        public cChildTableFinBase tblExtFileTransColumn;
        protected cColumn tblExtFileTransColumn_colnRowNo;
        protected cColumn tblExtFileTransColumn_colnLoadFileId;
        protected cColumn tblExtFileTransColumn_colsRecordTypeId;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC0;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC1;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC2;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC3;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC4;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC5;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC6;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC7;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC8;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC9;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC10;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC11;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC12;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC13;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC14;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC15;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC16;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC17;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC18;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC19;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC20;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC21;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC22;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC23;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC24;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC25;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC26;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC27;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC28;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC29;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC30;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC31;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC32;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC33;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC34;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC35;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC36;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC37;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC38;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC39;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC40;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC41;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC42;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC43;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC44;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC45;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC46;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC47;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC48;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC49;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC50;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC51;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC52;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC53;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC54;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC55;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC56;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC57;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC58;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC59;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC60;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC61;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC62;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC63;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC64;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC65;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC66;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC67;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC68;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC69;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC70;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC71;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC72;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC73;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC74;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC75;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC76;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC77;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC78;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC79;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC80;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC81;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC82;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC83;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC84;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC85;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC86;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC87;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC88;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC89;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC90;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC91;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC92;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC93;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC94;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC95;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC96;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC97;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC98;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC99;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC100;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC101;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC102;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC103;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC104;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC105;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC106;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC107;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC108;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC109;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC110;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC111;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC112;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC113;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC114;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC115;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC116;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC117;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC118;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC119;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC120;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC121;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC122;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC123;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC124;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC125;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC126;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC127;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC128;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC129;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC130;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC131;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC132;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC133;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC134;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC135;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC136;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC137;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC138;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC139;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC140;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC141;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC142;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC143;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC144;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC145;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC146;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC147;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC148;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC149;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC150;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC151;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC152;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC153;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC154;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC155;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC156;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC157;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC158;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC159;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC160;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC161;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC162;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC163;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC164;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC165;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC166;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC167;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC168;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC169;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC170;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC171;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC172;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC173;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC174;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC175;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC176;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC177;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC178;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC179;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC180;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC181;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC182;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC183;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC184;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC185;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC186;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC187;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC188;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC189;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC190;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC191;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC192;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC193;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC194;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC195;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC196;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC197;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC198;
        protected cColumnExtFileLoad tblExtFileTransColumn_colsC199;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN0;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN1;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN2;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN3;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN4;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN5;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN6;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN7;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN8;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN9;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN10;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN11;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN12;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN13;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN14;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN15;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN16;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN17;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN18;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN19;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN20;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN21;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN22;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN23;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN24;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN25;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN26;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN27;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN28;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN29;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN30;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN31;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN32;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN33;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN34;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN35;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN36;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN37;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN38;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN39;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN40;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN41;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN42;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN43;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN44;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN45;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN46;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN47;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN48;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN49;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN50;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN51;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN52;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN53;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN54;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN55;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN56;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN57;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN58;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN59;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN60;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN61;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN62;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN63;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN64;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN65;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN66;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN67;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN68;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN69;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN70;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN71;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN72;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN73;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN74;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN75;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN76;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN77;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN78;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN79;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN80;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN81;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN82;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN83;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN84;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN85;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN86;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN87;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN88;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN89;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN90;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN91;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN92;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN93;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN94;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN95;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN96;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN97;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN98;
        protected cColumnExtFileLoad tblExtFileTransColumn_colnN99;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD1;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD2;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD3;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD4;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD5;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD6;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD7;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD8;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD9;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD10;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD11;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD12;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD13;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD14;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD15;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD16;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD17;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD18;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD19;
        protected cColumnExtFileLoad tblExtFileTransColumn_coldD20;
	}
}
