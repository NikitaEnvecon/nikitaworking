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
    public partial class frmAuditSourceColumn : cFormWindow
    {
        #region Member Variables

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmAuditSourceColumn()
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
        public new static frmAuditSourceColumn FromHandle(SalWindowHandle handle)
        {
            return ((frmAuditSourceColumn)SalWindow.FromHandle(handle, typeof(frmAuditSourceColumn)));
        }
        #endregion

        private void cmdTranslate_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = (this.cChildTableDetail_colsSelectionDateDb.Text == "TRUE");
        }

        private void cmdTranslate_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalString sModule = "";
            SalString sLu = "";
            fcURL URL = new fcURL();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sModule = "ACCRUL";
                sLu = "AuditSourceColumn";
                URL.SetProgId(Pal.GetActiveInstanceName("frmBasicDataTranslation"));
                //URL.iParameters.AddAttribute("action", "populate");
                URL.iParameters.AddAttribute("MODULE", sModule);
                URL.iParameters.AddAttribute("LU", sLu);
                URL.Go();
            }
            #endregion

        }

        #region Properties

        #endregion

        #region Methods

        #endregion

        #region Overrides

        #endregion

        #region Window Actions

        #endregion

        #region Overrides

        #endregion

        #region Menu Event Handlers

        #endregion
    }
}
