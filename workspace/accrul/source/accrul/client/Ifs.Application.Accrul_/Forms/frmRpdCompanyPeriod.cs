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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

using Ifs.Fnd.Windows.Forms;

namespace Ifs.Application.Accrul_
{

    /// <summary>
    /// </summary>
    [FndWindowRegistration("RPD_COMPANY_PERIOD", "RpdCompanyPeriod", FndWindowRegistrationFlags.HomePage)]
    public partial class frmRpdCompanyPeriod : cFormWindow
    {
        #region Member Variables
        SalString sRpdId = SalString.Empty;
        SalNumber nRpdYear = SalNumber.Null;
        SalNumber nRpdPeriod = SalNumber.Null;
        SalString sHeaderWhere = new SalString("RPD_ID   = :i_hWndFrame.frmRpdCompanyPeriod.sRpdId");
        SalString sDetailWhereYear = new SalString("RPD_YEAR = :i_hWndFrame.frmRpdCompanyPeriod.nRpdYear");
        SalString sDetailWhereYearPeriod = new SalString("RPD_YEAR = :i_hWndFrame.frmRpdCompanyPeriod.nRpdYear AND RPD_PERIOD = :i_hWndFrame.frmRpdCompanyPeriod.nRpdPeriod");
        SalBoolean bUseDetailWhereYear = false;
        SalBoolean bPopulatingFromFrmRpdYear = false;
        SalBoolean bUseDetailWhereYearPeriod = false;        

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmRpdCompanyPeriod()
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
        public new static frmRpdCompanyPeriod FromHandle(SalWindowHandle handle)
        {
            return ((frmRpdCompanyPeriod)SalWindow.FromHandle(handle, typeof(frmRpdCompanyPeriod)));
        }
        #endregion

        #region Properties

        #endregion

