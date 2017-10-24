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
// 13-07-02    MAAYLK    Bug 109903, Replaced bug 103031 with a different correction
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
	/// cTabDialogBox fuctionality with cFinLibServices
	/// NOTE: There are currently no chagne company related code here.
	/// Please add them when neccessary, and remove this notice.
	/// </summary>
	public partial class cTabDialogBoxFin : cTabDialogBox
	{
		// Multiple Inheritance: Base class instance.
		protected cFinlibServices _cFinlibServices;
		
		
		#region Fields
		public SalString i_sCompany = "";
		public SalString i_sCompanyHelp = "";
		public SalString i_sChildText = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cTabDialogBoxFin()
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
		public cTabDialogBoxFin(ISalWindow derived)
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
		// Bug 86196 - Begin
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
		private void cTabDialogBoxFin_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Const.PAM_ChangedChildText:
					this.cTabDialogBoxFin_OnPAM_ChangedChildText(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_ChangedChildText event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cTabDialogBoxFin_OnPAM_ChangedChildText(object sender, WindowActionsEventArgs e)
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
		
		// Bug 109903 Begin
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
		// Bug 109903 End
		
		/// <summary>
		/// </summary>
		/// <param name="sFinCompany"></param>
		/// <returns></returns>
		public virtual SalBoolean SetCompany(SalString sFinCompany)
		{
			using (new SalContext(this))
			{
				return _cFinlibServices.SetCompany(sFinCompany);
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
		/// Multiple Inheritance: Cast operator from type cTabDialogBoxFin to type cDataSource.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cDataSource(cTabDialogBoxFin self)
		{
			return self._cDataSource;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTabDialogBoxFin to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cTabDialogBoxFin self)
		{
			return ((cSessionManager)self._cDataSource);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTabDialogBoxFin to type cWindowTranslation.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cWindowTranslation(cTabDialogBoxFin self)
		{
			return ((cWindowTranslation)self._cDataSource);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTabDialogBoxFin to type cFinlibServices.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cFinlibServices(cTabDialogBoxFin self)
		{
			return self._cFinlibServices;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataSource to type cTabDialogBoxFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTabDialogBoxFin(cDataSource super)
		{
			return ((cTabDialogBoxFin)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cTabDialogBoxFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTabDialogBoxFin(cSessionManager super)
		{
			return ((cTabDialogBoxFin)((cDataSource)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cWindowTranslation to type cTabDialogBoxFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTabDialogBoxFin(cWindowTranslation super)
		{
			return ((cTabDialogBoxFin)((cDataSource)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cFinlibServices to type cTabDialogBoxFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTabDialogBoxFin(cFinlibServices super)
		{
			return ((cTabDialogBoxFin)super._derived);
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
		public new static cTabDialogBoxFin FromHandle(SalWindowHandle handle)
		{
			return ((cTabDialogBoxFin)SalWindow.FromHandle(handle, typeof(cTabDialogBoxFin)));
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
		#endregion
		
		#region Multiple Inheritance Late Bind Interface
		
		public interface LateBind
		{
			SalBoolean vrtDataSourceReferenceItems(SalString sReference, SalString sReturnKeyName, SalArray<SalString> sColumnNames, SalArray<SalString> sColumnPrompts);
		}
		#endregion
	}
}
