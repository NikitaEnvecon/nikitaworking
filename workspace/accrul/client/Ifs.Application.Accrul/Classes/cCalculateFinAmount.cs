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
// 121123     Janblk     DANU-122, Parallel currency implementation
// 130523     NILILK     DANU-241, Added New Function CalcualteParallelCurrencyRate().
// 150304     PRatlk     PRFI-5692, Corrected rate calculation logic in CalcualteParallelCurrencyRate().

#endregion

using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// Created By Niroshan On 21.01.1999
	/// </summary>
	public class cCalculateFinAmount : SalFunctionalClass
	{
		#region Fields
		public SalString i_sFinCompany = "";
		public SalString i_sFinCurrencyCode = "";
		public SalString i_sFinBaseCurrencyCode = "";
		public SalString i_sFinCurrencyType = "";
		public SalDateTime i_dFinDate = SalDateTime.Null;
		public SalNumber i_nFinRound = 0;
		public SalNumber i_nFinThirdRound = 0;
		public SalNumber i_nFinBaseRound = 0;
		public SalNumber i_nFinTransRound = 0;
		public SalNumber i_nFinTransAmountRound = 0;
		public SalNumber i_nFinConversionFactor = 0;
		public SalNumber i_nFinCurrencyRate = 0;
		public SalString i_lsFinInverted = "";
		public SalString i_sFinThirdCurrencyCode = "";
		public SalString i_sFinIsThirdEMU = "";
		public SalString i_sFinIsBaseEMU = "";
		public SalNumber i_nFinThirdConversionFactor = 0;
		public SalNumber i_nFinThirdCurrencyRate = 0;
		public SalString i_lsFinThirdInverted = "";
		public SalString sFinCompany = "";
		public SalString sFinCurrencyCode = "";
		public SalString sFinThirdCurrencyCode = "";
		public SalString sFinBaseCurrencyCode = "";
		public SalString sFinCurrencyType = "";
		public SalString sFinIsThirdEMU = "";
		public SalString sFinIsBaseEMU = "";
		public SalDateTime dFinDate = SalDateTime.Null;
		public SalBoolean bGetRate = false;
		public SalBoolean bThirdGetRate = false;

        public SalString sFinParallelBaseType = "";
        public SalString i_sFinParallelBaseType = "";

		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cCalculateFinAmount(){ }
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cCalculateFinAmount(object derived)
		{
			// Attach derived instance.
			this._derived = derived;
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <param name="sFinCompany"></param>
		/// <returns></returns>
		public virtual SalBoolean SetCompany(SalString sFinCompany)
		{
			#region Actions
			i_sFinCompany = sFinCompany;
			bGetRate = false;
			bThirdGetRate = false;
			return true;
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
		public virtual SalBoolean SetFinCache(SalString sCompany, SalString sCurrencyCode, SalString sBaseCurrencyCode, SalString sCurrencyType, SalDateTime dDate)
		{
			#region Actions
			i_sFinCompany = sCompany;
			i_sFinCurrencyCode = sCurrencyCode;
			i_sFinBaseCurrencyCode = sBaseCurrencyCode;
			i_sFinCurrencyType = sCurrencyType;
			i_dFinDate = dDate;
			return true;
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
		public virtual SalBoolean SetCache(SalString sCompany, SalString sCurrencyCode, SalString sBaseCurrencyCode, SalString sCurrencyType, SalDateTime dDate)
		{
			#region Actions
			sFinCompany = sCompany;
			sFinCurrencyCode = sCurrencyCode;
			sFinBaseCurrencyCode = sBaseCurrencyCode;
			sFinCurrencyType = sCurrencyType;
			dFinDate = dDate;
			return true;
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
		public virtual SalBoolean IsEqualFinCatch(SalString sCompany, SalString sCurrencyCode, SalString sBaseCurrencyCode, SalString sCurrencyType, SalDateTime dDate)
		{
			#region Actions
			if (i_sFinCompany == sCompany && i_sFinCurrencyCode == sCurrencyCode && i_sFinBaseCurrencyCode == sBaseCurrencyCode && i_sFinCurrencyType == sCurrencyType && i_dFinDate == dDate) 
			{
				return true;
			}
			else
			{
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nAmount"></param>
		/// <param name="nRound"></param>
		/// <returns></returns>
		public virtual SalNumber RoundOf(SalNumber nAmount, SalNumber nRound)
		{
			#region Actions
			return nAmount.ToString(nRound).ToNumber();
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="p_sRoundingMethod"></param>
		/// <param name="p_nAmount"></param>
		/// <param name="p_nNoOfDec"></param>
		/// <returns></returns>
		public virtual SalNumber RoundOfTax(SalString p_sRoundingMethod, SalNumber p_nAmount, SalNumber p_nNoOfDec)
		{
			#region Local Variables
			SalNumber nCurrentRound = 0;
			SalBoolean bMinus = false;
			#endregion
			
			#region Actions
			if (p_nAmount < 0) 
			{
				bMinus = true;
			}
			else
			{
				bMinus = false;
			}
			if (p_sRoundingMethod == "ROUND_DOWN") 
			{
				return p_nAmount.Truncate(12, p_nNoOfDec);
			}
			if (p_sRoundingMethod == "ROUND_NEAREST") 
			{
				return p_nAmount.ToString(p_nNoOfDec).ToNumber();
			}
			if (p_sRoundingMethod == "ROUND_UP") 
			{
				nCurrentRound = p_nAmount.Truncate(12, p_nNoOfDec);
				if (p_nAmount != nCurrentRound) 
				{
					// If the value rounded is minus add to truncated value. Else substract.
					if (bMinus == true) 
					{
						nCurrentRound = nCurrentRound - ((SalNumber)0.1m).Power(p_nNoOfDec);
					}
					else
					{
						nCurrentRound = nCurrentRound + ((SalNumber)0.1m).Power(p_nNoOfDec);
					}
				}
				return nCurrentRound;
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nCurrencyAmount"></param>
		/// <param name="nAmount"></param>
		/// <returns></returns>
		public virtual SalBoolean GetBaseCurrencyAmount(SalNumber nCurrencyAmount, ref SalNumber nAmount)
		{
			#region Actions
			if (i_lsFinInverted == "TRUE") 
			{
				if (i_nFinConversionFactor == 0 || (i_nFinCurrencyRate / i_nFinConversionFactor) == 0) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					return false;
				}
				else
				{
					nAmount = RoundOf(nCurrencyAmount * (1 / (i_nFinCurrencyRate / i_nFinConversionFactor)), i_nFinBaseRound);
				}
			}
			else
			{
				if (i_nFinConversionFactor == 0) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					return false;
				}
				else
				{
					nAmount = RoundOf(nCurrencyAmount * (i_nFinCurrencyRate / i_nFinConversionFactor), i_nFinBaseRound);
				}
			}
			return true;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nCurrencyAmount"></param>
		/// <param name="nRate"></param>
		/// <param name="nAmount"></param>
		/// <returns></returns>
		public virtual SalBoolean GetBaseCurrAmountForRate(SalNumber nCurrencyAmount, SalNumber nRate, ref SalNumber nAmount)
		{
			#region Actions
			if (i_lsFinInverted == "TRUE") 
			{
				if (i_nFinConversionFactor == 0 || (nRate / i_nFinConversionFactor) == 0) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					return false;
				}
				else
				{
					nAmount = RoundOf(nCurrencyAmount * (1 / (nRate / i_nFinConversionFactor)), i_nFinBaseRound);
				}
			}
			else
			{
				if (i_nFinConversionFactor == 0) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					return false;
				}
				else
				{
					nAmount = RoundOf(nCurrencyAmount * (nRate / i_nFinConversionFactor), i_nFinBaseRound);
				}
			}
			return true;
			#endregion
		}

        /// <summary>
        /// </summary>
        /// <param name="nAmount"></param>
        /// <param name="nRate"></param>
        /// <param name="nParallelAmount"></param>
        /// <returns></returns>
        public virtual SalBoolean GetParallelCurrAmountForRate(SalNumber nAmount, SalNumber nRate, ref SalNumber nParallelAmount)
        {
            #region Actions
            if (i_sFinParallelBaseType == "TRANSACTION_CURRENCY")
            {
                if (i_lsFinThirdInverted == "TRUE")
                {
                    if (i_nFinThirdConversionFactor == 0 || (nRate / i_nFinThirdConversionFactor) == 0)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        return false;
                    }
                    else
                    {
                        nParallelAmount = RoundOf(nAmount * (1 / (nRate / i_nFinThirdConversionFactor)), i_nFinTransAmountRound);
                    }
                }
                else
                {
                    if (i_nFinThirdConversionFactor == 0)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        return false;
                    }
                    else
                    {
                        nParallelAmount = RoundOf(nAmount * (nRate / i_nFinThirdConversionFactor), i_nFinTransAmountRound);
                    }
                }
            }
            else if (i_sFinParallelBaseType == "ACCOUNTING_CURRENCY")
            {
                if (i_lsFinThirdInverted == "TRUE")
                {
                    if (i_nFinThirdConversionFactor == 0)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        return false;
                    }
                    else
                    {
                        nParallelAmount = RoundOf(nAmount * (nRate / i_nFinThirdConversionFactor), i_nFinTransAmountRound);
                    }
                }
                else
                {
                    if (i_nFinThirdConversionFactor == 0 || (nRate / i_nFinThirdConversionFactor) == 0)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        return false;
                    }
                    else
                    {
                        nParallelAmount = RoundOf(nAmount * (1 / (nRate / i_nFinThirdConversionFactor)), i_nFinTransAmountRound);
                    }
                }
            }
            return true;
            #endregion
        }
		
		/// <summary>
		/// </summary>
		/// <param name="nAmount"></param>
		/// <param name="nCurrencyAmount"></param>
		/// <returns></returns>
		public virtual SalBoolean GetTransCurrencyAmount(SalNumber nAmount, ref SalNumber nCurrencyAmount)
		{
			#region Actions
			if (i_lsFinInverted == "TRUE") 
			{
				if (i_nFinConversionFactor == 0) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					return false;
				}
				else
				{
					nCurrencyAmount = RoundOf(nAmount * (i_nFinCurrencyRate / i_nFinConversionFactor), i_nFinTransRound);
				}
			}
			else
			{
				if (i_nFinConversionFactor == 0 || (i_nFinCurrencyRate / i_nFinConversionFactor) == 0) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					return false;
				}
				else
				{
					nCurrencyAmount = RoundOf(nAmount * (1 / (i_nFinCurrencyRate / i_nFinConversionFactor)), i_nFinTransRound);
				}
			}
			return true;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nAmount"></param>
		/// <param name="nRate"></param>
		/// <param name="nCurrencyAmount"></param>
		/// <returns></returns>
		public virtual SalBoolean GetTransCurrAmountForRate(SalNumber nAmount, SalNumber nRate, ref SalNumber nCurrencyAmount)
		{
			#region Actions
			if (i_lsFinInverted == "TRUE") 
			{
				if (i_nFinConversionFactor == 0) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					return false;
				}
				else
				{
					nCurrencyAmount = RoundOf(nAmount * (nRate / i_nFinConversionFactor), i_nFinTransRound);
				}
			}
			else
			{
				if (i_nFinConversionFactor == 0 || (nRate / i_nFinConversionFactor) == 0) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					return false;
				}
				else
				{
					nCurrencyAmount = RoundOf(nAmount * (1 / (nRate / i_nFinConversionFactor)), i_nFinTransRound);
				}
			}
			return true;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nAmount"></param>
		/// <param name="nCurrencyAmount"></param>
		/// <param name="nCurrencyRate"></param>
		/// <returns></returns>
		public virtual SalBoolean GetCurrencyRate(SalNumber nAmount, SalNumber nCurrencyAmount, ref SalNumber nCurrencyRate)
		{
			#region Actions
			if (i_lsFinInverted == "TRUE") 
			{
				if (nAmount == 0) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					return false;
				}
				else
				{
					nCurrencyRate = RoundOf((nCurrencyAmount * i_nFinConversionFactor) / nAmount, i_nFinRound);
				}
			}
			else
			{
				if (nCurrencyAmount == 0) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					return false;
				}
				else
				{
					nCurrencyRate = RoundOf((nAmount * i_nFinConversionFactor) / nCurrencyAmount, i_nFinRound);
				}
			}
			return true;
			#endregion
		}


        public virtual SalBoolean CalcualteParallelCurrencyRate(SalNumber nAmount, SalNumber nCurrencyAmount,SalNumber nParallelCurrencyAmount, ref SalNumber nCurrencyRate)
        {
            #region Actions

            if (i_sFinParallelBaseType == "TRANSACTION_CURRENCY")
            {
                if (i_lsFinThirdInverted == "TRUE")
                {
                    if (nParallelCurrencyAmount == 0)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        return false;
                    }
                    else
                    {
                        nCurrencyRate = RoundOf((nCurrencyAmount * i_nFinThirdConversionFactor) / nParallelCurrencyAmount, i_nFinRound);
                    }
                }
                else
                {
                    if (nCurrencyAmount == 0)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        return false;
                    }
                    else
                    {
                        nCurrencyRate = RoundOf((nParallelCurrencyAmount * i_nFinThirdConversionFactor) / nCurrencyAmount, i_nFinRound);
                    }
                }
            }
            else
            {
                if (i_lsFinThirdInverted == "TRUE")
                {
                    if (nAmount == 0)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        return false;
                    }
                    else
                    {
                        nCurrencyRate = RoundOf((nParallelCurrencyAmount * i_nFinThirdConversionFactor) / nAmount, i_nFinRound);
                    }
                }
                else
                {
                    if (nParallelCurrencyAmount == 0)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        return false;
                    }
                    else
                    {
                        nCurrencyRate = RoundOf((nAmount * i_nFinThirdConversionFactor) / nParallelCurrencyAmount, i_nFinRound);
                    }
                }
            }

            return true;
            #endregion
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
			#region Actions
			if (i_lsFinInverted == "TRUE") 
			{
				if (nAmount == 0) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					return false;
				}
				else
				{
					nActCurrencyRate = (nCurrencyAmount * i_nFinConversionFactor) / nAmount;
				}
			}
			else
			{
				if (nCurrencyAmount == 0) 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.DEVIDED_BY_ZERO_Error, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
					return false;
				}
				else
				{
					nActCurrencyRate = (nAmount * i_nFinConversionFactor) / nCurrencyAmount;
				}
			}
			return true;
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
		public virtual SalBoolean SetFinThirdCache(SalString sCompany, SalString sThirdCurrencyCode, SalString sBaseCurrencyCode, SalDateTime dDate, SalString sIsThirdEMU, SalString sIsBaseEMU)
		{
			#region Actions
			i_sFinCompany = sCompany;
			i_sFinThirdCurrencyCode = sThirdCurrencyCode;
			i_sFinBaseCurrencyCode = sBaseCurrencyCode;
			i_dFinDate = dDate;
			i_sFinIsThirdEMU = sIsThirdEMU;
			i_sFinIsBaseEMU = sIsBaseEMU;
			return true;
			#endregion
		}


        public virtual SalBoolean SetFinThirdCache(SalString sCompany, SalString sThirdCurrencyCode, SalString sBaseCurrencyCode, SalDateTime dDate, SalString sIsThirdEMU, SalString sIsBaseEMU, SalString sParallelBaseType)
        {
            #region Actions
            i_sFinCompany = sCompany;
            i_sFinThirdCurrencyCode = sThirdCurrencyCode;
            i_sFinBaseCurrencyCode = sBaseCurrencyCode;
            i_dFinDate = dDate;
            i_sFinIsThirdEMU = sIsThirdEMU;
            i_sFinIsBaseEMU = sIsBaseEMU;
            i_sFinParallelBaseType = sParallelBaseType;
            return true;
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
		public virtual SalBoolean SetThirdCache(SalString sCompany, SalString sThirdCurrencyCode, SalString sBaseCurrencyCode, SalDateTime dDate, SalString sIsThirdEMU, SalString sIsBaseEMU)
		{
			#region Actions
			sFinCompany = sCompany;
			sFinThirdCurrencyCode = sThirdCurrencyCode;
			sFinBaseCurrencyCode = sBaseCurrencyCode;
			dFinDate = dDate;
			sFinIsThirdEMU = sIsThirdEMU;
			sFinIsBaseEMU = sIsBaseEMU;
			return true;
			#endregion
		}


        public virtual SalBoolean SetThirdCache(SalString sCompany, SalString sThirdCurrencyCode, SalString sBaseCurrencyCode, SalDateTime dDate, SalString sIsThirdEMU, SalString sIsBaseEMU, SalString sParallelBaseType)
		{
			#region Actions
			sFinCompany = sCompany;
			sFinThirdCurrencyCode = sThirdCurrencyCode;
			sFinBaseCurrencyCode = sBaseCurrencyCode;
			dFinDate = dDate;
			sFinIsThirdEMU = sIsThirdEMU;
			sFinIsBaseEMU = sIsBaseEMU;
            sFinParallelBaseType = sParallelBaseType;
			return true;
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
		public virtual SalBoolean IsEqualFinThirdCatch(SalString sCompany, SalString sThirdCurrencyCode, SalString sBaseCurrencyCode, SalDateTime dDate, SalString sIsThirdEMU, SalString sIsBaseEMU)
		{
			#region Actions
			if (i_sFinCompany == sCompany && i_sFinThirdCurrencyCode == sThirdCurrencyCode && i_sFinBaseCurrencyCode == sBaseCurrencyCode && i_dFinDate == dDate && i_sFinIsThirdEMU == sIsThirdEMU && i_sFinIsBaseEMU == sIsBaseEMU) 
			{
				return true;
			}
			else
			{
				return false;
			}
			#endregion
		}

		/// <summary>
		/// </summary>
		/// <param name="nAmount"></param>
		/// <param name="nThirdCurrencyAmount"></param>
		/// <returns></returns>
		public virtual SalBoolean GetThirdCurrencyAmount(SalNumber nAmount, ref SalNumber nThirdCurrencyAmount)
		{
			#region Actions
			if (i_lsFinThirdInverted == "TRUE") 
			{
				if (i_nFinThirdConversionFactor == 0) 
				{
					nThirdCurrencyAmount = 0;
					return false;
				}
				else
				{
					nThirdCurrencyAmount = RoundOf(nAmount * (i_nFinThirdCurrencyRate / i_nFinThirdConversionFactor), i_nFinTransAmountRound);

				}
			}
			else
			{
				if (i_nFinThirdConversionFactor == 0 || (i_nFinThirdCurrencyRate / i_nFinThirdConversionFactor) == 0) 
				{
					nThirdCurrencyAmount = 0;
					return false;
				}
				else
				{
					nThirdCurrencyAmount = RoundOf(nAmount * (1 / (i_nFinThirdCurrencyRate / i_nFinThirdConversionFactor)), i_nFinTransAmountRound);
				}
			}
			return true;
			#endregion
		}


        public virtual SalBoolean GetThirdCurrencyAmount(SalNumber nAmount,SalNumber nCurrAmount, ref SalNumber nThirdCurrencyAmount)
        {
            #region Actions

            if (i_sFinParallelBaseType == "TRANSACTION_CURRENCY")
            {
                nAmount = nCurrAmount;

                if (i_lsFinThirdInverted == "TRUE")
                {
                    if (i_nFinThirdConversionFactor == 0 || (i_nFinThirdCurrencyRate / i_nFinThirdConversionFactor) == 0)
                    {
                        nThirdCurrencyAmount = 0;
                        return false;
                    }
                    else
                    {
                        nThirdCurrencyAmount = RoundOf(nAmount * (1 / (i_nFinThirdCurrencyRate / i_nFinThirdConversionFactor)), i_nFinTransAmountRound);
                    }
                }
                else
                {
                    if (i_nFinThirdConversionFactor == 0)
                    {
                        nThirdCurrencyAmount = 0;
                        return false;
                    }
                    else
                    {
                        nThirdCurrencyAmount = RoundOf(nAmount * (i_nFinThirdCurrencyRate / i_nFinThirdConversionFactor), i_nFinTransAmountRound);
                    }
                }
            }
            else
            {
                GetThirdCurrencyAmount(nAmount,ref nThirdCurrencyAmount);
            }

            
            return true;
            #endregion
        }

		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public static cCalculateFinAmount FromHandle(SalWindowHandle handle)
		{
			return ((cCalculateFinAmount)SalWindow.FromHandle(handle, typeof(cCalculateFinAmount)));
		}
		#endregion
	}
}
