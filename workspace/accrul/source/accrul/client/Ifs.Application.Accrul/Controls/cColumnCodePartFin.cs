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
// DATE       ASSIGNEE    BUG     HISTORY
// 2013       CLSTLK     108361  Rollback correction done by SFI-981 and removed some part of the correction from SFI-1218. 
// 22-11-13   Mawelk     PBFI-4117(Lsc Bug Id 113887)  Fixed.
// 02-04-14   Samllk     114084  Modified cColumnCodePartFin_OnPM_DataItemValidate() to avoid infinte calling of message 
//                               PAM_ValidateCodePartValues, by having a new variable to store the previous value 
// 14-10-14   Mawelk     PRFI-3065 ( LCS Bug id 119152 )fixed.   
#endregion

using System;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using Ifs.Application.Appsrv;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// The common functionality for all the codeparts fields is implemented here
	/// When codepart columns were connected to this class, it will perform the following fuctions automatically
	/// 1. Disabling the unused codepart columns
	/// 2. Performs codestring completion for the codeparts
	/// 3. Pseudo codes for the account column is handled.
	/// 4. Synchronize with the user profile.
	/// </summary>
	public class cColumnCodePartFin : cColumnFinWithUserProfile
	{
		#region Fields
		[ThreadStatic]
		public static SalString sProjectCodePart;

		#region Static Fields initialization
		[ThreadStatic]
		private static bool threadStaticsInitialized;

		internal static void InitThreadStaticFields()
		{
			if (!threadStaticsInitialized)
			{
				threadStaticsInitialized = true;
				sProjectCodePart = "";
			}
		}
		#endregion

		public SalString sPrevValue = "";
        public SalString sPrevValueInValidateCodePart = "";
        public SalString i_sPkgName = "";
		public SalString i_sMethodName = "";
		public SalBoolean __i_bTabRepeat = false;
		public SalBoolean __i_bKeyDownReturn = false;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cColumnCodePartFin()
		{
			InitThreadStaticFields();
		
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cColumnCodePartFin(ISalWindow derived)
		{
			InitThreadStaticFields();
		
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
			// cColumnCodePartFin
			// 
			this.Name = "cColumnCodePartFin";
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cColumnCodePartFin_WindowActions);
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Get code part demand (Blocked, Can, Mandatory) and set value if exists
		/// </summary>
		/// <param name="nPLength"></param>
		/// <param name="nPAttr"></param>
		/// <returns></returns>
		public virtual SalNumber SetCodePartValues(SalNumber nPLength, SalNumber nPAttr)
		{
			#region Local Variables
			SalNumber i_nStrLength = 0;
			SalString i_lsAttr = "";
			SalString i_sReqAttr = "";
			SalString i_sReqAttrValue = "";
			SalString sReqField = "";
			SalString sReqFieldValue = "";
			SalString sColumnName = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				i_lsAttr = SalString.FromHandle(nPAttr);
				i_nStrLength = i_lsAttr.Length;
				i_sReqAttr = i_lsAttr.Left(nPLength);
				i_nStrLength = i_nStrLength - nPLength;
				i_sReqAttrValue = i_lsAttr.Right(i_nStrLength);
				sColumnName = cColumn.FromHandle(i_hWndSelf).p_sSqlColumn;
				sReqField = Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sColumnName, i_sReqAttr);
				sReqFieldValue = Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sColumnName, i_sReqAttrValue);
				if (sReqField.Trim().ToUpper() == "S") 
				{
					Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
                    // Bug 108361, Removed Code which makes Infinite call to PM_DataItemValidate.                        
				}
				else if (Sal.IsNull(this) || (sColumnName == "ACCOUNT")) 
				{
					Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sReqFieldValue.ToHandle());
                    // Bug 108361, Removed Code which makes Infinite call to PM_DataItemValidate. 
				}
				else
				{
					Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sReqFieldValue.ToHandle());
                    // Bug 108361, Removed Code which makes Infinite call to PM_DataItemValidate. 
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
		private void cColumnCodePartFin_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.cColumnCodePartFin_OnPM_DataItemValidate(sender, e);
					break;
				
				case Const.PAM_SetCodePartValues:
					e.Handled = true;
					this.SetCodePartValues(Sys.wParam, Sys.lParam);
					break;
				
				case Sys.SAM_SetFocus:
					this.cColumnCodePartFin_OnSAM_SetFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew:
					this.cColumnCodePartFin_OnPM_DataItemNew(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.WM_KEYDOWN:
					this.cColumnCodePartFin_OnWM_KEYDOWN(sender, e);
					break;
				
				case Sys.SAM_KillFocus:
					this.cColumnCodePartFin_OnSAM_KillFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnCodePartFin_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel) 
			{
				e.Return = Sys.VALIDATE_Cancel;
				return;
			}
            // Bug 108361, Begin Modified IF condition by removing this.sPrevValue != this.Text
            if (!(Sal.IsNull(this)) && (!(this.Text == Sys.STRING_Null)))
			{
				if (this.sPrevValue != this.Text)
                {
                    this.sPrevValueInValidateCodePart = this.Text;
                }
                this.sPrevValue = this.Text;
				if ((this.p_sSqlColumn.Scan("ACCOUNT") != -1) || (this.p_sSqlColumn.Scan("CODE\\_") != -1)) 
				{
					if (cColumnCodePartFin.sProjectCodePart == SalString.Null) 
					{
						cColumnCodePartFin.sProjectCodePart = Var.FinlibServices.GetCodePartFunction("PRACC");
					}
                    if (cColumnCodePartFin.sProjectCodePart == this.p_sSqlColumn.Right(1) & Sys.wParam == 1) 
					{
						if (Sal.SendMsg(this.i_hWndParent, Const.PAM_CheckExternalProject, ((SalString)this.Text).ToHandle(), 0) == Sys.VALIDATE_Cancel) 
						{
							e.Return = Sys.VALIDATE_Cancel;
							return;
						}
					}
					if (sPrevValueInValidateCodePart != Sys.STRING_Null)
                    {
                        if (Sal.SendMsg(this.i_hWndParent, Const.PAM_ValidateCodePartValues, this.p_sSqlColumn.ToHandle(), ((SalString)this.Text).ToHandle()) == Sys.VALIDATE_Cancel)
                        {
                            // Bug 108361, Begin
                            this.sPrevValueInValidateCodePart = SalString.Null;
                            // Bug 108361, End.
                            e.Return = Sys.VALIDATE_Cancel;
                            return;
                        }
                    }
                }
			}
            // Bug 108361, End.
			else if (Sal.IsNull(this) && (this.Text == Sys.STRING_Null)) 
			{
				if (cColumnCodePartFin.sProjectCodePart == this.p_sSqlColumn.Right(1)) 
				{
					Sal.SendMsg(this.i_hWndParent, Const.PAM_CheckExternalProject, ((SalString)this.Text).ToHandle(), 0);
				}
			}
			this.sPrevValue = this.Text;
			e.Return = Sys.VALIDATE_Ok;

            if (((Control)this).Text == "")
            { 
                Control whNextChild = ((Control)this.GetNextChild(Sys.TYPE_TableColumn));
                if ((whNextChild != Sys.hWndNULL) && whNextChild.Name == String.Concat(this.Name, "Desc"))
                {
                    whNextChild.Text = "";
                }
            }

			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnCodePartFin_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendMsg(this.i_hWndParent, Const.PAM_CodePartBlocked, this.p_sSqlColumn.ToHandle(), 0)) 
			{
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client                
                System.Windows.Forms.SendKeys.SendWait("{TAB}");
                
				return;
			}
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnCodePartFin_OnPM_DataItemNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew, Sys.wParam, Sys.lParam);
			this.sPrevValue = SalString.Null;
            this.sPrevValueInValidateCodePart = SalString.Null;
            this.__i_bTabRepeat = false;
			#endregion
		}
		
		/// <summary>
		/// WM_KEYDOWN event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnCodePartFin_OnWM_KEYDOWN(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			switch (Sys.wParam)
			{
				case Vis.VK_Tab:
					if (!(this.__i_bTabRepeat)) 
					{
						Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.WM_KEYDOWN, Vis.VK_Tab, 0);
						this.__i_bTabRepeat = true;
					}                    
                    else
                    {
                        Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.WM_KEYDOWN, Sys.wParam, Sys.lParam);
                    }                    
					break;
				
				default:
					this.__i_bKeyDownReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.WM_KEYDOWN, Sys.wParam, Sys.lParam);
					// Do return only if FALSE
					if (this.__i_bKeyDownReturn == false) 
					{
						e.Return = this.__i_bKeyDownReturn;
						return;
					}
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_KillFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnCodePartFin_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.__i_bTabRepeat = false;
			e.Return = Sal.SendClassMessage(Sys.SAM_KillFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cColumnCodePartFin to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cColumnCodePartFin self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cColumnCodePartFin to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cColumnCodePartFin self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cColumnCodePartFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cColumnCodePartFin(cEditControlsManager super)
		{
			return ((cColumnCodePartFin)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cColumnCodePartFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cColumnCodePartFin(cSessionManager super)
		{
			return ((cColumnCodePartFin)((cEditControlsManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cColumnCodePartFin FromHandle(SalWindowHandle handle)
		{
			return ((cColumnCodePartFin)SalWindow.FromHandle(handle, typeof(cColumnCodePartFin)));
		}
		#endregion
	}
}
