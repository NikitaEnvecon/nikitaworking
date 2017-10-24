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
	/// To be used for datafields representing a code part
	/// </summary>
	public class cDataFieldFin : cDataField
	{
		#region Fields
		public SalString __sOldLabel = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cDataFieldFin()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cDataFieldFin(ISalWindow derived)
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
			// cDataFieldFin
			// 
			this.Name = "cDataFieldFin";
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cDataFieldFin_WindowActions);
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber CallChanged()
		{
			using (new SalContext(this))
			{
                SalString __sDummy = SalString.FromHandle(Sal.SendMsg(i_hWndFrame, Const.PAM_ChangedChildText, 0, __sOldLabel.ToHandle()));
				if (__sDummy != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					Sal.SetWindowLabelText(i_hWndSelf, __sDummy);
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
		private void cDataFieldFin_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.cDataFieldFin_OnSAM_Create(sender, e);
					break;
				
				case Const.PAM_CallChanged:
					e.Handled = true;
					this.vrtCallChanged();
					break;
				
				// Bug 72392 - Begin				
				case Const.PAM_ChangeLovTitle:
					e.Handled = true;
					e.Return = Var.FinlibServices.GetTitle(SalString.FromHandle(Sys.lParam), this.p_sLovReference, this.__sOldLabel, this.i_hWndSelf).ToHandle();
					return;
				
				// Bug 72392 - End
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cDataFieldFin_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            this.__sOldLabel = this.GetLabelText(99);
            this.SendMessage(Const.PAM_CallChanged, 0, 0);
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldFin to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cDataFieldFin self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldFin to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cDataFieldFin self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataFieldFin to type cResize.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cResize(cDataFieldFin self)
		{
			return self._cResize;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cDataFieldFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldFin(cEditControlsManager super)
		{
			return ((cDataFieldFin)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cDataFieldFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldFin(cSessionManager super)
		{
			return ((cDataFieldFin)((cEditControlsManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cResize to type cDataFieldFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDataFieldFin(cResize super)
		{
			return ((cDataFieldFin)((cEditControlsManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cDataFieldFin FromHandle(SalWindowHandle handle)
		{
			return ((cDataFieldFin)SalWindow.FromHandle(handle, typeof(cDataFieldFin)));
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
