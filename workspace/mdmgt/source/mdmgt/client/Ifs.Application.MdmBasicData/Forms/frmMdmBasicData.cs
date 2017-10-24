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
using PPJ.Runtime.Sql;

namespace Ifs.Application.MdmBasicData
{

    /// <summary>
    /// </summary>
    [FndWindowRegistration("MDM_BASIC_DATA_HEADER", "MdmBasicDataHeader")]
    public partial class frmMdmBasicData : cMasterDetailTabFormWindow
    {
        #region Member Variables
        public const int PAMU_PopulateRoleJob = 3600;
        public SalNumber bReturn = 0;
        public SalString sTempId = "";
        public SalString sWinTiltle = "";
        public SalString sResult = "";
        public SalString sObjid = "";
        public SalArray<SalString> sParamArray = new SalArray<SalString>();
        public SalArray<SalString> sKeyArray = new SalArray<SalString>();
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmMdmBasicData()
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
        public new static frmMdmBasicData FromHandle(SalWindowHandle handle)
        {
            return ((frmMdmBasicData)SalWindow.FromHandle(handle, typeof(frmMdmBasicData)));
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        public void SetWindowTitle()
        {
            SalArray<SalString> sItems = new SalArray<SalString>();

            sItems[0] = SalString.FromHandle(this.ecmbTemplateId.EditDataItemValueGet());
            sItems[1] = dfsDescription.Text;

            Sal.SetWindowText(i_hWndFrame,
                Ifs.Fnd.ApplicationForms.Int
                .TranslateConstantWithParams(Properties.Resources.MdmBasicDataTitle,
                                             sItems));
        }

        private void Method_cmdActive_Execute()
        {
            ecmbTemplateId.Enabled = false;
            dfnRevision.Enabled = false;
            dfsDescription.Enabled = false;
            dfsState.Enabled = false;
            dfsCreatedBy.Enabled = false;
            dfdCreatedDate.Enabled = false;
            dfsProfileId.Enabled = false;
        }

        private void Method_cmdReOpen_Execute()
        {
            ecmbTemplateId.Enabled = true;
            dfnRevision.Enabled = true;
            dfsDescription.Enabled = true;
            dfsState.Enabled = true;
            dfsCreatedBy.Enabled = true;
            dfdCreatedDate.Enabled = true;
            dfsProfileId.Enabled = true;
        }

        private void Method_cmdCreateRevision_Execute()
        {
            SalNumber nIndex = 0;
            Sal.WaitCursor(true);
            SignatureHints hints = SignatureHints.NewContext();
            hints.Add("mdm_basic_data_header_api.C_Create_New_Revis_Struct", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
            if (DbPLSQLTransaction(cSessionManager.c_hSql, "&AO.mdm_basic_data_header_api.C_Create_New_Revis_Struct( :hWndForm.frmMdmBasicData.ecmbTemplateId, :hWndForm.frmMdmBasicData.dfnRevision)"))
            {
                DataSourceRefresh(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                sKeyArray[0] = ecmbTemplateId.i_sMyValue;
                sKeyArray[1] = dfnRevision.Text;
                sKeyArray[2] = dfsDescription.Text;
                using (SignatureHints hints1 = SignatureHints.NewContext())
                {
                    hints1.Add("mdm_basic_data_header_api.Get_Status", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    if (DbPLSQLBlock(cSessionManager.c_hSql, ":hWndForm.frmPmTab.sResult := &AO.mdm_basic_data_header_api.Get_Status( :hWndForm.frmMdmBasicData.ecmbTemplateId, :hWndForm.frmMdmBasicData.dfnRevision)"))
                    {
                        sKeyArray[3] = sResult;
                    }
                }
                nIndex = ecmbTemplateId.InsertDetails(ecmbTemplateId.GetItemCount() + 1, sKeyArray, 0);
                ecmbTemplateId.SetItemValue(nIndex, ecmbTemplateId.__nArrayEntries);
                using (SignatureHints hints1 = SignatureHints.NewContext())
                {
                    hints1.Add("mdm_basic_data_header_api.Get_Objid", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmPmTab.sObjid := &AO.mdm_basic_data_header_api.Get_Objid (:hWndForm.frmMdmBasicData.ecmbTemplateId.i_sMyValue,:i_hWndFrame.frmMdmBasicData.dfnRevision)");
                }
                ecmbTemplateId.__sRecordObjid[ecmbTemplateId.__nArrayEntries] = sObjid;
                ecmbTemplateId.__nArrayEntries = ecmbTemplateId.__nArrayEntries + 1;
                frmMdmBasicData.FromHandle(i_hWndFrame).ecmbTemplateId.SetSelectedItem(nIndex);
                frmMdmBasicData.FromHandle(i_hWndFrame).ecmbTemplateId.RecordSelectionListSetSelect(nIndex);
                PopulateRoleJob(5, 2);
                Sal.WaitCursor(false);
            }
            Sal.WaitCursor(false);
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
            //Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
        }

        public virtual SalNumber PopulateRoleJob(SalNumber nTabToPopulate, SalNumber nWParam)
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.PostMsg(TabAttachedWindowHandleGet(nTabToPopulate), Ifs.Fnd.ApplicationForms.Const.PM_User, nWParam, PAMU_PopulateRoleJob);
            }

            return 0;
            #endregion
        }

        private void ecmbTemplateId_OnPM_DataItemClear(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SetWindowText(this, "MDM Basic Data");
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemClear, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void ecmbTemplateId_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions

            e.Handled = true;
            //SetWindowTitle();
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam);
            Sal.GetWindowText(this.ecmbTemplateId, ref this.sTempId, 32000);
            this.sParamArray[0] = SalString.FromHandle(this.ecmbTemplateId.EditDataItemValueGet());
            this.sParamArray[1] = this.dfsDescription.Text;
            this.sParamArray[2] = this.dfsState.Text;
            sWinTiltle = "MDM Basic Data: " + this.sParamArray[0] + "-" + this.sParamArray[1] + "-" + this.sParamArray[2] + " ";
            Sal.SetWindowText(this.ecmbTemplateId.i_hWndFrame, sWinTiltle);
            e.Return = true;
            return;
            #endregion
        }

        private void frmMdmBasicData_OnPM_DataSourceClear(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.bReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceClear, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && this.bReturn == 1)
            {
                this.Method_cmdReOpen_Execute();
            }
            e.Return = this.bReturn;
            return;
            #endregion
        }

        private void frmMdmBasicData_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            #endregion
        }

