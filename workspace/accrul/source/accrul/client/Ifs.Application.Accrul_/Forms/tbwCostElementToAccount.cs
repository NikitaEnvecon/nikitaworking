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
//  Date    By      Notes
//  ----    ------  -------------------------------------------------------------------------------------
//  110911  Umdolk  EASTTWO-12428, Added PM_DataRecordRemove. 
//  111213  Umdolk  SFI-1175, Merged flexCap changes. 
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
    [FndWindowRegistration("COST_ELEMENT_TO_ACCOUNT_ALL", "CostElementToAccount", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwCostElementToAccount : cTableWindowFin
    {
        #region Window Variables
        public SalString lsCommonAttr = "";
        public SalString lsInfoAttr = "";
        public SalString sObjid = "";
        public SalString sObjversion = "";
        public SalString sPackageName = "";
        public SalArray<SalString> sArray = new SalArray<SalString>();
        public SalArray<SalWindowHandle> hWndArray = new SalArray<SalWindowHandle>();
        public SalString sBaseForPFE = "";
        public SalString sCodePartName = "";
        public SalString sCompany = "";
        public SalString sAccount = "";
        public SalString sStmt = "";
        public SalArray<SalString> sItemCompanyValues = new SalArray<SalString>();
        public SalArray<SalString> sItemAccountValues = new SalArray<SalString>();
        public SalArray<SalString> sItemNames = new SalArray<SalString>();
        public SalString sFormName = "";
        public SalString sItemName1 = "";
        public SalBoolean bIsRecordPaste = false;
        public SalBoolean bIsRecordDuplicate = false;
        public SalBoolean bReturn = false;
        public SalBoolean bFromDT = false;
        public SalNumber nNewReturnValue = 0;
        public SalNumber nDuplicateReturnValue = 0;
        public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        public SalNumber nCurrentRow = 0;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwCostElementToAccount()
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
        public new static tbwCostElementToAccount FromHandle(SalWindowHandle handle)
        {
            return ((tbwCostElementToAccount)SalWindow.FromHandle(handle, typeof(tbwCostElementToAccount)));
        }
        #endregion

        #region Methods

        

        // MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,Start
        /// <summary>
        /// </summary>
        /// <returns>
        /// Applications should return FALSE to skip standard window startup logic (such
        /// as exectuing the "startup behavior" settings), or TRUE to allow standard logic.
        /// </returns>
        // Insert new code here...
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    bFromDT = true;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("COMPANY", sItemCompanyValues);
                    sCompany = sItemCompanyValues[0];
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("ACCOUNT", sItemAccountValues);
                    sAccount = sItemAccountValues[0];
                    GetBaseForPFE();
                    GetBaseCodePartName();
                    if (sCodePartName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        Sal.TblSetColumnTitle(this.colsAccount, sCodePartName);
                    }
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    sStmt = " account = '" + sAccount + "'  AND code_part  = '" + sBaseForPFE + "'";
                    Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sStmt.ToHandle());
                    Sal.WaitCursor(false);
                    Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    // After the populate we need to reset the User Where for the next pupulate
                    DataSourceUserWhere(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ("code_part = '" + sBaseForPFE + "'").ToHandle());
                    return false;
                }
                else
                {
                    bFromDT = false;
                    UserGlobalValueGet("COMPANY", ref sCompany);
                    GetBaseForPFE();
                    GetBaseCodePartName();
                    DataSourceUserWhere(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ("code_part = '" + sBaseForPFE + "'").ToHandle());
                    if (sCodePartName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        Sal.TblSetColumnTitle(this.colsAccount, sCodePartName);

                    }
                }
            }
            return base.Activate(URL);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetBaseForPFE()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Accounting_Code_Parts_API.Get_Base_For_Followup_Element", System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.tbwCostElementToAccount.sBaseForPFE:= &AO.Accounting_Code_Parts_API.Get_Base_For_Followup_Element(\r\n" +
                        "	      :i_hWndFrame.tbwCostElementToAccount.sCompany)");
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetBaseCodePartName()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Accounting_Code_Parts_API.Get_Name", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.tbwCostElementToAccount.sCodePartName := &AO.Accounting_Code_Parts_API.Get_Name(\r\n" +
                        "	      :i_hWndFrame.tbwCostElementToAccount.sCompany,\r\n" +
                        "                      :i_hWndFrame.tbwCostElementToAccount.sBaseForPFE)");
                }
            }

            return 0;
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
        // MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,End
        /// <summary>
        /// The DataRecordExecuteModify function performs server update of
        /// modified records.
        /// COMMENTS:
        /// DataRecordExecuteModify is called once for each modified record by the
        /// DataSourceExecuteSqlUpdate function during the save process.
        /// </summary>
        /// <param name="hSql"></param>
        /// <returns></returns>
        public new SalBoolean DataRecordExecuteModify(SalSqlHandle hSql)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (Sal.IsNull(__colObjid) && (!(Sal.IsNull(colsProjectCostElement))) && (!(Sal.IsNull(coldValidFrom))))
                {
                    // -----------New: Cost Element Connection------------------
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("New: Cost Element  Connection");
                    lsInfoAttr = SalString.Null;
                    lsCommonAttr = SalString.Null;
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COMPANY", colsCompany.Text, ref lsCommonAttr);
                    // MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,Start
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAddDate("VALID_FROM", coldValidFrom.DateTime, ref lsCommonAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("CODE_PART", colsCodePart.Text, ref lsCommonAttr);
                    // MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,End
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ACCOUNT", colsAccount.Text, ref lsCommonAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("PROJECT_COST_ELEMENT", colsProjectCostElement.Text, ref lsCommonAttr);
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add(p_sPackageName + ".NEW__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
                        if (DbPLSQLBlock(hSql, p_sPackageName + ".NEW__(\r\n" +
                            "	:i_hWndFrame.tbwCostElementToAccount.lsInfoAttr,\r\n" +
                            "	:i_hWndFrame.tbwCostElementToAccount.sObjid,\r\n" +
                            "	:i_hWndFrame.tbwCostElementToAccount.sObjversion,\r\n" +
                            "	:i_hWndFrame.tbwCostElementToAccount.lsCommonAttr,\r\n	'DO' )"))
                        {
                            if (HandleSqlResult(lsInfoAttr))
                            {
                                Sal.SetWindowText(__colObjid, sObjid);
                                __lsObjversion = sObjversion;
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
                }
                // MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,Start
                else if ((!(Sal.IsNull(__colObjid))) && (!(Sal.IsNull(colsProjectCostElement))) && (!(Sal.IsNull(coldValidFrom))))
                {
                    // -----------Modify: Attribute Connection------------------
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("Modify: Attribute Connection");
                    return ((cDataSource)this).DataRecordExecuteModify(hSql);
                }
                // MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,End
                else if ((!(Sal.IsNull(__colObjid))) && Sal.IsNull(colsProjectCostElement))
                {
                    // -----------Remove: Attribute Connection------------------
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("Remove: Attribute Connection");
                    lsInfoAttr = SalString.Null;
                    sObjid = __colObjid.Text;
                    sObjversion = __colObjversion.Text;
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add(p_sPackageName + ".REMOVE__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (DbPLSQLBlock(hSql, p_sPackageName + ".REMOVE__(\r\n" +
                            "	:i_hWndFrame.tbwCostElementToAccount.lsInfoAttr,\r\n" +
                            "	:i_hWndFrame.tbwCostElementToAccount.sObjid,\r\n" +
                            "	:i_hWndFrame.tbwCostElementToAccount.sObjversion,\r\n	'DO' )"))
                        {
                            if (HandleSqlResult(lsInfoAttr))
                            {
                                Sal.ClearField(__colObjid);
                                __lsObjversion = SalString.Null;
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
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetEditable()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.TblSetColumnFlags(colsCompany, Sys.COL_Editable, true);
                Sal.TblSetColumnFlags(colsAccount, Sys.COL_Editable, true);
                Sal.TblSetColumnFlags(colsAccountDescription, Sys.COL_Editable, true);
                Sal.TblSetColumnFlags(colsProjectCostElementDesc, Sys.COL_Editable, true);
                Sal.TblSetColumnFlags(colsCodePart, Sys.COL_Editable, true);
                // Call SalTblSetColumnFlags( coldValidFrom, COL_Editable, TRUE )
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetEditableFalse()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.TblSetColumnFlags(colsCompany, Sys.COL_Editable, false);
                Sal.TblSetColumnFlags(colsAccount, Sys.COL_Editable, false);
                Sal.TblSetColumnFlags(colsAccountDescription, Sys.COL_Editable, false);
                Sal.TblSetColumnFlags(colsProjectCostElementDesc, Sys.COL_Editable, false);
                Sal.TblSetColumnFlags(colsCodePart, Sys.COL_Editable, false);
                // Call SalTblSetColumnFlags( coldValidFrom, COL_Editable, FALSE )
            }

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
        private void tbwCostElementToAccount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,Start

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tbwCostElementToAccount_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.tbwCostElementToAccount_OnPM_DataRecordDuplicate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere:
                    this.tbwCostElementToAccount_OnPM_DataSourceUserWhere(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.tbwCostElementToAccount_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged:
                    this.tbwCostElementToAccount_OnPM_UserProfileChanged(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tbwCostElementToAccount_OnPM_DataRecordRemove(sender, e);
                    break;

                // MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,End

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceHitCount:
                    this.tbwCostElementToAccount_OnPM_DataSourceHitCount(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCostElementToAccount_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = false;
                return;
            }
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (!(this.bIsRecordDuplicate))
                {
                    e.Return = false;
                    return;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCostElementToAccount_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("COST_ELEMENT_TO_ACCOUNT_API.New__");
                return;
            }
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.bIsRecordDuplicate = true;
                this.SetEditable();
            }
            this.nDuplicateReturnValue = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
            this.SetEditableFalse();
            e.Return = this.nDuplicateReturnValue;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCostElementToAccount_OnPM_DataSourceUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (this.i_lsUserWhere == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    this.i_lsUserWhere = "  code_part = '" + this.sBaseForPFE + "'";
                }
                else
                {
                    this.i_lsUserWhere = this.i_lsUserWhere + " AND code_part = '" + this.sBaseForPFE + "'";
                }
            }
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCostElementToAccount_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.bFromDT)
            {
                this.bFromDT = false;
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
                return;
            }
            else
            {
                Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.DataSourceUserWhere(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ("code_part = '" + this.sBaseForPFE + "'").ToHandle());
                }
                e.Return = true;
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_UserProfileChanged event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCostElementToAccount_OnPM_UserProfileChanged(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged, Sys.wParam, Sys.lParam))
            {
                this.UserGlobalValueGet("COMPANY", ref this.sCompany);
                this.GetBaseForPFE();
                this.GetBaseCodePartName();
                if (this.sCodePartName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    this.DataSourceUserWhere(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ("code_part = '" + this.sBaseForPFE + "'").ToHandle());
                    Sal.TblSetColumnTitle(this.colsAccount, this.sCodePartName);
                    e.Return = true;
                    return;
                }
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
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCostElementToAccount_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (Sal.TblAnyRows(this.i_hWndFrame, Sys.ROW_Selected,0))
                {
                    this.nCurrentRow = Sys.TBL_MinRow;
                    while (Sal.TblFindNextRow(this.i_hWndSelf, ref this.nCurrentRow, Sys.ROW_Selected, 0))
                    {
                        Sal.TblSetContext(this.i_hWndSelf, this.nCurrentRow);
                        if (this.colsProjectCostElement.Text == Sys.STRING_Null)
                        {
                            e.Return = false;
                            return;
                        }
                    }                
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
                    return;
                }
                else
                {
                    e.Return = false;
                    return;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceHitCount event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCostElementToAccount_OnPM_DataSourceHitCount(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            { 
                if ( Sal.NumberToHString(Sys.lParam) == Sys.STRING_Null )
                {
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceHitCount,  Sys.wParam, Sal.HStringToNumber( "CODE_PART = '" + sBaseForPFE + "'" ));                       
                    return;
                }
                else
                {
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceHitCount, Sys.wParam, Sal.HStringToNumber(Sal.NumberToHString(Sys.lParam) + " AND CODE_PART = '" + sBaseForPFE + "'"));
                    return;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceHitCount, Sys.wParam, Sys.lParam);        
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
                // MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,Start

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colsAccount_OnPM_DataItemZoom(sender, e);
                    break;

                // MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,End
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
                this.sItemName1 = this.GetItemName(this.colsAccount);
                if (this.colsCodePart.Text == "A")
                {
                    this.sFormName = Pal.GetActiveInstanceName("frmTabAccount");
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.colsCompany;
                    this.sItemNames[1] = "ACCOUNT";
                    this.hWndItems[1] = this.colsAccount;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Account", this, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("frmTabAccount"));

                    this.sItemName1 = SalString.Null;
                    e.Return = true;
                    return;
                }
                else
                {
                    this.bReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                    Sal.WaitCursor(false);
                    this.sItemName1 = SalString.Null;
                    e.Return = this.bReturn;
                    return;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

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

                // MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,Start

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsProjectCostElement_OnPM_DataItemValidate(sender, e);
                    break;

                // MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,End
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
                // Bug Id 86293, Begin
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                this.sArray[0] = "COMPANY";
                this.hWndArray[0] = this.colsCompany;
                this.sArray[1] = "PROJECT_COST_ELEMENT";
                this.hWndArray[1] = this.colsProjectCostElement;
                // Bug Id 86293, End
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
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataRecordExecuteModify(SalSqlHandle hSql)
        {
            return this.DataRecordExecuteModify(hSql);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        // Insert new code here...

        
        #endregion

        #region Event Handlers

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
           
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        private void menuItem_Secondary_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = true;
        }

        private void menuItem_Secondary_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            SessionNavigate(Pal.GetActiveInstanceName("tbwCostEleToAccntSecmap"));
        }
        #endregion
    }
}
