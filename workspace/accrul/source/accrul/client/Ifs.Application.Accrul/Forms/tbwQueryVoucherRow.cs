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
// Date    Assignee  Bug          History
// 130307  Machlk    Bug 107962   Fixed the document connections from docman.
// 130703  AjPelk    Bug 111044   Corrected. 
// 130703  AjPelk    Bug 111044   Corrected. 
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
    [FndWindowRegistration("VOUCHER_ROW_QRY", "VoucherRow", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwQueryVoucherRow : cTableWindowFin
    {
        #region Window Variables
        public SalNumber nCredit = 0;
        public SalNumber nDebet = 0;
        public SalNumber nBalance = 0;
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalNumber nRow = 0;
        public SalString lsSumBalance = "";
        public SalString lsSumDebet = "";
        public SalString lsSumCredit = "";
        public SalString sDataSource = "";
        public SalString lsWhere = "";
        public SalNumber nCreditCorr = 0;
        public SalNumber nDebetCorr = 0;
        public SalString sYes = "";
        public SalString lsSumDebetCorr = "";
        public SalString lsSumCreditCorr = "";
        public SalString lsCompanyRef = "";
        public SalString lsVoucherTypeRef = "";
        public SalNumber nAccountingYearRef = 0;
        public SalNumber nVoucherNoRef = 0;
        public cMessage Msg = new cMessage();
		public SalString sOriginalCompany = "";
        public SalString sOriginalVoucherType = "";
        public SalNumber nOriginalAccYear = 0;
        public SalNumber nOriginalVoucherNo = 0;
		
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwQueryVoucherRow()
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
        public new static tbwQueryVoucherRow FromHandle(SalWindowHandle handle)
        {
            return ((tbwQueryVoucherRow)SalWindow.FromHandle(handle, typeof(tbwQueryVoucherRow)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Local Variables
            // Insert new code here...
            #endregion

            #region Actions
            using (new SalContext(this))
            {
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
            SalNumber nItemIndexVouNo = 0;
            SalNumber nItemIndexVouType = 0;
            SalNumber nItemIndexVouYear = 0;
            SalNumber nRowCounter = 0;
            SalNumber nRows = 0;
            SalNumber nRC = 0;
            SalString sTmp1 = "";
            SalString sTmp2 = "";
            SalString sTmp3 = "";
            SalArray<SalString> sProjForecastItemValues = new SalArray<SalString>();
            SalString sCompany = "";
            SalString sProjectId = "";
            SalString sSubProjectId = "";
            SalString sActivitySeq = "";
            SalString sCostElement = "";
            SalString sInclause = "";
            SalString sUserWhere = "";
            SalString sUserOrderBy = "";
            // Bug 74250, start
            SalNumber nIndex = 0;
            // Bug 74250, end
            // Bug 107962 Begin
            SalNumber nItemIndexRowNo = 0;
            SalString sTmp4 = "";
            SalString sComp = "";
            // Bug 107962 End
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                // Bug 107962 Begin
                SetWindowTitle();
                // Bug 107962 End
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    // Bug 107962 Begin
                    if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet() == "DocReferenceObject" && Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY") >= 0)
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY"), 0, ref i_sCompany);
                        //Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY"), 0, ref sComp);

                        SetWindowTitle();
                    }
                    // Bug 107962 End                    
                    Sal.WaitCursor(true);
                    if (nItemIndex != Ifs.Fnd.ApplicationForms.Const.DTTRF_ColumnNotFound)
                    {
                        nRows = Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet();
                        // Get Column Positions
                        nItemIndexVouNo = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("VOUCHER_NO");
                        nItemIndexVouType = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("VOUCHER_TYPE");
                        nItemIndexVouYear = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("ACCOUNTING_YEAR");
                        // Bug 111044 begin , ROW_NO doest exist at this moment
                        if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet() != "VOUCHER_TYPE")
                        {
                            // Bug 107962 Begin
                            nItemIndexRowNo = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("ROW_NO");
                            // Bug 107962 End
                        }
                        // Bug 111044 end
                        sUserWhere = "";
                        nRowCounter = 0;
                        // Bug 74250, start
                        // Build Where-statement dynamic
                        if (!(Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeGet() == "ProjectForecastItem" || Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeGet() == "ProjectForecastItemActPceOnly"))
                        {
                            // If the window is not opened from Project Forecast Lines
                            while (nRowCounter <= nRows - 1)
                            {
                                nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndexVouType, nRowCounter, ref sTmp1);
                                nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndexVouNo, nRowCounter, ref sTmp2);
                                nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndexVouYear, nRowCounter, ref sTmp3);
                                // Bug 107962 Begin
                                nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndexRowNo, nRowCounter, ref sTmp4);
                                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet() == "DocReferenceObject")
                                {
                                    sUserWhere = sUserWhere + " VOUCHER_TYPE = " + "\'" + sTmp1 + "\'" + " AND VOUCHER_NO = " + "\'" + sTmp2 + "\'" + " AND ACCOUNTING_YEAR = " + "\'" + sTmp3 + "\'" + " AND ROW_NO = " + "\'" + sTmp4 + "\'";
                                }
                                else
                                {
                                    // Bug 107962 End
                                    sUserWhere = sUserWhere + " VOUCHER_TYPE = " + "'" + sTmp1 + "'" + " AND VOUCHER_NO = " + "'" + sTmp2 + "'" + " AND ACCOUNTING_YEAR = " + "'" + sTmp3 + "'";
                                // Bug 107962 Begin
                                }
                                // Bug 107962 End
                                nRowCounter = nRowCounter + 1;
                                if (nRowCounter < nRows)
                                {
                                    sUserWhere = sUserWhere + " OR ";
                                }
                            }
                        }
                        else
                        {
                            if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeGet() == "ProjectForecastItem")
                            {
                                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("COMPANY", sProjForecastItemValues);
                                sCompany = sProjForecastItemValues[0];
                                this.SetCompany(sCompany);
                                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("PROJECT_ID") >= 0)
                                {
                                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("PROJECT_ID", sProjForecastItemValues);
                                    sProjectId = sProjForecastItemValues[0];
                                }
                                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("SUB_PROJECT_ID") >= 0)
                                {
                                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("SUB_PROJECT_ID", sProjForecastItemValues);
                                    sSubProjectId = sProjForecastItemValues[0];
                                }
                                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("PROJECT_ACTIVITY_ID") >= 0)
                                {
                                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("PROJECT_ACTIVITY_ID", sProjForecastItemValues);
                                    sActivitySeq = sProjForecastItemValues[0];
                                }
                                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("PROJECT_COST_ELEMENT") >= 0)
                                {
                                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("PROJECT_COST_ELEMENT", sProjForecastItemValues);
                                    sCostElement = sProjForecastItemValues[0];
                                }
                                sInclause = "in (( ";
                                if (sProjectId == Ifs.Fnd.ApplicationForms.Const.strNULL)
                                {
                                    sInclause = sInclause + " NULL, ";
                                }
                                else
                                {
                                    sInclause = sInclause + " '" + sProjectId + "', ";
                                }
                                if (sSubProjectId == Ifs.Fnd.ApplicationForms.Const.strNULL)
                                {
                                    sInclause = sInclause + " NULL, ";
                                }
                                else
                                {
                                    sInclause = sInclause + " '" + sSubProjectId + "', ";
                                }
                                if (sActivitySeq == Ifs.Fnd.ApplicationForms.Const.strNULL)
                                {
                                    sInclause = sInclause + " NULL, ";
                                }
                                else
                                {
                                    sInclause = sInclause + " " + sActivitySeq + ", ";
                                }
                                if (sCostElement == Ifs.Fnd.ApplicationForms.Const.strNULL)
                                {
                                    sInclause = sInclause + " NULL ";
                                }
                                else
                                {
                                    sInclause = sInclause + " '" + sCostElement + "' ";
                                }
                                sInclause = sInclause + " )) ";
                                // MAKRLK, Twin Peaks, Changes for Project Cost Element Setup, Start
                                sUserWhere = sUserWhere + "(PROJECT_ID, " + "&AO.ACTIVITY_API.GET_SUB_PROJECT_ID(PROJECT_ACTIVITY_ID), " + "PROJECT_ACTIVITY_ID, " + "&AO.Cost_Element_To_Account_API.Get_Project_Follow_Up_Element( " + "COMPANY, " + "ACCOUNT, " + "CODE_B, " +
                                "CODE_C, " + "CODE_D, " + "CODE_E, " + "CODE_F, " + "CODE_G, " + "CODE_H, " + "CODE_I, " + "CODE_J, " + "VOUCHER_DATE " + ")) " + sInclause;
                                // MAKRLK, Twin Peaks, Changes for Project Cost Element Setup, End.
                            }
                            else
                            {
                                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("COMPANY", sProjForecastItemValues);
                                sCompany = sProjForecastItemValues[0];
                                this.SetCompany(sCompany);
                                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("PROJECT_COST_ELEMENT") >= 0)
                                {
                                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("PROJECT_COST_ELEMENT", sProjForecastItemValues);
                                    sCostElement = sProjForecastItemValues[0];
                                }
                                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("PROJECT_ACTIVITY_ID") >= 0)
                                {
                                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("PROJECT_ACTIVITY_ID", sProjForecastItemValues);
                                    nIndex = 0;
                                    while (sProjForecastItemValues[nIndex] != Ifs.Fnd.ApplicationForms.Const.strNULL)
                                    {
                                        if (nIndex == 0)
                                        {
                                            sActivitySeq = sProjForecastItemValues[nIndex];
                                        }
                                        else
                                        {
                                            sActivitySeq = sActivitySeq + ", " + sProjForecastItemValues[nIndex];
                                        }
                                        nIndex = nIndex + 1;
                                    }
                                }
                                sInclause = "in ( ";
                                if (sActivitySeq == Ifs.Fnd.ApplicationForms.Const.strNULL)
                                {
                                    sInclause = sInclause + " NULL ";
                                }
                                else
                                {
                                    sInclause = sInclause + " " + sActivitySeq;
                                }
                                sInclause = sInclause + " ) ";
                                // MAKRLK, Twin Peaks, Changes for Project Cost Element Setup, Start
                                sUserWhere = sUserWhere + " PROJECT_ACTIVITY_ID " + sInclause + "&AO.Cost_Element_To_Account_API.Get_Project_Follow_Up_Element( " + "COMPANY, " + "ACCOUNT, " + "CODE_B, " + "CODE_C, " + "CODE_D, " + "CODE_E, " + "CODE_F, " + "CODE_G, " +
                                "CODE_H, " + "CODE_I, " + "CODE_J, " + "VOUCHER_DATE " + ")  = '" + sCostElement + "'";
                                // MAKRLK, Twin Peaks, Changes for Project Cost Element Setup, End.
                            }
                        }
                        // Bug 74250, end
                        // Check sUserWhere statement length, to avoid application termination problem.
                        if (sUserWhere.Length < 28000)
                        {
                            // Set Order By Clause
                            sUserOrderBy = " ACCOUNTING_YEAR,VOUCHER_TYPE,VOUCHER_NO ";
                            // Send a message for building a new where-sentence
                            // Set 'User Where Clause' in the data source
                            Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sUserWhere.ToHandle());
                            // Set 'User Order By Clause' in the data source
                            Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserOrderBy, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sUserOrderBy.ToHandle());
                            // Populate the data source with selection from the new where-sentence
                            DataSourcePopulate(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
                        }
                        else
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_StringLength, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        }
                    }
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);
                    return false;
                }
                return base.Activate(URL);
            }

            #endregion

        }

        // Bug 78024 Removed method DataSourcePrepareKeyTransfer since it is no longer needed.
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Properties.Resources.WH_tbwQueryVoucherRow;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber Voucher(SalNumber nWhat)
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
                        return Sal.TblAnyRows(this, Sys.ROW_Selected, 0);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "VOUCHER_TYPE";
                        hWndItems[0] = colVoucherType;
                        sItemNames[1] = "VOUCHER_NO";
                        hWndItems[1] = colVoucherNo;
                        sItemNames[2] = "ACCOUNTING_YEAR";
                        hWndItems[2] = colAccountingYear;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("VoucherType", this, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmQueryVoucherDetail"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        break;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber QueryMultiCompanyVoucher(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();			
            SalArray<SalString> sItemValues = new SalArray<SalString>();			
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            SalString sFullName = "";
            SalNumber nRow = 0;
            SalBoolean bTemp = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        nRow = Sys.TBL_MinRow;
                        bTemp = false;
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmMCQueryVoucherDetail"))))
                        {
                            return 0;
                        }
                        while (Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_Selected, 0))
                        {
                            if (colMultiCompanyVoucher.Text == "TRUE")
                            {
                                if (!(Sal.IsNull(colMultiCompanyId)))
                                {
                                    // Bug 94795, Begin
                                    if (colVoucherType.Text != "R")
                                    {
                                        bTemp = true;
                                    }
                                    // Bug 94795, End
                                }
                            }
                        }
                        return bTemp;
                        return 0;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);						
                        // Bug 94795, Begin
                        if (!(Sal.IsNull(colMultiCompanyId)) && !(Sal.IsNull(colVoucherTypeRef)) && colMultiCompanyId.Text != colCompany.Text)
                        {
                            // this is the multi-company. use the reference information if no interim voucher is created otherwise take from the method.                            
                            if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Multi_Company_Voucher_Util_API.Get_Multi_Company_Info( \r\n" +
                                                                   "    :i_hWndFrame.tbwQueryVoucherRow.sOriginalCompany OUT, \r\n" +
                                                                   "    :i_hWndFrame.tbwQueryVoucherRow.nOriginalAccYear OUT, \r\n" +
                                                                   "    :i_hWndFrame.tbwQueryVoucherRow.sOriginalVoucherType OUT, \r\n" +
                                                                   "    :i_hWndFrame.tbwQueryVoucherRow.nOriginalVoucherNo OUT, \r\n" +
                                                                   "    :i_hWndFrame.tbwQueryVoucherRow.colCompany IN, \r\n" +
                                                                   "    :i_hWndFrame.tbwQueryVoucherRow.colAccountingYear IN, \r\n" +
                                                                   "    :i_hWndFrame.tbwQueryVoucherRow.colVoucherType IN, \r\n" +
                                                                   "    :i_hWndFrame.tbwQueryVoucherRow.colVoucherNo IN)")))
                            {
                                return false;
                            }
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet("VOUCHER_DETAIL");
                            sItemValues[0] = sOriginalVoucherType;
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("VOUCHER_TYPE", sItemValues);
                            sItemValues[0] = nOriginalVoucherNo.ToString();
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("VOUCHER_NO", sItemValues);
                            sItemValues[0] = nOriginalAccYear.ToString();
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("ACCOUNTING_YEAR", sItemValues);
                            sItemValues[0] = sOriginalCompany;
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("COMPANY", sItemValues);
                            SessionCreateWindow(Pal.GetActiveInstanceName("frmMCQueryVoucherDetail"), Sys.hWndMDI);
                            Sal.WaitCursor(false);
                        }
                        else
                        {
                            sItemNames[0] = "VOUCHER_TYPE";
                            hWndItems[0] = colVoucherType;
                            sItemNames[1] = "VOUCHER_NO";
                            hWndItems[1] = colVoucherNo;
                            sItemNames[2] = "ACCOUNTING_YEAR";
                            hWndItems[2] = colAccountingYear;
                            sItemNames[3] = "COMPANY";
                            hWndItems[3] = colCompany;

                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("VOUCHER_DETAIL", this, sItemNames, hWndItems);
                            SessionCreateWindow(Pal.GetActiveInstanceName("frmMCQueryVoucherDetail"), Sys.hWndMDI);
                            Sal.WaitCursor(false);
                        }
                        // Bug 94795, End                        
                        break;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// This function returns TRUE, if only one row in table window is selected
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean OnlyOneRowSelected()
        {
            #region Local Variables
            SalNumber nOldRow = 0;
            SalNumber nRow = 0;
            SalNumber nSelRows = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nOldRow = Sal.TblQueryContext(i_hWndSelf);
                nRow = Sys.TBL_MinRow;
                nSelRows = 0;
                while (true)
                {
                    if (Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_Selected, Sys.ROW_MarkDeleted))
                    {
                        Sal.TblSetContext(i_hWndSelf, nRow);
                        nSelRows = nSelRows + 1;
                    }
                    else
                    {
                        break;
                    }
                }
                Sal.TblSetContext(i_hWndSelf, nOldRow);
                if (nSelRows != 1)
                {
                    return false;
                }
                return true;
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
        private void tbwQueryVoucherRow_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged:
                    this.tbwQueryVoucherRow_OnPM_UserProfileChanged(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.tbwQueryVoucherRow_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.tbwQueryVoucherRow_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_AttachmentKeysGet:
                    this.tbwQueryVoucherRow_OnPM_AttachmentKeysGet(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_UserProfileChanged event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwQueryVoucherRow_OnPM_UserProfileChanged(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged, Sys.wParam, Sys.lParam))
            {
                this.nBalance = 0;
                this.nCredit = 0;
                this.nDebet = 0;
            }
            else
            {
                e.Return = false;
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwQueryVoucherRow_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
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
                        e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + ".tbwQueryVoucherRow.i_sCompany").ToHandle();
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
        private void tbwQueryVoucherRow_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    tbwQueryVoucherRow.FromHandle(this.i_hWndFrame).dfCodePartValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    tbwQueryVoucherRow.FromHandle(this.i_hWndFrame).dfDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
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
        /// PM_AttachmentKeysGet event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwQueryVoucherRow_OnPM_AttachmentKeysGet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.Msg.Construct();
            this.Msg.AddAttribute("ACCOUNTING_YEAR", Sal.WindowHandleToNumber(this.colAccountingYear).ToString(0));
            this.Msg.AddAttribute("COMPANY", Sal.WindowHandleToNumber(this.colCompany).ToString(0));
            this.Msg.AddAttribute("VOUCHER_NO", Sal.WindowHandleToNumber(this.colVoucherNo).ToString(0));
            this.Msg.AddAttribute("VOUCHER_TYPE", Sal.WindowHandleToNumber(this.colVoucherType).ToString(0));
            this.Msg.AddAttribute("ROW_NO", Sal.WindowHandleToNumber(this.colnRowNo).ToString(0));
            e.Return = this.Msg.Pack().ToHandle();
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfCodePartValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Const.PAM_SetCodePartValue:
                    this.dfCodePartValue_OnPAM_SetCodePartValue(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PAM_SetCodePartValue event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfCodePartValue_OnPAM_SetCodePartValue(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsWindowVisible(this.dfCodePartValue.i_hWndSelf))
            {
                Sal.SetWindowText(this.dfCodePartValue.i_hWndSelf, cTableWindowFin.sCodePartValue);
                e.Return = true;
                return;
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods

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

        // Devlog: 143762
        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataSourceClearIt(SalNumber nParam)
        {
            #region Actions
            dfCodePartValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            dfDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            return base.vrtDataSourceClearIt(nParam);
            #endregion
        }
        #endregion

        #region Event Handlers

        private void menuItem_Voucher_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Voucher_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_View_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = QueryMultiCompanyVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_View_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            QueryMultiCompanyVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        private void menuItem_Voucher_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Voucher_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Voucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_View_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = QueryMultiCompanyVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_View_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            QueryMultiCompanyVoucher(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
        }

        private void menuItem_Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Sal.SendClassMessage(Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        #endregion

    }
}
