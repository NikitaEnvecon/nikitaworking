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
// 12-11-23    JANBLK    DANU-122, Parallel currency implementation.
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
	/// </summary>
	public partial class cMasterDetailTabFormWindowFin : cMasterDetailTabFormWindow
	{
		// Multiple Inheritance: Base class instance.
		protected cFinlibServices _cFinlibServices;
		
		
		#region Fields
		public SalString i_sChildText = "";
		public SalString i_sCompany = "";
		public SalString i_sCompanyHelp = "";
		public SalWindowHandle i_hWndPicTabFa = SalWindowHandle.Null;
		public SalString i_sOldLabel = "";
		public SalString UnusedCodeParts = "";
		public SalString i_sSqlColumn = "";
		public SalString i_sDisableWindow = "";
        public SalBoolean i_bTranslateForCodePart = false;
        public SalBoolean i_bCompanyChangedFin = false;

        public SalString sParallelCurrencyRateType = "";


        public SalString sNullValue = Sys.STRING_Null;

		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cMasterDetailTabFormWindowFin()
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
		public cMasterDetailTabFormWindowFin(ISalWindow derived)
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

        [Browsable(false)]
        [DesignerSerializationVisibility(0)]
        public SalString i_sFinParallelBaseType
        {
            get { return _cFinlibServices.i_sFinParallelBaseType; }
            set { _cFinlibServices.i_sFinParallelBaseType = value; }
        }

		#endregion
		
		#region Methods
		
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
							SalQuickTabs.FromHandle(hWndPicTab).GetLabel(nIndex, ref sText);
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
		/// <returns></returns>
		public virtual SalBoolean SetWindowTitle()
		{
			#region Local Variables
			SalString sWindowTitle = "";
			SalArray<SalString> sParams = new SalArray<SalString>();
			SalString sCurrentWindowTitle = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (!(SetFinWindowTitle())) 
				{
					sParams[0] = i_sCompany;
					sCurrentWindowTitle = this.vrtGetWindowTitle();
					sCurrentWindowTitle = sCurrentWindowTitle;
					if (sCurrentWindowTitle.Scan("&0") != -1) 
					{
						sWindowTitle = Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams(sCurrentWindowTitle, sParams);
					}
					else if (sCurrentWindowTitle.Scan(":") != -1) 
					{
						if (this.vrtShowActiveCompany()) 
						{
							sWindowTitle = Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams(Vis.StrSubstitute(sCurrentWindowTitle, ":", ": &0 -"), sParams);
						}
						else
						{
							sWindowTitle = Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams(sCurrentWindowTitle, sParams);
						}
					}
					else
					{
						if (this.vrtShowActiveCompany()) 
						{
							sWindowTitle = Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams("&0 - " + sCurrentWindowTitle, sParams);
						}
						else
						{
							sWindowTitle = Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams(sCurrentWindowTitle, sParams);
						}
					}
                    // if you need to translate sWindowTitle according to the code part value translation please set i_bTranslateForCodePart to true in your respective form.
                    if (i_bTranslateForCodePart)
                    {
                        FinTranslateStringCodePart(i_sCompany, cSessionManager.c_sDbPrefix, ref sWindowTitle);
                    }
					Sal.SetWindowText(i_hWndSelf, sWindowTitle);
					return true;
				}
			}

			return false;
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
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sCurrencyCode"></param>
		/// <param name="sBaseCurrencyCode"></param>
		/// <param name="sCurrencyType"></param>
		/// <param name="dDate"></param>
		/// <returns></returns>
		public virtual SalBoolean GetAttributes(SalString sCompany, SalString sCurrencyCode, SalString sBaseCurrencyCode, SalString sCurrencyType, SalDateTime dDate)
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (IsEqualFinCatch(sCompany, sCurrencyCode, sBaseCurrencyCode, sCurrencyType, dDate)) 
				{
					return true;
				}
				else
				{
					SetCache(sCompany, sCurrencyCode, sBaseCurrencyCode, sCurrencyType, dDate);
					if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Currency_Rate_API.Fetch_Currency_Rate_Base"))) 
					{
						return false;
					}
					if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Currency_Code_API.Get_Currency_Rounding"))) 
					{
						return false;
					}
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Currency_Rate_API.Fetch_Currency_Rate_Base", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						hints.Add("Currency_Code_API.Get_Currency_Rounding", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					    // RUNTIME_CORRECTION: Used i_hWndSelf instead of i_hWndFrame since that doesn't refer to correct object cMasterDetailTabFormWindowFin
					    bOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n " + cSessionManager.c_sDbPrefix + "Currency_Rate_API.Fetch_Currency_Rate_Base(\r\n" +
						    " :i_hWndSelf.cMasterDetailTabFormWindowFin.i_nFinConversionFactor, \r\n" +
						    " :i_hWndSelf.cMasterDetailTabFormWindowFin.i_nFinCurrencyRate,\r\n" +
						    " :i_hWndSelf.cMasterDetailTabFormWindowFin.i_lsFinInverted,\r\n" +
						    " :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinCompany,\r\n" +
						    " :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinCurrencyCode,\r\n" +
						    " :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinBaseCurrencyCode,\r\n" +
						    " :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinCurrencyType, \r\n" +
						    " :i_hWndSelf.cMasterDetailTabFormWindowFin.dFinDate,\r\n" +
						    " 'DUMMY');\r\n SELECT " + cSessionManager.c_sDbPrefix + "Currency_Code_API.Get_Currency_Rounding(:i_hWndSelf.cMasterDetailTabFormWindowFin.sFinCompany, :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinCurrencyCode),\r\n " + cSessionManager.c_sDbPrefix +
						"Currency_Code_API.Get_Currency_Rounding(:i_hWndSelf.cMasterDetailTabFormWindowFin.sFinCompany, :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinBaseCurrencyCode)\r\n" +
						" INTO :i_hWndSelf.cMasterDetailTabFormWindowFin.i_nFinTransRound, :i_hWndSelf.cMasterDetailTabFormWindowFin.i_nFinBaseRound FROM DUAL;\r\n END;");
					}
					if (bOk) 
					{
						SetFinCache(sCompany, sCurrencyCode, sBaseCurrencyCode, sCurrencyType, dDate);
						bGetRate = false;
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sCurrencyCode"></param>
		/// <returns></returns>
		public virtual SalNumber GetRate(SalString sCompany, SalString sCurrencyCode)
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (sCompany == i_sFinCompany && sCurrencyCode == i_sFinCurrencyCode && bGetRate) 
				{
					bOk = true;
				}
				else
				{
					sFinCompany = sCompany;
					sFinCurrencyCode = sCurrencyCode;
					bGetRate = true;
					if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("CURRENCY_CODE_API.Get_No_Of_Decimals_In_Rate_")) 
					{
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("CURRENCY_CODE_API.Get_No_Of_Decimals_In_Rate_", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						// Insert new code here...
						// RUNTIME_CORRECTION: Used i_hWndSelf instead of i_hWndFrame since that doesn't refer to correct object cMasterDetailTabFormWindowFin
						bOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n " + cSessionManager.c_sDbPrefix + "CURRENCY_CODE_API.Get_No_Of_Decimals_In_Rate_(\r\n" +
							" :i_hWndSelf.cMasterDetailTabFormWindowFin.i_nFinRound, \r\n" +
							" :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinCompany,\r\n" +
							" :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinCurrencyCode\r\n" +
							");  \r\n END;");
						}
					}
				}
				if (bOk) 
				{
					return RoundOf(i_nFinCurrencyRate, i_nFinRound);
				}
				else
				{
					return 0;
				}
			}
			#endregion
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
		public virtual SalBoolean GetThirdCurrencyAttributes(SalString sCompany, SalString sThirdCurrencyCode, SalString sBaseCurrencyCode, SalDateTime dDate, SalString sIsThirdEMU, SalString sIsBaseEMU)
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (IsEqualFinThirdCatch(sCompany, sThirdCurrencyCode, sBaseCurrencyCode, dDate, sIsThirdEMU, sIsBaseEMU)) 
				{
					return true;
				}
				else
				{
					SetThirdCache(sCompany, sThirdCurrencyCode, sBaseCurrencyCode, dDate, sIsThirdEMU, sIsBaseEMU);
					if (sThirdCurrencyCode != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {   

                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Currency_Rate_API.Get_Parallel_Currency_Rate")))

						{
							return false;
						}
						if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Currency_Code_API.Get_Currency_Rounding"))) 
						{
							return false;
						}
						using(SignatureHints hints = SignatureHints.NewContext())
						{

						    // Insert new code here...
						    // RUNTIME_CORRECTION: Used i_hWndSelf instead of i_hWndFrame since that doesn't refer to correct object cMasterDetailTabFormWindowFin
                            bOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n &AO.Currency_Rate_API.Get_Parallel_Currency_Rate(\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.i_nFinThirdCurrencyRate INOUT, \r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.i_nFinThirdConversionFactor INOUT,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.i_lsFinThirdInverted INOUT,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinCompany IN,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinCurrencyCode IN,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.dFinDate IN,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.sParallelCurrencyRateType IN,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.i_sFinParallelBaseType IN,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinBaseCurrencyCode IN,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinThirdCurrencyCode IN,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinIsBaseEMU IN,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinIsThirdEMU IN\r\n" +
                                ");\r\n" +
                                "\r\n :i_hWndSelf.cMasterDetailTabFormWindowFin.i_nFinTransAmountRound := &AO.Currency_Code_API.Get_Currency_Rounding(:i_hWndSelf.cMasterDetailTabFormWindowFin.sFinCompany IN, :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinThirdCurrencyCode IN);\r\n" +
                                " END;\r\n");

                        }
					}
					if (bOk) 
					{
						SetFinThirdCache(sCompany, sThirdCurrencyCode, sBaseCurrencyCode, dDate, sIsThirdEMU, sIsBaseEMU);
						bThirdGetRate = false;
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			#endregion
		}


        public SalBoolean GetThirdCurrencyAttributes(SalString sCompany, SalString sThirdCurrencyCode, SalString sBaseCurrencyCode, SalDateTime dDate, SalString sIsThirdEMU, SalString sIsBaseEMU, SalString sParallelBaseType, SalString sParallelRateType)
        {
            #region Local Variables
            SalBoolean bOk = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (IsEqualFinThirdCatch(sCompany, sThirdCurrencyCode, sBaseCurrencyCode, dDate, sIsThirdEMU, sIsBaseEMU) /*&& (!(i_bCompanyChanged))*/)
                {
                    return true;
                }
                else
                {
                    SetThirdCache(sCompany, sThirdCurrencyCode, sBaseCurrencyCode, dDate, sIsThirdEMU, sIsBaseEMU, sParallelBaseType);
                    if (sThirdCurrencyCode != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {

                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Currency_Rate_API.Get_Parallel_Currency_Rate")))
                        {
                            return false;
                        }

                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Currency_Code_API.Get_Currency_Rounding")))
                        {
                            return false;
                        }
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {

                            hints.Add("Currency_Rate_API.Get_Parallel_Currency_Rate", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);

                            hints.Add("Currency_Code_API.Get_Currency_Rounding", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            hints.Add("Company_Finance_API.Get_Parallel_Base_Db", System.Data.ParameterDirection.Input);
                            // Insert new code here...
                            // RUNTIME_CORRECTION: Used i_hWndSelf instead of i_hWndFrame since that doesn't refer to correct object cMasterDetailTabFormWindowFin
                            sParallelCurrencyRateType = sParallelRateType;

                            bOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n " + cSessionManager.c_sDbPrefix + "Currency_Rate_API.Get_Parallel_Currency_Rate(\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.i_nFinThirdCurrencyRate, \r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.i_nFinThirdConversionFactor,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.i_lsFinThirdInverted,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinCompany,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinCurrencyCode,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.dFinDate,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.sParallelCurrencyRateType,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.i_sFinParallelBaseType,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinBaseCurrencyCode,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinThirdCurrencyCode,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.sNullValue,\r\n" +
                                " :i_hWndSelf.cMasterDetailTabFormWindowFin.sNullValue\r\n" +
                                ");\r\n" +
                                " \r\n :i_hWndSelf.cMasterDetailTabFormWindowFin.i_sFinParallelBaseType := &AO.Company_Finance_API.Get_Parallel_Base_Db(:i_hWndSelf.cMasterDetailTabFormWindowFin.sFinCompany);\r\n" +
                                "\r\n :i_hWndSelf.cMasterDetailTabFormWindowFin.i_nFinTransAmountRound := &AO.Currency_Code_API.Get_Currency_Rounding(:i_hWndSelf.cMasterDetailTabFormWindowFin.sFinCompany, :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinThirdCurrencyCode);\r\n" +
                                " END;\r\n");                            


                        }
                    }
                    if (bOk)
                    {
                        SetFinThirdCache(sCompany, sThirdCurrencyCode, sBaseCurrencyCode, dDate, sIsThirdEMU, sIsBaseEMU, sParallelBaseType);
                        bThirdGetRate = false;
                        //i_bCompanyChanged = false;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            #endregion
        }

		
		/// <summary>
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sThirdCurrencyCode"></param>
		/// <returns></returns>
		public virtual SalNumber GetThirdCurrencyRate(SalString sCompany, SalString sThirdCurrencyCode)
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (sCompany == i_sFinCompany && sThirdCurrencyCode == i_sFinThirdCurrencyCode && bThirdGetRate) 
				{
					bOk = true;
				}
				else
				{
					sFinCompany = sCompany;
					sFinThirdCurrencyCode = sThirdCurrencyCode;
					bThirdGetRate = true;
					if (sThirdCurrencyCode != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("CURRENCY_CODE_API.Get_No_Of_Decimals_In_Rate_")) 
						{
							using(SignatureHints hints = SignatureHints.NewContext())
							{
								hints.Add("CURRENCY_CODE_API.Get_No_Of_Decimals_In_Rate_", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							// Insert new code here...
							// RUNTIME_CORRECTION: Used i_hWndSelf instead of i_hWndFrame since that doesn't refer to correct object cMasterDetailTabFormWindowFin
							bOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n " + cSessionManager.c_sDbPrefix + "CURRENCY_CODE_API.Get_No_Of_Decimals_In_Rate_(\r\n" +
								" :i_hWndSelf.cMasterDetailTabFormWindowFin.i_nFinThirdRound, \r\n" +
								" :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinCompany,\r\n" +
								" :i_hWndSelf.cMasterDetailTabFormWindowFin.sFinThirdCurrencyCode\r\n" +
								");  \r\n END;");
							}
						}
					}
				}
				if (bOk) 
				{
					return RoundOf(i_nFinThirdCurrencyRate, i_nFinThirdRound);
				}
				else
				{
					return 0;
				}
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
		private void cMasterDetailTabFormWindowFin_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Const.PAM_CallChanged:
					this.cMasterDetailTabFormWindowFin_OnPAM_CallChanged(sender, e);
					break;
				case Const.PAM_ChangedChildText:
					this.cMasterDetailTabFormWindowFin_OnPAM_ChangedChildText(sender, e);
					break;
				
				case Const.PAM_GetAndSetDefaultCompany:
					this.cMasterDetailTabFormWindowFin_OnPAM_GetAndSetDefaultCompany(sender, e);
					break;
				
				case Const.PAM_TranslateCodePartTab:
					e.Handled = true;
					this.vrtTranslateCodePartTab(Sys.lParam.ToWindowHandle());
					break;
								
				case Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged:
					this.cMasterDetailTabFormWindowFin_OnPM_UserProfileChanged(sender, e);
					break;
				
				case Const.PAM_ChangeCompany:
					this.cMasterDetailTabFormWindowFin_OnPAM_ChangeCompany(sender, e);
					break;
				
				case Sys.SAM_CreateComplete:
					this.cMasterDetailTabFormWindowFin_OnSAM_CreateComplete(sender, e);
					break;
				
				case Const.PAM_DisableUnusedCodeParts:
					this.cMasterDetailTabFormWindowFin_OnPAM_DisableUnusedCodeParts(sender, e);
					break;
			}
			#endregion
		}
		/// <summary>
		/// PAM_CallChanged event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cMasterDetailTabFormWindowFin_OnPAM_CallChanged(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.DataSourceClear(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
			Sal.SendMsg(this.i_hWndSelf, Const.PAM_GetAndSetDefaultCompany, 0, 0);
			Sal.SendMsgToChildren(this.i_hWndSelf, Const.PAM_CallChanged, 0, 0);
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// PAM_ChangedChildText event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cMasterDetailTabFormWindowFin_OnPAM_ChangedChildText(object sender, WindowActionsEventArgs e)
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
		/// PAM_GetAndSetDefaultCompany event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cMasterDetailTabFormWindowFin_OnPAM_GetAndSetDefaultCompany(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.GetChangedFinCompany(ref this.i_sCompany);
			this.vrtSetWindowTitle();
			#endregion
		}
				
		/// <summary>
		/// PM_UserProfileChanged event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cMasterDetailTabFormWindowFin_OnPM_UserProfileChanged(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			// Get all changed variables
			if (this.GetChangedFinCompany(ref this.i_sCompany)) 
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
		private void cMasterDetailTabFormWindowFin_OnPAM_ChangeCompany(object sender, WindowActionsEventArgs e)
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
		private void cMasterDetailTabFormWindowFin_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.GetWindowText(this.i_hWndSelf, ref this.i_sOldLabel, 99);
			// Insert new code here...
			Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// PAM_DisableUnusedCodeParts event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cMasterDetailTabFormWindowFin_OnPAM_DisableUnusedCodeParts(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.i_sSqlColumn = SalString.FromHandle(Sys.lParam);
			if (this.i_sCompany == Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				this.UserGlobalValueGet("COMPANY", ref this.i_sCompanyHelp);
			}
			else
			{
				this.i_sCompanyHelp = this.i_sCompany;
			}
			if (!(this.GetUnusedCodeParts(this.i_sCompanyHelp, this.i_sSqlColumn, ref this.i_sDisableWindow))) 
			{
				this.i_sDisableWindow = Ifs.Fnd.ApplicationForms.Const.strNULL;
			}
			e.Return = this.i_sDisableWindow.ToHandle();
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



        public virtual SalBoolean CalcualteParallelCurrencyRate(SalNumber nAmount, SalNumber nCurrencyAmount, SalNumber nParallelCurrencyAmount, ref SalNumber nCurrencyRate)
        {
            using (new SalContext(this))
            {
                return _cFinlibServices.CalcualteParallelCurrencyRate(nAmount, nCurrencyAmount, nParallelCurrencyAmount, ref nCurrencyRate);
            }
        }

        public SalBoolean GetThirdCurrencyAmount(SalNumber nAmount, SalNumber nCurrAmount, ref SalNumber nThirdCurrencyAmount)
        {
            using (new SalContext(this))
            {
                return _cFinlibServices.GetThirdCurrencyAmount(nAmount, nCurrAmount, ref nThirdCurrencyAmount);
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
        /// <param name="sParallelBaseType"></param>
        public SalBoolean SetFinThirdCache(SalString sCompany, SalString sThirdCurrencyCode, SalString sBaseCurrencyCode, SalDateTime dDate, SalString sIsThirdEMU, SalString sIsBaseEMU, SalString sParallelBaseType)
        {
            using (new SalContext(this))
            {
                return _cFinlibServices.SetFinThirdCache(sCompany, sThirdCurrencyCode, sBaseCurrencyCode, dDate, sIsThirdEMU, sIsBaseEMU, sParallelBaseType);
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
        /// <param name="sCompany"></param>
        /// <param name="sThirdCurrencyCode"></param>
        /// <param name="sBaseCurrencyCode"></param>
        /// <param name="dDate"></param>
        /// <param name="sIsThirdEMU"></param>
        /// <param name="sIsBaseEMU"></param>
        /// <param name="sParallelBaseType"></param>
        /// <returns></returns>
        public SalBoolean SetThirdCache(SalString sCompany, SalString sThirdCurrencyCode, SalString sBaseCurrencyCode, SalDateTime dDate, SalString sIsThirdEMU, SalString sIsBaseEMU, SalString sParallelBaseType)
        {
            using (new SalContext(this))
            {
                return _cFinlibServices.SetThirdCache(sCompany, sThirdCurrencyCode, sBaseCurrencyCode, dDate, sIsThirdEMU, sIsBaseEMU, sParallelBaseType);
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
		/// Multiple Inheritance: Cast operator from type cMasterDetailTabFormWindowFin to type cDataSource.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cDataSource(cMasterDetailTabFormWindowFin self)
		{
			return self._cDataSource;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cMasterDetailTabFormWindowFin to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cMasterDetailTabFormWindowFin self)
		{
			return ((cSessionManager)self._cDataSource);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cMasterDetailTabFormWindowFin to type cWindowTranslation.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cWindowTranslation(cMasterDetailTabFormWindowFin self)
		{
			return ((cWindowTranslation)self._cDataSource);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cMasterDetailTabFormWindowFin to type SalToolTipManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator SalToolTipManager(cMasterDetailTabFormWindowFin self)
		{
			return self._SalToolTipManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cMasterDetailTabFormWindowFin to type cTabManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cTabManager(cMasterDetailTabFormWindowFin self)
		{
			return self._cTabManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cMasterDetailTabFormWindowFin to type cFinlibServices.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cFinlibServices(cMasterDetailTabFormWindowFin self)
		{
			return self._cFinlibServices;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cDataSource to type cMasterDetailTabFormWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cMasterDetailTabFormWindowFin(cDataSource super)
		{
			return ((cMasterDetailTabFormWindowFin)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cMasterDetailTabFormWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cMasterDetailTabFormWindowFin(cSessionManager super)
		{
			return ((cMasterDetailTabFormWindowFin)((cDataSource)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cWindowTranslation to type cMasterDetailTabFormWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cMasterDetailTabFormWindowFin(cWindowTranslation super)
		{
			return ((cMasterDetailTabFormWindowFin)((cDataSource)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type SalToolTipManager to type cMasterDetailTabFormWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cMasterDetailTabFormWindowFin(SalToolTipManager super)
		{
			return ((cMasterDetailTabFormWindowFin)((cDataSource)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTabManager to type cMasterDetailTabFormWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cMasterDetailTabFormWindowFin(cTabManager super)
		{
			return ((cMasterDetailTabFormWindowFin)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cFinlibServices to type cMasterDetailTabFormWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cMasterDetailTabFormWindowFin(cFinlibServices super)
		{
			return ((cMasterDetailTabFormWindowFin)super._derived);
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
		public new static cMasterDetailTabFormWindowFin FromHandle(SalWindowHandle handle)
		{
			return ((cMasterDetailTabFormWindowFin)SalWindow.FromHandle(handle, typeof(cMasterDetailTabFormWindowFin)));
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

            using (new SalContext(this))
            {
                UserGlobalValueGet("COMPANY", ref sTempCompany);
                if (sTempCompany != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    if (this.i_sCompany != "" && (this.i_sCompany != sTempCompany))
                    {
                        this.i_bCompanyChangedFin = true;
                    }
                    else
                    {
                        this.i_bCompanyChangedFin = false;
                    }
                    if (this.i_sCompany != sTempCompany)
                    {
                        //TODO: iURL gets cleared in SetCompnay(). Therefore store iUrl in a variable and restore it after SetCompnay(). A better solution must be found later.
                        //Bug 89864, Begin. Store iUrl in temporary variable to avoid it from getting cleared.
                        iURL.Clone(tempURL);
						SetCompany(sTempCompany);
                        iURL = tempURL;
                        //Bug 89864, End.
                    }
                }
            }
            return base.PrepareActivate(URL);
        }
		#endregion
		
		#region Multiple Inheritance Late Bind Interface
		
		public interface LateBind
		{
			SalBoolean vrtDataSourceReferenceItems(SalString sReference, SalString sReturnKeyName, SalArray<SalString> sColumnNames, SalArray<SalString> sColumnPrompts);
			SalString vrtGetWindowTitle();
			SalBoolean vrtSetWindowTitle();
			SalBoolean vrtShowActiveCompany();
			SalNumber vrtTranslateCodePartTab(SalWindowHandle hWndPicTab);
		}
		#endregion
	}
}
