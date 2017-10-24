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
    [FndWindowRegistration("USER_GROUP_FINANCE", "UserGroupFinance")]
    public partial class frmUserGrMem : cFormWindowFin
    {
        #region Window Variables
        public SalNumber nYear = 0;
        public SalString sCompanyName = "";
        public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
        public SalArray<SalString> sChanges = new SalArray<SalString>();
        public SalString sID = "";
        public SalNumber nNumChanges = 0;
        public SalArray<SalString> sItemNames = new SalArray<SalString>();
        public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmUserGrMem()
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
        public new static frmUserGrMem FromHandle(SalWindowHandle handle)
        {
            return ((frmUserGrMem)SalWindow.FromHandle(handle, typeof(frmUserGrMem)));
        }
        #endregion

        #region Methods
        // Insert new code here...
                
        
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Properties.Resources.WH_frmUserGrMem;
            }
            #endregion
        }

        public virtual SalNumber ChangeComp( SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {   
                switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            return Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
                    }
                return 0;
            }
            #endregion

        }
        #endregion

        #region Late Bind Methods
        // Insert new code here...

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalString vrtGetWindowTitle()
        {
            return this.GetWindowTitle();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
       
        #endregion

        #region ChildTable-tblUserGroups

        #region Window Variables
        public SalNumber nCount = 0;
        public SalString sGroup = "";
        #endregion

        #region Methods

        /// <summary>
        /// Gets client default values for NEW records
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean tblUserGroups_DataRecordGetDefaults()
        {
            this.tblUserGroups_colCompany.Text = this.dfCompany.Text;
            this.tblUserGroups_colCompany.EditDataItemSetEdited();
            this.tblUserGroups_colUserGroup.Text = SalString.FromHandle(this.cmbUserGroup.EditDataItemValueGet());
            this.tblUserGroups_colUserGroup.EditDataItemSetEdited();
            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="hSql">
        /// Sql handle
        /// Database connection sql handle to use for this server function call. Typically c_hSql is used.
        /// </param>
        /// <returns>The return value is TRUE if record may be removed, FALSE otherwise.</returns>
        public virtual SalBoolean tblUserGroups_DataRecordCheckRemove(SalSqlHandle hSql)
        {
            #region Local Variables
            SalArray<SalString> sDelete = new SalArray<SalString>();
            #endregion

            #region Actions

            if (tblUserGroups_colsDefaultGroupDb.Text == "Y")
            {
                sDelete[0] = tblUserGroups_colUserid.Text;
                string stmt = string.Format(@"&AO.User_Group_Member_Finance_Api.Count_User_Groups_Per_User__( {0} OUT, {1} IN, {2} IN )",
                                            this.QualifiedVarBindName("nCount"),
                                            this.tblUserGroups_colCompany.QualifiedBindName,
                                            this.tblUserGroups_colUserid.QualifiedBindName);
                DbPLSQLBlock(hSql,stmt);
               
                if (nCount > 1)
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_DeleteUser, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sDelete);
                    return false;
                }
                else
                {
                    if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_CheckDeleteUser, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo, sDelete) == Sys.IDYES)
                    {
                        return ((cChildTableFin)tblUserGroups).DataRecordCheckRemove(cSessionManager.c_hSql);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return ((cChildTableFin)tblUserGroups).DataRecordCheckRemove(cSessionManager.c_hSql);
            }
           
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber tblUserGroups_DataRecordRemove(SalNumber nWhat)
        {
            #region Local Variables
            SalNumber nNum = 0;
            SalBoolean bOk = false;
            SalNumber nCurrentRow = 0;
            #endregion

            #region Actions
 
            switch (nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    nCurrentRow = Sys.TBL_MinRow;
                    bOk = true;
                    while (Sal.TblFindNextRow(tblUserGroups, ref nCurrentRow, Sys.ROW_Selected, 0))
                    {
                        nNum = nNum + 1;
                        if (nNum > 10)
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoDelAbv, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            bOk = false;
                            break;
                        }
                    }
                    if (bOk)
                    {
                        return ((cChildTableFin)tblUserGroups).DataRecordRemove(nWhat);
                    }
                    return 0;

                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    return ((cChildTableFin)tblUserGroups).DataRecordRemove(nWhat);

                case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
                    return ((cChildTableFin)tblUserGroups).DataRecordRemove(nWhat);
            }
          

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckGroup()
        {
            #region Actions
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    if (DbPLSQLBlock(@"{0} := &AO.USER_GROUP_MEMBER_FINANCE_API.Get_Default_Group({1} IN,{2} IN); ", 
                                                   this.QualifiedVarBindName("sGroup"),
                                                   this.tblUserGroups_colCompany.QualifiedBindName,
                                                   this.tblUserGroups_colUserid.QualifiedBindName))
                    {
                        return (sGroup == tblUserGroups_colUserGroup.Text);  
                    }
                    else
                    { return false; }
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
        private void tblUserGroups_colUserid_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.tblUserGroups_colUserid_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblUserGroups_colUserid_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            switch (Sys.wParam)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.tblUserGroups_colCompany;
                    this.sItemNames[1] = "USERID";
                    this.hWndItems[1] = this.tblUserGroups_colUserid;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("COMPANY_FINANCE", tblUserGroups, this.sItemNames, this.hWndItems);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("FROMACCRUL");
                    SessionNavigate(Pal.GetActiveInstanceName("frmUserFin"));
                    e.Return = true;
                    return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblUserGroups_colDefaultGroup_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblUserGroups_colDefaultGroup_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblUserGroups_colDefaultGroup_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (Sal.ListQuerySelection(this.tblUserGroups_colDefaultGroup) == 1)
                {
                    if (!(Sal.IsNull(this.tblUserGroups_colUserid)))
                    {
                        if (this.CheckGroup())
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_CheckDefault, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            e.Return = Sys.VALIDATE_Cancel;
                            return;
                        }
                    }
                    else
                    {
                        e.Return = Sys.VALIDATE_Ok;
                        return;
                    }
                }
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            e.Return = Sys.VALIDATE_Cancel;
            return;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        private void tblUserGroups_DataRecordCheckRemoveEvent(object sender, cDataSource.DataRecordCheckRemoveEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblUserGroups_DataRecordCheckRemove(e.hSql);
        }

        private void tblUserGroups_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblUserGroups_DataRecordGetDefaults();
        }

        private void tblUserGroups_DataRecordRemoveEvent(object sender, cDataSource.DataRecordRemoveEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblUserGroups_DataRecordRemove(e.nWhat);
        }
        #endregion
    
        #endregion

        #region Event Handlers

        private void menuItem_Change_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
           
            ((FndCommand)sender).Enabled = ChangeComp(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
          }
        

        private void menuItem_Change_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
           ChangeComp(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);  
        }

        private void menuItem_Change_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = ChangeComp(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void menuItem_Change_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            ChangeComp(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);  
        }

        #endregion

       

       

       

    }
}
