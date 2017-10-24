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

namespace Ifs.Application.Accrul
{

    public partial class tbwAuditFormat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwAuditFormat));
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCountry = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsDecimalPoint = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsThousandSeparator = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsNegativeFormat = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsLeadingZeroes = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsTimeFormat = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsDateFormat = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsOutputFileDir = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsOutputFileDirServer = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuChangeCompany = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItemChangeCompany = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.colsDefaultFormat = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsCountryDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuChangeCompany);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            this.commandManager.ImageList = null;
            // 
            // colsCompany
            // 
            this.colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCompany.MaxLength = 20;
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "99");
            this.colsCompany.NamedProperties.Put("LovReference", "COMPANY");
            this.colsCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.Position = 3;
            resources.ApplyResources(this.colsCompany, "colsCompany");
            // 
            // colsCountry
            // 
            this.colsCountry.MaxLength = 200;
            this.colsCountry.Name = "colsCountry";
            this.colsCountry.NamedProperties.Put("EnumerateMethod", "ISO_COUNTRY_API.Enumerate");
            this.colsCountry.NamedProperties.Put("FieldFlags", "163");
            this.colsCountry.NamedProperties.Put("LovReference", "");
            this.colsCountry.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCountry.NamedProperties.Put("SqlColumn", "COUNTRY");
            this.colsCountry.Position = 5;
            resources.ApplyResources(this.colsCountry, "colsCountry");
            // 
            // colsDecimalPoint
            // 
            this.colsDecimalPoint.MaxLength = 200;
            this.colsDecimalPoint.Name = "colsDecimalPoint";
            this.colsDecimalPoint.NamedProperties.Put("EnumerateMethod", "AUDIT_DECIMAL_API.Enumerate");
            this.colsDecimalPoint.NamedProperties.Put("FieldFlags", "295");
            this.colsDecimalPoint.NamedProperties.Put("LovReference", "");
            this.colsDecimalPoint.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDecimalPoint.NamedProperties.Put("SqlColumn", "DECIMAL_POINT");
            this.colsDecimalPoint.Position = 6;
            resources.ApplyResources(this.colsDecimalPoint, "colsDecimalPoint");
            // 
            // colsThousandSeparator
            // 
            this.colsThousandSeparator.MaxLength = 200;
            this.colsThousandSeparator.Name = "colsThousandSeparator";
            this.colsThousandSeparator.NamedProperties.Put("EnumerateMethod", "AUDIT_THOUSAND_FMT_API.Enumerate");
            this.colsThousandSeparator.NamedProperties.Put("FieldFlags", "295");
            this.colsThousandSeparator.NamedProperties.Put("LovReference", "");
            this.colsThousandSeparator.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsThousandSeparator.NamedProperties.Put("SqlColumn", "THOUSAND_SEPARATOR");
            this.colsThousandSeparator.Position = 7;
            resources.ApplyResources(this.colsThousandSeparator, "colsThousandSeparator");
            // 
            // colsNegativeFormat
            // 
            this.colsNegativeFormat.MaxLength = 200;
            this.colsNegativeFormat.Name = "colsNegativeFormat";
            this.colsNegativeFormat.NamedProperties.Put("EnumerateMethod", "AUDIT_NEGATIVE_FMT_API.Enumerate");
            this.colsNegativeFormat.NamedProperties.Put("FieldFlags", "295");
            this.colsNegativeFormat.NamedProperties.Put("LovReference", "");
            this.colsNegativeFormat.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsNegativeFormat.NamedProperties.Put("SqlColumn", "NEGATIVE_FORMAT");
            this.colsNegativeFormat.Position = 8;
            resources.ApplyResources(this.colsNegativeFormat, "colsNegativeFormat");
            // 
            // colsLeadingZeroes
            // 
            this.colsLeadingZeroes.MaxLength = 200;
            this.colsLeadingZeroes.Name = "colsLeadingZeroes";
            this.colsLeadingZeroes.NamedProperties.Put("EnumerateMethod", "AUDIT_ZERO_FORMAT_API.Enumerate");
            this.colsLeadingZeroes.NamedProperties.Put("FieldFlags", "295");
            this.colsLeadingZeroes.NamedProperties.Put("LovReference", "");
            this.colsLeadingZeroes.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsLeadingZeroes.NamedProperties.Put("SqlColumn", "LEADING_ZEROES");
            this.colsLeadingZeroes.Position = 9;
            resources.ApplyResources(this.colsLeadingZeroes, "colsLeadingZeroes");
            // 
            // colsTimeFormat
            // 
            this.colsTimeFormat.MaxLength = 200;
            this.colsTimeFormat.Name = "colsTimeFormat";
            this.colsTimeFormat.NamedProperties.Put("EnumerateMethod", "AUDIT_TIME_FORMAT_API.Enumerate");
            this.colsTimeFormat.NamedProperties.Put("FieldFlags", "295");
            this.colsTimeFormat.NamedProperties.Put("LovReference", "");
            this.colsTimeFormat.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsTimeFormat.NamedProperties.Put("SqlColumn", "TIME_FORMAT");
            this.colsTimeFormat.Position = 10;
            resources.ApplyResources(this.colsTimeFormat, "colsTimeFormat");
            // 
            // colsDateFormat
            // 
            this.colsDateFormat.MaxLength = 200;
            this.colsDateFormat.Name = "colsDateFormat";
            this.colsDateFormat.NamedProperties.Put("EnumerateMethod", "AUDIT_DATE_FORMAT_API.Enumerate");
            this.colsDateFormat.NamedProperties.Put("FieldFlags", "295");
            this.colsDateFormat.NamedProperties.Put("LovReference", "");
            this.colsDateFormat.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDateFormat.NamedProperties.Put("SqlColumn", "DATE_FORMAT");
            this.colsDateFormat.Position = 11;
            resources.ApplyResources(this.colsDateFormat, "colsDateFormat");
            // 
            // colsOutputFileDir
            // 
            this.colsOutputFileDir.MaxLength = 2000;
            this.colsOutputFileDir.Name = "colsOutputFileDir";
            this.colsOutputFileDir.NamedProperties.Put("EnumerateMethod", "");
            this.colsOutputFileDir.NamedProperties.Put("FieldFlags", "310");
            this.colsOutputFileDir.NamedProperties.Put("LovReference", "");
            this.colsOutputFileDir.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsOutputFileDir.NamedProperties.Put("SqlColumn", "OUTPUT_FILE_DIR");
            this.colsOutputFileDir.Position = 12;
            resources.ApplyResources(this.colsOutputFileDir, "colsOutputFileDir");
            this.colsOutputFileDir.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsOutputFileDir_WindowActions);
            // 
            // colsOutputFileDirServer
            // 
            this.colsOutputFileDirServer.MaxLength = 2000;
            this.colsOutputFileDirServer.Name = "colsOutputFileDirServer";
            this.colsOutputFileDirServer.NamedProperties.Put("EnumerateMethod", "");
            this.colsOutputFileDirServer.NamedProperties.Put("FieldFlags", "310");
            this.colsOutputFileDirServer.NamedProperties.Put("LovReference", "");
            this.colsOutputFileDirServer.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsOutputFileDirServer.NamedProperties.Put("SqlColumn", "OUTPUT_FILE_DIR_SERVER");
            this.colsOutputFileDirServer.Position = 13;
            resources.ApplyResources(this.colsOutputFileDirServer, "colsOutputFileDirServer");
            // 
            // menuChangeCompany
            // 
            resources.ApplyResources(this.menuChangeCompany, "menuChangeCompany");
            this.menuChangeCompany.Name = "menuChangeCompany";
            this.menuChangeCompany.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menu_ChangeCompany_Execute);
            this.menuChangeCompany.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menu_ChangeCompany_Inquire);
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemChangeCompany});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItemChangeCompany
            // 
            this.menuItemChangeCompany.Command = this.menuChangeCompany;
            this.menuItemChangeCompany.Name = "menuItemChangeCompany";
            resources.ApplyResources(this.menuItemChangeCompany, "menuItemChangeCompany");
            this.menuItemChangeCompany.Text = "Change Company...";
            // 
            // colsDefaultFormat
            // 
            this.colsDefaultFormat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsDefaultFormat.MaxLength = 5;
            this.colsDefaultFormat.Name = "colsDefaultFormat";
            this.colsDefaultFormat.NamedProperties.Put("EnumerateMethod", "");
            this.colsDefaultFormat.NamedProperties.Put("FieldFlags", "295");
            this.colsDefaultFormat.NamedProperties.Put("LovReference", "");
            this.colsDefaultFormat.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDefaultFormat.NamedProperties.Put("SqlColumn", "DEFAULT_FORMAT");
            this.colsDefaultFormat.Position = 14;
            resources.ApplyResources(this.colsDefaultFormat, "colsDefaultFormat");
            this.colsDefaultFormat.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsDefaultFormat_WindowActions);
            // 
            // colsCountryDb
            // 
            this.colsCountryDb.MaxLength = 20;
            this.colsCountryDb.Name = "colsCountryDb";
            this.colsCountryDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsCountryDb.NamedProperties.Put("FieldFlags", "4352");
            this.colsCountryDb.NamedProperties.Put("LovReference", "");
            this.colsCountryDb.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCountryDb.NamedProperties.Put("SqlColumn", "COUNTRY_DB");
            this.colsCountryDb.Position = 4;
            resources.ApplyResources(this.colsCountryDb, "colsCountryDb");
            // 
            // tbwAuditFormat
            // 
            resources.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.menuTbwMethods;
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsCountryDb);
            this.Controls.Add(this.colsCountry);
            this.Controls.Add(this.colsDecimalPoint);
            this.Controls.Add(this.colsThousandSeparator);
            this.Controls.Add(this.colsNegativeFormat);
            this.Controls.Add(this.colsLeadingZeroes);
            this.Controls.Add(this.colsTimeFormat);
            this.Controls.Add(this.colsDateFormat);
            this.Controls.Add(this.colsOutputFileDir);
            this.Controls.Add(this.colsOutputFileDirServer);
            this.Controls.Add(this.colsDefaultFormat);
            this.Name = "tbwAuditFormat";
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :global.company");
            this.NamedProperties.Put("LogicalUnit", "AuditFormat");
            this.NamedProperties.Put("PackageName", "AUDIT_FORMAT_API");
            this.NamedProperties.Put("SourceFlags", "16833");
            this.NamedProperties.Put("ViewName", "AUDIT_FORMAT");
            this.Controls.SetChildIndex(this.colsDefaultFormat, 0);
            this.Controls.SetChildIndex(this.colsOutputFileDirServer, 0);
            this.Controls.SetChildIndex(this.colsOutputFileDir, 0);
            this.Controls.SetChildIndex(this.colsDateFormat, 0);
            this.Controls.SetChildIndex(this.colsTimeFormat, 0);
            this.Controls.SetChildIndex(this.colsLeadingZeroes, 0);
            this.Controls.SetChildIndex(this.colsNegativeFormat, 0);
            this.Controls.SetChildIndex(this.colsThousandSeparator, 0);
            this.Controls.SetChildIndex(this.colsDecimalPoint, 0);
            this.Controls.SetChildIndex(this.colsCountry, 0);
            this.Controls.SetChildIndex(this.colsCountryDb, 0);
            this.Controls.SetChildIndex(this.colsCompany, 0);
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

        protected cColumn colsCompany;
        protected cLookupColumn colsCountry;
        protected cLookupColumn colsDecimalPoint;
        protected cLookupColumn colsThousandSeparator;
        protected cLookupColumn colsNegativeFormat;
        protected cLookupColumn colsLeadingZeroes;
        protected cLookupColumn colsTimeFormat;
        protected cLookupColumn colsDateFormat;
        protected cColumn colsOutputFileDir;
        protected cColumn colsOutputFileDirServer;
        protected Fnd.Windows.Forms.FndCommand menuChangeCompany;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItemChangeCompany;
        protected cCheckBoxColumn colsDefaultFormat;
        protected cColumn colsCountryDb;

    }
}
