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
// Date    By      Notes
// ------  ------  -------------------------------------------------------------------------------------
// 141115  Kagalk  PRFI-3472, Merge Bug 119590, Modified tax code restriction validations.
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
using Ifs.Fnd.Windows.Forms;

namespace Ifs.Application.Accrul_
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("TAX_BOOK", "TaxBook", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwTaxBook : cTableWindowFin
    {
        #region Window Variables
        public SalString sTaxCode = "";
        public SalString sTaxCodeDb = "";
        public SalString sOldTaxCodeDb = "";
        public SalString sStatus = "";
        public SalString sCompany = "";        
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwTaxBook()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public new static tbwTaxBook FromHandle(SalWindowHandle handle)
        {
            return ((tbwTaxBook)SalWindow.FromHandle(handle, typeof(tbwTaxBook)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Properties.Resources.WH_tbwTaxBook;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean EnableCodePerBook()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmTaxCodePerTaxBook")))
                {
                    if (Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, ((Sys.ROW_Edited | Sys.ROW_MarkDeleted) | Sys.ROW_New)))
                    {
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Tax_Book_API.Get_Tax_Code", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            hints.Add("Tax_Code_API.Encode", System.Data.ParameterDirection.Input);
                            DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.tbwTaxBook.sTaxCode := \r\n" +
                                "			&AO.Tax_Code_API.Encode(\r\n" +
                                "				&AO.Tax_Book_API.Get_Tax_Code(\r\n" +
                                "					:i_hWndFrame.tbwTaxBook.colsCompany,\r\n" +
                                "					:i_hWndFrame.tbwTaxBook.colsTaxBookId))");
                        }
                        if (sTaxCode == "RESTRICTED")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            #endregion
        }

        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tbwTaxBook_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_FetchRowDone:
                    this.tbwTaxBook_OnSAM_FetchRowDone(sender, e);
                    break;                
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.tbwTaxBook_OnPM_DataSourceSave(sender, e);
                    break;                
            }
            #endregion
        }

        /// <summary>
        /// SAM_FetchRowDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwTaxBook_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.colsOldTaxCode.Text = this.colsTaxCode.Text;
            // Bug 86044 - Begin. Called the class message of SAM_FetchRowDone.
            e.Return = Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam);
            return;
            // Bug 86044 - End.
            #endregion
        }

        private void tbwTaxBook_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalNumber nRow = 0;            
            #endregion

            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                nRow = Sys.TBL_MinRow;
                while (Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_Edited | Sys.ROW_New, Sys.ROW_MarkDeleted))
                {
                    Sal.TblSetContext(i_hWndSelf, nRow);                   
                    if (this.colsTaxCode.Text != this.colsOldTaxCode.Text || this.colsOldTaxCode.Text == Sys.STRING_Null)
                    {
                        DbPLSQLBlock(cSessionManager.c_hSql, @":i_hWndFrame.tbwTaxBook.sTaxCodeDb := &AO.Tax_Code_API.Encode(:i_hWndFrame.tbwTaxBook.colsTaxCode)");
                        if (this.sTaxCodeDb == "RESTRICTED")
                        {
                            if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_WarnTaxRestr, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_YesNo) == Sys.IDNO)
                            {
                                if (this.colsOldTaxCode.Text != Sys.STRING_Null)
                                {
                                    this.colsTaxCode.Text = this.colsOldTaxCode.Text;   
                                }                                
                                e.Return = false;
                                return;
                            }
                        }
                    }
                }                
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            }
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsTaxCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsTaxCode_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsTaxCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("Tax_Code_API.Encode", System.Data.ParameterDirection.Input);
                this.colsTaxCode.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                    "			:i_hWndFrame.tbwTaxBook.sOldTaxCodeDb := \r\n" +
                    "			&AO.Tax_Code_API.Encode(:i_hWndFrame.tbwTaxBook.colsOldTaxCode);\r\n" +
                    "			:i_hWndFrame.tbwTaxBook.sTaxCodeDb := \r\n" +
                    "			&AO.Tax_Code_API.Encode(:i_hWndFrame.tbwTaxBook.colsTaxCode);\r\n			END;");
            }
            if (this.sOldTaxCodeDb == "RESTRICTED" && this.sTaxCodeDb == "ALL")
            {
                if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.QUESTION_RemoveTaxCodes, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo) == Sys.IDNO)
                {
                    this.colsTaxCode.Text = this.colsOldTaxCode.Text;
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
            }                        
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtFrameShutdownUser(SalNumber nWhat)
        {
            return this.FrameShutdownUser(nWhat);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalString vrtGetWindowTitle()
        {
            return this.GetWindowTitle();
        }
        #endregion

        #region Event Handlers

        private void menuItem__Tax_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = EnableCodePerBook();
        }

        private void menuItem__Tax_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {            
            Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindow, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)Pal.GetActiveInstanceName("frmTaxCodePerTaxBook")).ToHandle());         
        }

        private void menuItem__Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem__Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("Tax_Book_API.Check_Restricted", System.Data.ParameterDirection.Input);
                DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.tbwTaxBook.sStatus := &AO.Tax_Book_API.Check_Restricted(:i_hWndFrame.tbwTaxBook.colsCompany)");
            }
            if (sStatus == "FALSE")
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_PreventClose, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
            }
            else
            {
                Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
            }            
        }

        #endregion

    }
}