        #region Methods
        protected virtual SalBoolean GetRpdIdDescription()
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                String sStmt = ":i_hWndFrame.frmRpdCompanyPeriod.dfsDescription := " + cSessionManager.c_sDbPrefix + "RPD_IDENTITY_API.GET_DESCRIPTION(:i_hWndFrame.frmRpdCompanyPeriod.cmbRpdId IN)";
                DbPLSQLTransaction(cSessionManager.c_hSql, sStmt);
                return true;
            }
            #endregion
        }

        protected virtual SalBoolean GetAccPeriodInformation()
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                lsStmt = 
                "BEGIN " +
                "   :i_hWndFrame.frmRpdCompanyPeriod.cChildTableDetail_colAccPeriodFrom  := " + cSessionManager.c_sDbPrefix + "ACCOUNTING_PERIOD_API.Get_Date_From(" +
                "               :i_hWndFrame.frmRpdCompanyPeriod.cChildTableDetail_colsCompany          IN,  " +
                "               :i_hWndFrame.frmRpdCompanyPeriod.cChildTableDetail_colnAccountingYear   IN,  " +
                "               :i_hWndFrame.frmRpdCompanyPeriod.cChildTableDetail_colnAccountingPeriod IN); " +
                "   :i_hWndFrame.frmRpdCompanyPeriod.cChildTableDetail_colAccPeriodUntil := " + cSessionManager.c_sDbPrefix + "ACCOUNTING_PERIOD_API.Get_Date_Until(" +
                "               :i_hWndFrame.frmRpdCompanyPeriod.cChildTableDetail_colsCompany          IN,  " +
                "               :i_hWndFrame.frmRpdCompanyPeriod.cChildTableDetail_colnAccountingYear   IN,  " +
                "               :i_hWndFrame.frmRpdCompanyPeriod.cChildTableDetail_colnAccountingPeriod IN); " +
                "END;";
                DbPLSQLTransaction(cSessionManager.c_hSql, lsStmt);
                return true;
            }
            #endregion
        }

        protected virtual SalBoolean GetRpdPeriodInformation()
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                lsStmt =
                "BEGIN " +
                "   :i_hWndFrame.frmRpdCompanyPeriod.cChildTableDetail_colRpdPeriodFrom  := " + cSessionManager.c_sDbPrefix + "RPD_PERIOD_API.Get_From_Date(" +
                "               :i_hWndFrame.frmRpdCompanyPeriod.cChildTableDetail_colsRpdId     IN,  " +
                "               :i_hWndFrame.frmRpdCompanyPeriod.cChildTableDetail_colnRpdYear   IN,  " +
                "               :i_hWndFrame.frmRpdCompanyPeriod.cChildTableDetail_colnRpdPeriod IN); " +
                "   :i_hWndFrame.frmRpdCompanyPeriod.cChildTableDetail_colRpdPeriodUntil := " + cSessionManager.c_sDbPrefix + "RPD_PERIOD_API.Get_Until_Date(" +
                "               :i_hWndFrame.frmRpdCompanyPeriod.cChildTableDetail_colsRpdId     IN,  " +
                "               :i_hWndFrame.frmRpdCompanyPeriod.cChildTableDetail_colnRpdYear   IN,  " +
                "               :i_hWndFrame.frmRpdCompanyPeriod.cChildTableDetail_colnRpdPeriod IN); " +
                "END;";
                DbPLSQLTransaction(cSessionManager.c_hSql, lsStmt);
                return true;
            }
            #endregion
        }

        
        protected virtual SalBoolean GetCompanyName()
        {
            #region Local Variables
            SalBoolean bCommandOk = false;
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                String sStmt = ":i_hWndFrame.frmRpdCompanyPeriod.dfsCompanyName := " + cSessionManager.c_sDbPrefix + "COMPANY_FINANCE_API.GET_DESCRIPTION(:i_hWndFrame.frmRpdCompanyPeriod.dfsCompany IN)";
                DbPLSQLTransaction(cSessionManager.c_hSql, sStmt);
                return true;
            }
            #endregion
        }
        #endregion
        
        #region Overrides
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            SalString sDataSourceName = "";
            SalString sType = "";
            SalArray<SalString> sRpdIdArray = new SalArray<SalString>();
            SalArray<SalString> sRpdYearArray = new SalArray<SalString>();
            SalArray<SalString> sRpdPeriodArray = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    sDataSourceName = Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sSourceName;
                    sType = Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sType;
                    if (sDataSourceName == "RpdYear")
                    {
                        if (sType == "HEADER")
                        {
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("RPD_YEAR", sRpdYearArray);
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("RPD_ID", sRpdIdArray);
                            if (sRpdIdArray.Count > 0)
                            {
                                sRpdId = sRpdIdArray[0];
                                this.p_lsDefaultWhere = sHeaderWhere;                                
                            }
                            if (sRpdYearArray.Count > 0)
                            {
                                nRpdYear = sRpdYearArray[0].ToNumber();
                                cChildTableDetail.p_lsDefaultWhere = sDetailWhereYear;
                            }
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                            bUseDetailWhereYear = true;
                            bUseDetailWhereYearPeriod = false;
                            bPopulatingFromFrmRpdYear = true;
                            Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                            return true;
                        }
                        else if (sType = "DETAIL")
                        {
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("RPD_YEAR", sRpdYearArray);
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("RPD_ID", sRpdIdArray);
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("RPD_PERIOD", sRpdPeriodArray);
                            if (sRpdIdArray.Count > 0)
                            {
                                sRpdId = sRpdIdArray[0];
                                this.p_lsDefaultWhere = sHeaderWhere;
                            }
                            if ((sRpdYearArray.Count > 0) && (!(sRpdPeriodArray.Count > 0)))
                            {
                                nRpdYear = sRpdYearArray[0].ToNumber();
                                bUseDetailWhereYear = true;
                                bUseDetailWhereYearPeriod = false;
                                cChildTableDetail.p_lsDefaultWhere =  sDetailWhereYear;
                            }
                            if ((sRpdYearArray.Count > 0) && (sRpdPeriodArray.Count > 0))
                            {
                                nRpdYear = sRpdYearArray[0].ToNumber();
                                nRpdPeriod = sRpdPeriodArray[0].ToNumber();
                                bUseDetailWhereYear = false;
                                bUseDetailWhereYearPeriod = true;
                                cChildTableDetail.p_lsDefaultWhere = sDetailWhereYearPeriod;
                            }
                            bPopulatingFromFrmRpdYear = true;
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                            Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                            return true;
                        }
                    }
                }
                return base.Activate(URL);
            }
            #endregion
        }

        public override SalBoolean vrtDataSourcePopulateIt(SalNumber nParam)
        {
            //When not populated through the cmbRpdId(nParam = 45) reset the where statements
            if ((!bPopulatingFromFrmRpdYear) && (nParam != 45) && (bUseDetailWhereYear || bUseDetailWhereYearPeriod))
            {
                p_lsDefaultWhere = SalString.Empty;
                cChildTableDetail.p_lsDefaultWhere = SalString.Empty;
                bUseDetailWhereYear = false;
                bUseDetailWhereYearPeriod = false;
                sRpdId = SalString.Empty;
                nRpdPeriod = SalNumber.Null;
                nRpdYear = SalNumber.Null;              
            }
            bPopulatingFromFrmRpdYear = false;
            return base.vrtDataSourcePopulateIt(nParam);
        }
        #endregion

        #region Message Actions
        #endregion
        
        #region Window Actions
        private void cmbRpdId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.cmbRpdId_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void dfsCompany_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsCompany_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void cChildTableDetail_colnAccountingYear_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.cChildTableDetail_colnAccountingYear_OnPM_DataItemZoom(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.cChildTableDetail_colnAccountingYear_OnPM_DataItemValidate(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov:
                    this.detail_OnPM_DataItemLov(sender, e);                    
                    break;
            }
            #endregion
        }

        private void cChildTableDetail_colnRpdYear_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.cChildTableDetail_colnRpdYear_OnPM_DataItemValidate(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov:
                    this.detail_OnPM_DataItemLov(sender, e);                    
                    break;
            }
            #endregion
        }

        private void cChildTableDetail_colnRpdPeriod_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov:
                    this.detail_OnPM_DataItemLov(sender, e);
                    break;
            }
            #endregion
        }

        private void cChildTableDetail_colnAccountingPeriod_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov:
                    this.detail_OnPM_DataItemLov(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemLov event handler.
        /// </summary>
        /// <param name="message"></param>
        private void detail_OnPM_DataItemLov(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            if (cmbRpdId.IsEmpty() || dfsCompany.IsEmpty())
            {
                e.Return = false;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Sys.wParam, Sys.lParam);
            #endregion
        }
        
        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbRpdId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (!(Sal.IsNull(this.cmbRpdId)) && this.cmbRpdId.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed)
            {
                this.GetRpdIdDescription();
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }        

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cChildTableDetail_colnAccountingYear_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (!(Sal.IsNull(this.cChildTableDetail_colnAccountingPeriod)) && this.cChildTableDetail_colnAccountingPeriod.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed)
            {
                GetAccPeriodInformation();
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }
        
        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cChildTableDetail_colnRpdYear_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (!(Sal.IsNull(this.cChildTableDetail_colnRpdPeriod)) && this.cChildTableDetail_colnRpdPeriod.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed)
            {
                GetRpdPeriodInformation();
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }
        
        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsCompany_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }
            if (!(Sal.IsNull(this.cmbRpdId)) && this.dfsCompany.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed)
            {
                this.GetCompanyName();
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }


        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cChildTableDetail_colnAccountingYear_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
		    SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (!string.IsNullOrEmpty(this.cChildTableDetail_colnAccountingYear.Text))
                {
                    Sal.WaitCursor(true);
                    sItemNames[0] = "COMPANY";
                    hWndItems[0] = this.cChildTableDetail_colsCompany;
                    sItemNames[1] = "ACCOUNTING_YEAR";
                    hWndItems[1] = this.cChildTableDetail_colnAccountingYear;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("AccountingYear", this.cChildTableDetail, sItemNames, hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("frmAccPer"));
                    Sal.WaitCursor(false);
                    e.Return = true;
                    return;
                }
            }
            else if(Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmAccPer")); ;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        #endregion        

        #region Menu Event Handlers
        
        #endregion
    }
}
