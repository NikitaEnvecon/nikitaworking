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
    public partial class tbwTaxBookStructureCPValue : cTableWindowFin
    {
        #region Window Variables
        public SalString sStructureItemType = "";
        public SalString sLevelId = "";
        public SalString sOldCodePart = "";
        public SalArray<SalString> sItemNames = new SalArray<SalString>();
        public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwTaxBookStructureCPValue()
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
        public new static tbwTaxBookStructureCPValue FromHandle(SalWindowHandle handle)
        {
            return ((tbwTaxBookStructureCPValue)SalWindow.FromHandle(handle, typeof(tbwTaxBookStructureCPValue)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataRecordGetDefaults()
        {
            #region Local Variables
            SalNumber nInd = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (DbPrepareAndExecute(cSessionManager.c_hSql, "SELECT\r\n" + cSessionManager.c_sDbPrefix + "Tax_Book_Struc_Item_Type_API.Decode('TAXBOOK'),\r\n" + cSessionManager.c_sDbPrefix + "Tax_Book_Structure_Level_API.Get_Bottom_Level('" + colCompany.Text +
                    "','" + colStructureId.Text + "')\r\n" +
                    "INTO :i_hWndFrame.tbwTaxBookStructureCPValue.sStructureItemType,\r\n" +
                    ":i_hWndFrame.tbwTaxBookStructureCPValue.sLevelId FROM DUAL"))
                {
                    DbFetchNext(cSessionManager.c_hSql, ref nInd);
                }
                colStructureItemType.Text = sStructureItemType;
                Sal.SetFieldEdit(colStructureItemType, true);
                colLevelId.Text = sLevelId;
                Sal.SetFieldEdit(colLevelId, true);
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
        private void tbwTaxBookStructureCPValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_User:
                    this.tbwTaxBookStructureCPValue_OnPM_User(sender, e);
                    break;

                // The following code (On PM_DataRecordRemove) has been written to overcome a bug in Centura.

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tbwTaxBookStructureCPValue_OnPM_DataRecordRemove(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_User event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwTaxBookStructureCPValue_OnPM_User(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (SalString.FromHandle(Sys.lParam) == "CHANGE COMPANY")
            {
                Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwTaxBookStructureCPValue_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam))
            {
                if ((Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) && !(Sal.TblAnyRows(this.i_hWndSelf, 0, 0)))
                {
                    this.DataSourceClearIt(0);
                    e.Return = true;
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
        private void colNameValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colNameValue_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colNameValue_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                return;
            }
            else
            {
                this.sItemNames[0] = "TAX_BOOK_ID";
                this.hWndItems[0] = this.colNameValue;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Tax Book", this, this.sItemNames, this.hWndItems);
                SessionNavigate(Pal.GetActiveInstanceName("tbwTaxBook"));
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
        public override SalBoolean vrtDataRecordGetDefaults()
        {
            return this.DataRecordGetDefaults();
        }
        #endregion

        #region Event Handlers

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = (Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam));
        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_User, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "CHANGE COMPANY");
        }

        #endregion

    }
}
