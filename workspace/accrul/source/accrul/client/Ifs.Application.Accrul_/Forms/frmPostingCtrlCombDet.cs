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
// Date    By      Notes
// ------  ------  -------------------------------------------------------------------------------------
// 072613  Clstlk  Bug 111394, Modified tblPostCtrlCombDet_colsControlType1Value_OnPM_DataItemValidate by adding GetControlType1Attribs(),
//                  modified PM_DataRecordDuplicate and added PM_DataRecordPaste.                
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
using System.Collections.Generic;

namespace Ifs.Application.Accrul_
{
	
	/// <summary>
	/// </summary>
	public partial class frmPostingCtrlCombDet : cFormWindowFin
	{
		#region Window Variables
		public SalString lsType1desc = "";
		public SalString lsType2desc = "";
		public SalString lsType1Valuedesc = "";
		public SalString lsType2Valuedesc = "";
		public SalString lsControlType1 = "";
		public SalString lsControlType2 = "";
		public SalString lsModule1 = "";
		public SalString lsModule2 = "";
		public SalString sCodePartValueDesc = "";
		public SalArray<SalString> sItemNames = new SalArray<SalString>();
		public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
		public SalDateTime dPCStartDate = SalDateTime.Null;
		public SalDateTime dPCEndDate = SalDateTime.Null;
		public SalDateTime dStartDate = SalDateTime.Null;
		public SalDateTime dEndDate = SalDateTime.Null;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmPostingCtrlCombDet()
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
		public new static frmPostingCtrlCombDet FromHandle(SalWindowHandle handle)
		{
			return ((frmPostingCtrlCombDet)SalWindow.FromHandle(handle, typeof(frmPostingCtrlCombDet)));
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
				return Properties.Resources.WH_frmPostingCtrlCombDet;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="bPopulateSingle"></param>
		/// <returns></returns>
		public SalBoolean DataSourcePopulateIt(SalBoolean bPopulateSingle)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (((cDataSource)this).DataSourcePopulateIt(bPopulateSingle)) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Comb_Control_Type_API.Get_Comb_Type_Info", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						if (!(DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Comb_Control_Type_API.Get_Comb_Type_Info(\r\n" +
							" :i_hWndFrame.frmPostingCtrlCombDet.lsControlType1,\r\n" +
							" :i_hWndFrame.frmPostingCtrlCombDet.lsControlType2,\r\n" +
							" :i_hWndFrame.frmPostingCtrlCombDet.lsType1desc,\r\n" +
							" :i_hWndFrame.frmPostingCtrlCombDet.lsType2desc,\r\n" +
							" :i_hWndFrame.frmPostingCtrlCombDet.lsModule1, \r\n" +
							" :i_hWndFrame.frmPostingCtrlCombDet.lsModule2,\r\n" +
							" :i_hWndFrame.frmPostingCtrlCombDet.dfsCompany,\r\n" +
							" :i_hWndFrame.frmPostingCtrlCombDet.ccPostingType.i_sMyValue,\r\n" +
							" :i_hWndFrame.frmPostingCtrlCombDet.dfsControlType )"))) 
						{
							return false;
						}
					}
					lsType1Valuedesc = lsType1desc;
					lsType2Valuedesc = lsType2desc;
					Sal.TblSetColumnTitle(tblPostCtrlCombDet_colsControlType1, lsType1desc);
					Sal.TblSetColumnTitle(tblPostCtrlCombDet_colsControlType2, lsType2desc);
					Sal.TblSetColumnTitle(tblPostCtrlCombDet_colsControlType1Value, lsType1Valuedesc);
					Sal.TblSetColumnTitle(tblPostCtrlCombDet_colsControlType2Value, lsType2Valuedesc);
					lsType1Valuedesc = lsType1desc + " " + Properties.Resources.TEXT_HeadDescription;
					lsType2Valuedesc = lsType2desc + " " + Properties.Resources.TEXT_HeadDescription;
					Sal.TblSetColumnTitle(tblPostCtrlCombDet_colsControlType1Description, lsType1Valuedesc);
					Sal.TblSetColumnTitle(tblPostCtrlCombDet_colsControlType2Description, lsType2Valuedesc);
					// Assign codepart name to the title..
					Sal.TblSetColumnTitle(tblPostCtrlCombDet_colsCodePartValue, dfsCodeName.Text);
					this.sControlTypetbl = lsControlType1;
					this.sModuletbl = lsModule1;
					if (lsControlType1 != SalString.Null) 
					{
						this.GetControlTypeAttribs();
					}
					this.sView1 = this.sView;
                    this.SetZoomViewKeys("tblPostCtrlCombDet_colsControlType1Value");
					this.sPkgName1 = this.sPkgName;
					return true;
				}
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// Called from Posting Control Navigator
		/// </summary>
		/// <param name="sWhere"></param>
		/// <param name="dValidFrom"></param>
		/// <param name="dPCValidFrom"></param>
		/// <returns></returns>
		public virtual SalNumber SetWhere(SalString sWhere, SalDateTime dValidFrom, SalDateTime dPCValidFrom)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (dValidFrom != SalDateTime.Null) 
				{
					Int.PalDateGetDayInterval(dValidFrom, ref dStartDate, ref dEndDate);
					sWhere = sWhere + " AND (VALID_FROM between :i_hWndFrame.frmPostingCtrlCombDet.dStartDate AND :i_hWndFrame.frmPostingCtrlCombDet.dEndDate) ";
				}
				if (dPCValidFrom != SalDateTime.Null) 
				{
					Int.PalDateGetDayInterval(dPCValidFrom, ref dPCStartDate, ref dPCEndDate);
					sWhere = sWhere + " AND (PC_VALID_FROM between :i_hWndFrame.frmPostingCtrlCombDet.dPCStartDate AND :i_hWndFrame.frmPostingCtrlCombDet.dPCEndDate) ";
				}
				p_lsDefaultWhere = sWhere;
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
		private void ccPostingType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserOrderBy:
					e.Handled = true;
					e.Return = ((SalString)"MODULE,SORT_ORDER").ToHandle();
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsDefaultValue_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
					this.dfsDefaultValue_OnPM_DataItemZoom(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemZoom event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsDefaultValue_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				if (this.dfsCodePart.Text == "A") 
				{
					this.sItemNames[0] = "COMPANY";
					this.hWndItems[0] = this.dfsCompany;
					this.sItemNames[1] = "ACCOUNT";
					this.hWndItems[1] = this.dfsDefaultValue;
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Account", this, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwAccountOverview"));
					e.Return = true;
					return;
				}
				else
				{
					Ifs.Fnd.ApplicationForms.Var.bReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
					Sal.WaitCursor(false);
					e.Return = Ifs.Fnd.ApplicationForms.Var.bReturn;
					return;
				}
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
		private void tblPostCtrlCombDet_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.tblPostCtrlCombDet_OnPM_DataRecordNew(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
					this.tblPostCtrlCombDet_OnPM_DataRecordDuplicate(sender, e);
					break;
				
				case Sys.SAM_FetchRowDone:
					this.tblPostCtrlCombDet_OnSAM_FetchRowDone(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans:
					this.tblPostCtrlCombDet_OnPM_DataSourceCreateWindowTrans(sender, e);
					break;
                // Bug 111394, Begin
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    this.tblPostCtrlCombDet_OnPM_DataRecordPaste(sender, e);                    
                    break;
                // Bug 111394, End
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlCombDet_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam)) 
			{
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					this.tblPostCtrlCombDet_colsCodePartName.Text = this.dfsCodeName.Text;
					this.tblPostCtrlCombDet_colsCodePartName.EditDataItemSetEdited();
					this.tblPostCtrlCombDet_colsControlType1.Text = this.lsControlType1;
					this.tblPostCtrlCombDet_colsControlType1.EditDataItemSetEdited();
					this.tblPostCtrlCombDet_colsControlType2.Text = this.lsControlType2;
					this.tblPostCtrlCombDet_colsControlType2.EditDataItemSetEdited();
					this.tblPostCtrlCombDet_colsModule1.Text = this.lsModule1;
					this.tblPostCtrlCombDet_colsModule1.EditDataItemSetEdited();
					this.tblPostCtrlCombDet_colsModule2.Text = this.lsModule2;
					this.tblPostCtrlCombDet_colsModule2.EditDataItemSetEdited();
					this.tblPostCtrlCombDet_colsCombControlType.Text = this.dfsControlType.Text;
					this.tblPostCtrlCombDet_colsCombControlType.EditDataItemSetEdited();
					if (!(Sal.IsNull(this.tblPostCtrlCombDet_colsCodePartName))) 
					{
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("ACCOUNTING_CODE_PARTS_API.Get_Code_Part", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							if (!(this.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "ACCOUNTING_CODE_PARTS_API.Get_Code_Part(" + " :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsCodePart," + " :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsCompany," + 
								" :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsCodePartName) "))) 
							{
								e.Return = false;
								return;
							}
						}
						this.tblPostCtrlCombDet_colsCodePart.EditDataItemSetEdited();
					}
					this.sControlTypetbl = this.tblPostCtrlCombDet_colsControlType1.Text;
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
		/// PM_DataRecordDuplicate event handler.
		/// </summary>
		/// <param name="message"></param>
        private void tblPostCtrlCombDet_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    // Bug 111394, Begin Added while loop to duplicate multiple lines
                    this.nOldRow = Sal.TblQueryContext(tblPostCtrlCombDet);
                    this.nRow = Sys.TBL_MinRow;
                    while (Sal.TblFindNextRow(tblPostCtrlCombDet, ref this.nRow, (Sys.ROW_Edited | Sys.ROW_New), 0))
                    {
                        Sal.TblSetContext(tblPostCtrlCombDet, this.nRow);
                        this.tblPostCtrlCombDet_colsCodePartName.Text = this.dfsCodeName.Text;
                        this.tblPostCtrlCombDet_colsCodePartName.EditDataItemSetEdited();
                        this.tblPostCtrlCombDet_colsControlType1.Text = this.lsControlType1;
                        this.tblPostCtrlCombDet_colsControlType1.EditDataItemSetEdited();
                        this.tblPostCtrlCombDet_colsControlType2.Text = this.lsControlType2;
                        this.tblPostCtrlCombDet_colsControlType2.EditDataItemSetEdited();
                        this.tblPostCtrlCombDet_colsModule1.Text = this.lsModule1;
                        this.tblPostCtrlCombDet_colsModule1.EditDataItemSetEdited();
                        this.tblPostCtrlCombDet_colsModule2.Text = this.lsModule2;
                        this.tblPostCtrlCombDet_colsModule2.EditDataItemSetEdited();
                        this.tblPostCtrlCombDet_colsCombControlType.Text = this.dfsControlType.Text;
                        this.tblPostCtrlCombDet_colsCombControlType.EditDataItemSetEdited();
                        if (!(Sal.IsNull(this.tblPostCtrlCombDet_colsCodePartName)))
                        {
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("ACCOUNTING_CODE_PARTS_API.Get_Code_Part", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                if (!(this.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "ACCOUNTING_CODE_PARTS_API.Get_Code_Part(" + " :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsCodePart," + " :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsCompany," +
                                    " :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsCodePartName) ")))
                                {
                                    e.Return = false;
                                    return;
                                }
                            }
                            this.tblPostCtrlCombDet_colsCodePart.EditDataItemSetEdited();
                        }
                        this.sControlTypetbl = this.tblPostCtrlCombDet_colsControlType1.Text;
                        this.sModuletbl = this.tblPostCtrlCombDet_colsModule1.Text;
                        if (this.sControlTypetbl != SalString.Null)
                        {
                            this.GetControlTypeAttribs();
                        }
                        this.sView1 = this.sView;
                        this.SetZoomViewKeys("tblPostCtrlCombDet_colsControlType1Value");
                        this.sPkgName1 = this.sPkgName;
                        // Bug 111394, Begin
                        this.GetControlTypeValue1Desc();
                        this.sControlTypetbl = this.tblPostCtrlCombDet_colsControlType2.Text;
                        this.sModuletbl = this.tblPostCtrlCombDet_colsModule2.Text;
                        if (this.sControlTypetbl != SalString.Null)
                        {
                            this.GetControlTypeAttribs();
                        }
                        this.sView2 = this.sView;
                        this.sPkgName2 = this.sPkgName;
                        this.GetControlTypeValue2Desc();
                        if (this.tblPostCtrlCombDet_colsCodePartValue.Text != SalString.Null)
                        {
                            Sal.SendMsg(frmPostingCtrlCombDet.FromHandle(i_hWndFrame).tblPostCtrlCombDet_colsCodePartValue, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                        }
                        //Bug 111394, End 
                        Sal.WaitCursor(true);
                        this.tblPostCtrlCombDet_colsControlType1Value.p_sLovReference = this.sView1;
                        Sal.WaitCursor(false);
                    }
                    Sal.TblSetContext(tblPostCtrlCombDet, this.nOldRow);
                    //Bug 111394, End
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

        // Bug 111394, Begin Added PM_DataRecordPaste
        /// <summary>
        /// PM_DataRecordPaste event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblPostCtrlCombDet_OnPM_DataRecordPaste(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                   this.nOldRow = Sal.TblQueryContext(tblPostCtrlCombDet);
                   this.nRow = Sys.TBL_MinRow;
                   while (Sal.TblFindNextRow(tblPostCtrlCombDet, ref this.nRow, (Sys.ROW_Edited | Sys.ROW_New), 0))
                    {
                        Sal.TblSetContext(tblPostCtrlCombDet, this.nRow);
                        this.tblPostCtrlCombDet_colsCodePartName.Text = this.dfsCodeName.Text;
                        this.tblPostCtrlCombDet_colsCodePartName.EditDataItemSetEdited();
                        this.tblPostCtrlCombDet_colsControlType1.Text = this.lsControlType1;
                        this.tblPostCtrlCombDet_colsControlType1.EditDataItemSetEdited();
                        this.tblPostCtrlCombDet_colsControlType2.Text = this.lsControlType2;
                        this.tblPostCtrlCombDet_colsControlType2.EditDataItemSetEdited();
                        this.tblPostCtrlCombDet_colsModule1.Text = this.lsModule1;
                        this.tblPostCtrlCombDet_colsModule1.EditDataItemSetEdited();
                        this.tblPostCtrlCombDet_colsModule2.Text = this.lsModule2;
                        this.tblPostCtrlCombDet_colsModule2.EditDataItemSetEdited();
                        this.tblPostCtrlCombDet_colsCombControlType.Text = this.dfsControlType.Text;
                        this.tblPostCtrlCombDet_colsCombControlType.EditDataItemSetEdited();
                        if (!(Sal.IsNull(this.tblPostCtrlCombDet_colsCodePartName)))
                        {
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("ACCOUNTING_CODE_PARTS_API.Get_Code_Part", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                if (!(this.DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "ACCOUNTING_CODE_PARTS_API.Get_Code_Part(" + " :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsCodePart," + " :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsCompany," +
                                    " :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsCodePartName) ")))
                                {
                                    e.Return = false;
                                    return;
                                }
                            }
                            this.tblPostCtrlCombDet_colsCodePart.EditDataItemSetEdited();
                        }
                        this.sControlTypetbl = this.tblPostCtrlCombDet_colsControlType1.Text;
                        this.sModuletbl = this.tblPostCtrlCombDet_colsModule1.Text;
                        if (this.sControlTypetbl != SalString.Null)
                        {
                            this.GetControlTypeAttribs();
                        }
                        this.sView1 = this.sView;
                        this.SetZoomViewKeys("tblPostCtrlCombDet_colsControlType1Value");
                        this.sPkgName1 = this.sPkgName;
                        this.GetControlTypeValue1Desc();
                        this.sControlTypetbl = this.tblPostCtrlCombDet_colsControlType2.Text;
                        this.sModuletbl = this.tblPostCtrlCombDet_colsModule2.Text;
                        if (this.sControlTypetbl != SalString.Null)
                        {
                            this.GetControlTypeAttribs();
                        }
                        this.sView2 = this.sView;
                        this.sPkgName2 = this.sPkgName;
                        this.GetControlTypeValue2Desc();
                        if (this.tblPostCtrlCombDet_colsCodePartValue.Text != SalString.Null)
                        {
                            Sal.SendMsg(frmPostingCtrlCombDet.FromHandle(i_hWndFrame).tblPostCtrlCombDet_colsCodePartValue, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                        }
                        Sal.WaitCursor(true);
                        this.tblPostCtrlCombDet_colsControlType1Value.p_sLovReference = this.sView1;
                        Sal.WaitCursor(false);
                    }
                   Sal.TblSetContext(tblPostCtrlCombDet, this.nOldRow);
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
        //Bug 111394, End
		
		/// <summary>
		/// SAM_FetchRowDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlCombDet_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.WaitCursor(true);
			if (this.tblPostCtrlCombDet_colsControlType1.Text == "IC7") 
			{
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Income_Type_API.Get_Income_Type_Id")) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Income_Type_API.Get_Income_Type_Id", System.Data.ParameterDirection.Input);
						if (!(this.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN \r\n" +
							"			    :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsControlType1Value := &AO.Income_Type_API.Get_Income_Type_Id(\r\n" +
							"			    :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsControlType1Value); \r\n" +
							"			   END;"))) 
						{
							e.Return = false;
							return;
						}
					}
				}
			}
			else if (this.tblPostCtrlCombDet_colsControlType1.Text == "IC8") 
			{
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Type1099_API.Get_Irs1099_Type_Id")) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Type1099_API.Get_Irs1099_Type_Id", System.Data.ParameterDirection.Input);
						if (!(this.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN \r\n" +
							"			    :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsControlType1Value := &AO.Type1099_API.Get_Irs1099_Type_Id(\r\n" +
							"			    :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsControlType1Value); \r\n" +
							"			   END;"))) 
						{
							e.Return = false;
							return;
						}
					}
				}
			}
			if (this.tblPostCtrlCombDet_colsControlType2.Text == "IC7") 
			{
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Income_Type_API.Get_Income_Type_Id")) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Income_Type_API.Get_Income_Type_Id", System.Data.ParameterDirection.Input);
						if (!(this.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN \r\n" +
							"			    :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsControlType2Value := &AO.Income_Type_API.Get_Income_Type_Id(\r\n" +
							"			    :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsControlType2Value); \r\n" +
							"			   END;"))) 
						{
							e.Return = false;
							return;
						}
					}
				}
			}
			else if (this.tblPostCtrlCombDet_colsControlType2.Text == "IC8") 
			{
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Type1099_API.Get_Irs1099_Type_Id")) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Type1099_API.Get_Irs1099_Type_Id", System.Data.ParameterDirection.Input);
						if (!(this.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN \r\n" +
							"			    :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsControlType2Value := &AO.Type1099_API.Get_Irs1099_Type_Id(\r\n" +
							"			    :i_hWndFrame.frmPostingCtrlCombDet.tblPostCtrlCombDet_colsControlType2Value); \r\n" +
							"			   END;"))) 
						{
							e.Return = false;
							return;
						}
					}
				}
			}
			if (!(this.GetControlType1Attribs())) 
			{
				e.Return = false;
				return;
			}
			this.GetControlTypeValue1Desc();
			if (!(this.GetControlType2Attribs())) 
			{
				e.Return = false;
				return;
			}
			this.GetControlTypeValue2Desc();
			Sal.WaitCursor(false);
			Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourceCreateWindowTrans event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlCombDet_OnPM_DataSourceCreateWindowTrans(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
                if (this.sItemName1 == "tblPostCtrlCombDet_colsCodePartValue") 
				{
					e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans, Sys.wParam, Sys.lParam);
					return;
				}
				this.lsMessage = SalString.FromHandle(Sys.lParam);
				if (this.sCurrentZoomCol == "colsControlType1Value") 
				{
					this.sDummy1 = this.sView1Keys;
					this.sDummy2 = this.sView1LovCols;
					this.sSqlCol = this.tblPostCtrlCombDet_colsControlType1Value.p_sSqlColumn;
				}
				else if (this.sCurrentZoomCol == "colsControlType2Value") 
				{
					this.sDummy1 = this.sView2Keys;
					this.sDummy2 = this.sView2LovCols;
					this.sSqlCol = this.tblPostCtrlCombDet_colsControlType2Value.p_sSqlColumn;
				}
				if (!(this.sDummy1 == SalString.Null)) 
				{
					this.nTemp =this.sDummy1.Tokenize("", ",",this.sKeyCols);
					this.nTemp =this.sDummy2.Tokenize("", ",",this.sLovCols);
					this.nTemp = 0;
					this.nTemp1 = 0;
					// To find the Key column of the view
					while (true) // Outer
					{
						if (this.sKeyCols[this.nTemp] != SalString.Null) 
						{
							while (true)
							{
								if (this.sLovCols[this.nTemp1] != SalString.Null) 
								{
									if (this.sKeyCols[this.nTemp] ==this.sLovCols[this.nTemp1]) 
									{
										goto ExitOuter;
									}
									else
									{
										this.nTemp1 =this.nTemp1 + 1;
									}
								}
								else
								{
									break;
								}
							}
						}
						else
						{
							break;
						}
						this.nTemp = this.nTemp + 1;
						this.nTemp1 = 0;
					} ExitOuter:;
					this.MessageKeys.Unpack(this.lsMessage);
					this.nIndex = Vis.ArrayFindString(this.MessageKeys.m_sNames, this.sSqlCol);
					// Replace the relevant control type with the Key column of the view, in MessageKeys
                    if (this.nIndex != -1)
                    {
                        this.MessageKeys.m_sNames[this.nIndex] = this.sKeyCols[this.nTemp];
                        this.MessageKeys.m_sValues[this.nIndex] = this.sKeyCols[this.nTemp];
                    }
                    this.nIndex = Vis.ArrayFindString(this.tblPostCtrlCombDet.__sColumnName, this.sSqlCol);
                    this.tblPostCtrlCombDet.__sColumnName[this.nIndex] = this.sKeyCols[this.nTemp];
					this.bReturn1 = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans, Sys.wParam, this.MessageKeys.Pack().ToHandle());
                    this.tblPostCtrlCombDet.__sColumnName[this.nIndex] = this.sSqlCol;
				}
				else
				{
					e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans, Sys.wParam, Sys.lParam);
					return;
				}
			}
			else
			{
				e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans, Sys.wParam, Sys.lParam);
				return;
			}
			#endregion
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtDataSourcePopulateIt(SalNumber nParam)
		{
			return this.DataSourcePopulateIt(nParam);
		}
        // Insert new code here...
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalString vrtGetWindowTitle()
		{
			return this.GetWindowTitle();
		}
		#endregion
		
		#region ChildTable-tblPostCtrlCombDet
			
		#region Window Variables
		public SalString sControlType1 = "";
		public SalString sControlType2 = "";
		public SalString sDescription = "";
		public SalString sCtrlTypeCategory = "";
		public SalString sView = "";
		public SalString sView1 = "";
		public SalString sView2 = "";
		public SalString sPkgName = "";
		public SalString sPkgName1 = "";
		public SalString sPkgName2 = "";
		public SalString sControlTypetbl = "";
		public SalString sControlTypeValuetbl = "";
		public SalString sViewtbl = "";
		public SalString sPkgNametbl = "";
		public SalString sModuletbl = "";
		public SalString sControlTypeValueDesc = "";
		public SalString sSql = "";
		public SalString sBaseCurrCode = "";
		public SalString sCountryDb = "";
		public SalString sItemName1 = "";
		public SalString sFormName = "";
		public cMessage MessageKeys = new cMessage();
		public SalString lsMessage = "";
		public SalBoolean bReturn1 = false;
		public SalNumber nIndex = 0;
		public SalNumber nTemp = 0;
		public SalNumber nTemp1 = 0;
		public SalArray<SalString> sKeyCols = new SalArray<SalString>();
		public SalArray<SalString> sLovCols = new SalArray<SalString>();
		public SalString sKeyColumn = "";
		public SalString sCurrentZoomCol = "";
		public SalString sDummy1 = "";
		public SalString sDummy2 = "";
		public SalString sView1Keys = "";
		public SalString sView1LovCols = "";
		public SalString sView2Keys = "";
		public SalString sView2LovCols = "";
		public SalString sSqlCol = "";
        // Bug 111394, Begin 
        public SalNumber nOldRow = 0;
        public SalNumber nRow = 0;
        // Bug 111394, End 
		#endregion
						
		#region Methods
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean GetControlTypeAttribs()
		{
            string stmt = string.Format(@"&AO.Posting_Ctrl_Control_Type_API.Get_Control_Type_Attri_({0} OUT,{1} OUT, {2} OUT, {3} OUT,{4} IN,{5} IN)",
                                            this.QualifiedVarBindName("sDescription"),
                                            this.QualifiedVarBindName("sCtrlTypeCategory"),
                                            this.QualifiedVarBindName("sView"),
                                            this.QualifiedVarBindName("sPkgName"),
                                            this.QualifiedVarBindName("sControlTypetbl"),
                                            this.QualifiedVarBindName("sModuletbl"));
					
		    return (DbPLSQLBlock(stmt)); 
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
        public virtual SalBoolean GetControlType1Attribs()
        {
            sControlTypetbl = tblPostCtrlCombDet_colsControlType1.Text;
            sModuletbl = tblPostCtrlCombDet_colsModule1.Text;
            return GetControlTypeAttribs();
        }
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean GetControlType2Attribs()
		{
            sControlTypetbl = tblPostCtrlCombDet_colsControlType2.Text;
			sModuletbl = tblPostCtrlCombDet_colsModule2.Text;
			return GetControlTypeAttribs();
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetControlTypeDesc()
		{
            IDictionary<string,string> namedBindVariables = new Dictionary<string,string>();
            namedBindVariables.Add("sControlTypeValueDesc",this.QualifiedVarBindName("sControlTypeValueDesc"));
            namedBindVariables.Add("i_sCompany",this.QualifiedVarBindName("i_sCompany"));
            namedBindVariables.Add("sControlTypetbl",this.QualifiedVarBindName("sControlTypetbl"));
            namedBindVariables.Add("sControlTypeValuetbl",this.QualifiedVarBindName("sControlTypeValuetbl"));
            namedBindVariables.Add("sViewtbl",this.QualifiedVarBindName("sViewtbl"));
            namedBindVariables.Add("sPkgNametbl",this.QualifiedVarBindName("sPkgNametbl"));
            namedBindVariables.Add("sModuletbl",this.QualifiedVarBindName("sModuletbl"));
					
			DbPLSQLBlock(@"{sControlTypeValueDesc} :=  &AO.Posting_Ctrl_Control_Type_API.Get_Control_Type_Desc_(
						                                                                    {i_sCompany} IN,
						                                                                    {sControlTypetbl} IN,
						                                                                    {sControlTypeValuetbl} IN,
						                                                                    {sViewtbl} IN,
						                                                                    {sPkgNametbl} IN,
						                                                                    {sModuletbl} IN)",namedBindVariables);
			return 0;
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetControlTypeValue1Desc()
		{
            sControlTypetbl = tblPostCtrlCombDet_colsControlType1.Text;
            sControlTypeValuetbl = tblPostCtrlCombDet_colsControlType1Value.Text;
		    sViewtbl = sView;
		    sPkgNametbl = sPkgName;
		    sModuletbl = tblPostCtrlCombDet_colsModule1.Text;
		    GetControlTypeDesc();
            tblPostCtrlCombDet_colsControlType1Description.Text = sControlTypeValueDesc;
			return 0;
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetControlTypeValue2Desc()
		{
            sControlTypetbl = tblPostCtrlCombDet_colsControlType2.Text;
            sControlTypeValuetbl = tblPostCtrlCombDet_colsControlType2Value.Text;
		    sViewtbl = sView;
		    sPkgNametbl = sPkgName;
		    sModuletbl = tblPostCtrlCombDet_colsModule2.Text;
		    GetControlTypeDesc();
            tblPostCtrlCombDet_colsControlType2Description.Text = sControlTypeValueDesc;
			return 0;
		}
			
		/// <summary>
		/// </summary>
		/// <param name="lsServerAttr"></param>
		/// <param name="bMarkAsEdited"></param>
		/// <returns></returns>
		public virtual SalNumber DataRecordToFormUser(ref SalString lsServerAttr, ref SalBoolean bMarkAsEdited)
		{
            tblPostCtrlCombDet_colsCodePartName.Text = this.dfsCodeName.Text;
            tblPostCtrlCombDet_colsCodePartName.EditDataItemSetEdited();
            tblPostCtrlCombDet_colsControlType1.Text = this.lsControlType1;
            tblPostCtrlCombDet_colsControlType1.EditDataItemSetEdited();
            tblPostCtrlCombDet_colsControlType2.Text = this.lsControlType2;
            tblPostCtrlCombDet_colsControlType2.EditDataItemSetEdited();
		    tblPostCtrlCombDet_colsModule1.Text = this.lsModule1;
            tblPostCtrlCombDet_colsModule1.EditDataItemSetEdited();
		    tblPostCtrlCombDet_colsModule2.Text = this.lsModule2;
            tblPostCtrlCombDet_colsModule2.EditDataItemSetEdited();
            tblPostCtrlCombDet_colsCombControlType.Text = this.dfsControlType.Text;
            tblPostCtrlCombDet_colsCombControlType.EditDataItemSetEdited();
            if (!(Sal.IsNull(tblPostCtrlCombDet_colsCodePartName))) 
		    {
			    if (!(DbPLSQLBlock(@"ACCOUNTING_CODE_PARTS_API.Get_Code_Part({0} OUT,{1} IN,{2} IN)",
                                                                            this.tblPostCtrlCombDet_colsCodePart.QualifiedBindName,
                                                                            this.tblPostCtrlCombDet_colsCompany.QualifiedBindName,
                                                                            this.tblPostCtrlCombDet_colsCodePart.QualifiedBindName )))
			    {
				    return false;
			    }
                tblPostCtrlCombDet_colsCodePart.EditDataItemSetEdited();
		    }
            sControlTypetbl = tblPostCtrlCombDet_colsControlType1.Text;
			return 0;
		}
			
		/// <summary>
		/// </summary>
		/// <param name="hItem"></param>
		/// <returns></returns>
		public virtual SalString GetItemName(SalWindowHandle hItem)
		{
			SalString sItem = "";
            Sal.GetItemName(hItem, ref sItem);
			return sItem;
		}
			
		/// <summary>
		/// The framework calls the DataRecordGetDefaults function to retrive
		/// client default values for new records.
		/// </summary>
		/// <returns>The return value is TRUE if default values were sucessfully retrived, FALSE otherwise.</returns>
		public virtual SalBoolean DataRecordGetDefaults()
		{
            tblPostCtrlCombDet_coldValidFrom.DateTime = this.dfPcValidFrom.DateTime;
            tblPostCtrlCombDet_coldValidFrom.EditDataItemSetEdited();
		    return true;
		}
			
		/// <summary>
		/// </summary>
		/// <param name="sColName"></param>
		/// <returns></returns>
		public virtual SalNumber SetZoomViewKeys(SalString sColName)
		{
            string stmt = @"DECLARE
	                            view_			VARCHAR2(200); 
	                            no_param_view_	VARCHAR2(200); 
	                            temp_num_		NUMBER := 0; 
                            BEGIN 
	                            view_ := {0}; 
	                            temp_num_ := INSTR(view_, '('); 
	                            IF temp_num_ > 0 THEN 
		                            no_param_view_ := substr(view_,1,temp_num_ - 1); 
	                            ELSE 
		                            no_param_view_ := view_; 
	                            END IF; 
	                            &AO.Reference_SYS.Get_Lov_Properties( no_param_view_, {1} OUT, {2} OUT, {3} OUT, {4} OUT );
                            END;";

            if (sColName == "tblPostCtrlCombDet_colsControlType1Value") 
			{
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Reference_SYS.Get_Lov_Properties")) 
				{
                    DbPLSQLBlock(stmt, this.QualifiedVarBindName("sView"),
                                       this.QualifiedVarBindName("sView1Keys"),
                                       this.QualifiedVarBindName("sView1LovCols"),
                                       this.QualifiedVarBindName("sDummy1"),
                                       this.QualifiedVarBindName("sDummy2"));	
				}
			}
            else if (sColName == "tblPostCtrlCombDet_colsControlType2Value") 
			{
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Reference_SYS.Get_Lov_Properties")) 
				{
					DbPLSQLBlock(stmt, this.QualifiedVarBindName("sView"),
                                       this.QualifiedVarBindName("sView2Keys"),
                                       this.QualifiedVarBindName("sView2LovCols"),
                                       this.QualifiedVarBindName("sDummy1"),
                                       this.QualifiedVarBindName("sDummy2"));
				}
			}
			return 0;
		}
		#endregion
			
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblPostCtrlCombDet_colsControlType1Value_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblPostCtrlCombDet_colsControlType1Value_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblPostCtrlCombDet_colsControlType1Value_OnPM_DataItemValidate(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
					this.tblPostCtrlCombDet_colsControlType1Value_OnPM_DataItemLovUserWhere(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
					this.tblPostCtrlCombDet_colsControlType1Value_OnPM_DataItemZoom(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlCombDet_colsControlType1Value_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            this.tblPostCtrlCombDet_colsControlType1Value.p_sLovReference = this.sView1;
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlCombDet_colsControlType1Value_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            this.GetControlType1Attribs();
			this.GetControlTypeValue1Desc();
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemLovUserWhere event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlCombDet_colsControlType1Value_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.sView == "INCOME_TYPE_LOV(COUNTRY_CODE, CURRENCY_CODE)") 
			{
					
                DbPLSQLBlock(@"&AO.Company_Finance_API.Get_Accounting_Currency({0} INOUT,[2} IN );
                               {1} := &AO.Company_API.Get_Country_Db({2} IN ); ",
                               this.QualifiedVarBindName("sBaseCurrCode"),
                               this.QualifiedVarBindName("sCountryDb"),
                               this.tblPostCtrlCombDet_colsCompany.QualifiedBindName);

				e.Return = ("COUNTRY_CODE='" + this.sCountryDb + "' and CURRENCY_CODE='" + this.sBaseCurrCode + "'").ToHandle();
				return;
			}
			if (this.sView == "TYPE1099_LOV(COUNTRY_CODE)") 
			{
                DbPLSQLBlock( "{0} := &AO.Company_API.Get_Country_Db({1} IN );",
                                        this.QualifiedVarBindName("sCountryDb"),
                                        this.tblPostCtrlCombDet_colsCompany.QualifiedBindName);
	
				e.Return = ("COUNTRY_CODE='" + this.sCountryDb + "'").ToHandle();
				return;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemZoom event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlCombDet_colsControlType1Value_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				this.sCurrentZoomCol = "colsControlType1Value";
				// Bug 76695, Begin
				if (this.tblPostCtrlCombDet_colsControlType1.Text == "C43") 
				{
					this.sItemNames[0] = "REQUISITIONER_CODE";
                    this.hWndItems[0] = this.tblPostCtrlCombDet_colsControlType1Value;
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("PurchaseRequisitioner", this, this.sItemNames, this.hWndItems);
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sDestination = "PURCHASE_REQUISITIONER";
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("ZOOM");
                    SessionNavigate(Pal.GetActiveInstanceName("frmPurBasic"));
				}
				else
				{
					e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
					return;
				}
				e.Return = true;
				return;
				// Bug 76695, End
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
		private void tblPostCtrlCombDet_colsControlType2Value_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblPostCtrlCombDet_colsControlType2Value_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblPostCtrlCombDet_colsControlType2Value_OnPM_DataItemValidate(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
					this.tblPostCtrlCombDet_colsControlType2Value_OnPM_DataItemLovUserWhere(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
					this.tblPostCtrlCombDet_colsControlType2Value_OnPM_DataItemZoom(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlCombDet_colsControlType2Value_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            this.sControlTypetbl = this.tblPostCtrlCombDet_colsControlType2.Text;
			this.sModuletbl = this.tblPostCtrlCombDet_colsModule2.Text;
			this.GetControlTypeAttribs();
			this.sView2 = this.sView;
            this.SetZoomViewKeys("tblPostCtrlCombDet_colsControlType2Value");
			this.sPkgName2 = this.sPkgName;
			Sal.WaitCursor(true);
            this.tblPostCtrlCombDet_colsControlType2Value.p_sLovReference = this.sView2;
			Sal.WaitCursor(false);
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlCombDet_colsControlType2Value_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.GetControlTypeValue2Desc();
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemLovUserWhere event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlCombDet_colsControlType2Value_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            if (this.sView == "INCOME_TYPE_LOV(COUNTRY_CODE, CURRENCY_CODE)")
            {

                DbPLSQLBlock(@"&AO.Company_Finance_API.Get_Accounting_Currency({0} INOUT,[2} IN );
                               {1} := &AO.Company_API.Get_Country_Db({2} IN ); ",
                               this.QualifiedVarBindName("sBaseCurrCode"),
                               this.QualifiedVarBindName("sCountryDb"),
                               this.tblPostCtrlCombDet_colsCompany.QualifiedBindName);

                e.Return = ("COUNTRY_CODE='" + this.sCountryDb + "' and CURRENCY_CODE='" + this.sBaseCurrCode + "'").ToHandle();
                return;
            }
            if (this.sView == "TYPE1099_LOV(COUNTRY_CODE)")
            {
                DbPLSQLBlock("{0} := &AO.Company_API.Get_Country_Db({1} IN );",
                                        this.QualifiedVarBindName("sCountryDb"),
                                        this.tblPostCtrlCombDet_colsCompany.QualifiedBindName);

                e.Return = ("COUNTRY_CODE='" + this.sCountryDb + "'").ToHandle();
                return;
            }
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemZoom event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlCombDet_colsControlType2Value_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				this.sCurrentZoomCol = "colsControlType2Value";
				// Bug 76695, Begin
                if (this.tblPostCtrlCombDet_colsControlType2.Text == "C43") 
				{
					this.sItemNames[0] = "REQUISITIONER_CODE";
                    this.hWndItems[0] = this.tblPostCtrlCombDet_colsControlType2Value;
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("PurchaseRequisitioner", this, this.sItemNames, this.hWndItems);
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sDestination = "PURCHASE_REQUISITIONER";
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("ZOOM");
                    SessionNavigate(Pal.GetActiveInstanceName("frmPurBasic"));
				}
				else
				{
					e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
					return;
				}
				e.Return = true;
				return;
				// Bug 76695, End
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
		private void tblPostCtrlCombDet_colsCodePartValue_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblPostCtrlCombDet_colsCodePartValue_OnPM_DataItemValidate(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
					this.tblPostCtrlCombDet_colsCodePartValue_OnPM_DataItemZoom(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlCombDet_colsCodePartValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Part_Value_API.Get_Description")) 
			{
				this.sSql = string.Format(@"{0} := &AO.Accounting_Code_Part_Value_API.Get_Description({1} IN, {2} IN, {3} IN )",
                                                   this.QualifiedVarBindName("sCodePartValueDesc"),
                                                   this.QualifiedVarBindName("i_sCompany"),
                                                   this.tblPostCtrlCombDet_colsCodePart.QualifiedBindName,
                                                   this.tblPostCtrlCombDet_colsCodePartValue.QualifiedBindName);

                if (!(DbPLSQLBlock(this.sSql)))
                {
                    e.Return = false;
                    return;
                }
                this.tblPostCtrlCombDet_colsCodePartDescription.Text = this.sCodePartValueDesc;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemZoom event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlCombDet_colsCodePartValue_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
                this.sItemName1 = this.GetItemName(this.tblPostCtrlCombDet_colsCodePartValue);
				if (this.tblPostCtrlCombDet_colsCodePart.Text == "A") 
				{
					this.sFormName = Pal.GetActiveInstanceName("tbwAccountOverview");
					this.sItemNames[0] = "COMPANY";
                    this.hWndItems[0] = this.tblPostCtrlCombDet_colsCompany;
					this.sItemNames[1] = "ACCOUNT";
                    this.hWndItems[1] = this.tblPostCtrlCombDet_colsCodePartValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Account", tblPostCtrlCombDet, this.sItemNames, this.hWndItems);
                    SessionNavigate(Pal.GetActiveInstanceName("tbwAccountOverview"));
					this.sItemName1 = SalString.Null;
					e.Return = true;
					return;
				}
				else
				{
					Ifs.Fnd.ApplicationForms.Var.bReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
					Sal.WaitCursor(false);
					this.sItemName1 = SalString.Null;
					e.Return = Ifs.Fnd.ApplicationForms.Var.bReturn;
					return;
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		#endregion
			
		#region Window Events


        private void tblPostCtrlCombDet_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordGetDefaults();
        }

        private void tblPostCtrlCombDet_DataRecordToFormUserEvent(object sender, cDataSource.DataRecordToFormUserEventArgs e)
        {
            e.Handled = true;
            SalString lsServerAttr = e.lsServerAttr;
            SalBoolean bMarkAsEdited = e.bMarkAsEdited;
            e.ReturnValue = this.tblPostCtrlCombDet.DataRecordToFormUser( ref lsServerAttr, ref bMarkAsEdited);
            e.lsServerAttr = lsServerAttr;
            e.bMarkAsEdited = bMarkAsEdited;
        }
		
		#endregion
        #endregion
    }
}
