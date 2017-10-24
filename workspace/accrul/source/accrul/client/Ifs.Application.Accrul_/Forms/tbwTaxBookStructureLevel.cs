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
	/// Tax Book Structure Levels view
	/// </summary>
    public partial class tbwTaxBookStructureLevel : cTableWindowFin
    {
        #region Window Variables
        public SalNumber nTmp = 0;
        public SalString sTopNodeName = "";
        public SalString sValidDate = "";
        public SalString sElimCodePart = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwTaxBookStructureLevel()
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
        public new static tbwTaxBookStructureLevel FromHandle(SalWindowHandle handle)
        {
            return ((tbwTaxBookStructureLevel)SalWindow.FromHandle(handle, typeof(tbwTaxBookStructureLevel)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="lsAttr"></param>
        /// <returns></returns>
        public new SalNumber DataRecordFetchEditedUser(ref SalString lsAttr)
        {
            #region Actions
            using (new SalContext(this))
            {
                lsAttr = lsAttr + "TOP_NODE_NAME" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + sTopNodeName + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean HasDuplicateLevelAbove()
        {
            #region Local Variables
            SalNumber nRow = 0;
            SalNumber nRow1 = 0;
            SalBoolean bDupFound = false;
            SalArray<SalString> sParams = new SalArray<SalString>();
            SalString sLevelAbovePrev = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nRow = Sys.TBL_MinRow;
                bDupFound = false;
                while (Sal.TblFindNextRow(i_hWndSelf, ref nRow, 0, 0) && !(bDupFound))
                {
                    nRow1 = nRow;
                    sLevelAbovePrev = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    if (Sal.TblFindNextRow(i_hWndSelf, ref nRow1, 0, 0))
                    {
                        Sal.TblSetContext(i_hWndSelf, nRow1);
                        if (!(Sal.IsNull(colLevelAbove)))
                        {
                            sLevelAbovePrev = colLevelAbove.Text;
                        }
                    }
                    while (Sal.TblFindNextRow(i_hWndSelf, ref nRow1, 0, 0))
                    {
                        Sal.TblSetContext(i_hWndSelf, nRow1);
                        if (!(Sal.IsNull(colLevelAbove)))
                        {
                            if (sLevelAbovePrev == Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                sLevelAbovePrev = colLevelAbove.Text;
                            }
                            else if (sLevelAbovePrev == colLevelAbove.Text)
                            {
                                bDupFound = true;
                                sParams[0] = sLevelAbovePrev;
                                break;
                            }
                        }
                    }
                }
                if (bDupFound)
                {
                    if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_DupLevelAbove1, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo, sParams) == Sys.IDYES)
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataSourceSaveCheck()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (!(HasDuplicateLevelAbove()))
                {
                    return false;
                }
                return ((cTableWindowFin)this).DataSourceSaveCheck();
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
        private void tbwTaxBookStructureLevel_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_User:
                    this.tbwTaxBookStructureLevel_OnPM_User(sender, e);
                    break;

                // The following code (On PM_DataRecordRemove) has been written to overcome a bug in Centura.

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tbwTaxBookStructureLevel_OnPM_DataRecordRemove(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_User event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwTaxBookStructureLevel_OnPM_User(object sender, WindowActionsEventArgs e)
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
        private void tbwTaxBookStructureLevel_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
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
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtDataRecordFetchEditedUser(ref SalString lsAttr)
        {
            return this.DataRecordFetchEditedUser(ref lsAttr);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataSourceSaveCheck()
        {
            return this.DataSourceSaveCheck();
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
