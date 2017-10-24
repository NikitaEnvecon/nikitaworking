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
    [FndWindowRegistration("VOUCHER_TEXT", "VoucherText", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwVoucherText : cTableWindowFin
    {
        #region Window Variables
        public SalString sModule = "";
        public SalString sLu = "";
        public SalString lsAttribute = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwVoucherText()
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
        public new static tbwVoucherText FromHandle(SalWindowHandle handle)
        {
            return ((tbwVoucherText)SalWindow.FromHandle(handle, typeof(tbwVoucherText)));
        }
        #endregion

        #region Methods

        
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
                        sModule = "ACCRUL";
                        sLu = "VoucherText";
                        lsAttribute = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        nRow = Sys.TBL_MinRow;
                        while (true)
                        {
                            if (Sal.TblFindNextRow(this, ref nRow, Sys.ROW_Selected, 0))
                            {
                                Sal.TblSetContext(this, nRow);
                                lsAttribute = lsAttribute + "'" + colsTextId.Text + "'" + ",";
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (lsAttribute != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            lsAttribute = lsAttribute.Left(lsAttribute.Length - 1);
                        }
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_COMPANY", i_sCompany);
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_MODULE", sModule);
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_LU", sLu);
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_ATTRIBUTE", lsAttribute);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmCompanyTranslation"), Sys.hWndMDI);
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
        #endregion

        #region Late Bind Methods

       
        #endregion

        #region Event Handlers

        private void menuItem__Translation_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = this.Translation( Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire );
            
        }

        private void menuItem__Translation_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.Translation(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);

        }

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            
            Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
        }

        #endregion

    }
}
