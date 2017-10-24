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
	/// The common functionality for all the codepart description fields is implemented here
	/// When codepart description columns were connected to this class, it will perform the following fuctions automatically
	/// 1. Disabling the description columns for the unused codepart columns
	/// 2. Synchronize with the user profile.
	/// </summary>
	public class cColumnCodePartDescFin : cColumnFinWithUserProfile
	{
		#region Fields
		[ThreadStatic]
		public static SalString c_sCompany;
		[ThreadStatic]
		public static SalString c_sCodePart;
		[ThreadStatic]
		public static SalString c_sCodePartValue;

		#region Static Fields initialization
		[ThreadStatic]
		private static bool threadStaticsInitialized;

		internal static void InitThreadStaticFields()
		{
			if (!threadStaticsInitialized)
			{
				threadStaticsInitialized = true;
				c_sCompany = "";
				c_sCodePart = "";
				c_sCodePartValue = "";
			}
		}
		#endregion

		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cColumnCodePartDescFin()
		{
			InitThreadStaticFields();
		
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cColumnCodePartDescFin(ISalWindow derived)
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
			// cColumnCodePartDescFin
			// 
			this.Name = "cColumnCodePartDescFin";
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cColumnCodePartDescFin_WindowActions);
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <param name="p_sCodePartColumnName"></param>
		/// <param name="p_sCodePartValue"></param>
		/// <returns></returns>
		public virtual SalBoolean SetCodePartDesc(SalString p_sCodePartColumnName, SalString p_sCodePartValue)
		{
			#region Local Variables
			SalString sMultiCompany = "";
			SalString lsStmt = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.IsWindowVisible(i_hWndSelf)) 
				{
					if ((p_sSqlColumn.Scan("ACCOUNT") != -1) || (p_sSqlColumn.Scan("CODE\\_") != -1)) 
					{
						cColumnCodePartDescFin.c_sCodePartValue = p_sCodePartValue;
						cColumnCodePartDescFin.c_sCompany = SalString.FromHandle(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.AM_UserProfileValueGet, 0, ((SalString)"COMPANY").ToHandle()));
						sMultiCompany = SalString.FromHandle(Sal.SendMsg(Sys.hWndForm, Const.PAM_GetMultiCompany, Sys.wParam, Sys.lParam));
						if (sMultiCompany != Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							cColumnCodePartDescFin.c_sCompany = sMultiCompany;
						}
						if (p_sSqlColumn.ToUpper() == (p_sCodePartColumnName + "_DESC").ToUpper()) 
						{
							if (Sal.WindowIsDerivedFromClass(i_hWndParent, typeof(cChildTableFin))) 
							{
								if (cChildTableFin.sCodePartDescription == SalString.Null) 
								{
									if (cColumnCodePartDescFin.c_sCodePartValue != SalString.Null) 
									{
										if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Text_Field_Translation_API.Get_Text")) 
										{
											if (p_sCodePartColumnName.Scan("ACCOUNT") != -1) 
											{
												lsStmt = ":cChildTableFin.sCodePartDescription := &AO.Text_Field_Translation_API.Get_Text(	:cColumnCodePartDescFin.c_sCompany,\r\n" +
												"										'CODEA',\r\n" +
												"										:cColumnCodePartDescFin.c_sCodePartValue )";
												using(SignatureHints hints = SignatureHints.NewContext())
												{
													hints.Add("Text_Field_Translation_API.Get_Text", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
													hints.Add("Text_Field_Translation_API.Get_Text", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
													// SignatureParseError!  lsStmt variable assigned to in more than one place in the method
													DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
												}
											}
											else if (p_sCodePartColumnName.Scan("CODE\\_") != -1) 
											{
												cColumnCodePartDescFin.c_sCodePart = p_sCodePartColumnName.Right(1);
												lsStmt = ":cChildTableFin.sCodePartDescription := &AO.Text_Field_Translation_API.Get_Text(	:cColumnCodePartDescFin.c_sCompany,\r\n" +
												"										'CODE' || :cColumnCodePartDescFin.c_sCodePart,\r\n" +
												"										:cColumnCodePartDescFin.c_sCodePartValue) ";
												using(SignatureHints hints = SignatureHints.NewContext())
												{
													hints.Add("Text_Field_Translation_API.Get_Text", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
													hints.Add("Text_Field_Translation_API.Get_Text", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
													// SignatureParseError!  lsStmt variable assigned to in more than one place in the method
													DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
												}
											}
											Sal.SetWindowText(i_hWndSelf, cChildTableFin.sCodePartDescription);
											cChildTableFin.sCodePartDescription = SalString.Null;
											return true;
										}
									}
								}
								else
								{
									Sal.SetWindowText(i_hWndSelf, cChildTableFin.sCodePartDescription);
									return true;
								}
							}
							else if (Sal.WindowIsDerivedFromClass(i_hWndParent, typeof(cTableWindowFin))) 
							{
								if (cTableWindowFin.sCodePartDescription == SalString.Null) 
								{
									if (cColumnCodePartDescFin.c_sCodePartValue != SalString.Null) 
									{
										if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Text_Field_Translation_API.Get_Text")) 
										{
											if (p_sCodePartColumnName.Scan("ACCOUNT") != -1) 
											{
												lsStmt = ":cTableWindowFin.sCodePartDescription := &AO.Text_Field_Translation_API.Get_Text(	:cColumnCodePartDescFin.c_sCompany,\r\n" +
												"										'CODEA',\r\n" +
												"										:cColumnCodePartDescFin.c_sCodePartValue )";
												using(SignatureHints hints = SignatureHints.NewContext())
												{
													hints.Add("Text_Field_Translation_API.Get_Text", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
													hints.Add("Text_Field_Translation_API.Get_Text", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
													// SignatureParseError!  lsStmt variable assigned to in more than one place in the method
													DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
												}
											}
											else if (p_sCodePartColumnName.Scan("CODE\\_") != -1) 
											{
												cColumnCodePartDescFin.c_sCodePart = p_sCodePartColumnName.Right(1);
												lsStmt = ":cTableWindowFin.sCodePartDescription := &AO.Text_Field_Translation_API.Get_Text(	:cColumnCodePartDescFin.c_sCompany,\r\n" +
												"										'CODE' || :cColumnCodePartDescFin.c_sCodePart,\r\n" +
												"										:cColumnCodePartDescFin.c_sCodePartValue) ";
												using(SignatureHints hints = SignatureHints.NewContext())
												{
													hints.Add("Text_Field_Translation_API.Get_Text", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
													hints.Add("Text_Field_Translation_API.Get_Text", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
													// SignatureParseError!  lsStmt variable assigned to in more than one place in the method
													DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
												}
											}
											Sal.SetWindowText(i_hWndSelf, cTableWindowFin.sCodePartDescription);
											cTableWindowFin.sCodePartDescription = SalString.Null;
											return true;
										}
									}
								}
								else
								{
									Sal.SetWindowText(i_hWndSelf, cTableWindowFin.sCodePartDescription);
									return true;
								}
							}
						}
					}
				}
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// Get code part demand (Blocked, Can, Mandatory) and set value if exists
		/// </summary>
		/// <param name="nPLength"></param>
		/// <param name="nPAttr"></param>
		/// <returns></returns>
		public virtual SalNumber SetCodePartDescription(SalNumber nPLength, SalNumber nPAttr)
		{
			#region Local Variables
			SalNumber i_nStrLength = 0;
			SalString i_lsAttr = "";
			SalString i_sReqAttr = "";
			SalString i_sReqAttrValue = "";
			SalString sReqField = "";
			SalString sReqFieldValue = "";
			SalString sColumnName = "";
            //Bug 127280, Begin
            SalString sColumnNameWithoutDesc = "";
            //Bug 127280, End
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
                //Bug 127280, Begin
                sColumnNameWithoutDesc = sColumnName.Left(6);
                sReqField = Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sColumnNameWithoutDesc, i_sReqAttr);
                //Bug 127280, End
				sReqFieldValue = Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sColumnName, i_sReqAttrValue);
                if (sReqFieldValue != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    if (sReqField.Trim().ToUpper() == "S")
                    {
                        Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)Ifs.Fnd.ApplicationForms.Const.strNULL).ToHandle());
                    }
                    else
                    {
                        Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sReqFieldValue.ToHandle());
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
		private void cColumnCodePartDescFin_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.cColumnCodePartDescFin_OnSAM_SetFocus(sender, e);
					break;
				
				case Const.PAM_SetCodePartDesc:
					e.Handled = true;
					e.Return = this.vrtSetCodePartDesc(SalString.FromHandle(Sys.wParam), SalString.FromHandle(Sys.lParam));
					return;
				
				case Const.PAM_SetCodePartDescription:
					e.Handled = true;
					e.Return = this.SetCodePartDescription(Sys.wParam, Sys.lParam);
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cColumnCodePartDescFin_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendMsg(this.i_hWndParent, Const.PAM_CodePartDescBlocked, this.p_sSqlColumn.ToHandle(), 0)) 
			{
                // Used this method as using Sal.SendMsg,Sal.PostMsg to send Tab key is not working properly in aurora client
                System.Windows.Forms.SendKeys.Send("{TAB}");
				return;
			}
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cColumnCodePartDescFin to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cColumnCodePartDescFin self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cColumnCodePartDescFin to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cColumnCodePartDescFin self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cColumnCodePartDescFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cColumnCodePartDescFin(cEditControlsManager super)
		{
			return ((cColumnCodePartDescFin)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cColumnCodePartDescFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cColumnCodePartDescFin(cSessionManager super)
		{
			return ((cColumnCodePartDescFin)((cEditControlsManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cColumnCodePartDescFin FromHandle(SalWindowHandle handle)
		{
			return ((cColumnCodePartDescFin)SalWindow.FromHandle(handle, typeof(cColumnCodePartDescFin)));
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalBoolean vrtSetCodePartDesc(SalString p_sCodePartColumnName, SalString p_sCodePartValue)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.SetCodePartDesc(p_sCodePartColumnName, p_sCodePartValue);
			}
			else
			{
				return lateBind.vrtSetCodePartDesc(p_sCodePartColumnName, p_sCodePartValue);
			}
		}
		#endregion
		
		#region Multiple Inheritance Late Bind Interface
		
		public interface LateBind
		{
			SalBoolean vrtSetCodePartDesc(SalString p_sCodePartColumnName, SalString p_sCodePartValue);
		}
		#endregion
	}
}
