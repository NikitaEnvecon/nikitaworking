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
// 13-05-17    MAAYLK    Bug 108483, Added PAM_ChildTableSynchronizeProfile to refresh the visibility of Code Part columns of child table
// 13-07-02    MAAYLK    Bug 109903, Replaced bug 103031. Override FrameShutDownUser.
// 14-01-08    CHARLK    PBFI-4424 , Modify cChildTableFin_OnPAM_ValidateCodePartValues.
// 14-03-06    CHARLK    PBFI-5695 , Chaged code part and psuedocode validation to use the company in the data row not global company.
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
using System.Collections.Generic;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// </summary>
	public partial class cChildTableFin : cChildTableFinBase
	{
		// Multiple Inheritance: Base class instance.
		protected cFinlibServices _cFinlibServices;
		
		
		#region Fields
		[ThreadStatic]
		public static SalString sRequiredStringComplete;
		[ThreadStatic]
		public static SalString sRequiredString;
		[ThreadStatic]
		public static SalString sCodePart;
		[ThreadStatic]
		public static SalString sCodePartValue;
		[ThreadStatic]
		public static SalString sCodePartDescription;
		[ThreadStatic]
		public static SalString sNull;
		[ThreadStatic]
		public static SalDateTime dNull;
		[ThreadStatic]
		public static SalString sTempCodePart;
		[ThreadStatic]
		public static SalString sCompletionAttr;
		[ThreadStatic]
		public static SalString sPseudoCodeAttr;
		[ThreadStatic]
		public static SalString sIsPseudoCode;
		[ThreadStatic]
		public static SalBoolean bIsNullCodeParts;
		[ThreadStatic]
		public static SalString sUserName;
		[ThreadStatic]
		public static SalBoolean bPseudoAccount;
		[ThreadStatic]
		public static SalString sTempHoldValue;

		#region Static Fields initialization
		[ThreadStatic]
		private static bool threadStaticsInitialized;

		internal static void InitThreadStaticFields()
		{
			if (!threadStaticsInitialized)
			{
				threadStaticsInitialized = true;
				sRequiredStringComplete = "";
				sRequiredString = "";
				sCodePart = "";
				sCodePartValue = "";
				sCodePartDescription = "";
				sNull = "";
				dNull = SalDateTime.Null;
				sTempCodePart = "";
				sCompletionAttr = "";
				sPseudoCodeAttr = "";
				sIsPseudoCode = "";
				bIsNullCodeParts = false;
				sUserName = "";
				bPseudoAccount = false;
				sTempHoldValue = "";
			}
		}
		#endregion

		public SalString i_sSqlColumn = "";
		public SalString i_sCodePartValue = "";
		public SalString i_sCompany = "";
		public SalString i_sChildText = "";
		public SalString i_sCompanyHelp = "";
        private SalString sCompanyColumnName = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cChildTableFin()
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
		public cChildTableFin(ISalWindow derived)
		{
			// Attach derived instance.
			this._derived = derived;
            InitThreadStaticFields();
			// Initialize second-base instances.
			InitializeMultipleInheritance();
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Attach actions handler to derived instance.
			this._derived.AttachMessageActions(this);
		}
		#endregion
		
		#region Multiple Inheritance Fields
        // Bug 109903, Removed 103031, Begin
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
        // Bug 109903, Removed 103031, Begin
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
			// Bug Id 91199, Begin
			SalString sColValue = "";
			SalString sItemValue = "";
			// Bug Id 91199, End
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
				// Bug Id 91199, Begin
				if (Ifs.Fnd.ApplicationForms.Var.Profile.ValueStringGet(Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndSelf), "ReadOnly", Ifs.Fnd.ApplicationForms.Const.strNULL, ref sColValue) > 0) 
				{
					sColValue = sColValue + ",";
				}
				// Bug Id 91199, End
				while (n < i_nChildCount) 
				{
					if ((Sal.WindowClassName(i_hWndChild[n]) == "cColumnCodePartFin") || (Sal.WindowClassName(i_hWndChild[n]) == "cColumnCodePartInt")) 
					{
						sSqlColumn = cColumn.FromHandle(i_hWndChild[n]).p_sSqlColumn;
						// Bug Id 91199 - Begin
						Sal.GetItemName(i_hWndChild[n], ref sItemValue);
						if (((sSqlColumn.Scan("CODE_") != -1) || (sSqlColumn.Scan("ACCOUNT") != -1) || (sSqlColumn.Scan("QUANTITY") != -1) || (sSqlColumn.Scan("PROCESS_CODE") != -1) || (sSqlColumn.Scan("TEXT") != -1)) && (((bool)Sal.SendMsg(i_hWndChild[n], Ifs.Fnd.ApplicationForms.Const.PM_DataItemFlagQuery, 
							Ifs.Fnd.ApplicationForms.Const.FIELD_Insert, 0)) || (sColValue.Scan(sItemValue + ",") != -1))) 
						{
							sValue = SalString.FromHandle(Sal.SendMsg(i_hWndChild[n], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0));
							sPAttr = sPAttr + sSqlColumn + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + sValue + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
						}
						// Bug Id 91199 - End
					}
					n = n + 1;
				}
				if (sPrevAccount != Ifs.Fnd.ApplicationForms.Const.strNULL && sPrevAccount != Ifs.Fnd.ApplicationForms.Int.PalAttrGet("ACCOUNT", sPAttr)) 
				{
					sPrevAccount = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("ACCOUNT", sPAttr);
					// Bug 81052, Begin , Did the validation only if the Account exist
					if (sPrevAccount != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						bOk = ValidateCodePart("ACCOUNT", sPrevAccount);
					}
					// Bug 81052, End
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
					if (Sal.SendMsgToChildren(i_hWndSelf, Const.PAM_SetCodePartDescription, nLen, lsAttr.ToHandle())) 
					{
						return true;
					}
				}
				return false;
			}
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
						// Bug 83771, If condition was removed
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
					n = n + 1;
				}
				// Set the code part value
				cChildTableFin.sCodePartValue = sValue;
				Sal.SendMsgToChildren(i_hWndFrame, Const.PAM_SetCodePartValue, 0, 0);
				return sValue;
			}
			#endregion
		}
		
		/// <summary>
		/// Override this function to check whether a particular codepart is blocked.
		/// e.g. Return PalAttrGet( sSqlColumn, colsCodeDemand ) ="S"
		/// </summary>
		/// <param name="sSqlColumn"></param>
		/// <returns></returns>
		public virtual SalBoolean CodePartBlocked(SalString sSqlColumn)
		{
			#region Actions
			using (new SalContext(this))
			{
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// Override this function to check whether a particular codepart desc is blocked.
		/// </summary>
		/// <param name="sSqlColumn"></param>
		/// <returns></returns>
		public virtual SalBoolean CodePartDescBlocked(SalString sSqlColumn)
		{
			#region Actions
			using (new SalContext(this))
			{
				return false;
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
                cChildTableFin.sCodePartValue = p_sCodePartValue;
                if (this.i_sCompany == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    this.UserGlobalValueGet("COMPANY", ref this.i_sCompany);
                }

				if (p_sCodePart.Scan("ACCOUNT") != -1) 
				{
					if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Text_Field_Translation_API.Get_Text"))) 
					{
						return false;
					}
         			if (cChildTableFin.bIsNullCodeParts) 
					{
						if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Part_A_API.Validate_Account_Pseudo__"))) 
						{
							return false;
						}
						lsStmt = "&AO.Accounting_Code_Part_A_API.Validate_Account_Pseudo__( :i_hWndParent." + sCompanyColumnName + "," +
																	                         @":cChildTableFin.sCodePart, 
						                                                                     :cChildTableFin.sCodePartValue, 
																	                         :cChildTableFin.dNull, 
																	                         :cChildTableFin.sRequiredString, 
																	                         :cChildTableFin.sRequiredStringComplete, 
						                                                                     :cChildTableFin.sUserName );" +
		                          ":cChildTableFin.sCodePartDescription := &AO.Text_Field_Translation_API.Get_Text( :i_hWndParent." + sCompanyColumnName + "," + 
																						                            @"'CODEA', 
																						                            :cChildTableFin.sCodePartValue);" ;
						bCommandOk = DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
					}
					else
					{
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Part_A_API.Validate_Account_Pseudo__")))
                        {
                            return false;
                        }
                        lsStmt = "&AO.ACCOUNT_API.Get_Required_Code_Part_Pseudo(:cChildTableFin.sRequiredString," + 
														                       ":i_hWndParent." + sCompanyColumnName + "," +
														                      @":cChildTableFin.sCodePartValue ); 
		                          :cChildTableFin.sCodePartDescription := &AO.Text_Field_Translation_API.Get_Text(:i_hWndParent." + sCompanyColumnName + "," +
																					                            @"'CODEA', 
																					                              :cChildTableFin.sCodePartValue);" +
                                  ":cChildTableFin.sIsPseudoCode := &AO.PSEUDO_CODES_API.Exist_Pseudo_Code(:i_hWndParent." + sCompanyColumnName + "," +
                                                                                                         " :cChildTableFin.sCodePartValue);";


						bCommandOk = DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
						if (bCommandOk) 
						{
							if (cChildTableFin.sIsPseudoCode == "FALSE") 
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
					cChildTableFin.sCodePart = p_sCodePart.Right(1);
					if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Part_Value_API.Exist"))) 
					{
						return false;
					}
					if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Text_Field_Translation_API.Get_Text"))) 
					{
						return false;
					}
                    lsStmt = "&AO.Accounting_Code_Part_Value_API.Exist( :i_hWndParent." + sCompanyColumnName + ","
                                                                         + ":cChildTableFin.sCodePart,"
                                                                         + ":cChildTableFin.sCodePartValue );" +
                               ":cChildTableFin.sCodePartDescription := &AO.Text_Field_Translation_API.Get_Text( :i_hWndParent." + sCompanyColumnName + "," +
                                                                                                                "'CODE' || :cChildTableFin.sCodePart," +
                                                                                                                ":cChildTableFin.sCodePartValue);"; 
					bCommandOk = DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
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
				Sal.SendMsgToChildren(i_hWndFrame, Const.PAM_SetCodePartDesc, p_sCodePart.ToHandle(), cChildTableFin.sCodePartValue.ToHandle());
				Sal.SendMsgToChildren(i_hWndSelf, Const.PAM_SetCodePartDesc, p_sCodePart.ToHandle(), cChildTableFin.sCodePartValue.ToHandle());
				return Sys.VALIDATE_Ok;
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
					cChildTableFin.sTempCodePart = "A";
				}
				else
				{
					cChildTableFin.sTempCodePart = cChildTableFin.sCodePart;
				}
                lsStmt = @":cChildTableFin.sCompletionAttr := &AO.ACCOUNTING_CODESTR_COMPL_API.Get_Complete_CodeString(:i_hWndParent." + sCompanyColumnName + "," +
									                                                                                    @":cChildTableFin.sTempCodePart, 
									                                                                                    :cChildTableFin.sCodePartValue );";
				bCommandOk = DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
				if (bCommandOk) 
				{
					if (cChildTableFin.sCompletionAttr != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						ScanAttributeString(cChildTableFin.sCompletionAttr);
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
                lsStmt = "&AO.PSEUDO_CODES_API.Get_Complete_Pseudo( :cChildTableFin.sPseudoCodeAttr," + 
								                                     ":i_hWndParent." + sCompanyColumnName + "," +
								                                     @":cChildTableFin.sCodePartValue, 
				                                                     :cChildTableFin.sUserName);";
				bCommandOk = DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
				if (bCommandOk) 
				{
                    sRequiredStringComplete = sPseudoCodeAttr;
					cChildTableFin.bPseudoAccount = true;
					ScanAttributeString(cChildTableFin.sPseudoCodeAttr);
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
				nPos = cChildTableFin.sRequiredStringComplete.Scan(p_sCodePart);
				if (nPos != -1) 
				{
					// Find the length of the Attribute String
					nLength = cChildTableFin.sRequiredStringComplete.Length;
					// Extract the string from beginning of nPos to end of Attribute String
					sStrTmp = cChildTableFin.sRequiredStringComplete.Mid(nPos, nLength);
					// Get the position of the Unit Seperator
					nPosUnitDelim = sStrTmp.Scan(sUnitChar);
					// Get the position of the Record Seperator
					nPosRecDelim = sStrTmp.Scan(sRecChar);
					// Get the first part of the string upto the Unit Seperator
					nPosStr = cChildTableFin.sRequiredStringComplete.Left(nPos + 1).Length;
					nPosStr = nPosStr + nPosUnitDelim;
					sStr1 = cChildTableFin.sRequiredStringComplete.Left(nPosStr);
					// Get the last part of the string
					sStr2 = sStrTmp.Mid(nPosRecDelim, nLength);
					// Create new Attribute String
					sNewRequiredString = sStr1 + p_sCodePartValue + sStr2;
					// Replace existing Attribute String with new string
					cChildTableFin.sRequiredStringComplete = sNewRequiredString;
				}
				else
				{
					if (p_sCodePart.Scan("DESC") != -1) 
					{
						cChildTableFin.sRequiredStringComplete = cChildTableFin.sRequiredStringComplete + p_sCodePart + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + p_sCodePartValue + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
					}
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
							if ((Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sTmp_CodePart, cChildTableFin.sRequiredStringComplete) == Ifs.Fnd.ApplicationForms.Const.strNULL) || bReplace) 
							{
								// Bug 81052, Begin , fetched code part requierments again if the account changed because of code string completion.
								if (sTmp_CodePart == "ACCOUNT") 
								{
									cChildTableFin.sTempHoldValue = sTmp_Value;
									DbPLSQLBlock(cSessionManager.c_hSql, @"&AO.ACCOUNT_API.Get_Required_Code_Part_Pseudo(:cChildTableFin.sRequiredString OUT," +
														 		                                                         ":i_hWndParent." + sCompanyColumnName + "," +
																                                                         ":cChildTableFin.sTempHoldValue IN );");
                				}
								// Bug 81052, End
								ModifyRequiredString(sTmp_CodePart, sTmp_Value);
							}
							else if (sTmp_CodePart == "ACCOUNT" && cChildTableFin.bPseudoAccount) 
							{
								cChildTableFin.bPseudoAccount = false;
								ModifyRequiredString(sTmp_CodePart, sTmp_Value);
							}
							else
							{
								if (Ifs.Fnd.ApplicationForms.Int.PalAttrGet(sTmp_CodePart, cChildTableFin.sRequiredStringComplete) != sTmp_Value) 
								{
									// Prompt User
                                    nChoice = Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_OverwriteCodeParts, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2));
									if (nChoice == Sys.IDYES) 
									{
										// Replace values in sRequiredStringComplete with new values
										// Bug 81052, Begin , fetched code part requierments again if the account changed because of code string completion.
										if (sTmp_CodePart == "ACCOUNT") 
										{
											cChildTableFin.sTempHoldValue = sTmp_Value;
                                            DbPLSQLBlock(cSessionManager.c_hSql, @"&AO.ACCOUNT_API.Get_Required_Code_Part_Pseudo(:cChildTableFin.sRequiredString OUT," +
														 		                                                          ":i_hWndParent." + sCompanyColumnName + "," +
																                                                          ":cChildTableFin.sTempHoldValue IN );");
										}
										// Bug 81052, End
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
		private void cChildTableFin_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Const.PAM_CallChanged:
					this.cChildTableFin_OnPAM_CallChanged(sender, e);
					break;
				
				case Const.PAM_CodePartBlocked:
					e.Handled = true;
					e.Return = this.vrtCodePartBlocked(SalString.FromHandle(Sys.wParam));
					return;
				
				case Const.PAM_CodePartDescBlocked:
					e.Handled = true;
					e.Return = this.vrtCodePartDescBlocked(SalString.FromHandle(Sys.wParam));
					return;
				
				case Const.PAM_ValidateCodePartValues:
					this.cChildTableFin_OnPAM_ValidateCodePartValues(sender, e);
					break;
				
				case Const.PAM_FetchCodePartValue:
					e.Handled = true;
					e.Return = this.FetchCodePartValue(Sys.wParam, SalString.FromHandle(Sys.lParam)).ToHandle();
					return;
				
				case Const.PAM_CheckExternalProject:
					e.Handled = true;
					e.Return = this.vrtEnableDisableProjectActivityId(SalString.FromHandle(Sys.wParam));
					return;
				
				case Sys.SAM_Create:
					this.cChildTableFin_OnSAM_Create(sender, e);
					break;
				
				case Const.PAM_SynchronizeWithProfile:
					e.Handled = true;
					e.Return = this.GetVisibility(Sys.wParam, Sys.lParam);
					return;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.cChildTableFin_OnPM_DataRecordNew(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
					this.cChildTableFin_OnPM_DataRecordDuplicate(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
					this.cChildTableFin_OnPM_DataRecordRemove(sender, e);
					break;
				
				case Const.PAM_ChangedChildText:
					this.cChildTableFin_OnPAM_ChangedChildText(sender, e);
					break;
				
				case Const.PAM_SetNullCodeParts:
					this.cChildTableFin_OnPAM_SetNullCodeParts(sender, e);
					break;
				// Bug 108483, Begin.
				case Const.PAM_ChildTableSynchronizeProfile:
					this.cChildTableFin_OnPAM_ChildTableSynchronizeProfile(sender, e);
					break;
				// Bug 108483, End
				// Bug 109903 Begin
				// When the form is closing need to check if profile is changed & update 'ColVisibilityFin'
				case Const.PAM_FinFormFrameShutDownUser:
					this.cChildTableFin_OnPAM_FinFormFrameShutDownUser(sender, e);
					break;
				// Bug 109903 End
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_CallChanged event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cChildTableFin_OnPAM_CallChanged(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            // Bug 93629 Begin, Replaced the code that compares the child table's global company value and the parent's global company value as these two values are always the same.
            // Setting of this value is done in cDataSource_OnAM_UserProfileValueSet() when initialising the form. When the parent's AM_UserProfileValueSet actions are done it always sends the 
            // AM_UserProfileValueSet to child datasources as well.
            UserGlobalValueGet("COMPANY", ref i_sCompany);
            RefreshCodePartInfo(this.i_sCompany, cSessionManager.c_sDbPrefix);
            // Bug 93629 End.
			cColumnCodePartFin.sProjectCodePart = SalString.Null;
			Sal.SendMsgToChildren(this.i_hWndSelf, Const.PAM_CallChanged, 0, 0);
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// PAM_ValidateCodePartValues event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cChildTableFin_OnPAM_ValidateCodePartValues(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.i_sSqlColumn = SalString.FromHandle(Sys.wParam);
			this.i_sCodePartValue = SalString.FromHandle(Sys.lParam);
			this.AttrFetchCodePart(ref cChildTableFin.sRequiredStringComplete, Sal.TblQueryContext(this.i_hWndSelf));
            if (this.i_sCompany == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                this.UserGlobalValueGet("COMPANY", ref this.i_sCompany);
            }
			if (this.ValidateCodePart(this.i_sSqlColumn, this.i_sCodePartValue) != Sys.VALIDATE_Cancel) 
			{
				this.AttrDecodeCodePart(ref cChildTableFin.sRequiredString, ref cChildTableFin.sRequiredStringComplete);
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
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cChildTableFin_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam)) 
			{
				this.SynchronizeWithProfile(this.i_hWndSelf);
                this.sCompanyColumnName = cChildTableFin.FromHandle(i_hWndSelf).Name;
                sCompanyColumnName = sCompanyColumnName + "_colsCompany";
				e.Return = true;
				return;
			}
			e.Return = false;
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cChildTableFin_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
				cChildTableFin.sCodePartValue = SalString.Null;
				cChildTableFin.sCodePartDescription = SalString.Null;
				Sal.SendMsgToChildren(this.i_hWndFrame, Const.PAM_SetCodePartValue, 0, 0);
				Sal.SendMsgToChildren(this.i_hWndFrame, Const.PAM_SetCodePartDesc, 0, 0);
				e.Return = true;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordDuplicate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cChildTableFin_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
				cChildTableFin.sCodePartValue = SalString.Null;
				cChildTableFin.sCodePartDescription = SalString.Null;
				Sal.SendMsgToChildren(this.i_hWndFrame, Const.PAM_SetCodePartValue, 0, 0);
				Sal.SendMsgToChildren(this.i_hWndFrame, Const.PAM_SetCodePartDesc, 0, 0);
				e.Return = true;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordRemove event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cChildTableFin_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
				cChildTableFin.sCodePartValue = SalString.Null;
				cChildTableFin.sCodePartDescription = SalString.Null;
				Sal.SendMsgToChildren(this.i_hWndFrame, Const.PAM_SetCodePartValue, 0, 0);
				Sal.SendMsgToChildren(this.i_hWndFrame, Const.PAM_SetCodePartDesc, 0, 0);
				e.Return = true;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// PAM_ChangedChildText event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cChildTableFin_OnPAM_ChangedChildText(object sender, WindowActionsEventArgs e)
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
		/// PAM_SetNullCodeParts event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cChildTableFin_OnPAM_SetNullCodeParts(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			cChildTableFin.bIsNullCodeParts = Sys.wParam;
			e.Return = true;
			return;
			#endregion
		}
		
		// Bug 108483, Begin.
		/// <summary>
		/// PAM_ChildTableSynchronizeProfile event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cChildTableFin_OnPAM_ChildTableSynchronizeProfile(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.SynchronizeWithProfile(this.i_hWndSelf);
			e.Return = true;
			return;
			#endregion
		}
		// Bug 108483, End

		// Bug 109903, Begin.
		/// <summary>
		/// PAM_FinFormFrameShutDownUser event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cChildTableFin_OnPAM_FinFormFrameShutDownUser(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.SetCodepartVisibilityInProfile();
			e.Return = true;
			return;
			#endregion
		}
		// Bug 109903, End.
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
		
        // Bug 109903, Begin
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
        // Bug 109903, End
		
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
        //Bug 109903, Begin. Removed 103031
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cChildTableFin to type cTableManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cTableManager(cChildTableFin self)
		{
			return self._cTableManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cChildTableFin to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cChildTableFin self)
		{
			return ((cSessionManager)self._cTableManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cChildTableFin to type cWindowTranslation.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cWindowTranslation(cChildTableFin self)
		{
			return ((cWindowTranslation)self._cTableManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cChildTableFin to type cResize.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cResize(cChildTableFin self)
		{
			return self._cResize;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cChildTableFin to type cFinlibServices.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cFinlibServices(cChildTableFin self)
		{
			return self._cFinlibServices;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableManager to type cChildTableFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableFin(cTableManager super)
		{
			return ((cChildTableFin)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cChildTableFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableFin(cSessionManager super)
		{
			return ((cChildTableFin)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cWindowTranslation to type cChildTableFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableFin(cWindowTranslation super)
		{
			return ((cChildTableFin)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cResize to type cChildTableFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableFin(cResize super)
		{
			return ((cChildTableFin)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cFinlibServices to type cChildTableFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableFin(cFinlibServices super)
		{
			return ((cChildTableFin)super._derived);
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
		public new static cChildTableFin FromHandle(SalWindowHandle handle)
		{
			return ((cChildTableFin)SalWindow.FromHandle(handle, typeof(cChildTableFin)));
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalBoolean vrtCodePartBlocked(SalString sSqlColumn)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.CodePartBlocked(sSqlColumn);
			}
			else
			{
				return lateBind.vrtCodePartBlocked(sSqlColumn);
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalBoolean vrtCodePartDescBlocked(SalString sSqlColumn)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.CodePartDescBlocked(sSqlColumn);
			}
			else
			{
				return lateBind.vrtCodePartDescBlocked(sSqlColumn);
			}
		}
		
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
        /// <see cref="cChildTableFin.EnableDisableProjectActivityId"/>
        /// </summary>
        [DisplayName("EnableDisableProjectActivityId")]
        [CategoryAttribute("Accrul Late Bind Events")]
        [DescriptionAttribute("Occurs when the vrtEnableDisableProjectActivityId method is called.")]
        public event EventHandler<cChildTableFinEventArgs> EnableDisableProjectActivityIdEvent;

        /// <summary>
        /// Represents a method that will handle the EnableDisableProjectActivityId event.
        /// </summary>
        public delegate void EnableDisableProjectActivityIdEventHandler(object sender, cChildTableFinEventArgs e);

		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalBoolean vrtEnableDisableProjectActivityId(SalString sCodePartValue)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
                if (EnableDisableProjectActivityIdEvent != null)
                {
                    cChildTableFinEventArgs e = new cChildTableFinEventArgs(sCodePartValue);
                    
                    EnableDisableProjectActivityIdEvent(this, e);
                    if (e.Handled)
                        return e.ReturnValue;
                }
				return this.EnableDisableProjectActivityId(sCodePartValue);
			}
			else
			{
				return lateBind.vrtEnableDisableProjectActivityId(sCodePartValue);
			}
		}
		#endregion
		
		#region Multiple Inheritance Late Bind Interface
		
		public interface LateBind
		{
			SalBoolean vrtCodePartBlocked(SalString sSqlColumn);
			SalBoolean vrtCodePartDescBlocked(SalString sSqlColumn);
			SalBoolean vrtDataSourceReferenceItems(SalString sReference, SalString sReturnKeyName, SalArray<SalString> sColumnNames, SalArray<SalString> sColumnPrompts);
			SalBoolean vrtEnableDisableProjectActivityId(SalString sCodePartValue);
		}
		#endregion

        public class cChildTableFinEventArgs : FndReturnEventArgsSalBoolean
        {
            private SalString _sCodePartValue;

            public cChildTableFinEventArgs(SalString P_sCodepartValue)
            {
                _sCodePartValue = P_sCodepartValue;
            }

            public SalString sCodePartValue 
            {
                get
                {
                    return _sCodePartValue;
                }
                set
                {
                    _sCodePartValue = value;
                }
            }
        }
	}
}