        #endregion

        #region Overrides
        public override SalNumber vrtActivate(fcURL URL)
        {
            return base.vrtActivate(URL);
        }
        #endregion

        #region Window Actions

        private void frmMdmBasicData_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    if (dfsState.Text == "Activated")
                    {
                        Method_cmdActive_Execute();
                    }
                    else
                    {
                        Method_cmdReOpen_Execute();
                    }
                    this.frmMdmBasicData_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceClear:
                    this.frmMdmBasicData_OnPM_DataSourceClear(sender, e);
                    break;
            }
            #endregion
        }

        private void ecmbTemplateId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.ecmbTemplateId_OnPM_DataItemPopulate(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemClear:
                    this.ecmbTemplateId_OnPM_DataItemClear(sender, e);
                    break;
            }
        }

        #endregion

        #region Event Handlers
        private void cmdActive_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.DataRecordStateEvent(Const.METHOD_Execute, "Active");
            Method_cmdActive_Execute();
        }

        private void cmdActive_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            if (dfsState.Text == "New")
            {
                ((FndCommand)sender).Enabled = true;
            }
            else
            {
                ((FndCommand)sender).Enabled = false;
            }
        }

        private void cmdReOpen_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.DataRecordStateEvent(Const.METHOD_Execute, "Reopen");
            Method_cmdReOpen_Execute();
        }

        private void cmdReOpen_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            if (dfsState.Text == "Activated")
            {
                ((FndCommand)sender).Enabled = true;
            }
            else
            {
                ((FndCommand)sender).Enabled = false;
            }
        }

        private void cmdCreateRevision_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Method_cmdCreateRevision_Execute();
            DataSourceRefresh(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void cmdCreateRevision_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            if (dfsState.Text == "Activated")
            {
                ((FndCommand)sender).Enabled = true;
            }
            else
            {
                ((FndCommand)sender).Enabled = false;
            }
        }

        #endregion

        #region Menu Event Handlers

        #endregion
    }
}
