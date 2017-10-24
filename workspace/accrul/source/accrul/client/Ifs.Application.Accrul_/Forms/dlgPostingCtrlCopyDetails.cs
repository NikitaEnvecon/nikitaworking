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
	/// <param name="sCompany"></param>
	/// <param name="sPostingType"></param>
	/// <param name="sPostingTypeDesc"></param>
	/// <param name="sCodePart"></param>
	/// <param name="sCodeName"></param>
	/// <param name="sControlType"></param>
	/// <param name="sControlTypeDesc"></param>
	/// <param name="sModule"></param>
	/// <param name="dValidFrom"></param>
	public partial class dlgPostingCtrlCopyDetails : cDialogBoxFin
	{
		#region Window Parameters
		public SalString sCompany;
		public SalString sPostingType;
		public SalString sPostingTypeDesc;
		public SalString sCodePart;
		public SalString sCodeName;
		public SalString sControlType;
		public SalString sControlTypeDesc;
		public SalString sModule;
		public SalDateTime dValidFrom;
		#endregion
		
		#region Window Variables
		public SalString sReplace = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgPostingCtrlCopyDetails()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Shows the modal dialog.
		/// </summary>
		/// <param name="owner"></param>
		/// <returns></returns>
		public static SalNumber ModalDialog(Control owner, SalString sCompany, SalString sPostingType, SalString sPostingTypeDesc, SalString sCodePart, SalString sCodeName, SalString sControlType, SalString sControlTypeDesc, SalString sModule, SalDateTime dValidFrom)
		{
			dlgPostingCtrlCopyDetails dlg = DialogFactory.CreateInstance<dlgPostingCtrlCopyDetails>();
			dlg.sCompany = sCompany;
			dlg.sPostingType = sPostingType;
			dlg.sPostingTypeDesc = sPostingTypeDesc;
			dlg.sCodePart = sCodePart;
			dlg.sCodeName = sCodeName;
			dlg.sControlType = sControlType;
			dlg.sControlTypeDesc = sControlTypeDesc;
			dlg.sModule = sModule;
			dlg.dValidFrom = dValidFrom;
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgPostingCtrlCopyDetails FromHandle(SalWindowHandle handle)
		{
			return ((dlgPostingCtrlCopyDetails)SalWindow.FromHandle(handle, typeof(dlgPostingCtrlCopyDetails)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Actions
			using (new SalContext(this))
			{
				((cDialogBoxFin)this).FrameStartupUser();
				dfCompany.Text = sCompany;
				dfsPostingType.Text = sPostingType;
				dfsCodeName.Text = sCodeName;
				dfsControlType.Text = sControlType;
				dfdValidFrom.DateTime = dValidFrom;
				dfsModule.Text = sModule;
				Sal.SendMsg(tblPostingControlDetail, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				if (sPostingTypeDesc == SalString.Null) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Posting_Ctrl_Posting_Type_API.Get_Description", System.Data.ParameterDirection.Input);
						hints.Add("Posting_Ctrl_Control_Type_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN \r\n" +
							"	:i_hWndFrame.dlgPostingCtrlCopyDetails.dfsPostingTypeDesc := " + cSessionManager.c_sDbPrefix + "Posting_Ctrl_Posting_Type_API.Get_Description(\r\n" +
							"					:i_hWndFrame.dlgPostingCtrlCopyDetails.dfsPostingType);\r\n" +
							"	:i_hWndFrame.dlgPostingCtrlCopyDetails.dfsControlTypeDesc := " + cSessionManager.c_sDbPrefix + "Posting_Ctrl_Control_Type_API.Get_Description(\r\n" +
							"					:i_hWndFrame.dlgPostingCtrlCopyDetails.dfsControlType, \r\n" +
							"					:i_hWndFrame.dlgPostingCtrlCopyDetails.dfsModule);\r\nEND;");
					}
				}
				else
				{
					dfsPostingTypeDesc.Text = sPostingTypeDesc;
					dfsControlTypeDesc.Text = sControlTypeDesc;
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber Ok()
		{
			#region Local Variables
			SalBoolean bOk = false;
			SalNumber nRow = 0;
			SalNumber nPrevRow = 0;
			SalBoolean bContinue = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				bContinue = true;
				sReplace = "FALSE";
				nPrevRow = Sal.TblQueryContext(dlgPostingCtrlCopyDetails.FromHandle(i_hWndFrame).tblPostingControlDetail);
				nRow = Sys.TBL_MinRow;
				while (sReplace == "FALSE" && Sal.TblFindNextRow(dlgPostingCtrlCopyDetails.FromHandle(i_hWndFrame).tblPostingControlDetail, ref nRow, Sys.ROW_Edited, 0)) 
				{
					Sal.TblSetContext(dlgPostingCtrlCopyDetails.FromHandle(i_hWndFrame).tblPostingControlDetail, nRow);
					// Bug 87618 begin
					if (dlgPostingCtrlCopyDetails.FromHandle(i_hWndFrame).tblPostingControlDetail_colsIncludeCopy.Text == "TRUE") 
					{
							if (!(DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgPostingCtrlCopyDetails.sReplace := " + cSessionManager.c_sDbPrefix + "Posting_Ctrl_API.Check_Copy_Replace(\r\n" +
								                            ":i_hWndFrame.dlgPostingCtrlCopyDetails.dfCompany IN, \r\n" +
								                            ":i_hWndFrame.dlgPostingCtrlCopyDetails.dfsPostingType IN, \r\n" +
								                            ":i_hWndFrame.dlgPostingCtrlCopyDetails.sCodePart IN, 					\r\n" +
								                            ":i_hWndFrame.dlgPostingCtrlCopyDetails.tblPostingControlDetail_coldCopyValidFrom IN,\r\n" +
								                            ":i_hWndFrame.dlgPostingCtrlCopyDetails.tblPostingControlDetail_colsPostingType IN)"))) 
							{
								bContinue = false;
								break;
							}
					}
					// Bug 87618  end
				}
				if (sReplace == "TRUE") 
				{
					if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_PostCtrlReplace, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, (Ifs.Fnd.ApplicationForms.Const.WARNING_YesNo | Sys.MB_DefButton2)) == Sys.IDNO) 
					{
						bContinue = false;
					}
				}
				nRow = Sys.TBL_MinRow;
				DbTransactionBegin(ref cSessionManager.c_hSql);
				while (bContinue == true && Sal.TblFindNextRow(dlgPostingCtrlCopyDetails.FromHandle(i_hWndFrame).tblPostingControlDetail, ref nRow, Sys.ROW_Edited, 0)) 
				{
					Sal.TblSetContext(dlgPostingCtrlCopyDetails.FromHandle(i_hWndFrame).tblPostingControlDetail, nRow);
					if (dlgPostingCtrlCopyDetails.FromHandle(i_hWndFrame).tblPostingControlDetail_colsIncludeCopy.Text == "TRUE") 
					{
						// Bug 87618 begin
						if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Posting_Ctrl_API.Copy_Details_Set_Up(\r\n" +
								                                    ":i_hWndFrame.dlgPostingCtrlCopyDetails.dfCompany IN, \r\n" +
								                                    ":i_hWndFrame.dlgPostingCtrlCopyDetails.dfsPostingType IN, \r\n" +
								                                    ":i_hWndFrame.dlgPostingCtrlCopyDetails.sCodePart IN,\r\n" +
								                                    ":i_hWndFrame.dlgPostingCtrlCopyDetails.dfdValidFrom IN,\r\n" +
								                                    ":i_hWndFrame.dlgPostingCtrlCopyDetails.tblPostingControlDetail_colsPostingType IN,\r\n" +
								                                    ":i_hWndFrame.dlgPostingCtrlCopyDetails.sReplace IN,\r\n" +
								                                    ":i_hWndFrame.dlgPostingCtrlCopyDetails.tblPostingControlDetail_coldCopyValidFrom IN)"))) 
						{
							bContinue = false;
							break;
						}
						// Bug 87618  end
					}
				}
				DbTransactionEnd(cSessionManager.c_hSql);
				Sal.TblSetContext(dlgPostingCtrlCopyDetails.FromHandle(i_hWndFrame).tblPostingControlDetail, nPrevRow);
				if (bContinue == true) 
				{
					Sal.EndDialog(i_hWndSelf, Sys.IDOK);
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
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
				if (sMethod == "Ok") 
				{
					switch (nWhat)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return true;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							Ok();
							return true;
					}
				}
				else if (sMethod == "Cancel") 
				{
					switch (nWhat)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return true;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							Sal.EndDialog(i_hWndSelf, Sys.IDCANCEL);
							return true;
					}
				}
				else
				{
					Sal.GetItemName(Sys.hWndItem, ref sName);
					Ifs.Fnd.ApplicationForms.Int.ErrorBox("DESIGN TIME ERROR for item " + sName + "Function UserMethod handling method \"" + sMethod + "\" not written!");
					switch (nWhat)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							return false;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return false;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
							return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_AnyMethod;
					}
				}
			}

			return false;
			#endregion
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dlgPostingCtrlCopyDetails_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgPostingCtrlCopyDetails_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgPostingCtrlCopyDetails_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.i_sCompany = this.sCompany;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsPostingType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsModule_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfdValidFrom_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsPostingTypeDesc_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsCodeName_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsControlType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsControlTypeDesc_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void pbQuery_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					e.Handled = true;
					Sal.SendMsg(this.tblPostingControlDetail, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, (Ifs.Fnd.ApplicationForms.Const.POPULATE_UseQueryDialog | Ifs.Fnd.ApplicationForms.Const.POPULATE_NoConfirm));
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void pbPopulate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					e.Handled = true;
					Sal.SendMsg(this.tblPostingControlDetail, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_NoConfirm);
					break;
			}
			#endregion
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtFrameStartupUser()
		{
			return this.FrameStartupUser();
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
		{
			return this.UserMethod(nWhat, sMethod);
		}
		#endregion

        #region ChildTable-tblPostingControlDetail

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsPostingType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    e.Handled = true;
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("df");
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsIncludeCopy_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 87618 begin, added message action to fetch the value of dfdValid from to coldCopyValidFrom when colsIncludeCopy is checked

                case Sys.SAM_AnyEdit:
                    this.colsIncludeCopy_OnSAM_AnyEdit(sender, e);
                    break;

                case Sys.SAM_FieldEdit:
                    this.colsIncludeCopy_OnSAM_FieldEdit(sender, e);
                    break;

                // Bug 87618 Begin, end
            }
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsIncludeCopy_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblPostingControlDetail_colsIncludeCopy.Text == "TRUE")
            {
                this.tblPostingControlDetail_coldCopyValidFrom.DateTime = dlgPostingCtrlCopyDetails.FromHandle(this.tblPostingControlDetail_colsIncludeCopy.i_hWndFrame).dfdValidFrom.DateTime;
            }
            else
            {
                this.tblPostingControlDetail_coldCopyValidFrom.DateTime = Sys.DATETIME_Null;
            }
            #endregion
        }

        /// <summary>
        /// SAM_FieldEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsIncludeCopy_OnSAM_FieldEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblPostingControlDetail_colsIncludeCopy.Text == "TRUE")
            {
                this.tblPostingControlDetail_coldCopyValidFrom.DateTime = dlgPostingCtrlCopyDetails.FromHandle(this.tblPostingControlDetail_colsIncludeCopy.i_hWndFrame).dfdValidFrom.DateTime;
            }
            else
            {
                this.tblPostingControlDetail_coldCopyValidFrom.DateTime = Sys.DATETIME_Null;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void coldCopyValidFrom_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.coldCopyValidFrom_OnSAM_Create(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void coldCopyValidFrom_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            this.tblPostingControlDetail_coldCopyValidFrom.DateTime = Sys.DATETIME_Null;
            #endregion
        }
        #endregion

        #endregion
        
	}
}
