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
// <snippet>
// DATE        BY        NOTES
// YY-MM-DD
// 13-05-17    MAAYLK    Bug 108483, instead of GetCodePartNames() called ForceGetCodePartNames() 
// </snippet>

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
    [FndWindowRegistration("ACCOUNTING_CODE_PARTS", "AccountingCodeParts", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("ACCOUNTING_CODE_PARTS_USED2", "AccountingCodeParts")]
    public partial class tbwCodePart : cTableWindowFin
    {
        #region Window Variables
        public SalString sModule = "";
        public SalString sLu = "";
        public SalString lsAttribute = "";
        public SalString sCodePartFunction = "";
        public SalString sIIDYes = "";
        public SalString sIIDNo = "";
        public SalNumber nCurrentRow = 0;
        public SalNumber nRow = 0;
        public SalNumber nRetVal = 0;
        public SalString lsTemp = "";
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalString sCompanyName = "";
        public SalArray<SalString> sChanges = new SalArray<SalString>();
        public SalString sID = "";
        public SalNumber nNumChanges = 0;
        public SalString sPreCommitResult = "";
        public SalString UsedInIl = "";
        public SalString sCompany = "";
        public SalString sBaseCodePart = "";
        public SalBoolean bFromClient = false;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwCodePart()
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
        public new static tbwCodePart FromHandle(SalWindowHandle handle)
        {
            return ((tbwCodePart)SalWindow.FromHandle(handle, typeof(tbwCodePart)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                sLu = "AccountingCodeParts";
                return true;
            }
            #endregion
        }

        /// <summary>
        /// Checks whether the save was successful. This function is executed after all
        /// save logic but before commit. Return TRUE to continue with commit, FALSE to
        /// cause rollback.
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataSourceSaveCheckOk()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Accounting_Code_Parts_API.Check_Avl_Code_Part__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Accounting_Code_Parts_API.Check_Avl_Code_Part__(\r\n" +
                        "                                        :i_hWndFrame.tbwCodePart.sPreCommitResult,\r\n" +
                        "                                        :i_hWndFrame.tbwCodePart.colCompany )");
                }
                if (sPreCommitResult == "FALSE")
                {
                    Ifs.Fnd.ApplicationForms.Int.ErrorBox(Properties.Resources.ERROR_OnlyNineCodeParts);
                    return false;
                }
                // Bug 108483, Begin
                ((cTableWindowFin)this).ForceGetCodePartNames(i_sCompany, cSessionManager.c_sDbPrefix);
                // Bug 108483, End

                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sFormName"></param>
        /// <returns></returns>
        public virtual SalBoolean PrepareLaunch(SalString sFormName)
        {
            #region Local Variables
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sFormName == Pal.GetActiveInstanceName("frmCompanyTranslation"))
                {
                    Sal.WaitCursor(true);
                    sModule = "ACCRUL";
                    sLu = "AccountingCodeParts";
                    lsAttribute = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    nRow = Sys.TBL_MinRow;
                    while (true)
                    {
                        if (Sal.TblFindNextRow(this, ref nRow, Sys.ROW_Selected, 0))
                        {
                            Sal.TblSetContext(this, nRow);
                            lsAttribute = lsAttribute + "'" + colCodePart.Text + "'" + ",";
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (lsAttribute != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        lsAttribute = lsAttribute.Left(lsAttribute.Length - 1);
                    }
                    Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_COMPANY", i_sCompany);
                    Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_MODULE", sModule);
                    Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_LU", sLu);
                    Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_ATTRIBUTE", lsAttribute);
                    SessionCreateWindow(Pal.GetActiveInstanceName("frmCompanyTranslation"), Sys.hWndMDI);
                    Sal.WaitCursor(false);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetIIDYesNo()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("ACCOUNTING_CODE_PART_Y_N_API.decode", System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                        "	     :i_hWndFrame.tbwCodePart.lsTemp :=  \r\n" +
                        "	      &AO.ACCOUNTING_CODE_PART_Y_N_API.decode( 'N' );\r\n" +
                        "      	 END; ");
                }
                sIIDNo = lsTemp;
                Sal.WaitCursor(false);
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Properties.Resources.WH_tbwCodePart;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetBaseCodePart()
        {
            #region Actions
            UserGlobalValueGet("COMPANY", ref sCompany);
            String sStmt = "";
            sStmt = "BEGIN ";
            sStmt = sStmt + ":i_hWndFrame.tbwCodePart.sBaseCodePart := &AO.Accounting_Code_Parts_API.Get_Base_For_Followup_Element(:i_hWndFrame.tbwCostEleToAccntSecmap.sCompany IN);";
            sStmt = sStmt + " END;";
            DbPLSQLTransaction(cSessionManager.c_hSql, sStmt);

            return 0;
            #endregion
        }

        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tbwCodePart_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.tbwCodePart_OnSAM_Create(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCodePart_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam))
            {
                Sal.SetWindowText(this, Properties.Resources.WH_tbwCodePart);
                e.Return = true;
                return;
            }
            else
            {
                e.Return = false;
                return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodeUsed_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Validate:
                    this.colCodeUsed_OnSAM_Validate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Validate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodeUsed_OnSAM_Validate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.sIIDNo == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                this.GetIIDYesNo();
            }
            if ((this.colCodePart.Text == "A") && (this.colCodeUsed.Text == this.sIIDNo))
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.WH_tbwCodePart_A_have_be_yes, Properties.Resources.WH_tbwCodePart, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_Validate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colLogicalCodePart_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colLogicalCodePart_OnPM_DataItemValidate(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    this.colLogicalCodePart_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colLogicalCodePart_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            Sal.WaitCursor(true);
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("Accounting_Code_Parts_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                this.colLogicalCodePart.DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                    "	      :i_hWndFrame.tbwCodePart.colParentCodePartDesc   :=  \r\n" +
                    "	      substr( &AO.Accounting_Code_Parts_API.Get_Description(\r\n" +
                    "      	      :i_hWndFrame.tbwCodePart.colConsCompany,\r\n" +
                    "                      :i_hWndFrame.tbwCodePart.colParentCodePart),1,35);\r\n	 END; ");
            }
            Sal.WaitCursor(false);
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colLogicalCodePart_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            if (this.colConsCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                this.colParentCodePart.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                Sal.MessageBeep(0);
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colMaxNumberOfChar_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colMaxNumberOfChar_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colMaxNumberOfChar_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colMaxNumberOfChar.Number < 0 || this.colMaxNumberOfChar.Number > 10)
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_InValMaxCharNo, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            else
            {
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colParentCodePart_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colParentCodePart_OnPM_DataItemValidate(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    this.colParentCodePart_OnSAM_AnyEdit(sender, e);
                    break;

                case Sys.SAM_SetFocus:
                    this.colParentCodePart_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="lsServerAttr">
        /// Server attributes
        /// Object attributes sent from the client to the server. Applications can add extra
        /// attributes to this list.
        /// </param>
        /// <returns></returns>
        public new SalNumber DataRecordFetchEditedUser(ref SalString lsServerAttr)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (bFromClient )
                {
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("FROM_CLIENT", "TRUE", ref lsServerAttr);
                }
                else
                {
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("FROM_CLIENT", "FALSE", ref lsServerAttr);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colParentCodePart_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            Sal.WaitCursor(true);
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("Accounting_Code_Parts_API.Get_Name", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                this.colParentCodePart.DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                    "	      :i_hWndFrame.tbwCodePart.colParentCodePartDesc   :=  \r\n" +
                    "	      substr( &AO.Accounting_Code_Parts_API.Get_Name(\r\n" +
                    "      	      :i_hWndFrame.tbwCodePart.colConsCompany,\r\n" +
                    "                      :i_hWndFrame.tbwCodePart.colParentCodePart),1,35);\r\n	 END; ");
            }
            Sal.WaitCursor(false);
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colParentCodePart_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            if (this.colConsCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                this.colParentCodePart.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                Sal.MessageBeep(0);
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colParentCodePart_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colConsCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                this.colParentCodePart.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                System.Windows.Forms.SendKeys.Send("{TAB}");
                Sal.MessageBeep(0);
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colViewName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colViewName_OnPM_DataItemValidate(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    this.colViewName_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colViewName_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            Sal.WaitCursor(true);
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("Accounting_Code_Parts_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                this.colViewName.DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                    "	      :i_hWndFrame.tbwCodePart.colParentCodePartDesc   :=  \r\n" +
                    "	      substr( &AO.Accounting_Code_Parts_API.Get_Description(\r\n" +
                    "      	      :i_hWndFrame.tbwCodePart.colConsCompany,\r\n" +
                    "                      :i_hWndFrame.tbwCodePart.colParentCodePart),1,35);\r\n	 END; ");
            }
            Sal.WaitCursor(false);
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colViewName_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            if (this.colConsCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                this.colParentCodePart.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                Sal.MessageBeep(0);
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colPackageName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colPackageName_OnPM_DataItemValidate(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    this.colPackageName_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colPackageName_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            Sal.WaitCursor(true);
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("Accounting_Code_Parts_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                this.colPackageName.DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                    "	      :i_hWndFrame.tbwCodePart.colParentCodePartDesc   :=  \r\n" +
                    "	      substr( &AO.Accounting_Code_Parts_API.Get_Description(\r\n" +
                    "      	      :i_hWndFrame.tbwCodePart.colConsCompany,\r\n" +
                    "                      :i_hWndFrame.tbwCodePart.colParentCodePart),1,35);\r\n	 END; ");
            }
            Sal.WaitCursor(false);
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colPackageName_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            if (this.colConsCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                this.colParentCodePart.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                Sal.MessageBeep(0);
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtActivate(fcURL URL)
        {
            Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            return true;
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtDataRecordFetchEditedUser(ref SalString lsAttr)
        {
            return this.DataRecordFetchEditedUser(ref lsAttr);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataSourceSaveCheckOk()
        {
            return this.DataSourceSaveCheckOk();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
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

        private void menuItem_Set_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            if (colBaseForPFE.Text == "TRUE")
            {
                ((FndCommand)sender).Enabled = false;
            }
            else
            {
                nRow = Sys.TBL_MinRow;
                if (Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_Selected, 0))
                {
                    if (Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_Selected, 0))
                    {
                        ((FndCommand)sender).Enabled = false;
                    }
                    else
                    {
                        ((FndCommand)sender).Enabled = true;
                    }
                }
                else
                {
                    ((FndCommand)sender).Enabled = false;
                }
            }
        }

        private void menuItem_Set_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            colBaseForPFE.Text = "TRUE";
            colBaseForPFE.EditDataItemSetEdited();
            GetBaseCodePart();



            if (DbPLSQLTransaction(cSessionManager.c_hSql, " &AO.Accounting_Code_Parts_API.Check_Transactions_Exist__( :i_hWndFrame.tbwCodePart.colCompany IN ,\r\n" +
                                                                                                           " :i_hWndFrame.tbwCodePart.sBaseCodePart  IN) "))
            {
                this.bFromClient = true;
                if (sBaseCodePart == "A")
                {
                    if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ChangeBaseforPCRE,
                                           Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question,
                                           Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo) == Sys.IDNO)
                    {
                        Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_NoConfirm);

                    }
                }
                Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_NoConfirm);


            }
            else
            {
                Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            }
            
                    
        }

        private void menuItem__Translation_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = !(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) && Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCompanyTranslation")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCompanyTranslation"));
            
        }

        private void menuItem__Translation_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            PrepareLaunch(Pal.GetActiveInstanceName("frmCompanyTranslation"));
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        private void menuItem__Translation_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = !(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) && Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCompanyTranslation")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCompanyTranslation"));
        }

        private void menuItem__Translation_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            PrepareLaunch(Pal.GetActiveInstanceName("frmCompanyTranslation"));
        }

        private void menuItem_Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam); 
        }

        #endregion

    }
}
