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

namespace Ifs.Application.Accrul_
{

    public partial class frmRpdYear
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpdYear));
            this.cChildTableDetail = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.menuTblMenu = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuTblMenu_MenuItem_AccPerConnections = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmd_menuTblMenu_MenuItem_AccPerConnections = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cChildTableDetail_colsRpdId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colnRpdYear = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colnRpdPeriod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_coldFromDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_coldUntilDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colnYearPeriodNum = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsYearPeriodStr = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsStringAttribute1 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsStringAttribute2 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsStringAttribute3 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsStringAttribute4 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsStringAttribute5 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colnNumberAttribute1 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colnNumberAttribute2 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colnNumberAttribute3 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colnNumberAttribute4 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colnNumberAttribute5 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.labelRpdId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelRpdYear = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbRpdId = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.dfnRpdYear = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMenu = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuFrmMenu_MenuItem_AccPerConnections = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmd_menuFrmMenu_MenuItem_AccPerConnections = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cChildTableDetail.SuspendLayout();
            this.menuTblMenu.SuspendLayout();
            this.menuFrmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.cmd_menuFrmMenu_MenuItem_AccPerConnections);
            this.commandManager.Commands.Add(this.cmd_menuTblMenu_MenuItem_AccPerConnections);
            this.commandManager.ContextMenus.Add(this.menuFrmMenu);
            this.commandManager.ContextMenus.Add(this.menuTblMenu);
            // 
            // cChildTableDetail
            // 
            this.cChildTableDetail.ContextMenuStrip = this.menuTblMenu;
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsRpdId);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colnRpdYear);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colnRpdPeriod);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_coldFromDate);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_coldUntilDate);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colnYearPeriodNum);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsYearPeriodStr);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsStringAttribute1);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsStringAttribute2);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsStringAttribute3);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsStringAttribute4);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsStringAttribute5);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colnNumberAttribute1);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colnNumberAttribute2);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colnNumberAttribute3);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colnNumberAttribute4);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colnNumberAttribute5);
            resources.ApplyResources(this.cChildTableDetail, "cChildTableDetail");
            this.cChildTableDetail.Name = "cChildTableDetail";
            this.cChildTableDetail.NamedProperties.Put("DefaultWhere", "RPD_ID = :i_hWndFrame.frmRpdYear.cmbRpdId.i_sMyValue\nAND RPD_YEAR = :i_hWndFrame." +
                    "frmRpdYear.dfnRpdYear");
            this.cChildTableDetail.NamedProperties.Put("LogicalUnit", "RpdPeriod");
            this.cChildTableDetail.NamedProperties.Put("Module", "ACCRUL");
            this.cChildTableDetail.NamedProperties.Put("PackageName", "RPD_PERIOD_API");
            this.cChildTableDetail.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.cChildTableDetail.NamedProperties.Put("ViewName", "RPD_PERIOD");
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colnNumberAttribute5, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colnNumberAttribute4, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colnNumberAttribute3, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colnNumberAttribute2, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colnNumberAttribute1, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsStringAttribute5, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsStringAttribute4, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsStringAttribute3, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsStringAttribute2, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsStringAttribute1, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsYearPeriodStr, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colnYearPeriodNum, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_coldUntilDate, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_coldFromDate, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colnRpdPeriod, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colnRpdYear, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsRpdId, 0);
            // 
            // menuTblMenu
            // 
            this.menuTblMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTblMenu_MenuItem_AccPerConnections});
            this.menuTblMenu.Name = "menuTblMenu";
            resources.ApplyResources(this.menuTblMenu, "menuTblMenu");
            // 
            // menuTblMenu_MenuItem_AccPerConnections
            // 
            this.menuTblMenu_MenuItem_AccPerConnections.Command = this.cmd_menuTblMenu_MenuItem_AccPerConnections;
            resources.ApplyResources(this.menuTblMenu_MenuItem_AccPerConnections, "menuTblMenu_MenuItem_AccPerConnections");
            this.menuTblMenu_MenuItem_AccPerConnections.Name = "menuTblMenu_MenuItem_AccPerConnections";
            this.menuTblMenu_MenuItem_AccPerConnections.Text = "Accounting Period Connection...";
            // 
            // cmd_menuTblMenu_MenuItem_AccPerConnections
            // 
            resources.ApplyResources(this.cmd_menuTblMenu_MenuItem_AccPerConnections, "cmd_menuTblMenu_MenuItem_AccPerConnections");
            this.cmd_menuTblMenu_MenuItem_AccPerConnections.Name = "cmd_menuTblMenu_MenuItem_AccPerConnections";
            this.cmd_menuTblMenu_MenuItem_AccPerConnections.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmd_menuTblMenu_MenuItem_AccPerConnections_Execute);
            this.cmd_menuTblMenu_MenuItem_AccPerConnections.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmd_menuTblMenu_MenuItem_AccPerConnections_Inquire);
            // 
            // cChildTableDetail_colsRpdId
            // 
            this.cChildTableDetail_colsRpdId.Name = "cChildTableDetail_colsRpdId";
            this.cChildTableDetail_colsRpdId.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsRpdId.NamedProperties.Put("FieldFlags", "99");
            this.cChildTableDetail_colsRpdId.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsRpdId.NamedProperties.Put("SqlColumn", "RPD_ID");
            this.cChildTableDetail_colsRpdId.Position = 3;
            resources.ApplyResources(this.cChildTableDetail_colsRpdId, "cChildTableDetail_colsRpdId");
            // 
            // cChildTableDetail_colnRpdYear
            // 
            this.cChildTableDetail_colnRpdYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cChildTableDetail_colnRpdYear.Name = "cChildTableDetail_colnRpdYear";
            this.cChildTableDetail_colnRpdYear.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colnRpdYear.NamedProperties.Put("FieldFlags", "99");
            this.cChildTableDetail_colnRpdYear.NamedProperties.Put("Format", "");
            this.cChildTableDetail_colnRpdYear.NamedProperties.Put("LovReference", "RPD_YEAR(RPD_ID)");
            this.cChildTableDetail_colnRpdYear.NamedProperties.Put("SqlColumn", "RPD_YEAR");
            this.cChildTableDetail_colnRpdYear.Position = 4;
            resources.ApplyResources(this.cChildTableDetail_colnRpdYear, "cChildTableDetail_colnRpdYear");
            // 
            // cChildTableDetail_colnRpdPeriod
            // 
            this.cChildTableDetail_colnRpdPeriod.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cChildTableDetail_colnRpdPeriod.Name = "cChildTableDetail_colnRpdPeriod";
            this.cChildTableDetail_colnRpdPeriod.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colnRpdPeriod.NamedProperties.Put("FieldFlags", "163");
            this.cChildTableDetail_colnRpdPeriod.NamedProperties.Put("Format", "");
            this.cChildTableDetail_colnRpdPeriod.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colnRpdPeriod.NamedProperties.Put("SqlColumn", "RPD_PERIOD");
            this.cChildTableDetail_colnRpdPeriod.Position = 5;
            resources.ApplyResources(this.cChildTableDetail_colnRpdPeriod, "cChildTableDetail_colnRpdPeriod");
            // 
            // cChildTableDetail_coldFromDate
            // 
            this.cChildTableDetail_coldFromDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.cChildTableDetail_coldFromDate.Format = "d";
            this.cChildTableDetail_coldFromDate.Name = "cChildTableDetail_coldFromDate";
            this.cChildTableDetail_coldFromDate.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_coldFromDate.NamedProperties.Put("FieldFlags", "291");
            this.cChildTableDetail_coldFromDate.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_coldFromDate.NamedProperties.Put("SqlColumn", "FROM_DATE");
            this.cChildTableDetail_coldFromDate.Position = 6;
            resources.ApplyResources(this.cChildTableDetail_coldFromDate, "cChildTableDetail_coldFromDate");
            // 
            // cChildTableDetail_coldUntilDate
            // 
            this.cChildTableDetail_coldUntilDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.cChildTableDetail_coldUntilDate.Format = "d";
            this.cChildTableDetail_coldUntilDate.Name = "cChildTableDetail_coldUntilDate";
            this.cChildTableDetail_coldUntilDate.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_coldUntilDate.NamedProperties.Put("FieldFlags", "291");
            this.cChildTableDetail_coldUntilDate.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_coldUntilDate.NamedProperties.Put("SqlColumn", "UNTIL_DATE");
            this.cChildTableDetail_coldUntilDate.Position = 7;
            resources.ApplyResources(this.cChildTableDetail_coldUntilDate, "cChildTableDetail_coldUntilDate");
            // 
            // cChildTableDetail_colnYearPeriodNum
            // 
            this.cChildTableDetail_colnYearPeriodNum.Name = "cChildTableDetail_colnYearPeriodNum";
            this.cChildTableDetail_colnYearPeriodNum.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colnYearPeriodNum.NamedProperties.Put("FieldFlags", "288");
            this.cChildTableDetail_colnYearPeriodNum.NamedProperties.Put("Format", "");
            this.cChildTableDetail_colnYearPeriodNum.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colnYearPeriodNum.NamedProperties.Put("SqlColumn", "YEAR_PERIOD_NUM");
            this.cChildTableDetail_colnYearPeriodNum.Position = 8;
            resources.ApplyResources(this.cChildTableDetail_colnYearPeriodNum, "cChildTableDetail_colnYearPeriodNum");
            // 
            // cChildTableDetail_colsYearPeriodStr
            // 
            this.cChildTableDetail_colsYearPeriodStr.Name = "cChildTableDetail_colsYearPeriodStr";
            this.cChildTableDetail_colsYearPeriodStr.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsYearPeriodStr.NamedProperties.Put("FieldFlags", "288");
            this.cChildTableDetail_colsYearPeriodStr.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsYearPeriodStr.NamedProperties.Put("SqlColumn", "YEAR_PERIOD_STR");
            this.cChildTableDetail_colsYearPeriodStr.Position = 9;
            resources.ApplyResources(this.cChildTableDetail_colsYearPeriodStr, "cChildTableDetail_colsYearPeriodStr");
            // 
            // cChildTableDetail_colsStringAttribute1
            // 
            this.cChildTableDetail_colsStringAttribute1.Name = "cChildTableDetail_colsStringAttribute1";
            this.cChildTableDetail_colsStringAttribute1.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsStringAttribute1.NamedProperties.Put("FieldFlags", "294");
            this.cChildTableDetail_colsStringAttribute1.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsStringAttribute1.NamedProperties.Put("SqlColumn", "STRING_ATTRIBUTE1");
            this.cChildTableDetail_colsStringAttribute1.Position = 10;
            resources.ApplyResources(this.cChildTableDetail_colsStringAttribute1, "cChildTableDetail_colsStringAttribute1");
            // 
            // cChildTableDetail_colsStringAttribute2
            // 
            this.cChildTableDetail_colsStringAttribute2.Name = "cChildTableDetail_colsStringAttribute2";
            this.cChildTableDetail_colsStringAttribute2.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsStringAttribute2.NamedProperties.Put("FieldFlags", "294");
            this.cChildTableDetail_colsStringAttribute2.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsStringAttribute2.NamedProperties.Put("SqlColumn", "STRING_ATTRIBUTE2");
            this.cChildTableDetail_colsStringAttribute2.Position = 11;
            resources.ApplyResources(this.cChildTableDetail_colsStringAttribute2, "cChildTableDetail_colsStringAttribute2");
            // 
            // cChildTableDetail_colsStringAttribute3
            // 
            this.cChildTableDetail_colsStringAttribute3.Name = "cChildTableDetail_colsStringAttribute3";
            this.cChildTableDetail_colsStringAttribute3.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsStringAttribute3.NamedProperties.Put("FieldFlags", "294");
            this.cChildTableDetail_colsStringAttribute3.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsStringAttribute3.NamedProperties.Put("SqlColumn", "STRING_ATTRIBUTE3");
            this.cChildTableDetail_colsStringAttribute3.Position = 12;
            resources.ApplyResources(this.cChildTableDetail_colsStringAttribute3, "cChildTableDetail_colsStringAttribute3");
            // 
            // cChildTableDetail_colsStringAttribute4
            // 
            this.cChildTableDetail_colsStringAttribute4.Name = "cChildTableDetail_colsStringAttribute4";
            this.cChildTableDetail_colsStringAttribute4.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsStringAttribute4.NamedProperties.Put("FieldFlags", "294");
            this.cChildTableDetail_colsStringAttribute4.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsStringAttribute4.NamedProperties.Put("SqlColumn", "STRING_ATTRIBUTE4");
            this.cChildTableDetail_colsStringAttribute4.Position = 13;
            resources.ApplyResources(this.cChildTableDetail_colsStringAttribute4, "cChildTableDetail_colsStringAttribute4");
            // 
            // cChildTableDetail_colsStringAttribute5
            // 
            this.cChildTableDetail_colsStringAttribute5.Name = "cChildTableDetail_colsStringAttribute5";
            this.cChildTableDetail_colsStringAttribute5.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsStringAttribute5.NamedProperties.Put("FieldFlags", "294");
            this.cChildTableDetail_colsStringAttribute5.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsStringAttribute5.NamedProperties.Put("SqlColumn", "STRING_ATTRIBUTE5");
            this.cChildTableDetail_colsStringAttribute5.Position = 14;
            resources.ApplyResources(this.cChildTableDetail_colsStringAttribute5, "cChildTableDetail_colsStringAttribute5");
            // 
            // cChildTableDetail_colnNumberAttribute1
            // 
            this.cChildTableDetail_colnNumberAttribute1.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cChildTableDetail_colnNumberAttribute1.Name = "cChildTableDetail_colnNumberAttribute1";
            this.cChildTableDetail_colnNumberAttribute1.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colnNumberAttribute1.NamedProperties.Put("FieldFlags", "294");
            this.cChildTableDetail_colnNumberAttribute1.NamedProperties.Put("Format", "");
            this.cChildTableDetail_colnNumberAttribute1.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colnNumberAttribute1.NamedProperties.Put("SqlColumn", "NUMBER_ATTRIBUTE1");
            this.cChildTableDetail_colnNumberAttribute1.Position = 15;
            resources.ApplyResources(this.cChildTableDetail_colnNumberAttribute1, "cChildTableDetail_colnNumberAttribute1");
            // 
            // cChildTableDetail_colnNumberAttribute2
            // 
            this.cChildTableDetail_colnNumberAttribute2.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cChildTableDetail_colnNumberAttribute2.Name = "cChildTableDetail_colnNumberAttribute2";
            this.cChildTableDetail_colnNumberAttribute2.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colnNumberAttribute2.NamedProperties.Put("FieldFlags", "294");
            this.cChildTableDetail_colnNumberAttribute2.NamedProperties.Put("Format", "");
            this.cChildTableDetail_colnNumberAttribute2.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colnNumberAttribute2.NamedProperties.Put("SqlColumn", "NUMBER_ATTRIBUTE2");
            this.cChildTableDetail_colnNumberAttribute2.Position = 16;
            resources.ApplyResources(this.cChildTableDetail_colnNumberAttribute2, "cChildTableDetail_colnNumberAttribute2");
            // 
            // cChildTableDetail_colnNumberAttribute3
            // 
            this.cChildTableDetail_colnNumberAttribute3.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cChildTableDetail_colnNumberAttribute3.Name = "cChildTableDetail_colnNumberAttribute3";
            this.cChildTableDetail_colnNumberAttribute3.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colnNumberAttribute3.NamedProperties.Put("FieldFlags", "294");
            this.cChildTableDetail_colnNumberAttribute3.NamedProperties.Put("Format", "");
            this.cChildTableDetail_colnNumberAttribute3.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colnNumberAttribute3.NamedProperties.Put("SqlColumn", "NUMBER_ATTRIBUTE3");
            this.cChildTableDetail_colnNumberAttribute3.Position = 17;
            resources.ApplyResources(this.cChildTableDetail_colnNumberAttribute3, "cChildTableDetail_colnNumberAttribute3");
            // 
            // cChildTableDetail_colnNumberAttribute4
            // 
            this.cChildTableDetail_colnNumberAttribute4.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cChildTableDetail_colnNumberAttribute4.Name = "cChildTableDetail_colnNumberAttribute4";
            this.cChildTableDetail_colnNumberAttribute4.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colnNumberAttribute4.NamedProperties.Put("FieldFlags", "294");
            this.cChildTableDetail_colnNumberAttribute4.NamedProperties.Put("Format", "");
            this.cChildTableDetail_colnNumberAttribute4.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colnNumberAttribute4.NamedProperties.Put("SqlColumn", "NUMBER_ATTRIBUTE4");
            this.cChildTableDetail_colnNumberAttribute4.Position = 18;
            resources.ApplyResources(this.cChildTableDetail_colnNumberAttribute4, "cChildTableDetail_colnNumberAttribute4");
            // 
            // cChildTableDetail_colnNumberAttribute5
            // 
            this.cChildTableDetail_colnNumberAttribute5.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cChildTableDetail_colnNumberAttribute5.Name = "cChildTableDetail_colnNumberAttribute5";
            this.cChildTableDetail_colnNumberAttribute5.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colnNumberAttribute5.NamedProperties.Put("FieldFlags", "294");
            this.cChildTableDetail_colnNumberAttribute5.NamedProperties.Put("Format", "");
            this.cChildTableDetail_colnNumberAttribute5.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colnNumberAttribute5.NamedProperties.Put("SqlColumn", "NUMBER_ATTRIBUTE5");
            this.cChildTableDetail_colnNumberAttribute5.Position = 19;
            resources.ApplyResources(this.cChildTableDetail_colnNumberAttribute5, "cChildTableDetail_colnNumberAttribute5");
            // 
            // labelRpdId
            // 
            resources.ApplyResources(this.labelRpdId, "labelRpdId");
            this.labelRpdId.Name = "labelRpdId";
            // 
            // labelRpdYear
            // 
            resources.ApplyResources(this.labelRpdYear, "labelRpdYear");
            this.labelRpdYear.Name = "labelRpdYear";
            // 
            // dfsDescription
            // 
            resources.ApplyResources(this.dfsDescription, "dfsDescription");
            this.dfsDescription.Name = "dfsDescription";
            this.dfsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescription.NamedProperties.Put("FieldFlags", "288");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("ParentName", "cmbRpdId");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "RPD_IDENTITY_API.GET_DESCRIPTION(RPD_ID)");
            // 
            // labelDescription
            // 
            resources.ApplyResources(this.labelDescription, "labelDescription");
            this.labelDescription.Name = "labelDescription";
            // 
            // cmbRpdId
            // 
            this.cmbRpdId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbRpdId, "cmbRpdId");
            this.cmbRpdId.Name = "cmbRpdId";
            this.cmbRpdId.NamedProperties.Put("EnumerateMethod", "");
            this.cmbRpdId.NamedProperties.Put("FieldFlags", "99");
            this.cmbRpdId.NamedProperties.Put("Format", "9");
            this.cmbRpdId.NamedProperties.Put("LovReference", "RPD_IDENTITY");
            this.cmbRpdId.NamedProperties.Put("SqlColumn", "RPD_ID");
            this.cmbRpdId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbRpdId_WindowActions);
            // 
            // dfnRpdYear
            // 
            this.dfnRpdYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dfnRpdYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnRpdYear, "dfnRpdYear");
            this.dfnRpdYear.Format = "####";
            this.dfnRpdYear.Name = "dfnRpdYear";
            this.dfnRpdYear.NamedProperties.Put("EnumerateMethod", "");
            this.dfnRpdYear.NamedProperties.Put("FieldFlags", "163");
            this.dfnRpdYear.NamedProperties.Put("Format", "");
            this.dfnRpdYear.NamedProperties.Put("LovReference", "RPD_YEAR(RPD_ID)");
            this.dfnRpdYear.NamedProperties.Put("ParentName", "cmbRpdId");
            this.dfnRpdYear.NamedProperties.Put("SqlColumn", "RPD_YEAR");
            // 
            // menuFrmMenu
            // 
            this.menuFrmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFrmMenu_MenuItem_AccPerConnections});
            this.menuFrmMenu.Name = "menuFrmMenu";
            resources.ApplyResources(this.menuFrmMenu, "menuFrmMenu");
            // 
            // menuFrmMenu_MenuItem_AccPerConnections
            // 
            this.menuFrmMenu_MenuItem_AccPerConnections.Command = this.cmd_menuFrmMenu_MenuItem_AccPerConnections;
            resources.ApplyResources(this.menuFrmMenu_MenuItem_AccPerConnections, "menuFrmMenu_MenuItem_AccPerConnections");
            this.menuFrmMenu_MenuItem_AccPerConnections.Name = "menuFrmMenu_MenuItem_AccPerConnections";
            this.menuFrmMenu_MenuItem_AccPerConnections.Text = "Accounting Period Connection...";
            // 
            // cmd_menuFrmMenu_MenuItem_AccPerConnections
            // 
            resources.ApplyResources(this.cmd_menuFrmMenu_MenuItem_AccPerConnections, "cmd_menuFrmMenu_MenuItem_AccPerConnections");
            this.cmd_menuFrmMenu_MenuItem_AccPerConnections.Name = "cmd_menuFrmMenu_MenuItem_AccPerConnections";
            this.cmd_menuFrmMenu_MenuItem_AccPerConnections.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmd_menuFrmMenu_MenuItem_AccPerConnections_Execute);
            this.cmd_menuFrmMenu_MenuItem_AccPerConnections.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmd_menuFrmMenu_MenuItem_AccPerConnections_Inquire);
            // 
            // frmRpdYear
            // 
            resources.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.menuFrmMenu;
            this.Controls.Add(this.dfnRpdYear);
            this.Controls.Add(this.cmbRpdId);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.labelRpdYear);
            this.Controls.Add(this.labelRpdId);
            this.Controls.Add(this.cChildTableDetail);
            this.Name = "frmRpdYear";
            this.NamedProperties.Put("LogicalUnit", "RpdYear");
            this.NamedProperties.Put("Module", "ACCRUL");
            this.NamedProperties.Put("PackageName", "RPD_YEAR_API");
            this.NamedProperties.Put("ViewName", "RPD_YEAR");
            this.cChildTableDetail.ResumeLayout(false);
            this.menuTblMenu.ResumeLayout(false);
            this.menuFrmMenu.ResumeLayout(false);
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

        protected cChildTable cChildTableDetail;
        protected cBackgroundText labelRpdId;
        protected cBackgroundText labelRpdYear;
        protected cDataField dfsDescription;
        protected cBackgroundText labelDescription;
        protected cColumn cChildTableDetail_coldFromDate;
        protected cColumn cChildTableDetail_coldUntilDate;
        protected cColumn cChildTableDetail_colnYearPeriodNum;
        protected cColumn cChildTableDetail_colsYearPeriodStr;
        protected cColumn cChildTableDetail_colsStringAttribute1;
        protected cColumn cChildTableDetail_colsStringAttribute2;
        protected cColumn cChildTableDetail_colsStringAttribute3;
        protected cColumn cChildTableDetail_colsStringAttribute4;
        protected cColumn cChildTableDetail_colsStringAttribute5;
        protected cColumn cChildTableDetail_colnNumberAttribute1;
        protected cColumn cChildTableDetail_colnNumberAttribute2;
        protected cColumn cChildTableDetail_colnNumberAttribute3;
        protected cColumn cChildTableDetail_colnNumberAttribute4;
        protected cColumn cChildTableDetail_colnNumberAttribute5;
        protected cColumn cChildTableDetail_colnRpdPeriod;
        protected cRecListDataField cmbRpdId;
        protected cDataField dfnRpdYear;
        protected cColumn cChildTableDetail_colnRpdYear;
        protected cColumn cChildTableDetail_colsRpdId;
        protected Fnd.Windows.Forms.FndCommand cmd_menuFrmMenu_MenuItem_AccPerConnections;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMenu;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuFrmMenu_MenuItem_AccPerConnections;
        protected Fnd.Windows.Forms.FndCommand cmd_menuTblMenu_MenuItem_AccPerConnections;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMenu;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuTblMenu_MenuItem_AccPerConnections;
    }
}
