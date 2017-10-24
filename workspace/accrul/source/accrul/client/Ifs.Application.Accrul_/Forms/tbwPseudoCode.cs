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

using Ifs.Application.Accrul;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Vis;

namespace Ifs.Application.Accrul_
{

    /// <summary>
    /// </summary>
    [FndWindowRegistration("PSEUDO_CODES", "PseudoCodes", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwPseudoCode : cTableWindowFin
    {
        #region Window Variables
        public SalString sCodePart = "";
        public SalArray<SalString> sCodeParts = new SalArray<SalString>();
        public SalString sCodePartValue = "";
        public SalString sTemp = "";
        public SalString lsStmt = "";
        public SalString lsTemp = "";
        public SalString lsTemp1 = "";
        public SalNumber nIndex = 0;
        public SalNumber nTemp = 0;
        public SalNumber nTemp1 = 0;
        public SalNumber nTemp2 = 0;
        public SalWindowHandle hWndTemp = SalWindowHandle.Null;
        public SalWindowHandle hWndCodePart = SalWindowHandle.Null;
        public SalNumber nCodePartId = 0;
        public SalString sModule = "";
        public SalString sLu = "";
        public SalString lsAttribute = "";
        public SalString sProjectCodePart = "";
        public SalString sSender = "";
        public SalString sProjectCodePartHandle = "";
        public SalString sProjectOrigin = "";
        public SalNumber nReturnValue;
        private SalString isExcludeProjFollowups = "";
        private SalWindowHandle sProjectCodeHandle = SalWindowHandle.Null;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwPseudoCode()
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
        public new static tbwPseudoCode FromHandle(SalWindowHandle handle)
        {
            return ((tbwPseudoCode)SalWindow.FromHandle(handle, typeof(tbwPseudoCode)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            // Bug 91958 Begin Fixed it to Return TRUE
            return true;
            // Bug 91958 End
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
                        sModule = "ACCRUL";
                        sLu = "PseudoCodes";
                        lsAttribute = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        nRow = Sys.TBL_MinRow;
                        while (true)
                        {
                            if (Sal.TblFindNextRow(this, ref nRow, Sys.ROW_Selected, 0))
                            {
                                Sal.TblSetContext(this, nRow);
                                lsAttribute = lsAttribute + "'" + colsPseudoCode.Text + "'" + ",";
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
                        return 1;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return !(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) && Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCompanyTranslation")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(
                            Pal.GetActiveInstanceName("frmCompanyTranslation"));
                }
            }

            return 0;
            #endregion
        }
        // !
        // ! These Functions are for Codepart Demand
        // ! This function does all the processing that is required when the Focus is
        // ! set on a free code part (colCodeB to colCodeJ)
        /// <summary>
        /// </summary>
        /// <param name="hPWindow"></param>
        /// <param name="sPCodePart"></param>
        /// <param name="sPCodeValue"></param>
        /// <returns></returns>
        public virtual SalBoolean CodePartSetFocus(SalWindowHandle hPWindow, SalString sPCodePart, SalString sPCodeValue)
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
                else
                {
                    colsCodePart.Text = sPCodePart;
                    return true;
                }
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
        /// <param name="hWindow"></param>
        /// <returns></returns>
        public virtual SalString GetMyDemand(SalWindowHandle hWindow)
        {
            #region Local Variables
            SalString sColName = "";
            SalNumber nCodePartNum = 0;
            SalString sMyDemand = "";
            SalNumber nPos = 0;
            SalNumber nPos2 = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nPos = 1;
                nPos2 = 6;
                Sal.GetItemName(hWindow, ref sColName);
                if (sColName.Scan("DESC") != -1)
                {
                    sColName = sColName.Left(9);
                }
                nCodePartNum = ((SalString)"BCDEFGHIJP").Scan(sColName.Right(1));
                // nPos is assigned 2 because the calculation would not work for Process code
                // if nPos is 1
                if (nCodePartNum == 9)
                {
                    nPos = 2;
                }
                if (((SalString)(colsCodeDemand.Text)).Left(1) == "1")
                {
                    sMyDemand = ((SalString)colsCodeDemand.Text).Mid(nCodePartNum * 2 + nPos, 1);
                }
                else
                {
                    if (sColName != "colsProcessCodeP")
                    {
                        sMyDemand = ((SalString)colsCodeDemand.Text).Mid(nCodePartNum * 8 + nPos2, 1);
                    }
                    else
                    {
                        return Ifs.Fnd.ApplicationForms.Int.PalAttrGet("PROCESSCODE", colsCodeDemand.Text);
                    }
                }
                return sMyDemand;
            }
            #endregion
        }
        // ! Build the Foundation Attr String for the child values
        /// <summary>
        /// </summary>
        /// <param name="sPAttr"></param>
        /// <returns></returns>
        public virtual SalNumber BuildAttrForChildTable(ref SalString sPAttr)
        {
            #region Local Variables
            SalString sValue = "";
            SalWindowHandle hWndCol = SalWindowHandle.Null;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sPAttr = Ifs.Fnd.ApplicationForms.Const.strNULL;
                nIndex = 1;
                while (true)
                {
                    hWndCol = Sal.TblGetColumnWindow(i_hWndFrame, nIndex, Sys.COL_GetID);
                    if (hWndCol == SalWindowHandle.Null)
                    {
                        break;
                    }
                    if (Sal.WindowIsDerivedFromClass(hWndCol, typeof(cColumn)))
                    {
                        sValue = SalString.FromHandle(Sal.SendMsg(hWndCol, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0));
                        sPAttr = sPAttr + cColumn.FromHandle(hWndCol).p_sSqlColumn + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + sValue + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
                    }
                    nIndex = nIndex + 1;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// Copy server attributes from string to variable.
        /// </summary>
        /// <param name="sPAttr"></param>
        /// <param name="sPCodePart"></param>
        /// <returns></returns>
        public virtual SalNumber AttrDecodeCodePart(SalString sPAttr, SalArray<SalString> sPCodePart)
        {
            #region Local Variables
            SalArray<SalString> sAttr = new SalArray<SalString>();
            SalArray<SalString> sField = new SalArray<SalString>();
            SalNumber n = 0;
            SalString sResult = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Ifs.Fnd.ApplicationForms.Var.Console.TextAdd(Ifs.Fnd.ApplicationForms.Const.CONS_Debug, "  ===  AttrDecodeCodePart( '" + sPAttr + "')");
                sPAttr.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), sAttr);
                n = 0;
                sResult = Ifs.Fnd.ApplicationForms.Const.strNULL;
                while (sAttr[n] != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    sField[1] = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    sAttr[n].Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), sField);
                    // There are 9 code parts
                    sPCodePart[n] = sField[1];
                    n = n + 1;
                }
                sPAttr = sResult;
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
                nColumnId = Sal.TblQueryColumnID(colsCodeB);
                nId = 1;
                // Get the Demand of each column from colCodeDemand
                // For the columns where demand set to 'S', clear the field using SalClearField() function
                while (nId < 20)
                {
                    hWndCol = Sal.TblGetColumnWindow(i_hWndSelf, nColumnId + nId - 1, Sys.COL_GetID);
                    sMyDemand = GetMyDemand(hWndCol);
                    if (!(Sal.IsNull(hWndCol)) && sMyDemand == "S")
                    {
                        Sal.ClearField(hWndCol);
                        Sal.SetFieldEdit(hWndCol, true);
                    }
                    nId = nId + 1;
                }
            }

            return 0;
            #endregion
        }
        // ! Validate Code String Requirements
        /// <summary>
        /// </summary>
        /// <param name="hToReturn"></param>
        /// <returns></returns>
        public virtual SalWindowHandle f_Handle(SalWindowHandle hToReturn)
        {
            #region Actions
            using (new SalContext(this))
            {
                return hToReturn;
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
            SalArray<SalWindowHandle> hColCodePart = new SalArray<SalWindowHandle>(10);
            SalString sCodeDemand = "";
            // Bug 86955 begin
            SalString strTarget = "";
            // Bug 86955 end
            SalNumber nStrLen = 0;
            SalNumber nCount = 0;
            SalNumber nCodePartNum = 0;
            SalString sColName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sCodeDemand = colsCodeDemand.Text;
                nTemp = ((SalString)colsCodeDemand.Text).Scan("M");
                hPColumn = SalWindowHandle.Null;
                if (nTemp == -1)
                {
                    // everything is OK !
                    return true;
                }
                else
                {
                    // Make an array of CodePart Window handles
                    hWndTemp = f_Handle(colsAccount);
                    nCount = 0;
                    nIndex = 0;
                    while (nCount < 20)
                    {
                        hWndTemp = Sal.GetNextChild(hWndTemp, Sys.TYPE_TableColumn);
                        Sal.GetItemName(hWndTemp, ref sColName);
                        // Do not include the description columns
                        if (sColName.Scan("DESC") == -1)
                        {
                            hColCodePart[nIndex] = hWndTemp;
                            nIndex = nIndex + 1;
                        }
                        nCount = nCount + 1;
                    }
                    // Get the Code Part Number(B is 0, J is 9 and Process Code)  of Mandatory column that is left NULL
                    nTemp = 0;
                    nStrLen = sCodeDemand.Length;
                    while (true)
                    {
                        nTemp = sCodeDemand.Scan("M");
                        if (nTemp == -1)
                        {
                            return true;
                        }
                        strTarget = sCodeDemand.Mid(nTemp - 3, 2);
                        sCodeDemand = sCodeDemand.Right(nStrLen - nTemp - 1);
                        nStrLen = sCodeDemand.Length;
                        // Bug 86955 begin, if the value of colsCodeName come through a query
                        nTemp1 = sCodeDemand.Scan("CODE");
                        if (nTemp1 != -1)
                        {
                            if (strTarget == "EB")
                            {
                                if (Sal.IsNull(hColCodePart[0]))
                                {
                                    hPColumn = hColCodePart[0];
                                    return false;
                                }
                                // Else
                                // Return TRUE
                            }
                            if (strTarget == "EC")
                            {
                                if (Sal.IsNull(hColCodePart[1]))
                                {
                                    hPColumn = hColCodePart[1];
                                    return false;
                                }
                                // Else
                                // Return TRUE
                            }
                            if (strTarget == "ED")
                            {
                                if (Sal.IsNull(hColCodePart[2]))
                                {
                                    hPColumn = hColCodePart[2];
                                    return false;
                                }
                                // Else
                                // Return TRUE
                            }
                            if (strTarget == "EE")
                            {
                                if (Sal.IsNull(hColCodePart[3]))
                                {
                                    hPColumn = hColCodePart[3];
                                    return false;
                                }
                                // Else
                                // Return TRUE
                            }
                            if (strTarget == "EF")
                            {
                                if (Sal.IsNull(hColCodePart[4]))
                                {
                                    hPColumn = hColCodePart[4];
                                    return false;
                                }
                                // Else
                                // Return TRUE
                            }
                            if (strTarget == "EG")
                            {
                                if (Sal.IsNull(hColCodePart[5]))
                                {
                                    hPColumn = hColCodePart[5];
                                    return false;
                                }
                                // Else
                                // Return TRUE
                            }
                            if (strTarget == "EH")
                            {
                                if (Sal.IsNull(hColCodePart[6]))
                                {
                                    hPColumn = hColCodePart[6];
                                    return false;
                                }
                                // Else
                                // Return TRUE
                            }
                            if (strTarget == "EI")
                            {
                                if (Sal.IsNull(hColCodePart[7]))
                                {
                                    hPColumn = hColCodePart[7];
                                    return false;
                                }
                                // Else
                                // Return TRUE
                            }
                            if (strTarget == "EJ")
                            {
                                if (Sal.IsNull(hColCodePart[8]))
                                {
                                    hPColumn = hColCodePart[8];
                                    return false;
                                }
                                // Else
                                // Return TRUE
                            }
                            if (strTarget == "DE")
                            {
                                if (Sal.IsNull(hColCodePart[9]))
                                {
                                    hPColumn = hColCodePart[9];
                                    return false;
                                }
                                // Else
                                // Return TRUE
                            }
                        }
                        if (nTemp1 == -1)
                        {
                            nTemp2 = sCodeDemand.Scan("TEX");
                            if (nTemp2 != -1)
                            {
                                if (strTarget == "DE")
                                {
                                    if (Sal.IsNull(hColCodePart[9]))
                                    {
                                        hPColumn = hColCodePart[9];
                                        return false;
                                    }
                                    break;
                                }
                            }
                            nCodePartNum = nCodePartNum + (nTemp + 1) / 2;
                            if (Sal.IsNull(hColCodePart[nCodePartNum - 1]))
                            {
                                // Return the Handle of the column that is Mandatory and Null
                                hPColumn = hColCodePart[nCodePartNum - 1];
                                return false;
                            }
                        }
                        // Bug 86955 end
                    }
                    return true;
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataRecordCheckRequired()
        {
            #region Local Variables
            SalWindowHandle hColumn_R = SalWindowHandle.Null;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Ifs.Fnd.ApplicationForms.Var.Console.Add("*************** DataRecordValidate Called");
                Sal.WaitCursor(true);
                if (Sal.IsNull(colsAccount))
                {
                    DataRecordShowRequired(colsAccount);
                    Sal.WaitCursor(false);
                    return false;
                }
                // Check that user has specified Mandatory Code Parts
                if (!(CheckMandatoryCodeParts(ref hColumn_R)))
                {
                    DataRecordShowRequired(hColumn_R);
                    Sal.WaitCursor(false);
                    return false;
                }
                Sal.WaitCursor(false);
                return true;
            }
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
                Sal.WaitCursor(true);
                // Security check
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Text_Field_Translation_API.Get_Text"))
                {
                    lsStmt = SalString.Null;
                    if (Sal.IsWindowVisible(colsAccountDesc) && (sCodePart == "A"))
                    {
                        lsStmt = lsStmt + ":i_hWndFrame.tbwPseudoCode.colsAccountDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwPseudoCode.colsCompany,'CODEA', :i_hWndFrame.tbwPseudoCode.colsAccount); ";
                    }
                    if (Sal.IsWindowVisible(colsCodeBDesc) && (sCodePart == "B"))
                    {
                        lsStmt = lsStmt + ":i_hWndFrame.tbwPseudoCode.colsCodeBDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwPseudoCode.colsCompany,'CODEB', :i_hWndFrame.tbwPseudoCode.colsCodeB); ";
                    }
                    if (Sal.IsWindowVisible(colsCodeCDesc) && (sCodePart == "C"))
                    {
                        lsStmt = lsStmt + ":i_hWndFrame.tbwPseudoCode.colsCodeCDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwPseudoCode.colsCompany,'CODEC', :i_hWndFrame.tbwPseudoCode.colsCodeC); ";
                    }
                    if (Sal.IsWindowVisible(colsCodeDDesc) && (sCodePart == "D"))
                    {
                        lsStmt = lsStmt + ":i_hWndFrame.tbwPseudoCode.colsCodeDDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwPseudoCode.colsCompany,'CODED', :i_hWndFrame.tbwPseudoCode.colsCodeD); ";
                    }
                    if (Sal.IsWindowVisible(colsCodeEDesc) && (sCodePart == "E"))
                    {
                        lsStmt = lsStmt + ":i_hWndFrame.tbwPseudoCode.colsCodeEDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwPseudoCode.colsCompany,'CODEE', :i_hWndFrame.tbwPseudoCode.colsCodeE); ";
                    }
                    if (Sal.IsWindowVisible(colsCodeFDesc) && (sCodePart == "F"))
                    {
                        lsStmt = lsStmt + ":i_hWndFrame.tbwPseudoCode.colsCodeFDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwPseudoCode.colsCompany,'CODEF', :i_hWndFrame.tbwPseudoCode.colsCodeF); ";
                    }
                    if (Sal.IsWindowVisible(colsCodeGDesc) && (sCodePart == "G"))
                    {
                        lsStmt = lsStmt + ":i_hWndFrame.tbwPseudoCode.colsCodeGDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwPseudoCode.colsCompany,'CODEG', :i_hWndFrame.tbwPseudoCode.colsCodeG); ";
                    }
                    if (Sal.IsWindowVisible(colsCodeHDesc) && (sCodePart == "H"))
                    {
                        lsStmt = lsStmt + ":i_hWndFrame.tbwPseudoCode.colsCodeHDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwPseudoCode.colsCompany,'CODEH', :i_hWndFrame.tbwPseudoCode.colsCodeH); ";
                    }
                    if (Sal.IsWindowVisible(colsCodeIDesc) && (sCodePart == "I"))
                    {
                        lsStmt = lsStmt + ":i_hWndFrame.tbwPseudoCode.colsCodeIDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwPseudoCode.colsCompany,'CODEI', :i_hWndFrame.tbwPseudoCode.colsCodeI) ;";
                    }
                    if (Sal.IsWindowVisible(colsCodeJDesc) && (sCodePart == "J"))
                    {
                        lsStmt = lsStmt + ":i_hWndFrame.tbwPseudoCode.colsCodeJDesc := " + cSessionManager.c_sDbPrefix + "Text_Field_Translation_API.Get_Text(" + ":i_hWndFrame.tbwPseudoCode.colsCompany,'CODEJ', :i_hWndFrame.tbwPseudoCode.colsCodeJ); ";
                    }
                    if (lsStmt != SalString.Null)
                    {
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Text_Field_Translation_API.Get_Text", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + lsStmt + "END;");
                        }
                    }
                }
                Sal.WaitCursor(false);
            }

            return 0;
            #endregion
        }

