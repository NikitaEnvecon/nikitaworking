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
	/// Define Columns
	/// </summary>
	/// <param name="sViewName"></param>
	[FndWindowRegistration("INTFACE_REPL_STRUCT_COLS", "IntfaceReplStructCols", FndWindowRegistrationFlags.HomePage)]
	public partial class tbwIntfaceReplStructCols : cTableWindow
	{
		#region Window Parameters
		public SalString sViewName;
		#endregion
		
		#region Window Variables
		public SalString sIntfaceName = "";
		public SalString sStructureSeq = "";
		public SalBoolean bOk = false;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
        public tbwIntfaceReplStructCols()
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
		public new static tbwIntfaceReplStructCols FromHandle(SalWindowHandle handle)
		{
			return ((tbwIntfaceReplStructCols)SalWindow.FromHandle(handle, typeof(tbwIntfaceReplStructCols)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Applications override the FrameStartupUser function to perform
		/// actions when a window has been started.
		/// COMMENTS:
		/// Common actions to perform at this time is populating the window
		/// with special data, changeing the window title etc.
		/// 
		/// The FrameStartupUser is called by the framework after a window
		/// has been complete created and is visible on the screen, but before
		/// the framework executes any startup behvior according to the properties
		/// for that window.
		/// 
		/// Note: If this function is overriden on a form or table window some code
		/// must be supplied in order to support the standard framework functionality
		/// DataTransfer.
		/// EXAMPLE:
		/// Function: FrameStartupUser
		/// 	Actions
		/// 		Call SetWindowTitle( )
		/// 		If DataTransfer.RecCountGet( ) > 0
		/// 			Call SalWaitCursor( TRUE )
		/// 			Call InitFromTransferredData( )
		/// 			Call DataTransfer.Reset( )
		/// 			Call SalWaitCursor( FALSE )
		/// 			Return FALSE
		/// 		Else
		/// 			Call SalWaitCursor( FALSE )
		/// 			Return TRUE
		/// 		Return TRUE
		/// </summary>
		/// <returns>
		/// Applications should return FALSE to skip standard window startup logic (such
		/// as exectuing the "startup behavior" settings), or TRUE to allow standard logic.
		/// </returns>
        // Insert new code here...
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            SalArray<SalString> sIntfaceNameArray = new SalArray<SalString>();
            SalArray<SalString> sStructureSeqArray = new SalArray<SalString>();
            SalNumber nCount = 0;
            SalBoolean bOk = false;
            #endregion

            #region Actions
            this.sViewName = URL.iParameters.GetAttribute("VIEWNAME");
            using (new SalContext(this))
            {
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("INTFACE_NAME", sIntfaceNameArray);
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("STRUCTURE_SEQ", sStructureSeqArray);
                sIntfaceName = sIntfaceNameArray[0];
                sStructureSeq = sStructureSeqArray[0];
                bOk = ((cDataSource)this).FrameStartupUser();
                SetWindowTitle();
            }
            return false;
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
				Sal.SetWindowText(i_hWndSelf, Properties.Resources.WH_IntfaceReplStructCols + " - " + sIntfaceName + " - " + sStructureSeq + " " + sViewName);
				return true;
			}
			#endregion
		}
		
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
					lsStmt = " INTFACE_NAME = :i_hWndFrame.tbwIntfaceReplStructCols.sIntfaceName AND STRUCTURE_SEQ = :i_hWndFrame.tbwIntfaceReplStructCols.sStructureSeq";
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
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tbwIntfaceReplStructCols_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.tbwIntfaceReplStructCols_OnPM_DataRecordNew(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
					this.tbwIntfaceReplStructCols_OnPM_DataRecordDuplicate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tbwIntfaceReplStructCols_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.bOk = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && this.bOk) 
			{
				Sal.SendMsg(this.colsIntfaceName, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, this.sIntfaceName.ToHandle());
				Sal.SendMsg(this.colnStructureSeq, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, this.sStructureSeq.ToHandle());
				// Call SalSendMsg( colsOnNew, PM_DataItemValueSet, TRUE, SalHStringToNumber('FALSE'))
				// Call SalSendMsg( colsOnModify, PM_DataItemValueSet, TRUE, SalHStringToNumber('FALSE'))
			}
			e.Return = this.bOk;
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordDuplicate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tbwIntfaceReplStructCols_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.bOk = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && this.bOk) 
			{
				Sal.SendMsg(this.colsIntfaceName, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, this.sIntfaceName.ToHandle());
				Sal.SendMsg(this.colnStructureSeq, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, this.sStructureSeq.ToHandle());
				// Call SalSendMsg( colsOnNew, PM_DataItemValueSet, TRUE, SalHStringToNumber('FALSE'))
				// Call SalSendMsg( colsOnModify, PM_DataItemValueSet, TRUE, SalHStringToNumber('FALSE'))
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
