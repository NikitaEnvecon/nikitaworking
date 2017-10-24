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
// 10-04-05    MAAYLK    Bug 89864, Modified vrtPrepareActivate()
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
	public partial class cContainerTabFormWindowFin : cContainerTabFormWindow
	{
		// Multiple Inheritance: Base class instance.
		protected cFinlibServices _cFinlibServices;
		
		
		#region Fields
		public SalString __sDummy = "";
		public SalString i_sOldLabel = "";
		public SalArray<SalString> __sOldTabLabel = new SalArray<SalString>();
		public SalString i_sCompany = "";
		public SalString i_sChildText = "";
		public SalString i_sCompanyHelp = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cContainerTabFormWindowFin()
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
		public cContainerTabFormWindowFin(ISalWindow derived)
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
			SalString sDummy = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (!(SetFinWindowTitle())) 
				{
					sDummy = i_sOldLabel;
					FinTranslateStringCodePart(i_sCompany, cSessionManager.c_sDbPrefix, ref sDummy);
					Sal.SetWindowText(i_hWndSelf, i_sCompany + " - " + sDummy);
					return true;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="hWndPicTab"></param>
		/// <returns></returns>
		public virtual SalNumber TranslateCodePartTab(SalWindowHandle hWndPicTab)
		{
			#region Local Variables
			SalString sText = "";
			SalString sName = "";
			SalString sTabName = "";
			SalNumber nIndex = 0;
			SalNumber nTextLength = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.WindowIsDerivedFromClass(hWndPicTab, typeof(SalQuickTabs))) 
				{
					Sal.GetItemName(hWndPicTab, ref sName);
					nIndex = SalQuickTabs.FromHandle(hWndPicTab).GetCount();
					while (nIndex > 0) 
					{
						nIndex = nIndex - 1;
						if (SalQuickTabs.FromHandle(hWndPicTab).GetName(nIndex, ref sTabName)) 
						{
							// only in first time
							if (__sOldTabLabel[nIndex] == Ifs.Fnd.ApplicationForms.Const.strNULL) 
							{
								SalQuickTabs.FromHandle(hWndPicTab).GetLabel(nIndex, ref sText);
								__sOldTabLabel[nIndex] = sText;
							}
							sText = __sOldTabLabel[nIndex];
							nTextLength = sText.Length;
							if (FinTranslateStringCodePart(i_sCompany, cSessionManager.c_sDbPrefix, ref sText)) 
							{
								SalQuickTabs.FromHandle(hWndPicTab).SetLabel(nIndex, sText, false);
							}
						}
					}
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nlParam"></param>
		/// <returns></returns>
		public virtual SalNumber GetAllChangeVar(SalNumber nlParam)
		{
			#region Local Variables
			SalArray<SalString> sChanges = new SalArray<SalString>();
			SalNumber nNumChanges = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				nNumChanges = SalString.FromHandle(nlParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), sChanges);
				if (Ifs.Fnd.ApplicationForms.Int.PalStrSplitLeft(sChanges[0], ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter()) == "COMPANY") 
				{
					i_sCompany = Ifs.Fnd.ApplicationForms.Int.PalStrSplitRight(sChanges[0], ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter());
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
				Sal.SendMsg(this.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.AM_UserProfileValueSet, 0, new SalString("COMPANY" + "^" + sSetName).ToHandle());
				Sal.SendMsg(this.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged, 0, Ifs.Fnd.ApplicationForms.Int.PalAttrCreate("COMPANY", sSetName).ToHandle());
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// Indicates that a tab has been activated.
		/// This function is called before the child windows have been shown
		/// </summary>
		/// <param name="hWnd"></param>
		/// <param name="nTab"></param>
		/// <returns></returns>
		public new SalNumber TabActivateStart(SalWindowHandle hWnd, SalNumber nTab)
		{
			#region Local Variables
			SalString sTabName = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				// do it only the first time
				picTab.GetName(nTab, ref sTabName);
				if (picTab.GetPageWindow(sTabName) == Sys.hWndNULL) 
				{
					_SessionWindowSetTransferGlobals(ref sTabName);
				}
				((cContainerTabFormWindow)this).TabActivateStart(hWnd, nTab);
			}

			return 0;
			#endregion
		}
		// Bug 80665, Removed TabActivateFinish
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
		private void cContainerTabFormWindowFin_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Const.PAM_CallChanged:
					this.cContainerTabFormWindowFin_OnPAM_CallChanged(sender, e);
					break;
				case Sys.SAM_Create:
					this.cContainerTabFormWindowFin_OnSAM_Create(sender, e);
					break;
				
				// Bug 82855, Begin
				
				// Bug 82855, End
				
				case Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged:
					this.cContainerTabFormWindowFin_OnPM_UserProfileChanged(sender, e);
					break;
				
				case Const.PM_TranslateCodePartTab:
					e.Handled = true;
					this.vrtTranslateCodePartTab(Sys.lParam.ToWindowHandle());
					break;
				
				case Const.PAM_ChangeCompany:
					this.cContainerTabFormWindowFin_OnPAM_ChangeCompany(sender, e);
					break;
				
				case Const.PAM_ChangedChildText:
					this.cContainerTabFormWindowFin_OnPAM_ChangedChildText(sender, e);
					break;
			}
			#endregion
		}
		/// <summary>
		/// PAM_CallChanged event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cContainerTabFormWindowFin_OnPAM_CallChanged(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.DataSourceClear(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
			this.vrtSetWindowTitle();
			Sal.SendMsgToChildren(this.i_hWndSelf, Const.PAM_CallChanged, 0, 0);
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cContainerTabFormWindowFin_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			Sal.GetWindowText(this.i_hWndSelf, ref this.i_sOldLabel, 99);
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_UserProfileChanged event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cContainerTabFormWindowFin_OnPM_UserProfileChanged(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			// Get all changed variables
			if (this.GetAllChangeVar(Sys.lParam)) 
			{
				// The above code is executed in PAM_CallChanged so invoke it directly for the window instead of having duplicate code
				Sal.SendMsg(this.i_hWndSelf, Const.PAM_CallChanged, 0, 0);
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
		private void cContainerTabFormWindowFin_OnPAM_ChangeCompany(object sender, WindowActionsEventArgs e)
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
		/// PAM_ChangedChildText event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cContainerTabFormWindowFin_OnPAM_ChangedChildText(object sender, WindowActionsEventArgs e)
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
		public new SalBoolean DataSourceReferenceItems(SalString sReference, SalString sReturnKeyName, SalArray<SalString> sColumnNames, SalArray<SalWindowHandle> hWndChild, SalNumber nChildCount, SalArray<SalString> sColumnPrompts)
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
		/// Multiple Inheritance: Cast operator from type cContainerTabFormWindowFin to type cDataSource.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cDataSource(cContainerTabFormWindowFin self)
		{
			return self._cDataSource;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cContainerTabFormWindowFin to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cContainerTabFormWindowFin self)
		{
			return ((cSessionManager)self._cDataSource);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cContainerTabFormWindowFin to type cWindowTranslation.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cWindowTranslation(cContainerTabFormWindowFin self)
		{
			return ((cWindowTranslation)self._cDataSource);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cContainerTabFormWindowFin to type SalToolTipManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator SalToolTipManager(cContainerTabFormWindowFin self)
		{
			return self._SalToolTipManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cContainerTabFormWindowFin to type cTabManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cTabManager(cContainerTabFormWindowFin self)
		{
			return self._cTabManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cContainerTabFormWindowFin to type cFinlibServices.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cFinlibServices(cContainerTabFormWindowFin self)
		{
			return self._cFinlibServices;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataSource to type cContainerTabFormWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cContainerTabFormWindowFin(cDataSource super)
		{
			return ((cContainerTabFormWindowFin)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cContainerTabFormWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cContainerTabFormWindowFin(cSessionManager super)
		{
			return ((cContainerTabFormWindowFin)((cDataSource)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cWindowTranslation to type cContainerTabFormWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cContainerTabFormWindowFin(cWindowTranslation super)
		{
			return ((cContainerTabFormWindowFin)((cDataSource)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type SalToolTipManager to type cContainerTabFormWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cContainerTabFormWindowFin(SalToolTipManager super)
		{
			return ((cContainerTabFormWindowFin)((cDataSource)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTabManager to type cContainerTabFormWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cContainerTabFormWindowFin(cTabManager super)
		{
			return ((cContainerTabFormWindowFin)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cFinlibServices to type cContainerTabFormWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cContainerTabFormWindowFin(cFinlibServices super)
		{
			return ((cContainerTabFormWindowFin)super._derived);
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
		public new static cContainerTabFormWindowFin FromHandle(SalWindowHandle handle)
		{
			return ((cContainerTabFormWindowFin)SalWindow.FromHandle(handle, typeof(cContainerTabFormWindowFin)));
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
		public override SalBoolean vrtTabActivateStart(SalWindowHandle hWnd, SalNumber nTab)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.TabActivateStart(hWnd, nTab);
			}
			else
			{
				return lateBind.vrtTabActivateStart(hWnd, nTab);
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalNumber vrtTranslateCodePartTab(SalWindowHandle hWndPicTab)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.TranslateCodePartTab(hWndPicTab);
			}
			else
			{
				return lateBind.vrtTranslateCodePartTab(hWndPicTab);
			}
		}
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public override SalNumber vrtPrepareActivate(fcURL URL)
		{
            #region Local Variables
            SalString sTempCompany = Ifs.Fnd.ApplicationForms.Const.strNULL;
            //Bug 89864, Begin.
            fcURL tempURL = new fcURL();
            //Bug 89864, End.
            #endregion

            UserGlobalValueGet("COMPANY", ref sTempCompany);
            
			// Check whether globals (class level instance) are different from instance variable, 
            if (this.i_sCompany != sTempCompany)
            {
                //TODO: iURL gets cleared in SetCompnay(). Therefore store iUrl in a variable and restore it after SetCompnay(). A better solution must be found later.
                //Bug 89864, Begin. Store iUrl in temporary variable to avoid it from getting cleared.
                iURL.Clone(tempURL);
				SetCompany(sTempCompany);
                iURL = tempURL;
                //Bug 89864, End.
            }
            return base.PrepareActivate(URL);
        }
		#endregion
		
		#region Multiple Inheritance Late Bind Interface
		
		public interface LateBind
		{
			SalBoolean vrtDataSourceReferenceItems(SalString sReference, SalString sReturnKeyName, SalArray<SalString> sColumnNames, SalArray<SalString> sColumnPrompts);
			SalBoolean vrtSetWindowTitle();
			SalBoolean vrtTabActivateStart(SalWindowHandle hWnd, SalNumber nTab);
			SalNumber vrtTranslateCodePartTab(SalWindowHandle hWndPicTab);
		}
		#endregion
	}
}
