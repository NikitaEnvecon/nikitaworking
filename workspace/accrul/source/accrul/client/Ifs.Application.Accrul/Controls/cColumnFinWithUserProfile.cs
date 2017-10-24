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
	/// This Class has all the functionality of Column Fin and additional functionality
	/// to synchronize coulumns with the User profile Changes.
	/// </summary>
	public class cColumnFinWithUserProfile : cColumnFin
	{
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cColumnFinWithUserProfile()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cColumnFinWithUserProfile(ISalWindow derived)
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
			// cColumnFinWithUserProfile
			// 
			this.Name = "cColumnFinWithUserProfile";
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cColumnFinWithUserProfile_WindowActions);
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalNumber CallChanged()
		{
			#region Local Variables
			SalString __sDummy = "";
			SalString __sDisableWindow = "";
			SalNumber __nVisibility = 0;
			SalNumber __nCodePartCount = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				__sDummy = SalString.FromHandle(Sal.SendMsg(i_hWndFrame, Const.PAM_ChangedChildText, 0, __sOldLabel.ToHandle()));
				if (__sDummy != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.TblSetColumnTitle(i_hWndSelf, __sDummy);
				}
				// Disable unused codepart columns
				__sDisableWindow = SalString.FromHandle(Sal.SendMsg(i_hWndFrame, Const.PAM_DisableUnusedCodeParts, 0, p_sSqlColumn.ToHandle()));
				// Check for Visibility
				__nCodePartCount = GetCodePartCount(p_sSqlColumn);
				__nVisibility = Sal.SendMsg(Sys.hWndForm, Const.PAM_SynchronizeWithProfile, __nCodePartCount, i_hWndSelf.ToNumber());
				if (__sDisableWindow != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
                    Sal.HideWindowAndLabel(i_hWndSelf);
				}
				else
				{
					if (__nVisibility == 1) 
					{
                        Sal.ShowWindowAndLabel(i_hWndSelf);
					}
					else
					{
                        Sal.HideWindowAndLabel(i_hWndSelf);
					}
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// Gets the count for the codeparts
		/// </summary>
		/// <param name="sSqlColumn"></param>
		/// <returns></returns>
		public virtual SalNumber GetCodePartCount(SalString sSqlColumn)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sSqlColumn == "ACCOUNT" || sSqlColumn == "ACCOUNT_DESC") 
				{
					return 0;
				}
				if (sSqlColumn == "CODE_B" || sSqlColumn == "CODE_B_DESC") 
				{
					return 1;
				}
				if (sSqlColumn == "CODE_C" || sSqlColumn == "CODE_C_DESC") 
				{
					return 2;
				}
				if (sSqlColumn == "CODE_D" || sSqlColumn == "CODE_D_DESC") 
				{
					return 3;
				}
				if (sSqlColumn == "CODE_E" || sSqlColumn == "CODE_E_DESC") 
				{
					return 4;
				}
				if (sSqlColumn == "CODE_F" || sSqlColumn == "CODE_F_DESC") 
				{
					return 5;
				}
				if (sSqlColumn == "CODE_G" || sSqlColumn == "CODE_G_DESC") 
				{
					return 6;
				}
				if (sSqlColumn == "CODE_H" || sSqlColumn == "CODE_H_DESC") 
				{
					return 7;
				}
				if (sSqlColumn == "CODE_I" || sSqlColumn == "CODE_I_DESC") 
				{
					return 8;
				}
				if (sSqlColumn == "CODE_J" || sSqlColumn == "CODE_J_DESC") 
				{
					return 9;
				}
				return -1;
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
		private void cColumnFinWithUserProfile_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.cColumnFinWithUserProfile_OnSAM_Create(sender, e);
					break;
				
				case Const.PAM_CallChanged:
					e.Handled = true;
					this.vrtCallChanged();
					break;
				
				case Sys.SAM_SetFocus:
					this.cColumnFinWithUserProfile_OnSAM_SetFocus(sender, e);
					break;
				
				case Const.PAM_DescriptionFound:
					e.Handled = true;
					this.cGetCodePartDescription();
					break;
				
				case Const.PAM_CellContentFound:
					e.Handled = true;
					this.cGetCodePartValue();
					break;
				
				case Sys.SAM_KillFocus:
					this.cColumnFinWithUserProfile_OnSAM_KillFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnFinWithUserProfile_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam))) 
			{
				e.Return = false;
				return;
			}
			Sal.SendMsg(this.i_hWndSelf, Const.PAM_CallChanged, 0, 0);
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnFinWithUserProfile_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam))) 
			{
				e.Return = false;
				return;
			}
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_KillFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnFinWithUserProfile_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.SendClassMessage(Sys.SAM_KillFocus, Sys.wParam, Sys.lParam))) 
			{
				e.Return = false;
				return;
			}
			e.Return = true;
			return;
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cColumnFinWithUserProfile to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cColumnFinWithUserProfile self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cColumnFinWithUserProfile to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cColumnFinWithUserProfile self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cColumnFinWithUserProfile.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cColumnFinWithUserProfile(cEditControlsManager super)
		{
			return ((cColumnFinWithUserProfile)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cColumnFinWithUserProfile.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cColumnFinWithUserProfile(cSessionManager super)
		{
			return ((cColumnFinWithUserProfile)((cEditControlsManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cColumnFinWithUserProfile FromHandle(SalWindowHandle handle)
		{
			return ((cColumnFinWithUserProfile)SalWindow.FromHandle(handle, typeof(cColumnFinWithUserProfile)));
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtCallChanged()
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
