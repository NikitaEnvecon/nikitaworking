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
// 221009  WAPELK  Bug 86293, Move FrameStartupUser() mwthod contents to vrtActivate
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
    [FndWindowRegistration("PROJECT_COST_ELEMENT", "ProjectCostElement", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwProjectCostElement : cTableWindowFin
    {
        #region Window Variables
        public SalString sModule = "";
        public SalString sLu = "";
        public SalString lsAttribute = "";
        public SalNumber nResult = 0;
        public SalString sBaseCodePartName = "";
        public SalBoolean bOk = false;
        public SalString sDefaultNoBaseCostElement = "";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwProjectCostElement()
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
        public new static tbwProjectCostElement FromHandle(SalWindowHandle handle)
        {
            return ((tbwProjectCostElement)SalWindow.FromHandle(handle, typeof(tbwProjectCostElement)));
        }
        #endregion

        #region Methods
        // Bug Id 86293, Begin
        // Bug Id 86293. Moved code to vrtActivate.
        // Bug Id 86293, End

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
                            sLu = "ProjectCostElement";
                            lsAttribute = Ifs.Fnd.ApplicationForms.Const.strNULL;
                            nRow = Sys.TBL_MinRow;
                            while (true)
                            {
                                // Bug 73889, Begin. Used i_hWndSelf instead of window name.
                                if (Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_Selected, 0))
                                {
                                    Sal.TblSetContext(i_hWndSelf, nRow);
                                    lsAttribute = lsAttribute + "'" + colsProjectCostElement.Text + "'" + ",";
                                }
                                // Bug 73889, End.
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
        /// <returns></returns>
        public new SalBoolean DataSourceSaveCheckOk()
        {
            #region Local Variables
            SalBoolean bOk = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                bOk = ((cTableWindowFin)this).DataSourceSaveCheckOk();
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Project_Cost_Element_API.Check_Default_Element__", System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                        "				&AO.Project_Cost_Element_API.Check_Default_Element__(:i_hWndFrame.tbwProjectCostElement.colsCompany);\r\n" +
                        "			    END;")))
                    {
                        return false;
                    }
                }
                return bOk;
            }
            #endregion
        }
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            SalArray<SalString> sComp = new SalArray<SalString>();
            SalNumber nRC = 0;
            SalNumber nItemIndex = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    nItemIndex = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY");
                    if (nItemIndex >= 0)
                    {
                        nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nItemIndex, 0, ref i_sCompany);
                    }
                    UserGlobalValueSet("COMPANY", i_sCompany);
                    SetWindowTitle();
                    InitFromTransferedData();
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);
                    return false;
                }
                return base.Activate(URL);
            }
            #endregion
        }

        protected virtual bool ToggleDefaultNoBase(int p_nWhat)
        {
            #region Local Variables
            SalNumber   ln_currentTableRow = 0;
            SalNumber   nCounter = 0;
            SalBoolean  bOk = false;
            SalArray<SalString> sParam = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (p_nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        ln_currentTableRow = Sys.TBL_MinRow;
                        nCounter = 0;
                        while (Sal.TblFindNextRow(i_hWndSelf, ref ln_currentTableRow, Sys.ROW_Selected, 0))
                        {
                            Sal.TblSetContext(i_hWndSelf, ln_currentTableRow);
                            nCounter = nCounter + 1;
                        }

                        if ((nCounter == 1) && !(DataSourceSave(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)) && Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("PROJECT_COST_ELEMENT") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Project_Cost_Element_API.Set_Default_No_Base__"))
                        {
                            return true;
                        }

                     
                        return false;
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        {
                            if (cbObsolete.Text == "TRUE")
                            {
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NotAllowedWithBlockForUse, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                return false;
                            }

                            if (colsElementTypeDb.Text == "REVENUE")
                            {
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoDefaultBaseForRevnue, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                return false;                               
                            }

                            GetBaseCodePartName();
                            sParam[0] = this.sBaseCodePartName;
                            sParam[1] = this.colsProjectCostElement.Text;
                            Sal.WaitCursor(true);
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                this.nResult = 0;
                                hints.Add("Project_Cost_Element_API.Check_Default_No_Base_Exist__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input);
                                DbPLSQLBlock(cSessionManager.c_hSql,   "&AO.Project_Cost_Element_API.Check_Default_No_Base_Exist__(\r\n" +
                                                                                                                              "  :i_hWndFrame.tbwProjectCostElement.nResult,\r\n" +
                                        				                                                                      "  :i_hWndFrame.tbwProjectCostElement.colsCompany);");

                                if (this.nResult == 0)  
                                {
                                    if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_DefaultBaseFirstTime, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, (Ifs.Fnd.ApplicationForms.Const.INFO_OkCancel | Sys.MB_DefButton2), sParam) == Sys.IDCANCEL)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        bOk = DbPLSQLTransaction(cSessionManager.c_hSql, "BEGIN" + "  &AO.Project_Cost_Element_API.Set_Default_No_Base__(:i_hWndFrame.tbwProjectCostElement.colsCompany IN , :i_hWndFrame.tbwProjectCostElement.colsProjectCostElement IN);  END;");
                                        Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                                        return true;
                                    }
                                }
                                else if (this.nResult == 1 && cbDefaultNoBase.Text == "FALSE")
                                {

                                    GetDefaultNoBase();
                                    sParam.Clear();
                                    sParam[0] = this.sDefaultNoBaseCostElement;
                                    sParam[1] = this.colsProjectCostElement.Text;
                                    if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_ChangeDefaultNoBase, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, (Ifs.Fnd.ApplicationForms.Const.INFO_OkCancel | Sys.MB_DefButton2), sParam) == Sys.IDCANCEL)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        bOk = DbPLSQLTransaction(cSessionManager.c_hSql, "BEGIN" + "  &AO.Project_Cost_Element_API.Set_Default_No_Base__(:i_hWndFrame.tbwProjectCostElement.colsCompany IN , :i_hWndFrame.tbwProjectCostElement.colsProjectCostElement IN);  END;");
                                        Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                                        return true;
                                    }
                                }
                                if (cbDefaultNoBase.Text == "TRUE")
                                {
                                    sParam.Clear();
                                    sParam[0] = this.sBaseCodePartName;

                                    if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_RemoveDefaultNoBase, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, (Ifs.Fnd.ApplicationForms.Const.INFO_OkCancel | Sys.MB_DefButton2), sParam) == Sys.IDCANCEL)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        bOk = DbPLSQLTransaction(cSessionManager.c_hSql, "BEGIN" + "  &AO.Project_Cost_Element_API.Reset_Default_No_Base__(:i_hWndFrame.tbwProjectCostElement.colsCompany IN , :i_hWndFrame.tbwProjectCostElement.colsProjectCostElement IN);  END;");
                                        Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                                        return true;
                                        
                                    }
                                   
                                }
                            }
                            Sal.WaitCursor(false);
                            return true;                            
                        }
                }
            }

            return true;
            #endregion
        }

        protected virtual SalString GetDefaultNoBase()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Project_Cost_Element_API.Get_Default_No_Base", System.Data.ParameterDirection.Input);

                    DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.tbwProjectCostElement.sDefaultNoBaseCostElement := &AO.Project_Cost_Element_API.Get_Default_No_Base(\r\n" +
                                                                               " :i_hWndFrame.tbwProjectCostElement.colsCompany)");
                    return this.sDefaultNoBaseCostElement;
                }
            }

            #endregion
        }

        protected virtual SalString GetBaseCodePartName()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Accounting_Code_Parts_API.Get_Name", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("Accounting_Code_Parts_API.Get_Base_For_Followup_Element", System.Data.ParameterDirection.Input);


                    DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.tbwProjectCostElement.sBaseCodePartName:= &AO.Accounting_Code_Parts_API.Get_Name(\r\n" +
                                                                               " :i_hWndFrame.tbwProjectCostElement.colsCompany ,\r\n"  +
                                                                               "  &AO.Accounting_Code_Parts_API.Get_Base_For_Followup_Element(:i_hWndFrame.tbwProjectCostElement.colsCompany))");
                    return this.sBaseCodePartName;


                }
            }
                       
            #endregion
        }

        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataSourceSaveCheckOk()
        {
            return this.DataSourceSaveCheckOk();
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

        private void menuItem_Translation_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Translation_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
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

        private void menuTbwMethods_Toggle_Default_No_Base____Execute(object sender, FndCommandExecuteEventArgs e)
        {
            ToggleDefaultNoBase(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuTbwMethods_Toggle_Default_No_Base____Inquire(object sender, FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ToggleDefaultNoBase(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        #endregion

        

        

        
    }
}
