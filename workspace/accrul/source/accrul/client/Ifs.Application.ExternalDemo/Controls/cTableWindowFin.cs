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
// 09-08-21    GADALK    Bug 84567, Modified OnPM_UserProfileChanged.
// 10-04-05    MAAYLK    Bug 89864, Modified vrtPrepareActivate()
// 12-09-12    KAGALK    Bug 103031, Modified to display code parts according to the user profile
// 12-11-23    JANBLK    DANU-122, Parallel currency implementation.
// 13-05-17    MAAYLK    Bug 108483, Added code to refresh codepart visibility at vrtActivate()
// 13-07-02    MAAYLK    Bug 109903, Replaced bug 103031 with a different correction. Overided FrameShutdownUser()
// 13-09-03    MAAYLK    Bug 112164, To prevent calling DataSourceClear(), instead of sending PAM_CallChanged directly called its other action methods
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
	public partial class cTableWindowFin : cTableWindowFinBase
	{
		// Multiple Inheritance: Base class instance.
		protected cFinlibServices _cFinlibServices;
		
		
		#region Fields
		[ThreadStatic]
		public static SalString sCodePartValue;
		[ThreadStatic]
		public static SalString sCodePart;
		[ThreadStatic]
		public static SalString sCodePartDescription;
		[ThreadStatic]
		public static SalString sCompletionAttr;
		[ThreadStatic]
		public static SalString sIsPseudoCode;
		[ThreadStatic]
		public static SalString sPseudoCodeAttr;
		[ThreadStatic]
		public static SalString sRequiredStringComplete;
		[ThreadStatic]
		public static SalString sTempCodePart;
		[ThreadStatic]
		public static SalString sUserName;
		[ThreadStatic]
		public static SalBoolean bIsNullCodeParts;
		[ThreadStatic]
		public static SalBoolean bPseudoAccount;
		[ThreadStatic]
		public static SalString sRequiredString;
		[ThreadStatic]
		public static SalDateTime dNull;

		#region Static Fields initialization
		[ThreadStatic]
		private static bool threadStaticsInitialized;

		internal static void InitThreadStaticFields()
		{
			if (!threadStaticsInitialized)
			{
				threadStaticsInitialized = true;
				sCodePartValue = "";
				sCodePart = "";
				sCodePartDescription = "";
				sCompletionAttr = "";
				sIsPseudoCode = "";
				sPseudoCodeAttr = "";
				sRequiredStringComplete = "";
				sTempCodePart = "";
				sUserName = "";
				bIsNullCodeParts = false;
				bPseudoAccount = false;
				sRequiredString = "";
				dNull = SalDateTime.Null;
			}
		}
		#endregion

		public SalString i_sCompany = "";
		public SalString i_sChildText = "";
		public SalString i_sCompanyHelp = "";
		public SalString i_sOldLabel = "";
		public SalString i_sSqlColumn = "";
		public SalString i_sDisableWindow = "";
		public SalString i_sNotSupported = "";
		public SalString i_sVoucherTypeRef = "";
		public SalString i_sVoucherType = "";
		public SalString i_sCodePartValue = "";
		public SalNumber i_nVoucherNo = 0;
		public SalNumber i_nVoucherNumberRef = 0;
		public SalNumber i_nAccountingYear = 0;
		public SalNumber i_nAccountingYearRef = 0;
        public SalBoolean i_bTranslateForCodePart = false;

        public SalString sParallelCurrencyRateType = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cTableWindowFin()
		{
            InitThreadStaticFields();
			// Initialize second-base instances.
			InitializeMultipleInheritance();
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cTableWindowFin(ISalWindow derived)
		{
            InitThreadStaticFields();
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
		/// <param name="sFinCompany"></param>
		/// <returns></returns>
		public virtual SalBoolean GetChangedFinCompany(ref SalString sFinCompany)
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
					sFinCompany = sCompany;
					return true;
				}
				else
				{
					if (i_sCompany != sCompany) 
					{
						sFinCompany = sCompany;
						return true;
					}
				}
				return false;
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// Applications call the InitFromTransferedData function to initialize
		/// (populate) the data source based on information in data transfer.
		/// </summary>
		/// <returns></returns>
		public virtual SalString InitFromTransferedDataFin()
		{
			#region Local Variables
			SalArray<SalString> sSqlColumn = new SalArray<SalString>();
			SalString lsWhereStmt = "";
			SalNumber n = 0;
			SalNumber nIndex = 0;
			SalNumber nRows = 0;
			SalNumber nColumns = 0;
			SalString sDelim = "";
			SalString sDelim2 = "";
			SalString sTmp = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				nColumns = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemNamesGet(sSqlColumn);
				nRows = Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet();
				// Start building statment
				lsWhereStmt = Ifs.Fnd.ApplicationForms.Const.strNULL;
				sDelim = Ifs.Fnd.ApplicationForms.Const.strNULL;
				// Build the list of columns
				lsWhereStmt = lsWhereStmt + "(";
				n = 0;
				while (n < nColumns) 
				{
					lsWhereStmt = lsWhereStmt + sDelim + sSqlColumn[n];
					sDelim = ",";
					n = n + 1;
				}
				// Build the list of possible matching values
				lsWhereStmt = lsWhereStmt + ") in (";
				sDelim2 = "";
				nIndex = nRows - 1;
				while (nIndex >= 0) 
				{
					// Build list of column values.
					lsWhereStmt = lsWhereStmt + sDelim2 + "(";
					sDelim = "";
					n = 0;
					while (n < nColumns) 
					{
						if (!(Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(n, nIndex, ref sTmp))) 
						{
							Ifs.Fnd.ApplicationForms.Int.ErrorBox("Internal error - InitFromTransferedData: Cannot complete data transfer");
							break;
						}
						lsWhereStmt = lsWhereStmt + sDelim + "'" + sTmp + "'";
						sDelim = ",";
						n = n + 1;
					}
					lsWhereStmt = lsWhereStmt + ")";
					sDelim2 = ",";
					nIndex = nIndex - 1;
				}
				lsWhereStmt = lsWhereStmt + ")";
				// Format complete statement
				n = 0;
				return lsWhereStmt;
			}
			#endregion
		}
		
		/// <summary>
		/// Obsalete Function - To be removed - Finance 8.5
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
				Sal.SendMsg(this.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.AM_UserProfileValueSet, 0, new SalString("COMPANY" + "^" + sSetName).ToHandle());
				Sal.SendMsg(this.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged, 0, Ifs.Fnd.ApplicationForms.Int.PalAttrCreate("COMPANY", sSetName).ToHandle());
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// Get the code partvalue
		/// </summary>
		/// <param name="nRowCount"></param>
		/// <param name="sCodePart"></param>
		/// <returns></returns>
		public virtual SalString FetchCodePartValue(SalNumber nRowCount, SalString sCodePart)
		{
			#region Local Variables
			SalNumber n = 0;
			SalString sSqlColumn = "";
			SalString sValue = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				Sal.TblSetContext(i_hWndSelf, nRowCount);
				sValue = Ifs.Fnd.ApplicationForms.Const.strNULL;
				n = 0;
				while (n < i_nChildCount) 
				{
					if ((Sal.WindowClassName(i_hWndChild[n]) == "cColumnCodePartFin") || (Sal.WindowClassName(i_hWndChild[n]) == "cColumnFin")) 
					{
						sSqlColumn = cColumn.FromHandle(i_hWndChild[n]).p_sSqlColumn;
						// Jump over the description columns
						if (sSqlColumn.Scan("DESC") == -1) 
						{
							if (sSqlColumn == "ACCOUNT") 
							{
								if (sCodePart == "A") 
								{
									sValue = SalString.FromHandle(Sal.SendMsg(i_hWndChild[n], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0));
									break;
								}
							}
							else if (sSqlColumn.Scan("CODE_") != -1) 
							{
								if (sSqlColumn.Right(1) == sCodePart) 
								{
									sValue = SalString.FromHandle(Sal.SendMsg(i_hWndChild[n], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0));
									break;
								}
							}
						}
					}
					n = n + 1;
				}
				// Set the code part value
				cTableWindowFin.sCodePartValue = sValue;
				Sal.SendMsgToChildren(i_hWndFrame, Const.PAM_SetCodePartValue, 0, 0);
				return sValue;
			}
			#endregion
		}
		// Bug 76007 - Begin
		/// <summary>
		/// get all code parts and values
		/// </summary>
		/// <param name="sPAttr"></param>
		/// <param name="nRowCount"></param>
		/// <returns></returns>
		public virtual SalBoolean AttrFetchCodePart(ref SalString sPAttr, SalNumber nRowCount)
		{
			#region Local Variables
			SalNumber n = 0;
			SalString sSqlColumn = "";
			SalString sValue = "";
			SalBoolean bOk = false;
			SalString sPrevAccount = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (i_sSqlColumn != "ACCOUNT") 
				{
					sPrevAccount = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("ACCOUNT", sPAttr);
				}
				else
				{
					sPrevAccount = Ifs.Fnd.ApplicationForms.Const.strNULL;
				}
				Sal.TblSetContext(i_hWndSelf, nRowCount);
				sPAttr = Ifs.Fnd.ApplicationForms.Const.strNULL;
				n = 0;
				while (n < i_nChildCount) 
				{
					if ((Sal.WindowClassName(i_hWndChild[n]) == "cColumnCodePartFin") || (Sal.WindowClassName(i_hWndChild[n]) == "cColumnCodePartInt")) 
					{
						sSqlColumn = cColumn.FromHandle(i_hWndChild[n]).p_sSqlColumn;
						if (((sSqlColumn.Scan("CODE_") != -1) || (sSqlColumn.Scan("ACCOUNT") != -1) || (sSqlColumn.Scan("QUANTITY") != -1) || (sSqlColumn.Scan("PROCESS_CODE") != -1) || (sSqlColumn.Scan("TEXT") != -1)) && ((bool)Sal.SendMsg(i_hWndChild[n], Ifs.Fnd.ApplicationForms.Const.PM_DataItemFlagQuery, 
							Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, 0))) 
						{
							sValue = SalString.FromHandle(Sal.SendMsg(i_hWndChild[n], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0));
							sPAttr = sPAttr + sSqlColumn + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + sValue + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
						}
					}
					n = n + 1;
				}
				if (sPrevAccount != Ifs.Fnd.ApplicationForms.Const.strNULL && sPrevAccount != Ifs.Fnd.ApplicationForms.Int.PalAttrGet("ACCOUNT", sPAttr)) 
				{
					sPrevAccount = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("ACCOUNT", sPAttr);
					bOk = ValidateCodePart("ACCOUNT", sPrevAccount);
					sPrevAccount = Ifs.Fnd.ApplicationForms.Const.strNULL;
				}
				Ifs.Fnd.ApplicationForms.Var.Console.TextAdd(Ifs.Fnd.ApplicationForms.Const.CONS_Debug, "~~AttrFetchCodePart( '" + sPAttr + "'~~");
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// Get code part demand (Blocked, Can, Mandatory) and set value if exists
		/// </summary>
		/// <param name="sPAttr"></param>
		/// <param name="sPAttrValue"></param>
		/// <returns></returns>
		public virtual SalBoolean AttrDecodeCodePart(ref SalString sPAttr, ref SalString sPAttrValue)
		{
			#region Local Variables
			SalString lsAttr = "";
			SalNumber nLen = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				lsAttr = sPAttr + sPAttrValue;
				nLen = sPAttr.Length;
				if (Sal.SendMsgToChildren(i_hWndSelf, Const.PAM_SetCodePartValues, nLen, lsAttr.ToHandle())) 
				{
					return true;
				}
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// Checks if an account has a code string completion and gets the codepart values as an attribute string if a completion exists.
		/// </summary>
		/// <param name="p_sCodePart"></param>
		/// <returns></returns>
		public virtual SalBoolean CheckCompletion(SalString p_sCodePart)
		{
			#region Local Variables
			SalBoolean bCommandOk = false;
			SalString lsStmt = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (p_sCodePart == "ACCOUNT") 
				{
					cTableWindowFin.sTempCodePart = "A";
				}
				else
				{
					cTableWindowFin.sTempCodePart = cTableWindowFin.sCodePart;
				}
				lsStmt = " :cTableWindowFin.sCompletionAttr := &AO.ACCOUNTING_CODESTR_COMPL_API.Get_Complete_CodeString(\r\n" +
				" 					:i_hWndSelf.colsCompany,\r\n" +
				"					:cTableWindowFin.sTempCodePart,\r\n" +
				"					:cTableWindowFin.sCodePartValue );";
				bCommandOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + lsStmt + "END;");
				if (bCommandOk) 
				{
					if (cTableWindowFin.sCompletionAttr != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						ScanAttributeString(cTableWindowFin.sCompletionAttr);
					}
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
		/// Gets the corresponding codepart values as an attribute string for a pseudocode.
		/// </summary>
		/// <param name="p_sCodePart"></param>
		/// <returns></returns>
		public virtual SalBoolean CheckPseudoCode(SalString p_sCodePart)
		{
			#region Local Variables
			SalBoolean bCommandOk = false;
			SalString lsStmt = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				lsStmt = " &AO.PSEUDO_CODES_API.Get_Complete_Pseudo(\r\n" +
				"				:cTableWindowFin.sPseudoCodeAttr,\r\n" +
				"				:i_hWndSelf.colsCompany,\r\n" +
				"				:cTableWindowFin.sCodePartValue,\r\n" +
				"                                                                :cTableWindowFin.sUserName);";
				bCommandOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + lsStmt + "END;");
				if (bCommandOk) 
				{
					cTableWindowFin.bPseudoAccount = true;
					ScanAttributeString(cTableWindowFin.sPseudoCodeAttr);
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
		/// Override this function to check whether a project is an extrnally created project
		/// </summary>
		/// <param name="sCodePartValue"></param>
		/// <returns></returns>
		public virtual SalBoolean EnableDisableProjectActivityId(SalString sCodePartValue)
		{
			#region Actions
			using (new SalContext(this))
			{
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// This function Modifies or Adds new code part values to sRequiredStringComplete.
		/// </summary>
		/// <param name="p_sCodePart"></param>
		/// <param name="p_sCodePartValue"></param>
		/// <returns></returns>
		public virtual SalNumber ModifyRequiredString(SalString p_sCodePart, SalString p_sCodePartValue)
		{
			#region Local Variables
			SalNumber nPos = 0;
			SalNumber nLength = 0;
			SalNumber nPosUnitDelim = 0;
			SalNumber nPosRecDelim = 0;
			SalNumber nPosStr = 0;
			SalString sStrTmp = "";
			SalString sStr1 = "";
			SalString sStr2 = "";
			SalString sNewRequiredString = "";
			SalString sUnitChar = "";
			SalString sRecChar = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sUnitChar = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter();
				sRecChar = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
				// Get the position of the code part
				nPos = cTableWindowFin.sRequiredStringComplete.Scan(p_sCodePart);
				if (nPos != -1) 
				{
					// Find the length of the Attribute String
					nLength = cTableWindowFin.sRequiredStringComplete.Length;
					// Extract the string from beginning of nPos to end of Attribute String
					sStrTmp = cTableWindowFin.sRequiredStringComplete.Mid(nPos, nLength);
					// Get the position of the Unit Seperator
					nPosUnitDelim = sStrTmp.Scan(sUnitChar);
					// Get the position of the Record Seperator
					nPosRecDelim = sStrTmp.Scan(sRecChar);
					// Get the first part of the string upto the Unit Seperator
					nPosStr = cTableWindowFin.sRequiredStringComplete.Left(nPos + 1).Length;
					nPosStr = nPosStr + nPosUnitDelim;
					sStr1 = cTableWindowFin.sRequiredStringComplete.Left(nPosStr);
					// Get the last part of the string
					sStr2 = sStrTmp.Mid(nPosRecDelim, nLength);
					// Create new Attribute String
					sNewRequiredString = sStr1 + p_sCodePartValue + sStr2;
					// Replace existing Attribute String with new string
					cTableWindowFin.sRequiredStringComplete = sNewRequiredString;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// This function will scan an attribute string and extract codepart values. If an existing codepart value differs from the required codepart
		/// values of a Completion or PseudoCode the user will be informed that one or more existing codepart values will be modified.
		/// </summary>
		/// <param name="p_sString"></param>
		/// <returns></returns>
		public virtual SalNumber ScanAttributeString(SalString p_sString)
		{
			#region Local Variables
			SalBoolean bReplace = false;
			SalBoolean bNoReplace = false;
			SalNumber nPos1 = 0;
			SalNumber nPos2 = 0;
			SalNumber nLength = 0;
			SalNumber nChoice = 0;
			SalString sTmp_CodePart = "";
			SalString sTmpString = "";
			SalString sTmp_Value = "";
			SalString sUnitChar = "";
			SalString sRecChar = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (p_sString != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					sTmpString = p_sString;
					nLength = sTmpString.Length;
					sUnitChar = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter();
					sRecChar = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
					while (sTmpString != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						nPos1 = sTmpString.Scan(sUnitChar);
						sTmp_CodePart = sTmpString.Left(nPos1);
						nPos2 = sTmpString.Scan(sRecChar);
						sTmp_Value = sTmpString.Mid(nPos1 + 1, nPos2 - nPos1 - 1);
						if (sTmp_Value != Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							if ((Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sTmp_CodePart, cTableWindowFin.sRequiredStringComplete) == Ifs.Fnd.ApplicationForms.Const.strNULL) || bReplace) 
							{
								ModifyRequiredString(sTmp_CodePart, sTmp_Value);
							}
							else if (sTmp_CodePart == "ACCOUNT" && cTableWindowFin.bPseudoAccount) 
							{
								cTableWindowFin.bPseudoAccount = false;
								ModifyRequiredString(sTmp_CodePart, sTmp_Value);
							}
							else
							{
								if (Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sTmp_CodePart, cTableWindowFin.sRequiredStringComplete) != sTmp_Value) 
								{
									// Prompt User
                                    nChoice = Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_OverwriteCodeParts, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2));
									if (nChoice == Sys.IDYES) 
									{
										// Replace values in sRequiredStringComplete with new values
										ModifyRequiredString(sTmp_CodePart, sTmp_Value);
										bReplace = true;
									}
									else
									{
										bNoReplace = true;
									}
								}
							}
						}
						if (bNoReplace) 
						{
							sTmpString = Ifs.Fnd.ApplicationForms.Const.strNULL;
						}
						else
						{
							sTmpString = sTmpString.Mid(nPos2 + 1, nLength);
						}
					}
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="p_sCodePart"></param>
		/// <param name="p_sCodePartValue"></param>
		/// <returns></returns>
		public virtual SalBoolean ValidateCodePart(SalString p_sCodePart, SalString p_sCodePartValue)
		{
			#region Local Variables
			SalBoolean bCommandOk = false;
			SalBoolean bValue = false;
			SalString lsStmt = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				cTableWindowFin.sCodePartValue = p_sCodePartValue;
				cTableWindowFin.dNull = SalDateTime.Null;
				if (p_sCodePart.Scan("ACCOUNT") != -1) 
				{
					if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Text_Field_Translation_API.Get_Text"))) 
					{
						return false;
					}
					if (cTableWindowFin.bIsNullCodeParts) 
					{
						if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Part_A_API.Validate_Account_Pseudo__"))) 
						{
							return false;
						}
						lsStmt = "&AO.Accounting_Code_Part_A_API.Validate_Account_Pseudo__(\r\n" +
						"                                                		:i_hWndSelf.colsCompany,\r\n" +
						"					:cTableWindowFin.sCodePart,\r\n" +
						"                                                		:cTableWindowFin.sCodePartValue,\r\n" +
						"					:cTableWindowFin.dNull,\r\n" +
						"					:cTableWindowFin.sRequiredString,\r\n" +
						"                                               			:cTableWindowFin.sRequiredStringComplete,\r\n" +
						"                                                                                :cTableWindowFin.sUserName ); ";
						lsStmt = lsStmt + ":cTableWindowFin.sCodePartDescription := &AO.Text_Field_Translation_API.Get_Text(\r\n" +
						"					:i_hWndSelf.colsCompany, \r\n" +
						"					'CODEA',\r\n" +
						"					:cTableWindowFin.sCodePartValue); ";
						bCommandOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + lsStmt + "END;");
					}
					else
					{
						if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Text_Field_Translation_API.Get_Text"))) 
						{
							return false;
						}
						lsStmt = ":cTableWindowFin.sIsPseudoCode := &AO.PSEUDO_CODES_API.Exist_Pseudo_Code(\r\n" +
						"                                                		:i_hWndSelf.colsCompany,\r\n" +
						"					:cTableWindowFin.sCodePartValue);";
						lsStmt = lsStmt + "&AO.ACCOUNT_API.Get_Required_Code_Part_Pseudo(\r\n" +
						"					:cTableWindowFin.sRequiredString,\r\n" +
						"					:i_hWndSelf.colsCompany,\r\n" +
						"					:cTableWindowFin.sCodePartValue ); ";
						lsStmt = lsStmt + ":cTableWindowFin.sCodePartDescription := &AO.Text_Field_Translation_API.Get_Text(\r\n" +
						"					:i_hWndSelf.colsCompany, \r\n" +
						"					'CODEA',\r\n" +
						"					:cTableWindowFin.sCodePartValue); ";
						bCommandOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + lsStmt + "END;");
						if (bCommandOk) 
						{
							if (cTableWindowFin.sIsPseudoCode == "FALSE") 
							{
								bValue = CheckCompletion(p_sCodePart);
							}
							else
							{
								bValue = CheckPseudoCode(p_sCodePart);
							}
							bCommandOk = bValue;
						}
					}
				}
				else if (p_sCodePart.Scan("CODE\\_") != -1) 
				{
					cTableWindowFin.sCodePart = p_sCodePart.Right(1);
					if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Part_Value_API.Exist"))) 
					{
						return false;
					}
					if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Text_Field_Translation_API.Get_Text"))) 
					{
						return false;
					}
					lsStmt = "&AO.Accounting_Code_Part_Value_API.Exist(\r\n" +
					"                                                		:i_hWndSelf.colsCompany,\r\n" +
					"					:cTableWindowFin.sCodePart,\r\n" +
					"                                                		:cTableWindowFin.sCodePartValue ); ";
					lsStmt = lsStmt + ":cTableWindowFin.sCodePartDescription := &AO.Text_Field_Translation_API.Get_Text(\r\n" +
					"					:i_hWndSelf.colsCompany, \r\n" +
					"					'CODE' || :cTableWindowFin.sCodePart,\r\n" +
					"					:cTableWindowFin.sCodePartValue); ";
					bCommandOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + lsStmt + "END;");
					if (bCommandOk) 
					{
						bValue = CheckCompletion(p_sCodePart);
						bCommandOk = bValue;
					}
				}
				if (!(bCommandOk)) 
				{
					return Sys.VALIDATE_Cancel;
				}
				Sal.SendMsgToChildren(i_hWndFrame, Const.PAM_SetCodePartValue, 0, 0);
				Sal.SendMsgToChildren(i_hWndFrame, Const.PAM_SetCodePartDesc, p_sCodePart.ToHandle(), cTableWindowFin.sCodePartValue.ToHandle());
				Sal.SendMsgToChildren(i_hWndSelf, Const.PAM_SetCodePartDesc, p_sCodePart.ToHandle(), cTableWindowFin.sCodePartValue.ToHandle());
				return Sys.VALIDATE_Ok;
			}
			#endregion
		}
		// Bug 76007 - End
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
						// RUNTIME_CORRECTION: Used i_hWndSelf instead of i_hWndFrame since that doesn't refer to correct object cTableWindowFin
						bOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n " + cSessionManager.c_sDbPrefix + "Currency_Rate_API.Fetch_Currency_Rate_Base(\r\n" +
							" :i_hWndSelf.cTableWindowFin.i_nFinConversionFactor, \r\n" +
							" :i_hWndSelf.cTableWindowFin.i_nFinCurrencyRate,\r\n" +
							" :i_hWndSelf.cTableWindowFin.i_lsFinInverted,\r\n" +
							" :i_hWndSelf.cTableWindowFin.sFinCompany,\r\n" +
							" :i_hWndSelf.cTableWindowFin.sFinCurrencyCode,\r\n" +
							" :i_hWndSelf.cTableWindowFin.sFinBaseCurrencyCode,\r\n" +
							" :i_hWndSelf.cTableWindowFin.sFinCurrencyType, \r\n" +
							" :i_hWndSelf.cTableWindowFin.dFinDate,\r\n" +
							" 'DUMMY');\r\n SELECT " + cSessionManager.c_sDbPrefix + "Currency_Code_API.Get_Currency_Rounding(:i_hWndSelf.cTableWindowFin.sFinCompany, :i_hWndSelf.cTableWindowFin.sFinCurrencyCode),\r\n " + cSessionManager.c_sDbPrefix + "Currency_Code_API.Get_Currency_Rounding(:i_hWndSelf.cTableWindowFin.sFinCompany, :i_hWndSelf.cTableWindowFin.sFinBaseCurrencyCode)\r\n" +
							" INTO :i_hWndSelf.cTableWindowFin.i_nFinTransRound, :i_hWndSelf.cTableWindowFin.i_nFinBaseRound FROM DUAL;\r\n END;");
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
						// RUNTIME_CORRECTION: Used i_hWndSelf instead of i_hWndFrame since that doesn't refer to correct object cTableWindowFin
						bOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n " + cSessionManager.c_sDbPrefix + "CURRENCY_CODE_API.Get_No_Of_Decimals_In_Rate_(\r\n" +
							" :i_hWndSelf.cTableWindowFin.i_nFinRound, \r\n" +
							" :i_hWndSelf.cTableWindowFin.sFinCompany,\r\n" +
							" :i_hWndSelf.cTableWindowFin.sFinCurrencyCode\r\n" +
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
							hints.Add("Currency_Code_API.Get_Currency_Rounding", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						// Insert new code here...
						// RUNTIME_CORRECTION: Used i_hWndSelf instead of i_hWndFrame since that doesn't refer to correct object cTableWindowFin
                            bOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n &AO.Currency_Rate_API.Get_Parallel_Currency_Rate(\r\n" +
                                " :i_hWndSelf.cTableWindowFin.i_nFinThirdCurrencyRate INOUT, \r\n" +
                                " :i_hWndSelf.cTableWindowFin.i_nFinThirdConversionFactor INOUT,\r\n" +
                                " :i_hWndSelf.cTableWindowFin.i_lsFinThirdInverted INOUT,\r\n" +
                                " :i_hWndSelf.cTableWindowFin.sFinCompany IN,\r\n" +
                                " :i_hWndSelf.cTableWindowFin.sFinCurrencyCode IN,\r\n" +
                                " :i_hWndSelf.cTableWindowFin.dFinDate IN,\r\n" +
                                " :i_hWndSelf.cTableWindowFin.sParallelCurrencyRateType IN,\r\n" +
                                " :i_hWndSelf.cTableWindowFin.i_sFinParallelBaseType IN,\r\n" +
                                " :i_hWndSelf.cTableWindowFin.sFinBaseCurrencyCode IN,\r\n" +
                                " :i_hWndSelf.cTableWindowFin.sFinThirdCurrencyCode IN,\r\n" +
                                " :i_hWndSelf.cTableWindowFin.sNullValue IN,\r\n" +
                                " :i_hWndSelf.cTableWindowFin.sNullValue IN\r\n" +
                                ");\r\n" +
                            "\r\n SELECT " + cSessionManager.c_sDbPrefix + "Currency_Code_API.Get_Currency_Rounding(:i_hWndSelf.cTableWindowFin.sFinCompany, :i_hWndSelf.cTableWindowFin.sFinThirdCurrencyCode)\r\n" +
							"INTO :i_hWndSelf.cTableWindowFin.i_nFinTransAmountRound FROM DUAL;\r\n END;");
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
		
		/// <summary>
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sThirdCurrencyCode"></param>
		/// <param name="sBaseCurrencyCode"></param>
		/// <param name="dDate"></param>
		/// <param name="sIsThirdEMU"></param>
		/// <param name="sIsBaseEMU"></param>
		/// <returns></returns>
        public SalBoolean GetThirdCurrencyAttributes(SalString sCompany, SalString sThirdCurrencyCode, SalString sBaseCurrencyCode, SalDateTime dDate, SalString sIsThirdEMU, SalString sIsBaseEMU, SalString sParallelBaseType, SalString sParallelRateType)
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
                            hints.Add("Currency_Rate_API.Get_Parallel_Currency_Rate", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            hints.Add("Currency_Code_API.Get_Currency_Rounding", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            hints.Add("Company_Finance_API.Get_Parallel_Base_Db", System.Data.ParameterDirection.Input);
						// Insert new code here...
						// RUNTIME_CORRECTION: Used i_hWndSelf instead of i_hWndFrame since that doesn't refer to correct object cTableWindowFin
                            sParallelCurrencyRateType = sParallelRateType;
                            bOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n " + cSessionManager.c_sDbPrefix + "Currency_Rate_API.Get_Parallel_Currency_Rate(\r\n" +
							" :i_hWndSelf.cTableWindowFin.i_nFinThirdCurrencyRate,\r\n" +
                            " :i_hWndSelf.cTableWindowFin.i_nFinThirdConversionFactor, \r\n" +
							" :i_hWndSelf.cTableWindowFin.i_lsFinThirdInverted,\r\n" +
							" :i_hWndSelf.cTableWindowFin.sFinCompany,\r\n" +
                            " :i_hWndSelf.cTableWindowFin.sFinCurrencyCode,\r\n" +
                            " :i_hWndSelf.cTableWindowFin.dFinDate,\r\n" +
                            " :i_hWndSelf.cTableWindowFin.sParallelCurrencyRateType,\r\n" +
                            " :i_hWndSelf.cTableWindowFin.i_sFinParallelBaseType,\r\n" +
                            " :i_hWndSelf.cTableWindowFin.sFinBaseCurrencyCode,\r\n" +
                            " :i_hWndSelf.cTableWindowFin.sFinThirdCurrencyCode);\r\n" +
                            " \r\n :i_hWndSelf.cTableWindowFin.i_sFinParallelBaseType := &AO.Company_Finance_API.Get_Parallel_Base_Db(:i_hWndSelf.cTableWindowFin.sFinCompany);\r\n" +
                            "\r\n :i_hWndSelf.cTableWindowFin.i_nFinTransAmountRound := &AO.Currency_Code_API.Get_Currency_Rounding(:i_hWndSelf.cTableWindowFin.sFinCompany, :i_hWndSelf.cTableWindowFin.sFinThirdCurrencyCode);\r\nEND;");
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
							// RUNTIME_CORRECTION: Used i_hWndSelf instead of i_hWndFrame since that doesn't refer to correct object cTableWindowFin
							bOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n " + cSessionManager.c_sDbPrefix + "CURRENCY_CODE_API.Get_No_Of_Decimals_In_Rate_(\r\n" +
								" :i_hWndSelf.cTableWindowFin.i_nFinThirdRound, \r\n" +
								" :i_hWndSelf.cTableWindowFin.sFinCompany,\r\n" +
								" :i_hWndSelf.cTableWindowFin.sFinThirdCurrencyCode\r\n" +
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
		
		/// <summary>
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		public virtual SalBoolean _OneRowSelected(SalWindowHandle hWnd)
		{
			#region Local Variables
			SalNumber nCurrentRow = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				nCurrentRow = Sys.TBL_MinRow;
				if (Sal.TblFindNextRow(hWnd, ref nCurrentRow, Sys.ROW_Selected, 0)) 
				{
					if (Sal.TblFindNextRow(hWnd, ref nCurrentRow, Sys.ROW_Selected, 0)) 
					{
						Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_OneRowSelected, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
						Sal.Abort(-1);
						return false;
					}
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nMpccomAccId"></param>
		/// <returns></returns>
		public virtual SalString _MPCCOMWhereStmt(SalNumber nMpccomAccId)
		{
			#region Local Variables
			SalString sWhere = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (nMpccomAccId == SalNumber.Null) 
				{
					return Ifs.Fnd.ApplicationForms.Const.strNULL;
				}
				sWhere = nMpccomAccId.ToString(0);
				sWhere = "ACCOUNTING_ID = " + sWhere;
				return sWhere;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sVoucherType"></param>
		/// <param name="sFunctionGroup"></param>
		/// <param name="sAccount"></param>
		/// <param name="nMpccomAccId"></param>
		/// <param name="nVoucherNo"></param>
		/// <param name="nAccountingYear"></param>
		/// <returns></returns>
		public virtual SalString _GetWhereStmt(SalString sCompany, SalString sVoucherType, SalString sFunctionGroup, SalString sAccount, SalNumber nMpccomAccId, SalNumber nVoucherNo, SalNumber nAccountingYear)
		{
			#region Local Variables
			SalString sWhere = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				i_sVoucherType = sVoucherType;
				i_nVoucherNo = nVoucherNo;
				i_nAccountingYear = nAccountingYear;
				if (sFunctionGroup == "L") 
				{
					return _MPCCOMWhereStmt(nMpccomAccId);
				}
				// 0 = Zero
				else if (sFunctionGroup == "0") 
				{
					return _MPCCOMWhereStmt(nMpccomAccId);
				}
				// O = Letter 'O'
				else if (sFunctionGroup == "O") 
				{
					return _MPCCOMWhereStmt(nMpccomAccId);
				}
				else if (sFunctionGroup == "A") 
				{
					sWhere = "COMPANY =  '" + sCompany + "' AND voucher_type = '" + sVoucherType + "' AND account = '" + sAccount + "' AND voucher_number = " + nVoucherNo.ToString(0) + " AND accounting_year =" + nAccountingYear.ToString(0);
					return sWhere;
				}
				else if (sFunctionGroup == "B") 
				{
					sWhere = " COMPANY =  '" + sCompany + "' AND voucher_type = '" + sVoucherType + "' AND voucher_no = " + nVoucherNo.ToString(0);
					return sWhere;
				}
				else if (sFunctionGroup == "C") 
				{
					sWhere = "voucher_type = '" + sVoucherType + "' AND voucher_no = " + nVoucherNo.ToString(0) + " AND accounting_year =" + nAccountingYear.ToString(0);
					return sWhere;
				}
				else if (sFunctionGroup == "F") 
				{
					sWhere = " voucher_type_ref = '" + sVoucherType + "' AND voucher_no_ref = " + nVoucherNo.ToString(0) + " AND accounting_year_ref =" + nAccountingYear.ToString(0);
					return sWhere;
				}
				else if (sFunctionGroup == "G") 
				{
					sWhere = " COMPANY =  '" + sCompany + "' AND voucher_type = '" + sVoucherType + "' AND voucher_no = " + nVoucherNo.ToString(0) + " AND accounting_year =" + nAccountingYear.ToString(0);
					return sWhere;
				}
				else if (sFunctionGroup == "I") 
				{
					sWhere = " voucher_type_ref = '" + sVoucherType + "' AND voucher_no_ref = " + nVoucherNo.ToString(0) + " AND accounting_year_ref =" + nAccountingYear.ToString(0);
					return sWhere;
				}
				else if (sFunctionGroup == "J") 
				{
					DbPLSQLBlock(cSessionManager.c_hSql, " SELECT voucher_no_reference, voucher_type_reference, accounting_year_reference\r\n" +
						"                                                INTO   :i_hWndFrame.cTableWindowFin.i_nVoucherNumberRef,  :i_hWndFrame.cTableWindowFin.i_sVoucherTypeRef, :i_hWndFrame.cTableWindowFin.i_nAccountingYearRef\r\n" +
						"                                                FROM  &AO.GEN_LED_VOUCHER\r\n" +
						"                                                WHERE company  = :i_hWndFrame.cTableWindowFin.i_sCompany\r\n" +
						"                                                AND voucher_type = :i_hWndFrame.cTableWindowFin.i_sVoucherType\r\n" +
						"                                                AND voucher_no    =" + ":i_hWndFrame.cTableWindowFin.i_nVoucherNo\r\n" +
						"                                                AND accounting_year = :i_hWndFrame.cTableWindowFin.i_nAccountingYear ");
					sWhere = " voucher_type_ref = " + "'" + cTableWindowFin.FromHandle(i_hWndFrame).i_sVoucherTypeRef + "'" + "  AND voucher_no_ref  = " + cTableWindowFin.FromHandle(i_hWndFrame).i_nVoucherNumberRef.ToString(0) + "\r\n" +
					"        AND accounting_year_ref =" + cTableWindowFin.FromHandle(i_hWndFrame).i_nAccountingYearRef.ToString(0);
					return sWhere;
				}
				else if (sFunctionGroup == "N") 
				{
					sWhere = " COMPANY =  '" + sCompany + "' AND voucher_type_REF = '" + sVoucherType + "' AND voucher_no_REF = " + nVoucherNo.ToString(0);
					return sWhere;
				}
				else if (sFunctionGroup == "U") 
				{
					sWhere = " COMPANY =  '" + sCompany + "' AND voucher_type = '" + sVoucherType + "' AND voucher_no = " + nVoucherNo.ToString(0);
					return sWhere;
				}
			}

			return "";
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sWindowName"></param>
		/// <returns></returns>
		public virtual SalBoolean _CheckWindow(SalString sWindowName)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sWindowName != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					if (Ifs.Fnd.ApplicationForms.Var.Security.IsPresObjectAvailable(sWindowName)) 
					{
						if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(sWindowName)) 
						{
							return true;
						}
					}
					return false;
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sWindowName"></param>
		/// <param name="lsWhereStmt"></param>
		/// <returns></returns>
		public virtual SalNumber _CreateAndPopulateWindow(SalString sWindowName, SalString lsWhereStmt)
		{
			#region Local Variables
			SalWindowHandle hWndTmp = SalWindowHandle.Null;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				hWndTmp = SessionCreateWindow(sWindowName, Sys.hWndMDI);
				Sal.SendMsg(hWndTmp, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, lsWhereStmt.ToHandle());
				Sal.SendMsg(hWndTmp, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nMpccomAccId"></param>
		/// <param name="sFunctionGroup"></param>
		/// <returns></returns>
		public virtual SalString _GetWindowName(SalNumber nMpccomAccId, SalString sFunctionGroup)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (nMpccomAccId != SalNumber.Null) 
				{
					if (sFunctionGroup == "L") 
					{
						return Pal.GetActiveInstanceName("tbwAccounting");
					}
					// 0 = Zero
					else if (sFunctionGroup == "0") 
					{
						return Pal.GetActiveInstanceName("tbwAccounting");
					}
					// O = Letter 'O'
					else if (sFunctionGroup == "O") 
					{
						return Pal.GetActiveInstanceName("tbwAccounting");
					}
				}
				else
				{
					if (sFunctionGroup == "A") 
					{
						return Pal.GetActiveInstanceName("tbwAccTrans");
					}
					else if (sFunctionGroup == "B") 
					{
						return Pal.GetActiveInstanceName("tbwPaymentPerCurrencyCuQry");
					}
					else if (sFunctionGroup == "C") 
					{
						return Pal.GetActiveInstanceName("tbwCompanyConsTrans");
					}
					else if (sFunctionGroup == "F") 
					{
						return Pal.GetActiveInstanceName("tbwCustomerInvOview");
					}
					else if (sFunctionGroup == "G") 
					{
						return Pal.GetActiveInstanceName("tbwNettingQry");
					}
					else if (sFunctionGroup == "I") 
					{
						return Pal.GetActiveInstanceName("tbwSupplierInvOview");
					}
					else if (sFunctionGroup == "J") 
					{
						return Pal.GetActiveInstanceName("tbwSupplierInvOview");
					}
					else if (sFunctionGroup == "N") 
					{
						return Pal.GetActiveInstanceName("frmMixedPaymentPayDetails");
					}
					else if (sFunctionGroup == "U") 
					{
						return Pal.GetActiveInstanceName("tbwPaymentPerCurrencySuQry");
					}
					else
					{
						i_sNotSupported = "TRUE";
					}
				}
			}

			return "";
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

		// Bug 109903 Begin
		// When the form is closing need to check if profile is changed & update 'ColVisibilityFin'
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public new SalBoolean FrameShutdownUser(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				SetCodepartVisibilityInProfile();
				return ((cTableWindowFinBase)this).FrameShutdownUser(nWhat);
			}
			#endregion
		}
		// Bug 109903 End
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cTableWindowFin_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Const.PAM_CallChanged:
					this.cTableWindowFin_OnPAM_CallChanged(sender, e);
					break;
				
				case Const.PAM_ChangedChildText:
					this.cTableWindowFin_OnPAM_ChangedChildText(sender, e);
					break;
				
				case Const.PAM_GetAndSetDefaultCompany:
					this.cTableWindowFin_OnPAM_GetAndSetDefaultCompany(sender, e);
					break;
								
				case Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged:
					this.cTableWindowFin_OnPM_UserProfileChanged(sender, e);
					break;
				
				case Sys.SAM_CreateComplete:
					this.cTableWindowFin_OnSAM_CreateComplete(sender, e);
					break;
				
				case Const.PAM_ChangeCompany:
					this.cTableWindowFin_OnPAM_ChangeCompany(sender, e);
					break;
				
				case Const.PAM_DisableUnusedCodeParts:
					this.cTableWindowFin_OnPAM_DisableUnusedCodeParts(sender, e);
					break;
				
				case Sys.SAM_Create:
					this.cTableWindowFin_OnSAM_Create(sender, e);
					break;
				
				case Const.PAM_SynchronizeWithProfile:
					e.Handled = true;
					e.Return = this.GetVisibility(Sys.wParam, Sys.lParam);
					return;
				
				case Const.PAM_FetchCodePartValue:
					e.Handled = true;
					e.Return = this.FetchCodePartValue(Sys.wParam, SalString.FromHandle(Sys.lParam)).ToHandle();
					return;
				
				// Bug 76007 - Begin
				
				case Const.PAM_ValidateCodePartValues:
					this.cTableWindowFin_OnPAM_ValidateCodePartValues(sender, e);
					break;
				
				case Const.PAM_CheckExternalProject:
					e.Handled = true;
					e.Return = this.vrtEnableDisableProjectActivityId(SalString.FromHandle(Sys.wParam));
					return;
				
				// Bug 76007 - End
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_CallChanged event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cTableWindowFin_OnPAM_CallChanged(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.DataSourceClear(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
			Sal.SendMsg(this.i_hWndSelf, Const.PAM_GetAndSetDefaultCompany, 0, 0);
            // Bug 93629 Begin.
            RefreshCodePartInfo(this.i_sCompany, cSessionManager.c_sDbPrefix);
            // Bug 93629 End.
			Sal.SendMsgToChildren(this.i_hWndSelf, Const.PAM_CallChanged, 0, 0);
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// PAM_ChangedChildText event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cTableWindowFin_OnPAM_ChangedChildText(object sender, WindowActionsEventArgs e)
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
		private void cTableWindowFin_OnPAM_GetAndSetDefaultCompany(object sender, WindowActionsEventArgs e)
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
		private void cTableWindowFin_OnPM_UserProfileChanged(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            // No need to check whether company is changed, this method is called after changing and setting company
            // DataSourceClear and vrtSetWindowTitle is executed in PAM_CallChanged so invoke it directly for the window instead of having duplicate code
			Sal.SendMsg(this.i_hWndSelf, Const.PAM_CallChanged, 0, 0);
            e.Return = true;
            return;
			#endregion
		}
		
		/// <summary>
		/// SAM_CreateComplete event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cTableWindowFin_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.SynchronizeWithProfile(this.i_hWndSelf);
			Sal.GetWindowText(this.i_hWndSelf, ref this.i_sOldLabel, 99);
			// Insert new code here...
			Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// PAM_ChangeCompany event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cTableWindowFin_OnPAM_ChangeCompany(object sender, WindowActionsEventArgs e)
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
					// This is not required since change company now opens a new form with the changed company
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_DisableUnusedCodeParts event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cTableWindowFin_OnPAM_DisableUnusedCodeParts(object sender, WindowActionsEventArgs e)
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
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cTableWindowFin_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam)) 
			{
				this.SynchronizeWithProfile(this.i_hWndSelf);
				e.Return = true;
				return;
			}
			e.Return = false;
			return;
			#endregion
		}
		
		/// <summary>
		/// PAM_ValidateCodePartValues event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cTableWindowFin_OnPAM_ValidateCodePartValues(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.i_sSqlColumn = SalString.FromHandle(Sys.wParam);
			this.i_sCodePartValue = SalString.FromHandle(Sys.lParam);
			this.AttrFetchCodePart(ref cTableWindowFin.sRequiredStringComplete, Sal.TblQueryContext(this.i_hWndSelf));
			if (this.ValidateCodePart(this.i_sSqlColumn, this.i_sCodePartValue) != Sys.VALIDATE_Cancel) 
			{
				this.AttrDecodeCodePart(ref cTableWindowFin.sRequiredString, ref cTableWindowFin.sRequiredStringComplete);
				e.Return = Sys.VALIDATE_Ok;
				return;
			}
			else
			{
				e.Return = Sys.VALIDATE_Cancel;
				return;
			}
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
		
		// Bug 108483, Begin
		/// <summary>
        /// Gets CodePart Names from Server. This is called by tbwCodePart to refresh Code Part cache on SaveCheckOk()
        /// </summary>
        /// <param name="sCompany"></param>
        /// <param name="sAppOwner"></param>
        /// <returns></returns>
        public virtual SalBoolean ForceGetCodePartNames(SalString sCompany, SalString sAppOwner)
        {
            using (new SalContext(this))
            {
                return _cFinlibServices.ForceGetCodePartNames(sCompany, sAppOwner);
            }
        }
		// Bug 108483, End

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
		/// Multiple Inheritance: Cast operator from type cTableWindowFin to type cTableManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cTableManager(cTableWindowFin self)
		{
			return self._cTableManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowFin to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cTableWindowFin self)
		{
			return ((cSessionManager)self._cTableManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowFin to type cWindowTranslation.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cWindowTranslation(cTableWindowFin self)
		{
			return ((cWindowTranslation)self._cTableManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowFin to type SalToolTipManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator SalToolTipManager(cTableWindowFin self)
		{
			return self._SalToolTipManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowFin to type cFinlibServices.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cFinlibServices(cTableWindowFin self)
		{
			return self._cFinlibServices;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableManager to type cTableWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowFin(cTableManager super)
		{
			return ((cTableWindowFin)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cTableWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowFin(cSessionManager super)
		{
			return ((cTableWindowFin)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cWindowTranslation to type cTableWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowFin(cWindowTranslation super)
		{
			return ((cTableWindowFin)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type SalToolTipManager to type cTableWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowFin(SalToolTipManager super)
		{
			return ((cTableWindowFin)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cFinlibServices to type cTableWindowFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowFin(cFinlibServices super)
		{
			return ((cTableWindowFin)super._derived);
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
		public new static cTableWindowFin FromHandle(SalWindowHandle handle)
		{
			return ((cTableWindowFin)SalWindow.FromHandle(handle, typeof(cTableWindowFin)));
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
		public virtual SalBoolean vrtEnableDisableProjectActivityId(SalString sCodePartValue)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.EnableDisableProjectActivityId(sCodePartValue);
			}
			else
			{
				return lateBind.vrtEnableDisableProjectActivityId(sCodePartValue);
			}
		}
		
		// Bug 109903 Begin
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtFrameShutdownUser(SalNumber nWhat)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.FrameShutdownUser(nWhat);
			}
			else
			{
				return lateBind.vrtFrameShutdownUser(nWhat);
			}
		}
		// Bug 109903 End
		
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
            //Bug 108483, Begin. Added the else part
			if (this.i_sCompany != sTempCompany)
			{
                //TODO: iURL gets cleared in SetCompnay(). Therefore store iUrl in a variable and restore it after SetCompnay(). A better solution must be found later.
                //Bug 89864, Begin. Store iUrl in temporary variable to avoid it from getting cleared.
                iURL.Clone(tempURL);
				SetCompany(sTempCompany);
                iURL = tempURL;
                //Bug 89864, End.
			}
            else
            {
                this.SynchronizeWithProfile(this.i_hWndSelf);
                // Bug 112164, Begin. Removed sending PAM_CallChanged. called following 2 methods instead
                RefreshCodePartInfo(this.i_sCompany, cSessionManager.c_sDbPrefix);
                Sal.SendMsgToChildren(this.i_hWndSelf, Const.PAM_CallChanged, 0, 0);
                // Bug 112164, End
            }
            //Bug 108483, End
			return base.PrepareActivate(URL);
        }
		#endregion
		
		#region Multiple Inheritance Late Bind Interface
		
		public interface LateBind
		{
			SalBoolean vrtDataSourceReferenceItems(SalString sReference, SalString sReturnKeyName, SalArray<SalString> sColumnNames, SalArray<SalString> sColumnPrompts);
			SalBoolean vrtEnableDisableProjectActivityId(SalString sCodePartValue);
			// Bug 109903 Begin
			SalBoolean vrtFrameShutdownUser(SalNumber nWhat);
			// Bug 109903 End
			SalString vrtGetWindowTitle();
			SalBoolean vrtSetWindowTitle();
			SalBoolean vrtShowActiveCompany();
		}
		#endregion
	}
}
