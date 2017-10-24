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
using Ifs.Fnd.Windows.Forms.InfoServicesControls;
using Ifs.Fnd.Windows.Forms;
using Ifs.Fnd.Explorer.Interfaces;
using Ifs.Fnd.AccessProvider.Activity;

namespace Ifs.Application.Accrul
{

    /// <summary>
    /// </summary>
    public partial class dlgAuditReportOrder : cDialog
    {
        #region Window Parameters
        public SalString p_sReportId;
        public SalString p_sReportParam;
        #endregion

        #region Member Variables
        public OrderReportControl ORControl;
        public IFndExplorer Explorer;
        public FndActivityContext ActivityContext;
        private Dictionary<string, string> reportParametersTable = new Dictionary<string, string>();
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgAuditReportOrder()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Shows the modal dialog.
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static SalNumber ModalDialog(Control owner, SalString p_sReportId, ref SalString p_sReportParam)
		{
			dlgAuditReportOrder dlg = DialogFactory.CreateInstance<dlgAuditReportOrder>();
			dlg.p_sReportId = p_sReportId;
			dlg.p_sReportParam = p_sReportParam;
			SalNumber ret = dlg.ShowDialog(owner);
            p_sReportParam = dlg.p_sReportParam;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgAuditReportOrder FromHandle(SalWindowHandle handle)
		{
			return ((dlgAuditReportOrder)SalWindow.FromHandle(handle, typeof(dlgAuditReportOrder)));
		}
		#endregion

        #region Properties

        #endregion

        #region Methods

        public new SalBoolean FrameStartupUser()
        {
            #region Variables
            SalString sInCompany = "";
            SalWindowHandle hWnd = SalWindowHandle.Null;
            #endregion

            #region Actions
            using (new SalContext(this))
            {             
                sInCompany = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("COMPANY", this.p_sReportParam);
                if (sInCompany != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    UserGlobalValueSet("COMPANY", sInCompany);
                }
                this.dfReportId.Text = p_sReportId; 
                this.Explorer = IFndApplication.GetExplorerFromCurrentThread();
                this.ActivityContext = cSessionManager.ActivityContext;
                commandList.Enabled = false;
                tabParam.Controls.Clear();
                ORControl = new OrderReportControl(p_sReportId, this.Explorer, this.ActivityContext);
                ORControl.LOVButtonStateChanged += new ListButtonStateChangedDelegate(ORControl_LOVButtonStateChanged);
                tabParam.Controls.Add(ORControl);
                ORControl.Dock = System.Windows.Forms.DockStyle.Fill;
                ORControl.LoadReport();
                return true;
            }
            #endregion
        }

        internal protected virtual SalString PrepareAttributeString(Dictionary<string, string> dictionayValues)
        {
            #region Actions
            SalString sParamAttr = "";
            foreach (string key in dictionayValues.Keys)
            {
                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd(key, dictionayValues[key], ref sParamAttr);
            }
            return sParamAttr;
            #endregion
        }

        void ORControl_LOVButtonStateChanged(object sender, ListButtonStateEventArgs e)
        {
            #region Actions
            this.commandList.Enabled = e.ButtonState;
            #endregion
        }

        #endregion

        #region Overrides

        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }
        #endregion

        #region Window Actions

        #endregion

        #region Event Handlers

        private void commandOk_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // Dialog class have AcceptButton set to run this logic if the user ends the dialog using the Return button.
            // PPJ dialog close trough Sal.EndDialog so we set DialogResult to prevent the dialog from closing premature.
            DialogResult = DialogResult.None;
            reportParametersTable = ORControl.ResultValue;
            if (reportParametersTable != null)
            {
                p_sReportParam = PrepareAttributeString(reportParametersTable);

                Sal.EndDialog(this, Sys.IDOK);
            }
        }

        private void commandCancel_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // Dialog class have CancelButton set to run this logic even if the user close the dialog trough the esc button.
            // PPJ dialog close trough Sal.EndDialog so we set DialogResult to prevent the dialog from closing premature.
            DialogResult = DialogResult.None;

            Sal.EndDialog(this, Sys.IDCANCEL);
        }

        private void commandList_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ORControl.DisplayLOVforCurrentParameter();
        }

        #endregion

    }
}
