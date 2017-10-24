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
    [FndWindowRegistration("POSTING_CTRL_MASTER", "PostingCtrl", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwPostingCtrl : cTableWindowFin
    {
        #region Window Variables
        public SalString sCompanyName = "";
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalArray<SalString> sChanges = new SalArray<SalString>();
        public SalString sID = "";
        public SalNumber nNumChanges = 0;
        public SalString sModule = "";
        public SalString sLedgFlag = "";
        public SalString sTaxFlag = "";
        public SalString sControlType = "";
        public SalString dbControlType = "";
        public SalString sTempLovReference = "";
        public SalNumber nControlFlag = 0;
        public SalNumber nNum = 0;
        public SalNumber nRow = 0;
        public SalNumber nDeletedRows = 0;
        public SalNumber nSelectedRow = 0;
        public SalArray<SalString> sRecords = new SalArray<SalString>();
        public SalArray<SalString> sUnits = new SalArray<SalString>();
        public SalString sCtrlTypeCategory = "";
        public SalString sControlTypeDesc = "";
        public SalString sMessageParam = "";
        public SalBoolean bForCordPartA = false;
        public SalBoolean bParentNavigator = false;
        public SalDateTime dPCStartDate = SalDateTime.Null;
        public SalDateTime dPCEndDate = SalDateTime.Null;
        public SalDateTime dStartDate = SalDateTime.Null;
        public SalDateTime dEndDate = SalDateTime.Null;
        public SalBoolean bCancelPressed = false;
        public SalString sOldCompanyName = "";
        public SalWindowHandle hWndCol = SalWindowHandle.Null;
        public SalBoolean bIsRecordPaste = false;
        public SalNumber nNewReturnValue = 0;
        public SalNumber nPasteReturnValue = 0;
        public SalNumber nDuplicateReturnValue = 0;
        public SalBoolean bIsRecordDuplicate = false;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwPostingCtrl()
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
        public new static tbwPostingCtrl FromHandle(SalWindowHandle handle)
        {
            return ((tbwPostingCtrl)SalWindow.FromHandle(handle, typeof(tbwPostingCtrl)));
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
                return Properties.Resources.WH_tbwPostingCtrl;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean RightMouseClick(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            SalNumber nRow = 0;
            SalString sPrevControlType = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Posting_Ctrl_Control_Type_API.Get_Control_Type_Info__")))
                        {
                            return false;
                        }
                        if (Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam))
                        {
                            return false;
                        }
                        nRow = Sys.TBL_MinRow;
                        if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0))
                        {
                            Sal.TblSetContext(i_hWndSelf, nRow);
                            sPrevControlType = colControlType.Text;
                            while (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0))
                            {
                                Sal.TblSetContext(i_hWndSelf, nRow);
                                if (colControlType.Text != sPrevControlType)
                                {
                                    return false;
                                }
                            }
                            if ((colsCtrlTypeCategoryDb.Text == "FIXED") || (colsCtrlTypeCategoryDb.Text == "PREPOSTING"))
                            {
                                return false;
                            }
                            if (colsCtrlTypeCategoryDb.Text == "COMBINATION")
                            {
                                return Sal.TblAnyRows(i_hWndSelf, Sys.ROW_Selected, 0) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmPostingCtrlCombDet"));
                            }
                            else if (colsCtrlTypeCategoryDb.Text != Sys.STRING_Null)
                            {
                                return Sal.TblAnyRows(i_hWndSelf, Sys.ROW_Selected, 0) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmPostCtrlDet"));
                            }
                            return true;
                        }
                        return false;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        if (colsCtrlTypeCategoryDb.Text == "COMBINATION")
                        {
                            sItemNames[0] = "POSTING_TYPE";
                            hWndItems[0] = colPostingType;
                            sItemNames[1] = "CODE_PART";
                            hWndItems[1] = colsCodePart;
                            sItemNames[2] = "MODULE";
                            hWndItems[2] = colModule;
                            sItemNames[3] = "CONTROL_TYPE";
                            hWndItems[3] = colControlType;
                            sItemNames[4] = "COMPANY";
                            hWndItems[4] = colsCompany;
                            sItemNames[5] = "PC_VALID_FROM";
                            hWndItems[5] = coldPcValidFrom;
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("CombControlType", this, sItemNames, hWndItems);
                            SessionCreateWindow(Pal.GetActiveInstanceName("frmPostingCtrlCombDet"), Sys.hWndMDI);
                            Sal.WaitCursor(false);
                        }
                        else
                        {
                            sItemNames[0] = "POSTING_TYPE";
                            hWndItems[0] = colPostingType;
                            sItemNames[1] = "CODE_PART";
                            hWndItems[1] = colsCodePart;
                            sItemNames[2] = "MODULE";
                            hWndItems[2] = colModule;
                            sItemNames[3] = "PC_VALID_FROM";
                            hWndItems[3] = coldPcValidFrom;
                            // Bug 75985, Begin
                            sItemNames[4] = "CONTROL_TYPE";
                            hWndItems[4] = colControlType;
                            // Bug 75985, End
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("PostingType", this, sItemNames, hWndItems);
                            SessionCreateWindow(Pal.GetActiveInstanceName("frmPostCtrlDet"), Sys.hWndMDI);
                            Sal.WaitCursor(false);
                        }
                        break;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean CopyDetails(SalNumber nWhat)
        {
            #region Local Variables
            SalNumber nRow = 0;
            SalNumber nRet = 0;
            SalWindowHandle hWndNav = SalWindowHandle.Null;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        // Bug 75103, Begin. The Security check is done for Copy_Details_Set_Up procedure.
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Posting_Ctrl_API.Copy_Details_Set_Up")))
                        {
                            return false;
                        }
                        // Bug 75103, End.
                        if (Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam))
                        {
                            return false;
                        }
                        nRow = Sys.TBL_MinRow;
                        if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0))
                        {
                            if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                        if (colsCtrlTypeCategoryDb.Text == "COMBINATION")
                        {
                            return false;
                        }
                        // New rows have null
                        if (colsExistCombInDetail.Text == Sys.STRING_Null)
                        {
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("Posting_Ctrl_API.Exist_Comb_In_Detail", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.tbwPostingCtrl.colsExistCombInDetail :=" + cSessionManager.c_sDbPrefix + "Posting_Ctrl_API.Exist_Comb_In_Detail(	:i_hWndFrame.tbwPostingCtrl.colsCompany, \r\n" +
                                    "					:i_hWndFrame.tbwPostingCtrl.colPostingType, \r\n" +
                                    "					:i_hWndFrame.tbwPostingCtrl.colsCodePart, \r\n" +
                                    "					:i_hWndFrame.tbwPostingCtrl.coldPcValidFrom)");
                            }
                        }
                        if (colsExistCombInDetail.Text == "TRUE")
                        {
                            return false;
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        nRet = dlgPostingCtrlCopyDetails.ModalDialog(i_hWndSelf, colsCompany.Text, colPostingType.Text, colPostingTypeDesc.Text, colsCodePart.Text, colsCodeName.Text, colControlType.Text, colControlTypeDesc.Text, colPostModule.Text, coldPcValidFrom.DateTime);
                        if (bParentNavigator && nRet == Sys.IDOK)
                        {
                            // Refresh nodes in Posting Ctrl Navigator part
                            hWndNav = Sal.ParentWindow(this);
                            frmPostCtrlNavigator.FromHandle(hWndNav).tlbTree.TreeListNodeRefresh(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, frmPostCtrlNavigator.FromHandle(hWndNav).nRootNode, false);
                            return true;
                        }
                        break;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// for Call ID 78662
        /// </summary>
        /// <param name="nWhat">
        /// Standard method parameter
        /// Standard method parameter. Possible values are METHOD_Inquire, METHOD_Execute.
        /// </param>
        /// <param name="sMessage">
        /// Window name
        /// Name of window to create.
        /// </param>
        /// <returns></returns>
        public new SalBoolean DataSourceCreateWindowTrans(SalNumber nWhat, SalString sMessage)
        {
            #region Local Variables
            SalBoolean bOk = false;
            cMessage mParams = new cMessage();
            SalArray<SalString> sNames = new SalArray<SalString>();
            SalString sKey = "";
            SalArray<SalString> sValues = new SalArray<SalString>();
            SalNumber nItems = 0;
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            SalNumber i = 0;
            SalNumber nKeyItem = 0;
            SalNumber nIndex = 0;
            SalString sWindowName = "";
            SalString sTransferType = "";
            SalString sDestination = "";
            SalBoolean bNoTransfer = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        mParams.Unpack(sMessage);
                        sWindowName = mParams.GetAttribute("__NAME");
                        return Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(sWindowName) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(sWindowName);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        sMessageParam = sMessage;
                        Sal.WaitCursor(true);
                        if (bForCordPartA)
                        {
                            // Call Only for code part account
                            sTransferType = "CREATE_WINDOW";
                            mParams.Unpack(sMessage);
                            nItems = mParams.EnumAttributes(sNames, sValues);
                            while (i < nItems)
                            {
                                if (sNames[i] == "__NAME")
                                {
                                    sWindowName = sValues[i];
                                }
                                else if (sNames[i] == "__TYPE")
                                {
                                    sTransferType = sValues[i];
                                }
                                else if (sNames[i] == "__DESTINATION")
                                {
                                    sDestination = sValues[i];
                                }
                                else if (sNames[i] == "__NOTRANSFER")
                                {
                                    bNoTransfer = true;
                                }
                                else
                                {
                                    // Add DbPrefix if the column to find is a function call.
                                    sKey = sNames[i];
                                    _AddDbPrefixToPackageCall(ref sKey);
                                    nIndex = Vis.ArrayFindString(__sColumnName, sKey);
                                    if (nIndex >= 0)
                                    {
                                        sItemNames[nKeyItem] = sValues[i];
                                        hWndItems[nKeyItem] = i_hWndChild[nIndex];
                                        nKeyItem = nKeyItem + 1;
                                    }
                                }
                                i = i + 1;
                                sItemNames[0] = "ACCOUNT";
                            }
                            if (!(bNoTransfer))
                            {
                                // Init data transfer with all items
                                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(p_sLogicalUnit, i_hWndSelf, sItemNames, hWndItems);
                                Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet(sTransferType);
                                Ifs.Fnd.ApplicationForms.Var.DataTransfer._DestinationSet(sDestination);
                            }
                            // Create the window
                            bOk = SessionCreateWindow(sWindowName, Sys.hWndMDI) != Sys.hWndNULL;
                            return bOk;
                        }
                        else
                        {
                            // Call for others just continue the normal way
                            ((cTableWindowFin)this).DataSourceCreateWindowTrans(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sMessageParam);
                        }
                        break;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// Called from Posting Control Navigator
        /// </summary>
        /// <param name="sWhere"></param>
        /// <param name="dValidFrom"></param>
        /// <param name="dPCValidFrom"></param>
        /// <returns></returns>
        public virtual SalNumber SetWhere(SalString sWhere, SalDateTime dValidFrom, SalDateTime dPCValidFrom)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (dValidFrom != SalDateTime.Null)
                {
                    Int.PalDateGetDayInterval(dValidFrom, ref dStartDate, ref dEndDate);
                    sWhere = sWhere + " AND (VALID_FROM between :i_hWndFrame.tbwPostingCtrl.dStartDate AND :i_hWndFrame.tbwPostingCtrl.dEndDate) ";
                }
                if (dPCValidFrom != SalDateTime.Null)
                {
                    Int.PalDateGetDayInterval(dPCValidFrom, ref dPCStartDate, ref dPCEndDate);
                    sWhere = sWhere + " AND (PC_VALID_FROM between :i_hWndFrame.tbwPostingCtrl.dPCStartDate AND :i_hWndFrame.tbwPostingCtrl.dPCEndDate) ";
                }
                p_lsDefaultWhere = sWhere;
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// Call from Posting Control Navigator
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetParentNavigator()
        {
            #region Actions
            using (new SalContext(this))
            {
                bParentNavigator = true;
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetCodePart()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (Sal.IsNull(colsCodePart) && !(Sal.IsNull(colsCodeName)))
                {
                    if (DbPLSQLBlock(cSessionManager.c_hSql, "&AO.ACCOUNTING_CODE_PARTS_API.Get_Code_Part(\r\n" +
                            "                                 :i_hWndFrame.tbwPostingCtrl.colsCodePart OUT,\r\n" +
                            "                                 :i_hWndFrame.tbwPostingCtrl.colsCompany IN,\r\n" +
                            "                                 :i_hWndFrame.tbwPostingCtrl.colsCodeName IN) "))
                    {
                        if (!(Sal.IsNull(colsCodePart)))
                        {
                            colsCodePart.EditDataItemSetEdited();
                        }
                    }                                    
                 }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sSheet"></param>
        /// <param name="sProfileName"></param>
        /// <param name="sProfileSection"></param>
        /// <returns></returns>
        public new SalNumber PSheetApplyChanges(SalString sSheet, SalString sProfileName, SalString sProfileSection)
        {
            #region Actions
            using (new SalContext(this))
            {
                ((cTableWindowFin)this).PSheetApplyChanges(sSheet, sProfileName, sProfileSection);
                if (sSheet == "dlgPSheetUserGlobals")
                {
                    bCancelPressed = false;
                }
                else
                {
                    bCancelPressed = true;
                }
            }

            return 0;
            #endregion
        }
        // Bug 71046, Begin
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalNumber DataRecordQueryDialog()
        {
            #region Actions
            using (new SalContext(this))
            {
                colControlType.p_sLovReference = "POSTING_CTRL_CONTROL_TYPE";
                return ((cDataSource)this).DataRecordQueryDialog();
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
        private void tbwPostingCtrl_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tbwPostingCtrl_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.tbwPostingCtrl_OnPM_DataSourceSave(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tbwPostingCtrl_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    this.tbwPostingCtrl_OnPM_DataRecordPaste(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.tbwPostingCtrl_OnPM_DataRecordDuplicate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwPostingCtrl_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (SalString.FromHandle(Sys.lParam) == "COMPANY")
            {
                switch (Sys.wParam)
                {
                    case Vis.DT_Handle:
                        e.Return = SalWindowHandle.Null.ToNumber();
                        return;

                    default:
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwPostingCtrl.i_sCompany").ToHandle();
                        return;
                }
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
        private void tbwPostingCtrl_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                // Don't refresh the form if called from Posting Ctrl Navigator
                if (this.bParentNavigator)
                {
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    return;
                }

                Sal.TblQueryFocus(this.i_hWndSelf, ref this.nSelectedRow, ref this.hWndCol);
                this.nRow = Sys.TBL_MinRow;
                this.nDeletedRows = 0;
                while (true)
                {
                    if (Sal.TblFindNextRow(this.i_hWndSelf, ref this.nRow, Sys.ROW_MarkDeleted, 0) && (this.nRow <= this.nSelectedRow))
                    {
                        this.nDeletedRows = this.nDeletedRows + 1;
                    }
                    else
                    {
                        break;
                    }
                }
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
                {
                    e.Return = true;
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    return;
                }
                else
                {
                    e.Return = false;
                    return;
                }
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwPostingCtrl_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nNewReturnValue = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if ((!(this.bIsRecordPaste)) && (!(this.bIsRecordDuplicate)))
                {
                    this.coldPcValidFrom.DateTime = SalDateTime.Current;
                    this.coldPcValidFrom.EditDataItemSetEdited();
                }
            }
            e.Return = this.nNewReturnValue;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordPaste event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwPostingCtrl_OnPM_DataRecordPaste(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.bIsRecordPaste = true;
            }
            this.nPasteReturnValue = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.bIsRecordPaste = false;
            }
            e.Return = this.nPasteReturnValue;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwPostingCtrl_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.bIsRecordDuplicate = true;
            }
            this.nDuplicateReturnValue = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.bIsRecordDuplicate = false;
            }
            e.Return = this.nDuplicateReturnValue;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colPostingType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colPostingType_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserOrderBy:
                    e.Handled = true;
                    e.Return = ((SalString)"MODULE,SORT_ORDER").ToHandle();
                    return;

                case Sys.SAM_AnyEdit:
                    this.colPostingType_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colPostingType_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.colPostingType)))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Posting_Ctrl_Posting_Type_API.Get_Module", System.Data.ParameterDirection.Input);
                    this.colPostingType.DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.tbwPostingCtrl.colModule :=" + cSessionManager.c_sDbPrefix + "Posting_Ctrl_Posting_Type_API.Get_Module(\r\n" +
                        ":i_hWndFrame.tbwPostingCtrl.colPostingType)");
                }
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Posting_Ctrl_Posting_Type_API.Get_Posting_Type_Attri_", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input);
                    if (!(this.colPostingType.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Posting_Ctrl_Posting_Type_API.Get_Posting_Type_Attri_(\r\n" +
                        "   :i_hWndFrame.tbwPostingCtrl.colPostingTypeDesc,\r\n" +
                        "   :i_hWndFrame.tbwPostingCtrl.colPostModule,\r\n" +
                        "   :i_hWndFrame.tbwPostingCtrl.sLedgFlag,\r\n" +
                        "   :i_hWndFrame.tbwPostingCtrl.sTaxFlag,\r\n" +
                        "   :i_hWndFrame.tbwPostingCtrl.colPostingType)")))
                    {
                        e.Return = false;
                        return;
                    }
                }
                if (!(Sal.IsNull(this.colPostModule)))
                {
                    this.colPostModule.EditDataItemSetEdited();
                }
                // Bug 91651, Begin, Modified the IF Condition
                if (!(Sal.IsNull(this.colsCodeName)))
                {
                    Sal.SendMsg(this.colsCodeName, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                }
                // Bug 91651, End
            }
            else
            {
                this.colPostingTypeDesc.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colPostingType_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.bIsRecordPaste == true || this.bIsRecordDuplicate == true)
            {
                Sal.SendMsg(this.colPostingType.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsCodeName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsCodeName_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserOrderBy:
                    e.Handled = true;
                    e.Return = ((SalString)"CODE_PART").ToHandle();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeName_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.colsCodeName)))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("ACCOUNTING_CODE_PARTS_API.Get_Code_Part", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(this.colsCodeName.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "ACCOUNTING_CODE_PARTS_API.Get_Code_Part(" + " :i_hWndFrame.tbwPostingCtrl.colsCodePart," + " :i_hWndFrame.tbwPostingCtrl.colsCompany," + " :i_hWndFrame.tbwPostingCtrl.colsCodeName) ")))
                    {
                        e.Return = false;
                        return;
                    }
                }
                if (!(Sal.IsNull(this.colsCodePart)))
                {
                    this.colsCodePart.EditDataItemSetEdited();
                }
                if (!(Sal.IsNull(this.colControlType)))
                {
                    Sal.SendMsg(this.colControlType, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colControlType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colControlType_OnPM_DataItemValidate(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    this.colControlType_OnSAM_AnyEdit(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.colControlType_OnPM_DataItemLovDone(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.colControlType_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov:
                    this.colControlType_OnPM_DataItemLov(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colControlType_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.GetCodePart();
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("CTRL_TYPE_ALLOWED_VALUE_API.Get_Allowed_Info__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                if (this.colControlType.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "CTRL_TYPE_ALLOWED_VALUE_API.Get_Allowed_Info__(\r\n" +
                    "     :i_hWndFrame.tbwPostingCtrl.sModule,\r\n" +
                    "     :i_hWndFrame.tbwPostingCtrl.sCtrlTypeCategory,\r\n" +
                    "     :i_hWndFrame.tbwPostingCtrl.colsCtrlTypeCategoryDb,\r\n" +
                    "     :i_hWndFrame.tbwPostingCtrl.sControlTypeDesc,\r\n" +
                    "     :i_hWndFrame.tbwPostingCtrl.colsCompany,\r\n" +
                    "     :i_hWndFrame.tbwPostingCtrl.colsCodePart,\r\n" +
                    "     :i_hWndFrame.tbwPostingCtrl.colPostingType,\r\n" +
                    "     :i_hWndFrame.tbwPostingCtrl.colControlType,\r\n" +
                    "     :i_hWndFrame.tbwPostingCtrl.colsCtrlTypeCategory)"))
                {
                    this.colModule.Text = this.sModule;
                    if (this.sCtrlTypeCategory != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        this.colsCtrlTypeCategory.Text = this.sCtrlTypeCategory;
                        this.colsCtrlTypeCategory.EditDataItemSetEdited();
                    }
                    if (!(Sal.IsNull(this.colControlType) || (((SalString)this.colControlType.Text).ToUpper() == Ifs.Fnd.ApplicationForms.Var.__g_Property.sDataSourceValueOnNew.ToUpper())))
                    {
                        if (this.sModule == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_LuName, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                            e.Return = false;
                            return;
                        }
                    }
                    this.colModule.EditDataItemSetEdited();
                    if (this.sControlTypeDesc != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        this.colControlTypeDesc.Text = this.sControlTypeDesc;
                    }
                    else
                    {
                        // Bug 82933 Begin, Removed IP:Hints.Ignore and modified the db call to make it unambigious to the porting tool.
                        using (SignatureHints hints1 = SignatureHints.NewContext())
                        {
                            hints1.Add("Posting_Ctrl_Control_Type_API.Get_Description", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            if (!(this.colControlType.DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Posting_Ctrl_Control_Type_API.Get_Description(\r\n" +
                                "				:i_hWndFrame.tbwPostingCtrl.colControlTypeDesc,\r\n" +
                                "				:i_hWndFrame.tbwPostingCtrl.colControlType,\r\n" +
                                "				:i_hWndFrame.tbwPostingCtrl.colModule,\r\n" +
                                "				NULL )")))
                            {
                                e.Return = false;
                                return;
                            }
                        }
                        // Bug 82933, End
                    }
                    if ((this.colDefaultValueNoCt.Text != Sys.STRING_Null) && ((this.colsCtrlTypeCategoryDb.Text == "FIXED") || (this.colsCtrlTypeCategoryDb.Text == "PREPOSTING")))
                    {
                        this.colDefaultValueNoCt.Text = Sys.STRING_Null;
                    }
                    if ((this.colDefaultValue.Text != Sys.STRING_Null) && (this.colsCtrlTypeCategoryDb.Text == "PREPOSTING"))
                    {
                        this.colDefaultValue.Text = Sys.STRING_Null;
                    }
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                    return;
                }
                else
                {
                    e.Return = false;
                    return;
                }
            }
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colControlType_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.colsCtrlTypeCategory.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            if (this.bIsRecordPaste == true || this.bIsRecordDuplicate == true)
            {
                Sal.SendMsg(this.colControlType.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colControlType_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nNum = SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sRecords);
            this.nNum = this.sRecords[3].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
            if (this.sUnits[0] == "CTRL_TYPE_CATEGORY")
            {
                this.colsCtrlTypeCategory.Text = this.sUnits[1];
                Sal.SetFieldEdit(this.colsCtrlTypeCategory, true);
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colControlType_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.colsCodeName) || Sal.IsNull(this.colPostingType))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemLov event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colControlType_OnPM_DataItemLov(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 71046, Begin
            if (this.colControlType.p_sLovReference != "CTRL_TYPE_ALLOWED_VALUE(COMPANY,POSTING_TYPE,CODE_PART)")
            {
                this.colControlType.p_sLovReference = "CTRL_TYPE_ALLOWED_VALUE(COMPANY,POSTING_TYPE,CODE_PART)";
            }
            // Bug 71046, End
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.GetCodePart();
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colDefaultValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colDefaultValue_OnPM_DataItemZoom(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.colDefaultValue_OnPM_DataItemQueryEnabled(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.colDefaultValue_OnPM_DataItemLovUserWhere(sender, e);
                    break;

            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colDefaultValue_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.sTempLovReference = this.colDefaultValue.p_sLovReference;
                this.bForCordPartA = false;
                if (this.colsCodePart.Text == "A")
                {
                    this.colDefaultValue.p_sLovReference = "ACCOUNT(COMPANY)";
                    this.bForCordPartA = true;
                }
                Ifs.Fnd.ApplicationForms.Var.bReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                this.colDefaultValue.p_sLovReference = this.sTempLovReference;
                e.Return = Ifs.Fnd.ApplicationForms.Var.bReturn;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colDefaultValue_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colsCtrlTypeCategoryDb.Text == "PREPOSTING")
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void colDefaultValue_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = ((SalString)("COMPANY = '" + this.colsCompany.Text + "' AND CODE_PART = '" + this.colsCodePart.Text + "'")).ToHandle();
            return;
            #endregion
        }


        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colDefaultValueNoCt_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colDefaultValueNoCt_OnPM_DataItemZoom(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.colDefaultValueNoCt_OnPM_DataItemQueryEnabled(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.colDefaultValueNoCt_OnPM_DataItemLovUserWhere(sender, e);
                    break;
            }
            #endregion
        }

        private void colDefaultValueNoCt_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = ((SalString)("COMPANY = '" + this.colsCompany.Text + "' AND CODE_PART = '" + this.colsCodePart.Text + "'")).ToHandle();
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colDefaultValueNoCt_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.sTempLovReference = this.colDefaultValueNoCt.p_sLovReference;
                this.bForCordPartA = false;
                if (this.colsCodePart.Text == "A")
                {
                    this.colDefaultValueNoCt.p_sLovReference = "ACCOUNT(COMPANY)";
                    this.bForCordPartA = true;
                }
                Ifs.Fnd.ApplicationForms.Var.bReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                this.colDefaultValueNoCt.p_sLovReference = this.sTempLovReference;
                e.Return = Ifs.Fnd.ApplicationForms.Var.bReturn;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colDefaultValueNoCt_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((this.colsCtrlTypeCategoryDb.Text == "FIXED") || (this.colsCtrlTypeCategoryDb.Text == "PREPOSTING"))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtDataRecordQueryDialog()
        {
            return this.DataRecordQueryDialog();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataSourceCreateWindowTrans(SalNumber nWhat, SalString sMessage)
        {
            return this.DataSourceCreateWindowTrans(nWhat, sMessage);
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
        public override SalNumber vrtPSheetApplyChanges(SalString sSheet, SalString sProfileName, SalString sProfileSection)
        {
            return this.PSheetApplyChanges(sSheet, sProfileName, sProfileSection);
        }
        #endregion

        #region Event Handlers

        private void menuItem__Details_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = RightMouseClick(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Details_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            RightMouseClick(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Copy_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = CopyDetails(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Copy_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            CopyDetails(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            SalWindowHandle hWndNav = SalWindowHandle.Null;
            sOldCompanyName = i_sCompany;
            // 149054 - Send the message PAM_ChangeCompany to the parent. The rest of the code above is now obsolete with the new change company functionality.
            hWndNav = Sal.ParentWindow(this);
            // 151649 - Added IF condition to check the parent
            if (hWndNav != (SalWindowHandle)Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm)
            {
                Sal.SendMsg(hWndNav, Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
            }
            else
            {
                Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
            }
        }

        #endregion

    }
}
