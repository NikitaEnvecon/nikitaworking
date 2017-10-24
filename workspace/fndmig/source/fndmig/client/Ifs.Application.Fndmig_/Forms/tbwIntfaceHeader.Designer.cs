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
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Fndmig_
{
	
	public partial class tbwIntfaceHeader
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsIntfaceName;
		public cColumn colsDescription;
		public cColumn colsGroupId;
		public cColumn colIntfaceGroupDescription;
		public cColumn colsIntfacePath;
		public cColumn colsIntfaceFile;
		public cColumn colsDateFormat;
		public cColumn colnMinusPos;
		public cColumn colWhereClause;
		public cColumn colsViewName;
		public cLookupColumn colsColumnSeparator;
		public cLookupColumn colsThousandSeparator;
		public cLookupColumn colsDecimalPoint;
		public cLookupColumn colsColumnEmbrace;
		public cLookupColumn colsFileLocation;
		public cColumn colsProcedureName;
		public cColumn colIntfaceProceduresDescription;
		public cColumn colIntfaceProceduresDirection;
		public cColumn coldLastExecuted;
		public cColumn colsExecutedBy;
		public cColumn colLastInfo;
		public cColumn colSourceName;
		public cColumn colsSourceOwner;
		public cColumn colNoteText;
		public cColumn colOrderByClause;
		public cColumn colsExportJob;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIntfaceHeader));
            this.menuTbwMethods_menu_Job_Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Start_Job___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuJob__History_Overview___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Print_Documentation___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Export_job___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuS_erver_Processes___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsIntfaceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsGroupId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colIntfaceGroupDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsIntfacePath = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsIntfaceFile = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDateFormat = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnMinusPos = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colWhereClause = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsViewName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsColumnSeparator = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsThousandSeparator = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsDecimalPoint = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsColumnEmbrace = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsFileLocation = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsProcedureName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colIntfaceProceduresDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colIntfaceProceduresDirection = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldLastExecuted = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsExecutedBy = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colLastInfo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colSourceName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSourceOwner = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colNoteText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colOrderByClause = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsExportJob = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Job = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Start = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Job = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Print = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Export = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Server = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Job_Details___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Start_Job___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuJob__History_Overview___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Print_Documentation___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Export_job___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuS_erver_Processes___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menu_Job_Details___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Job_Details___, "menuTbwMethods_menu_Job_Details___");
            this.menuTbwMethods_menu_Job_Details___.Name = "menuTbwMethods_menu_Job_Details___";
            this.menuTbwMethods_menu_Job_Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Job_Execute);
            this.menuTbwMethods_menu_Job_Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Job_Inquire);
            // 
            // menuTbwMethods_menu_Start_Job___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Start_Job___, "menuTbwMethods_menu_Start_Job___");
            this.menuTbwMethods_menu_Start_Job___.Name = "menuTbwMethods_menu_Start_Job___";
            this.menuTbwMethods_menu_Start_Job___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Start_Execute);
            this.menuTbwMethods_menu_Start_Job___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Start_Inquire);
            // 
            // menuTbwMethods_menuJob__History_Overview___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuJob__History_Overview___, "menuTbwMethods_menuJob__History_Overview___");
            this.menuTbwMethods_menuJob__History_Overview___.Name = "menuTbwMethods_menuJob__History_Overview___";
            this.menuTbwMethods_menuJob__History_Overview___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Job_Execute);
            this.menuTbwMethods_menuJob__History_Overview___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Job_Inquire);
            // 
            // menuTbwMethods_menu_Print_Documentation___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Print_Documentation___, "menuTbwMethods_menu_Print_Documentation___");
            this.menuTbwMethods_menu_Print_Documentation___.Name = "menuTbwMethods_menu_Print_Documentation___";
            this.menuTbwMethods_menu_Print_Documentation___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Print_Execute);
            this.menuTbwMethods_menu_Print_Documentation___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Print_Inquire);
            // 
            // menuTbwMethods_menu_Export_job___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Export_job___, "menuTbwMethods_menu_Export_job___");
            this.menuTbwMethods_menu_Export_job___.Name = "menuTbwMethods_menu_Export_job___";
            this.menuTbwMethods_menu_Export_job___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Export_Execute);
            this.menuTbwMethods_menu_Export_job___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Export_Inquire);
            // 
            // menuTbwMethods_menuS_erver_Processes___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuS_erver_Processes___, "menuTbwMethods_menuS_erver_Processes___");
            this.menuTbwMethods_menuS_erver_Processes___.Name = "menuTbwMethods_menuS_erver_Processes___";
            this.menuTbwMethods_menuS_erver_Processes___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Server_Execute);
            this.menuTbwMethods_menuS_erver_Processes___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Server_Inquire);
            // 
            // colsIntfaceName
            // 
            this.colsIntfaceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsIntfaceName.MaxLength = 30;
            this.colsIntfaceName.Name = "colsIntfaceName";
            this.colsIntfaceName.NamedProperties.Put("EnumerateMethod", "");
            this.colsIntfaceName.NamedProperties.Put("FieldFlags", "163");
            this.colsIntfaceName.NamedProperties.Put("LovReference", "");
            this.colsIntfaceName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsIntfaceName.NamedProperties.Put("SqlColumn", "INTFACE_NAME");
            this.colsIntfaceName.Position = 3;
            resources.ApplyResources(this.colsIntfaceName, "colsIntfaceName");
            // 
            // colsDescription
            // 
            this.colsDescription.MaxLength = 50;
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.Position = 4;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsGroupId
            // 
            this.colsGroupId.MaxLength = 20;
            this.colsGroupId.Name = "colsGroupId";
            this.colsGroupId.NamedProperties.Put("EnumerateMethod", "");
            this.colsGroupId.NamedProperties.Put("FieldFlags", "294");
            this.colsGroupId.NamedProperties.Put("LovReference", "INTFACE_GROUP");
            this.colsGroupId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsGroupId.NamedProperties.Put("SqlColumn", "GROUP_ID");
            this.colsGroupId.Position = 5;
            resources.ApplyResources(this.colsGroupId, "colsGroupId");
            // 
            // colIntfaceGroupDescription
            // 
            this.colIntfaceGroupDescription.MaxLength = 2000;
            this.colIntfaceGroupDescription.Name = "colIntfaceGroupDescription";
            this.colIntfaceGroupDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colIntfaceGroupDescription.NamedProperties.Put("FieldFlags", "304");
            this.colIntfaceGroupDescription.NamedProperties.Put("LovReference", "");
            this.colIntfaceGroupDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colIntfaceGroupDescription.NamedProperties.Put("SqlColumn", "&AO.INTFACE_GROUP_API.Get_Description(GROUP_ID)");
            this.colIntfaceGroupDescription.NamedProperties.Put("ValidateMethod", "");
            this.colIntfaceGroupDescription.Position = 6;
            resources.ApplyResources(this.colIntfaceGroupDescription, "colIntfaceGroupDescription");
            // 
            // colsIntfacePath
            // 
            this.colsIntfacePath.Name = "colsIntfacePath";
            this.colsIntfacePath.NamedProperties.Put("EnumerateMethod", "");
            this.colsIntfacePath.NamedProperties.Put("FieldFlags", "290");
            this.colsIntfacePath.NamedProperties.Put("LovReference", "");
            this.colsIntfacePath.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsIntfacePath.NamedProperties.Put("ResizeableChildObject", "");
            this.colsIntfacePath.NamedProperties.Put("SqlColumn", "INTFACE_PATH");
            this.colsIntfacePath.NamedProperties.Put("ValidateMethod", "");
            this.colsIntfacePath.Position = 7;
            resources.ApplyResources(this.colsIntfacePath, "colsIntfacePath");
            // 
            // colsIntfaceFile
            // 
            this.colsIntfaceFile.MaxLength = 50;
            this.colsIntfaceFile.Name = "colsIntfaceFile";
            this.colsIntfaceFile.NamedProperties.Put("EnumerateMethod", "");
            this.colsIntfaceFile.NamedProperties.Put("FieldFlags", "290");
            this.colsIntfaceFile.NamedProperties.Put("LovReference", "");
            this.colsIntfaceFile.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsIntfaceFile.NamedProperties.Put("ResizeableChildObject", "");
            this.colsIntfaceFile.NamedProperties.Put("SqlColumn", "INTFACE_FILE");
            this.colsIntfaceFile.NamedProperties.Put("ValidateMethod", "");
            this.colsIntfaceFile.Position = 8;
            resources.ApplyResources(this.colsIntfaceFile, "colsIntfaceFile");
            // 
            // colsDateFormat
            // 
            this.colsDateFormat.MaxLength = 30;
            this.colsDateFormat.Name = "colsDateFormat";
            this.colsDateFormat.NamedProperties.Put("EnumerateMethod", "");
            this.colsDateFormat.NamedProperties.Put("FieldFlags", "290");
            this.colsDateFormat.NamedProperties.Put("LovReference", "");
            this.colsDateFormat.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDateFormat.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDateFormat.NamedProperties.Put("SqlColumn", "DATE_FORMAT");
            this.colsDateFormat.NamedProperties.Put("ValidateMethod", "");
            this.colsDateFormat.Position = 9;
            resources.ApplyResources(this.colsDateFormat, "colsDateFormat");
            // 
            // colnMinusPos
            // 
            this.colnMinusPos.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnMinusPos.Name = "colnMinusPos";
            this.colnMinusPos.NamedProperties.Put("EnumerateMethod", "");
            this.colnMinusPos.NamedProperties.Put("FieldFlags", "290");
            this.colnMinusPos.NamedProperties.Put("LovReference", "");
            this.colnMinusPos.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnMinusPos.NamedProperties.Put("ResizeableChildObject", "");
            this.colnMinusPos.NamedProperties.Put("SqlColumn", "MINUS_POS");
            this.colnMinusPos.NamedProperties.Put("ValidateMethod", "");
            this.colnMinusPos.Position = 10;
            resources.ApplyResources(this.colnMinusPos, "colnMinusPos");
            // 
            // colWhereClause
            // 
            this.colWhereClause.MaxLength = 2000;
            this.colWhereClause.Name = "colWhereClause";
            this.colWhereClause.NamedProperties.Put("EnumerateMethod", "");
            this.colWhereClause.NamedProperties.Put("FieldFlags", "306");
            this.colWhereClause.NamedProperties.Put("LovReference", "");
            this.colWhereClause.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colWhereClause.NamedProperties.Put("ResizeableChildObject", "");
            this.colWhereClause.NamedProperties.Put("SqlColumn", "WHERE_CLAUSE");
            this.colWhereClause.NamedProperties.Put("ValidateMethod", "");
            this.colWhereClause.Position = 11;
            resources.ApplyResources(this.colWhereClause, "colWhereClause");
            // 
            // colsViewName
            // 
            this.colsViewName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsViewName.Name = "colsViewName";
            this.colsViewName.NamedProperties.Put("EnumerateMethod", "");
            this.colsViewName.NamedProperties.Put("FieldFlags", "294");
            this.colsViewName.NamedProperties.Put("LovReference", "INTFACE_VIEWS");
            this.colsViewName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsViewName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsViewName.NamedProperties.Put("SqlColumn", "VIEW_NAME");
            this.colsViewName.NamedProperties.Put("ValidateMethod", "");
            this.colsViewName.Position = 12;
            resources.ApplyResources(this.colsViewName, "colsViewName");
            // 
            // colsColumnSeparator
            // 
            this.colsColumnSeparator.MaxLength = 200;
            this.colsColumnSeparator.Name = "colsColumnSeparator";
            this.colsColumnSeparator.NamedProperties.Put("EnumerateMethod", "INTFACE_FORMAT_CHAR_API.Enumerate");
            this.colsColumnSeparator.NamedProperties.Put("FieldFlags", "290");
            this.colsColumnSeparator.NamedProperties.Put("LovReference", "");
            this.colsColumnSeparator.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsColumnSeparator.NamedProperties.Put("ResizeableChildObject", "");
            this.colsColumnSeparator.NamedProperties.Put("SqlColumn", "COLUMN_SEPARATOR");
            this.colsColumnSeparator.NamedProperties.Put("ValidateMethod", "");
            this.colsColumnSeparator.Position = 13;
            resources.ApplyResources(this.colsColumnSeparator, "colsColumnSeparator");
            // 
            // colsThousandSeparator
            // 
            this.colsThousandSeparator.MaxLength = 200;
            this.colsThousandSeparator.Name = "colsThousandSeparator";
            this.colsThousandSeparator.NamedProperties.Put("EnumerateMethod", "INTFACE_FORMAT_CHAR_API.Enumerate");
            this.colsThousandSeparator.NamedProperties.Put("FieldFlags", "290");
            this.colsThousandSeparator.NamedProperties.Put("LovReference", "");
            this.colsThousandSeparator.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsThousandSeparator.NamedProperties.Put("ResizeableChildObject", "");
            this.colsThousandSeparator.NamedProperties.Put("SqlColumn", "THOUSAND_SEPARATOR");
            this.colsThousandSeparator.NamedProperties.Put("ValidateMethod", "");
            this.colsThousandSeparator.Position = 14;
            resources.ApplyResources(this.colsThousandSeparator, "colsThousandSeparator");
            // 
            // colsDecimalPoint
            // 
            this.colsDecimalPoint.MaxLength = 200;
            this.colsDecimalPoint.Name = "colsDecimalPoint";
            this.colsDecimalPoint.NamedProperties.Put("EnumerateMethod", "INTFACE_FORMAT_CHAR_API.Enumerate");
            this.colsDecimalPoint.NamedProperties.Put("FieldFlags", "290");
            this.colsDecimalPoint.NamedProperties.Put("LovReference", "");
            this.colsDecimalPoint.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDecimalPoint.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDecimalPoint.NamedProperties.Put("SqlColumn", "DECIMAL_POINT");
            this.colsDecimalPoint.NamedProperties.Put("ValidateMethod", "");
            this.colsDecimalPoint.Position = 15;
            resources.ApplyResources(this.colsDecimalPoint, "colsDecimalPoint");
            // 
            // colsColumnEmbrace
            // 
            this.colsColumnEmbrace.MaxLength = 200;
            this.colsColumnEmbrace.Name = "colsColumnEmbrace";
            this.colsColumnEmbrace.NamedProperties.Put("EnumerateMethod", "INTFACE_FORMAT_CHAR_API.Enumerate");
            this.colsColumnEmbrace.NamedProperties.Put("FieldFlags", "290");
            this.colsColumnEmbrace.NamedProperties.Put("LovReference", "");
            this.colsColumnEmbrace.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsColumnEmbrace.NamedProperties.Put("ResizeableChildObject", "");
            this.colsColumnEmbrace.NamedProperties.Put("SqlColumn", "COLUMN_EMBRACE");
            this.colsColumnEmbrace.NamedProperties.Put("ValidateMethod", "");
            this.colsColumnEmbrace.Position = 16;
            resources.ApplyResources(this.colsColumnEmbrace, "colsColumnEmbrace");
            // 
            // colsFileLocation
            // 
            this.colsFileLocation.MaxLength = 200;
            this.colsFileLocation.Name = "colsFileLocation";
            this.colsFileLocation.NamedProperties.Put("EnumerateMethod", "INTFACE_FILE_LOCATION_API.Enumerate");
            this.colsFileLocation.NamedProperties.Put("FieldFlags", "291");
            this.colsFileLocation.NamedProperties.Put("LovReference", "");
            this.colsFileLocation.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsFileLocation.NamedProperties.Put("ResizeableChildObject", "");
            this.colsFileLocation.NamedProperties.Put("SqlColumn", "FILE_LOCATION");
            this.colsFileLocation.NamedProperties.Put("ValidateMethod", "");
            this.colsFileLocation.Position = 17;
            resources.ApplyResources(this.colsFileLocation, "colsFileLocation");
            // 
            // colsProcedureName
            // 
            this.colsProcedureName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsProcedureName.Name = "colsProcedureName";
            this.colsProcedureName.NamedProperties.Put("EnumerateMethod", "");
            this.colsProcedureName.NamedProperties.Put("FieldFlags", "294");
            this.colsProcedureName.NamedProperties.Put("LovReference", "INTFACE_PROCEDURES");
            this.colsProcedureName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsProcedureName.NamedProperties.Put("SqlColumn", "PROCEDURE_NAME");
            this.colsProcedureName.Position = 18;
            resources.ApplyResources(this.colsProcedureName, "colsProcedureName");
            // 
            // colIntfaceProceduresDescription
            // 
            this.colIntfaceProceduresDescription.MaxLength = 2000;
            this.colIntfaceProceduresDescription.Name = "colIntfaceProceduresDescription";
            this.colIntfaceProceduresDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colIntfaceProceduresDescription.NamedProperties.Put("FieldFlags", "304");
            this.colIntfaceProceduresDescription.NamedProperties.Put("LovReference", "");
            this.colIntfaceProceduresDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colIntfaceProceduresDescription.NamedProperties.Put("SqlColumn", "&AO.INTFACE_PROCEDURES_API.Get_Description(PROCEDURE_NAME)");
            this.colIntfaceProceduresDescription.NamedProperties.Put("ValidateMethod", "");
            this.colIntfaceProceduresDescription.Position = 19;
            resources.ApplyResources(this.colIntfaceProceduresDescription, "colIntfaceProceduresDescription");
            // 
            // colIntfaceProceduresDirection
            // 
            this.colIntfaceProceduresDirection.MaxLength = 2000;
            this.colIntfaceProceduresDirection.Name = "colIntfaceProceduresDirection";
            this.colIntfaceProceduresDirection.NamedProperties.Put("EnumerateMethod", "");
            this.colIntfaceProceduresDirection.NamedProperties.Put("FieldFlags", "304");
            this.colIntfaceProceduresDirection.NamedProperties.Put("LovReference", "");
            this.colIntfaceProceduresDirection.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colIntfaceProceduresDirection.NamedProperties.Put("SqlColumn", "&AO.INTFACE_PROCEDURES_API.Get_Direction(PROCEDURE_NAME)");
            this.colIntfaceProceduresDirection.NamedProperties.Put("ValidateMethod", "");
            this.colIntfaceProceduresDirection.Position = 20;
            resources.ApplyResources(this.colIntfaceProceduresDirection, "colIntfaceProceduresDirection");
            // 
            // coldLastExecuted
            // 
            this.coldLastExecuted.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldLastExecuted.Format = "G";
            this.coldLastExecuted.Name = "coldLastExecuted";
            this.coldLastExecuted.NamedProperties.Put("EnumerateMethod", "");
            this.coldLastExecuted.NamedProperties.Put("FieldFlags", "290");
            this.coldLastExecuted.NamedProperties.Put("LovReference", "");
            this.coldLastExecuted.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldLastExecuted.NamedProperties.Put("SqlColumn", "LAST_EXECUTED");
            this.coldLastExecuted.Position = 21;
            resources.ApplyResources(this.coldLastExecuted, "coldLastExecuted");
            // 
            // colsExecutedBy
            // 
            this.colsExecutedBy.MaxLength = 30;
            this.colsExecutedBy.Name = "colsExecutedBy";
            this.colsExecutedBy.NamedProperties.Put("EnumerateMethod", "");
            this.colsExecutedBy.NamedProperties.Put("FieldFlags", "290");
            this.colsExecutedBy.NamedProperties.Put("LovReference", "");
            this.colsExecutedBy.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsExecutedBy.NamedProperties.Put("SqlColumn", "EXECUTED_BY");
            this.colsExecutedBy.Position = 22;
            resources.ApplyResources(this.colsExecutedBy, "colsExecutedBy");
            // 
            // colLastInfo
            // 
            this.colLastInfo.MaxLength = 4000;
            this.colLastInfo.Name = "colLastInfo";
            this.colLastInfo.NamedProperties.Put("EnumerateMethod", "");
            this.colLastInfo.NamedProperties.Put("FieldFlags", "310");
            this.colLastInfo.NamedProperties.Put("LovReference", "");
            this.colLastInfo.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colLastInfo.NamedProperties.Put("SqlColumn", "LAST_INFO");
            this.colLastInfo.Position = 23;
            resources.ApplyResources(this.colLastInfo, "colLastInfo");
            // 
            // colSourceName
            // 
            this.colSourceName.MaxLength = 2000;
            this.colSourceName.Name = "colSourceName";
            this.colSourceName.NamedProperties.Put("EnumerateMethod", "");
            this.colSourceName.NamedProperties.Put("FieldFlags", "306");
            this.colSourceName.NamedProperties.Put("LovReference", "INTFACE_SOURCE_COL_LOV(INTFACE_HEADER_API.Get_Source_Name(INTFACE_NAME), INTFACE_" +
                    "HEADER_API.Get_Source_Owner(INTFACE_NAME)))");
            this.colSourceName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colSourceName.NamedProperties.Put("ResizeableChildObject", "");
            this.colSourceName.NamedProperties.Put("SqlColumn", "SOURCE_NAME");
            this.colSourceName.NamedProperties.Put("ValidateMethod", "");
            this.colSourceName.Position = 24;
            resources.ApplyResources(this.colSourceName, "colSourceName");
            // 
            // colsSourceOwner
            // 
            this.colsSourceOwner.MaxLength = 50;
            this.colsSourceOwner.Name = "colsSourceOwner";
            this.colsSourceOwner.NamedProperties.Put("EnumerateMethod", "");
            this.colsSourceOwner.NamedProperties.Put("FieldFlags", "290");
            this.colsSourceOwner.NamedProperties.Put("LovReference", "");
            this.colsSourceOwner.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsSourceOwner.NamedProperties.Put("ResizeableChildObject", "");
            this.colsSourceOwner.NamedProperties.Put("SqlColumn", "SOURCE_OWNER");
            this.colsSourceOwner.NamedProperties.Put("ValidateMethod", "");
            this.colsSourceOwner.Position = 25;
            resources.ApplyResources(this.colsSourceOwner, "colsSourceOwner");
            // 
            // colNoteText
            // 
            this.colNoteText.MaxLength = 2000;
            this.colNoteText.Name = "colNoteText";
            this.colNoteText.NamedProperties.Put("EnumerateMethod", "");
            this.colNoteText.NamedProperties.Put("FieldFlags", "310");
            this.colNoteText.NamedProperties.Put("LovReference", "");
            this.colNoteText.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colNoteText.NamedProperties.Put("SqlColumn", "NOTE_TEXT");
            this.colNoteText.Position = 26;
            resources.ApplyResources(this.colNoteText, "colNoteText");
            // 
            // colOrderByClause
            // 
            this.colOrderByClause.MaxLength = 2000;
            this.colOrderByClause.Name = "colOrderByClause";
            this.colOrderByClause.NamedProperties.Put("EnumerateMethod", "");
            this.colOrderByClause.NamedProperties.Put("FieldFlags", "306");
            this.colOrderByClause.NamedProperties.Put("LovReference", "");
            this.colOrderByClause.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colOrderByClause.NamedProperties.Put("ResizeableChildObject", "");
            this.colOrderByClause.NamedProperties.Put("SqlColumn", "ORDER_BY_CLAUSE");
            this.colOrderByClause.NamedProperties.Put("ValidateMethod", "");
            this.colOrderByClause.Position = 27;
            resources.ApplyResources(this.colOrderByClause, "colOrderByClause");
            // 
            // colsExportJob
            // 
            resources.ApplyResources(this.colsExportJob, "colsExportJob");
            this.colsExportJob.Name = "colsExportJob";
            this.colsExportJob.NamedProperties.Put("FieldFlags", "256");
            this.colsExportJob.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsExportJob.Position = 28;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Job,
            this.menuItem__Start,
            this.menuItem_Job,
            this.menuItem__Print,
            this.menuItem__Export,
            this.menuItem_Server});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Job
            // 
            this.menuItem__Job.Command = this.menuTbwMethods_menu_Job_Details___;
            this.menuItem__Job.Name = "menuItem__Job";
            resources.ApplyResources(this.menuItem__Job, "menuItem__Job");
            this.menuItem__Job.Text = "&Job Details...";
            // 
            // menuItem__Start
            // 
            this.menuItem__Start.Command = this.menuTbwMethods_menu_Start_Job___;
            this.menuItem__Start.Name = "menuItem__Start";
            resources.ApplyResources(this.menuItem__Start, "menuItem__Start");
            this.menuItem__Start.Text = "&Start Job...";
            // 
            // menuItem_Job
            // 
            this.menuItem_Job.Command = this.menuTbwMethods_menuJob__History_Overview___;
            this.menuItem_Job.Name = "menuItem_Job";
            resources.ApplyResources(this.menuItem_Job, "menuItem_Job");
            this.menuItem_Job.Text = "Job &History Overview...";
            // 
            // menuItem__Print
            // 
            this.menuItem__Print.Command = this.menuTbwMethods_menu_Print_Documentation___;
            this.menuItem__Print.Name = "menuItem__Print";
            resources.ApplyResources(this.menuItem__Print, "menuItem__Print");
            this.menuItem__Print.Text = "&Print Documentation...";
            // 
            // menuItem__Export
            // 
            this.menuItem__Export.Command = this.menuTbwMethods_menu_Export_job___;
            this.menuItem__Export.Name = "menuItem__Export";
            resources.ApplyResources(this.menuItem__Export, "menuItem__Export");
            this.menuItem__Export.Text = "&Export job...";
            // 
            // menuItem_Server
            // 
            this.menuItem_Server.Command = this.menuTbwMethods_menuS_erver_Processes___;
            this.menuItem_Server.Name = "menuItem_Server";
            resources.ApplyResources(this.menuItem_Server, "menuItem_Server");
            this.menuItem_Server.Text = "S&cheduled Migration Jobs...";
            // 
            // tbwIntfaceHeader
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsIntfaceName);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsGroupId);
            this.Controls.Add(this.colIntfaceGroupDescription);
            this.Controls.Add(this.colsIntfacePath);
            this.Controls.Add(this.colsIntfaceFile);
            this.Controls.Add(this.colsDateFormat);
            this.Controls.Add(this.colnMinusPos);
            this.Controls.Add(this.colWhereClause);
            this.Controls.Add(this.colsViewName);
            this.Controls.Add(this.colsColumnSeparator);
            this.Controls.Add(this.colsThousandSeparator);
            this.Controls.Add(this.colsDecimalPoint);
            this.Controls.Add(this.colsColumnEmbrace);
            this.Controls.Add(this.colsFileLocation);
            this.Controls.Add(this.colsProcedureName);
            this.Controls.Add(this.colIntfaceProceduresDescription);
            this.Controls.Add(this.colIntfaceProceduresDirection);
            this.Controls.Add(this.coldLastExecuted);
            this.Controls.Add(this.colsExecutedBy);
            this.Controls.Add(this.colLastInfo);
            this.Controls.Add(this.colSourceName);
            this.Controls.Add(this.colsSourceOwner);
            this.Controls.Add(this.colNoteText);
            this.Controls.Add(this.colOrderByClause);
            this.Controls.Add(this.colsExportJob);
            this.Name = "tbwIntfaceHeader";
            this.NamedProperties.Put("DefaultOrderBy", "INTFACE_NAME");
            this.NamedProperties.Put("DefaultWhere", @"&AO.Intface_User_API.Get_Privilege(&AO.Fnd_Session_API.Get_FND_User) = &AO.Intface_Privilege_API.Get_Client_Value(1) AND nvl(&AO.Intface_Group_API.Get_Hide_Flag(GROUP_ID),'FALSE') = 'FALSE'  AND INTFACE_NAME IN (SELECT INTFACE_NAME FROM &AO.INTFACE_ALLOWED_JOBS)");
            this.NamedProperties.Put("LogicalUnit", "IntfaceHeader");
            this.NamedProperties.Put("PackageName", "INTFACE_HEADER_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "129");
            this.NamedProperties.Put("ViewName", "INTFACE_HEADER");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.Controls.SetChildIndex(this.colsExportJob, 0);
            this.Controls.SetChildIndex(this.colOrderByClause, 0);
            this.Controls.SetChildIndex(this.colNoteText, 0);
            this.Controls.SetChildIndex(this.colsSourceOwner, 0);
            this.Controls.SetChildIndex(this.colSourceName, 0);
            this.Controls.SetChildIndex(this.colLastInfo, 0);
            this.Controls.SetChildIndex(this.colsExecutedBy, 0);
            this.Controls.SetChildIndex(this.coldLastExecuted, 0);
            this.Controls.SetChildIndex(this.colIntfaceProceduresDirection, 0);
            this.Controls.SetChildIndex(this.colIntfaceProceduresDescription, 0);
            this.Controls.SetChildIndex(this.colsProcedureName, 0);
            this.Controls.SetChildIndex(this.colsFileLocation, 0);
            this.Controls.SetChildIndex(this.colsColumnEmbrace, 0);
            this.Controls.SetChildIndex(this.colsDecimalPoint, 0);
            this.Controls.SetChildIndex(this.colsThousandSeparator, 0);
            this.Controls.SetChildIndex(this.colsColumnSeparator, 0);
            this.Controls.SetChildIndex(this.colsViewName, 0);
            this.Controls.SetChildIndex(this.colWhereClause, 0);
            this.Controls.SetChildIndex(this.colnMinusPos, 0);
            this.Controls.SetChildIndex(this.colsDateFormat, 0);
            this.Controls.SetChildIndex(this.colsIntfaceFile, 0);
            this.Controls.SetChildIndex(this.colsIntfacePath, 0);
            this.Controls.SetChildIndex(this.colIntfaceGroupDescription, 0);
            this.Controls.SetChildIndex(this.colsGroupId, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsIntfaceName, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.menuTbwMethods.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Job_Details___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Start_Job___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuJob__History_Overview___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Print_Documentation___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Export_job___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuS_erver_Processes___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Job;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Start;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Job;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Print;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Export;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Server;
	}
}
