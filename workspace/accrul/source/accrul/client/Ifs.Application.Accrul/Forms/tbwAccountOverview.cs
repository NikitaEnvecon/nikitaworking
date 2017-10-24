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
//  ------------------------------------------------------------------------ 
//  120210  Shedlk  SFI-2398, Merged bug 101078
//  120809  Kagalk  Bug 101446, Enabled to use Count Hits for Notes column
#endregion

using System;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using Ifs.Application.Appsrv;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;
using Ifs.Fnd.Windows.Forms;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("ACCOUNT", "Account")]
    public partial class tbwAccountOverview : cTableWindowFin
    {
        #region Window Variables
        public SalNumber nRetVal = 0;
        public SalString IID_Can = "";
        public SalString IID_Must = "";
        public SalString IID_Block = "";
        public SalBoolean bGENLED = false;
        public SalString lsTemp = "";
        public SalString lsTemp2 = "";
        public SalString lsTemp3 = "";
        public SalString sTemp = "";
        public SalString sTemp1 = "";
        public SalString sTemp2 = "";
        public SalString sTemp3 = "";
        public SalString sTemp4 = "";
        public SalString sTemp5 = "";
        public SalString sTemp6 = "";
        public SalString sTemp7 = "";
        public SalString sTemp8 = "";
        public SalString sTemp9 = "";
        public SalString sTemp10 = "";
        public SalString sTemp11 = "";
        public SalString sTemp12 = "";
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalString sTextType = "";
        public SalString sBudTemp1 = "";
        public SalString sBudTemp2 = "";
        public SalString sBudTemp3 = "";
        public SalString sBudTemp4 = "";
        public SalString sBudTemp5 = "";
        public SalString sBudTemp6 = "";
        public SalString sBudTemp7 = "";
        public SalString sBudTemp8 = "";
        public SalString sBudTemp9 = "";
        public SalString sBudTemp10 = "";
        public SalString sTempa = "";
        public SalString sTempa1 = "";
        public SalString sTempa2 = "";
        public SalString sTempa3 = "";
        public SalString sTempa4 = "";
        public SalString sTempa5 = "";
        public SalString sTempa6 = "";
        public SalString sTempa7 = "";
        public SalString sTempa8 = "";
        public SalString sTempa9 = "";
        public SalString sTempa10 = "";
        public SalString sTempa11 = "";
        public SalString sTempa12 = "";
        public SalString sBudTempa1 = "";
        public SalString sBudTempa2 = "";
        public SalString sBudTempa3 = "";
        public SalString sBudTempa4 = "";
        public SalString sBudTempa5 = "";
        public SalString sBudTempa6 = "";
        public SalString sBudTempa7 = "";
        public SalString sBudTempa8 = "";
        public SalString sBudTempa9 = "";
        public SalString sBudTempa10 = "";
        public SalString sModule = "";
        public SalString sLu = "";
        public SalString lsAttribute = "";
        public SalString sTaxHandlingValue = "";
        public SalString sTaxHandlingValueBlocked = "";
        public SalString sTaxHandlingValueAll = "";
        public SalString ArchivingTransDB = "";
        public SalString sG_GENLED_A = "";
        public SalString sBaseForPFE = "";
        // BUg 105199 Begin
        public SalNumber nIndex = 0;
        public SalArray<SalString> sItemNames = new SalArray<SalString>();
        public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        // BUg 105199 End

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwAccountOverview()
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
        public new static tbwAccountOverview FromHandle(SalWindowHandle handle)
        {
            return ((tbwAccountOverview)SalWindow.FromHandle(handle, typeof(tbwAccountOverview)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Local Variables
            SalNumber nRC = 0;
            SalNumber nItemIndex = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                // Insert new code here...
                // Bug 76047, Moved the db calls to the block in SAM_CreateComplete
                // Insert new code here...
                return true;
            }
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            SalNumber nRC = 0;
            SalNumber nItemIndex = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    nItemIndex = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("ACCOUNT");
                    if (nItemIndex >= 0)
                    {

                        // PPJ: Automatically generated temporary assignments.
                        // PPJ: Dynamic array items, properties, and controls cannot be passed by reference.
                        SalString temp1 = colsAccount.Text;
                        nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndex, 0, ref temp1);
                        colsAccount.Text = temp1;

                    }
                    nItemIndex = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY");
                    if (nItemIndex >= 0)
                    {
                        nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndex, 0, ref i_sCompany);
                    }
                    InitFromTransferredData();
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    SetWindowTitle();
                    Sal.WaitCursor(false);
                    return false;
                }
                return base.Activate(URL);
            }

            #endregion

        }

        /// <summary>
        /// Gets client default values for NEW records
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataRecordGetDefaults()
        {
            #region Actions
            using (new SalContext(this))
            {
                colsCompany.Text = i_sCompany;
                colsCompany.EditDataItemSetEdited();
                colsPrevTaxHandlingValue.Text = sTaxHandlingValueAll;
                return true;
            }
            #endregion
        }

        /// <summary>
        /// This function was included to correct Bug # : 5579 (Duplicating Accounts)
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber EnableHiddenColumns()
        {
            #region Local Variables
            SalNumber n = 0;
            SalWindowHandle hWndCol = SalWindowHandle.Null;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                n = 1;
                while (true)
                {
                    hWndCol = Sal.TblGetColumnWindow(this, n, Sys.COL_GetID);
                    if (hWndCol == SalWindowHandle.Null)
                    {
                        break;
                    }
                    if (!(Sal.IsWindowVisible(hWndCol)))
                    {
                        Sal.EnableWindow(hWndCol);
                    }
                    n = n + 1;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber CodestrCompl(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:

                        Sal.WaitCursor(true);
                        sItemNames[0] = "COMPANY";
                        hWndItems[0] = colsCompany;
                        sItemNames[1] = "CODE_PART_VALUE";
                        hWndItems[1] = colsAccount;
                        // Bug 93244 Begin. Additionally adding the codepart during the DataTransfer
                        colCodePart.Text = "A";
                        sItemNames[2] = "CODE_PART";
                        hWndItems[2] = colCodePart;
                        // Bug 93244 End.

                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("OBJECT_ID", i_hWndFrame, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmCdCompl"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        return 1;

                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return Sal.TblAnyRows(this, Sys.ROW_Selected, 0) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCdCompl"));
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber TaxCodesPerAccount(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            SalNumber nRow = 0;
            SalBoolean bTemp = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        bTemp = false;
                        nRow = Sys.TBL_MinRow;
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmAccountTaxCode"))))
                        {
                            return 0;
                        }
                        while (Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_Selected, 0))
                        {
                            Sal.TblSetContext(i_hWndSelf, nRow);
                            cSessionManager.c_lsStmt = ":i_hWndFrame.tbwAccountOverview.sTaxHandlingValue :=\r\n" +
                            "                        &AO.ACCOUNT_API.Get_Tax_Handling_Value(\r\n" +
                            "                        :i_hWndFrame.tbwAccountOverview.colsCompany,\r\n" +
                            "                        :i_hWndFrame.tbwAccountOverview.colsAccount)";
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("ACCOUNT_API.Get_Tax_Handling_Value", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_lsStmt);
                            }
                            if (sTaxHandlingValue != "BLOCKED")
                            {
                                bTemp = true;
                                return bTemp;
                            }
                        }
                        return bTemp;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "ACCOUNT";
                        hWndItems[0] = colsAccount;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Account", this, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmAccountTaxCode"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        return 1;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber Translation(SalNumber nWhat)
        {
            #region Local Variables
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        if (Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCompanyTranslation")))
                        {
                            sModule = "ACCRUL";
                            sLu = "Account";
                            lsAttribute = Ifs.Fnd.ApplicationForms.Const.strNULL;
                            nRow = Sys.TBL_MinRow;
                            while (true)
                            {
                                if (Sal.TblFindNextRow(this, ref nRow, Sys.ROW_Selected, 0))
                                {
                                    Sal.TblSetContext(this, nRow);
                                    lsAttribute = lsAttribute + "'" + colsAccount.Text + "'" + ",";
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (lsAttribute != Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                lsAttribute = lsAttribute.Left(lsAttribute.Length - 1);
                                Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_COMPANY", i_sCompany);
                                Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_MODULE", sModule);
                                Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_LU", sLu);
                                Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_ATTRIBUTE", lsAttribute);
                                SessionCreateWindow(Pal.GetActiveInstanceName("frmCompanyTranslation"), Sys.hWndMDI);
                            }
                        }
                        Sal.WaitCursor(false);
                        return 1;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return !(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) && Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCompanyTranslation")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(
                            Pal.GetActiveInstanceName("frmCompanyTranslation"));
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber FreeText(SalNumber nWhat)
        {
            #region Local Variables
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:

                        Sal.WaitCursor(false);
                        lsTemp = colsText.Text;
                        if (tbwAccountOverview.FromHandle(i_hWndFrame).colsText.EditLaunchEditor())
                        {
                            nRetVal = 1979;
                            colsText.Text = lsTemp.Left(nRetVal); // 1978 is a magic number of SqlRouter and SqlNet ( It's a limitations! )
                            colsText.EditDataItemSetEdited();

                            Sal.SendMsg(colsText, Const.PAM_AccntCheckUncheckCBText, 0, 0);
                        }
                        return 1;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        nRow = Sys.TBL_MinRow;
                        if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0))
                        {
                            if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0))
                            {
                                return 0;
                            }
                            return 1;
                        }
                        return 0;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public virtual SalString GetIID(SalString sCode)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (sCode == "K")
                {
                    return IID_Can;
                }
                if (sCode == "M")
                {
                    return IID_Must;
                }
                if (sCode == "S")
                {
                    return IID_Block;
                }
            }

            return "";
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckModule()
        {
            #region Actions
            using (new SalContext(this))
            {
                // Bug 76047, Moved the db call to the block in SAM_CreateComplete
                sG_GENLED_A = sTemp;
                if (sTemp == "GENLED")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            #endregion
        }
        // Menu functions
        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber ConnectAttribute(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "COMPANY";
                        hWndItems[0] = colsCompany;
                        sItemNames[1] = "CODE_PART_VALUE";
                        hWndItems[1] = colsAccount;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("AttributeCon", this, sItemNames, hWndItems);
                        if (Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("tbwAttributeCon")))
                        {
                            SessionCreateWindow(Pal.GetActiveInstanceName("tbwAttributeCon"), Sys.hWndMDI);
                        }
                        Sal.WaitCursor(false);
                        return 1;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return 0;
                        }
                        if (!(Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0)))
                        {
                            return 0;
                        }
                        // Bug 79351, Begin. Added IsDataSourceAvailable()
                        if (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("tbwAttributeCon")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("tbwAttributeCon"))))
                        {
                            return 0;
                        }
                        // Bug 79351, End
                        return 1;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber ConnProjectCostElement(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return 0;
                        }
                        if (!(Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0)))
                        {
                            return 0;
                        }
                        if (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("tbwCostElementToAccount"))))
                        {
                            return 0;
                        }
                        GetBaseForPFE();
                        if (sBaseForPFE != "A")
                        {
                            return 0;
                        }
                        return 1;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "COMPANY";
                        hWndItems[0] = colsCompany;
                        sItemNames[1] = "ACCOUNT";
                        hWndItems[1] = colsAccount;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("tbwCostElementToAccount"), this, sItemNames, hWndItems);
                        if (Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("tbwCostElementToAccount")))
                        {
                            SessionCreateWindow(Pal.GetActiveInstanceName("tbwCostElementToAccount"), Sys.hWndMDI);
                        }
                        Sal.WaitCursor(false);
                        return 1;
                }
            }

            return 0;
            #endregion
        }
        // Bug 65271, Begin.
        /// <summary>
        /// </summary>
        /// <param name="sWindowName"></param>
        /// <returns></returns>
        public new SalNumber DataSourcePrepareKeyTransfer(SalString sWindowName)
        {
            #region Local Variables
            SalArray<SalString> sArray = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sWindowName == Pal.GetActiveInstanceName("frmHistoryLog"))
                {
                    colCodePart.Text = "A";
                    sArray[0] = "COMPANY";
                    sArray[1] = "CODE_PART";
                    sArray[2] = "CODE_PART_VALUE";
                    hWndItems[0] = colsCompany;
                    hWndItems[1] = colCodePart;
                    hWndItems[2] = colsAccount;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Account", this, sArray, hWndItems);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("CREATE_WINDOW");
                }
                else
                {
                    ((cDataSource)this).DataSourcePrepareKeyTransfer(sWindowName);
                }
            }

            return 0;
            #endregion
        }
        // Bug 65271, End.
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
                    DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.tbwAccountOverview.sBaseForPFE:= &AO.Accounting_Code_Parts_API.Get_Base_For_Followup_Element(\r\n" +
                        "	      :i_hWndFrame.tbwAccountOverview.colsCompany)");
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>         
        public virtual SalString FormatWhereClause(SalNumber wParam, SalNumber lParam)
        {
            #region Local Variables
            SalString sWhere = "";
            SalString sFormattedWhere = "";
            SalNumber nOffset = 0;
            // Bug 101446, begin
            SalNumber nEnd = 0;
            SalNumber nLength = 0;
            SalString sStmt = "";
            SalString sModifiedStmt = "";
            // Bug 101446, end
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sWhere = SalString.FromHandle(lParam);
                // Bug 101446, begin
                sStmt = "CB_TEXT = :_gBs@T";
                nOffset = sWhere.Scan(sStmt);
                if (nOffset != -1)
                {
                    sModifiedStmt = "TEXT IS NOT NULL";
                }
                else
                {
                    sStmt = "CB_TEXT = :_gBs@F";
                    nOffset = sWhere.Scan(sStmt);
                    if (nOffset != -1)
                    {
                        sModifiedStmt = "TEXT IS NULL";
                    }                    
                    else
                    {
                        sStmt = "upper( CB_TEXT ) = upper( :_gBs@T )";
                        nOffset = sWhere.Scan(sStmt);
                        if (nOffset != -1)
                        {
                            sModifiedStmt = "TEXT IS NOT NULL";
                        }
                        else
                        {
                            sStmt = "upper( CB_TEXT ) = upper( :_gBs@F )";
                            nOffset = sWhere.Scan(sStmt);
                            if (nOffset != -1)
                            {
                                sModifiedStmt = "TEXT IS NULL";
                            }
                        }

                    }                    
                }
                if (nOffset != -1)
                {
                    nLength = sStmt.Length;
                    sFormattedWhere = sWhere.Left(nOffset) + sModifiedStmt + sWhere.Right(sWhere.Length - (nOffset + nLength));
                    return sFormattedWhere;
                }
                // Bug 101446, end
                return sWhere;
            }

            return "";
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public virtual SalString FormatOrderByClause(SalNumber wParam, SalNumber lParam)
        {
            #region Local Variables
            SalString sOrderBy = "";
            SalString sFormattedOrderBy = "";
            SalNumber nOffset = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sOrderBy = SalString.FromHandle(lParam);
                nOffset = sOrderBy.Scan("CB_TEXT DESC");
                if (nOffset != -1)
                {
                    sFormattedOrderBy = sOrderBy.Replace(nOffset, 12, "TEXT ASC");
                    return sFormattedOrderBy;
                }
               
                else
                {
                    nOffset = sOrderBy.Scan("CB_TEXT");
                    if (nOffset != -1)
                    {
                        sFormattedOrderBy = sOrderBy.Replace(nOffset, 7, "TEXT DESC");
                        return sFormattedOrderBy;
                    }
                }
                return sOrderBy;
            }

            return "";
            #endregion
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tbwAccountOverview_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.tbwAccountOverview_OnSAM_Create(sender, e);
                    break;

                case Sys.SAM_CreateComplete:
                    this.tbwAccountOverview_OnSAM_CreateComplete(sender, e);
                    break;

                case Sys.SAM_FetchRowDone:
                    this.tbwAccountOverview_OnSAM_FetchRowDone(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.tbwAccountOverview_OnPM_DataSourceSave(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tbwAccountOverview_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.tbwAccountOverview_OnPM_DataRecordDuplicate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere:
                    this.tbwAccountOverview_OnPM_DataSourceUserWhere(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserOrderBy:
                    this.tbwAccountOverview_OnPM_DataSourceUserOrderBy(sender, e);
                    break;
                // Bug 101446, begin
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceHitCount:
                    this.tbwAccountOverview_OnPM_DataSourceHitCount(sender, e);
                    break;
                // Bug 101446, end

            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwAccountOverview_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.EnableHiddenColumns();
            e.Return = Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_CreateComplete event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwAccountOverview_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 76047, Begin, Merged the db call from CheckModule and FrameStartupUser
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("ACCOUNT_REQUEST_API.DECODE", System.Data.ParameterDirection.Input);
                hints.Add("Tax_Handling_Value_API.Decode", System.Data.ParameterDirection.Input);
                hints.Add("Finance_Lib_API.Check_Module", System.Data.ParameterDirection.Output);
                this.DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                    "	:i_hWndFrame.tbwAccountOverview.lsTemp :=  &AO.ACCOUNT_REQUEST_API.DECODE('K') ;\r\n" +
                    "	:i_hWndFrame.tbwAccountOverview.lsTemp2 := &AO.ACCOUNT_REQUEST_API.DECODE('M') ;\r\n" +
                    "       	:i_hWndFrame.tbwAccountOverview.lsTemp3 := &AO.ACCOUNT_REQUEST_API.DECODE('S') ;\r\n" +
                    "	:i_hWndFrame.tbwAccountOverview.sTaxHandlingValueBlocked := &AO.Tax_Handling_Value_API.Decode( 'BLOCKED' );\r\n" +
                    "	:i_hWndFrame.tbwAccountOverview.sTaxHandlingValueAll := &AO.Tax_Handling_Value_API.Decode( 'ALL' );\r\n" +
                    "	&AO.Finance_Lib_API.Check_Module(:i_hWndFrame.tbwAccountOverview.sTemp);\r\n" +
                    "               	 END; ");
            }
            // Bug 76047, End
            this.IID_Can = this.lsTemp;
            this.IID_Must = this.lsTemp2;
            this.IID_Block = this.lsTemp3;
            if (this.sG_GENLED_A == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                this.bGENLED = this.CheckModule();
            }
            else
            {
                if (this.sG_GENLED_A == "GENLED")
                {
                    this.bGENLED = true;
                }
                else
                {
                    this.bGENLED = false;
                }
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_FetchRowDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwAccountOverview_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam))
            {
                Sal.SendMsg(this.colsText, Const.PAM_AccntCheckUncheckCBText, 0, 0);
                this.colsPrevTaxHandlingValue.Text = this.colsTaxHandlingValue.Text;
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
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwAccountOverview_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwAccountOverview_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
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
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwAccountOverview.i_sCompany").ToHandle();
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
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwAccountOverview_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    this.ArchivingTransDB = this.colsArchivingTrans.Text;
                }
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.colsPrevTaxHandlingValue.Text = this.sTaxHandlingValueAll;
                    this.colsArchivingTrans.Text = this.ArchivingTransDB;
                    Sal.SendMsg(this.colsArchivingTrans, Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, 0, 0);
                    Sal.SendMsg(this.colsAccountType, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                    this.colsArchivingTrans.EditDataItemValueSet(1, ((SalString)this.colsArchivingTrans.Text).ToHandle());
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
        /// PM_DataSourceUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwAccountOverview_OnPM_DataSourceUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Sys.wParam, this.FormatWhereClause(Sys.wParam, Sys.lParam).ToHandle());
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceUserOrderBy event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwAccountOverview_OnPM_DataSourceUserOrderBy(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserOrderBy, Sys.wParam, this.FormatOrderByClause(Sys.wParam, Sys.lParam).ToHandle());
            return;
            #endregion
        }

        // Bug 101446, begin
        /// <summary>
        /// PM_DataSourceHitCount event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwAccountOverview_OnPM_DataSourceHitCount(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceHitCount, Sys.wParam, this.FormatWhereClause(Sys.wParam, Sys.lParam).ToHandle());
            return;
            #endregion
        }

        // Bug 101446, end

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
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsAccount_OnPM_DataItemValidate(sender, e);
                    break;
            }
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
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (Sal.IsNull(this.colsAccount.i_hWndSelf))
                {
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
                if ((((SalString)this.colsAccount.Text).Scan("&") >= 0) || (((SalString)this.colsAccount.Text).Scan("'") >= 0))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_InvalidCharacterAccount, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
                else
                {
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
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsAccountType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsAccountType_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsAccountType_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (this.colsAccountType.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                Sal.WaitCursor(true);
                this.sTemp = this.colsAccountType.Text;
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Account_Type_API.Get_Default_Codepart_Demands_", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("ACCOUNT_TYPE_API.Get_Logical_Account_Type", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("ACCOUNT_TYPE_VALUE_API.Encode", System.Data.ParameterDirection.Input);
                    if (!(this.colsAccountType.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + cSessionManager.c_sDbPrefix + "Account_Type_API.Get_Default_Codepart_Demands_(\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sTemp1 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sTemp2 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sTemp3 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sTemp4 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sTemp5 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sTemp6 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sTemp7 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sTemp8 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sTemp9 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sTemp10 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sTemp11,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sTemp12,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sBudTemp1 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sBudTemp2 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sBudTemp3 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sBudTemp4 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sBudTemp5 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sBudTemp6 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sBudTemp7 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sBudTemp8 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sBudTemp9 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sBudTemp10 ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.i_sCompany ,\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.sTemp ) ;\r\n" +
                        "		:i_hWndFrame.tbwAccountOverview.colsLogicalAccountTypeDb := SUBSTR(" + cSessionManager.c_sDbPrefix + "ACCOUNT_TYPE_VALUE_API.Encode (\r\n" +
                        "                                            							          " + cSessionManager.c_sDbPrefix + "ACCOUNT_TYPE_API.Get_Logical_Account_Type(\r\n" +
                        "                                           							            :i_hWndFrame.tbwAccountOverview.i_sCompany,:i_hWndFrame.tbwAccountOverview.colsAccountType)),1,20) ;\r\n	END;")))
                    {
                        Sal.WaitCursor(false);
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                }
                this.colsReqAccntB.Text = this.GetIID(this.sTemp1);
                this.colsReqAccntC.Text = this.GetIID(this.sTemp2);
                this.colsReqAccntD.Text = this.GetIID(this.sTemp3);
                this.colsReqAccntE.Text = this.GetIID(this.sTemp4);
                this.colsReqAccntF.Text = this.GetIID(this.sTemp5);
                this.colsReqAccntG.Text = this.GetIID(this.sTemp6);
                this.colsReqAccntH.Text = this.GetIID(this.sTemp7);
                this.colsReqAccntI.Text = this.GetIID(this.sTemp8);
                this.colsReqAccntJ.Text = this.GetIID(this.sTemp9);
                this.colsReqQuantity.Text = this.GetIID(this.sTemp10);
                this.colsReqText.Text = this.GetIID(this.sTemp11);
                this.colsProcessCode.Text = this.GetIID(this.sTemp12);

                this.colsReqBudgetCodeB.Text = this.GetIID(this.sBudTemp1);
                this.colsReqBudgetCodeC.Text = this.GetIID(this.sBudTemp2);
                this.colsReqBudgetCodeD.Text = this.GetIID(this.sBudTemp3);
                this.colsReqBudgetCodeE.Text = this.GetIID(this.sBudTemp4);
                this.colsReqBudgetCodeF.Text = this.GetIID(this.sBudTemp5);
                this.colsReqBudgetCodeG.Text = this.GetIID(this.sBudTemp6);
                this.colsReqBudgetCodeH.Text = this.GetIID(this.sBudTemp7);
                this.colsReqBudgetCodeI.Text = this.GetIID(this.sBudTemp8);
                this.colsReqBudgetCodeJ.Text = this.GetIID(this.sBudTemp9);
                this.colsReqBudgetQuantity.Text = this.GetIID(this.sBudTemp10);
                this.colsReqAccntB.EditDataItemSetEdited();
                this.colsReqAccntC.EditDataItemSetEdited();
                this.colsReqAccntD.EditDataItemSetEdited();
                this.colsReqAccntE.EditDataItemSetEdited();
                this.colsReqAccntF.EditDataItemSetEdited();
                this.colsReqAccntG.EditDataItemSetEdited();
                this.colsReqAccntH.EditDataItemSetEdited();
                this.colsReqAccntI.EditDataItemSetEdited();
                this.colsReqAccntJ.EditDataItemSetEdited();
                this.colsReqQuantity.EditDataItemSetEdited();
                this.colsReqText.EditDataItemSetEdited();

                this.colsProcessCode.EditDataItemSetEdited();
                Sal.WaitCursor(false);
                this.colsReqBudgetCodeB.EditDataItemSetEdited();
                this.colsReqBudgetCodeC.EditDataItemSetEdited();
                this.colsReqBudgetCodeD.EditDataItemSetEdited();
                this.colsReqBudgetCodeE.EditDataItemSetEdited();
                this.colsReqBudgetCodeF.EditDataItemSetEdited();
                this.colsReqBudgetCodeG.EditDataItemSetEdited();
                this.colsReqBudgetCodeH.EditDataItemSetEdited();
                this.colsReqBudgetCodeI.EditDataItemSetEdited();
                this.colsReqBudgetCodeJ.EditDataItemSetEdited();
                this.colsReqBudgetQuantity.EditDataItemSetEdited();
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
        private void colsTaxHandlingValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsTaxHandlingValue_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsTaxHandlingValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (this.colsTaxHandlingValue.Text != this.colsPrevTaxHandlingValue.Text)
            {
                if (this.colsTaxHandlingValue.Text == this.sTaxHandlingValueBlocked)
                {
                    Sal.SendMsg(this.colsTaxCodeMandatory, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)"FALSE").ToHandle());
                }
            }
            this.colsPrevTaxHandlingValue.Text = this.colsTaxHandlingValue.Text;
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsTaxCodeMandatory_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.colsTaxCodeMandatory_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsTaxCodeMandatory_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colsTaxHandlingValue.Text == this.sTaxHandlingValueBlocked)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCurrencyBalance_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.colCurrencyBalance_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCurrencyBalance_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colBudgetAccount.Text == "Y")
            {
                this.colCurrencyBalance.Text = "N";
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
        private void colBudgetAccount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.colBudgetAccount_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colBudgetAccount_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colLedgerAccount.Text == "Y" || this.colCurrencyBalance.Text == "Y")
            {
                this.colBudgetAccount.Text = "N";
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
        private void colLedgerAccount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.colLedgerAccount_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colLedgerAccount_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colBudgetAccount.Text == "Y" || this.colsStatAccount.Text == "Y")
            {
                this.colLedgerAccount.Text = "N";
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
        private void colTaxAccount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.colTaxAccount_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colTaxAccount_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Bug 85877, Begin, checked if the permission available
            if (Sal.SendMsg(this.colTaxAccount.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, 0, 0) == Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled)
            {
                if (this.colBudgetAccount.Text == "Y" || this.colsStatAccount.Text == "Y")
                {
                    this.colTaxAccount.Text = "N";
                }
                if (this.colTaxAccount.Text == "Y")
                {
                    this.colLedgerAccount.Text = "Y";
                    this.colLedgerAccount.EditDataItemSetEdited();
                }
            }
            // Bug 85877, End
            e.Return = Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsStatAccount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.colsStatAccount_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsStatAccount_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colLedgerAccount.Text == "Y" || (this.colsLogicalAccountTypeDb.Text != "S" && this.colsLogicalAccountTypeDb.Text != "O"))
            {
                this.colsStatAccount.Text = "N";
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
		private void colsExcludePeriodicalCap_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsExcludePeriodicalCap_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.colsExcludePeriodicalCap_OnPM_LookupInit(sender, e);
                    break;
			}
			#endregion
		}        

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsExcludePeriodicalCap_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if ((Sal.ListQuerySelection(this.colsExcludePeriodicalCap) > 0) && ( (this.colsLogicalAccountTypeDb.Text == "A" || this.colsLogicalAccountTypeDb.Text == "L" || this.colsLogicalAccountTypeDb.Text == "O" || this.colsLogicalAccountTypeDb.Text == Sys.STRING_Null)))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_PeriodicalCap, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    Sal.ListSetSelect(this.colsExcludePeriodicalCap, 0);
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }                
                else
                {
                   e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                   return;
                }
            }
            #endregion
        }		



        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsExcludePeriodicalCap_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam))
            {
               Sal.ListDelete(colsExcludePeriodicalCap, 4);                
               e.Return = true;
               return;
            }
            e.Return = false;
            return;
            #endregion
        }
        
        
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void colsExcludeProjFollowup_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					this.colsExcludeProjFollowup_OnSAM_AnyEdit(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsExcludeProjFollowup_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(this.colsLogicalAccountTypeDb.Text == "A" || this.colsLogicalAccountTypeDb.Text == "L" || this.colsLogicalAccountTypeDb.Text == "O")) 
			{
				this.colsExcludeProjFollowup.Text = "FALSE";
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
        private void colsCBAttribute_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    e.Handled = true;
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsCBText_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    e.Handled = true;
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsText_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Const.PAM_AccntCheckUncheckCBText:
                    this.colsText_OnPAM_AccntCheckUncheckCBText(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PAM_AccntCheckUncheckCBText event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsText_OnPAM_AccntCheckUncheckCBText(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colsText.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                this.colsCBText.Text = "F";
            }
            else
            {
                this.colsCBText.Text = "T";
            }
            #endregion
        }
        // Bug 105199 Begin
        		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsConsAccnt_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.colsConsAccnt_OnPM_DataItemQueryEnabled(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colsConsAccnt_OnPM_DataItemZoom(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
        private void colsConsAccnt_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.colsConsCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemZoom event handler.
		/// </summary>
		/// <param name="message"></param>
        private void colsConsAccnt_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.colsConsCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				e.Return = false;
				return;
			}
			else
			{
				switch (Sys.wParam)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						this.sItemNames[0] = "ACCOUNT";
						this.hWndItems[0] = this.colsConsAccnt;
						this.sItemNames[1] = "COMPANY";
						this.hWndItems[1] = this.colsConsCompany;
						Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Account", this, this.sItemNames, this.hWndItems);
						// Set the Type to ZOOM since this will clear in IEE
						Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("ZOOM");
						
                        this.colsConsAccnt.SessionCreateWindow(Pal.GetActiveInstanceName("frmTabAccount"), Sys.hWndMDI);
                       
						e.Return = true;
						return;
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		#endregion
        // Bug 105199 End

       

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
        public override SalNumber vrtDataSourcePrepareKeyTransfer(SalString sWindowName)
        {
            return this.DataSourcePrepareKeyTransfer(sWindowName);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }

        #endregion

        #region Event Handlers

        private void menuItem_Code_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = CodestrCompl(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Code_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            CodestrCompl(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Account_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.TblAnyRows(Sys.hWndForm, Sys.ROW_Selected, 0) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmTabAccount"));
        }

        private void menuItem__Account_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            Sal.WaitCursor(true);
            sItemNames[0] = "ACCOUNT";
            hWndItems[0] = colsAccount;
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Account", this, sItemNames, hWndItems);
            if (Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmTabAccount")))
            {
                SessionCreateWindow(Pal.GetActiveInstanceName("frmTabAccount"), Sys.hWndMDI);
            }
            Sal.WaitCursor(false);
        }

        private void menuItem__Tax_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = TaxCodesPerAccount(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Tax_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            TaxCodesPerAccount(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Code_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ConnectAttribute(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Code_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ConnectAttribute(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Project_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ConnProjectCostElement(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Project_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ConnProjectCostElement(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Translation_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Translation_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Notes_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Notes_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            FreeText(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        #endregion

    }
}
