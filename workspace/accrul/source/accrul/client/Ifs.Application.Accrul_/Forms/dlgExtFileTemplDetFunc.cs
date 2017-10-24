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
	[FndWindowRegistration("EXT_FILE_TEMPL_DET_FUNC", "ExtFileTemplDetFunc", FndWindowRegistrationFlags.HomePage)]
	public partial class dlgExtFileTemplDetFunc : cDialogBox
	{
		#region Window Variables
		public SalString sFileTemplateId = "";
		public SalString sColumnId = "";
		public SalString sColumnDescription = "";
		public SalNumber nRowNo = 0;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgExtFileTemplDetFunc()
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
		public static SalNumber ModalDialog(Control owner)
		{
			dlgExtFileTemplDetFunc dlg = DialogFactory.CreateInstance<dlgExtFileTemplDetFunc>();
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgExtFileTemplDetFunc FromHandle(SalWindowHandle handle)
		{
			return ((dlgExtFileTemplDetFunc)SalWindow.FromHandle(handle, typeof(dlgExtFileTemplDetFunc)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{			
            SalBoolean bOk = __InitFromDataTransfer();
		    // Set bOk = bOk And DataSourcePopulate( METHOD_Execute, 0 )
		    PopulateFromView();
		    __InvestigateButtons();
		    dfFileTemplateId.Text = sFileTemplateId;
		    dfsColumnId.Text = sColumnId;
		    dfsColumnDescription.Text = sColumnDescription;
		    DbPLSQLBlock(@":i_hWndFrame.dlgExtFileTemplDetFunc.dfsTemplateDescription := &AO.Ext_File_Template_API.Get_Description(:i_hWndFrame.dlgExtFileTemplDetFunc.dfFileTemplateId)");
		    return bOk;
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sMethod"></param>
		/// <returns></returns>
		public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
		{
            switch (sMethod)
            {
                case "New":
                    return UM_New(nWhat);
                case "Save":
                    return UM_Save(nWhat);
                case "Remove":
                    return UM_Remove(nWhat);
                case "List":
                    return UM_List(nWhat);
                case "Close":
                    return UM_Close(nWhat);
            }
			return 0;
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_New(SalNumber nWhat)
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions

			bOk = Sal.SendMsg(tblExtFileTemplDetFunc, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, nWhat, 0);
            if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            { __InvestigateButtons(); }
			return bOk;
	
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Save(SalNumber nWhat)
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
	
			bOk = Sal.SendMsg(tblExtFileTemplDetFunc, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, nWhat, 0);
			if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{ __InvestigateButtons(); }
			return bOk;

			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Remove(SalNumber nWhat)
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
		
			bOk = Sal.SendMsg(tblExtFileTemplDetFunc, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, nWhat, 0);
			if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{ __InvestigateButtons(); }
			return bOk;
	
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_List(SalNumber nWhat)
		{
            return __ManageListOfValues(nWhat);
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Close(SalNumber nWhat)
		{
		    switch (nWhat)
		    {
			    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
				    return true;
					
			    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
				    if (DataSourceIsDirty(nWhat)) 
				    { return Sal.EndDialog(this, Sys.IDCANCEL); }
				    else
				    { return false; }
				    break;
		    }
			return false;
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean __InitFromDataTransfer()
		{
			#region Local Variables
			SalString sTransferName = "";
			SalString sTmp = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sTransferName = Pal.GetActiveInstanceName("dlgExtFileTemplDetFunc");
				if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet() == sTransferName) 
				{
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(0, 0, ref sFileTemplateId);
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(1, 0, ref sTmp);
					nRowNo = sTmp.ToNumber();
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(2, 0, ref sColumnId);
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(3, 0, ref sColumnDescription);
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
				}
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber __InvestigateButtons()
		{
			pbNew.MethodInvestigateState();
			pbSave.MethodInvestigateState();
			pbRemove.MethodInvestigateState();
			pbList.MethodInvestigateState();
			return 0;
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dlgExtFileTemplDetFunc_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Close:
					e.Handled = true;
					// Close = Cancel.
					e.Return = Sal.EndDialog(this, Sys.IDCANCEL);
					return;
				
				case Sys.SAM_Create:
					this.dlgExtFileTemplDetFunc_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgExtFileTemplDetFunc_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			Sal.CenterWindow(this);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblExtFileTemplDetFunc_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemEntered:
					e.Handled = true;
					this.pbList.MethodInvestigateState();
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
		
		#region ChildTable - tblExtFileTemplDetFunc
	
		#region Methods
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
        public virtual SalBoolean tblExtFileTemplDetFunc_DataRecordGetDefaults()
		{
		    tblExtFileTemplDetFunc_colsFileTemplateId.EditDataItemValueSet(1, this.sFileTemplateId.ToHandle());
            tblExtFileTemplDetFunc_colnRowNo.EditDataItemValueSet(1, this.nRowNo.ToString(0).ToHandle());
            return true;
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
        public virtual SalNumber tblExtFileTemplDetFunc_MethodInvestigateState()
		{
		    return this.__InvestigateButtons();
		}
			
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean __ManageListOfValues(SalNumber nWhat)
		{
			#region Local Variables
			SalBoolean bOk = false;
			SalNumber nRow = 0;
			SalWindowHandle hWndFocusCell = SalWindowHandle.Null;
			#endregion
				
			#region Actions
			using (new SalContext(this))
			{
				Sal.TblQueryFocus(tblExtFileTemplDetFunc, ref nRow, ref hWndFocusCell);
				bOk = Sal.SendMsg(hWndFocusCell, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, nWhat, 0);
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
                    Sal.TblSetFocusCell(tblExtFileTemplDetFunc, nRow, hWndFocusCell, 0, 0);
				}
				return bOk;
			}
			#endregion
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber PopulateFromView()
		{
		    Sal.WaitCursor(true);
		    Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_NoConfirm);
		    Sal.WaitCursor(false);
			return 0;
		}
		#endregion

        #region Event Handlers

        private void tblExtFileTemplDetFunc_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblExtFileTemplDetFunc_DataRecordGetDefaults();
        }


        private void tblExtFileTemplDetFunc_MethodInvestigateStateEvent(object sender, FndReturnEventArgsSalNumber e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblExtFileTemplDetFunc_MethodInvestigateState();
        }
        #endregion
      
        #endregion
	}
}
