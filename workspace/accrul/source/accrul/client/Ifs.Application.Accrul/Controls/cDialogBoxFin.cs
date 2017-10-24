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
// 12-09-12    KAGALK    Bug 103031, Modified to display code parts according to the user profile
// 13-07-02    MAAYLK    Bug 109903, Replaced bug 103031 with a diffenect correction
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
	/// </summary>
	public partial class cDialogBoxFin : cDialogBox
	{
		// Multiple Inheritance: Base class instance.
		protected cFinlibServices _cFinlibServices;
		
		
		#region Fields
		public SalString i_sCompany = "";
		public SalString i_sCompanyHelp = "";
		public SalString i_sChildText = "";
		public SalWindowHandle i_hWndLOV = SalWindowHandle.Null;
		public SalString i_sOldLabel = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cDialogBoxFin()
		{
			// Initialize second-base instances.
			InitializeMultipleInheritance();
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cDialogBoxFin(ISalWindow derived)
		{
			// Attach derived instance.
			this._derived = derived;
			// Initialize second-base instances.
			InitializeMultipleInheritance();
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Attach actions handler to derived instance.
			this._derived.AttachMessageActions(this);
		}
		#endregion
		
		#region Multiple Inheritance Fields
        // Bug 109903, Removed Bug 103031
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString __sVisibility
		{
			get { return _cFinlibServices.__sVisibility; }
			set { _cFinlibServices.__sVisibility = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalArray<SalString> __sDefVisibilityArray
		{
			get { return _cFinlibServices.__sDefVisibilityArray; }
			set { _cFinlibServices.__sDefVisibilityArray = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalArray<SalString> sPlaceHolders
		{
			get { return _cFinlibServices.sPlaceHolders; }
			set { _cFinlibServices.sPlaceHolders = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalArray<SalString> __sVisibilityArray
		{
			get { return _cFinlibServices.__sVisibilityArray; }
			set { _cFinlibServices.__sVisibilityArray = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString __sDefVisibility
		{
			get { return _cFinlibServices.__sDefVisibility; }
			set { _cFinlibServices.__sDefVisibility = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber nInit
		{
			get { return _cFinlibServices.nInit; }
			set { _cFinlibServices.nInit = value; }
		}
        // Bug 109903, Removed Bug 103031
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString __sProfileSection
		{
			get { return _cFinlibServices.__sProfileSection; }
			set { _cFinlibServices.__sProfileSection = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString sCompChanged
		{
			get { return _cFinlibServices.sCompChanged; }
			set { _cFinlibServices.sCompChanged = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString sFinIsThirdEMU
		{
			get { return _cFinlibServices.sFinIsThirdEMU; }
			set { _cFinlibServices.sFinIsThirdEMU = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString i_sFinCurrencyCode
		{
			get { return _cFinlibServices.i_sFinCurrencyCode; }
			set { _cFinlibServices.i_sFinCurrencyCode = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber i_nFinConversionFactor
		{
			get { return _cFinlibServices.i_nFinConversionFactor; }
			set { _cFinlibServices.i_nFinConversionFactor = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString i_sFinThirdCurrencyCode
		{
			get { return _cFinlibServices.i_sFinThirdCurrencyCode; }
			set { _cFinlibServices.i_sFinThirdCurrencyCode = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString sFinCurrencyCode
		{
			get { return _cFinlibServices.sFinCurrencyCode; }
			set { _cFinlibServices.sFinCurrencyCode = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString i_sFinBaseCurrencyCode
		{
			get { return _cFinlibServices.i_sFinBaseCurrencyCode; }
			set { _cFinlibServices.i_sFinBaseCurrencyCode = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString i_sFinCurrencyType
		{
			get { return _cFinlibServices.i_sFinCurrencyType; }
			set { _cFinlibServices.i_sFinCurrencyType = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber i_nFinCurrencyRate
		{
			get { return _cFinlibServices.i_nFinCurrencyRate; }
			set { _cFinlibServices.i_nFinCurrencyRate = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalDateTime i_dFinDate
		{
			get { return _cFinlibServices.i_dFinDate; }
			set { _cFinlibServices.i_dFinDate = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString i_sFinCompany
		{
			get { return _cFinlibServices.i_sFinCompany; }
			set { _cFinlibServices.i_sFinCompany = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalBoolean bGetRate
		{
			get { return _cFinlibServices.bGetRate; }
			set { _cFinlibServices.bGetRate = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString i_sFinIsBaseEMU
		{
			get { return _cFinlibServices.i_sFinIsBaseEMU; }
			set { _cFinlibServices.i_sFinIsBaseEMU = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString i_lsFinInverted
		{
			get { return _cFinlibServices.i_lsFinInverted; }
			set { _cFinlibServices.i_lsFinInverted = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString i_sFinIsThirdEMU
		{
			get { return _cFinlibServices.i_sFinIsThirdEMU; }
			set { _cFinlibServices.i_sFinIsThirdEMU = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber i_nFinRound
		{
			get { return _cFinlibServices.i_nFinRound; }
			set { _cFinlibServices.i_nFinRound = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString sFinThirdCurrencyCode
		{
			get { return _cFinlibServices.sFinThirdCurrencyCode; }
			set { _cFinlibServices.sFinThirdCurrencyCode = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalDateTime dFinDate
		{
			get { return _cFinlibServices.dFinDate; }
			set { _cFinlibServices.dFinDate = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString sFinCurrencyType
		{
			get { return _cFinlibServices.sFinCurrencyType; }
			set { _cFinlibServices.sFinCurrencyType = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber i_nFinTransRound
		{
			get { return _cFinlibServices.i_nFinTransRound; }
			set { _cFinlibServices.i_nFinTransRound = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber i_nFinThirdRound
		{
			get { return _cFinlibServices.i_nFinThirdRound; }
			set { _cFinlibServices.i_nFinThirdRound = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString i_lsFinThirdInverted
		{
			get { return _cFinlibServices.i_lsFinThirdInverted; }
			set { _cFinlibServices.i_lsFinThirdInverted = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString sFinCompany
		{
			get { return _cFinlibServices.sFinCompany; }
			set { _cFinlibServices.sFinCompany = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString sFinIsBaseEMU
		{
			get { return _cFinlibServices.sFinIsBaseEMU; }
			set { _cFinlibServices.sFinIsBaseEMU = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber i_nFinBaseRound
		{
			get { return _cFinlibServices.i_nFinBaseRound; }
			set { _cFinlibServices.i_nFinBaseRound = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString sFinBaseCurrencyCode
		{
			get { return _cFinlibServices.sFinBaseCurrencyCode; }
			set { _cFinlibServices.sFinBaseCurrencyCode = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber i_nFinTransAmountRound
		{
			get { return _cFinlibServices.i_nFinTransAmountRound; }
			set { _cFinlibServices.i_nFinTransAmountRound = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber i_nFinThirdCurrencyRate
		{
			get { return _cFinlibServices.i_nFinThirdCurrencyRate; }
			set { _cFinlibServices.i_nFinThirdCurrencyRate = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalBoolean bThirdGetRate
		{
			get { return _cFinlibServices.bThirdGetRate; }
			set { _cFinlibServices.bThirdGetRate = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber i_nFinThirdConversionFactor
		{
			get { return _cFinlibServices.i_nFinThirdConversionFactor; }
			set { _cFinlibServices.i_nFinThirdConversionFactor = value; }
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean FinDlgCheckCompany()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (i_sCompany == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Ifs.Fnd.ApplicationForms.Int.InfoBox(Properties.Resources.FINTXT_DlgLovCompanyMissing);
					return Sal.EndDialog(i_hWndSelf, Sys.IDCANCEL);
				}
				else
				{
					return true;
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean FinDlgCheckState(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						MethodStateChanged(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_AnyMethod);
						return true;
					
					default:
						return true;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sFaCompany"></param>
		/// <returns></returns>
		public virtual SalBoolean GetChangedFinCompany(ref SalString sFaCompany)
		{
			#region Local Variables
			SalString sCompany = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				UserGlobalValueGet("COMPANY", ref sCompany);
				if (i_sCompany == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					sFaCompany = sCompany;
					return true;
				}
				else
				{
					if (i_sCompany != sCompany) 
					{
						sFaCompany = sCompany;
						return true;
					}
				}
				return false;
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean ListOfValues(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return Sal.SendMsg(i_hWndLOV, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						return Sal.PostMsg(i_hWndLOV, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					
					default:
						return true;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// Late bound function defining values in combo boxes via parameter input
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean SetComboBoxValues()
		{
			#region Actions
			using (new SalContext(this))
			{
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// Late bound function defining window data fields via parameter input
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean SetDataFieldValues()
		{
			#region Actions
			using (new SalContext(this))
			{
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sMethod"></param>
		/// <returns></returns>
		public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
		{
			#region Actions
			using (new SalContext(this))
			{
				Ifs.Fnd.ApplicationForms.Int.InfoBox(Properties.Resources.FINTXT_DlgLovMissInstFun);
				return Sal.EndDialog(i_hWndSelf, Sys.IDCANCEL);
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean FinDlgSetWindowTitle()
		{
			#region Actions
			using (new SalContext(this))
			{
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// Obsalete Function - Finance 8.5
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean SetFinWindowTitle()
		{
			#region Actions
			using (new SalContext(this))
			{
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean SetWindowTitle()
		{
			#region Local Variables
			SalArray<SalString> sParameters = new SalArray<SalString>();
			SalString sWindowTitle = "";
			SalString sCurrentWindowTitle = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (!(this.vrtSetFinWindowTitle())) 
				{
					sParameters[0] = i_sCompany;
					sCurrentWindowTitle = this.vrtGetWindowTitle();
					sCurrentWindowTitle = sCurrentWindowTitle;
					if (sCurrentWindowTitle.Scan("&0") != -1) 
					{
						sWindowTitle = Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams(sCurrentWindowTitle, sParameters);
					}
					else if (sCurrentWindowTitle.Scan(":") != -1) 
					{
						if (this.vrtShowActiveCompany()) 
						{
							sWindowTitle = Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams(Vis.StrSubstitute(sCurrentWindowTitle, ":", ": &0 -"), sParameters);
						}
						else
						{
							sWindowTitle = Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams(sCurrentWindowTitle, sParameters);
						}
					}
					else
					{
						if (this.vrtShowActiveCompany()) 
						{
							sWindowTitle = Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams("&0 - " + sCurrentWindowTitle, sParameters);
						}
						else
						{
							sWindowTitle = Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams(sCurrentWindowTitle, sParameters);
						}
					}
					FinTranslateStringCodePart(i_sCompany, cSessionManager.c_sDbPrefix, ref sWindowTitle);
					Sal.SetWindowText(i_hWndSelf, sWindowTitle);
					return true;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalString GetWindowTitle()
		{
			#region Actions
			using (new SalContext(this))
			{
				return i_sOldLabel;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ShowActiveCompany()
		{
			#region Actions
			using (new SalContext(this))
			{
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber ChangeCompany(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgChangeCompanyFin"))) 
                        {
                            return !(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0));
                        }
                        return false;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						Var.FinlibServices.DoChangeCompany(i_hWndFrame);
						break;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sSetName"></param>
		/// <returns></returns>
		public virtual SalNumber SetCompany(SalString sSetName)
		{
			#region Actions
			using (new SalContext(this))
			{
				i_sCompany = sSetName;
				UserGlobalValueSet("COMPANY", i_sCompany);
				this.vrtSetWindowTitle();
				Sal.SendMsgToChildren(i_hWndSelf, Const.PAM_CallChanged, 0, 0);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="hWndProfileWindow"></param>
		/// <param name="sEntryName"></param>
		/// <param name="sValue"></param>
		/// <returns></returns>
		public virtual SalNumber SetProfileValue(SalWindowHandle hWndProfileWindow, SalString sEntryName, SalString sValue)
		{
			#region Local Variables
			SalString sProfileSection = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sProfileSection = Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(hWndProfileWindow);
				Ifs.Fnd.ApplicationForms.Var.Profile.ValueSet(sProfileSection, sEntryName, sValue);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="hWndProfileWindow"></param>
		/// <param name="sEntryName"></param>
		/// <param name="sDefValue"></param>
		/// <returns></returns>
		public virtual SalString GetProfileValue(SalWindowHandle hWndProfileWindow, SalString sEntryName, SalString sDefValue)
		{
			#region Local Variables
			SalString sProfileSection = "";
			SalString sProfileValue = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sProfileSection = Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(hWndProfileWindow);
				Ifs.Fnd.ApplicationForms.Var.Profile.ValueStringGet(sProfileSection, sEntryName, sDefValue, ref sProfileValue);
				return sProfileValue;
			}
			#endregion
		}
		// Bug 72392 - Begin
		/// <summary>
		/// </summary>
		/// <param name="sReference"></param>
		/// <param name="sReturnKeyName"></param>
		/// <param name="sColumnNames"></param>
		/// <param name="sColumnPrompts"></param>
		/// <returns></returns>
		public virtual new SalBoolean DataSourceReferenceItems(SalString sReference, SalString sReturnKeyName, SalArray<SalString> sColumnNames, SalArray<SalString> sColumnPrompts)
		{
			#region Actions
			using (new SalContext(this))
			{
				return Var.FinlibServices.DataSourceReferenceItems(sReference, sReturnKeyName, sColumnNames, i_hWndChild, i_nChildCount, sColumnPrompts);
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
		private void cDialogBoxFin_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Const.PAM_ChangedChildText:
					this.cDialogBoxFin_OnPAM_ChangedChildText(sender, e);
					break;
				
				case Const.PAM_DlgCheckState:
					e.Handled = true;
					e.Return = this.vrtFinDlgCheckState(Sys.wParam);
					return;
				
				case Const.PAM_DlgFocusFirst:
					e.Handled = true;
					Sal.SendMsg(this.i_hWndSelf, Const.PAM_DlgSetLovState, Ifs.Fnd.ApplicationForms.Int.PalGetFocus().ToNumber(), 0);
					break;
				
				case Const.PAM_DlgSetCombo:
					e.Handled = true;
					e.Return = this.vrtSetComboBoxValues();
					return;
				
				case Const.PAM_DlgSetDataFieldValues:
					e.Handled = true;
					e.Return = this.vrtSetDataFieldValues();
					return;
				
				case Const.PAM_DlgSetDefPb:
					e.Handled = true;
					Sal.SendMsgToChildren(this.i_hWndSelf, Const.PAM_DlgSetDefPb, 0, 0);
					break;
				
				case Const.PAM_DlgSetLovState:
					this.cDialogBoxFin_OnPAM_DlgSetLovState(sender, e);
					break;
				
				case Const.PAM_GetAndSetDefaultCompany:
					e.Handled = true;
					this.GetChangedFinCompany(ref this.i_sCompany);
					break;
								
				case Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged:
					this.cDialogBoxFin_OnPM_UserProfileChanged(sender, e);
					break;
				
				case Const.PAM_ChangeCompany:
					this.cDialogBoxFin_OnPAM_ChangeCompany(sender, e);
					break;
				
				case Sys.SAM_CreateComplete:
					this.cDialogBoxFin_OnSAM_CreateComplete(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_ChangedChildText event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cDialogBoxFin_OnPAM_ChangedChildText(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			// Translate a child text
			this.i_sChildText = SalString.FromHandle(Sys.lParam);
			if (this.i_sCompany == Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				this.UserGlobalValueGet("COMPANY", ref this.i_sCompanyHelp);
			}
			else
			{
				this.i_sCompanyHelp = this.i_sCompany;
			}
			if (!(this.FinTranslateStringCodePart(this.i_sCompanyHelp, cSessionManager.c_sDbPrefix, ref this.i_sChildText))) 
			{
				this.i_sChildText = Ifs.Fnd.ApplicationForms.Const.strNULL;
			}
			e.Return = this.i_sChildText.ToHandle();
			return;
			#endregion
		}
		
		/// <summary>
		/// PAM_DlgSetLovState event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cDialogBoxFin_OnPAM_DlgSetLovState(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.i_hWndLOV = Sys.lParam.ToWindowHandle();
			Sal.PostMsg(this.i_hWndSelf, Const.PAM_DlgCheckState, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_UserProfileChanged event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cDialogBoxFin_OnPM_UserProfileChanged(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			// Get all changed variables
			if (this.GetChangedFinCompany(ref this.i_sCompany)) 
			{
				// Clear form
				this.DataSourceClear(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				this.vrtSetWindowTitle();
				Sal.SendMsgToChildren(this.i_hWndSelf, Const.PAM_CallChanged, 0, 0);
				e.Return = true;
				return;
			}
			else
			{
				e.Return = false;
				return;
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_ChangeCompany event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cDialogBoxFin_OnPAM_ChangeCompany(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			switch (Sys.wParam)
			{
				case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
					e.Return = this.ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
					return;
				
				case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
					this.ChangeCompany(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_CreateComplete event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cDialogBoxFin_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.GetWindowText(this.i_hWndSelf, ref this.i_sOldLabel, 99);
			// If no data source then tell the child fields that they are updatable and make the dialog
			// believe that it's populated in order to be able to input data
			if (this.p_sViewName == Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				Sal.SendMsgToChildren(this.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemFlagSet, Ifs.Fnd.ApplicationForms.Const.FIELD_Update, 1);
				Sal.SendMsgToChildren(this.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, 0, 0);
			}
			// Initiate instance variable for company
			if (this.i_sCompany == Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				Sal.SendMsg(this.i_hWndSelf, Const.PAM_GetAndSetDefaultCompany, 0, 0);
			}
			// Send message that takes care of defining field values via window parameters
			Sal.SendMsg(this.i_hWndSelf, Const.PAM_DlgSetDataFieldValues, 0, 0);
			// Values in combo boxes are set via message FTR_DlgSetCombo
			//  Add this message in instance and set value in combo boxes via window parameters
			Sal.PostMsg(this.i_hWndSelf, Const.PAM_DlgSetCombo, 0, 0);
			// Make sure that LOV (and dialog) button shows correct state
			Sal.PostMsg(this.i_hWndSelf, Const.PAM_DlgFocusFirst, 0, 0);
			// Post message that will make sure that default push button message is sent to children
			Sal.PostMsg(this.i_hWndSelf, Const.PAM_DlgSetDefPb, 0, 0);
			// Check that company has been set and define window title
			this.vrtFinDlgCheckCompany();
			this.vrtSetWindowTitle();
			Sal.WaitCursor(false);
			Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam);
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber AddToDefProfile()
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.AddToDefProfile();
			}
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber AddToProfile()
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.AddToProfile();
			}
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber ClearVisibilityArray()
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.ClearVisibilityArray();
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sReference"></param>
		/// <param name="sReturnKeyName"></param>
		/// <param name="sColumnNames"></param>
		/// <param name="hWndChild"></param>
		/// <param name="nChildCount"></param>
		/// <param name="sColumnPrompts"></param>
		/// <returns></returns>
		public virtual new SalBoolean DataSourceReferenceItems(SalString sReference, SalString sReturnKeyName, SalArray<SalString> sColumnNames, SalArray<SalWindowHandle> hWndChild, SalNumber nChildCount, SalArray<SalString> sColumnPrompts)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.DataSourceReferenceItems(sReference, sReturnKeyName, sColumnNames, hWndChild, nChildCount, sColumnPrompts);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="hWndActualForm"></param>
		/// <returns></returns>
		public virtual SalNumber DoChangeCompany(SalWindowHandle hWndActualForm)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.DoChangeCompany(hWndActualForm);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sAppOwner"></param>
		/// <param name="sText"></param>
		/// <returns></returns>
		public virtual SalBoolean FinTranslateStringCodePart(SalString sCompany, SalString sAppOwner, ref SalString sText)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.FinTranslateStringCodePart(sCompany, sAppOwner, ref sText);
			}
		}
		
		/// <summary>
		/// Returns the actual currency rate without rounding
		/// </summary>
		/// <param name="nAmount"></param>
		/// <param name="nCurrencyAmount"></param>
		/// <param name="nActCurrencyRate"></param>
		/// <returns></returns>
		public virtual SalBoolean GetActualCurrencyRate(SalNumber nAmount, SalNumber nCurrencyAmount, ref SalNumber nActCurrencyRate)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.GetActualCurrencyRate(nAmount, nCurrencyAmount, ref nActCurrencyRate);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nCurrencyAmount"></param>
		/// <param name="nRate"></param>
		/// <param name="nAmount"></param>
		/// <returns></returns>
		public virtual SalBoolean GetBaseCurrAmountForRate(SalNumber nCurrencyAmount, SalNumber nRate, ref SalNumber nAmount)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.GetBaseCurrAmountForRate(nCurrencyAmount, nRate, ref nAmount);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nCurrencyAmount"></param>
		/// <param name="nAmount"></param>
		/// <returns></returns>
		public virtual SalBoolean GetBaseCurrencyAmount(SalNumber nCurrencyAmount, ref SalNumber nAmount)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.GetBaseCurrencyAmount(nCurrencyAmount, ref nAmount);
			}
		}
		
		/// <summary>
		/// This function will return the code part connected to the code part function given by the input parameter sFunction.
		/// If you are calling this function from a window where you don't have any code parts, first call RefreshCodePartInfo.
		/// </summary>
		/// <param name="sFunction"></param>
		/// <returns></returns>
		public virtual SalString GetCodePartFunction(SalString sFunction)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.GetCodePartFunction(sFunction);
			}
		}
		
		/// <summary>
		/// Gets CodePart Names from Server
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sAppOwner"></param>
		/// <returns></returns>
		public virtual SalBoolean GetCodePartNames(SalString sCompany, SalString sAppOwner)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.GetCodePartNames(sCompany);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nAmount"></param>
		/// <param name="nCurrencyAmount"></param>
		/// <param name="nCurrencyRate"></param>
		/// <returns></returns>
		public virtual SalBoolean GetCurrencyRate(SalNumber nAmount, SalNumber nCurrencyAmount, ref SalNumber nCurrencyRate)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.GetCurrencyRate(nAmount, nCurrencyAmount, ref nCurrencyRate);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nAmount"></param>
		/// <param name="nThirdCurrencyAmount"></param>
		/// <returns></returns>
		public virtual SalBoolean GetThirdCurrencyAmount(SalNumber nAmount, ref SalNumber nThirdCurrencyAmount)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.GetThirdCurrencyAmount(nAmount, ref nThirdCurrencyAmount);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sReference"></param>
		/// <param name="sLovReference"></param>
		/// <param name="sOldLabel"></param>
		/// <param name="hWndSelf"></param>
		/// <returns></returns>
		public virtual SalString GetTitle(SalString sReference, SalString sLovReference, SalString sOldLabel, SalWindowHandle hWndSelf)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.GetTitle(sReference, sLovReference, sOldLabel, hWndSelf);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="p_hWnd"></param>
		/// <returns></returns>
		public virtual SalWindowHandle GetTopForm(SalWindowHandle p_hWnd)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.GetTopForm(p_hWnd);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nAmount"></param>
		/// <param name="nRate"></param>
		/// <param name="nCurrencyAmount"></param>
		/// <returns></returns>
		public virtual SalBoolean GetTransCurrAmountForRate(SalNumber nAmount, SalNumber nRate, ref SalNumber nCurrencyAmount)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.GetTransCurrAmountForRate(nAmount, nRate, ref nCurrencyAmount);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nAmount"></param>
		/// <param name="nCurrencyAmount"></param>
		/// <returns></returns>
		public virtual SalBoolean GetTransCurrencyAmount(SalNumber nAmount, ref SalNumber nCurrencyAmount)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.GetTransCurrencyAmount(nAmount, ref nCurrencyAmount);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sSqlColumn"></param>
		/// <param name="sDisableWindow"></param>
		/// <returns></returns>
		public virtual SalBoolean GetUnusedCodeParts(SalString sCompany, SalString sSqlColumn, ref SalString sDisableWindow)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.GetUnusedCodeParts(sCompany, sSqlColumn, ref sDisableWindow);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nCount"></param>
		/// <param name="nColPosition"></param>
		/// <returns></returns>
		public virtual SalNumber GetVisibility(SalNumber nCount, SalNumber nColPosition)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.GetVisibility(nCount, nColPosition);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sCurrencyCode"></param>
		/// <param name="sBaseCurrencyCode"></param>
		/// <param name="sCurrencyType"></param>
		/// <param name="dDate"></param>
		/// <returns></returns>
		public virtual SalBoolean IsEqualFinCatch(SalString sCompany, SalString sCurrencyCode, SalString sBaseCurrencyCode, SalString sCurrencyType, SalDateTime dDate)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.IsEqualFinCatch(sCompany, sCurrencyCode, sBaseCurrencyCode, sCurrencyType, dDate);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sThirdCurrencyCode"></param>
		/// <param name="sBaseCurrencyCode"></param>
		/// <param name="dDate"></param>
		/// <param name="sIsThirdEMU"></param>
		/// <param name="sIsBaseEMU"></param>
		/// <returns></returns>
		public virtual SalBoolean IsEqualFinThirdCatch(SalString sCompany, SalString sThirdCurrencyCode, SalString sBaseCurrencyCode, SalDateTime dDate, SalString sIsThirdEMU, SalString sIsBaseEMU)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.IsEqualFinThirdCatch(sCompany, sThirdCurrencyCode, sBaseCurrencyCode, dDate, sIsThirdEMU, sIsBaseEMU);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sLovReference"></param>
		/// <returns></returns>
		public virtual SalString LovViewNameGet(SalString sLovReference)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.LovViewNameGet(sLovReference);
			}
		}
		
		/// <summary>
		/// Compare the Default settings with the newly modified used unused code parts
		/// </summary>
		/// <param name="nModCount"></param>
		/// <param name="nDefCount"></param>
		/// <returns></returns>
		public virtual SalBoolean MatchDefaultArray(SalNumber nModCount, SalNumber nDefCount)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.MatchDefaultArray(nModCount, nDefCount);
			}
		}
		
		/// <summary>
		/// This function will refresh lsDisplayCodePart, lsCodePartFunction and sCodePartName arrays,
		///  if company or database has been changed or sCodePartName is empty.
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sAppOwner"></param>
		/// <returns></returns>
		public virtual SalBoolean RefreshCodePartInfo(SalString sCompany, SalString sAppOwner)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.RefreshCodePartInfo(sCompany);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nAmount"></param>
		/// <param name="nRound"></param>
		/// <returns></returns>
		public virtual SalNumber RoundOf(SalNumber nAmount, SalNumber nRound)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.RoundOf(nAmount, nRound);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="p_sRoundingMethod"></param>
		/// <param name="p_nAmount"></param>
		/// <param name="p_nNoOfDec"></param>
		/// <returns></returns>
		public virtual SalNumber RoundOfTax(SalString p_sRoundingMethod, SalNumber p_nAmount, SalNumber p_nNoOfDec)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.RoundOfTax(p_sRoundingMethod, p_nAmount, p_nNoOfDec);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sCurrencyCode"></param>
		/// <param name="sBaseCurrencyCode"></param>
		/// <param name="sCurrencyType"></param>
		/// <param name="dDate"></param>
		/// <returns></returns>
		public virtual SalBoolean SetCache(SalString sCompany, SalString sCurrencyCode, SalString sBaseCurrencyCode, SalString sCurrencyType, SalDateTime dDate)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.SetCache(sCompany, sCurrencyCode, sBaseCurrencyCode, sCurrencyType, dDate);
			}
		}

		//Bug 109903, Begin
		/// <summary>
        /// This method will update Finance specific profile variable 'ColVisibilityFin' if the user has deliberately, changed the visibility of any column.
		/// Codepart columns that are invisible merely because they are 'Not Used' in the company should not be saved to the profile
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SetCodepartVisibilityInProfile()
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.SetCodepartVisibilityInProfile();
			}
		}
		//Bug 109903, End
		
		/// <summary>
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sCurrencyCode"></param>
		/// <param name="sBaseCurrencyCode"></param>
		/// <param name="sCurrencyType"></param>
		/// <param name="dDate"></param>
		/// <returns></returns>
		public virtual SalBoolean SetFinCache(SalString sCompany, SalString sCurrencyCode, SalString sBaseCurrencyCode, SalString sCurrencyType, SalDateTime dDate)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.SetFinCache(sCompany, sCurrencyCode, sBaseCurrencyCode, sCurrencyType, dDate);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sThirdCurrencyCode"></param>
		/// <param name="sBaseCurrencyCode"></param>
		/// <param name="dDate"></param>
		/// <param name="sIsThirdEMU"></param>
		/// <param name="sIsBaseEMU"></param>
		/// <returns></returns>
		public virtual SalBoolean SetFinThirdCache(SalString sCompany, SalString sThirdCurrencyCode, SalString sBaseCurrencyCode, SalDateTime dDate, SalString sIsThirdEMU, SalString sIsBaseEMU)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.SetFinThirdCache(sCompany, sThirdCurrencyCode, sBaseCurrencyCode, dDate, sIsThirdEMU, sIsBaseEMU);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sThirdCurrencyCode"></param>
		/// <param name="sBaseCurrencyCode"></param>
		/// <param name="dDate"></param>
		/// <param name="sIsThirdEMU"></param>
		/// <param name="sIsBaseEMU"></param>
		/// <returns></returns>
		public virtual SalBoolean SetThirdCache(SalString sCompany, SalString sThirdCurrencyCode, SalString sBaseCurrencyCode, SalDateTime dDate, SalString sIsThirdEMU, SalString sIsBaseEMU)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.SetThirdCache(sCompany, sThirdCurrencyCode, sBaseCurrencyCode, dDate, sIsThirdEMU, sIsBaseEMU);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="hWndProfileWindow"></param>
		/// <returns></returns>
		public virtual SalNumber SynchronizeWithProfile(SalWindowHandle hWndProfileWindow)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.SynchronizeWithProfile(hWndProfileWindow);
			}
		}
        // Bug 109903, Removed Bug 103031
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDialogBoxFin to type cDataSource.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cDataSource(cDialogBoxFin self)
		{
			return self._cDataSource;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDialogBoxFin to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cDialogBoxFin self)
		{
			return ((cSessionManager)self._cDataSource);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDialogBoxFin to type cWindowTranslation.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cWindowTranslation(cDialogBoxFin self)
		{
			return ((cWindowTranslation)self._cDataSource);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDialogBoxFin to type cFinlibServices.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cFinlibServices(cDialogBoxFin self)
		{
			return self._cFinlibServices;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataSource to type cDialogBoxFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDialogBoxFin(cDataSource super)
		{
			return ((cDialogBoxFin)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cDialogBoxFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDialogBoxFin(cSessionManager super)
		{
			return ((cDialogBoxFin)((cDataSource)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cWindowTranslation to type cDialogBoxFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDialogBoxFin(cWindowTranslation super)
		{
			return ((cDialogBoxFin)((cDataSource)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cFinlibServices to type cDialogBoxFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cDialogBoxFin(cFinlibServices super)
		{
			return ((cDialogBoxFin)super._derived);
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Multiple Inheritance: Initialize delegate instances.
		/// </summary>
		private void InitializeMultipleInheritance()
		{
			this._cFinlibServices = new cFinlibServices(this);
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cDialogBoxFin FromHandle(SalWindowHandle handle)
		{
			return ((cDialogBoxFin)SalWindow.FromHandle(handle, typeof(cDialogBoxFin)));
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtDataSourceReferenceItems(SalString sReference, SalString sReturnKeyName, SalArray<SalString> sColumnNames, SalArray<SalString> sColumnPrompts)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.DataSourceReferenceItems(sReference, sReturnKeyName, sColumnNames, sColumnPrompts);
			}
			else
			{
				return lateBind.vrtDataSourceReferenceItems(sReference, sReturnKeyName, sColumnNames, sColumnPrompts);
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalBoolean vrtFinDlgCheckCompany()
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.FinDlgCheckCompany();
			}
			else
			{
				return lateBind.vrtFinDlgCheckCompany();
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalBoolean vrtFinDlgCheckState(SalNumber nWhat)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.FinDlgCheckState(nWhat);
			}
			else
			{
				return lateBind.vrtFinDlgCheckState(nWhat);
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalString vrtGetWindowTitle()
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.GetWindowTitle();
			}
			else
			{
				return lateBind.vrtGetWindowTitle();
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalBoolean vrtSetComboBoxValues()
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.SetComboBoxValues();
			}
			else
			{
				return lateBind.vrtSetComboBoxValues();
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalBoolean vrtSetDataFieldValues()
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.SetDataFieldValues();
			}
			else
			{
				return lateBind.vrtSetDataFieldValues();
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalBoolean vrtSetFinWindowTitle()
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.SetFinWindowTitle();
			}
			else
			{
				return lateBind.vrtSetFinWindowTitle();
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalBoolean vrtSetWindowTitle()
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.SetWindowTitle();
			}
			else
			{
				return lateBind.vrtSetWindowTitle();
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalBoolean vrtShowActiveCompany()
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.ShowActiveCompany();
			}
			else
			{
				return lateBind.vrtShowActiveCompany();
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.UserMethod(nWhat, sMethod);
			}
			else
			{
				return lateBind.vrtUserMethod(nWhat, sMethod);
			}
		}
		#endregion
		
		#region Multiple Inheritance Late Bind Interface
		
		public interface LateBind
		{
			SalBoolean vrtDataSourceReferenceItems(SalString sReference, SalString sReturnKeyName, SalArray<SalString> sColumnNames, SalArray<SalString> sColumnPrompts);
			SalBoolean vrtFinDlgCheckCompany();
			SalBoolean vrtFinDlgCheckState(SalNumber nWhat);
			SalString vrtGetWindowTitle();
			SalBoolean vrtSetComboBoxValues();
			SalBoolean vrtSetDataFieldValues();
			SalBoolean vrtSetFinWindowTitle();
			SalBoolean vrtSetWindowTitle();
			SalBoolean vrtShowActiveCompany();
			SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod);
		}
		#endregion
	}
}
