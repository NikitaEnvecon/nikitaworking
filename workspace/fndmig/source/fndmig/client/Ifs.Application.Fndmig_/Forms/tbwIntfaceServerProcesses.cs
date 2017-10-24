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
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Core;
using Ifs.Fnd.Explorer.Interfaces;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Fndmig_
{

    /// <summary>
    /// </summary>
    [FndWindowRegistration("BATCH_SCHEDULE_TASK", "BatchSchedule")]
    public partial class tbwIntfaceServerProcesses : cTableWindow
    {
        #region Member Variables
        public SalString sDateFormat = "";
        public SalString sTimeFormat = "";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwIntfaceServerProcesses()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // Window variables for database calls.
            InitializeWindowVariables();
        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static tbwIntfaceServerProcesses FromHandle(SalWindowHandle handle)
        {
            return ((tbwIntfaceServerProcesses)SalWindow.FromHandle(handle, typeof(tbwIntfaceServerProcesses)));
        }
        #endregion

        /**
         * InitializeWindowVariables: Window variables will be initialized here.
         */
        protected virtual void InitializeWindowVariables()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo(CultureInfo.CurrentCulture.Name);
            String sDatePatern = culture.DateTimeFormat.ShortDatePattern;
            String sTimePattern = culture.DateTimeFormat.ShortTimePattern;
            bool b24HourTime = sTimePattern.Contains("H");
            int nEmCount = 0;
            int nDiCount = 0;
            int nWyCount = 0;

            foreach (char c in sDatePatern)
            {
                
                switch (c)
                {
                    case 'M':
                    case 'm':
                        nEmCount++;
                        break;
                    case 'D':
                    case 'd':
                        nDiCount++;
                        break;
                    case 'Y':
                    case 'y':
                        nWyCount++;
                        break;
                }
            }

            if ((nEmCount < 1) || (nEmCount > 2) || (nDiCount < 1) || (nDiCount > 2) || (nWyCount < 2) || (nWyCount > 4))
            {
                // if the date format not recognized, use the default
                sDatePatern = "yyyy-MM-dd";
            }
            else
            {
                if (nEmCount == 1)
                {
                    sDatePatern = sDatePatern.Replace("M", "MM");
                    sDatePatern = sDatePatern.Replace("m", "mm");
                }
                if (nDiCount == 1)
                {
                    sDatePatern = sDatePatern.Replace("D", "DD");
                    sDatePatern = sDatePatern.Replace("d", "dd");
                }
            }

            // Update the window variables
            if (b24HourTime)
            {
                sTimeFormat = "HH24:mi";
            }
            else
            {
                sTimeFormat = "HH:mi AM";
            }

            sDateFormat = sDatePatern;
        }

        private void menuTbwMethods_menu_Execute_Job_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            if (FndMessageBox.Show(String.Format(Properties.Resources.TEXT_ConfirmRunSchedule, new string[] { colnScheduleId.Text , colsScheduleName.Text }),
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                DbPLSQLTransaction(cSessionManager.c_hSql, "Batch_Schedule_API.Run_Batch_Schedule__(:i_hWndFrame.tbwIntfaceServerProcesses.colnScheduleId)");
            }
        }

        private void menuTbwMethods_menu_View_Schedule_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            SalString keyList = SalString.Empty;
            SalString messageID = SalString.Empty;
            SalNumber columnID = ((SalTableColumn)(tbwIntfaceServerProcesses.FromHandle(Sys.hWndForm).colnScheduleId)).GetColumnID();
            SalNumber nRow = Sys.TBL_MinRow;
            SalNumber n = 1;
            while (Sal.TblFindNextRow(Sys.hWndForm, ref nRow, Sys.ROW_Selected, 0))
            {
                Sal.TblSetContext(Sys.hWndForm, nRow);
                Sal.TblGetColumnText(Sys.hWndForm, columnID, ref messageID);
                keyList = keyList + "&key" + n + "=" + messageID;
                n = n + 1;
            }
            IFndExplorerNavigationService navigationService = IFndApplication.FndApplication.ActiveExplorer.Services.GetServiceProvider<IFndExplorerNavigationService>();
            navigationService.Navigate(new FndUrlAddress(("ifswin:Ifs.Application.TaskScheduling.TaskSchedule?action=get" + keyList.ToString())));
        }

        private void menuTbwMethods_menu_View_Schedule_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // At least one row must be selected
            ((FndCommand)sender).Enabled = Sal.TblAnyRows(Sys.hWndForm, Sys.ROW_Selected, 0);
        }

        private void menuTbwMethods_menu_Execute_Job_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            // Save the focus row to later resetting
            SalNumber nContextRow = Sal.TblQueryContext(Sys.hWndForm);
            SalNumber nRow = Sys.TBL_MinRow;
            if (Sal.TblFindNextRow(Sys.hWndForm, ref nRow, Sys.ROW_Selected, 0))
            {
                if (Sal.TblFindNextRow(Sys.hWndForm, ref nRow, Sys.ROW_Selected, 0))
                {
                    ((FndCommand)sender).Enabled = false;
                }
                else
                {
                    ((FndCommand)sender).Enabled = true;
                }
            }
            else
            {
                ((FndCommand)sender).Enabled = false;
            }
            // Reset the focus row
            Sal.TblSetContext(Sys.hWndForm, nContextRow);
        }

        #region Properties

        #endregion

        #region Methods

        #endregion

        #region Overrides

        #endregion

        #region Window Actions

        #endregion

        #region Event Handlers

        #endregion

        #region Menu Event Handlers

        #endregion
    }
}
