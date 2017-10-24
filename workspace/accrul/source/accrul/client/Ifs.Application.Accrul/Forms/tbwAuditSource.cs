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

namespace Ifs.Application.Accrul
{

    /// <summary>
    /// </summary>
    public partial class tbwAuditSource : cTableWindow
    {
        #region Member Variables

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwAuditSource()
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
        public new static tbwAuditSource FromHandle(SalWindowHandle handle)
        {
            return ((tbwAuditSource)SalWindow.FromHandle(handle, typeof(tbwAuditSource)));
        }
        #endregion

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

        private void Columns_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Actions
            using (new SalContext(this))
            {
                Ifs.Fnd.ApplicationForms.Int.PostMessage(
                    this,
                    Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindow,
                    Ifs.Fnd.ApplicationForms.Const.METHOD_Execute,
                    Pal.GetActiveInstanceName("frmAuditSourceColumn"));
            }
            #endregion
        }

        private void Columns_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            #region Local Variables
            FndCommand command = (FndCommand)sender;
            #endregion

            #region Actions
            command.Enabled = true;
            #endregion
        }

        #endregion
    }
}
