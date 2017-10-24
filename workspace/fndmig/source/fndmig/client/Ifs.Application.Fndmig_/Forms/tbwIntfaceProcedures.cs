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
	[FndWindowRegistration("INTFACE_PROCEDURES", "IntfaceProcedures")]
	public partial class tbwIntfaceProcedures : cTableWindow
	{
		#region Window Variables
		public SalString sOriginalProcName = "";
    	#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public tbwIntfaceProcedures()
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
		public new static tbwIntfaceProcedures FromHandle(SalWindowHandle handle)
		{
			return ((tbwIntfaceProcedures)SalWindow.FromHandle(handle, typeof(tbwIntfaceProcedures)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		protected virtual void GetDirection()
		{
            cEnumeration enumIntfaceDirection = cEnumeration.Get("IntfaceDirection");
            colsDirection.Text = enumIntfaceDirection.Decode(colsProcedureName.Text.Contains("OUT") ? "2" : "1");
            colsDirection.EditDataItemSetEdited();
        }
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void colsProcedureName_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
					e.Handled = true;
					this.sOriginalProcName = Ifs.Fnd.ApplicationForms.Const.strNULL;
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.colsProcedureName_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsProcedureName_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
			if (this.sOriginalProcName != this.colsProcedureName.Text) 
			{
				Sal.WaitCursor(true);
				if (this.colsProcedureName.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.WaitCursor(false);
					e.Return = Sys.VALIDATE_Ok;
					return;
				}
				this.GetDirection();
				Sal.WaitCursor(false);
				e.Return = Sys.VALIDATE_Ok;
				return;
			}
			else
			{
				e.Return = Sys.VALIDATE_Ok;
				return;
			}
			#endregion
		}
		#endregion
	}
}
