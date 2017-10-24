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
	public class cCheckBoxFin : cCheckBox
	{
		#region Fields
		public SalString __sOldLabel = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cCheckBoxFin()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cCheckBoxFin(ISalWindow derived)
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
			// cCheckBoxFin
			// 
			this.Name = "cCheckBoxFin";
			this.AutoSize = true;
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cCheckBoxFin_WindowActions);
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
					if (Sal.WindowIsDerivedFromClass(Sys.hWndForm, typeof(cTabFormWindow))) 
					{
						__sDummy = __sDummy.Left(__sOldLabel.Length);
					}
					else
					{
						__sDummy = __sDummy;
					}
					Sal.SetWindowText(this, __sDummy);
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
		private void cCheckBoxFin_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.cCheckBoxFin_OnSAM_Create(sender, e);
					break;
				
				case Const.PAM_CallChanged:
					e.Handled = true;
					this.vrtCallChanged();
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cCheckBoxFin_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			Sal.GetWindowText(this.i_hWndSelf, ref this.__sOldLabel, 99);
			Sal.SendMsg(this.i_hWndSelf, Const.PAM_CallChanged, 0, 0);
			e.Return = true;
		}

		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cCheckBoxFin to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cCheckBoxFin self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cCheckBoxFin to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cCheckBoxFin self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cCheckBoxFin to type cResize.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cResize(cCheckBoxFin self)
		{
			return self._cResize;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cCheckBoxFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cCheckBoxFin(cEditControlsManager super)
		{
			return ((cCheckBoxFin)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cCheckBoxFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cCheckBoxFin(cSessionManager super)
		{
			return ((cCheckBoxFin)((cEditControlsManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cResize to type cCheckBoxFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cCheckBoxFin(cResize super)
		{
			return ((cCheckBoxFin)((cEditControlsManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cCheckBoxFin FromHandle(SalWindowHandle handle)
		{
			return ((cCheckBoxFin)SalWindow.FromHandle(handle, typeof(cCheckBoxFin)));
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
