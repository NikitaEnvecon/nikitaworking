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
// 091106  Nirplk  Bug 84087, Corrected in vrtActivate()
// 121123  Janblk  DANU-122, Parallel currency implementation
// 121218  Raablk  Bug 107457, Corrected by modifying PM_DataItemValidate event handler in colTransactionDate.
// 150219  AjPelk  PRFI-5486, Lcs merge bug is 120401
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
    [FndWindowRegistration("EXT_TRANSACTIONS", "ExtTransaction", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwExtTransactions : cTableWindowFin
    {
        #region Window Variables
        public SalNumber nTemp = 0;
        public SalString sTemp = "";
        public SalString sTemp1 = "";
        public SalString lsTemp = "";
        public SalString lsStmt = "";
        public SalWindowHandle hWndTemp = SalWindowHandle.Null;
        public SalNumber nRow = 0;
        public SalString sAlterTrans = "";
        public SalString lsSelectStatment = "";
        public SalArray<SalBoolean> bVisible = new SalArray<SalBoolean>(20);
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalString sIsProjectCodePart = "";
        public SalString sDummyCodePart = "";
        public SalString sIsProjectExternallyCreated = "";
        public SalString sProjActivityBlockedFlag = "";
        public SalString sBaseCurrencyCode = "";
        public SalString sCurrencyType = "";
        public SalNumber nCurrencyRate = 0;
        public SalNumber nAccDecimalsInAmount = 0;
        public SalNumber nDecimalsInAmount = 0;
        public SalString sTaxHandlingValue = "";
        public SalDateTime dLoadDate = SalDateTime.Null;
        public SalWindowHandle hWndCodePart = SalWindowHandle.Null;
        public SalNumber nCodePartId = 0;
        public SalString sUserId = "";
        public SalArray<SalString> sItemNames = new SalArray<SalString>();
        public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        public SalString sColVisibility = "";
        public SalArray<SalString> sColumnArray = new SalArray<SalString>();
        public SalArray<SalString> sParams = new SalArray<SalString>(2);
        public SalString sCodestringCmpl = "";
        public SalString sColSqlName = "";
        public SalString sColValue = "";
        public SalString sRequiredStringComplete = "";
        public SalString sAccntMdfy = "";

        public SalString sThirdInverted = "";
        SalString sThirdCurrencyCode = "";
        SalNumber nFinThirdConversionFactor = 0;
        SalNumber nFinThirdCurrencyRate = 0;
        SalNumber nParallelCurrRateType = SalNumber.Null;
        SalString lsFinThirdInverted;
        public SalString sFormName = "";
        public SalString sParallelBaseType = "";
        public SalString sParallelRateType = "";
        #endregion
        private static SalString UserMethod_sName = "";

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwExtTransactions()
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
        public new static tbwExtTransactions FromHandle(SalWindowHandle handle)
        {
            return ((tbwExtTransactions)SalWindow.FromHandle(handle, typeof(tbwExtTransactions)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckTaxCode()
        {
            #region Actions
            using (new SalContext(this))
            {
                // Bug Bug 97225, Begin
                using (SignatureHints hints = SignatureHints.NewContext())
                {                    
                    hints.Add("Voucher_Type_Detail_API.Get_Function_Group", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("Account_Tax_Code_API.Check_Tax_Code", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, "\r\n" +
                        "                            DECLARE\r\n" +
                        "                               function_group_  VARCHAR2(10);\r\n" +
                        "                               check_deductible_ VARCHAR2(5) := 'FALSE';\r\n" +
                        "                            BEGIN                           \r\n" +
                        "                               function_group_ := &AO.Voucher_Type_Detail_API.Get_Function_Group( :i_hWndFrame.tbwExtTransactions.colCompany, \r\n" +
                        "                                                                                                                                                    :i_hWndFrame.tbwExtTransactions.colVoucherType);\r\n" +
                        "                              IF ( function_group_ IN ('M', 'K', 'Q')) THEN\r\n" +
                        "                                 check_deductible_ := 'TRUE';\r\n" +
                        "                               END IF;\r\n" +
                        "                               &AO.Account_Tax_Code_API.Check_Tax_Code(\r\n" +
                        "                                  :i_hWndFrame.tbwExtTransactions.sTaxHandlingValue,\r\n" +
                        "                                  :i_hWndFrame.tbwExtTransactions.colsTaxDirection,\r\n" +
                        "                                  :i_hWndFrame.tbwExtTransactions.colCompany,\r\n" +
                        "                                  :i_hWndFrame.tbwExtTransactions.colAccount,\r\n" +
                        "                                  :i_hWndFrame.tbwExtTransactions.colOptionalCode,\r\n" +
                        "                                  NULL,\r\n" +
                        "                                  NULL,\r\n" +
                        "                                  check_deductible_ );\r\n" +
                        "                           END;")))
                    {
                        colsTaxDirection.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        return false;
                    }
                }
                // Bug Bug 97225, End
                colsTaxDirection.EditDataItemSetEdited();
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
            SalNumber nItemIndex = 0;
            SalNumber nItemIndexLoadId = 0;
            SalNumber nRC = 0;
            SalNumber nRowCounter = 0;
            SalNumber nRows = 0;
            SalString sValueGet = "";
            SalArray<SalString> sLoadId = new SalArray<SalString>();
            SalString lsUserWhere = "";
            SalBoolean bFromDataTransfer = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    bFromDataTransfer = true;
                    if (nItemIndex != Ifs.Fnd.ApplicationForms.Const.DTTRF_ColumnNotFound)
                    {
                        nItemIndexLoadId = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("LOAD_ID");
                        nRows = Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet();
                        nRowCounter = 0;
                        lsUserWhere = "";
                        while (nRowCounter <= nRows - 1)
                        {
                            // Load Id
                            nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndexLoadId, nRowCounter, ref sValueGet);
                            sLoadId[nRowCounter] = sValueGet;
                            // build select statement if we call this function from voucher row
                            lsUserWhere = lsUserWhere + " (LOAD_ID = '" + sLoadId[nRowCounter] + "' )";
                            if (nRowCounter != nRows - 1)
                            {
                                lsUserWhere = lsUserWhere + " OR ";
                            }
                            nRowCounter = nRowCounter + 1;
                        }
                        // Send a message for building a new where-sentence
                        Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, lsUserWhere.ToHandle());

                        // Bug 84087, Begin, replaced POPULATE_Single by 0
                        // Populate the data source with selection from the new where-sentence
                        Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        // Bug 84087, End
                    }
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);
                }
                // Bug 110830, Rremoved method calls to GetProfileProperties and ApplyCodePartsChanges
                sIsProjectCodePart = GetCodePartFunction("PRACC");

                lsSelectStatment = "DECLARE " + " base_currency_code_		VARCHAR2(20); " + "BEGIN " + "base_currency_code_ := " + cSessionManager.c_sDbPrefix + "Company_Finance_API.Get_Currency_Code(:i_hWndFrame.tbwExtTransactions.i_sCompany ) ; " + ":i_hWndFrame.tbwExtTransactions.sBaseCurrencyCode := base_currency_code_ ; " +
                ":i_hWndFrame.tbwExtTransactions.sThirdCurrencyCode    := " + cSessionManager.c_sDbPrefix + "Company_Finance_API.Get_Parallel_Acc_Currency(:i_hWndFrame.tbwExtTransactions.i_sCompany , SYSDATE ); "+
                ":i_hWndFrame.tbwExtTransactions.sParallelBaseType     := " + cSessionManager.c_sDbPrefix + "Company_Finance_API.Get_Parallel_Base_Db(:i_hWndFrame.tbwExtTransactions.i_sCompany ); " + 
                ":i_hWndFrame.tbwExtTransactions.sCurrencyType         := " + cSessionManager.c_sDbPrefix + "Currency_Type_API.Get_Default_Type(:i_hWndFrame.tbwExtTransactions.i_sCompany ); " + ":i_hWndFrame.tbwExtTransactions.nAccDecimalsInAmount := " +
                cSessionManager.c_sDbPrefix + "Currency_Code_API.Get_Currency_Rounding(:i_hWndFrame.tbwExtTransactions.i_sCompany, base_currency_code_); " + " END;";
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Company_Finance_API.Get_Currency_Code", System.Data.ParameterDirection.Input);
                    hints.Add("Currency_Type_API.Get_Default_Type", System.Data.ParameterDirection.Input);
                    hints.Add("Currency_Code_API.Get_Currency_Rounding", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, lsSelectStatment)))
                    {
                        // Don't translate this message, this message only for programmer not user
                        Ifs.Fnd.ApplicationForms.Int.AlertBox("Design time error in funtion FrameStartupUser !", Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        return false;
                    }
                }
                if (bFromDataTransfer)
                    return false;
                else
                    return base.Activate(URL);
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
                return Properties.Resources.TEXT_TitleCorrectTrans;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataRecordValidate()
        {
            #region Local Variables
            SalWindowHandle hColumn_R = SalWindowHandle.Null;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nRow = Sal.TblQueryContext(i_hWndSelf);
                if (!(Sal.TblQueryRowFlags(i_hWndSelf, nRow, Sys.ROW_MarkDeleted)))
                {
                    if (!(CheckMandatoryCodeParts(ref hColumn_R)))
                    {
                        DataRecordShowRequired(hColumn_R);
                        Sal.WaitCursor(false);
                        return false;
                    }
                }
                if (colAccount.EditDataItemStateGet() & Ifs.Fnd.ApplicationForms.Const.EDIT_Changed)
                {
                    colCodeB.EditDataItemSetEdited();
                    colCodeC.EditDataItemSetEdited();
                    colCodeD.EditDataItemSetEdited();
                    colCodeE.EditDataItemSetEdited();
                    colCodeF.EditDataItemSetEdited();
                    colCodeG.EditDataItemSetEdited();
                    colCodeH.EditDataItemSetEdited();
                    colCodeI.EditDataItemSetEdited();
                    colCodeJ.EditDataItemSetEdited();
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ShowHideCodeParts()
        {
            #region Actions
            using (new SalContext(this))
            {
                ColumnUsedVisibility();
                ForceColumnUsedVisibility();
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ColumnUsedVisibility()
        {
            #region Actions
            using (new SalContext(this))
            {
                // The code part description is included in the numeration of bVisable
                if (cFinlibServices.lsDisplayCodePart[1] == "N")
                {
                    bVisible[2] = 0;
                }
                else
                {
                    bVisible[2] = 1;
                }
                if (cFinlibServices.lsDisplayCodePart[2] == "N")
                {
                    bVisible[4] = 0;
                }
                else
                {
                    bVisible[4] = 1;
                }
                if (cFinlibServices.lsDisplayCodePart[3] == "N")
                {
                    bVisible[6] = 0;
                }
                else
                {
                    bVisible[6] = 1;
                }
                if (cFinlibServices.lsDisplayCodePart[4] == "N")
                {
                    bVisible[8] = 0;
                }
                else
                {
                    bVisible[8] = 1;
                }
                if (cFinlibServices.lsDisplayCodePart[5] == "N")
                {
                    bVisible[10] = 0;
                }
                else
                {
                    bVisible[10] = 1;
                }
                if (cFinlibServices.lsDisplayCodePart[6] == "N")
                {
                    bVisible[12] = 0;
                }
                else
                {
                    bVisible[12] = 1;
                }
                if (cFinlibServices.lsDisplayCodePart[7] == "N")
                {
                    bVisible[14] = 0;
                }
                else
                {
                    bVisible[14] = 1;
                }
                if (cFinlibServices.lsDisplayCodePart[8] == "N")
                {
                    bVisible[16] = 0;
                }
                else
                {
                    bVisible[16] = 1;
                }
                if (cFinlibServices.lsDisplayCodePart[9] == "N")
                {
                    bVisible[18] = 0;
                }
                else
                {
                    bVisible[18] = 1;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ForceColumnUsedVisibility()
        {
            #region Local Variables
            SalNumber nFirstFreeCodePart = 0;
            SalWindowHandle hWndCurColCodePart = SalWindowHandle.Null;
            SalWindowHandle hWndCurColCodePartDesc = SalWindowHandle.Null;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nFirstFreeCodePart = Sal.TblQueryColumnID(colCodeB);
                nTemp = 2;
                while (true)
                {
                    hWndCurColCodePart = Sal.TblGetColumnWindow(i_hWndSelf, nFirstFreeCodePart + nTemp - 2, Sys.COL_GetID);
                    hWndCurColCodePartDesc = Sal.TblGetColumnWindow(i_hWndSelf, nFirstFreeCodePart + nTemp - 1, Sys.COL_GetID);
                    if (bVisible[nTemp])
                    {
                        Sal.ShowWindow(hWndCurColCodePart);
                        Sal.ShowWindow(hWndCurColCodePartDesc);
                    }
                    else
                    {
                        Sal.HideWindow(hWndCurColCodePart);
                        Sal.HideWindow(hWndCurColCodePartDesc);
                    }
                    nTemp = nTemp + 2;
                    if (nTemp == 20)
                    {
                        break;
                    }
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ClearBlockedCodeParts()
        {
            #region Local Variables
            SalString sMyDemand = "";
            SalNumber nColumnId = 0;
            SalNumber nId = 0;
            SalWindowHandle hWndCol = SalWindowHandle.Null;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                // Loop thru the Free Code Part Columns
                // Get to the Free Code Parts
                nColumnId = Sal.TblQueryColumnID(colCodeB);
                nId = 1;
                // Get the Demand of each column from colCodePartDemand
                // For the columns where demand set to 'S', clear the field using SalClearField() function
                while (nId < 10)
                {
                    hWndCol = Sal.TblGetColumnWindow(i_hWndSelf, nColumnId + nId - 1, Sys.COL_GetID);
                    sMyDemand = GetMyDemand(hWndCol);
                    if (!(Sal.IsNull(hWndCol)) && sMyDemand == "S")
                    {
                        Sal.ClearField(hWndCol);
                    }
                    nId = nId + 1;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="hWindow"></param>
        /// <returns></returns>
        public virtual SalString GetMyDemand(SalWindowHandle hWindow)
        {
            #region Local Variables
            SalString sColName = "";
            SalNumber nCodePartNum = 0;
            SalString sMyDemand = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.GetItemName(hWindow, ref sColName);
                if (sColName.Scan("DESC") != -1)
                {
                    sColName = sColName.Left(8);
                }
                nCodePartNum = ((SalString)"BCDEFGHIJ").Scan(sColName.Right(1));
                sMyDemand = ((SalString)colCodePartsDemand.Text).Mid(nCodePartNum * 2 + 1, 1);
                return sMyDemand;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="hPWindow"></param>
        /// <returns></returns>
        public virtual SalBoolean SetFocusCodePart(SalWindowHandle hPWindow)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (AmIBlocked(hPWindow))
                {
                    // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                    System.Windows.Forms.SendKeys.Send("{TAB}");
                    return false;
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="hWindow"></param>
        /// <returns></returns>
        public virtual SalBoolean AmIBlocked(SalWindowHandle hWindow)
        {
            #region Local Variables
            SalString sMyDemand = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sMyDemand = GetMyDemand(hWindow);
                if (sMyDemand == "S")
                {
                    return true;
                }
                return false;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="hPColumn"></param>
        /// <returns></returns>
        public virtual SalNumber CheckMandatoryCodeParts(ref SalWindowHandle hPColumn)
        {
            #region Local Variables
            SalArray<SalWindowHandle> hColCodePart = new SalArray<SalWindowHandle>(9);
            SalString sCodePartDemand = "";
            SalNumber nStrLen = 0;
            SalNumber nCodePartNum = 0;
            SalNumber nIndex = 0;
            SalNumber nCount = 0;
            SalString sColName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sCodePartDemand = colCodePartsDemand.Text;
                nTemp = ((SalString)colCodePartsDemand.Text).Scan("M");
                hPColumn = SalWindowHandle.Null;
                if (nTemp == -1)
                {
                    // everything is OK !
                    return true;
                }
                else
                {
                    // Make an array of CodePart Window handles
                    nTemp = Sal.TblQueryColumnID(colCodeB);
                    nCount = 0;
                    nIndex = 0;
                    while (nCount < 18)
                    {
                        // Bug 68760, Begin. Changed first argument from tbwExtTransactions to i_hWndFrame
                        hWndTemp = Sal.TblGetColumnWindow(i_hWndFrame, nTemp + nCount, Sys.COL_GetID);
                        // Bug 68760, End
                        Sal.GetItemName(hWndTemp, ref sColName);
                        // Do not include the description columns
                        if (sColName.Scan("DESC") == -1)
                        {
                            hColCodePart[nIndex] = hWndTemp;
                            nIndex = nIndex + 1;
                        }
                        nCount = nCount + 1;
                    }
                    // Get the Code Part Number(B is 0, J is 9)  of Mandatory column that is left NULL
                    // This code will not work if Code Part Number is of two digits
                    nTemp = 0;
                    nStrLen = sCodePartDemand.Length;
                    while (true)
                    {
                        nTemp = sCodePartDemand.Scan("M");
                        if (nTemp == -1)
                        {
                            return true;
                        }
                        sCodePartDemand = sCodePartDemand.Right(nStrLen - nTemp - 1);
                        nStrLen = sCodePartDemand.Length;
                        nCodePartNum = nCodePartNum + (nTemp + 1) / 2;
                        if (Sal.IsNull(hColCodePart[nCodePartNum - 1]))
                        {
                            // Return the Handle of the column that is Mandatory and Null
                            hPColumn = hColCodePart[nCodePartNum - 1];
                            return false;
                        }
                    }
                    return true;
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sCodepart"></param>
        /// <returns></returns>
        public virtual SalNumber CheckProjActivityBlocked(SalString sCodepart)
        {
            #region Actions
            using (new SalContext(this))
            {
                sDummyCodePart = sCodepart;
                if (!(Sal.IsNull(colnProjectActivityId)))
                {
                    Sal.ClearField(colnProjectActivityId);
                    colnProjectActivityId.EditDataItemSetEdited();
                }
                if (Ifs.Application.Accrul.Int.IsGenLedInstalled && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Project_Api.Get_Externally_Created"))
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Accounting_Project_Api.Get_Externally_Created", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                            "	      :i_hWndFrame.tbwExtTransactions.sIsProjectExternallyCreated  :=  \r\n" +
                            "	       &AO.Accounting_Project_Api.Get_Externally_Created(\r\n" +
                            "      	      :i_hWndFrame.tbwExtTransactions.i_sCompany,\r\n" +
                            "                      :i_hWndFrame.tbwExtTransactions.sDummyCodePart );\r\n	 END; ")))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    sIsProjectExternallyCreated = "Y";
                }
                if (sIsProjectExternallyCreated == "Y")
                {
                    sProjActivityBlockedFlag = "TRUE";
                }
                else
                {
                    sProjActivityBlockedFlag = "FALSE";
                }
                if ((sCodepart == Ifs.Fnd.ApplicationForms.Const.strNULL) || (sIsProjectExternallyCreated == "N"))
                {
                    Sal.ClearField(colnProjectActivityId);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// Get multiplier to make decimals rounding
        /// </summary>
        /// <param name="nDecimals"></param>
        /// <returns></returns>
        public virtual SalNumber GetMultiplier(SalNumber nDecimals)
        {
            #region Local Variables
            SalNumber nMultiplier = 0;
            SalString sMultiplier = "";
            SalNumber nDec = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sMultiplier = "1";
                nDec = 0;
                while (nDec < nDecimals)
                {
                    sMultiplier = sMultiplier + "0";
                    nDec = nDec + 1;
                }
                nMultiplier = sMultiplier.ToNumber();
                return nMultiplier;
            }
            #endregion
        }

        /// <summary>
        /// Round number of decimals
        /// </summary>
        /// <param name="nValue"></param>
        /// <param name="nNumberOfDecimals"></param>
        /// <returns></returns>
        public virtual SalNumber RoundedDecimals(SalNumber nValue, SalNumber nNumberOfDecimals)
        {
            #region Local Variables
            SalNumber nMult = 0;
            SalNumber nNeValue = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (nValue == SalNumber.Null)
                {
                    return nValue;
                }
                if (nNumberOfDecimals == 0)
                {
                    return nValue.Round();
                }
                nMult = GetMultiplier(nNumberOfDecimals);
                if (nValue < 0)
                {
                    nNeValue = -nValue;
                    nNeValue = (nNeValue * nMult).Round();
                    nValue = -nNeValue;
                }
                else
                {
                    nValue = (nValue * nMult).Round();
                }
                return nValue / nMult;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nMyValue"></param>
        /// <param name="hWndRival"></param>
        /// <param name="nDecimalsCurrent"></param>
        /// <param name="nDecimalsRival"></param>
        /// <param name="sStatus"></param>
        /// <returns></returns>
        public virtual SalNumber SetAnotherValue(SalNumber nMyValue, SalWindowHandle hWndRival, SalNumber nDecimalsCurrent, SalNumber nDecimalsRival, SalString sStatus)
        {
            #region Local Variables
            SalNumber nCalculateValue = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sStatus == "CURRENT_AMOUNT")
                {
                    if (nMyValue == SalNumber.Null)
                    {
                        colAmount.Number = Sys.NUMBER_Null;
                        colAmount.EditDataItemSetEdited();
                        colCurrencyAmount.Number = Sys.NUMBER_Null;
                        colCurrencyAmount.EditDataItemSetEdited();
                        Sal.SendMsg(hWndRival, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                    }
                    else
                    {
                        nMyValue = RoundedDecimals(nMyValue, nDecimalsCurrent);
                        if (colCurrencyRateType.Text != SalString.Null)
                        {
                            sCurrencyType = colCurrencyRateType.Text;
                        }
                        // Bug 71809 Start
                        // Call i_hWndFrame.tbwExtTransactions.GetAttributes(colCompany, colCurrencyCode, sBaseCurrencyCode, sCurrencyType, colTransactionDate)
                        tbwExtTransactions.FromHandle(i_hWndFrame).GetAttributes(colCompany.Text, colCurrencyCode.Text, sBaseCurrencyCode, sCurrencyType, coldVoucherDate.DateTime);
                        // Bug 71809 End
                        tbwExtTransactions.FromHandle(i_hWndFrame).GetBaseCurrencyAmount(nMyValue, ref nCalculateValue);
                        Sal.SendMsg(colAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, nCalculateValue.ToString(nDecimalsRival).ToHandle());
                        colAmount.EditDataItemSetEdited();
                        colCurrencyAmount.Number = nMyValue;
                        colCurrencyAmount.EditDataItemSetEdited();
                        if (nCalculateValue < 0 && colCorrection.Text == "FALSE" || nCalculateValue > 0 && colCorrection.Text == "TRUE")
                        {
                            nCalculateValue = -nCalculateValue;
                        }
                        Sal.SendMsg(hWndRival, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, nCalculateValue.ToString(nDecimalsRival).ToHandle());
                    }
                }
                if (sStatus == "ACCOUNTING_AMOUNT")
                {
                    nMyValue = RoundedDecimals(nMyValue, nDecimalsCurrent);
                    colAmount.Number = nMyValue;
                    colAmount.EditDataItemSetEdited();
                    if (colCurrencyCode.Text == sBaseCurrencyCode)
                    {
                        colCurrencyAmount.Number = nMyValue;
                        colCurrencyAmount.EditDataItemSetEdited();
                        if (nMyValue < 0 && colCorrection.Text == "FALSE" || nMyValue > 0 && colCorrection.Text == "TRUE")
                        {
                            Sal.SendMsg(hWndRival, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, (-nMyValue).ToString(nDecimalsCurrent).ToHandle());
                        }
                        else
                        {
                            Sal.SendMsg(hWndRival, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, nMyValue.ToString(nDecimalsCurrent).ToHandle());
                        }
                    }
                    else if (colCurrencyCode.Text != sBaseCurrencyCode && nMyValue != SalNumber.Null)
                    {
                        if (colAmount.Number < 0)
                        {
                            if (colCurrencyAmount.Number > 0)
                            {
                                colCurrencyCreditAmount.Number = colCurrencyAmount.Number;
                                colCurrencyAmount.Number = -colCurrencyAmount.Number;
                            }
                            Sal.SendMsg(colCurrencyDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                        }
                        else if (colAmount.Number > 0)
                        {
                            if (colCurrencyAmount.Number < 0)
                            {
                                colCurrencyDebetAmount.Number = -colCurrencyAmount.Number;
                                colCurrencyAmount.Number = -colCurrencyAmount.Number;
                            }
                            Sal.SendMsg(colCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                        }
                        // Can get displayed the Rate
                    }
                }

                this.SetThirdCurrencyAmounts();
                return nMyValue;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateCurrencyCode()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (!(Sal.IsNull(colCurrencyCode)))
                {
                    lsSelectStatment = "DECLARE " + " base_currency_code_		VARCHAR2(20); " + "BEGIN " + "base_currency_code_ := " + cSessionManager.c_sDbPrefix + "Company_Finance_API.Get_Currency_Code(:i_hWndFrame.tbwExtTransactions.i_sCompany ); " + ":i_hWndFrame.tbwExtTransactions.sBaseCurrencyCode := base_currency_code_ ; " +
                    ":i_hWndFrame.tbwExtTransactions.sCurrencyType         := " + cSessionManager.c_sDbPrefix + "Currency_Type_API.Get_Default_Type(:i_hWndFrame.tbwExtTransactions.i_sCompany ); " + ":i_hWndFrame.tbwExtTransactions.nAccDecimalsInAmount := " +
                    cSessionManager.c_sDbPrefix + "Currency_Code_API.Get_Currency_Rounding(:i_hWndFrame.tbwExtTransactions.i_sCompany, base_currency_code_); " + " END;";
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Company_Finance_API.Get_Currency_Code", System.Data.ParameterDirection.Input);
                        hints.Add("Currency_Type_API.Get_Default_Type", System.Data.ParameterDirection.Input);
                        hints.Add("Currency_Code_API.Get_Currency_Rounding", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        DbPLSQLBlock(cSessionManager.c_hSql, lsSelectStatment);
                    }
                    if (coldVoucherDate.DateTime == Sys.DATETIME_Null)
                    {
                        GetVoucherDate();
                    }
                    // ! Bug 71809 Start
                    // ! If Not GetAttributes(colCompany,colCurrencyCode,sBaseCurrencyCode,sCurrencyType,colTransactionDate)
                    // Return FALSE
                    if (!(GetAttributes(colCompany.Text, colCurrencyCode.Text, sBaseCurrencyCode, sCurrencyType, coldVoucherDate.DateTime)))
                    {
                        return false;
                    }
                    // ! Bug 71809 End
                    nCurrencyRate = GetRate(colCompany.Text, colCurrencyCode.Text);
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Currency_Code_API.Get_Currency_Rounding", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                            "	      :i_hWndFrame.tbwExtTransactions.nDecimalsInAmount :=  \r\n" +
                            "	      &AO.Currency_Code_API.Get_Currency_Rounding(\r\n" +
                            "      	     :i_hWndFrame.tbwExtTransactions.i_sCompany,\r\n" +
                            "                     :i_hWndFrame.tbwExtTransactions.colCurrencyCode);\r\n	 END; ")))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateValues()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (Sal.IsNull(colTransactionDate))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoTransactionDate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                    return false;
                }
                else if (Sal.IsNull(colCurrencyCode))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoCurrencyCode, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            #endregion
        }

        /// <summary>
        /// To Execute  CheckProjActivityBlocked for the Project Code Part
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ExecCheckProjActivityBlocked()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (sIsProjectCodePart == "B")
                {
                    CheckProjActivityBlocked(colCodeB.Text);
                }
                else
                {
                    if (sIsProjectCodePart == "C")
                    {
                        CheckProjActivityBlocked(colCodeC.Text);
                    }
                    else
                    {
                        if (sIsProjectCodePart == "D")
                        {
                            CheckProjActivityBlocked(colCodeD.Text);
                        }
                        else
                        {
                            if (sIsProjectCodePart == "E")
                            {
                                CheckProjActivityBlocked(colCodeE.Text);
                            }
                            else
                            {
                                if (sIsProjectCodePart == "F")
                                {
                                    CheckProjActivityBlocked(colCodeF.Text);
                                }
                                else
                                {
                                    if (sIsProjectCodePart == "G")
                                    {
                                        CheckProjActivityBlocked(colCodeG.Text);
                                    }
                                    else
                                    {
                                        if (sIsProjectCodePart == "H")
                                        {
                                            CheckProjActivityBlocked(colCodeH.Text);
                                        }
                                        else
                                        {
                                            if (sIsProjectCodePart == "I")
                                            {
                                                CheckProjActivityBlocked(colCodeI.Text);
                                            }
                                            else
                                            {
                                                if (sIsProjectCodePart == "J")
                                                {
                                                    CheckProjActivityBlocked(colCodeJ.Text);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sCodePart"></param>
        /// <returns></returns>
        public virtual SalNumber FetchDescription(SalString sCodePart)
        {
            #region Actions
            using (new SalContext(this))
            {
                // Security check
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Text_Field_Translation_API.Get_Text"))
                {
                    lsStmt = SalString.Null;
                    if (Sal.IsWindowVisible(colAccountDesc) && (sCodePart == "A"))
                    {
						if (colAccount.Text == Sys.STRING_Null) 
						{
							colAccountDesc.Text = Sys.STRING_Null;
							return 0;
						}
                        lsStmt = lsStmt + ":i_hWndFrame.tbwExtTransactions.colAccountDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwExtTransactions.colCompany,'CODEA', :i_hWndFrame.tbwExtTransactions.colAccount); ";
                    }
                    else if (Sal.IsWindowVisible(colCodeBDesc) && (sCodePart == "B"))
                    {
						if (colCodeB.Text == Sys.STRING_Null) 
						{
							colCodeBDesc.Text = Sys.STRING_Null;
							return 0;
						}
                        lsStmt = lsStmt + ":i_hWndFrame.tbwExtTransactions.colCodeBDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwExtTransactions.colCompany,'CODEB', :i_hWndFrame.tbwExtTransactions.colCodeB); ";
                    }
                    else if (Sal.IsWindowVisible(colCodeCDesc) && (sCodePart == "C"))
                    {
						if (colCodeC.Text == Sys.STRING_Null) 
						{
							colCodeCDesc.Text = Sys.STRING_Null;
							return 0;
						}
                        lsStmt = lsStmt + ":i_hWndFrame.tbwExtTransactions.colCodeCDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwExtTransactions.colCompany,'CODEC', :i_hWndFrame.tbwExtTransactions.colCodeC); ";
                    }
                    else if (Sal.IsWindowVisible(colCodeDDesc) && (sCodePart == "D"))
                    {
						if (colCodeD.Text == Sys.STRING_Null) 
						{
							colCodeDDesc.Text = Sys.STRING_Null;
							return 0;
						}
                        lsStmt = lsStmt + ":i_hWndFrame.tbwExtTransactions.colCodeDDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwExtTransactions.colCompany,'CODED', :i_hWndFrame.tbwExtTransactions.colCodeD); ";
                    }
                    else if (Sal.IsWindowVisible(colCodeEDesc) && (sCodePart == "E"))
                    {
						if (colCodeE.Text == Sys.STRING_Null) 
						{
							colCodeEDesc.Text = Sys.STRING_Null;
							return 0;
						}
                        lsStmt = lsStmt + ":i_hWndFrame.tbwExtTransactions.colCodeEDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwExtTransactions.colCompany,'CODEE', :i_hWndFrame.tbwExtTransactions.colCodeE); ";
                    }
                    else if (Sal.IsWindowVisible(colCodeFDesc) && (sCodePart == "F"))
                    {
						if (colCodeF.Text == Sys.STRING_Null) 
						{
							colCodeFDesc.Text = Sys.STRING_Null;
							return 0;
						}
                        lsStmt = lsStmt + ":i_hWndFrame.tbwExtTransactions.colCodeFDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwExtTransactions.colCompany,'CODEF', :i_hWndFrame.tbwExtTransactions.colCodeF); ";
                    }
                    else if (Sal.IsWindowVisible(colCodeGDesc) && (sCodePart == "G"))
                    {
						if (colCodeG.Text == Sys.STRING_Null) 
						{
							colCodeGDesc.Text = Sys.STRING_Null;
							return 0;
						}
                        lsStmt = lsStmt + ":i_hWndFrame.tbwExtTransactions.colCodeGDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwExtTransactions.colCompany,'CODEG', :i_hWndFrame.tbwExtTransactions.colCodeG); ";
                    }
                    else if (Sal.IsWindowVisible(colCodeHDesc) && (sCodePart == "H"))
                    {
						if (colCodeH.Text == Sys.STRING_Null) 
						{
							colCodeHDesc.Text = Sys.STRING_Null;
							return 0;
						}
                        lsStmt = lsStmt + ":i_hWndFrame.tbwExtTransactions.colCodeHDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwExtTransactions.colCompany,'CODEH', :i_hWndFrame.tbwExtTransactions.colCodeH); ";
                    }
                    else if (Sal.IsWindowVisible(colCodeIDesc) && (sCodePart == "I"))
                    {
						if (colCodeI.Text == Sys.STRING_Null) 
						{
							colCodeIDesc.Text = Sys.STRING_Null;
							return 0;
						}
                        lsStmt = lsStmt + ":i_hWndFrame.tbwExtTransactions.colCodeIDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwExtTransactions.colCompany,'CODEI', :i_hWndFrame.tbwExtTransactions.colCodeI); ";
                    }
                    else if (Sal.IsWindowVisible(colCodeJDesc) && (sCodePart == "J"))
                    {
						if (colCodeJ.Text == Sys.STRING_Null) 
						{
							colCodeJDesc.Text = Sys.STRING_Null;
							return 0;
						}
                        lsStmt = lsStmt + ":i_hWndFrame.tbwExtTransactions.colCodeJDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwExtTransactions.colCompany,'CODEJ', :i_hWndFrame.tbwExtTransactions.colCodeJ); ";
                    }
                    Sal.WaitCursor(true);
                    if (lsStmt != SalString.Null)
                    {
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Text_Field_Translation_API.Get_Text", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + lsStmt + "END;");
                        }
                    }
                    Sal.WaitCursor(false);
                }
            }

            return 0;
            #endregion
        }

        // Bug 71024,  removed SetCorrection() and use colsCorrectionParam
        // Bug 110830, Removed methods GetProfileProperties and ApplyCodePartChanges
        // Bug 71024, Begin
        /// <summary>
        /// </summary>
        /// <param name="sCorrectionFlg"></param>
        /// <returns></returns>
        public virtual SalNumber SetSignForAllAmounts(SalString sCorrectionFlg)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (sCorrectionFlg == "TRUE" || sCorrectionFlg == "FALSE")
                {
                    if (colCurrencyCreditAmount.Number != Sys.NUMBER_Null)
                    {
                        colCurrencyCreditAmount.Number = -colCurrencyCreditAmount.Number;
                        colCurrencyCreditAmount.EditDataItemSetEdited();
                    }
                    if (colCurrencyDebetAmount.Number != Sys.NUMBER_Null)
                    {
                        colCurrencyDebetAmount.Number = -colCurrencyDebetAmount.Number;
                        colCurrencyDebetAmount.EditDataItemSetEdited();
                    }
                    if (colCurrencyAmount.Number != Sys.NUMBER_Null)
                    {
                        colCurrencyAmount.Number = -colCurrencyAmount.Number;
                        colCurrencyAmount.EditDataItemSetEdited();
                    }
                    if (colDebetAmount.Number != Sys.NUMBER_Null)
                    {
                        colDebetAmount.Number = -colDebetAmount.Number;
                        colDebetAmount.EditDataItemSetEdited();
                    }
                    if (colCreditAmount.Number != Sys.NUMBER_Null)
                    {
                        colCreditAmount.Number = -colCreditAmount.Number;
                        colCreditAmount.EditDataItemSetEdited();
                    }
                    if (colAmount.Number != Sys.NUMBER_Null)
                    {
                        colAmount.Number = -colAmount.Number;
                        colAmount.EditDataItemSetEdited();
                    }
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nChkValue"></param>
        /// <returns></returns>
        public virtual SalNumber SetCurrencyDebitAmntFirst(ref SalNumber p_nChkValue)
        {
            #region Actions
            using (new SalContext(this))
            {
                // first set the currency debit amount and then debit amount
                Sal.SendMsg(colCurrencyDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, p_nChkValue.ToString(nDecimalsInAmount).ToHandle());
                Sal.SendMsg(colCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                Sal.SendMsg(colCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                p_nChkValue = SetAnotherValue(p_nChkValue, colDebetAmount, nDecimalsInAmount, nAccDecimalsInAmount, "CURRENT_AMOUNT");
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nChkValue"></param>
        /// <returns></returns>
        public virtual SalNumber SetCurrencyCreditAmntFirst(ref SalNumber p_nChkValue)
        {
            #region Actions
            using (new SalContext(this))
            {
                // first set the currency credit amount and then credit amount
                Sal.SendMsg(colCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, (-p_nChkValue).ToString(nDecimalsInAmount).ToHandle());
                Sal.SendMsg(colCurrencyDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                Sal.SendMsg(colDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                p_nChkValue = SetAnotherValue(p_nChkValue, colCreditAmount, nDecimalsInAmount, nAccDecimalsInAmount, "CURRENT_AMOUNT");
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nChkValue"></param>
        /// <returns></returns>
        public virtual SalNumber SetDebitAmntFirst(ref SalNumber p_nChkValue)
        {
            #region Actions
            using (new SalContext(this))
            {
                // first set debit amount and then currency debit amount
                Sal.SendMsg(colDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, p_nChkValue.ToString(nAccDecimalsInAmount).ToHandle());
                Sal.SendMsg(colCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                if (colCurrencyCode.Text == sBaseCurrencyCode)
                {
                    Sal.SendMsg(colCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
                p_nChkValue = SetAnotherValue(p_nChkValue, colCurrencyDebetAmount, nAccDecimalsInAmount, nDecimalsInAmount, "ACCOUNTING_AMOUNT");
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_nChkValue"></param>
        /// <returns></returns>
        public virtual SalNumber SetCreditAmntFirst(ref SalNumber p_nChkValue)
        {
            #region Actions
            using (new SalContext(this))
            {
                // first set credit amount and then currency credit amount
                Sal.SendMsg(colCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, (-p_nChkValue).ToString(nAccDecimalsInAmount).ToHandle());
                Sal.SendMsg(colDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                if (colCurrencyCode.Text == sBaseCurrencyCode)
                {
                    Sal.SendMsg(colCurrencyDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
                p_nChkValue = SetAnotherValue(p_nChkValue, colCurrencyCreditAmount, nAccDecimalsInAmount, nDecimalsInAmount, "ACCOUNTING_AMOUNT");
            }

            return 0;
            #endregion
        }
        // Bug 71024, End
        // Bug 92374 , begin
        /// <summary>
        /// </summary>
        /// <param name="p_sSqlName"></param>
        /// <param name="p_sCodepartValue"></param>
        /// <returns></returns>
        public virtual SalBoolean GetCodestringCmpl(SalString p_sSqlName, SalString p_sCodepartValue)
        {
            #region Local Variables
            SalNumber nCodestrCmplModfyCount = 0;
            SalNumber nCodestrCmplNoCount = 0;
            SalString sCallCodepart = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                AttrFetchCodePart(ref sRequiredStringComplete, Sal.TblQueryContext(i_hWndSelf));
                sColValue = p_sCodepartValue;
                sCallCodepart = p_sSqlName;
                if (p_sSqlName == "ACCOUNT")
                {
                    sColSqlName = "A";
                }
                else if (p_sSqlName.Scan("CODE\\_") != -1)
                {
                    sColSqlName = p_sSqlName.Right(1);
                }
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Ext_Transactions_API.Get_Ext_Complete_Code_Str__", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.tbwExtTransactions.sCodestringCmpl :=\r\n" +
                        "			&AO.Ext_Transactions_API.Get_Ext_Complete_Code_Str__(\r\n" +
                        "			:i_hWndFrame.tbwExtTransactions.colCompany,\r\n" +
                        "                                                 :i_hWndFrame.tbwExtTransactions.colLoadId,\r\n" +
                        "                                                :i_hWndFrame.tbwExtTransactions.sColSqlName,\r\n" +
                        "                                                :i_hWndFrame.tbwExtTransactions.sColValue )")))
                    {
                        return false;
                    }
                    else
                    {
                        if (sCodestringCmpl != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            sAccntMdfy = "FALSE";
                            ScanAttributeString(sCodestringCmpl, ref nCodestrCmplModfyCount, ref nCodestrCmplNoCount);
                            SetCodestringCmpl(sRequiredStringComplete);
                            // colsModifyCodestrCmpl = 'ACCNT' to check tax and tax calculations , colsModifyCodestrCmpl = 'FALSE' to re-check code string completion , TRUE to ingnore re-check
                            if (sCallCodepart == "ACCOUNT" || sAccntMdfy == "TRUE")
                            {
                                colsModifyCodestrCmpl.Text = "ACCNT";
                            }
                            else if (nCodestrCmplNoCount == 1 && nCodestrCmplModfyCount > 0)
                            {
                                colsModifyCodestrCmpl.Text = "TRUE";
                            }
                            else
                            {
                                colsModifyCodestrCmpl.Text = "TRUE";
                            }
                        }
                        else
                        {
                            if (sCallCodepart == "ACCOUNT")
                            {
                                colsModifyCodestrCmpl.Text = "ACCNT";
                            }
                        }
                        colsModifyCodestrCmpl.EditDataItemSetEdited();
                        return true;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sPAttr"></param>
        /// <param name="nRowCount"></param>
        /// <returns></returns>
        public virtual new SalBoolean AttrFetchCodePart(ref SalString sPAttr, SalNumber nRowCount)
        {
            #region Local Variables
            SalNumber n = 0;
            SalString sSqlColumn = "";
            SalString sValue = "";
            SalString sPrevAccount = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (i_sSqlColumn != "ACCOUNT")
                {
                    sPrevAccount = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("ACCOUNT", sPAttr);
                }
                else
                {
                    sPrevAccount = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
                Sal.TblSetContext(i_hWndSelf, nRowCount);
                sPAttr = Ifs.Fnd.ApplicationForms.Const.strNULL;
                n = 0;
                while (n < i_nChildCount)
                {                    
                    if ((Sal.WindowClassName(i_hWndChild[n]) == "cColumnFin") || (Sal.WindowClassName(i_hWndChild[n]) == "cColumn"))
                    {
                        sSqlColumn = cColumn.FromHandle(i_hWndChild[n]).p_sSqlColumn;
                        if ((sSqlColumn == "ACCOUNT" || sSqlColumn == "CODE_B" || sSqlColumn == "CODE_C" || sSqlColumn == "CODE_D" || sSqlColumn == "CODE_E" || sSqlColumn == "CODE_F" || sSqlColumn == "CODE_G" || sSqlColumn == "CODE_H" || sSqlColumn == "CODE_I" ||
                        sSqlColumn == "CODE_J" || sSqlColumn == "PROCESS_CODE") && ((bool)Sal.SendMsg(i_hWndChild[n], Ifs.Fnd.ApplicationForms.Const.PM_DataItemFlagQuery, Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, 0)))
                        {
                            sValue = SalString.FromHandle(Sal.SendMsg(i_hWndChild[n], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0));
                            sPAttr = sPAttr + sSqlColumn + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + sValue + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
                        }
                    }
                    n = n + 1;
                }
                if (sPrevAccount != Ifs.Fnd.ApplicationForms.Const.strNULL && sPrevAccount != Ifs.Fnd.ApplicationForms.Int.PalAttrGet("ACCOUNT", sPAttr))
                {
                    sPrevAccount = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("ACCOUNT", sPAttr);
                    sPrevAccount = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
                Ifs.Fnd.ApplicationForms.Var.Console.TextAdd(Ifs.Fnd.ApplicationForms.Const.CONS_Debug, "~~AttrFetchCodePart( '" + sPAttr + "'~~");
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_sString"></param>
        /// <param name="p_nCodestrCmplModfyCount"></param>
        /// <param name="p_nCodestrCmplNoCount"></param>
        /// <returns></returns>
        public virtual SalNumber ScanAttributeString(SalString p_sString, ref SalNumber p_nCodestrCmplModfyCount, ref SalNumber p_nCodestrCmplNoCount)
        {
            #region Local Variables
            SalBoolean bReplace = false;
            SalBoolean bNoReplace = false;
            SalNumber nPos1 = 0;
            SalNumber nPos2 = 0;
            SalNumber nLength = 0;
            SalNumber nChoice = 0;
            SalString sTmp_CodePart = "";
            SalString sTmpString = "";
            SalString sTmp_Value = "";
            SalString sUnitChar = "";
            SalString sRecChar = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (p_sString != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    sTmpString = p_sString;
                    nLength = sTmpString.Length;
                    sUnitChar = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter();
                    sRecChar = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
                    while (sTmpString != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        nPos1 = sTmpString.Scan(sUnitChar);
                        sTmp_CodePart = sTmpString.Left(nPos1);
                        nPos2 = sTmpString.Scan(sRecChar);
                        sTmp_Value = sTmpString.Mid(nPos1 + 1, nPos2 - nPos1 - 1);
                        if (sTmp_CodePart == "ACCOUNT" && sTmp_Value != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            sAccntMdfy = "TRUE";
                        }
                        if (sTmp_Value != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            if ((Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sTmp_CodePart, sRequiredStringComplete) == Ifs.Fnd.ApplicationForms.Const.strNULL) || bReplace)
                            {
                                ModifyRequiredString(sTmp_CodePart, sTmp_Value);
                                p_nCodestrCmplModfyCount = p_nCodestrCmplModfyCount + 1;
                            }
                            else
                            {
                                if (Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sTmp_CodePart, sRequiredStringComplete) != sTmp_Value)
                                {
                                    // Prompt User
                                    nChoice = Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.TEXT_OverwriteCodeParts, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2));
                                    if (nChoice == Sys.IDYES)
                                    {
                                        // Replace values in sRequiredStringComplete with new values
                                        ModifyRequiredString(sTmp_CodePart, sTmp_Value);
                                        p_nCodestrCmplModfyCount = p_nCodestrCmplModfyCount + 1;
                                        bReplace = true;
                                    }
                                    else
                                    {
                                        bNoReplace = true;
                                        p_nCodestrCmplNoCount = p_nCodestrCmplNoCount + 1;
                                    }
                                }
                                p_nCodestrCmplModfyCount = p_nCodestrCmplModfyCount + 1;
                            }
                        }
                        if (bNoReplace)
                        {
                            sTmpString = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        }
                        else
                        {
                            sTmpString = sTmpString.Mid(nPos2 + 1, nLength);
                        }
                    }
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_sCodePart"></param>
        /// <param name="p_sCodePartValue"></param>
        /// <returns></returns>
        public virtual new SalNumber ModifyRequiredString(SalString p_sCodePart, SalString p_sCodePartValue)
        {
            #region Local Variables
            SalNumber nPos = 0;
            SalNumber nLength = 0;
            SalNumber nPosUnitDelim = 0;
            SalNumber nPosRecDelim = 0;
            SalNumber nPosStr = 0;
            SalString sStrTmp = "";
            SalString sStr1 = "";
            SalString sStr2 = "";
            SalString sNewRequiredString = "";
            SalString sUnitChar = "";
            SalString sRecChar = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sUnitChar = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter();
                sRecChar = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
                // ! Get the position of the code part
                nPos = sRequiredStringComplete.Scan(p_sCodePart);
                if (nPos != -1)
                {
                    // Find the length of the Attribute String
                    nLength = sRequiredStringComplete.Length;
                    // Extract the string from beginning of nPos to end of Attribute String
                    sStrTmp = sRequiredStringComplete.Mid(nPos, nLength);
                    // Get the position of the Unit Seperator
                    nPosUnitDelim = sStrTmp.Scan(sUnitChar);
                    // Get the position of the Record Seperator
                    nPosRecDelim = sStrTmp.Scan(sRecChar);
                    // Get the first part of the string upto the Unit Seperator
                    nPosStr = sRequiredStringComplete.Left(nPos + 1).Length;
                    nPosStr = nPosStr + nPosUnitDelim;
                    sStr1 = sRequiredStringComplete.Left(nPosStr);
                    // Get the last part of the string
                    sStr2 = sStrTmp.Mid(nPosRecDelim, nLength);
                    // Create new Attribute String
                    sNewRequiredString = sStr1 + p_sCodePartValue + sStr2;
                    // Replace existing Attribute String with new string
                    sRequiredStringComplete = sNewRequiredString;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="p_sString"></param>
        /// <returns></returns>
        public virtual SalNumber SetCodestringCmpl(SalString p_sString)
        {
            #region Local Variables
            SalNumber nPos1 = 0;
            SalNumber nPos2 = 0;
            SalNumber nLength = 0;
            SalString sTmp_CodePart = "";
            SalString sTmpString = "";
            SalString sTmp_Value = "";
            SalString sUnitChar = "";
            SalString sRecChar = "";
            SalNumber i = 0;
            SalNumber j = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sTmpString = p_sString;
                nLength = sTmpString.Length;
                sUnitChar = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter();
                sRecChar = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
                while (sTmpString != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    i = i + 1;
                    nPos1 = sTmpString.Scan(sUnitChar);
                    sTmp_CodePart = sTmpString.Left(nPos1);
                    nPos2 = sTmpString.Scan(sRecChar);
                    sTmp_Value = sTmpString.Mid(nPos1 + 1, nPos2 - nPos1 - 1);
                    if (sTmp_CodePart == "ACCOUNT")
                    {
                        colAccount.Text = sTmp_Value;
                        colAccount.EditDataItemSetEdited();
                        FetchDescription("A");
                    }
                    else if (sTmp_CodePart == "CODE_B")
                    {
                        colCodeB.Text = sTmp_Value;
                        colCodeB.EditDataItemSetEdited();
                        FetchDescription("B");
                    }
                    else if (sTmp_CodePart == "CODE_C")
                    {
                        colCodeC.Text = sTmp_Value;
                        colCodeC.EditDataItemSetEdited();
                        FetchDescription("C");
                    }
                    else if (sTmp_CodePart == "CODE_D")
                    {
                        colCodeD.Text = sTmp_Value;
                        colCodeD.EditDataItemSetEdited();
                        FetchDescription("D");
                    }
                    else if (sTmp_CodePart == "CODE_E")
                    {
                        colCodeE.Text = sTmp_Value;
                        colCodeE.EditDataItemSetEdited();
                        FetchDescription("E");
                    }
                    else if (sTmp_CodePart == "CODE_F")
                    {
                        colCodeF.Text = sTmp_Value;
                        colCodeF.EditDataItemSetEdited();
                        FetchDescription("F");
                    }
                    else if (sTmp_CodePart == "CODE_G")
                    {
                        colCodeG.Text = sTmp_Value;
                        colCodeG.EditDataItemSetEdited();
                        FetchDescription("G");
                    }
                    else if (sTmp_CodePart == "CODE_H")
                    {
                        colCodeH.Text = sTmp_Value;
                        colCodeH.EditDataItemSetEdited();
                        FetchDescription("H");
                    }
                    else if (sTmp_CodePart == "CODE_I")
                    {
                        colCodeI.Text = sTmp_Value;
                        colCodeI.EditDataItemSetEdited();
                        FetchDescription("I");
                    }
                    else if (sTmp_CodePart == "CODE_J")
                    {
                        colCodeJ.Text = sTmp_Value;
                        colCodeJ.EditDataItemSetEdited();
                        FetchDescription("J");
                    }
                    else if (sTmp_CodePart == "PROCESS_CODE")
                    {
                        colProcessCode.Text = sTmp_Value;
                        colProcessCode.EditDataItemSetEdited();
                    }
                    sTmpString = sTmpString.Mid(nPos2 + 1, nLength);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean GetVoucherDate()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Ext_Transactions_API.Get_Voucher_Date", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN\r\n" +
                        "	      :i_hWndFrame.tbwExtTransactions.coldVoucherDate :=\r\n" +
                        "	      &AO.Ext_Transactions_API.Get_Voucher_Date(\r\n" +
                        "      	     :i_hWndFrame.tbwExtTransactions.i_sCompany,\r\n" +
                        "                     :i_hWndFrame.tbwExtTransactions.colLoadId,\r\n" +
                        "                     :i_hWndFrame.tbwExtTransactions.colTransactionDate);\r\n	 END; ")))
                    {
                        return false;
                    }
                }
                return true;
            }
            #endregion
        }

                // Bug 110830, Begin
		/// <summary>
		/// </summary>
		/// <param name="sCodePart"></param>
		/// <param name="sCodePartValue"></param>
		/// <param name="hCodePartColumn"></param>
		/// <returns></returns>
		public virtual SalNumber ValidateCodePartColumn(SalString sCodePart, SalString sCodePartValue, SalWindowHandle hCodePartColumn)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sCodePart == sIsProjectCodePart) 
				{
					CheckProjActivityBlocked(sCodePartValue);
				}
				FetchDescription(sCodePart);
				if (!(Sal.IsNull(hCodePartColumn))) 
				{
					GetCodestringCmpl(cColumn.FromHandle(hCodePartColumn).p_sSqlColumn, sCodePartValue);
					if (AmIBlocked(hCodePartColumn)) 
					{
						sParams[0] = Vis.StrChoose(Ifs.Fnd.ApplicationForms.Int.PalWinGetTitle(hCodePartColumn) != Ifs.Fnd.ApplicationForms.Const.strNULL, Ifs.Fnd.ApplicationForms.Int.PalWinGetTitle(hCodePartColumn), Ifs.Fnd.ApplicationForms.Int.PalGetItemNameX(
								hCodePartColumn));
						sParams[1] = colAccount.Text;
						Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_BlockedCodePartEntered, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParams);
						return Sys.VALIDATE_Cancel;
					}
				}
				return Sys.VALIDATE_Ok;
			}
			#endregion
		}
        // Bug 110830, End

        /// <summary>
        /// To set the values for ThirdCurrency DebitAmount, CreditAmount and Amount
        /// </summary>
        /// <returns></returns>CurrencyRateType
        public virtual SalNumber SetThirdCurrencyAmounts()
        {
            #region Local Variables
            SalNumber nThirdCurrencyCurrencyAmount = 0;
            SalString sParallelCurrencyBaseType;
            
            SalString sBaseCurrencyCode="";
            SalString sIsThirdEMU="";
            SalString sIsBaseEMU="";

            #endregion


            #region Actions

            
            sFinCurrencyCode = this.colCurrencyCode.Text;
            //if (sParallelBaseType == "TRANSACTION_CURRENCY")
            //{
            tbwExtTransactions.FromHandle(i_hWndFrame).GetThirdCurrencyAttributes(i_sCompany, sThirdCurrencyCode, sBaseCurrencyCode, colTransactionDate.DateTime, "DUMMY", "DUMMY", sParallelBaseType, colsParallelCurrRateType.Text);
            //}
            //else
            //{
            //    tbwExtTransactions.FromHandle(i_hWndFrame).GetThirdCurrencyAttributes(i_sCompany, sThirdCurrencyCode, sBaseCurrencyCode, colTransactionDate.DateTime, "DUMMY", "DUMMY");
            //}
            

            
             if ((tbwExtTransactions.FromHandle(i_hWndFrame).i_nFinThirdCurrencyRate != SalNumber.Null))
             using (new SalContext(this))
             {
                 if (sThirdCurrencyCode == Ifs.Fnd.ApplicationForms.Const.strNULL)
                 {
                     if (!(Sal.IsNull(colDebetAmount)))
                     {
                         colnThirdCurrencyDebitAmount.Number = 0;
                         colnThirdCurrencyAmount.Number = 0;
                         colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                     }
                     else if (!(Sal.IsNull(colCreditAmount)))
                     {
                         colnThirdCurrencyCreditAmount.Number = 0;
                         colnThirdCurrencyAmount.Number = 0;
                         colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                     }
                 }
                 else
                 {
                     if (sThirdCurrencyCode == colCurrencyCode.Text && sParallelBaseType == "TRANSACTION_CURRENCY")
                     {

                         if (!(Sal.IsNull(colCurrencyDebetAmount)))
                         {
                             colnThirdCurrencyDebitAmount.Number = colCurrencyDebetAmount.Number;
                             colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                             colnThirdCurrencyAmount.Number = colCurrencyDebetAmount.Number;
                             colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                             colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                         }
                         else if (!(Sal.IsNull(colCurrencyCreditAmount)))
                         {
                             colnThirdCurrencyCreditAmount.Number = colCurrencyCreditAmount.Number;
                             colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                             colnThirdCurrencyAmount.Number = -colCurrencyCreditAmount.Number;
                             colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                             colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                         }
                     }
                     else if (sThirdCurrencyCode == tbwExtTransactions.FromHandle(i_hWndFrame).i_sFinBaseCurrencyCode && sParallelBaseType == "ACCOUNTING_CURRENCY")
                     {
                         if (!(Sal.IsNull(colDebetAmount)))
                         {
                             colnThirdCurrencyDebitAmount.Number = colDebetAmount.Number;
                             colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                             colnThirdCurrencyAmount.Number = colDebetAmount.Number;
                             colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                             colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                         }
                         else if (!(Sal.IsNull(colCreditAmount)))
                         {
                             colnThirdCurrencyCreditAmount.Number = colCreditAmount.Number;
                             colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                             colnThirdCurrencyAmount.Number = -colCreditAmount.Number;
                             colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                             colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                         }
                     }
                     else
                     {
                         if (!(tbwExtTransactions.FromHandle(i_hWndFrame).i_nFinThirdCurrencyRate == SalNumber.Null))
                         {
                             if (!(Sal.IsNull(colDebetAmount)) && (colDebetAmount.Number != 0))
                             {
                                 if (sParallelBaseType == "ACCOUNTING_CURRENCY")
                                 {
                                     tbwExtTransactions.FromHandle(i_hWndFrame).GetThirdCurrencyAmount(colDebetAmount.Number, ref nThirdCurrencyCurrencyAmount);
                                 }
                                 else if (sParallelBaseType == "TRANSACTION_CURRENCY")
                                 {
                                     tbwExtTransactions.FromHandle(i_hWndFrame).GetThirdCurrencyAmount(colDebetAmount.Number, colCurrencyDebetAmount.Number, ref nThirdCurrencyCurrencyAmount);
                                 }
                                 colnThirdCurrencyDebitAmount.Number = nThirdCurrencyCurrencyAmount;
                                 colnThirdCurrencyAmount.Number = colnThirdCurrencyDebitAmount.Number;
                                 colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                                 colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                                 colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                             }
                             else if (!(Sal.IsNull(colCreditAmount)))
                             {
                                 if (sParallelBaseType == "ACCOUNTING_CURRENCY")
                                 {
                                     tbwExtTransactions.FromHandle(i_hWndFrame).GetThirdCurrencyAmount(colCreditAmount.Number, ref nThirdCurrencyCurrencyAmount);
                                 }
                                 else if (sParallelBaseType == "TRANSACTION_CURRENCY")
                                 {
                                     tbwExtTransactions.FromHandle(i_hWndFrame).GetThirdCurrencyAmount(colCreditAmount.Number, colCurrencyCreditAmount.Number, ref nThirdCurrencyCurrencyAmount);
                                 }

                                 colnThirdCurrencyCreditAmount.Number = nThirdCurrencyCurrencyAmount;
                                 colnThirdCurrencyAmount.Number = -colnThirdCurrencyCreditAmount.Number;
                                 colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                                 colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                                 colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                             }
                         }

                     }
                 }
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
        private void tbwExtTransactions_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged:
                    this.tbwExtTransactions_OnPM_UserProfileChanged(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tbwExtTransactions_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.tbwExtTransactions_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tbwExtTransactions_OnPM_DataRecordNew(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_UserProfileChanged event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwExtTransactions_OnPM_UserProfileChanged(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged, Sys.wParam, Sys.lParam))
            {
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwExtTransactions_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
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
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwExtTransactions.i_sCompany").ToHandle();
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
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwExtTransactions_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.sUserId = this.colsUserId.Text;
                }
            }
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwExtTransactions_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.colsUserId.Text = this.sUserId;
                    this.colsUserId.EditDataItemSetEdited();
                    if (!(this.GetVoucherDate()))
                    {
                        e.Return = false;
                        return;
                    }

                }
            }
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colTransactionDate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colTransactionDate_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colTransactionDate_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Period_API.Get_Accounting_Period_Ext"))
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Accounting_Period_API.Get_Accounting_Period_Ext", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (this.colTransactionDate.DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.tbwExtTransactions.colAccountingPeriod := " + cSessionManager.c_sDbPrefix + "Accounting_Period_API.Get_Accounting_Period_Ext(\r\n" +
                            "                                                    :i_hWndFrame.tbwExtTransactions.i_sCompany,\r\n" +
                            "                                                    :i_hWndFrame.tbwExtTransactions.colsUserGroup, \r\n" +
                            "                                                    :i_hWndFrame.tbwExtTransactions.colTransactionDate ) "))
                        {
                            // Bug 107457, begin, removed the not equal sign
                            if ((this.GetVoucherDate()))
                            {
                                e.Return = true;
                                return;
                            }
                            // Bug 107457, end
                        }
                    }
                }
                e.Return = false;
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
        private void colVoucherType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colVoucherType_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colVoucherType_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.sItemNames[0] = "COMPANY";
                this.hWndItems[0] = this.colCompany;
                this.sItemNames[1] = "VOUCHER_TYPE";
                this.hWndItems[1] = this.colVoucherType;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("VoucherTypeDetail", this, this.sItemNames, this.hWndItems);
                SessionNavigate(Pal.GetActiveInstanceName("tbwQueryVoucherType"));
                e.Return = true;
                return;
            }
            else
            {
                e.Return = true;
                return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colAccountingYear_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colAccountingYear_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colAccountingYear_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Period_API.Get_Accounting_Period_Ext"))
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Accounting_Period_API.Get_Accounting_Period_Ext", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (this.colAccountingYear.DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.tbwExtTransactions.colAccountingPeriod := " + cSessionManager.c_sDbPrefix + "Accounting_Period_API.Get_Accounting_Period_Ext(\r\n" +
                            "                                                    :i_hWndFrame.tbwExtTransactions.i_sCompany,\r\n" +
                            "                                                    :i_hWndFrame.tbwExtTransactions.colsUserGroup, \r\n" +
                            "                                                    :i_hWndFrame.tbwExtTransactions.colTransactionDate ) "))
                        {
                            e.Return = true;
                            return;
                        }
                    }
                }
                e.Return = false;
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
        private void colsUserGroup_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsUserGroup_OnPM_DataItemValidate(sender, e);
                    break;

                case Sys.SAM_SetFocus:
                    this.colsUserGroup_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsUserGroup_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (Sal.IsNull(this.colsUserGroup.i_hWndSelf))
                {
                    e.Return = true;
                    return;
                }
                else
                {
                    if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("User_Group_Member_Finance_API.Exist"))
                    {
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("User_Group_Member_Finance_API.Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            if (this.colsUserGroup.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "User_Group_Member_Finance_API.Exist(\r\n" +
                                "                                           :i_hWndFrame.tbwExtTransactions.i_sCompany ,\r\n" +
                                "                                           :i_hWndFrame.tbwExtTransactions.colsUserGroup ,\r\n" +
                                "                                           :i_hWndFrame.tbwExtTransactions.colsUserId)"))
                            {
                                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Period_API.Get_Accounting_Period_Ext"))
                                {
                                    using (SignatureHints hints1 = SignatureHints.NewContext())
                                    {
                                        hints1.Add("Accounting_Period_API.Get_Accounting_Period_Ext", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                        if (this.colsUserGroup.DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.tbwExtTransactions.colAccountingPeriod := " + cSessionManager.c_sDbPrefix + "Accounting_Period_API.Get_Accounting_Period_Ext(\r\n" +
                                            "                                                    :i_hWndFrame.tbwExtTransactions.i_sCompany,\r\n" +
                                            "                                                    :i_hWndFrame.tbwExtTransactions.colsUserGroup, \r\n" +
                                            "                                                    :i_hWndFrame.tbwExtTransactions.colTransactionDate ) "))
                                        {
                                            e.Return = true;
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    e.Return = false;
                    return;
                }
            }
            else
            {
                e.Return = false;
                return;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsUserGroup_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.colsUserId))
            {
                this.colsUserId.Text = this.sUserId;
                this.colsUserId.EditDataItemSetEdited();
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
        private void colAccount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 110830, Removed. On SAM_SetFocus

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colAccount_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colAccount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.colAccount.i_hWndSelf))
            {
                // Set the Free Code Parts blocked
                this.colCodePartsDemand.Text = "1S2S3S4S5S6S7S8S9S";
                this.colAccountDesc.Text = Sys.STRING_Null;
                e.Return = true;
                return;
            }
            else
            {
                this.sTemp = "A";
                this.sTemp1 = this.colAccount.Text;
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Account_API.Exist_", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (!(this.colAccount.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Account_API.Exist_(\r\n" +
                        "                                           :i_hWndFrame.tbwExtTransactions.i_sCompany ,\r\n" +
                        "                                           :i_hWndFrame.tbwExtTransactions.sTemp1)")))
                    {
                        e.Return = false;
                        return;
                    }
                    else
                    {
                        // The Account has changed.Get the code part demand for this row (Setting it for testing)
                        this.sTemp = this.colAccount.Text;
                        this.lsStmt = "Select " + cSessionManager.c_sDbPrefix + "Ext_Transactions_API.Get_Demand_String_(:i_hWndFrame.tbwExtTransactions.i_sCompany,\r\n" +
                        ":i_hWndFrame.tbwExtTransactions.sTemp) into :i_hWndFrame.tbwExtTransactions.lsTemp from DUAL";
                        if (this.colAccount.DbPrepareAndExecute(cSessionManager.c_hSql, this.lsStmt))
                        {
                            this.colAccount.DbFetchNext(cSessionManager.c_hSql, ref this.nTemp);
                            this.colCodePartsDemand.Text = this.lsTemp.Left(20);
                            this.ClearBlockedCodeParts();
                            // Bug 92374, begin
                            this.GetCodestringCmpl(cColumn.FromHandle(this.colAccount.i_hWndSelf).p_sSqlColumn, this.colAccount.Text);
                            // Bug 92374, end
                            this.FetchDescription("A");
                            e.Return = true;
                            return;
                        }
                        else
                        {
                            e.Return = false;
                            return;
                        }
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodeB_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 110830, Removed. On SAM_SetFocus

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
					// Bug 110830, Begin. Moved Validation to one method and stopped calling Class Validation
					e.Return = this.ValidateCodePartColumn("B", this.colCodeB.Text, this.colCodeB.i_hWndSelf);
					return;
					// Bug 110830, End
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodeBDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodeBDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodeBDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colCodeB);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colCodeBDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
            if (this.AmIBlocked(this.hWndCodePart))
            {
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                System.Windows.Forms.SendKeys.Send("{TAB}");
                e.Return = false;
                return;
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
        private void colCodeC_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 110830, Removed. On SAM_SetFocus

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
					// Bug 110830, Begin. Moved Validation to one method and stopped calling Class Validation
					e.Return = this.ValidateCodePartColumn("C", this.colCodeC.Text, this.colCodeC.i_hWndSelf);
					return;
					// Bug 110830, End
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodeCDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodeCDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodeCDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colCodeC);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colCodeCDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
            if (this.AmIBlocked(this.hWndCodePart))
            {
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                System.Windows.Forms.SendKeys.Send("{TAB}");
                e.Return = false;
                return;
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
        private void colCodeD_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 110830, Removed. On SAM_SetFocus

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
					// Bug 110830, Begin. Moved Validation to one method and stopped calling Class Validation
					e.Return = this.ValidateCodePartColumn("D", this.colCodeD.Text, this.colCodeD.i_hWndSelf);
					return;
					// Bug 110830, End
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodeDDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodeDDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodeDDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colCodeD);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colCodeDDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
            if (this.AmIBlocked(this.hWndCodePart))
            {
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                System.Windows.Forms.SendKeys.Send("{TAB}");
                e.Return = false;
                return;
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
        private void colCodeE_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 110830, Removed. On SAM_SetFocus

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
					// Bug 110830, Begin. Moved Validation to one method and stopped calling Class Validation
					e.Return = this.ValidateCodePartColumn("E", this.colCodeE.Text, this.colCodeE.i_hWndSelf);
					return;
					// Bug 110830, End
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodeEDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodeEDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodeEDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colCodeE);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colCodeEDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
            if (this.AmIBlocked(this.hWndCodePart))
            {
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                System.Windows.Forms.SendKeys.Send("{TAB}");
                e.Return = false;
                return;
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
        private void colCodeF_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 110830, Removed. On SAM_SetFocus

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
					// Bug 110830, Begin. Moved Validation to one method and stopped calling Class Validation
					e.Return = this.ValidateCodePartColumn("F", this.colCodeF.Text, this.colCodeF.i_hWndSelf);
					return;
					// Bug 110830, End
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodeFDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodeFDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodeFDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colCodeF);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colCodeFDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
            if (this.AmIBlocked(this.hWndCodePart))
            {
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                System.Windows.Forms.SendKeys.Send("{TAB}");
                e.Return = false;
                return;
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
        private void colCodeG_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 110830, Removed. On SAM_SetFocus

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
					// Bug 110830, Begin. Moved Validation to one method and stopped calling Class Validation
					e.Return = this.ValidateCodePartColumn("G", this.colCodeG.Text, this.colCodeG.i_hWndSelf);
					return;
					// Bug 110830, End
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodeGDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodeGDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodeGDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colCodeG);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colCodeGDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
            if (this.AmIBlocked(this.hWndCodePart))
            {
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                System.Windows.Forms.SendKeys.Send("{TAB}");
                e.Return = false;
                return;
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
        private void colCodeH_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 110830, Removed. On SAM_SetFocus

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
					// Bug 110830, Begin. Moved Validation to one method and stopped calling Class Validation
					e.Return = this.ValidateCodePartColumn("H", this.colCodeH.Text, this.colCodeH.i_hWndSelf);
					return;
					// Bug 110830, End
                    break;
            }
            #endregion
        }
       
        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodeHDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodeHDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodeHDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colCodeH);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colCodeHDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
            if (this.AmIBlocked(this.hWndCodePart))
            {
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                System.Windows.Forms.SendKeys.Send("{TAB}");
                e.Return = false;
                return;
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
        private void colCodeI_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 110830, Removed. On SAM_SetFocus

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
					// Bug 110830, Begin. Moved Validation to one method and stopped calling Class Validation
					e.Return = this.ValidateCodePartColumn("I", this.colCodeI.Text, this.colCodeI.i_hWndSelf);
					return;
					// Bug 110830, End
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodeIDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodeIDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodeIDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colCodeI);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colCodeIDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
            if (this.AmIBlocked(this.hWndCodePart))
            {
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                System.Windows.Forms.SendKeys.Send("{TAB}");
                e.Return = false;
                return;
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
        private void colCodeJ_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 110830, Removed. On SAM_SetFocus

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
					// Bug 110830, Begin. Moved Validation to one method and stopped calling Class Validation
					e.Return = this.ValidateCodePartColumn("J", this.colCodeJ.Text, this.colCodeJ.i_hWndSelf);
					return;
					// Bug 110830, End
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCodeJDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colCodeJDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCodeJDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colCodeJ);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colCodeJDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
            if (this.AmIBlocked(this.hWndCodePart))
            {
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                System.Windows.Forms.SendKeys.Send("{TAB}");
                e.Return = false;
                return;
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
        private void colCurrencyCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colCurrencyCode_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCurrencyCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (!(Sal.IsNull(this.colCurrencyCode)))
                {
                    if (this.ValidateValues())
                    {
                        e.Return = this.ValidateCurrencyCode();
                        return;
                    }
                }
                else if (!(Sal.IsNull(this.colCurrencyAmount)) && !(Sal.IsNull(this.colTransactionDate)))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoCurrencyCode, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                    e.Return = false;
                    return;
                }
                else
                {
                    e.Return = true;
                    return;
                }
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCorrection_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.colCorrection_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    this.colCorrection_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCorrection_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colsCorrectionParam.Text == "TRUE")
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                return;
            }
            else
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCorrection_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam))
            {
                this.SetSignForAllAmounts(this.colCorrection.Text);
            }
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCurrencyDebetAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colCurrencyDebetAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled:
                    this.colCurrencyDebetAmount_OnPM_EditStateFieldEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCurrencyDebetAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colCurrencyDebetAmount.Number != Sys.NUMBER_Null)
            {
                // Bug 71024,  condition removed since SetCorrection() does not exist
                if (this.colCurrencyDebetAmount.Number < 0 && this.colCorrection.Text == "FALSE" || this.colCurrencyDebetAmount.Number > 0 && this.colCorrection.Text == "TRUE")
                {
                    this.colCurrencyDebetAmount.Number = -this.colCurrencyDebetAmount.Number;
                }
                if (!(this.ValidateValues()))
                {
                    e.Return = false;
                    return;
                }
                this.ValidateCurrencyCode();
                this.colCurrencyDebetAmount.Number = this.SetAnotherValue(this.colCurrencyDebetAmount.Number, this.colDebetAmount, this.nDecimalsInAmount, this.nAccDecimalsInAmount, "CURRENT_AMOUNT");
                if (!(Sal.IsNull(this.colCurrencyCreditAmount)))
                {
                    Sal.SendMsg(this.colCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
                if (!(Sal.IsNull(this.colCreditAmount)))
                {
                    Sal.SendMsg(this.colCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
            }
            else
            {
                this.colCurrencyCreditAmount.Number = -this.SetAnotherValue(-this.colCurrencyCreditAmount.Number, this.colCreditAmount, this.nDecimalsInAmount, this.nAccDecimalsInAmount, "CURRENT_AMOUNT");
                if (!(Sal.IsNull(this.colDebetAmount)))
                {
                    Sal.SendMsg(this.colDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_EditStateFieldEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCurrencyDebetAmount_OnPM_EditStateFieldEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.colCurrencyCreditAmount)) && Sal.IsNull(this.colCurrencyDebetAmount))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCurrencyCreditAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colCurrencyCreditAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled:
                    this.colCurrencyCreditAmount_OnPM_EditStateFieldEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCurrencyCreditAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colCurrencyCreditAmount.Number != Sys.NUMBER_Null)
            {
                // Bug 71024, colCorrection = strNULL has no effect since SetCorrection() is removed
                if (this.colCurrencyCreditAmount.Number < 0 && this.colCorrection.Text == "FALSE" || this.colCurrencyCreditAmount.Number > 0 && this.colCorrection.Text == "TRUE")
                {
                    this.colCurrencyCreditAmount.Number = -this.colCurrencyCreditAmount.Number;
                }
                if (!(this.ValidateValues()))
                {
                    e.Return = false;
                    return;
                }
                this.ValidateCurrencyCode();
                this.colCurrencyCreditAmount.Number = -this.SetAnotherValue(-this.colCurrencyCreditAmount.Number, this.colCreditAmount, this.nDecimalsInAmount, this.nAccDecimalsInAmount, "CURRENT_AMOUNT");
                if (!(Sal.IsNull(this.colCurrencyDebetAmount)))
                {
                    Sal.SendMsg(this.colCurrencyDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
                if (!(Sal.IsNull(this.colDebetAmount)))
                {
                    Sal.SendMsg(this.colDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
            }
            else
            {
                this.colCurrencyDebetAmount.Number = this.SetAnotherValue(this.colCurrencyDebetAmount.Number, this.colDebetAmount, this.nDecimalsInAmount, this.nAccDecimalsInAmount, "CURRENT_AMOUNT");
                if (!(Sal.IsNull(this.colCreditAmount)))
                {
                    Sal.SendMsg(this.colCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_EditStateFieldEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCurrencyCreditAmount_OnPM_EditStateFieldEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.colCurrencyDebetAmount)) && Sal.IsNull(this.colCurrencyCreditAmount))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCurrencyAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colCurrencyAmount_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCurrencyAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colCurrencyAmount.Number != Sys.NUMBER_Null)
            {
                if (!(this.ValidateValues()))
                {
                    e.Return = false;
                    return;
                }
                this.ValidateCurrencyCode();
            }
            // Bug 71024 Begin , colCorrection = strNULL has no effect since SetCorrection() is removed and modified the rest
            if (this.colsCorrectionParam.Text != "TRUE")
            {
                if (this.colCurrencyAmount.Number >= 0 && this.colCorrection.Text == "FALSE" || this.colCurrencyAmount.Number < 0 && this.colCorrection.Text == "TRUE")
                {

                    // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                    SalNumber temp1 = this.colCurrencyAmount.Number;
                    this.SetCurrencyDebitAmntFirst(ref temp1);
                    this.colCurrencyAmount.Number = temp1;

                }
                else
                {

                    // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                    SalNumber temp2 = this.colCurrencyAmount.Number;
                    this.SetCurrencyCreditAmntFirst(ref temp2);
                    this.colCurrencyAmount.Number = temp2;

                }
            }
            else
            {
                if (this.colCorrection.Text == "TRUE")
                {
                    if (this.colCurrencyAmount.Number >= 0)
                    {

                        // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                        SalNumber temp3 = this.colCurrencyAmount.Number;
                        this.SetCurrencyCreditAmntFirst(ref temp3);
                        this.colCurrencyAmount.Number = temp3;

                    }
                    else
                    {

                        // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                        SalNumber temp4 = this.colCurrencyAmount.Number;
                        this.SetCurrencyDebitAmntFirst(ref temp4);
                        this.colCurrencyAmount.Number = temp4;

                    }
                }
                else
                {
                    if (this.colCurrencyAmount.Number >= 0)
                    {

                        // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                        SalNumber temp5 = this.colCurrencyAmount.Number;
                        this.SetCurrencyDebitAmntFirst(ref temp5);
                        this.colCurrencyAmount.Number = temp5;

                    }
                    else
                    {

                        // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                        SalNumber temp6 = this.colCurrencyAmount.Number;
                        this.SetCurrencyCreditAmntFirst(ref temp6);
                        this.colCurrencyAmount.Number = temp6;

                    }
                }
            }
            // Bug 71024 End
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colDebetAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colDebetAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled:
                    this.colDebetAmount_OnPM_EditStateFieldEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colDebetAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colDebetAmount.Number != Sys.NUMBER_Null)
            {
                // Bug 71024 Begin , colCorrection = strNULL has no effect since SetCorrection() is removed
                if (this.colDebetAmount.Number < 0 && this.colCorrection.Text == "FALSE" || this.colDebetAmount.Number > 0 && this.colCorrection.Text == "TRUE")
                {
                    this.colDebetAmount.Number = -this.colDebetAmount.Number;
                }
                if (!(this.ValidateValues()))
                {
                    e.Return = false;
                    return;
                }
                this.ValidateCurrencyCode();
                this.colDebetAmount.Number = this.SetAnotherValue(this.colDebetAmount.Number, this.colCurrencyDebetAmount, this.nAccDecimalsInAmount, this.nDecimalsInAmount, "ACCOUNTING_AMOUNT");
                if (!(Sal.IsNull(this.colCreditAmount)))
                {
                    Sal.SendMsg(this.colCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
                if (!(Sal.IsNull(this.colCurrencyCreditAmount)))
                {
                    Sal.SendMsg(this.colCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
            }
            else
            {
                this.colCreditAmount.Number = -this.SetAnotherValue(-this.colCreditAmount.Number, this.colCurrencyCreditAmount, this.nAccDecimalsInAmount, this.nDecimalsInAmount, "ACCOUNTING_AMOUNT");
                if (!(Sal.IsNull(this.colCurrencyDebetAmount)))
                {
                    Sal.SendMsg(this.colCurrencyDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_EditStateFieldEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colDebetAmount_OnPM_EditStateFieldEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.colCreditAmount)) && Sal.IsNull(this.colDebetAmount))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colCreditAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colCreditAmount_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled:
                    this.colCreditAmount_OnPM_EditStateFieldEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCreditAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colCreditAmount.Number != Sys.NUMBER_Null)
            {
                // Bug 71024 Begin , colCorrection = strNULL has no effect since SetCorrection() is removed
                if (this.colCreditAmount.Number < 0 && this.colCorrection.Text == "FALSE" || this.colCreditAmount.Number > 0 && this.colCorrection.Text == "TRUE")
                {
                    this.colCreditAmount.Number = -this.colCreditAmount.Number;
                }
                if (!(this.ValidateValues()))
                {
                    e.Return = false;
                    return;
                }
                this.ValidateCurrencyCode();
                this.colCreditAmount.Number = -this.SetAnotherValue(-this.colCreditAmount.Number, this.colCurrencyCreditAmount, this.nAccDecimalsInAmount, this.nDecimalsInAmount, "ACCOUNTING_AMOUNT");
                if (!(Sal.IsNull(this.colDebetAmount)))
                {
                    Sal.SendMsg(this.colDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
                if (!(Sal.IsNull(this.colCurrencyDebetAmount)))
                {
                    Sal.SendMsg(this.colCurrencyDebetAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
            }
            else
            {
                this.colDebetAmount.Number = this.SetAnotherValue(this.colDebetAmount.Number, this.colCurrencyDebetAmount, this.nAccDecimalsInAmount, this.nDecimalsInAmount, "ACCOUNTING_AMOUNT");
                if (!(Sal.IsNull(this.colCurrencyCreditAmount)))
                {
                    Sal.SendMsg(this.colCurrencyCreditAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, SalNumber.Null.ToString(0).ToHandle());
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_EditStateFieldEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colCreditAmount_OnPM_EditStateFieldEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.colDebetAmount)) && Sal.IsNull(this.colCreditAmount))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colAmount_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.colAmount.Number != Sys.NUMBER_Null)
            {
                if (!(this.ValidateValues()))
                {
                    e.Return = false;
                    return;
                }
                this.ValidateCurrencyCode();
            }
            // Bug 71024 Begin , colCorrection = strNULL has no effect since SetCorrection() is removed and modified the rest
            if (this.colsCorrectionParam.Text != "TRUE")
            {
                if (this.colAmount.Number >= 0 && this.colCorrection.Text == "FALSE" || this.colAmount.Number < 0 && this.colCorrection.Text == "TRUE")
                {

                    // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                    SalNumber temp1 = this.colAmount.Number;
                    this.SetDebitAmntFirst(ref temp1);
                    this.colAmount.Number = temp1;

                }
                else
                {

                    // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                    SalNumber temp2 = this.colAmount.Number;
                    this.SetCreditAmntFirst(ref temp2);
                    this.colAmount.Number = temp2;

                }
            }
            else
            {
                if (this.colCorrection.Text == "TRUE")
                {
                    if (this.colAmount.Number >= 0)
                    {

                        // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                        SalNumber temp3 = this.colAmount.Number;
                        this.SetCreditAmntFirst(ref temp3);
                        this.colAmount.Number = temp3;

                    }
                    else
                    {

                        // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                        SalNumber temp4 = this.colAmount.Number;
                        this.SetDebitAmntFirst(ref temp4);
                        this.colAmount.Number = temp4;

                    }
                }
                else
                {
                    if (this.colAmount.Number >= 0)
                    {

                        // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                        SalNumber temp5 = this.colAmount.Number;
                        this.SetDebitAmntFirst(ref temp5);
                        this.colAmount.Number = temp5;

                    }
                    else
                    {

                        // PPJ: Automatically generated temporary assignments. Properties canot be passed by reference.
                        SalNumber temp6 = this.colAmount.Number;
                        this.SetCreditAmntFirst(ref temp6);
                        this.colAmount.Number = temp6;

                    }
                }
            }
            // Bug 71024 End
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colOptionalCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colOptionalCode_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colOptionalCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (this.colOptionalCode.Text != this.colsPrevTaxCode.Text)
            {
                if (!(Sal.IsNull(this.colOptionalCode)))
                {
                    if (!(this.CheckTaxCode()))
                    {
                        this.colsPrevTaxCode.Text = this.colOptionalCode.Text;
                        e.Return = false;
                        return;
                    }
                }
                else
                {
                    this.colsTaxDirection.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
            }
            this.colsPrevTaxCode.Text = this.colOptionalCode.Text;
            if (Sal.IsNull(this.colOptionalCode))
            {
                Sal.ClearField(this.colsTaxDirection);
                this.colsTaxDirection.EditDataItemSetEdited();
                Sal.ClearField(this.colnTaxAmount);
                this.colnTaxAmount.EditDataItemSetEdited();
                Sal.ClearField(this.colnCurrencyTaxAmount);
                this.colnCurrencyTaxAmount.EditDataItemSetEdited();
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
        private void colnProjectActivityId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colnProjectActivityId_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.colnProjectActivityId_OnPM_DataItemLovUserWhere(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colnProjectActivityId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.colnProjectActivityId))
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("ACTIVITY"))
                {
                    this.ExecCheckProjActivityBlocked();
                    if (!(this.sProjActivityBlockedFlag == "TRUE"))
                    {
                        // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                        System.Windows.Forms.SendKeys.Send("{TAB}");
                    }
                }
                else
                {
                    // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                    System.Windows.Forms.SendKeys.Send("{TAB}");
                }
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colnProjectActivityId_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.sIsProjectCodePart == "B")
            {
                e.Return = ((SalString)"PROJECT_ID =  :i_hWndFrame.tbwExtTransactions.colCodeB").ToHandle();
                return;
            }
            else
            {
                if (this.sIsProjectCodePart == "C")
                {
                    e.Return = ((SalString)"PROJECT_ID =  :i_hWndFrame.tbwExtTransactions.colCodeC").ToHandle();
                    return;
                }
                else
                {
                    if (this.sIsProjectCodePart == "D")
                    {
                        e.Return = ((SalString)"PROJECT_ID =  :i_hWndFrame.tbwExtTransactions.colCodeD").ToHandle();
                        return;
                    }
                    else
                    {
                        if (this.sIsProjectCodePart == "E")
                        {
                            e.Return = ((SalString)"PROJECT_ID =  :i_hWndFrame.tbwExtTransactions.colCodeE").ToHandle();
                            return;
                        }
                        else
                        {
                            if (this.sIsProjectCodePart == "F")
                            {
                                e.Return = ((SalString)"PROJECT_ID =  :i_hWndFrame.tbwExtTransactions.colCodeF").ToHandle();
                                return;
                            }
                            else
                            {
                                if (this.sIsProjectCodePart == "G")
                                {
                                    e.Return = ((SalString)"PROJECT_ID =  :i_hWndFrame.tbwExtTransactions.colCodeG").ToHandle();
                                    return;
                                }
                                else
                                {
                                    if (this.sIsProjectCodePart == "H")
                                    {
                                        e.Return = ((SalString)"PROJECT_ID =  :i_hWndFrame.tbwExtTransactions.colCodeH").ToHandle();
                                        return;
                                    }
                                    else
                                    {
                                        if (this.sIsProjectCodePart == "I")
                                        {
                                            e.Return = ((SalString)"PROJECT_ID =  :i_hWndFrame.tbwExtTransactions.colCodeI").ToHandle();
                                            return;
                                        }
                                        else
                                        {
                                            if (this.sIsProjectCodePart == "J")
                                            {
                                                e.Return = ((SalString)"PROJECT_ID =  :i_hWndFrame.tbwExtTransactions.colCodeJ").ToHandle();
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            e.Return = ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToNumber();
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsTaxDirection_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsTaxDirection_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.colsTaxDirection_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsTaxDirection_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.colOptionalCode)))
            {
                if (Sal.IsNull(this.colsTaxDirection))
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoTaxDirection, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsTaxDirection_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.colOptionalCode))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colnTaxAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colnTaxAmount_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colnTaxAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.QueryFieldEdit(this.colnTaxAmount.i_hWndSelf))
            {
                if (this.colCurrencyCode.Text == this.sBaseCurrencyCode)
                {
                    Sal.SendMsg(this.colnCurrencyTaxAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, this.colnTaxAmount.Number.ToString(this.nAccDecimalsInAmount).ToHandle());
                }
                this.colnTaxAmount.Number = this.RoundedDecimals(this.colnTaxAmount.Number, this.nAccDecimalsInAmount);
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
        private void colnCurrencyTaxAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colnCurrencyTaxAmount_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colnCurrencyTaxAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.QueryFieldEdit(this.colnCurrencyTaxAmount.i_hWndSelf))
            {
                if (this.colCurrencyCode.Text == this.sBaseCurrencyCode)
                {
                    Sal.SendMsg(this.colnTaxAmount, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, this.colnCurrencyTaxAmount.Number.ToString(this.nAccDecimalsInAmount).ToHandle());
                    this.colnCurrencyTaxAmount.Number = this.RoundedDecimals(this.colnCurrencyTaxAmount.Number, this.nAccDecimalsInAmount);
                }
                else
                {
                    if (this.ValidateCurrencyCode())
                    {
                        this.colnCurrencyTaxAmount.Number = this.SetAnotherValue(this.colnCurrencyTaxAmount.Number, this.colnTaxAmount, this.nDecimalsInAmount, this.nAccDecimalsInAmount, "TAX_CURRENT_AMOUNT");
                    }
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        #endregion

        private void colnThirdCurrencyAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colnThirdCurrencyAmount_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void colnThirdCurrencyAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            #endregion

            #region Actions
            e.Handled = true;
            if (this.colnThirdCurrencyAmount.Number < 0 && this.colCorrection.Text == "TRUE")
            {
                if (this.colnThirdCurrencyDebitAmount.Number != Sys.NUMBER_Null)
                {
                    colnThirdCurrencyDebitAmount.Number = -colnThirdCurrencyAmount.Number;
                    colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                }
                else
                {
                    colnThirdCurrencyCreditAmount.Number = colnThirdCurrencyAmount.Number;
                    colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                }
            }
            else if (this.colnThirdCurrencyAmount.Number < 0 && this.colCorrection.Text == "FALSE")
            {
                if (this.colnThirdCurrencyDebitAmount.Number != Sys.NUMBER_Null)
                {
                    colnThirdCurrencyCreditAmount.Number = -colnThirdCurrencyAmount.Number;
                    colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                    colnThirdCurrencyDebitAmount.Number = Sys.NUMBER_Null;
                    colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                }
                else
                {
                    colnThirdCurrencyCreditAmount.Number = -colnThirdCurrencyAmount.Number;
                    colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
                }

            }
            else
            {
                colnThirdCurrencyDebitAmount.Number = colnThirdCurrencyAmount.Number;
                colnThirdCurrencyDebitAmount.EditDataItemSetEdited();
                colnThirdCurrencyCreditAmount.Number = Sys.NUMBER_Null;
                colnThirdCurrencyCreditAmount.EditDataItemSetEdited();
            }

            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void colnThirdCurrencyDebitAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colnThirdCurrencyDebitAmount_OnPM_DataItemValidate(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.colnThirdCurrencyDebitAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        private void colnThirdCurrencyDebitAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            #endregion

            #region Actions
            e.Handled = true;
            if (this.colnThirdCurrencyDebitAmount.Number != Sys.NUMBER_Null)
            {


                colnThirdCurrencyAmount.Number = colnThirdCurrencyDebitAmount.Number;
                colnThirdCurrencyAmount.EditDataItemSetEdited();
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colnThirdCurrencyDebitAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.colnThirdCurrencyCreditAmount)))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void colnThirdCurrencyCreditAmount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colnThirdCurrencyCreditAmount_OnPM_DataItemValidate(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.colnThirdCurrencyCreditAmount_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        private void colnThirdCurrencyCreditAmount_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            #endregion

            #region Actions
            e.Handled = true;
            if (this.colnThirdCurrencyCreditAmount.Number != Sys.NUMBER_Null)
            {

                colnThirdCurrencyAmount.Number = -colnThirdCurrencyCreditAmount.Number;
                colnThirdCurrencyAmount.EditDataItemSetEdited();
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colnThirdCurrencyCreditAmount_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.colnThirdCurrencyDebitAmount)))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void tableWindow_colsParallelCurrRateType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.tableWindow_colsParallelCurrRateType_OnPM_DataItemLovUserWhere(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tableWindow_colsParallelCurrRateType_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        private void tableWindow_colsParallelCurrRateType_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;

            if (sParallelBaseType == "TRANSACTION_CURRENCY")
            {
                e.Return = ((SalString)("RATE_TYPE_CATEGORY_DB = 'PARALLEL_CURRENCY'")).ToHandle();
            }
            if (sParallelBaseType == "ACCOUNTING_CURRENCY")
            {
                e.Return = ((SalString)("REF_CURRENCY_CODE = '" + sBaseCurrencyCode + "'") + (SalString)(" AND RATE_TYPE_CATEGORY_DB != 'PROJECT'")).ToHandle();
            }

            return;
            #endregion
        }


        private void tableWindow_colsParallelCurrRateType_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;

            if (sThirdCurrencyCode == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataRecordValidate()
        {
            return this.DataRecordValidate();
        }
        // Insert new code here...

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalString vrtGetWindowTitle()
        {
            return this.GetWindowTitle();
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

        private void menuItem__Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem__Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        #endregion

        
    }
}
