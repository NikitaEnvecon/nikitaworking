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

using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// </summary>
	public class cComboBoxFin : cComboBox
	{
		#region Fields
		public SalString __sOldLabel = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cComboBoxFin()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cComboBoxFin(ISalWindow derived)
		{
			// Attach derived instance.
			this._derived = derived;
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Attach actions handler to derived instance.
			this._derived.AttachMessageActions(this);
		}
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// cComboBoxFin
			// 
			this.Name = "cComboBoxFin";
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cComboBoxFin_WindowActions);
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber CallChanged()
		{
			#region Local Variables
			SalString __sDummy = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				__sDummy = SalString.FromHandle(Sal.SendMsg(i_hWndFrame, Const.PAM_ChangedChildText, 0, __sOldLabel.ToHandle()));
				if (__sDummy != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.SetWindowLabelText(i_hWndSelf, __sDummy);
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
		private void cComboBoxFin_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Const.PAM_CallChanged:
					e.Handled = true;
					this.vrtCallChanged();
					break;
				
				case Sys.SAM_Create:
					this.cComboBoxFin_OnSAM_Create(sender, e);
					break;
				
				case Sys.SAM_SetFocus:
					this.cComboBoxFin_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cComboBoxFin_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam))) 
			{
				e.Return = false;
				return;
			}
			Sal.GetWindowLabelText(this.i_hWndSelf, ref this.__sOldLabel, 99);
			Sal.SendMsg(this.i_hWndSelf, Const.PAM_CallChanged, 0, 0);
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cComboBoxFin_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam))) 
			{
				e.Return = false;
				return;
			}
			Sal.SendMsg(this.i_hWndParent, Const.PAM_DlgSetLovState, 0, this.i_hWndSelf.ToNumber());
			e.Return = true;
			return;
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cComboBoxFin to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cComboBoxFin self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cComboBoxFin to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cComboBoxFin self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cComboBoxFin to type cResize.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cResize(cComboBoxFin self)
		{
			return self._cResize;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cComboBoxFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cComboBoxFin(cEditControlsManager super)
		{
			return ((cComboBoxFin)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cComboBoxFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cComboBoxFin(cSessionManager super)
		{
			return ((cComboBoxFin)((cEditControlsManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cResize to type cComboBoxFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cComboBoxFin(cResize super)
		{
			return ((cComboBoxFin)((cEditControlsManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cComboBoxFin FromHandle(SalWindowHandle handle)
		{
			return ((cComboBoxFin)SalWindow.FromHandle(handle, typeof(cComboBoxFin)));
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalNumber vrtCallChanged()
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.CallChanged();
			}
			else
			{
				return lateBind.vrtCallChanged();
			}
		}
		#endregion
		
		#region Multiple Inheritance Late Bind Interface
		
		public interface LateBind
		{
			SalNumber vrtCallChanged();
		}
		#endregion
	}
}
