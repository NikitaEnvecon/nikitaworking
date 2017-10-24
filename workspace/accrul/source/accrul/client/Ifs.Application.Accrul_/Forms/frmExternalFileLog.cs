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
    [FndWindowRegistration("EXT_FILE_LOAD", "ExtFileLoad", FndWindowRegistrationFlags.HomePage)]
    public partial class frmExternalFileLog : cFormWindow
    {

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmExternalFileLog()
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
        public new static frmExternalFileLog FromHandle(SalWindowHandle handle)
        {
            return ((frmExternalFileLog)SalWindow.FromHandle(handle, typeof(frmExternalFileLog)));
        }
        #endregion

        #region Methods

        
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
       
        #endregion

        #region ChildTable-tblExternalFileLog

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="p_nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_LogDetail(SalNumber p_nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
     
            switch (p_nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    return Sal.TblAnyRows(tblExternalFileLog, Sys.ROW_Selected, 0) && Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("EXT_FILE_LOG_DETAIL");

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    Sal.WaitCursor(true);
                    sItemNames[0] = "LOAD_FILE_ID";
                    hWndItems[0] = tblExternalFileLog_colnLoadFileId;
                    sItemNames[1] = "SEQ_NO";
                    hWndItems[1] = tblExternalFileLog_colnSeqNo;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("ExtFileLogDetail", tblExternalFileLog, sItemNames, hWndItems);
                    SessionCreateWindow(Pal.GetActiveInstanceName("frmExternalFileLogDetail"), Sys.hWndMDI);
                    return true;
            }
       

            return false;
            #endregion
        }
        #endregion
    
        #endregion

        #region Event Handlers

        private void menuItem_External_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            
            ((FndCommand)sender).Enabled = this.UM_LogDetail(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_External_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            
            this.UM_LogDetail(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        #endregion

    }
}
