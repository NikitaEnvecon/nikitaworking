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
//120216  Hawalk  SFI-2334, Merged bugs 100135 (75 correction done by Kanslk) and 101066, Modified frmPostCtrlDet to accomodate new parameter to 
//120216                    Posting_Ctrl_Control_Type_API.Get_Control_Type_Desc_(). Moved GetControlTypeDesc() into the child table tblPostCtrlDet because  
//120216                    valid_from from there (child table) has to be used therein (method).                      
//130627  Maaylk  Bug 108854, Added DataSourcePopulateIt() to tblPostCtrlDet and called GetControlTypeAttribs() inside it.
//140227  Shedlk  PBFI-4125, Merged LCS bug 112945
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
using System.Collections.Generic;

namespace Ifs.Application.Accrul_
{
	
	/// <summary>
	/// </summary>
    public partial class frmPostCtrlDet : cFormWindowFin
    {
        #region Window Variables
        public SalBoolean bReturn = false;
        public SalString sControlTypeName = "";
        public SalString sCodePartName = "";
        public SalString sCodePart = "";
        public SalString sView = "";
        public SalString sModule = "";
        public SalString sDescription = "";
        public SalString sCtrlTypeCategory = "";
        public SalString sPkgName = "";
        public SalString sControlType = "";
        public SalString sControlTypeValue = "";
        public SalString sControlTypeValueDesc = "";
        public SalString sSql = "";
        public SalString sCodePartValue = "";
        public SalString sCodePartValueDesc = "";
        public SalString sTempLovReference = "";
        public SalString sDummy1 = "";
        public SalString sDummy2 = "";
        public SalString sDummy3 = "";
        public SalString sDummy4 = "";
        public SalString sCctEnabled = "";
        public SalBoolean bNew = false;
        public SalWindowHandle hWndNavigator = SalWindowHandle.Null;
        public SalDateTime dPCStartDate = SalDateTime.Null;
        public SalDateTime dPCEndDate = SalDateTime.Null;
        public SalDateTime dStartDate = SalDateTime.Null;
        public SalDateTime dEndDate = SalDateTime.Null;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmPostCtrlDet()
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
        public new static frmPostCtrlDet FromHandle(SalWindowHandle handle)
        {
            return ((frmPostCtrlDet)SalWindow.FromHandle(handle, typeof(frmPostCtrlDet)));
        }
        #endregion

