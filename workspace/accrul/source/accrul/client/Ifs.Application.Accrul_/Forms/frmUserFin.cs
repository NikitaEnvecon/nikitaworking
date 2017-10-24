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

namespace Ifs.Application.Accrul_
{
	
	/// <summary>
	/// </summary>
	[FndWindowRegistration("USER_FINANCE", "UserFinance", FndWindowRegistrationFlags.HomePage)]
	public partial class frmUserFin : cFormWindowFin
	{
		#region Window Variables
		public SalNumber nTemp = 0;
		public SalString sTemp = "";
		public SalString lsTemp = "";
		public SalString sCompany = "";
		public SalString sUserId = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmUserFin()
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
		public new static frmUserFin FromHandle(SalWindowHandle handle)
		{
			return ((frmUserFin)SalWindow.FromHandle(handle, typeof(frmUserFin)));
		}
		#endregion
		
		#region Methods
        // Insert new code here...
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            SalArray<SalString> sItemValues = new SalArray<SalString>();
            SalNumber nItemIndex = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    nItemIndex = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY");
                    if (nItemIndex != -1)
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("COMPANY", sItemValues);
                        sCompany = sItemValues[0];
                    }
                    nItemIndex = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("USERID");
                    if (nItemIndex != -1)
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("USERID", sItemValues);
                        sUserId = sItemValues[0];
                    }

                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    if (sCompany != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        DataSourceUserWhere(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"company = (:i_hWndFrame.frmUserFin.sCompany) ").ToHandle());
                        Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_Single);
                        if (sUserId != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            tblUserFin.DataSourceUserWhere(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"company = (:i_hWndFrame.frmUserFin.sCompany) AND userid = (:i_hWndFrame.frmUserFin.sUserId) ").ToHandle());
                        }
                        Sal.SendMsgToChildren(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_Single);
                    }
                    SetWindowTitle();
                    Sal.WaitCursor(false);
                    return false;
                }
                SetWindowTitle();
                Sal.WaitCursor(false);
                return base.Activate(URL);
            }
            #endregion
            
        }
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalString GetWindowTitle()
		{
			#region Actions
			using (new SalContext(this))
			{
				return Properties.Resources.WM_frmUserFin;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean ShowActiveCompany()
		{
			#region Actions
			using (new SalContext(this))
			{
				return false;
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
		private void tblUserFin_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_FetchRowDone:
					this.tblUserFin_OnSAM_FetchRowDone(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_FetchRowDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblUserFin_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam);
			//if (this.tblUserFin_colsCompany.Text == this.tblUserFin_colsDefaultComp.Text) 
			//{
			//	this.tblUserFin_colsDefault.Text = "Y";
			//}
			//else
			//{
			//	this.tblUserFin_colsDefault.Text = "N";
			//}
			this.tblUserFin_colsDefaultComp2.Text = this.tblUserFin_colsDefault.Text;
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
		public override SalBoolean vrtShowActiveCompany()
		{
			return this.ShowActiveCompany();
		}
		#endregion
		
		#region ChildTable-tblUserFin
			
		#region Methods
			
		/// <summary>
		/// Gets client default values for NEW records
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean tblUserFin_DataRecordGetDefaults()
		{
            tblUserFin_colsCompany.Text = SalString.FromHandle(this.cmbsCompany.EditDataItemValueGet());
            tblUserFin_colsCompany.EditDataItemSetEdited();
            tblUserFin_colsDefault.Text = "FALSE";
            tblUserFin_colsDefault.EditDataItemSetEdited();
            return true;
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CheckDefaultNO()
		{
            //if ((tblUserFin_colsCompany.Text == tblUserFin_colsDefaultComp2.Text) && (tblUserFin.DataRecordIdGet() != Ifs.Fnd.ApplicationForms.Const.strNULL))
            if (tblUserFin.DataRecordIdGet() != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
                if (tblUserFin_colsDefault.Text == "FALSE" && tblUserFin_colsDefaultComp2.Text == "TRUE") 
				{
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_CheckDefault_Comp, Properties.Resources.WM_frmUserFin, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					tblUserFin_colsDefault.Text = "TRUE";
                    return false;
				}
			}
			//if (tblUserFin_colsDefault.Text == "TRUE") 
			//{
            //    tblUserFin_colsDefaultComp.Text = tblUserFin_colsCompany.Text;
			//}
			//else
			//{
            //    tblUserFin_colsDefaultComp.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
			//}
            //tblUserFin_colsDefaultComp.EditDataItemSetEdited();
			return true;
		}
			
		/// <summary>
		/// Checks the current record for required fields
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean tblUserFin_DataRecordCheckRequired()
		{
			#region Local Variables
			SalArray<SalString> sValue = new SalArray<SalString>(1);
			#endregion
				
			#region Actions
			if (!(((cDataSource)this.tblUserFin).DataRecordCheckRequired())) 
			{
				return false;
			}
			// make sure set Flags colsDefaultComp is Y for new user id
            if ((tblUserFin_colsIsNewUserId.Text == "Y") && (tblUserFin_colsDefault.Text != "TRUE")) 
			{
				Sal.WaitCursor(false);
                sValue[0] = tblUserFin_colsUserId.Text;
                Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_CheckDefault_NewUserId, Properties.Resources.WM_frmUserFin, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sValue);
				tblUserFin_colsDefault.Text = "TRUE";
                tblUserFin_colsDefault.EditDataItemSetEdited();
                //tblUserFin_colsDefaultComp.Text = tblUserFin_colsCompany.Text;
                //tblUserFin_colsDefaultComp.EditDataItemSetEdited();
			}
            if (tblUserFin_colsDefault.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed) 
			{
                return (CheckDefaultNO());
			}
            //Sal.SetFieldEdit(tblUserFin_colsDefault, false);
			return true;
			#endregion
		}
			
		/// <summary>
		/// The tblUserFin_DataRecordExecuteNew function performs server creation of
		/// new records.
		/// COMMENTS:
		/// tblUserFin_DataRecordExecuteNew is called once for each new record by the
		/// DataSourceExecuteSqlInsert function during the save process.
		/// </summary>
		/// <param name="hSql">
		/// Sql handle
		/// Database connection sql handle to use for this server function call. Typically c_hSql is used.
		/// </param>
		/// <returns>The return value is TRUE if the record is created successfully, FALSE otherwise.</returns>
		public virtual SalBoolean tblUserFin_DataRecordExecuteNew(SalSqlHandle hSql)
		{				
            SalBoolean bOk = ((cChildTable)this.tblUserFin).DataRecordExecuteNew(hSql);
            if ((tblUserFin_colsUserId.Text == Ifs.Fnd.ApplicationForms.Int.FndUser()) && (tblUserFin_colsDefault.Text == "TRUE")) 
			{
				_UserProfileCurrentSet("COMPANY", this.cmbsCompany.i_sMyValue);
			}
			return bOk;
		}
			
		/// <summary>
		/// The tblUserFin_DataRecordExecuteModify function performs server update of
		/// modified records.
		/// COMMENTS:
		/// tblUserFin_DataRecordExecuteModify is called once for each modified record by the
		/// DataSourceExecuteSqlUpdate function during the save process.
		/// </summary>
		/// <param name="hSql">
		/// Sql handle
		/// Database connection sql handle to use for this server function call. Typically c_hSql is used.
		/// </param>
		/// <returns>The return value is TRUE if the record is updated successfully, FALSE otherwise.</returns>
		public virtual SalBoolean tblUserFin_DataRecordExecuteModify(SalSqlHandle hSql)
		{				
            SalBoolean bOk = ((cChildTable)this.tblUserFin).DataRecordExecuteModify(hSql);
            if ((tblUserFin_colsUserId.Text == Ifs.Fnd.ApplicationForms.Int.FndUser()) && (tblUserFin_colsDefault.Text == "TRUE")) 
		    {
			    _UserProfileCurrentSet("COMPANY", this.cmbsCompany.i_sMyValue);
		    }
		    return bOk;
		}
			
		/// <summary>
		/// </summary>
		/// <param name="sUserId"></param>
		/// <returns></returns>
		public virtual SalNumber CountUserId(SalString sUserId)
		{
			this.sTemp = sUserId;
			if (!(DbPLSQLBlock(@"&AO.User_Finance_API.Count_UserId({0} OUT,{1} IN )", this.QualifiedVarBindName("nTemp"), this.QualifiedVarBindName("sTemp")))) 
			{ return 0; }
			return this.nTemp;
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ValidateUserId()
		{
			Sal.WaitCursor(true);
			using(SignatureHints hints = SignatureHints.NewContext())
			{
				hints.Add("Fnd_User_API.Exist", System.Data.ParameterDirection.Input);
				if (!(DbPLSQLBlock(@"&AO.Fnd_User_API.Exist ({0} IN)",tblUserFin_colsUserId.QualifiedBindName)))
				{
					Sal.WaitCursor(false);
					return false;
				}
			}
			Sal.WaitCursor(false);
			return true;
		}
			
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber tblUserFin_DataRecordRemove(SalNumber nWhat)
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
					while (Sal.TblFindNextRow(tblUserFin, ref nCurrentRow, Sys.ROW_Selected, 0)) 
					{
						nNum = nNum + 1;
						if (nNum > 10) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoDelUsersAbv, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
							bOk = false;
							break;
						}
					}
					if (bOk) 
					{
						return ((cChildTable)this.tblUserFin).DataRecordRemove(nWhat);
					}
					return 0;
						
				case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
					return ((cChildTable)this.tblUserFin).DataRecordRemove(nWhat);
						
				case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
                    return ((cChildTable)this.tblUserFin).DataRecordRemove(nWhat);
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
		private void tblUserFin_colsUserId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblUserFin_colsUserId_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblUserFin_colsUserId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
                if (Sal.IsNull(this.tblUserFin_colsUserId.i_hWndSelf)) 
				{
					e.Return = true;
					return;
				}
				// Bug 83771, Else condition removed
				if (!(this.ValidateUserId())) 
				{
					e.Return = false;
					return;
				}
                if (this.CountUserId(this.tblUserFin_colsUserId.Text) == 0) 
				{
                    this.tblUserFin_colsIsNewUserId.Text = "Y";
				}
				else
				{
                    this.tblUserFin_colsIsNewUserId.Text = "N";
				}
				e.Return = true;
				return;
			}
			else
			{
				e.Return = false;
				return;
			}
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblUserFin_colsDefault_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Validate:
					this.tblUserFin_colsDefault_OnSAM_Validate(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_Validate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblUserFin_colsDefault_OnSAM_Validate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(this.CheckDefaultNO())) 
			{
                tblUserFin_colsDefault.Text = "TRUE";
                e.Return = Sys.VALIDATE_Cancel;
				return;
			}
			e.Return = Sys.VALIDATE_Ok;
			return;
			#endregion
		}
		#endregion
			
		#region Late Bind Methods
		
        private void tblUserFin_DataRecordCheckRequiredEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblUserFin_DataRecordCheckRequired();
        }
	
        private void tblUserFin_DataRecordExecuteModifyEvent(object sender, cDataSource.DataRecordExecuteModifyEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblUserFin_DataRecordExecuteModify(e.hSql);
        }

        private void tblUserFin_DataRecordExecuteNewEvent(object sender, cDataSource.DataRecordExecuteNewEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblUserFin_DataRecordExecuteNew(e.hSql);
        }

        private void tblUserFin_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblUserFin_DataRecordGetDefaults();
        }

        private void tblUserFin_DataRecordRemoveEvent(object sender, cDataSource.DataRecordRemoveEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = tblUserFin_DataRecordRemove(e.nWhat);
        }

        #endregion

        #endregion
    }
}
