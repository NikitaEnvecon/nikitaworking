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

namespace Ifs.Application.MdmBasicData
{

    public partial class tbwMethodList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwMethodList));
            this.colnExecuteSeq = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsMethodName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colOnNew = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsViewName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colOnModify = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsTemplateId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnRevision = new Ifs.Fnd.ApplicationForms.cColumn();
            this.SuspendLayout();
            // 
            // __colObjversion
            // 
            this.@__colObjversion.Position = 5;
            // 
            // colnExecuteSeq
            // 
            this.colnExecuteSeq.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnExecuteSeq.Name = "colnExecuteSeq";
            this.colnExecuteSeq.NamedProperties.Put("EnumerateMethod", "");
            this.colnExecuteSeq.NamedProperties.Put("FieldFlags", "163");
            this.colnExecuteSeq.NamedProperties.Put("Format", "");
            this.colnExecuteSeq.NamedProperties.Put("LovReference", "");
            this.colnExecuteSeq.NamedProperties.Put("SqlColumn", "EXECUTE_SEQ");
            this.colnExecuteSeq.Position = 4;
            this.colnExecuteSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnExecuteSeq, "colnExecuteSeq");
            // 
            // colsMethodName
            // 
            this.colsMethodName.Name = "colsMethodName";
            this.colsMethodName.NamedProperties.Put("EnumerateMethod", "");
            this.colsMethodName.NamedProperties.Put("FieldFlags", "295");
            this.colsMethodName.NamedProperties.Put("LovReference", "");
            this.colsMethodName.NamedProperties.Put("SqlColumn", "METHOD_NAME");
            this.colsMethodName.Position = 7;
            resources.ApplyResources(this.colsMethodName, "colsMethodName");
            // 
            // colOnNew
            // 
            this.colOnNew.Name = "colOnNew";
            this.colOnNew.NamedProperties.Put("EnumerateMethod", "");
            this.colOnNew.NamedProperties.Put("FieldFlags", "295");
            this.colOnNew.NamedProperties.Put("LovReference", "");
            this.colOnNew.NamedProperties.Put("SqlColumn", "ON_NEW");
            this.colOnNew.Position = 8;
            resources.ApplyResources(this.colOnNew, "colOnNew");
            // 
            // colsViewName
            // 
            this.colsViewName.Name = "colsViewName";
            this.colsViewName.NamedProperties.Put("EnumerateMethod", "");
            this.colsViewName.NamedProperties.Put("FieldFlags", "294");
            this.colsViewName.NamedProperties.Put("LovReference", "INTFACE_VIEWS");
            this.colsViewName.NamedProperties.Put("SqlColumn", "VIEW_NAME");
            this.colsViewName.Position = 6;
            resources.ApplyResources(this.colsViewName, "colsViewName");
            // 
            // colOnModify
            // 
            this.colOnModify.Name = "colOnModify";
            this.colOnModify.NamedProperties.Put("EnumerateMethod", "");
            this.colOnModify.NamedProperties.Put("FieldFlags", "295");
            this.colOnModify.NamedProperties.Put("LovReference", "");
            this.colOnModify.NamedProperties.Put("SqlColumn", "ON_MODIFY");
            this.colOnModify.Position = 9;
            resources.ApplyResources(this.colOnModify, "colOnModify");
            // 
            // colsTemplateId
            // 
            this.colsTemplateId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsTemplateId.MaxLength = 30;
            this.colsTemplateId.Name = "colsTemplateId";
            this.colsTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.colsTemplateId.NamedProperties.Put("FieldFlags", "4195");
            this.colsTemplateId.NamedProperties.Put("LovReference", "");
            this.colsTemplateId.NamedProperties.Put("SqlColumn", "TEMPLATE_ID");
            this.colsTemplateId.Position = 2;
            resources.ApplyResources(this.colsTemplateId, "colsTemplateId");
            // 
            // colnRevision
            // 
            this.colnRevision.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnRevision.Name = "colnRevision";
            this.colnRevision.NamedProperties.Put("EnumerateMethod", "");
            this.colnRevision.NamedProperties.Put("FieldFlags", "4195");
            this.colnRevision.NamedProperties.Put("Format", "");
            this.colnRevision.NamedProperties.Put("LovReference", "MDM_BASIC_DATA_HEADER(TEMPLATE_ID)");
            this.colnRevision.NamedProperties.Put("SqlColumn", "REVISION");
            this.colnRevision.Position = 3;
            this.colnRevision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnRevision, "colnRevision");
            // 
            // tbwMethodList
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsTemplateId);
            this.Controls.Add(this.colnRevision);
            this.Controls.Add(this.colnExecuteSeq);
            this.Controls.Add(this.colsViewName);
            this.Controls.Add(this.colsMethodName);
            this.Controls.Add(this.colOnNew);
            this.Controls.Add(this.colOnModify);
            this.Name = "tbwMethodList";
            this.NamedProperties.Put("LogicalUnit", "MdmMethodList");
            this.NamedProperties.Put("Module", "MDMGT");
            this.NamedProperties.Put("PackageName", "MDM_METHOD_LIST_API");
            this.NamedProperties.Put("ViewName", "MDM_METHOD_LIST");
            this.Controls.SetChildIndex(this.colOnModify, 0);
            this.Controls.SetChildIndex(this.colOnNew, 0);
            this.Controls.SetChildIndex(this.colsMethodName, 0);
            this.Controls.SetChildIndex(this.colsViewName, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.colnExecuteSeq, 0);
            this.Controls.SetChildIndex(this.colnRevision, 0);
            this.Controls.SetChildIndex(this.colsTemplateId, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
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

        protected cColumn colnExecuteSeq;
        protected cColumn colsMethodName;
        protected cCheckBoxColumn colOnNew;
        protected cColumn colsViewName;
        protected cCheckBoxColumn colOnModify;
        protected cColumn colsTemplateId;
        protected cColumn colnRevision;
    }
}
