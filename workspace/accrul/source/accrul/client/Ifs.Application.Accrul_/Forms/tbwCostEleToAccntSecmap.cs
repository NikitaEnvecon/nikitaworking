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
using System.Diagnostics;
using Ifs.Application.Accrul;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Accrul_
{

    /// <summary>
    /// </summary>
    /// 
    [FndWindowRegistration("COST_ELE_TO_ACCNT_SECMAP", "CostEleToAccntSecmap")]
    public partial class tbwCostEleToAccntSecmap : cTableWindowFin
    {
        #region Window Variables
        public SalString sBaseForPFE = "";
        public SalArray<SalString> sArray = new SalArray<SalString>();
        public SalArray<SalWindowHandle> hWndArray = new SalArray<SalWindowHandle>();
        public SalNumber nCurrentRow = 0;
        public SalString sCompany = "";
        public SalString sItemName = "";
        public SalString sFormName = "";
        public SalString sCodePart = "";
        public SalArray<SalString> sItemNames = new SalArray<SalString>();
        public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        public SalBoolean bReturn = false;

        public SalString sStmt = "";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwCostEleToAccntSecmap()
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
        [DebuggerStepThrough]
        public new static tbwCostEleToAccntSecmap FromHandle(SalWindowHandle handle)
        {
            return ((tbwCostEleToAccntSecmap)SalWindow.FromHandle(handle, typeof(tbwCostEleToAccntSecmap)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            UserGlobalValueGet("COMPANY", ref sCompany);

            sStmt = "BEGIN ";
            sStmt = sStmt + ":i_hWndFrame.tbwCostEleToAccntSecmap.sBaseForPFE := &AO.Accounting_Code_Parts_API.Get_Base_For_Followup_Element(:i_hWndFrame.tbwCostEleToAccntSecmap.sCompany IN);";
            sStmt = sStmt + " END;";

            DbPLSQLTransaction(cSessionManager.c_hSql, sStmt);

            return base.Activate(URL);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ChangeCompany(SalNumber nWhat)
        {
            switch (nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    return Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    return Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
            }
            return 0;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CopyCREToSecondaryMapping(SalNumber nWhat)
        {
            #region Actions
            UserGlobalValueGet("COMPANY", ref sCompany);
            String sStmt = "";

            switch (nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    sStmt = "BEGIN ";
                    sStmt = sStmt + ":i_hWndFrame.tbwCostEleToAccntSecmap.sCodePart := &AO.Accounting_Code_Parts_API.Get_Base_For_Followup_Element(:i_hWndFrame.tbwCostEleToAccntSecmap.sCompany IN);";
                    sStmt = sStmt + " END;";
                    DbPLSQLTransaction(cSessionManager.c_hSql, sStmt);
                    if (sCodePart == "A")
                    {
                        return true;
                    }
                    return false;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_CopyCRE,
                                                 Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question,
                                                 Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo) == Sys.IDYES)
                    {
                        sStmt = "BEGIN ";
                        sStmt = sStmt + "&AO.Cost_Ele_To_Accnt_Secmap_API.Copy_Elements_To_Sec_Map__(:i_hWndFrame.tbwCostEleToAccntSecmap.sCompany IN);";
                        sStmt = sStmt + " END;";
                        DbPLSQLTransaction(cSessionManager.c_hSql, sStmt);
                        Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        return true;
                    }
                    return false;
            }
            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="hItem"></param>
        /// <returns></returns>
        public virtual SalString GetItemName(SalWindowHandle hItem)
        {
            #region Local Variables
            SalString sItem = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.GetItemName(hItem, ref sItem);
                return sItem;
            }
            #endregion
        }

        /// <summary>
        /// The framework calls the DataRecordGetDefaults function to retrive
        /// client default values for new records.
        /// </summary>
        /// <returns></returns>
        public SalBoolean DataRecordGetDefaults()
        {
            #region Actions
            UserGlobalValueGet("COMPANY", ref sCompany);
            this.colsCompany.Text = sCompany;
            this.colsCompany.EditDataItemSetEdited();
            return true;
            #endregion
        }

        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsProjectCostElement_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colsProjectCostElement_OnPM_DataItemZoom(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsProjectCostElement_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsProjectCostElement_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = true;
                return;
            }
            else if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                this.sArray[0] = "COMPANY";
                this.hWndArray[0] = this.colsCompany;
                this.sArray[1] = "PROJECT_COST_ELEMENT";
                this.hWndArray[1] = this.colsProjectCostElement;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("PROJECT_COST_ELEMENT", this, this.sArray, this.hWndArray);
                SessionNavigate(Pal.GetActiveInstanceName("tbwProjectCostElement"));
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsProjectCostElement_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colsProjectCostElement.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (Sal.IsNull(this.__colObjid))
                {
                    this.coldValidFrom.DateTime = SalDateTime.Current;
                    this.coldValidFrom.EditDataItemSetEdited();
                }
                else
                {
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
            }
            else
            {
                this.coldValidFrom.DateTime = Sys.DATETIME_Null;
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsAccount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colsAccount_OnPM_DataItemZoom(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsAccount_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsAccount_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.sItemName = this.GetItemName(this.colsAccount);
                if (this.colsCodePart.Text == "A")
                {
                    this.sFormName = Pal.GetActiveInstanceName("frmTabAccount");
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.colsCompany;
                    this.sItemNames[1] = "ACCOUNT";
                    this.hWndItems[1] = this.colsAccount;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Account", this, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("frmTabAccount"));

                    this.sItemName = SalString.Null;
                    e.Return = true;
                    return;
                }
                else
                {
                    this.bReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                    Sal.WaitCursor(false);
                    this.sItemName = SalString.Null;
                    e.Return = this.bReturn;
                    return;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsAccount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(this.colsAccount.Text == ""))
            {
                if (DbPLSQLBlock(cSessionManager.c_hSql,
                                @" BEGIN
                                   &AO.Accounting_Code_Part_Value_API.Exist( :i_hWndFrame.tbwCostEleToAccntSecmap.colsCompany IN, 
                                                                             :i_hWndFrame.tbwCostEleToAccntSecmap.colsCodePart IN, 
                                                                             :i_hWndFrame.tbwCostEleToAccntSecmap.colsAccount IN);
                                END;"))
                {
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
                else
                {
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }
        #endregion

        #region Event Handlers

        private void menuItem_CopyCRE_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = this.CopyCREToSecondaryMapping(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_CopyCRE_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            this.CopyCREToSecondaryMapping(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            this.ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Change_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            this.ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataRecordGetDefaults()
        {
            return this.DataRecordGetDefaults();
        }

        #endregion
    }
}
