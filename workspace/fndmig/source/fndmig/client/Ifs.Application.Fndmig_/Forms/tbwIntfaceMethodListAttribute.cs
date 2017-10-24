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

using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Fndmig_
{
	
	/// <summary>
	/// </summary>
	/// <param name="nExecuteSeq"></param>
	/// <param name="sViewName"></param>
	public partial class tbwIntfaceMethodListAttribute : cTableWindow
	{
		#region Window Parameters
		public SalNumber nExecuteSeq;
		public SalString sViewName;
		#endregion
		
		#region Window Variables
		public SalString sParentWindow = "";
		public SalString sIntfaceName = "";
		public SalBoolean bOk = false;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
        public tbwIntfaceMethodListAttribute()
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
		public new static tbwIntfaceMethodListAttribute FromHandle(SalWindowHandle handle)
		{
			return ((tbwIntfaceMethodListAttribute)SalWindow.FromHandle(handle, typeof(tbwIntfaceMethodListAttribute)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Adding additional where clause
		/// </summary>
		/// <param name="bPopulateSingle">
		/// Data items only flag
		/// Specify TRUE to populate the data items only (ingorning record selection combo boxes), FALSE
		/// to populate everything.
		/// </param>
		/// <returns></returns>
		public SalBoolean DataSourcePopulateIt(SalBoolean bPopulateSingle)
		{
			#region Local Variables
			SalString lsStmt = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (sIntfaceName != SalString.Null) 
				{
					lsStmt = " INTFACE_NAME = :i_hWndFrame.tbwIntfaceMethodListAttribute.sIntfaceName AND EXECUTE_SEQ = :i_hWndFrame.tbwIntfaceMethodListAttribute.nExecuteSeq";
					if (i_lsUserWhere != SalString.Null && lsStmt != SalString.Null) 
					{
						lsStmt = lsStmt + " AND " + i_lsUserWhere;
					}
					else if (i_lsUserWhere != SalString.Null && lsStmt == SalString.Null) 
					{
						lsStmt = i_lsUserWhere;
					}
					DataSourceUserWhere(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, lsStmt.ToHandle());
				}
				return ((cTableWindow)this).DataSourcePopulateIt(bPopulateSingle);
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            URL.iParameters.GetAttribute(ref this.nExecuteSeq, "EXECUTE_SEQ");
            this.sViewName = URL.iParameters.GetAttribute("VIEWNAME");

            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                       Sal.WaitCursor(true);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("INTFACE_NAME"), 0, ref sIntfaceName);
                        // Call DataTransfer.ItemValueStrGet(DataTransfer.ItemIndexGet('EXECUTE_SEQ'),1, sExecuteSeq)
                        if (InitFromTransferredData())
                        {
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                        }
                        Sal.WaitCursor(false);
                        SetWindowTitle();
                }
            }
            return false;
        }
		
		/// <summary>
		/// Used to keep any query-counting within the Intface_name transferred from tbwIntfaceMethodList
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="nParam"></param>
		/// <returns></returns>
		public new SalNumber DataSourceHitCount(SalNumber nWhat, SalNumber nParam)
		{
			#region Local Variables
			SalString lsStmt = "";
			SalString lsParam = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					if (sIntfaceName != SalString.Null) 
					{
						lsStmt = SalString.Null;
						lsParam = SalString.FromHandle(nParam);
						lsStmt = " INTFACE_NAME = :i_hWndFrame.tbwIntfaceMethodListAttribute.sIntfaceName";
						if (lsParam != SalString.Null && lsStmt != SalString.Null) 
						{
							lsStmt = lsStmt + " AND " + lsParam;
						}
						else if (lsParam != SalString.Null && lsStmt == SalString.Null) 
						{
							lsStmt = lsParam;
						}
						nParam = lsStmt.ToHandle();
					}
				}
				return ((cDataSource)this).DataSourceHitCount(nWhat, nParam);
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean SetWindowTitle()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.SetWindowText(i_hWndSelf, Properties.Resources.WH_MethodListAttr + " - " + sIntfaceName + " - " + nExecuteSeq.ToString(0) + "  " + sViewName);
				return true;
			}
			#endregion
		}

        /// <summary>
        /// Set the IntfaceName and ExecuteSeq values for pasted records
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetIntfaceNameExecSeq()
        {
            #region Local Variables
            SalNumber nCurrentRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nCurrentRow = Sys.TBL_MinRow;
                while (Sal.TblFindNextRow(i_hWndSelf, ref nCurrentRow, Sys.ROW_Edited, 0))
                {
                    Sal.TblSetContext(i_hWndSelf, nCurrentRow);
                    // Only modify pasted records
                    if (colsIntfaceName.Text == Sys.STRING_Null)
                    {
                        Sal.SendMsg(colsIntfaceName, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sIntfaceName.ToHandle());
                        Sal.SendMsg(colnExecuteSeq, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, nExecuteSeq.ToString(0).ToHandle());
                        Sal.SendMsg(colsOnNew, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)"FALSE").ToHandle());
                        Sal.SendMsg(colsOnModify, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)"FALSE").ToHandle());
                    }
                }
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
		private void tbwIntfaceMethodListAttribute_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.tbwIntfaceMethodListAttribute_OnPM_DataRecordNew(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
					this.tbwIntfaceMethodListAttribute_OnPM_DataRecordDuplicate(sender, e);
					break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    this.tbwIntfaceMethodListAttribute_OnPM_DataRecordPaste(sender, e);
                    break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tbwIntfaceMethodListAttribute_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.bOk = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && this.bOk) 
			{
				Sal.SendMsg(this.colsIntfaceName, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, this.sIntfaceName.ToHandle());
				Sal.SendMsg(this.colnExecuteSeq, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, this.nExecuteSeq.ToString(0).ToHandle());
				Sal.SendMsg(this.colsOnNew, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)"FALSE").ToHandle());
				Sal.SendMsg(this.colsOnModify, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)"FALSE").ToHandle());
			}
			e.Return = this.bOk;
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordDuplicate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tbwIntfaceMethodListAttribute_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.bOk = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && this.bOk) 
			{
				Sal.SendMsg(this.colsIntfaceName, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, this.sIntfaceName.ToHandle());
				Sal.SendMsg(this.colnExecuteSeq, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, this.nExecuteSeq.ToString(0).ToHandle());
				Sal.SendMsg(this.colsOnNew, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)"FALSE").ToHandle());
				Sal.SendMsg(this.colsOnModify, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)"FALSE").ToHandle());
			}
			e.Return = this.bOk;
			return;
			#endregion
		}

        /// <summary>
        /// PM_DataRecordPaste event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwIntfaceMethodListAttribute_OnPM_DataRecordPaste(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.bOk = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && this.bOk)
            {
                this.SetIntfaceNameExecSeq();
            }
            e.Return = this.bOk;
            return;
            #endregion
        }
        
        #endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtDataSourceHitCount(SalNumber nWhat, SalNumber nParam)
		{
			return this.DataSourceHitCount(nWhat, nParam);
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtDataSourcePopulateIt(SalNumber nParam)
		{
			return this.DataSourcePopulateIt(nParam);
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
        // Insert new code here...
		#endregion
	}
}