        public virtual void ClearActivitySecNo(SalString sSender)
        {
            if (sSender.Equals(sProjectCodePart))
            {
                Sal.ClearField(colnProjectActivityId);
            }
            colnProjectActivityId.EditDataItemSetEdited();
        }

        protected virtual void EnableDisableProjectActivityId(SalString sSender)
        {
            #region Local Variables
            SalArray<SalString> sData = new SalArray<SalString>();
            SalString sFormName;
            SalString stmt;
            SalBoolean bExecutionResult;
            #endregion

            #region Actions

            if (sSender.Equals(""))
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
                return;
            }
            if (sSender.Equals(sProjectCodePart))
            {
                using (new SalContext(this))
                {
                    sFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndSelf) + ".";

                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("ACCOUNTING_PROJECT_API.Get_Project_Origin_Db", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        stmt = "BEGIN " + sFormName + "sProjectOrigin :=\r\n" +
                            "&AO.ACCOUNTING_PROJECT_API.Get_Project_Origin_Db(" + sFormName + "colsCompany," + sFormName + sProjectCodePartHandle + "); \r\n END;";

                        bExecutionResult = DbPLSQLBlock(cSessionManager.c_hSql, stmt);

                        if (bExecutionResult)
                        {
                            if (!sProjectOrigin.Equals("PROJECT"))
                            {
                                if (sProjectOrigin.Equals("JOB"))
                                {
                                    colnProjectActivityId.Number = 0;
                                }
                                else if (sProjectOrigin.Equals("FINPROJECT"))
                                {
                                    colnProjectActivityId.Number = SalNumber.Null;
                                }
                                else
                                {
                                    colnProjectActivityId.Number = SalNumber.Null;
                                }

                                System.Windows.Forms.SendKeys.Send("{TAB}");
                            }
                            else
                            {
                                colnProjectActivityId.Number = SalNumber.Null;
                                System.Windows.Forms.SendKeys.Send("{TAB}");
                            }
                            colnProjectActivityId.EditDataItemSetEdited();
                        }

                    }
                }
            }
            #endregion
        }

        protected virtual SalBoolean CheckActSeqValid()
        {
            // Not used anymore verification moved to server side
            #region loval variables

            SalString stmt;
            SalString sFormName;
            SalBoolean bExecutionResult;

            #endregion

            #region actions
            nReturnValue = false;
            using (new SalContext(this))
            {
                sFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndSelf) + ".";

                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("ACTIVITY_api.Is_Activity_Postable", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    stmt = "BEGIN " + sFormName + "nReturnValue :=\r\n" +
                        "&AO.ACTIVITY_api.Is_Activity_Postable(" + sFormName + sProjectCodePartHandle + "," + sFormName + "colnProjectActivityId); \r\n END;";

                    bExecutionResult = DbPLSQLBlock(cSessionManager.c_hSql, stmt);

                    if (bExecutionResult)
                    {
                        return nReturnValue;
                    }
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
        private void tbwPseudoCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tbwPseudoCode_OnPM_DataSourceQueryFieldName(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwPseudoCode_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
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
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwPseudoCode.i_sCompany").ToHandle();
                        return;
                }
            }
            else if (SalString.FromHandle(Sys.lParam) == "project_id")
            {
                switch (Sys.wParam)
                {
                    case Vis.DT_Handle:
                        e.Return = SalWindowHandle.Null.ToNumber();
                        return;

                    default:
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwPseudoCode." + sProjectCodePartHandle).ToHandle();
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
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsPseudoCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsPseudoCode_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsPseudoCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("PSEUDO_CODES_API.Check_If_Account_", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                if (!(this.colsPseudoCode.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "PSEUDO_CODES_API.Check_If_Account_( :i_hWndFrame.tbwPseudoCode.i_sCompany, :i_hWndFrame.tbwPseudoCode.colsPseudoCode)")))
                {
                    e.Return = false;
                    return;
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
        private void colsAccount_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsAccount_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsAccount_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsAccount_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.colsCodePart.Text = "A";
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
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
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (Sal.IsNull(this.colsAccount.i_hWndSelf))
                {
                    // Set the Free Code Parts blocked
                    this.colsCodeDemand.Text = "1S2S3S4S5S6S7S8S9S";
                    this.colsAccountDesc.Text = Sys.STRING_Null;
                    e.Return = true;
                    return;
                }
                else
                {
                    this.sTemp = this.colsAccount.Text;
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("PSEUDO_CODES_API.Validate_Account", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(this.colsAccount.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "PSEUDO_CODES_API.Validate_Account(:i_hWndFrame.tbwPseudoCode.lsTemp, :i_hWndFrame.tbwPseudoCode.i_sCompany,\r\n" +
                            "                                           :i_hWndFrame.tbwPseudoCode.sTemp)")))
                        {
                            e.Return = false;
                            return;
                        }
                    }
                    if (this.lsTemp.Trim() == "")
                    {
                        e.Return = false;
                        return;
                    }
                    this.colsCodeDemand.Text = this.lsTemp.Left(21);
                    // There are two cases here. User would either like the Fixed Code String or the Code String Completion
                    // Get the complete code string
                    if (Var.g_bUseTemFCS)
                    {

                        this.colsCodeB.Text = Var.g_sFCSTemCodeB;
                        this.colsCodeC.Text = Var.g_sFCSTemCodeC;
                        this.colsCodeD.Text = Var.g_sFCSTemCodeD;
                        this.colsCodeE.Text = Var.g_sFCSTemCodeE;
                        this.colsCodeF.Text = Var.g_sFCSTemCodeF;
                        this.colsCodeG.Text = Var.g_sFCSTemCodeG;
                        this.colsCodeH.Text = Var.g_sFCSTemCodeH;
                        this.colsCodeI.Text = Var.g_sFCSTemCodeI;
                        this.colsCodeJ.Text = Var.g_sFCSTemCodeJ;
                    }
                    else
                    {
                        this.lsTemp = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        this.lsTemp1 = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        this.BuildAttrForChildTable(ref this.lsTemp1);
                        this.lsStmt = cSessionManager.c_sDbPrefix + "PSEUDO_CODES_API.Get_Complete_Codestr( :i_hWndFrame.tbwPseudoCode.lsTemp, :i_hWndFrame.tbwPseudoCode.lsTemp1 ) ";
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("PSEUDO_CODES_API.Get_Complete_Codestr", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
                            if (this.colsAccount.DbPLSQLBlock(cSessionManager.c_hSql, this.lsStmt))
                            {

                                if (sProjectCodePart.Equals('B') && !this.colsCodeB.Text.Equals(this.sCodeParts[1]))
                                {
                                    this.ClearActivitySecNo("B");
                                }
                                else if (sProjectCodePart.Equals('C') && !this.colsCodeC.Text.Equals(this.sCodeParts[2]))
                                {
                                    this.ClearActivitySecNo("C");
                                }
                                else if (sProjectCodePart.Equals('D') && !this.colsCodeD.Text.Equals(this.sCodeParts[3]))
                                {
                                    this.ClearActivitySecNo("D");
                                }
                                else if (sProjectCodePart.Equals('E') && !this.colsCodeE.Text.Equals(this.sCodeParts[4]))
                                {
                                    this.ClearActivitySecNo("E");
                                }
                                else if (sProjectCodePart.Equals('F') && !this.colsCodeF.Text.Equals(this.sCodeParts[5]))
                                {
                                    this.ClearActivitySecNo("F");
                                }
                                else if (sProjectCodePart.Equals('G') && !this.colsCodeG.Text.Equals(this.sCodeParts[6]))
                                {
                                    this.ClearActivitySecNo("G");
                                }
                                else if (sProjectCodePart.Equals('H') && !this.colsCodeH.Text.Equals(this.sCodeParts[7]))
                                {
                                    this.ClearActivitySecNo("H");
                                }
                                else if (sProjectCodePart.Equals('I') && !this.colsCodeI.Text.Equals(this.sCodeParts[8]))
                                {
                                    this.ClearActivitySecNo("I");
                                }
                                else if (sProjectCodePart.Equals('J') && !this.colsCodeJ.Text.Equals(this.sCodeParts[9]))
                                {
                                    this.ClearActivitySecNo("J");
                                }

                                this.AttrDecodeCodePart(this.lsTemp, this.sCodeParts);
                                this.colsCodeB.Text = this.sCodeParts[1];
                                this.colsCodeC.Text = this.sCodeParts[2];
                                this.colsCodeD.Text = this.sCodeParts[3];
                                this.colsCodeE.Text = this.sCodeParts[4];
                                this.colsCodeF.Text = this.sCodeParts[5];
                                this.colsCodeG.Text = this.sCodeParts[6];
                                this.colsCodeH.Text = this.sCodeParts[7];
                                this.colsCodeI.Text = this.sCodeParts[8];
                                this.colsCodeJ.Text = this.sCodeParts[9];
                                this.colsCodeB.EditDataItemSetEdited();
                                this.colsCodeC.EditDataItemSetEdited();
                                this.colsCodeD.EditDataItemSetEdited();
                                this.colsCodeE.EditDataItemSetEdited();
                                this.colsCodeF.EditDataItemSetEdited();
                                this.colsCodeG.EditDataItemSetEdited();
                                this.colsCodeH.EditDataItemSetEdited();
                                this.colsCodeI.EditDataItemSetEdited();
                                this.colsCodeJ.EditDataItemSetEdited();
                            }
                        }
                    }
                    this.ClearBlockedCodeParts();
                    Sal.SendMsg(this.colsCodeB, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                    Sal.SendMsg(this.colsCodeC, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                    Sal.SendMsg(this.colsCodeD, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                    Sal.SendMsg(this.colsCodeE, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                    Sal.SendMsg(this.colsCodeF, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                    Sal.SendMsg(this.colsCodeG, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                    Sal.SendMsg(this.colsCodeH, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                    Sal.SendMsg(this.colsCodeI, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                    Sal.SendMsg(this.colsCodeJ, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                    this.FetchDescription("A");
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
        private void colsCodeB_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeB_OnSAM_SetFocus(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsCodeB_OnPM_DataItemValidate(sender, e);
                    this.EnableDisableProjectActivityId("B");
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.ClearActivitySecNo("B");
                    break;

            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeB_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.colsCodePart.Text = "B";
            if (this.CodePartSetFocus(this.colsCodeB.i_hWndSelf, "B", this.colsCodeB.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeB_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.colsCodeB.i_hWndSelf))
            {
                this.colsCodeBDesc.Text = Sys.STRING_Null;
            }
            else
            {
                this.FetchDescription("B");
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
        private void colsCodeBDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeBDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeBDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colsCodeB);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colsCodeBDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
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
        private void colsCodeC_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeC_OnSAM_SetFocus(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsCodeC_OnPM_DataItemValidate(sender, e);
                    this.EnableDisableProjectActivityId("C");
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.ClearActivitySecNo("C");
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeC_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.colsCodePart.Text = "C";
            if (this.CodePartSetFocus(this.colsCodeC.i_hWndSelf, "C", this.colsCodeC.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeC_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.colsCodeC.i_hWndSelf))
            {
                this.colsCodeCDesc.Text = Sys.STRING_Null;
            }
            else
            {
                this.FetchDescription("C");
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
        private void colsCodeCDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeCDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeCDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colsCodeC);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colsCodeCDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
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
        private void colsCodeD_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeD_OnSAM_SetFocus(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsCodeD_OnPM_DataItemValidate(sender, e);
                    this.EnableDisableProjectActivityId("D");
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.ClearActivitySecNo("D");
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeD_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.colsCodePart.Text = "D";
            if (this.CodePartSetFocus(this.colsCodeD.i_hWndSelf, "D", this.colsCodeD.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeD_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.colsCodeD.i_hWndSelf))
            {
                this.colsCodeDDesc.Text = Sys.STRING_Null;
            }
            else
            {
                this.FetchDescription("D");
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
        private void colsCodeDDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeDDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeDDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colsCodeD);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colsCodeDDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
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
        private void colsCodeE_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeE_OnSAM_SetFocus(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsCodeE_OnPM_DataItemValidate(sender, e);
                    this.EnableDisableProjectActivityId("E");
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.ClearActivitySecNo("E");
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeE_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.colsCodePart.Text = "E";
            if (this.CodePartSetFocus(this.colsCodeE.i_hWndSelf, "E", this.colsCodeE.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeE_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.colsCodeE.i_hWndSelf))
            {
                this.colsCodeEDesc.Text = Sys.STRING_Null;
            }
            else
            {
                this.FetchDescription("E");
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
        private void colsCodeEDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeEDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeEDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colsCodeE);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colsCodeEDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
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
        private void colsCodeF_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeF_OnSAM_SetFocus(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsCodeF_OnPM_DataItemValidate(sender, e);
                    this.EnableDisableProjectActivityId("F");
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.ClearActivitySecNo("F");
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeF_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.colsCodePart.Text = "F";
            if (this.CodePartSetFocus(this.colsCodeF.i_hWndSelf, "F", this.colsCodeF.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeF_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.colsCodeF.i_hWndSelf))
            {
                this.colsCodeFDesc.Text = Sys.STRING_Null;
            }
            else
            {
                this.FetchDescription("F");
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
        private void colsCodeFDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeFDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeFDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colsCodeF);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colsCodeFDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
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
        private void colsCodeG_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeG_OnSAM_SetFocus(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsCodeG_OnPM_DataItemValidate(sender, e);
                    this.EnableDisableProjectActivityId("G");
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.ClearActivitySecNo("G");
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeG_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.colsCodePart.Text = "G";
            if (this.CodePartSetFocus(this.colsCodeG.i_hWndSelf, "G", this.colsCodeG.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeG_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.colsCodeG.i_hWndSelf))
            {
                this.colsCodeGDesc.Text = Sys.STRING_Null;
            }
            else
            {
                this.FetchDescription("G");
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
        private void colsCodeGDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeGDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeGDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colsCodeG);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colsCodeGDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
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
        private void colsCodeH_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeH_OnSAM_SetFocus(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsCodeH_OnPM_DataItemValidate(sender, e);
                    this.EnableDisableProjectActivityId("H");
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.ClearActivitySecNo("H");
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeH_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.colsCodePart.Text = "H";
            if (this.CodePartSetFocus(this.colsCodeH.i_hWndSelf, "H", this.colsCodeH.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeH_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.colsCodeH.i_hWndSelf))
            {
                this.colsCodeHDesc.Text = Sys.STRING_Null;
            }
            else
            {
                this.FetchDescription("H");
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
        private void colsCodeHDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeHDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeHDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colsCodeH);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colsCodeHDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
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
        private void colsCodeI_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeI_OnSAM_SetFocus(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsCodeI_OnPM_DataItemValidate(sender, e);
                    this.EnableDisableProjectActivityId("I");
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.ClearActivitySecNo("I");
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeI_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.colsCodePart.Text = "I";
            if (this.CodePartSetFocus(this.colsCodeI.i_hWndSelf, "I", this.colsCodeI.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeI_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.colsCodeI.i_hWndSelf))
            {
                this.colsCodeIDesc.Text = Sys.STRING_Null;
            }
            else
            {
                this.FetchDescription("I");
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
        private void colsCodeIDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeIDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeIDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colsCodeI);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colsCodeIDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
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
        private void colsCodeJ_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeJ_OnSAM_SetFocus(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsCodeJ_OnPM_DataItemValidate(sender, e);
                    this.EnableDisableProjectActivityId("J");
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.ClearActivitySecNo("J");
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeJ_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.colsCodePart.Text = "J";
            if (this.CodePartSetFocus(this.colsCodeJ.i_hWndSelf, "J", this.colsCodeJ.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeJ_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.colsCodeJ.i_hWndSelf))
            {
                this.colsCodeJDesc.Text = Sys.STRING_Null;
            }
            else
            {
                this.FetchDescription("J");
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
        private void colsCodeJDesc_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsCodeJDesc_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCodeJDesc_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nCodePartId = Sal.TblQueryColumnID(this.colsCodeJ);
            this.hWndCodePart = Sal.TblGetColumnWindow(this.colsCodeJDesc.i_hWndFrame, this.nCodePartId, Sys.COL_GetID);
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
        private void colsProcessCodeP_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.colsProcessCodeP_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsProcessCodeP_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.CodePartSetFocus(this.colsProcessCodeP.i_hWndSelf, "P", this.colsProcessCodeP.Text))
            {
                Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                e.Return = true;
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
        private void colsPseudoCodeOwnership_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.colsPseudoCodeOwnership_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsPseudoCodeOwnership_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            e.Handled = true;
            if (Ifs.Fnd.ApplicationForms.Int.FndUser() == this.colsUserName.Text)
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
            else
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
        }

        private void colnProjectActivityId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.colnProjectActivityId_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        private void colnProjectActivityId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;


            if (Ifs.Application.Accrul.Int.IsGenLedInstalled && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("ACCOUNTING_PROJECT_API.Get_Project_Origin_Db"))
            {
                // When no project code part is defined proj activity id will not be editable.
                if(sProjectCodePart.Equals(""))
                {
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                    return;
                }
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    SalString sFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndSelf) + ".";

                    if ((DbPLSQLBlock(@"{0} := &AO.ACCOUNTING_PROJECT_API.Get_Project_Origin_Db( {1} IN, " + sFormName + sProjectCodePartHandle + ") ;",
                        this.QualifiedVarBindName("sProjectOrigin"), this.colsCompany.QualifiedBindName)))
                    {
                        if (!sProjectOrigin.Equals("PROJECT"))
                        {
                            if (sProjectOrigin.Equals("JOB"))
                            {
                                colnProjectActivityId.Number = 0;
                            }
                            else if (sProjectOrigin.Equals("FINPROJECT"))
                            {
                                colnProjectActivityId.Number = SalNumber.Null;
                            }

                            e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                            return;
                        }

                    }
                }
            }


            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_EditStateFieldEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataRecordCheckRequired()
        {
            return this.DataRecordCheckRequired();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtFrameStartupUser()
        {
            sProjectCodePart = Ifs.Application.Accrul.Var.FinlibServices.GetCodePartFunction("PRACC");
            sProjectCodePartHandle = "colsCode" + sProjectCodePart;
            return this.FrameStartupUser();
        }
        public override SalNumber vrtActivate(fcURL URL)
        {
            sProjectCodePart = Ifs.Application.Accrul.Var.FinlibServices.GetCodePartFunction("PRACC");
            sProjectCodePartHandle = "colsCode" + sProjectCodePart;
            // Project activity id column is hidden to revert a EAP request from the RTM code is left to use in further development
            //if (sProjectCodePart.Equals(""))
            //{
            //    Sal.HideWindow(colnProjectActivityId);
            //}
            //else
            //{
            //    Sal.ShowWindow(colnProjectActivityId);
            //}
            return base.vrtActivate(URL);
        }

        public override SalNumber vrtDataSourceSave(SalNumber nWhat)
        {
            return base.vrtDataSourceSave(nWhat);
        }
        #endregion

        #region Event Handlers

        private void menuItem__Translation_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Translation_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
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
            ((FndCommand)sender).Enabled = Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Translation_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
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