        #region Methods
        /// <summary>
        /// </summary>
        /// <returns></returns>        
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    // Bug 75985, Begin
                    ExtractDataTransferAttributes();
                    GetControlTypeAttribs();
                    // Bug 75985, End
                    InitFromTransferredData();
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    // Bug 75985, Removed Call to GetControlTypeAttribs
                    // GetControlTypeAttribs();
                    bNew = false;
                    // Bug 75985, Begin
                    sCodePartName = dfsCodeName.Text;
                    Sal.TblSetColumnTitle(tblPostCtrlDet_colCodePartValue, sCodePartName);
                    // Bug 75985, End
                    Sal.WaitCursor(false);
                    return false;
                }
                return base.Activate(URL);
            }
            #endregion

        }

		// Bug 108854. Removed Function: DataSourcePopulateIt

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean GetControlTypeAttribs()
        {
            #region Actions
            using (new SalContext(this))
            {
                sControlType = dfControlType.Text;
                sModule = dfModule.Text;

                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Posting_Ctrl_Control_Type_API.Get_Control_Type_Attri_") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Reference_SYS.Get_Lov_Properties"))
                {                    
                        string stmt = @"DECLARE
								            view_ 			VARCHAR2(200); 
                                            no_param_view_	VARCHAR2(200); 
                            	            temp_num_		NUMBER := 0; 
                                        BEGIN 
								            &AO.Posting_Ctrl_Control_Type_API.Get_Control_Type_Attri_( 
                                                               :i_hWndFrame.frmPostCtrlDet.sDescription OUT, 
                                                               :i_hWndFrame.frmPostCtrlDet.sCtrlTypeCategory OUT, 
													            view_ , 
                                                               :i_hWndFrame.frmPostCtrlDet.sPkgName OUT, 
                                                               :i_hWndFrame.frmPostCtrlDet.sControlType IN, 
                                                               :i_hWndFrame.frmPostCtrlDet.sModule IN, 
												               :i_hWndFrame.frmPostCtrlDet.i_sCompany IN); 
                                            :i_hWndFrame.frmPostCtrlDet.sView := view_; 
                                            temp_num_ := INSTR(view_, '('); 
							                IF temp_num_ > 0 THEN 
								              no_param_view_ := substr(view_,1,temp_num_ - 1); 
							                ELSE 
								              no_param_view_ := view_; 
							                END IF; 
                            	            &AO.Reference_SYS.Get_Lov_Properties( 
                                                               no_param_view_, 
                                                               :i_hWndFrame.frmPostCtrlDet.sDummy1 OUT, 
                                                               :i_hWndFrame.frmPostCtrlDet.sDummy2 OUT, 
                                                               :i_hWndFrame.frmPostCtrlDet.sDummy3 OUT, 
                                                               :i_hWndFrame.frmPostCtrlDet.sDummy4 OUT); 
                            	            :i_hWndFrame.frmPostCtrlDet.sCctEnabled := &AO.Posting_Ctrl_Posting_Type_API.Cct_Enabled(:i_hWndFrame.frmPostCtrlDet.ccPostingType.i_sMyValue IN);	
							            END;";

                        if (!(DbPLSQLBlock(cSessionManager.c_hSql,stmt )))
                        {
                            return false;
                        }
                                        
                }
                Sal.TblSetColumnTitle(tblPostCtrlDet_colControlTypeValue, sDescription);
                if (dfControlType.Text == "FAC4")
                {
                    // Bug 112945, Begin, Added FAP35 through FAP38 to if condition
                    if (ccPostingType.i_sMyValue == "FAP7" || ccPostingType.i_sMyValue == "FAP8" || ccPostingType.i_sMyValue == "FAP9" || ccPostingType.i_sMyValue == "FAP11" || ccPostingType.i_sMyValue == "FAP12" || ccPostingType.i_sMyValue == "FAP19" ||
                        ccPostingType.i_sMyValue == "FAP20" || ccPostingType.i_sMyValue == "FAP25" || ccPostingType.i_sMyValue == "FAP26" || ccPostingType.i_sMyValue == "FAP27" || ccPostingType.i_sMyValue == "FAP35" || ccPostingType.i_sMyValue == "FAP36" ||
                        ccPostingType.i_sMyValue == "FAP37" || ccPostingType.i_sMyValue == "FAP38")
                    {
                        sView = "TRANSACTION_REASON_DISPOSAL(COMPANY)";
                    }
                    // Bug 112945, End
                    if (ccPostingType.i_sMyValue == "FAP2" || ccPostingType.i_sMyValue == "FAP13" || ccPostingType.i_sMyValue == "FAP14" || ccPostingType.i_sMyValue == "FAP22" || ccPostingType.i_sMyValue == "FAP28" || ccPostingType.i_sMyValue == "FAP29")
                    {
                        sView = "TRANSACTION_REASON_ACQUISITION(COMPANY)";
                    }
                    if (ccPostingType.i_sMyValue == "FAP15" || ccPostingType.i_sMyValue == "FAP16" || ccPostingType.i_sMyValue == "FAP30" || ccPostingType.i_sMyValue == "FAP31" || ccPostingType.i_sMyValue == "FAP33")
                    {
                        sView = "TRANSACTION_REASON_DEPRECIATE(COMPANY)";
                    }
                    if (ccPostingType.i_sMyValue == "FAP4" || ccPostingType.i_sMyValue == "FAP24" || ccPostingType.i_sMyValue == "FAP32" || ccPostingType.i_sMyValue == "FAP34")
                    {
                        sView = "TRANSACTION_REASON_IMPORT(COMPANY)";
                    }                    
                }                
                if (ccPostingType.i_sMyValue == "IP3" || ccPostingType.i_sMyValue == "PP18" || ccPostingType.i_sMyValue == "PP44" || ccPostingType.i_sMyValue == "PP48" || ccPostingType.i_sMyValue == "PP49" || ccPostingType.i_sMyValue == "IP9" || ccPostingType.i_sMyValue ==
                "IP10")
                {
                    if (dfControlType.Text == "AC7")
                    {
                        sView = "STATUTORY_FEE_DEDUCTIBLE(COMPANY)";
                    }
                }                
                sCodePartName = dfsCodeName.Text;
                Sal.TblSetColumnTitle(tblPostCtrlDet_colCodePartValue, sCodePartName);
                return true;
            }
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
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (ccPostingType.i_sMyValue == SalString.Null)
                        {
                            return false;
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        // Bug 75959, Begin, replaced dfPostingType by ccPostingType.i_sMyValue
                        dlgPostingCtrlCopyDetails.ModalDialog(i_hWndSelf, dfCompany.Text, ccPostingType.i_sMyValue, SalString.Null, dfCodePart.Text, dfsCodeName.Text, dfControlType.Text, SalString.Null, dfModule.Text, dfPcValidFrom.DateTime);
                        // Bug 75959, End
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
        /// <param name="sWhereChild"></param>
        /// <param name="dValidFrom"></param>
        /// <param name="dPCValidFrom"></param>
        /// <returns></returns>
        public virtual SalNumber SetWhere(SalString sWhere, SalString sWhereChild, SalDateTime dValidFrom, SalDateTime dPCValidFrom)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (dValidFrom != SalDateTime.Null)
                {
                    Int.PalDateGetDayInterval(dValidFrom, ref dStartDate, ref dEndDate);
                    sWhere = sWhere + " AND (VALID_FROM between :i_hWndFrame.frmPostCtrlDet.dStartDate AND :i_hWndFrame.frmPostCtrlDet.dEndDate) ";
                }
                if (dPCValidFrom != SalDateTime.Null)
                {
                    Int.PalDateGetDayInterval(dPCValidFrom, ref dPCStartDate, ref dPCEndDate);
                    sWhere = sWhere + " AND (PC_VALID_FROM between :i_hWndFrame.frmPostCtrlDet.dPCStartDate AND :i_hWndFrame.frmPostCtrlDet.dPCEndDate) ";
                    sWhereChild = sWhereChild + " AND (PC_VALID_FROM between :i_hWndFrame.frmPostCtrlDet.dPCStartDate AND :i_hWndFrame.frmPostCtrlDet.dPCEndDate) ";
                }
                p_lsDefaultWhere = sWhere;
                tblPostCtrlDet.p_lsDefaultWhere = sWhereChild;
            }

            return 0;
            #endregion
        }
        // Bug 75985, Begin
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ExtractDataTransferAttributes()
        {
            #region Actions
            using (new SalContext(this))
            {
                ccPostingType.i_sMyValue = Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sData[0];
                sControlType = Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sData[4];
                sModule = Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sData[2];
                dfControlType.Text = sControlType;
                dfModule.Text = sModule;
            }

            return false;
            #endregion
        }

        /// <summary>
        /// This Function Recieves Data from Posting Control Navigator
        /// </summary>
        /// <param name="sNavControlType"></param>
        /// <param name="sNavModule"></param>
        /// <param name="sNavCodeName"></param>
        /// <param name="sNavCtrlTypeCatDb"></param>
        /// <returns></returns>
        public virtual SalBoolean RecivePostingCtrlNavAttribs(SalString sNavControlType, SalString sNavModule, SalString sNavCodeName, SalString sNavCtrlTypeCatDb)
        {
            #region Actions
            using (new SalContext(this))
            {
                sControlType = sNavControlType;
                sModule = sNavModule;
                sCodePartName = sNavCodeName;
                dfControlType.Text = sControlType;
                dfModule.Text = sModule;
                dfsCodeName.Text = sCodePartName;
                if (!((sNavCtrlTypeCatDb == "FIXED") || (sNavCtrlTypeCatDb == "PREPOSTING")))
                {
                    GetControlTypeAttribs();
                }
            }

            return false;
            #endregion
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void frmPostCtrlDet_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmPostCtrlDet_OnPM_DataSourceSave(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmPostCtrlDet_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.GetNewAllowedInfo();
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);

            if ((Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) && (e.Return == 1))
            {
                Sal.SendMsg(this.tblPostCtrlDet, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
            }
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void ccPostingType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserOrderBy:
                    e.Handled = true;
                    e.Return = ((SalString)"MODULE,SORT_ORDER").ToHandle();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPostCtrlDet_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_FetchRowDone:
                    this.tblPostCtrlDet_OnSAM_FetchRowDone(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tblPostCtrlDet_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.tblPostCtrlDet_OnPM_DataRecordDuplicate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans:
                    this.tblPostCtrlDet_OnPM_DataSourceCreateWindowTrans(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_FetchRowDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sControlTypeValue = this.tblPostCtrlDet_colControlTypeValue.Text;
            this.sControlType = this.dfControlType.Text;
            this.sModule = this.dfModule.Text;
            // Bug 75985, Removed Code
            if (this.tblPostCtrlDet_colPostingType.Text == "IP3" || this.tblPostCtrlDet_colPostingType.Text == "PP18" || this.tblPostCtrlDet_colPostingType.Text == "PP44" || this.tblPostCtrlDet_colPostingType.Text == "PP48" || this.tblPostCtrlDet_colPostingType.Text ==
            "PP49" || this.tblPostCtrlDet_colPostingType.Text == "IP9" || this.tblPostCtrlDet_colPostingType.Text == "IP10")
            {
                if (this.dfControlType.Text == "AC7")
                {
                    this.sView = "STATUTORY_FEE_DEDUCTIBLE(COMPANY)";
                }
            }
            // Bug 75985, Removed Code
            this.sCodePartValue = this.tblPostCtrlDet_colCodePartValue.Text;
            this.sCodePart = this.dfCodePart.Text;
            e.Return = Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (this.dfsCtrlTypeCategoryDb.Text == "FIXED" || this.dfsCtrlTypeCategoryDb.Text == "PREPOSTING")
                {
                    e.Return = false;
                    return;
                }
            }
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.bNew = true;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.bDuplicate = true;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourceCreateWindowTrans event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_OnPM_DataSourceCreateWindowTrans(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (this.sItemName1 == "tblPostCtrlDet_colCodePartValue")
                {
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans, Sys.wParam, Sys.lParam);
                    return;
                }
                this.lsMessage = SalString.FromHandle(Sys.lParam);
                if (!(frmPostCtrlDet.FromHandle(this.i_hWndFrame).sDummy1 == SalString.Null))
                {
                    this.nTemp1 = this.sDummy1.Tokenize("", ",", this.sKeyCols);
                    this.nTemp1 = this.sDummy2.Tokenize("", ",", this.sLovCols);
                    this.nTemp1 = 0;
                    this.nTemp2 = 0;
                    // To find the Key column of the view
                    while (true) // Outer
                    {
                        if (this.sKeyCols[this.nTemp1] != SalString.Null)
                        {
                            while (true)
                            {
                                if (this.sLovCols[this.nTemp2] != SalString.Null)
                                {
                                    if (this.sKeyCols[this.nTemp1] == this.sLovCols[this.nTemp2])
                                    {
                                        goto ExitOuter;
                                    }
                                    else
                                    {
                                        this.nTemp2 = this.nTemp2 + 1;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                        this.nTemp1 = this.nTemp1 + 1;
                        this.nTemp2 = 0;
                    }
                ExitOuter: ;
                    this.MessageKeys.Unpack(this.lsMessage);
                    this.nIndex = Vis.ArrayFindString(this.MessageKeys.m_sNames, this.tblPostCtrlDet_colControlTypeValue.p_sSqlColumn);
                    // Replace tblPostCtrlDet_colControlTypeValue with the Key column of the view in MessageKeys
                    if (this.nIndex != -1)
                    {
                        this.MessageKeys.m_sNames[this.nIndex] = this.sKeyCols[this.nTemp1];
                        this.MessageKeys.m_sValues[this.nIndex] = this.sKeyCols[this.nTemp1];
                    }
                    this.nIndex = Vis.ArrayFindString(this.tblPostCtrlDet.__sColumnName, this.tblPostCtrlDet_colControlTypeValue.p_sSqlColumn);
                    this.tblPostCtrlDet.__sColumnName[this.nIndex] = this.sKeyCols[this.nTemp1];
                    this.bReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans, Sys.wParam, this.MessageKeys.Pack().ToHandle());
                    this.tblPostCtrlDet.__sColumnName[this.nIndex] = this.tblPostCtrlDet_colControlTypeValue.p_sSqlColumn;
                }
                else
                {
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans, Sys.wParam, Sys.lParam);
                    return;
                }
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods

        // Bug 108854, Removed vrtDataSourcePopulateIt
        // Insert new code here...

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
       
        #endregion

        #region ChildTable-tblPostCtrlDet

        #region Window Variables
        public SalBoolean bDuplicate = false;
        public cMessage MessageKeys = new cMessage();
        public SalString lsMessage = "";
        public SalNumber nIndex = 0;
        public SalArray<SalString> sItemNames = new SalArray<SalString>();
        public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        public SalString sFormName = "";
        public SalString sItemName1 = "";
        public SalString sBaseCurrCode = "";
        public SalString sCountryDb = "";
        public SalString sStmt = "";
        public SalNumber nNum = 0;
        public SalArray<SalString> sUnits = new SalArray<SalString>();
        public SalArray<SalString> sRecords = new SalArray<SalString>();
        public SalString sSpecCtrlTypeCategory = "";
        public SalNumber nTemp1 = 0;
        public SalNumber nTemp2 = 0;
        public SalArray<SalString> sKeyCols = new SalArray<SalString>();
        public SalArray<SalString> sLovCols = new SalArray<SalString>();
        public SalString sKeyColumn = "";
        #endregion

        #region Methods

        /// <summary>
        /// Gets default values for NEW records
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean DataRecordGetDefaults()
        {
            tblPostCtrlDet_colCompany.Text = this.dfCompany.Text;
            tblPostCtrlDet_colCompany.EditDataItemSetEdited();
            tblPostCtrlDet_colPostingType.Text = this.ccPostingType.i_sMyValue;
            tblPostCtrlDet_colPostingType.EditDataItemSetEdited();
            tblPostCtrlDet_colCodePart.Text = this.dfCodePart.Text;
            tblPostCtrlDet_colCodePart.EditDataItemSetEdited();
            tblPostCtrlDet_colPcValidFrom.DateTime = this.dfPcValidFrom.DateTime;
            tblPostCtrlDet_colPcValidFrom.EditDataItemSetEdited();
            tblPostCtrlDet_colValidFrom.DateTime = this.dfPcValidFrom.DateTime;
            tblPostCtrlDet_colValidFrom.EditDataItemSetEdited();
            tblPostCtrlDet_colControlType.Text = this.dfControlType.Text;
            tblPostCtrlDet_colControlType.EditDataItemSetEdited();
            tblPostCtrlDet_colModule.Text = this.dfModule.Text;
            tblPostCtrlDet_colModule.EditDataItemSetEdited();
            return true;
        }

        /// <summary>
        /// The framework calls the DataRecordPrepareNew function to retrive
        /// server default values for new records.
        /// </summary>
        /// <returns>The return value is TRUE if default values were sucessfully retrived, FALSE otherwise.</returns>
        public virtual SalBoolean DataRecordPrepareNew()
        {
            if (((cChildTable)this.tblPostCtrlDet).DataRecordPrepareNew())
            {
                if (this.bNew)
                {
                    this.bNew = false;
                }
                else
                {
                    return Sal.ClearField(tblPostCtrlDet_colValidFrom);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="hItem"></param>
        /// <returns></returns>
        public virtual SalString GetItemName(SalWindowHandle hItem)
        {
            SalString sItem = "";
            Sal.GetItemName(hItem, ref sItem);
            return sItem;
        }
                                   
        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean DetailsSpecification(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            SalNumber nCurrentRow = 0;
            SalNumber nCount = 0;
            #endregion

            #region Actions
   
            switch (nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    if (Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam))
                    {
                        return false;
                    }
                    // only one row selected
                    nCount = 0;
                    nCurrentRow = Sys.TBL_MinRow;
                    while (Sal.TblFindNextRow(tblPostCtrlDet, ref nCurrentRow, Sys.ROW_Selected, 0))
                    {
                        nCount = nCount + 1;
                        if (nCount > 1)
                        {
                            break;
                        }
                    }
                    if (nCount != 1)
                    {
                        return false;
                    }

                    if (tblPostCtrlDet_colsSpecControlType.Text == Sys.STRING_Null)
                    {
                        return false;
                    }
                    if ((tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.Text == "FIXED") || (tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.Text == "PREPOSTING"))
                    {
                        return false;
                    }
                    if (tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.Text == "COMBINATION")
                    {
                        return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmPostingCtrlCombDetSpec"));
                    }
                    else if (tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.Text != Sys.STRING_Null)
                    {
                        return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmPostCtrlDetSpec"));
                    }
                    return false;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    Sal.WaitCursor(true);
                    sItemNames[0] = "COMPANY";
                    hWndItems[0] = tblPostCtrlDet_colCompany;
                    sItemNames[1] = "CODE_PART";
                    hWndItems[1] = tblPostCtrlDet_colCodePart;
                    sItemNames[2] = "POSTING_TYPE";
                    hWndItems[2] = tblPostCtrlDet_colPostingType;
                    sItemNames[3] = "PC_VALID_FROM";
                    hWndItems[3] = tblPostCtrlDet_colPcValidFrom;
                    sItemNames[4] = "CONTROL_TYPE_VALUE";
                    hWndItems[4] = tblPostCtrlDet_colControlTypeValue;
                    sItemNames[5] = "VALID_FROM";
                    hWndItems[5] = tblPostCtrlDet_colValidFrom;
                    sItemNames[6] = "SPEC_CONTROL_TYPE";
                    hWndItems[6] = tblPostCtrlDet_colsSpecControlType;
                    if (tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.Text == "COMBINATION")
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("CombControlType", tblPostCtrlDet, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmPostingCtrlCombDetSpec"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        return true;
                    }
                    else
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("PostingType", tblPostCtrlDet, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmPostCtrlDetSpec"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                    }
                    break;
            }
        
            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetNewAllowedInfo()
        {
            SalNumber nSelectedRow = Sal.TblQueryContext(tblPostCtrlDet);
            SalNumber nCurrentRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblPostCtrlDet, ref nCurrentRow, Sys.ROW_New, 0))
            {
                Sal.TblSetFocusRow(tblPostCtrlDet, nCurrentRow);
                Sal.SendMsg(tblPostCtrlDet_colsSpecControlType, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
            }
            Sal.TblSetContext(tblPostCtrlDet, nSelectedRow);
            return 0;
        }
        // Bug 75985, Begin
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalString DataSourceFormatSqlColumnUser()
        {

            return String.Format(@"&AO.Posting_Ctrl_Control_Type_API.Get_Control_Type_Desc_({0}, {1}, control_type_value, {2}, {3}, {4}, VALID_FROM  )",
                                this.QualifiedVarBindName("i_sCompany"),
                                this.QualifiedVarBindName("sControlType"),
                                this.QualifiedVarBindName("sView"),
                                this.QualifiedVarBindName("sPkgName"),
                                this.QualifiedVarBindName("sModule"));

        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalString DataSourceFormatSqlIntoUser()
        {
            return this.tblPostCtrlDet_colControlTypeValueDesc.QualifiedBindName;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetControlTypeDesc()
        {

            string stmt = @"{sControlTypeValueDesc} := &AO.Posting_Ctrl_Control_Type_API.Get_Control_Type_Desc_(
                                                        {i_sCompany} IN,
                                                        {sControlType} IN,
                                                        {sControlTypeValue} IN,
                                                        {sView} IN,
                                                        {sPkgName} IN,
                                                        {sModule} IN,
				                                        {colValidFrom} IN)";

            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("sControlTypeValueDesc",this.QualifiedVarBindName("sControlTypeValueDesc"));
            namedBindVariables.Add("i_sCompany",this.QualifiedVarBindName("i_sCompany"));
            namedBindVariables.Add("sControlType",this.QualifiedVarBindName("sControlType"));
            namedBindVariables.Add("sControlTypeValue",this.QualifiedVarBindName("sControlTypeValue"));
            namedBindVariables.Add("sView",this.QualifiedVarBindName("sView"));
            namedBindVariables.Add("sPkgName",this.QualifiedVarBindName("sPkgName"));
            namedBindVariables.Add("sModule",this.QualifiedVarBindName("sModule"));
            namedBindVariables.Add("colValidFrom",this.tblPostCtrlDet_colValidFrom.QualifiedBindName);

            DbPLSQLBlock(stmt,namedBindVariables);
            return 0;

        }

		/// <summary>
		/// </summary>
		/// <param name="bPopulateSingle"></param>
		/// <returns></returns>
		public virtual SalBoolean DataSourcePopulateIt(SalBoolean bPopulateSingle)
		{
			
		    this.GetControlTypeAttribs();
            return ((cDataSource)tblPostCtrlDet).DataSourcePopulateIt(bPopulateSingle);
		}

        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPostCtrlDet_colControlTypeValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblPostCtrlDet_colControlTypeValue_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblPostCtrlDet_colControlTypeValue_OnPM_DataItemValidate(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    this.tblPostCtrlDet_colControlTypeValue_OnSAM_AnyEdit(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.tblPostCtrlDet_colControlTypeValue_OnPM_DataItemLovUserWhere(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.tblPostCtrlDet_colControlTypeValue_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_colControlTypeValue_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.WaitCursor(true);
            if (this.sView == "WORK_CENTER_NOSITE")
            {
                this.tblPostCtrlDet_colControlTypeValue.p_sLovReference = "WORK_CENTER_DESC(COMPANY)";
            }
            else
            {
                this.tblPostCtrlDet_colControlTypeValue.p_sLovReference = this.sView;
            }
            Sal.WaitCursor(false);
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_colControlTypeValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sControlTypeValue = this.tblPostCtrlDet_colControlTypeValue.Text;
			this.GetControlTypeDesc();
            this.tblPostCtrlDet_colControlTypeValueDesc.Text = this.sControlTypeValueDesc;
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_colControlTypeValue_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendMsg(this.tblPostCtrlDet_colControlTypeValue.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            e.Return = Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_colControlTypeValue_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("tblPostCtrlDet_colCompany", this.tblPostCtrlDet_colCompany.QualifiedBindName);
            namedBindVariables.Add("sBaseCurrCode", this.QualifiedVarBindName("sBaseCurrCode"));   
            namedBindVariables.Add("sCountryDb", this.QualifiedVarBindName("sCountryDb"));
            if (this.sView == "INCOME_TYPE_LOV(COUNTRY_CODE, CURRENCY_CODE)")
            {
                DbPLSQLBlock(@"&AO.Company_Finance_API.Get_Accounting_Currency({sBaseCurrCode} INOUT, {tblPostCtrlDet_colCompany} IN);
                               {sCountryDb} := &AO.Company_API.Get_Country_Db({tblPostCtrlDet_colCompany} IN);", namedBindVariables);                     
                e.Return = ("COUNTRY_CODE='" + this.sCountryDb + "' and CURRENCY_CODE='" + this.sBaseCurrCode + "'").ToHandle();
                return;
            }
            if (this.sView == "TYPE1099_LOV(COUNTRY_CODE)")
            {
                DbPLSQLBlock(@"{sCountryDb} := &AO.Company_API.Get_Country_Db({tblPostCtrlDet_colCompany} IN);", namedBindVariables);
                e.Return = ("COUNTRY_CODE='" + this.sCountryDb + "'").ToHandle();
                return;
            }
            if (this.ccPostingType.i_sMyValue == "M42" && this.dfControlType.Text == "C48")
            {
                e.Return = ("COMPANY='" + this.i_sCompany).ToHandle();
                return;
            }
            if (this.sView == "STATUTORY_FEE_DEDUCTIBLE(COMPANY)" && (this.ccPostingType.i_sMyValue == "PP48" || this.ccPostingType.i_sMyValue == "PP49"))
            {
                this.sStmt = " FEE_TYPE_DB ='IRS1099TX'";
                e.Return = this.sStmt.ToHandle();
                return;
            }
            if (this.dfControlType.Text == "FAC4")
            {
                if (this.ccPostingType.i_sMyValue == "FAP7" || this.ccPostingType.i_sMyValue == "FAP8" || this.ccPostingType.i_sMyValue == "FAP9" || this.ccPostingType.i_sMyValue == "FAP11" ||
                    this.ccPostingType.i_sMyValue == "FAP12" || this.ccPostingType.i_sMyValue == "FAP19" || this.ccPostingType.i_sMyValue == "FAP20" || this.ccPostingType.i_sMyValue == "FAP25" ||
                    this.ccPostingType.i_sMyValue == "FAP26" || this.ccPostingType.i_sMyValue == "FAP27" || this.ccPostingType.i_sMyValue == "FAP35" || this.ccPostingType.i_sMyValue == "FAP36" ||
                    this.ccPostingType.i_sMyValue == "FAP37" || this.ccPostingType.i_sMyValue == "FAP38")
                {
                    this.sView = "TRANSACTION_REASON_DISPOSAL(COMPANY)";
                }
                if (this.ccPostingType.i_sMyValue == "FAP2" || this.ccPostingType.i_sMyValue == "FAP13" || this.ccPostingType.i_sMyValue == "FAP14" || this.ccPostingType.i_sMyValue == "FAP22" ||
                this.ccPostingType.i_sMyValue == "FAP28" || this.ccPostingType.i_sMyValue == "FAP29")
                {
                    this.sView = "TRANSACTION_REASON_ACQUISITION(COMPANY)";
                }
                if (this.ccPostingType.i_sMyValue == "FAP15" || this.ccPostingType.i_sMyValue == "FAP16" || this.ccPostingType.i_sMyValue == "FAP30" || this.ccPostingType.i_sMyValue == "FAP31" ||
                this.ccPostingType.i_sMyValue == "FAP33")
                {
                    this.sView = "TRANSACTION_REASON_DEPRECIATE(COMPANY)";
                }
                if (this.ccPostingType.i_sMyValue == "FAP4" || this.ccPostingType.i_sMyValue == "FAP24" || this.ccPostingType.i_sMyValue == "FAP32" || this.ccPostingType.i_sMyValue == "FAP34")
                {
                    this.sView = "TRANSACTION_REASON_IMPORT(COMPANY)";
                }
                e.Return = this.sStmt.ToHandle();
                return;
            }
            if (this.sView == "VOUCHER_TYPE_FUNCTION_GROUP(COMPANY)")
            {
                if (this.ccPostingType.i_sMyValue == "IP1")
                {
                    this.sStmt = " FUNCTION_GROUP = 'I'";
                }
                else if (this.ccPostingType.i_sMyValue == "IP2")
                {
                    this.sStmt = " FUNCTION_GROUP = 'F'";
                }
                e.Return = this.sStmt.ToHandle();
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_colControlTypeValue_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (this.dfControlType.Text == "IC5")
                {
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.tblPostCtrlDet_colCompany;
                    this.sItemNames[1] = "PRELIM_CODE";
                    this.hWndItems[1] = this.tblPostCtrlDet_colControlTypeValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("PostingCtrlDetail", this.tblPostCtrlDet, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwPreliminaryCode"));
                }
                else if (this.dfControlType.Text == "PC2")
                {
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.tblPostCtrlDet_colCompany;
                    this.sItemNames[1] = "SHORT_NAME";
                    this.hWndItems[1] = this.tblPostCtrlDet_colControlTypeValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("CashAccount", this.tblPostCtrlDet, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwCashAccount"));
                }
                else if (this.dfControlType.Text == "AC4")
                {
                    this.sItemNames[0] = "COUNTRY_CODE";
                    this.hWndItems[0] = this.tblPostCtrlDet_colControlTypeValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("IsoCountryDef", this.tblPostCtrlDet, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwIsoCountry"));
                }
                else if (this.dfControlType.Text == "AC7")
                {
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.tblPostCtrlDet_colCompany;
                    this.sItemNames[1] = "FEE_CODE";
                    this.hWndItems[1] = this.tblPostCtrlDet_colControlTypeValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("StatutoryFee", this.tblPostCtrlDet, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwStatFee"));
                }
                else if (this.dfControlType.Text == "IC1")
                {
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.tblPostCtrlDet_colCompany;
                    this.sItemNames[1] = "GROUP_ID";
                    this.hWndItems[1] = this.tblPostCtrlDet_colControlTypeValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("InvoicePartyTypeGroup", this.tblPostCtrlDet, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwInvoicePartyTypeGroupSupplier"));
                }
                else if (this.dfControlType.Text == "IC2")
                {
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.tblPostCtrlDet_colCompany;
                    this.sItemNames[1] = "GROUP_ID";
                    this.hWndItems[1] = this.tblPostCtrlDet_colControlTypeValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("InvoicePartyTypeGroup", this.tblPostCtrlDet, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwInvoicePartyTypeGroupCustomer"));
                }
                else if (this.dfControlType.Text == "IC4")
                {
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.tblPostCtrlDet_colCompany;
                    this.sItemNames[1] = "PAY_TERM_ID";
                    this.hWndItems[1] = this.tblPostCtrlDet_colControlTypeValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("PaymentTerm", this.tblPostCtrlDet, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwPaymentTerm"));
                }
                else if (this.dfControlType.Text == "PC5")
                {
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.tblPostCtrlDet_colCompany;
                    this.sItemNames[1] = "DEDUCTION_RULE";
                    this.hWndItems[1] = this.tblPostCtrlDet_colControlTypeValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("DeductionRule", this.tblPostCtrlDet, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwDeductionRule"));
                }
                else if (this.dfControlType.Text == "FAC4")
                {
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.tblPostCtrlDet_colCompany;
                    this.sItemNames[1] = "TRANSACTION_REASON";
                    this.hWndItems[1] = this.tblPostCtrlDet_colControlTypeValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("TransactionReason", this.tblPostCtrlDet, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwTransactionReason"));
                }
                // Bug 76695, Begin
                else if (this.dfControlType.Text == "C43")
                {
                    this.sItemNames[0] = "REQUISITIONER_CODE";
                    this.hWndItems[0] = this.tblPostCtrlDet_colControlTypeValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("PurchaseRequisitioner", this.tblPostCtrlDet, this.sItemNames, this.hWndItems);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sDestination = "PURCHASE_REQUISITIONER";
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("ZOOM");
                    SessionNavigate(Pal.GetActiveInstanceName("frmPurBasic"));
                }
                // Bug 76695, End
                else if (this.dfControlType.Text == "AC8")
                {
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.tblPostCtrlDet_colControlTypeValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Company", this.tblPostCtrlDet, this.sItemNames, this.hWndItems);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sDestination = "COMPANY";
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("ZOOM");
                    SessionNavigate(Pal.GetActiveInstanceName("frmCompany"));
                }
                else
                {
                    Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                }
                e.Return = true;
                return;
            }
            else
            {
                if (this.dfControlType.Text == "IC5")
                {
                    if (Ifs.Fnd.ApplicationForms.Var.Security.IsPresObjectAvailable(Pal.GetActiveInstanceName("tbwPreliminaryCode")))
                    {
                        e.Return = true;
                        return;
                    }
                }
                else if (this.dfControlType.Text == "PC2")
                {
                    if (Ifs.Fnd.ApplicationForms.Var.Security.IsPresObjectAvailable(Pal.GetActiveInstanceName("tbwCashAccount")))
                    {
                        e.Return = true;
                        return;
                    }
                }
                else if (this.dfControlType.Text == "AC4")
                {
                    e.Return = true;
                    return;
                }
                else if (this.dfControlType.Text == "AC7")
                {
                    e.Return = true;
                    return;
                }
                else if (this.dfControlType.Text == "IC1")
                {
                    e.Return = true;
                    return;
                }
                else if (this.dfControlType.Text == "IC2")
                {
                    e.Return = true;
                    return;
                }
                else if (this.dfControlType.Text == "IC4")
                {
                    if (Ifs.Fnd.ApplicationForms.Var.Security.IsPresObjectAvailable(Pal.GetActiveInstanceName("tbwPaymentTerm")))
                    {
                        e.Return = true;
                        return;
                    }
                }
                else if (this.dfControlType.Text == "PC5")
                {
                    if (Ifs.Fnd.ApplicationForms.Var.Security.IsPresObjectAvailable(Pal.GetActiveInstanceName("tbwDeductionRule")))
                    {
                        e.Return = true;
                        return;
                    }
                }
                else if (this.dfControlType.Text == "FAC4")
                {
                    if (Ifs.Fnd.ApplicationForms.Var.Security.IsPresObjectAvailable(Pal.GetActiveInstanceName("tbwTransactionReason")))
                    {
                        e.Return = true;
                        return;
                    }
                }
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPostCtrlDet_colCodePartValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblPostCtrlDet_colCodePartValue_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.tblPostCtrlDet_colCodePartValue_OnPM_DataItemZoom(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblPostCtrlDet_colCodePartValue_OnPM_DataItemQueryEnabled(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.tblPostCtrlDet_colCodePartValue_OnPM_DataItemLovUserWhere(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_colCodePartValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.sCodePart = this.dfCodePart.Text;
            this.sCodePartValue = this.tblPostCtrlDet_colCodePartValue.Text;
            if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Part_Value_API.Get_Description"))
            {
                this.sSql = string.Format("{0} := &AO.Accounting_Code_Part_Value_API.Get_Description({1} IN, {2} IN, {3} IN );",
                this.QualifiedVarBindName("sCodePartValueDesc"),
                this.QualifiedVarBindName("i_sCompany"),
                this.QualifiedVarBindName("sCodePart"),
                this.QualifiedVarBindName("sCodePartValueDesc"));
                
                if (!(DbPLSQLBlock(this.sSql)))
                {
                    e.Return = false;
                    return;
                }
                this.tblPostCtrlDet_colCodePartValueDesc.Text = this.sCodePartValueDesc;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_colCodePartValue_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.sItemName1 = this.GetItemName(this.tblPostCtrlDet_colCodePartValue);
                if (this.tblPostCtrlDet_colCodePart.Text == "A")
                {
                    this.sFormName = Pal.GetActiveInstanceName("tbwAccountOverview");
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.tblPostCtrlDet_colCompany;
                    this.sItemNames[1] = "ACCOUNT";
                    this.hWndItems[1] = this.tblPostCtrlDet_colCodePartValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Account", tblPostCtrlDet, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwAccountOverview"));
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
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_colCodePartValue_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblPostCtrlDet_colsSpecControlType)))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void tblPostCtrlDet_colCodePartValue_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = ((SalString)("COMPANY = '" + this.tblPostCtrlDet_colCompany.Text + "' AND CODE_PART = '" + this.tblPostCtrlDet_colCodePart.Text + "'")).ToHandle();
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPostCtrlDet_colsSpecControlType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.tblPostCtrlDet_colsSpecControlType_OnSAM_AnyEdit(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.tblPostCtrlDet_colsSpecControlType_OnPM_DataItemLovDone(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblPostCtrlDet_colsSpecControlType_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblPostCtrlDet_colsSpecControlType_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    e.Handled = true;
                    e.Return = ((SalString)"CTRL_TYPE_CATEGORY_DB IN ( 'ORDINARY', 'SYSTEM_DEFINED', 'COMBINATION' )").ToHandle();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_colsSpecControlType_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tblPostCtrlDet_colsSpecCtrlTypeCategory.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
            Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_colsSpecControlType_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nNum = SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sRecords);
            this.nNum = this.sRecords[3].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
            if (this.sUnits[0] == "SPEC_CTRL_TYPE_CATEGORY")
            {
                this.tblPostCtrlDet_colsSpecCtrlTypeCategory.Text = this.sUnits[1];
                Sal.SetFieldEdit(this.tblPostCtrlDet_colsSpecCtrlTypeCategory, true);
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_colsSpecControlType_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblPostCtrlDet_colsSpecControlType.Text == Sys.STRING_Null)
            {
                this.tblPostCtrlDet_colsSpecControlTypeDesc.Text = Sys.STRING_Null;
                this.tblPostCtrlDet_colsSpecModule.Text = Sys.STRING_Null;
                this.tblPostCtrlDet_colsSpecCtrlTypeCategory.Text = Sys.STRING_Null;
                this.tblPostCtrlDet_colsSpecDefaultValue.Text = Sys.STRING_Null;
                this.tblPostCtrlDet_colsSpecDefaultValueNoCt.Text = Sys.STRING_Null;

                this.tblPostCtrlDet_colsSpecModule.EditDataItemSetEdited();
                this.tblPostCtrlDet_colsSpecCtrlTypeCategory.EditDataItemSetEdited();
                this.tblPostCtrlDet_colsSpecDefaultValue.EditDataItemSetEdited();
                this.tblPostCtrlDet_colsSpecDefaultValueNoCt.EditDataItemSetEdited();
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                return;
            }
            else
            {
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                namedBindVariables.Add("colsSpecModule", this.tblPostCtrlDet_colsSpecModule.QualifiedBindName);
                namedBindVariables.Add("sSpecCtrlTypeCategory", this.QualifiedVarBindName("sSpecCtrlTypeCategory"));
                namedBindVariables.Add("colsSpecCtrlTypeCategoryDb", this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.QualifiedBindName);
                namedBindVariables.Add("colsSpecControlTypeDesc", this.tblPostCtrlDet_colsSpecControlTypeDesc.QualifiedBindName);
                namedBindVariables.Add("colCompany", this.tblPostCtrlDet_colCompany.QualifiedBindName);
                namedBindVariables.Add("colCodePart", this.tblPostCtrlDet_colCodePart.QualifiedBindName);
                namedBindVariables.Add("colPostingType", this.tblPostCtrlDet_colPostingType.QualifiedBindName);
                namedBindVariables.Add("colsSpecControlType", this.tblPostCtrlDet_colsSpecControlType.QualifiedBindName);
                namedBindVariables.Add("colsSpecCtrlTypeCategory", this.tblPostCtrlDet_colsSpecCtrlTypeCategory.QualifiedBindName);

                string stmt = @"&AO.CTRL_TYPE_ALLOWED_VALUE_API.Get_Allowed_Info__( 
                             {colsSpecModule} OUT, 
                             {sSpecCtrlTypeCategory} OUT, 
                             {colsSpecCtrlTypeCategoryDb} OUT, 
                             {colsSpecControlTypeDesc} OUT, 
                             {colCompany} IN, 
                             {colCodePart} IN, 
                             {colPostingType} IN, 
                             {colsSpecControlType} IN, 
                             {colsSpecCtrlTypeCategory} IN);";

                if (DbPLSQLBlock(stmt,namedBindVariables))
                {
                    this.tblPostCtrlDet_colsSpecModule.EditDataItemSetEdited();
                    if (this.sSpecCtrlTypeCategory != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        this.tblPostCtrlDet_colsSpecCtrlTypeCategory.Text = this.sSpecCtrlTypeCategory;
                        this.tblPostCtrlDet_colsSpecCtrlTypeCategory.EditDataItemSetEdited();
                    }
                    if ((this.sSpecCtrlTypeCategory == Ifs.Fnd.ApplicationForms.Const.strNULL) || (this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.Text == "FIXED") || (this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.Text == "PREPOSTING"))
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SpecCtrlTypeNotExist, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                    if ((this.tblPostCtrlDet_colsSpecDefaultValueNoCt.Text != Sys.STRING_Null) && ((this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.Text == "FIXED") || (this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.Text == "PREPOSTING")))
                    {
                        this.tblPostCtrlDet_colsSpecDefaultValueNoCt.Text = Sys.STRING_Null;
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
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_colsSpecControlType_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.tblPostCtrlDet_colCodePartValue)) || this.sCctEnabled == "FALSE")
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblPostCtrlDet_colsSpecDefaultValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblPostCtrlDet_colsSpecDefaultValue_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.tblPostCtrlDet_colsSpecDefaultValue_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_colsSpecDefaultValue_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.tblPostCtrlDet_colsSpecControlType))
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
        private void tblPostCtrlDet_colsSpecDefaultValue_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.sItemName1 = this.GetItemName(this.tblPostCtrlDet_colsSpecDefaultValue);
                if (this.tblPostCtrlDet_colCodePart.Text == "A")
                {
                    this.sFormName = Pal.GetActiveInstanceName("tbwAccountOverview");
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.tblPostCtrlDet_colCompany;
                    this.sItemNames[1] = "ACCOUNT";
                    this.hWndItems[1] = this.tblPostCtrlDet_colsSpecDefaultValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Account", tblPostCtrlDet, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwAccountOverview"));
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
        private void tblPostCtrlDet_colsSpecDefaultValueNoCt_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblPostCtrlDet_colsSpecDefaultValueNoCt_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.tblPostCtrlDet_colsSpecDefaultValueNoCt_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlDet_colsSpecDefaultValueNoCt_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.tblPostCtrlDet_colsSpecControlType) || (this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.Text == "FIXED") || (this.tblPostCtrlDet_colsSpecCtrlTypeCategoryDb.Text == "PREPOSTING"))
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
        private void tblPostCtrlDet_colsSpecDefaultValueNoCt_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.sItemName1 = this.GetItemName(this.tblPostCtrlDet_colsSpecDefaultValueNoCt);
                if (this.tblPostCtrlDet_colCodePart.Text == "A")
                {
                    this.sFormName = Pal.GetActiveInstanceName("tbwAccountOverview");
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.tblPostCtrlDet_colCompany;
                    this.sItemNames[1] = "ACCOUNT";
                    this.hWndItems[1] = this.tblPostCtrlDet_colsSpecDefaultValueNoCt;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Account", tblPostCtrlDet, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwAccountOverview"));
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
        #endregion

        #region Window Events

        private void tblPostCtrlDet_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordGetDefaults();
        }

        private void tblPostCtrlDet_DataRecordPrepareNewEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordPrepareNew();
        }

        private void tblPostCtrlDet_DataSourceFormatSqlColumnUserEvent(object sender, FndReturnEventArgsSalString e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataSourceFormatSqlColumnUser();
        }

        private void tblPostCtrlDet_DataSourceFormatSqlIntoUserEvent(object sender, FndReturnEventArgsSalString e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataSourceFormatSqlIntoUser();
        }

        private void tblPostCtrlDet_DataSourcePopulateItEvent(object sender, cDataSource.DataSourcePopulateItEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataSourcePopulateIt(e.nParam);
        }
        #endregion
      
        #endregion

        #region Event Handlers

        private void menuItem__Details_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = this.DetailsSpecification(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Details_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.DetailsSpecification(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem__Copy_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled =  this.CopyDetails(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem__Copy_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.CopyDetails(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion

      
    }
}
