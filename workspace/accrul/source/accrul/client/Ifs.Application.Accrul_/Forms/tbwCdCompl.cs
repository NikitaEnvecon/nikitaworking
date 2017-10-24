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
// 140619  Chwilk  Bug 117510, Modified tbwCdCompl_WindowActions().
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
    [FndWindowRegistration("ACCOUNTING_CODESTR_COMPL", "AccountCodestrCompl", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwCdCompl : cTableWindowFin
    {
        #region Window Variables
        public SalNumber nRetVal = 0;
        public SalString sTemp = "";
        public SalString sTemp2 = "";
        public SalString sTemp3 = "";
        public SalString lsTemp = "";
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalArray<SalString> sChanges = new SalArray<SalString>();
        public SalNumber nNumChanges = 0;
        public SalString sTemp4 = "";
        public SalString sTemp5 = "";
        public SalString sTempCodeFillCodePart = "";
        public SalString sTempCodePart = "";
        public SalBoolean bSaved = false;
        public SalBoolean bLovDefined = false;
        public SalString sAccount = "";
        public SalString sAcc = "";
        public SalString sAccountNo = "";
        public SalString sCodeFillAccount = "";
        public SalString sCodePartName = "";
        public SalString sDemandBlock = "";
        public SalArray<SalString> sItemNames = new SalArray<SalString>();
        public SalString sItemName1 = "";
        public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        public SalString sTempBlocked = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwCdCompl()
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
        public new static tbwCdCompl FromHandle(SalWindowHandle handle)
        {
            return ((tbwCdCompl)SalWindow.FromHandle(handle, typeof(tbwCdCompl)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        // Insert new code here...

       
        /// <summary>
        /// Gets client default values for NEW records
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataRecordGetDefaults()
        {
            #region Actions
            using (new SalContext(this))
            {
                colCompany.Text = i_sCompany;
                colCompany.EditDataItemSetEdited();

                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ValidateFillValue()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                sTemp = colCompany.Text;
                sTemp2 = colCodeFillCodePart.Text;
                sTemp3 = colCodefillValue.Text;
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Accounting_Code_Part_Value_API.Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Accounting_Code_Part_Value_API.Exist (\r\n" +
                        ":i_hWndFrame.tbwCdCompl.sTemp ,\r\n" +
                        ":i_hWndFrame.tbwCdCompl.sTemp2 ,\r\n" +
                        ":i_hWndFrame.tbwCdCompl.sTemp3  ) ")))
                    {
                        Sal.WaitCursor(false);
                        return false;
                    }
                }
                Sal.WaitCursor(false);
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetFillValueDesc()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                sTemp = colCompany.Text;
                sTemp2 = colCodeFillCodePart.Text;
                sTemp3 = colCodefillValue.Text;
                if (sTemp2 == "P")
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("ACCOUNT_PROCESS_CODE_API.GET_DESCRIPTION", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                            "	 	:i_hWndFrame.tbwCdCompl.lsTemp  :=\r\n" +
                            "	  	 &AO.ACCOUNT_PROCESS_CODE_API.GET_DESCRIPTION(\r\n" +
                            "                      	:i_hWndFrame.tbwCdCompl.sTemp, \r\n" +
                            "		:i_hWndFrame.tbwCdCompl.sTemp3  );\r\n	   END; ");
                    }
                }
                else
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("ACCOUNTING_CODE_PART_VALUE_API.Get_Desc_For_Code_Part", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                            "	 	 :i_hWndFrame.tbwCdCompl.lsTemp   :=\r\n" +
                            "	  	 &AO.ACCOUNTING_CODE_PART_VALUE_API.Get_Desc_For_Code_Part(\r\n" +
                            "       		:i_hWndFrame.tbwCdCompl.sTemp, \r\n" +
                            "       		:i_hWndFrame.tbwCdCompl.sTemp2,\r\n" +
                            "       		:i_hWndFrame.tbwCdCompl.sTemp3 );\r\n	   END; ");
                    }
                }
                colCodefillValueName.Text = lsTemp;
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
                return Ifs.Application.Accrul.Properties.Resources.WH_OverViewCdCompl;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="bRefreshAccount"></param>
        /// <returns></returns>
        public virtual SalNumber RefreshDemandTrap(SalBoolean bRefreshAccount)
        {
            #region Local Variables
            SalNumber nIndex = 0;
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nRow = Sal.TblQueryContext(i_hWndSelf);
                // Set stop indicator (so we don't process more rows than neccessary )
                Sal.TblSetRowFlags(i_hWndSelf, DataSourceRecordsInMemoryCount(), Sys.ROW_UnusedFlag2, true);
                // Process all EDITED records in the table window
                nIndex = Sys.TBL_MinRow;
                while (true)
                {
                    // Find row that is either edited or stop indicator
                    if (Sal.TblFindNextRow(i_hWndSelf, ref nIndex, 0, 0))
                    {
                        // Save row if edited and not deleted
                        Sal.TblSetContext(i_hWndSelf, nIndex);
                        if ((sAccountNo == colCodePartValue.Text) && (bRefreshAccount == true))
                        {
                            if ((colCodePartValue.Text != "A") && (colCodeFillCodePart.Text != "A"))
                            {
                                if (!(AmIDemanded(colCodeFillCodePart.Text)) && !(Sal.IsNull(colCodefillValue)))
                                {
                                    Sal.ClearField(colCodefillValue);
                                    Sal.ClearField(colCodefillValueName);
                                    Sal.SetFieldEdit(colCodefillValue, true);
                                }
                                if (!(AmIDemanded(colCodeFillCodePart.Text)))
                                {
                                    colCdPartBlocked.Text = "S";
                                }
                                else
                                {
                                    colCdPartBlocked.Text = "O";
                                }
                            }
                        }
                        else if ((sAccountNo == colCodePartValue.Text) && (bRefreshAccount == false))
                        {
                            if (!(AmIDemanded(colCodeFillCodePart.Text)) && !(Sal.IsNull(colCodeFillCodePart)))
                            {
                                if (!(Sal.IsNull(colCodefillValue)))
                                {
                                    Sal.ClearField(colCodefillValue);
                                    Sal.ClearField(colCodefillValueName);
                                    Sal.SetFieldEdit(colCodefillValue, true);
                                }
                            }
                            if (!(AmIDemanded(colCodeFillCodePart.Text)))
                            {
                                colCdPartBlocked.Text = "S";
                            }
                            else
                            {
                                colCdPartBlocked.Text = "O";
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                    // Abort if we have reached beyond the maximum row in memory
                    if (Sal.TblQueryRowFlags(i_hWndSelf, nIndex, Sys.ROW_UnusedFlag2))
                    {
                        break;
                    }
                }
                Sal.TblSetContext(i_hWndSelf, nRow);
                return true;
            }
            #endregion
        }

        /// <summary>
        /// always put on the sDemandBlock  of the  table
        /// </summary>
        /// <param name="bPCheck"></param>
        /// <param name="sCodePartValue"></param>
        /// <param name="sAccCodeString"></param>
        /// <returns></returns>
        public virtual SalBoolean GetCodePartDemand(SalBoolean bPCheck, SalString sCodePartValue, SalString sAccCodeString)
        {
            #region Actions
            using (new SalContext(this))
            {
                // check wheter already exist code demand in sDemandBlock
                if (sAccCodeString == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    sAccount = sCodePartValue;
                    if (sAccount == Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        return true;
                    }
                    sTemp5 = sCodePartValue;
                    Sal.WaitCursor(true);
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Accounting_Code_Part_A_API.Get_Required_Code_Part", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Accounting_Code_Part_A_API.Get_Required_Code_Part(\r\n" +
                            ":i_hWndFrame.tbwCdCompl.sTemp4 ,\r\n" +
                            ":i_hWndFrame.tbwCdCompl.i_sCompany ,\r\n" +
                            ":i_hWndFrame.tbwCdCompl.sTemp5 ) "))
                        {

                            sDemandBlock = sTemp4;
                            Sal.WaitCursor(false);
                            return true;
                        }
                    }
                }
                else
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Accounting_Code_Part_A_API.Get_Required_Code_Part", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Accounting_Code_Part_A_API.Get_Required_Code_Part(\r\n" +
                            ":i_hWndFrame.tbwCdCompl.sTemp4 ,\r\n" +
                            ":i_hWndFrame.tbwCdCompl.i_sCompany ,'" + sAccCodeString + "' ) "))
                        {

                            sDemandBlock = sTemp4;
                            return true;
                        }
                    }
                }
                Sal.WaitCursor(false);
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public virtual SalBoolean AmIDemanded(SalString sCode)
        {
            #region Actions
            using (new SalContext(this))
            {
                // not 'S'
                if (((SalString)"ABCDEFGHIJ").Scan(sCode) != -1)
                {
                    return sDemandBlock.Mid(sDemandBlock.Scan("CODE_" + sCode) + 7, 1) != "S";
                }
                return sDemandBlock.Mid(sDemandBlock.Scan("PROCESS_CODE") + 13, 1) != "S";
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sCodePart"></param>
        /// <returns></returns>
        public virtual SalNumber GetAccountNumber(SalString sCodePart)
        {
            #region Local Variables
            SalNumber nIndex = 0;
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nRow = Sal.TblQueryContext(i_hWndSelf);
                // Set stop indicator (so we don't process more rows than neccessary )
                Sal.TblSetRowFlags(i_hWndSelf, DataSourceRecordsInMemoryCount(), Sys.ROW_UnusedFlag2, true);
                // Process all EDITED records in the table window
                nIndex = Sys.TBL_MinRow;
                while (true)
                {
                    // Find row that is either edited or stop indicator
                    if (Sal.TblFindNextRow(i_hWndSelf, ref nIndex, 0, 0))
                    {
                        // Save row if edited and not deleted
                        Sal.TblSetContext(i_hWndSelf, nIndex);
                        if ((sCodePart == colCodePartValue.Text) && (colCodeFillCodePart.Text == "A"))
                        {
                            sAcc = colCodefillValue.Text;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                    // Abort if we have reached beyond the maximum row in memory
                    if (Sal.TblQueryRowFlags(i_hWndSelf, nIndex, Sys.ROW_UnusedFlag2))
                    {
                        break;
                    }
                }
                Sal.TblSetContext(i_hWndSelf, nRow);
                return true;
            }
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
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tbwCdCompl_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tbwCdCompl_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.tbwCdCompl_OnPM_DataSourceSave(sender, e);
                    break;
                
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCdCompl_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((SalString.FromHandle(Sys.lParam) == "COMPANY") && (Sys.wParam != Vis.DT_Handle))
            {
                e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwCdCompl.i_sCompany").ToHandle();
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCdCompl_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.sTempCodeFillCodePart = this.colCodeFillCodePart.Text;
                this.sTempCodePart = this.colCodePart.Text;
                this.sTempBlocked = this.colCdPartBlocked.Text;
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
                {
                    Sal.SetFocus(Sys.hWndNULL);
                    this.bSaved = true;
                    e.Return = true;
                    return;
                }
                this.bSaved = false;
                e.Return = false;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodefillValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colCodefillValue_OnPM_DataItemValidate(sender, e);
                    break;

                case Sys.SAM_SetFocus:
                    this.colCodefillValue_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.WM_CHAR:
                    this.colCodefillValue_OnWM_CHAR(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.WM_PASTE:
                    this.colCodefillValue_OnWM_PASTE(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colCodefillValue_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodefillValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (Sal.IsNull(this.colCodefillValue.i_hWndSelf))
                {
                    this.colCodefillValueName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    if (this.colCodeFillCodePart.Text == "A")
                    {
                        this.sAccountNo = this.colCodePartValue.Text;
                        this.sCodeFillAccount = this.colCodefillValue.Text;
                        this.GetCodePartDemand(false, Ifs.Fnd.ApplicationForms.Const.strNULL, this.sCodeFillAccount);
                        this.RefreshDemandTrap(true);
                    }
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
                if (!(this.ValidateFillValue()))
                {
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
                else
                {
                    this.GetFillValueDesc();
                    if (this.colCodeFillCodePart.Text == "A")
                    {
                        this.sAccountNo = this.colCodePartValue.Text;
                        this.sCodeFillAccount = this.colCodefillValue.Text;
                        this.GetCodePartDemand(false, Ifs.Fnd.ApplicationForms.Const.strNULL, this.sCodeFillAccount);
                        this.RefreshDemandTrap(true);
                    }
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
            }
            else
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodefillValue_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (((bool)Sal.SendMsg(this.colCodefillValue.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, 0, 0)) && (this.colCodePart.Text != this.colCodeFillCodePart.Text))
            {
                if (((this.sCodePartName != this.colCodePartValue.Text) || (this.sCodePartName == Ifs.Fnd.ApplicationForms.Const.strNULL)) && (this.colCdPartBlocked.Text == Ifs.Fnd.ApplicationForms.Const.strNULL))
                {
                    this.sAccountNo = this.colCodePartValue.Text;
                    this.sCodePartName = this.colCodePartValue.Text;
                    this.GetAccountNumber(this.sCodePartName);
                    this.GetCodePartDemand(true, this.sCodePartName, this.sAcc);
                    if (this.sAcc == Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        this.RefreshDemandTrap(false);
                    }
                    else
                    {
                        this.RefreshDemandTrap(true);
                    }
                    this.sAcc = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    this.sCodePartName = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
                if (this.colCdPartBlocked.Text == "S")
                {
                    this.bLovDefined = false;
                    this.colCodefillValue.p_sLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
                else if (this.colCodeFillCodePart.Text == "P")
                {
                    this.bLovDefined = true;
                    this.colCodefillValue.p_sLovReference = "ACCOUNT_PROCESS_CODE(COMPANY)";
                }
                else if ((this.bSaved == true) && ((this.sTempCodeFillCodePart == this.sTempCodePart) || (this.sTempBlocked == "S")))
                {
                    this.bSaved = false;
                    this.bLovDefined = false;
                    this.colCodefillValue.p_sLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
                else
                {
                    this.bLovDefined = true;
                    this.colCodefillValue.p_sLovReference = "ACCOUNTING_CODE_PART_VALUE_LOV(COMPANY,CODEFILL_CODE_PART)";
                }
            }
            else
            {
                this.bLovDefined = false;
                this.colCodefillValue.p_sLovReference = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// WM_CHAR event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodefillValue_OnWM_CHAR(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam != Vis.VK_Tab)
            {
                if (!(Sal.SendMsg(this.colCodefillValue.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, 0, 0)))
                {
                    Sal.MessageBeep(0);
                    e.Return = false;
                    return;
                }
                else
                {
                    if ((this.colCodePart.Text == this.colCodeFillCodePart.Text) || (this.bLovDefined == false))
                    {
                        Sal.MessageBeep(0);
                        e.Return = false;
                        return;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// WM_PASTE event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodefillValue_OnWM_PASTE(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.SendMsg(this.colCodefillValue.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, 0, 0)) || ((this.colCodePart.Text == this.colCodeFillCodePart.Text) || (this.bLovDefined == false)))
            {
                Sal.MessageBeep(0);
                e.Return = false;
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodefillValue_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (this.colCodeFillCodePart.Text == "A")
                {
                    this.sItemName1 = this.GetItemName(this.colCodefillValue);
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.colCompany;
                    this.sItemNames[1] = "ACCOUNT";
                    this.hWndItems[1] = this.colCodefillValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Account", this, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwAccountOverview"));
                    e.Return = true;
                    return;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
            return;
            #endregion
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

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
       
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Actions
            using (new SalContext(this))
            {
                // Reset DataTransfer to get same execution flow as before when overriding FrameStartupUser and just return true
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                SetWindowTitle();
                return base.Activate(URL);
            }
            #endregion
        }
        #endregion

        #region Event Handlers

        private void menuItem__Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
           
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);

        }

        private void menuItem__Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        #endregion

    }
}
