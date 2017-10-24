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
// DATE        BY        NOTES
// YY-MM-DD
// 12-02-20    MAWELK    Bug 108346, Corrected in SetCharacter().
// 13-03-14    MAWELK    Bug 108935. Changes to CallChanged().
#endregion

using System;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// </summary>
	public class cColumnFin : cColumn
	{
		#region Fields
		[ThreadStatic]
		public static SalString c_sCodePartValue;
		[ThreadStatic]
		public static SalString c_sCodePart;
		[ThreadStatic]
		public static SalString c_sCompany;
		[ThreadStatic]
		public static SalString c_sDescription;
		[ThreadStatic]
		public static SalWindowHandle c_hMyDescHandle;
		[ThreadStatic]
		public static SalWindowHandle c_hMyCodePartHandle;
		[ThreadStatic]
		public static SalString c_sCodePartValueTemp;
		[ThreadStatic]
		public static SalString c_sCodePartTemp;
		[ThreadStatic]
		public static SalString c_sDescriptionTemp;

		#region Static Fields initialization
		[ThreadStatic]
		private static bool threadStaticsInitialized;

		internal static void InitThreadStaticFields()
		{
			if (!threadStaticsInitialized)
			{
				threadStaticsInitialized = true;
				c_sCodePartValue = "";
				c_sCodePart = "";
				c_sCompany = "";
				c_sDescription = "";
				c_hMyDescHandle = SalWindowHandle.Null;
				c_hMyCodePartHandle = SalWindowHandle.Null;
				c_sCodePartValueTemp = "";
				c_sCodePartTemp = "";
				c_sDescriptionTemp = "";
			}
		}
		#endregion

		public SalString UnusedCodeParts = "";
		public SalString __sOldLabel = "";
		public SalString __sVouDate = "";
		public SalString __sUserGroup = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cColumnFin()
		{
			InitThreadStaticFields();
		
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cColumnFin(ISalWindow derived)
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
			// cColumnFin
			// 
			this.Name = "cColumnFin";
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cColumnFin_WindowActions);
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
			SalString __sDisableWindow = "";
			SalString __sInternalCP = "";
			SalString __sLast = "";
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
				__sInternalCP = Var.FinlibServices.GetCodePartFunction("INTERN");
				if (__sDisableWindow != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.HideWindow(i_hWndSelf);
				}
				else
				{
					__sLast = p_sSqlColumn.Right(1);
					if (__sInternalCP != Ifs.Fnd.ApplicationForms.Const.strNULL && (__sInternalCP.Scan(__sLast) != -1) && this.vrtHideInternalCP()) 
					{
						Sal.HideWindow(i_hWndSelf);
					}
                    // Bug Id 108935 Begin , Removed the Else part of the code.
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean cGetCodePartDescription()
		{
			#region Local Variables
			SalNumber a = 0;
			SalString sMultiCompany = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				// Gets the voucher company, in a multi - company scenario
				sMultiCompany = SalString.FromHandle(Sal.SendMsg(Sys.hWndForm, Const.PAM_GetMultiCompany, Sys.wParam, Sys.lParam));
				if (sMultiCompany != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					cColumnFin.c_sCompany = sMultiCompany;
				}
				// When focus is on a codepart description column
				a = __sOldLabel.Scan("Description");
				// Bug 83804, Begin - Modified the If condition
				if (a > -1 || (__sOldLabel.Scan("@") != -1 && p_sSqlColumn.Scan("_DESC") != -1)) 
				{
					cColumnFin.c_sCodePartTemp = __sOldLabel.Mid(1, 1);
					cColumnFin.c_sCodePartValueTemp = SalString.FromHandle(Sal.SendMsg(i_hWndParent, Const.PAM_FetchCodePartValue, Sal.TblQueryContext(i_hWndParent), cColumnFin.c_sCodePartTemp.ToHandle()));

					if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Part_Value_API.Get_Description"))) 
					{
						return false;
					}
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Accounting_Code_Part_Value_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					// Insert new code here...
					// RUNTIME_CORRECTION: Used i_hWndSelf instead of i_hWndFrame since that doesn't refer to correct object cColumnFin
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndSelf.cColumnFin.c_sDescriptionTemp := " + cSessionManager.c_sDbPrefix + "Accounting_Code_Part_Value_API.Get_Description(\r\n" +
						":i_hWndSelf.cColumnFin.c_sCompany, :i_hWndSelf.cColumnFin.c_sCodePartTemp, :i_hWndSelf.cColumnFin.c_sCodePartValueTemp ) "))) 
						{
							return false;
						}
					}
					cColumnFin.c_hMyDescHandle = Sys.lParam.ToWindowHandle();
					Sal.SetWindowText(cColumnFin.c_hMyDescHandle, cColumnFin.c_sDescriptionTemp);
					return true;
				}
				// Bug 83804, End
				// When focus is on a codepart column
				else
				{
					a = __sOldLabel.Scan("@");
					if (a == -1) 
					{
						return false;
					}
					else
					{
						cColumnFin.c_sCodePart = __sOldLabel.Right(1);
						if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Part_Value_API.Get_Description"))) 
						{
							return false;
						}
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Accounting_Code_Part_Value_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						// Insert new code here...
						// RUNTIME_CORRECTION: Used i_hWndSelf instead of i_hWndFrame since that doesn't refer to correct object cColumnFinEuro
						if (!(DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndSelf.cColumnFin.c_sDescription := " + cSessionManager.c_sDbPrefix + "Accounting_Code_Part_Value_API.Get_Description(\r\n" +
							":i_hWndSelf.cColumnFin.c_sCompany, :i_hWndSelf.cColumnFin.c_sCodePart, :i_hWndSelf.cColumnFin.c_sCodePartValue ) "))) 
							{
								return false;
							}
						}
						cColumnFin.c_hMyDescHandle = Sys.lParam.ToWindowHandle();
						Sal.SetWindowText(cColumnFin.c_hMyDescHandle, cColumnFin.c_sDescription);
						return true;
					}
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean cGetCodePartValue()
		{
			#region Actions
			using (new SalContext(this))
			{
				cColumnFin.c_hMyCodePartHandle = Sys.lParam.ToWindowHandle();
				if (cColumnFin.c_sCodePartValue == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.SetWindowText(cColumnFin.c_hMyCodePartHandle, "NULL");
				}
				else
				{
					Sal.SetWindowText(cColumnFin.c_hMyCodePartHandle, cColumnFin.c_sCodePartValue);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean HideInternalCP()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.SendMsg(i_hWndFrame, Const.PAM_ShowInternalCP, 0, 0)) 
				{
					return false;
				}
				return true;
			}
			#endregion
		}

        /// <summary>
        /// </summary>
        /// <param name="sLable"></param>
        /// <returns></returns>
        public virtual SalBoolean MissingCharater(ref SalString sLable)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (sLable.Scan("@") == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sLable"></param>
        /// <returns></returns>
        public virtual SalNumber SetCharacter(ref SalString sLable)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (p_sSqlColumn == "ACCOUNT")
                {
                    sLable = "@A";
                }
                else if (p_sSqlColumn == "CODE_B")
                {
                    sLable = "@B";
                }
                else if (p_sSqlColumn == "CODE_C")
                {
                    sLable = "@C";
                }
                else if (p_sSqlColumn == "CODE_D")
                {
                    sLable = "@D";
                }
                else if (p_sSqlColumn == "CODE_E")
                {
                    sLable = "@E";
                }
                else if (p_sSqlColumn == "CODE_F")
                {
                    sLable = "@F";
                }
                else if (p_sSqlColumn == "CODE_G")
                {
                    sLable = "@G";
                }
                else if (p_sSqlColumn == "CODE_H")
                {
                    sLable = "@H";
                }
                else if (p_sSqlColumn == "CODE_I")
                {
                    sLable = "@I";
                }
                else if (p_sSqlColumn == "CODE_J")
                {
                    sLable = "@J";
                }
                else if (p_sSqlColumn == "ACCOUNT_DESC")
                {
                    // Bug Id 108346 Begin
                    if (sLable.ToString().IndexOf('\r') != -1)
                    {
                        sLable = sLable.ToString().Split(new char[] { '\r' })[1];
                        sLable = "@A" + "\r" + sLable;
                    }
                    // Bug Id 108346 End
                }
                else if (p_sSqlColumn == "CODE_B_DESC")
                {
                     // Bug Id 108346 Begin
                    if (sLable.ToString().IndexOf('\r') != -1)
                    {
                        sLable = sLable.ToString().Split(new char[] { '\r' })[1];
                        sLable = "@B" + "\r" + sLable;
                    }
                    // Bug Id 108346 End
                }
                else if (p_sSqlColumn == "CODE_C_DESC")
                {
                     // Bug Id 108346 Begin
                    if (sLable.ToString().IndexOf('\r') != -1)
                    {
                        sLable = sLable.ToString().Split(new char[] { '\r' })[1];
                        sLable = "@C" + "\r" + sLable;
                    }
                    // Bug Id 108346 End
                }
                else if (p_sSqlColumn == "CODE_D_DESC")
                {
                     // Bug Id 108346 Begin
                    if (sLable.ToString().IndexOf('\r') != -1)
                    {
                        sLable = sLable.ToString().Split(new char[] { '\r' })[1];
                        sLable = "@D" + "\r" + sLable;
                    }
                    // Bug Id 108346 End
                }
                else if (p_sSqlColumn == "CODE_E_DESC")
                {
                     // Bug Id 108346 Begin
                    if (sLable.ToString().IndexOf('\r') != -1)
                    {
                        sLable = sLable.ToString().Split(new char[] { '\r' })[1];
                        sLable = "@E" + "\r" + sLable;
                    }
                    // Bug Id 108346 End
                }
                else if (p_sSqlColumn == "CODE_F_DESC")
                {
                     // Bug Id 108346 Begin
                    if (sLable.ToString().IndexOf('\r') != -1)
                    {
                        sLable = sLable.ToString().Split(new char[] { '\r' })[1];
                        sLable = "@F" + "\r" + sLable;
                    }
                    // Bug Id 108346 End
                }
                else if (p_sSqlColumn == "CODE_G_DESC")
                {
                     // Bug Id 108346 Begin
                    if (sLable.ToString().IndexOf('\r') != -1)
                    {
                        sLable = sLable.ToString().Split(new char[] { '\r' })[1];
                        sLable = "@G" + "\r" + sLable;
                    }
                    // Bug Id 108346 End
                }
                else if (p_sSqlColumn == "CODE_H_DESC")
                {
                     // Bug Id 108346 Begin
                    if (sLable.ToString().IndexOf('\r') != -1)
                    {
                        sLable = sLable.ToString().Split(new char[] { '\r' })[1];
                        sLable = "@H" + "\r" + sLable;
                    }
                    // Bug Id 108346 End
                }
                else if (p_sSqlColumn == "CODE_I_DESC")
                {
                     // Bug Id 108346 Begin
                    if (sLable.ToString().IndexOf('\r') != -1)
                    {
                        sLable = sLable.ToString().Split(new char[] { '\r' })[1];
                        sLable = "@I" + "\r" + sLable;
                    }
                    // Bug Id 108346 End
                }
                else if (p_sSqlColumn == "CODE_J_DESC")
                {
                     // Bug Id 108346 Begin
                    if (sLable.ToString().IndexOf('\r') != -1)
                    {
                        sLable = sLable.ToString().Split(new char[] { '\r' })[1];
                        sLable = "@J" + "\r" + sLable;
                    }
                    // Bug Id 108346 End
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
		private void cColumnFin_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.cColumnFin_OnSAM_Create(sender, e);
					break;
				
				case Const.PAM_CallChanged:
					e.Handled = true;
					this.vrtCallChanged();
					break;
				
				case Sys.SAM_SetFocus:
					this.cColumnFin_OnSAM_SetFocus(sender, e);
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
					this.cColumnFin_OnSAM_KillFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
					this.cColumnFin_OnPM_DataItemLovUserWhere(sender, e);
					break;
				
				// Bug 72392 - Begin
				
				case Const.PAM_ChangeLovTitle:
					e.Handled = true;
					e.Return = Var.FinlibServices.GetTitle(SalString.FromHandle(Sys.lParam), this.p_sLovReference, this.__sOldLabel, this.i_hWndSelf).ToHandle();
					return;
				
				// Bug 72392 - End
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.cColumnFin_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnFin_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            this.__sOldLabel = this.GetColumnTitle(99);
            if (this.GetClassName() == "cColumnCodePartFin" || this.GetClassName() == "cColumnCodePartDescFin")
            {
                if (this.MissingCharater(ref this.__sOldLabel))
                {
                    this.SetCharacter(ref this.__sOldLabel);
                }
            }
            this.SendMessage(Const.PAM_CallChanged, 0, 0);
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnFin_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam))) 
			{
				e.Return = false;
				return;
			}
			cColumnFin.c_sCodePartValue = this.Text;
			if (!(cColumnFin.c_sCodePartValue == Ifs.Fnd.ApplicationForms.Const.strNULL)) 
			{
				Sal.SendMsgToChildren(this.i_hWndFrame, Const.PAM_GetChildCompany, 0, 0);
				// CONVERSION: Static code snippet replaced original source.
				// CONVERSION: Handle latebound problem. Latebound call was there due to compilation problems in CTD
				cDataSource.FromHandle(this.i_hWndFrame).UserGlobalValueGet("COMPANY", ref cColumnFin.c_sCompany);
				Sal.SendMsgToChildren(this.i_hWndFrame, Const.PAM_DescriptionFind, Sys.wParam, Sal.WindowHandleToNumber(this));
				// Bug 83804, Begin - Modified the If condition
				if (!(this.__sOldLabel.Scan("@EU") != -1 || this.__sOldLabel.Scan("@RATE") != -1 || this.__sOldLabel.Scan("QUANTITY") != -1 || this.__sOldLabel.Scan("TEXT") != -1 || this.__sOldLabel.Scan("DESCRIPTION") != -1 || (this.__sOldLabel.Scan("@") != 
				-1 && this.p_sSqlColumn.Scan("_DESC") != -1))) 
				{
					Sal.SendMsgToChildren(this.i_hWndFrame, Const.PAM_CellContentFind, Sys.wParam, Sal.WindowHandleToNumber(this));
				}
				// Bug 83804, End
			}
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_KillFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnFin_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
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
		
		/// <summary>
		/// PM_DataItemLovUserWhere event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnFin_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.__sVouDate = SalString.FromHandle(Sal.SendMsg(this.i_hWndFrame, Const.PAM_VoucherDateGet, 0, 0));
			this.__sUserGroup = SalString.FromHandle(Sal.SendMsg(this.i_hWndFrame, Const.PAM_UserGroupGet, 0, 0));
			if (this.__sVouDate != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				if (this.__sUserGroup != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					e.Return = ("( VALID_FROM <=  TO_DATE(" + "'" + this.__sVouDate + "'" + ", 'YYYY-MM-DD-HH24.MI.SS') AND VALID_UNTIL >= TO_DATE(" + "'" + this.__sVouDate + "'" + ", 'YYYY-MM-DD-HH24.MI.SS')\r\n" +
					"			  AND USER_GROUP = " + "'" + this.__sUserGroup + "'" + ")").ToHandle();
					return;
				}
				else
				{
					e.Return = ("( VALID_FROM <=  TO_DATE(" + "'" + this.__sVouDate + "'" + ", 'YYYY-MM-DD-HH24.MI.SS') AND VALID_UNTIL >= TO_DATE(" + "'" + this.__sVouDate + "'" + ", 'YYYY-MM-DD-HH24.MI.SS'))").ToHandle();
					return;
				}
			}
			e.Return = ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToNumber();
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnFin_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Ok) 
			{
				if (!(Sal.IsNull(this)) && (!(this.Text == Sys.STRING_Null))) 
				{
					if ((this.p_sSqlColumn.Scan("ACCOUNT") != -1) || (this.p_sSqlColumn.Scan("CODE\\_") != -1) && (this.p_sSqlColumn.Scan("_DESC") == -1)) 
					{
						if (!(Sal.WindowIsDerivedFromClass(this, typeof(cColumnCodePartFin)))) 
						{
							Sal.SendMsgToChildren(this.i_hWndParent, Const.PAM_SetCodePartDesc, this.p_sSqlColumn.ToHandle(), ((SalString)this.Text).ToHandle());
						}
					}
				}
				e.Return = Sys.VALIDATE_Ok;
				return;
			}
			e.Return = Sys.VALIDATE_Cancel;
			return;
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cColumnFin to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cColumnFin self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cColumnFin to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cColumnFin self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cColumnFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cColumnFin(cEditControlsManager super)
		{
			return ((cColumnFin)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cColumnFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cColumnFin(cSessionManager super)
		{
			return ((cColumnFin)((cEditControlsManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cColumnFin FromHandle(SalWindowHandle handle)
		{
			return ((cColumnFin)SalWindow.FromHandle(handle, typeof(cColumnFin)));
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
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalBoolean vrtHideInternalCP()
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.HideInternalCP();
			}
			else
			{
				return lateBind.vrtHideInternalCP();
			}
		}
		#endregion
		
		#region Multiple Inheritance Late Bind Interface
		
		public interface LateBind
		{
			SalNumber vrtCallChanged();
			SalBoolean vrtHideInternalCP();
		}
		#endregion
	}
}
