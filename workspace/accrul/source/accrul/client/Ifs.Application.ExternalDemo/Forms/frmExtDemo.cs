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
using System.Diagnostics;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.ExternalDemo
{

    /// <summary>
    /// </summary>
    public partial class frmExtDemo : cFormWindow
    {
        #region Member Variables
        public SalString sFileTemplateId = "";
        public SalString sRecordTypeId = "";
        public SalString sColumnTranslationMsg = "";
        public SalString lsParam = "";
        public cMessage cColumnTranslationMsg = new cMessage();
        public cMessage cColumnTranslationMsg2 = new cMessage();
        public cMessage cColumnTranslationMsg3 = new cMessage();
        public cMessage cColumnTranslationMsg4 = new cMessage();
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmExtDemo()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        #endregion

        #region System Methods/Properties
        //protected virtual void CustomDataItemQueryEnabled(WindowActionsEventArgs e)
        //{
        //    if ((this.dfsStateDb.Text == "4") || (this.dfsStateDb.Text == "7"))
        //    {
        //        e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
        //        return;
        //    }
        //    else
        //    {
        //        e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
        //        return;
        //    }
        //}
        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static frmExtDemo FromHandle(SalWindowHandle handle)
        {
            return ((frmExtDemo)SalWindow.FromHandle(handle, typeof(frmExtDemo)));
        }

        #endregion

        private void dfsUserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmExtDemo_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Revision_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {

        }

        private void Revision_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {

        }

        private void tblExtFileTransDemo_colnLoadFileId_Click(object sender, EventArgs e)
        {

        }

       
        #region Properties

        #endregion

        #region Methods

        #endregion

        #region Overrides

        #endregion

        #region Window Actions
        public virtual SalNumber ChangeColumnTitles()
        {
            #region Local Variables
            SalNumber nRows = 0;
            SalNumber n = 0;
            SalArray<SalString> sNames = new SalArray<SalString>();
            SalArray<SalString> sValues = new SalArray<SalString>();
            SalNumber nRows2 = 0;
            SalNumber n2 = 0;
            SalArray<SalString> sNames2 = new SalArray<SalString>();
            SalArray<SalString> sValues2 = new SalArray<SalString>();
            SalNumber nRows3 = 0;
            SalNumber n3 = 0;
            SalArray<SalString> sNames3 = new SalArray<SalString>();
            SalArray<SalString> sValues3 = new SalArray<SalString>();
            SalString sColName = "";
            SalString sColDesc = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                this.sFileTemplateId = this.dfsFileTemplateId.Text;
                this.sRecordTypeId = this.cChildTableDetail_colsRecordTypeId.Text;
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                namedBindVariables.Add("ColumnTranslationMsg", this.QualifiedVarBindName("sColumnTranslationMsg"));
                namedBindVariables.Add("FileTemplateId", this.QualifiedVarBindName("sFileTemplateId"));
                namedBindVariables.Add("RecordTypeId", this.cChildTableDetail_colsRecordTypeId.QualifiedBindName);
                string stmt = @"&AO.EXT_FILE_TRANS_API.Get_Column_Names({ColumnTranslationMsg} OUT, {FileTemplateId} IN, {RecordTypeId} IN );";

                if (DbPLSQLBlock(stmt, namedBindVariables))
                {
                    this.cColumnTranslationMsg.Unpack(this.sColumnTranslationMsg);
                    if (this.cColumnTranslationMsg.GetName() == "COLUMNNAMES")
                    {
                        Sal.SendMsgToChildren(this.tblExtFileTransColDemo, Const.PAM_ExtEnableDisable, Const.METHOD_ExtDisable, Sys.lParam);
                        nRows = this.cColumnTranslationMsg.EnumAttributes(sNames, sValues);
                        n = 0;
                        while (n < nRows)
                        {
                            this.cColumnTranslationMsg2.Unpack(sValues[n]);
                            if (this.cColumnTranslationMsg2.GetName() == "DETAILS")
                            {
                                nRows2 = this.cColumnTranslationMsg2.EnumAttributes(sNames2, sValues2);
                                n2 = 0;
                                if (nRows2 < 1)
                                {
                                    Sal.SendMsgToChildren(this.tblExtFileTransColDemo, Const.PAM_ExtEnableDisable, Const.METHOD_ExtEnableDefault, Sys.lParam);
                                }
                                else
                                {
                                    while (n2 < nRows2)
                                    {
                                        this.cColumnTranslationMsg3.Unpack(sValues2[n2]);
                                        if (this.cColumnTranslationMsg3.GetName() == "LINE")
                                        {
                                            nRows3 = this.cColumnTranslationMsg3.EnumAttributes(sNames3, sValues3);
                                            n3 = 0;
                                            sColName = this.cColumnTranslationMsg3.FindAttribute("NAME", Ifs.Fnd.ApplicationForms.Const.strNULL);
                                            sColDesc = this.cColumnTranslationMsg3.FindAttribute("TRANS", Ifs.Fnd.ApplicationForms.Const.strNULL);
                                            if (sColName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                                            {
                                                Sal.SendMsgToChildren(this.tblExtFileTransColDemo, Const.PAM_ExtTranslateTitle, sColName.ToHandle(), sColDesc.ToHandle());
                                            }
                                        }
                                        n2 = n2 + 1;
                                    }
                                }
                            }
                            n = n + 1;
                        }
                    }
                    Sal.PostMsg(this.tblExtFileTransColDemo, Ifs.Fnd.ApplicationForms.Const.PM_TableColumnsOptimize, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                }
                else
                {
                    Sal.SendMsgToChildren(this.tblExtFileTransColDemo, Const.PAM_ExtEnableDisable, Const.METHOD_ExtDisable, Sys.lParam);
                }

            }

            return 0;
            #endregion
        }

       
        #endregion
        private void tblExtFileTransColumn_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.tblExtFileTransColumn_OnPM_DataSourcePopulate(sender, e);
                    break;
            }
            #endregion
        }


        private void tblExtFileTransColumn_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
                {
                    this.ChangeColumnTitles();
                    e.Return = true;
                    return;
                }
                e.Return = false;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }
        private void tblExtFileTrans_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                //case Sys.SAM_RowHeaderClick:
                //    this.tblExtFileTrans_OnSAM_RowHeaderClick(sender, e);
                //    break;

                //case Sys.SAM_Click:
                //    this.tblExtFileTrans_OnSAM_Click(sender, e);
                //    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.tblExtFileTrans_OnPM_DataSourcePopulate(sender, e);
                    break;

                //case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                //    this.tblExtFileTransDemo_OnPM_DataRecordRemove(sender, e);
                //    break;
            }
            #endregion
        }

        //private void tblExtFileTrans_OnSAM_RowHeaderClick(object sender, WindowActionsEventArgs e)
        //{
        //    #region Actions
        //    e.Handled = true;
        //    if (!(this.nRownoRow == this.tblExtFileTrans_colnRowNo.Number))
        //    {
        //        Sal.EnableWindowAndLabel(this.tblExtFileTransColumn);
        //        Sal.SendMsg(frmExternalFileTransactions.FromHandle(this.tblExtFileTrans.i_hWndFrame).tblExtFileTransColumn, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
        //        this.nRownoRow = this.tblExtFileTrans_colnRowNo.Number;
        //        Sal.SetFocus(this.tblExtFileTrans);
        //        Sal.TblClearSelection(this.tblExtFileTransColumn);
        //    }
        //    #endregion
        //}

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        //private void tblExtFileTrans_OnSAM_Click(object sender, WindowActionsEventArgs e)
        //{
        //    #region Actions
        //    e.Handled = true;
        //    if (!(this.nRownoRow == this.tblExtFileTrans_colnRowNo.Number))
        //    {
        //        Sal.EnableWindowAndLabel(this.tblExtFileTransColumn);
        //        Sal.SendMsg(frmExternalFileTransactions.FromHandle(this.tblExtFileTrans.i_hWndFrame).tblExtFileTransColumn, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
        //        this.nRownoRow = this.tblExtFileTrans_colnRowNo.Number;
        //        Sal.SetFocus(this.tblExtFileTrans);
        //        Sal.TblClearSelection(this.tblExtFileTransColumn);
        //    }
        //    #endregion
        //}

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileTrans_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
                {
                    Sal.TblClearSelection(this.tblExtFileTransDemo);
                    e.Return = true;
                    return;
                }
                e.Return = false;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        //private void tblExtFileTrans_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        //{
        //    #region Actions
        //    e.Handled = true;
        //    if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
        //    {
        //        if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam))
        //        {
        //            this.HideAllColumns();
        //            Sal.DisableWindowAndLabel(this.tblExtFileTransColumn);
        //            e.Return = true;
        //            return;
        //        }
        //        e.Return = false;
        //        return;
        //    }
        //    else if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
        //    {
        //        if ((this.dfsStateDb.Text == "4") || (this.dfsStateDb.Text == "7"))
        //        {
        //            e.Return = false;
        //            return;
        //        }
        //    }
        //    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
        //    return;
        //    #endregion
        //}
        //#endregion
        #region Overrides

        #endregion

        #region Menu Event Handlers

        #endregion
    }
}
