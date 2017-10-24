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
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Accrul_
{

    /// <summary>
    /// </summary>
    public partial class dlgRpdMapAccPeriods : cDialogBox
    {
        #region Member Variables
        public SalString sRpdId;
        public SalString sCompany;
        public SalNumber nAccYearFrom;
        public SalNumber nAccYearTo;
        public SalString sIncludeYearEnd;

        #region Window Variables
        public SalWindowHandle hWndLovField = SalWindowHandle.Null;
        private SalNumber nNoPeriodCount = 0;
        #endregion
		
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgRpdMapAccPeriods()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();            
            Sal.DisableWindow(dfsCompany);
            SetWindowTitle();
            Sal.DisableWindow(this.pbList);                
        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Shows the modal dialog.
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static SalNumber ModalDialog(Control owner, SalString sRpdId, SalString sCompany)
        {            
            dlgRpdMapAccPeriods dlg = DialogFactory.CreateInstance<dlgRpdMapAccPeriods>();            
            dlg.sRpdId = sRpdId;
            dlg.dfsCompany.Text = sCompany;
            SalNumber ret = dlg.ShowDialog(owner);
            return ret;
        }

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static dlgRpdMapAccPeriods FromHandle(SalWindowHandle handle)
        {
            return ((dlgRpdMapAccPeriods)SalWindow.FromHandle(handle, typeof(dlgRpdMapAccPeriods)));
        }
        #endregion

        #region Properties
        
        #endregion

        #region Methods
        /// <summary>
        /// Stub for all user methods.
        /// Should be overridden with own method for all container classes.
        /// (other classen can override PM_UserMethod instead)
        /// </summary>
        /// <param name="nWhat"></param>
        /// <param name="sMethod"></param>
        /// <returns></returns>
        public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
        {
            #region Local Variables
            SalString sName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sMethod == "OK")
                {
                    return Ok(nWhat);
                }
                if (sMethod == "Cancel")
                {
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            return this.EndDialog(Sys.IDCANCEL);                            

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return 1;

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
                            return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_AnyMethod;
                    }
                }
                if (sMethod = "List")
                {
                    return List(nWhat);
                }
                Sal.GetItemName(Sys.hWndItem, ref sName);
                Ifs.Fnd.ApplicationForms.Int.ErrorBox("DESIGN TIME ERROR for item " + sName + "\r\n" +
                    "Function UserMethod handling method \"" + sMethod + "\" not written!");
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        return 0;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return 0;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
                        return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_AnyMethod;
                }
            }

            return 0;
            #endregion
        }
        
        protected virtual SalBoolean List(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean bOk = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return false;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        if (hWndLovField != SalWindowHandle.Null) 
						{
							if (Sal.SendMsg(hWndLovField, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0)) 
							{
								Sal.SendMsg(hWndLovField, Sys.SAM_Validate, 0, 0);
								Sal.SetFocus(hWndLovField);
                                pbOk.MethodInvestigateState();
								return Sal.PostMsg(hWndLovField, Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
							}
							else
							{
								Sal.SetFocus(hWndLovField);
							}
						}
                        Sal.WaitCursor(false);                        
						return true;
                }
            }
            return false;
            #endregion
        }

        protected virtual SalBoolean Ok(SalNumber nWhat)
        {
            #region Local Variables
            SalNumber nResult;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        sCompany = dfsCompany.Text;
                        nAccYearFrom = dfnAccountingYearFrom.Number;
                        nAccYearTo = dfnAccountingYearTo.Number;
                        sIncludeYearEnd = cbIncludeYearEnd.Checked ? "TRUE" : "FALSE";                        
                        if (DbPLSQLTransaction(@"&AO.Rpd_Company_API.Map_Accounting_Periods( {0} OUT, {1} IN , {2} IN , {3} IN , {4} IN , {5} IN ) ", 
                                                         QualifiedVarBindName("nNoPeriodCount"),
                                                         QualifiedVarBindName("sRpdId"),
                                                         QualifiedVarBindName("sCompany"),
                                                         QualifiedVarBindName("nAccYearFrom" ),
                                                         QualifiedVarBindName("nAccYearTo") ,
                                                         QualifiedVarBindName("sIncludeYearEnd")))
                        {
                            if (nNoPeriodCount > 0)
                            {                              
                                
                                return this.EndDialog(Sys.IDNO);
                            }
                            else
                            {
                                return this.EndDialog(Sys.IDOK);
                            }
                        }
                        return false;
                }
            }
            return false;
            #endregion
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return UserMethod(nWhat, sMethod);
        }

        /// <summary>
        /// Set the window title according to current area and country.
        /// </summary>
        public virtual void SetWindowTitle()
        {
            Sal.SetWindowText(this, Properties.Resources.WH_dlgRpdMapAccPeriods);
        }         
        #endregion

        #region Message Actions

        #endregion

        #region Event Handlers

        #endregion

        #region Window Actions
        /// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsCompany_WindowActions(object sender, WindowActionsEventArgs e)
        {
        	#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
                    this.dfsCompany_OnSAM_SetFocus(sender, e);
					break;                
			}
			#endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsCompany_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam))
            {
                Sal.EnableWindow(this.pbList);
                this.hWndLovField = this.dfsCompany.i_hWndSelf;                
            }
            #endregion
        }
        
        private void dfnAccountingYearFrom_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.dfnAccountingYearFrom_OnSAM_SetFocus(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this. dfnAccountingYearFrom_OnPM_DataItemLovUserWhere(sender, e) ;
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfnAccountingYearFrom_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam))
            {
                Sal.EnableWindow(this.pbList);
                this.hWndLovField = this.dfnAccountingYearFrom.i_hWndSelf;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfnAccountingYearFrom_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (string.IsNullOrEmpty(this.dfsCompany.Text))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.LOVITEMVALUE_IsNull;
                return;
            }
            else
            {
                sCompany = dfsCompany.Text;
                e.Return = new SalString("COMPANY = :i_hWndFrame.dlgRpdMapAccPeriods.sCompany").ToHandle();
                return;
            }
            #endregion
        }
		
        private void dfnAccountingYearTo_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.dfnAccountingYearTo_OnSAM_SetFocus(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.dfnAccountingYearTo_OnPM_DataItemLovUserWhere(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfnAccountingYearTo_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam))
            {
                Sal.EnableWindow(this.pbList);
                this.hWndLovField = this.dfnAccountingYearTo.i_hWndSelf;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfnAccountingYearTo_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (string.IsNullOrEmpty(this.dfsCompany.Text))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.LOVITEMVALUE_IsNull;
                return;
            }
            else
            {
                sCompany = dfsCompany.Text;
                e.Return = new SalString("COMPANY = :i_hWndFrame.dlgRpdMapAccPeriods.sCompany").ToHandle();
                return;
            }
            #endregion
        }
		
        private void cbIncludeYearEnd_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.cbIncludeYearEnd_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }
        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbIncludeYearEnd_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam))
            {
                Sal.DisableWindow(this.pbList);
                this.hWndLovField = this.cbIncludeYearEnd.i_hWndSelf;
            }
            #endregion
        }

        #endregion

        #region Menu Event Handlers

        #endregion
    }
}
