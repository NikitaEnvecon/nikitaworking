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
// 13-05-17    MAAYLK    Bug 108483, Added a method to refresh Codepart cache. This was needed to be called from tbwCodePart
// 13-07-02    MAAYLK    Bug 109903, Removed bug correction 103031. Introduced another correction with a new profile called 'ColVisibilityFin'
#endregion

using System;
using System.Collections.Generic;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Vis;

namespace Ifs.Application.Accrul
{
	
	/// <summary>
	/// Class used to manage specific services such as 'Change Company' and
	/// code part translation
	/// </summary>
	public class cFinlibServices : cCalculateFinAmount
	{
		#region Fields
		[ThreadStatic]
        private static string currentCompany;
		[ThreadStatic]
		public static SalArray<SalString> sCodePartName;
		[ThreadStatic]
		public static SalNumber nCodePartNameCount;
		[ThreadStatic]
		public static SalArray<SalString> lsDisplayCodePart;
		[ThreadStatic]
		public static SalArray<SalString> lsCodePartFunction;
		[ThreadStatic]
        private static SalString UnusedCodeParts;
		[ThreadStatic]
		private static SalString sAccCodePartsMsg;
        // Bug 109903, Removed Bug 103031 static variables

		#region Static Fields initialization
		[ThreadStatic]
		private static bool threadStaticsInitialized;

		internal static void InitThreadStaticFields()
		{
			if (!threadStaticsInitialized)
			{
				threadStaticsInitialized = true;
				sCodePartName = new SalArray<SalString>();
				nCodePartNameCount = 0;
				lsDisplayCodePart = new SalArray<SalString>();
				lsCodePartFunction = new SalArray<SalString>();
                // Bug 109903, Removed Bug 103031 static variables
			}
		}
		#endregion

		public SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
		public SalString __sVisibility = "";
		public SalString __sDefVisibility = "";
		public SalArray<SalString> __sVisibilityArray = new SalArray<SalString>();
		public SalArray<SalString> __sDefVisibilityArray = new SalArray<SalString>();
		public SalString __sProfileSection = "";
		public SalNumber nInit = 0;
		public SalString sCompChanged = "";
        // Bug 109903, Begin. Removed Bug 103031 and introduced three varaibles
		private SalNumber nStartLoc = 0;
		private SalNumber nEndLoc = 0;
		private SalString __sVisibilityAtStart = "";
		// Bug 109903, End
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cFinlibServices()
		{
			InitThreadStaticFields();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cFinlibServices(object derived)
		{
			InitThreadStaticFields();
		
			// Attach derived instance.
			this._derived = derived;
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <param name="hWndActualForm"></param>
		/// <returns></returns>
		public virtual SalNumber DoChangeCompany(SalWindowHandle hWndActualForm)
		{
			nInit = 1;
			sCompChanged = "Y";
			dlgChangeCompanyFin.ModalDialog(GetTopForm(hWndActualForm), hWndActualForm);

			return 0;
		}

		// Bug 80149, Begin
		/// <summary>
		/// </summary>
		/// <param name="p_hWnd"></param>
		/// <returns></returns>
		public virtual SalWindowHandle GetTopForm(SalWindowHandle p_hWnd)
		{
            SalWindowHandle hWndTemp = p_hWnd;
            SalWindowHandle hWndReturn = hWndTemp;
			while ((hWndTemp != SalWindowHandle.Null) && (hWndTemp != Sys.hWndMDI)) 
			{
				hWndReturn = hWndTemp;
				hWndTemp = Sal.ParentWindow(hWndTemp);
			}
			return hWndReturn;
		}

		// Bug 80149, End
		/// <summary>
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sAppOwner"></param>
		/// <param name="sText"></param>
		/// <returns></returns>
		public virtual SalBoolean FinTranslateStringCodePart(SalString sCompany, SalString sAppOwner, ref SalString sText)
		{			
            SalNumber a = sText.Scan("@");
			if (a == -1) 
				return false;

			RefreshCodePartInfo(sCompany);
			while (true)
			{
                SalString sDummy = sText.Mid(a + 1, 1);
                SalNumber n = Sal.StrLop(ref sDummy) - 65;
				if (n >= 0 && n < cFinlibServices.nCodePartNameCount) 
					sText = sText.Replace(a, 2, cFinlibServices.sCodePartName[n]);
				else
					return false;

				a = sText.Scan("@");
				if (a == -1) 
					return true;
			}

			return false;
		}
		
		/// <summary>
		/// Gets CodePart Names from Server
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sAppOwner"></param>
		/// <returns></returns>
        public virtual SalBoolean GetCodePartNames(SalString sCompany)
        {
            currentCompany = sCompany;
            if (!Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Parts_API.Get_Acc_Code_Parts_Msg"))
                return false;

            // Bug 79499, begin, Removed the if condition created by bug 75217 as due to this condition any internal code part name changes done from tbwCodepart do not gett saved properly
            if (sCompChanged == "Y" || nInit != 1)
            {
                Ifs.Fnd.ApplicationForms.Var.g_Bind.Clear();
                Ifs.Fnd.ApplicationForms.Var.g_Bind.s[0] = sCompany;
                if (!Ifs.Fnd.ApplicationForms.Var.g_Bind.DbPLSQLBlock("&AO.Accounting_Code_Parts_API.Get_Acc_Code_Parts_Msg( :g_Bind.s[1] OUT, :g_Bind.s[0] IN);"))
                    return false;

                cFinlibServices.sAccCodePartsMsg = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[1];
            }

            string name;
            IList<KeyValuePair<string,string>> list;
            if (cMessage.FromString(cFinlibServices.sAccCodePartsMsg, out name, out list) && (list != null) && (name == "ACC_CODE_PARTS"))
            {
                cFinlibServices.nCodePartNameCount = 0;

                foreach (KeyValuePair<string, string> kvp in list)
                {
                    switch (kvp.Key)
                    {
                        case "CODE_PART_NAME":
                            cFinlibServices.sCodePartName[cFinlibServices.nCodePartNameCount] = kvp.Value;
                            break;
                        case "CODE_PART_USED_DB":
                            cFinlibServices.lsDisplayCodePart[cFinlibServices.nCodePartNameCount] = kvp.Value;
                            break;
                        case "CODE_PART_FUNCTION":
                            cFinlibServices.lsCodePartFunction[cFinlibServices.nCodePartNameCount] = (kvp.Value == "Project" ? "PRACC" : kvp.Value);
                            cFinlibServices.nCodePartNameCount++;
                            break;

                    }
                }
            }

            return true;
        }
		
        // Bug 108483, Begin. Added code to refresh codepart visibility at vrtActivate()
        /// <summary>
        /// Gets CodePart Names from Server
        /// </summary>
        /// <param name="sCompany"></param>
        /// <param name="sAppOwner"></param>
        /// <returns></returns>
        public virtual SalBoolean ForceGetCodePartNames(SalString sCompany, SalString sAppOwner)
        {
            if (nInit == 1)
            {
                nInit = 0;
                SalBoolean bReturn = GetCodePartNames(sCompany);
                nInit = 1;
                return bReturn;
            }
            return GetCodePartNames(sCompany);
        }
		// Bug 108483, End

		/// <summary>
		/// </summary>
		/// <param name="sCompany"></param>
		/// <param name="sSqlColumn"></param>
		/// <param name="sDisableWindow"></param>
		/// <returns></returns>
		public virtual SalBoolean GetUnusedCodeParts(SalString sCompany, SalString sSqlColumn, ref SalString sDisableWindow)
		{
			cFinlibServices.UnusedCodeParts = SalString.Null;
			if (cFinlibServices.lsDisplayCodePart[1] == "N") 
			{
				cFinlibServices.UnusedCodeParts = cFinlibServices.UnusedCodeParts + "CODE_B" + "CODE_B_DESC";
			}
			if (cFinlibServices.lsDisplayCodePart[2] == "N") 
			{
				cFinlibServices.UnusedCodeParts = cFinlibServices.UnusedCodeParts + "CODE_C" + "CODE_C_DESC";
			}
			if (cFinlibServices.lsDisplayCodePart[3] == "N") 
			{
				cFinlibServices.UnusedCodeParts = cFinlibServices.UnusedCodeParts + "CODE_D" + "CODE_D_DESC";
			}
			if (cFinlibServices.lsDisplayCodePart[4] == "N") 
			{
				cFinlibServices.UnusedCodeParts = cFinlibServices.UnusedCodeParts + "CODE_E" + "CODE_E_DESC";
			}
			if (cFinlibServices.lsDisplayCodePart[5] == "N") 
			{
				cFinlibServices.UnusedCodeParts = cFinlibServices.UnusedCodeParts + "CODE_F" + "CODE_F_DESC";
			}
			if (cFinlibServices.lsDisplayCodePart[6] == "N") 
			{
				cFinlibServices.UnusedCodeParts = cFinlibServices.UnusedCodeParts + "CODE_G" + "CODE_G_DESC";
			}
			if (cFinlibServices.lsDisplayCodePart[7] == "N") 
			{
				cFinlibServices.UnusedCodeParts = cFinlibServices.UnusedCodeParts + "CODE_H" + "CODE_H_DESC";
			}
			if (cFinlibServices.lsDisplayCodePart[8] == "N") 
			{
				cFinlibServices.UnusedCodeParts = cFinlibServices.UnusedCodeParts + "CODE_I" + "CODE_I_DESC";
			}
			if (cFinlibServices.lsDisplayCodePart[9] == "N") 
			{
				cFinlibServices.UnusedCodeParts = cFinlibServices.UnusedCodeParts + "CODE_J" + "CODE_J_DESC";
			}
			if (cFinlibServices.UnusedCodeParts.Scan(sSqlColumn) != -1) 
			{
				sDisableWindow = "Y";
				return true;
			}
			return false;
		}
		
		/// <summary>
		/// This function will return the code part connected to the code part function given by the input parameter sFunction.
		/// If you are calling this function from a window where you don't have any code parts, first call RefreshCodePartInfo.
		/// </summary>
		/// <param name="sFunction"></param>
		/// <returns></returns>
		public virtual SalString GetCodePartFunction(SalString sFunction)
		{
            SalNumber nIndex = 0;
            SalString sCode = Ifs.Fnd.ApplicationForms.Const.strNULL;
            SalBoolean bFound = false;
			while (nIndex < 10 && !(bFound)) 
			{
				if (cFinlibServices.lsCodePartFunction[nIndex] == sFunction) 
				{
					if (sFunction != "INTERN") 
					{
						bFound = true;
					}
					sCode = sCode + (nIndex + 65).ToCharacter();
				}
				nIndex = nIndex + 1;
			}
			return sCode;
		}
		
		/// <summary>
		/// This function will refresh lsDisplayCodePart, lsCodePartFunction and sCodePartName arrays,
		///  if company or database has been changed or sCodePartName is empty.
		/// </summary>
		/// <param name="company"></param>
		/// <param name="sAppOwner"></param>
		/// <returns></returns>
        public virtual SalBoolean RefreshCodePartInfo(string company)
        {
            if (company != currentCompany || cFinlibServices.sCodePartName[0] == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                // Bug 79499, begin
                if (nInit == 1)
                    sCompChanged = "Y";
                // Bug 79499, end

                GetCodePartNames(company);
                ClearVisibilityArray();
                // Bug 85880, Begin
                SynchronizeWithProfile(Sys.hWndItem);
                // Bug 85880, End
                // Bug 109903, Removed bug correction 103031
            }
            // Bug 79499, Moved the 'Set nInit = 1' Statement before the Call to GetCodePartNames()
            if (nInit != 1)
            {
                nInit = 1;
                GetCodePartNames(company);
            }
            // Bug 79499, end

            return false;
        }
		
		/// <summary>
		/// </summary>
		/// <param name="hWndProfileWindow"></param>
		/// <returns></returns>
		public virtual SalNumber SynchronizeWithProfile(SalWindowHandle hWndProfileWindow)
		{
			#region Actions
			__sProfileSection = Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(hWndProfileWindow);
			// Bug 109903, Begin.
			Ifs.Fnd.ApplicationForms.Var.Profile.ValueStringGet(__sProfileSection, "ColVisibilityFin", Ifs.Fnd.ApplicationForms.Const.strNULL, ref __sVisibility);
			// 'ColVisibilityFin' = Null means that this profile variable has not been set so far. In such cases get the value of F1 profile 'ColVisibility'
			if (__sVisibility == Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				Ifs.Fnd.ApplicationForms.Var.Profile.ValueStringGet(__sProfileSection, "ColVisibility", Ifs.Fnd.ApplicationForms.Const.strNULL, ref __sVisibility);
			}
			// Bug 109903, End
			Ifs.Fnd.ApplicationForms.Var.Profile.ValueStringGet(__sProfileSection, "DefColVisibility", Ifs.Fnd.ApplicationForms.Const.strNULL, ref __sDefVisibility);
			__sVisibility.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, ",", __sVisibilityArray);
			__sDefVisibility.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, ",", __sDefVisibilityArray);
			// Bug 109903, Begin
			// this method is called when the company has been changed or the window is opened, to save the 'ColVisibility' profile at the start.
			Ifs.Fnd.ApplicationForms.Var.Profile.ValueStringGet(__sProfileSection, "ColVisibility", Ifs.Fnd.ApplicationForms.Const.strNULL, ref __sVisibilityAtStart);
			// Bug 109903, End

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber AddToDefProfile()
		{
			Ifs.Fnd.ApplicationForms.Var.Profile.ValueSet(__sProfileSection, "DefColVisibility", __sDefVisibility);
			return 0;
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber AddToProfile()
		{
			Ifs.Fnd.ApplicationForms.Var.Profile.ValueSet(__sProfileSection, "ColVisibility", __sVisibility);

			return 0;
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber ClearVisibilityArray()
		{
            SalNumber nColumns = __sVisibilityArray.GetUpperBound(1);
            SalNumber nIndex = 0;
			while (nIndex <= nColumns) 
			{
				__sVisibilityArray[nIndex] = Ifs.Fnd.ApplicationForms.Const.strNULL;
                nIndex++;
			}

			return 0;
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nCount"></param>
		/// <param name="nColPosition"></param>
		/// <returns></returns>
		public virtual SalNumber GetVisibility(SalNumber nCount, SalNumber nColPosition)
		{
			if ((Sal.TblQueryColumnID(nColPosition.ToWindowHandle()) - 1) > 0) 
			{
                SalNumber nColumn = Sal.TblQueryColumnID(nColPosition.ToWindowHandle()) - 1;
				// Synchronize with used unused codeparts
				if (nCount >= 0) 
				{
                    // Bug 109903, Begin, Use the local variables instead of static variables
					if ((nStartLoc == SalNumber.Null) || (nStartLoc == 0)) 
                    {
						nStartLoc = nColumn;
                    }
					if (nColumn > nEndLoc) 
                    {
						nEndLoc = nColumn;
                    }
                    // Bug 109903, End
					if (!(MatchDefaultArray(nCount, nColumn))) 
					{
						// The used-unused flag is changed for the code part
						if (__sDefVisibilityArray[nColumn] != Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							AddToDefProfile();
							if (__sVisibilityArray[nColumn] == Ifs.Fnd.ApplicationForms.Const.strNULL) 
							{
								return ((SalString)"1").ToNumber();
							}
							// A code part is newly set as used
							if (__sDefVisibilityArray[nColumn] == "1") 
							{
								AddToProfile();
								return __sDefVisibilityArray[nColumn].ToNumber();
							}
						}
					}
				}
				// Bug 109903, Removed bug correction 103031
				// Else get visibility
				if (__sVisibilityArray[nColumn] == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					return ((SalString)"1").ToNumber();
				}
				return __sVisibilityArray[nColumn].ToNumber();
			}
			return ((SalString)"0").ToNumber();
		}
		
		/// <summary>
		/// Compare the Default settings with the newly modified used unused code parts
		/// </summary>
		/// <param name="nModCount"></param>
		/// <param name="nDefCount"></param>
		/// <returns></returns>
		public virtual SalBoolean MatchDefaultArray(SalNumber nModCount, SalNumber nDefCount)
		{
            SalString sDefVis = Vis.StrChoose(cFinlibServices.lsDisplayCodePart[nModCount] == "Y", "1", "0");
			if (sDefVis != __sDefVisibilityArray[nDefCount]) 
			{
				__sDefVisibilityArray[nDefCount] = sDefVis;
				return false;
			}
			return true;
		}
		// Bug 72392 - Begin
		// DataSource Level Functions
		/// <summary>
		/// </summary>
		/// <param name="sReference"></param>
		/// <param name="sReturnKeyName"></param>
		/// <param name="sColumnNames"></param>
		/// <param name="hWndChild"></param>
		/// <param name="nChildCount"></param>
		/// <param name="sColumnPrompts"></param>
		/// <returns></returns>
		public virtual SalBoolean DataSourceReferenceItems(SalString sReference, SalString sReturnKeyName, SalArray<SalString> sColumnNames, SalArray<SalWindowHandle> hWndChild, SalNumber nChildCount, SalArray<SalString> sColumnPrompts)
		{
			#region Local Variables
			SalNumber n = 0;
			SalNumber i = 0;
			SalString sTitle = "";
			SalNumber nCount = 0;
			#endregion
			
			#region Actions
			while (n < nChildCount) 
			{
				sTitle = SalString.FromHandle(Sal.SendMsg(hWndChild[n], Const.PAM_ChangeLovTitle, 0, sReference.ToHandle()));
				if (sTitle == "#WRONG_COLUMN#" || sTitle == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					// Next item in Loop
				}
				else
				{
					if (sTitle == "#FALSE#") 
					{
						return false;
					}
					else
					{
						if (sTitle != SalString.Null) 
						{
							nCount = sColumnNames.GetUpperBound(1);
							while (i < nCount) 
							{
								if (sColumnNames[i] == sReturnKeyName) 
								{
									sColumnPrompts[i] = sTitle;
									return true;
								}
								i = i + 1;
							}
							return false;
						}
						else
						{
							return false;
						}
					}
				}
				n = n + 1;
			}
			return false;
			#endregion
		}
		// DataItem Level Functions
		/// <summary>
		/// </summary>
		/// <param name="sReference"></param>
		/// <param name="sLovReference"></param>
		/// <param name="sOldLabel"></param>
		/// <param name="hWndSelf"></param>
		/// <returns></returns>
		public virtual SalString GetTitle(SalString sReference, SalString sLovReference, SalString sOldLabel, SalWindowHandle hWndSelf)
		{
			#region Local Variables
			SalString sTitle = "";
			SalNumber nLength = 0;
			#endregion
			
			#region Actions
            SalString sLov = LovViewNameGet(sLovReference);
			if (sLov == sReference) 
			{
				if (Vis.StrScanReverse(sOldLabel, 0, "@") > -1) 
				{
					// Handle cColumn Titles & cDataField Titles properly
					if (Sal.WindowIsDerivedFromClass(hWndSelf, typeof(cColumn))) 
					{
						nLength = Sal.TblGetColumnTitle(hWndSelf, ref sTitle, 200);
					}
					else if (Sal.WindowIsDerivedFromClass(hWndSelf, typeof(cDataField))) 
					{
						nLength = Sal.GetWindowLabelText(hWndSelf, ref sTitle, 200);
					}
					if (sTitle != SalString.Null) 
					{
						if (sTitle.Right(1) == ":") 
						{
							sTitle = sTitle.Left(nLength - 1);
						}
						return sTitle;
					}
					else
					{
						return "#FALSE#";
					}
				}
				else
				{
					return "#FALSE#";
				}
			}
			return "#WRONG_COLUMN#";
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sLovReference"></param>
		/// <returns></returns>
		public virtual SalString LovViewNameGet(SalString sLovReference)
		{
			#region Local Variables
			SalNumber nStart = 0;
			SalNumber nEnd = 0;
			SalString sViewName = "";
			#endregion
			
			#region Actions
			nStart = sLovReference.Scan("(");
			nEnd = sLovReference.Scan(")");
			if (nEnd > nStart) 
			{
				sViewName = sLovReference.Mid(0, nStart);
			}
			else
			{
				sViewName = sLovReference;
			}
			return sViewName;
			#endregion
		}

        // Bug 109903, Begin
        /// <summary>
		/// This method will update Finance specific profile variable 'ColVisibilityFin' if the user has deliberately, changed the visibility of any column.
		/// Codepart columns that are invisible merely because they are 'Not Used' in the company should not be saved to the profile
        /// </summary>
        /// <returns></returns>
		public virtual SalNumber SetCodepartVisibilityInProfile()
        {
            #region Local Variables
			SalString sCurrentVisibility = "";
			SalArray<SalString> sVisibilityAtStartArray = new SalArray<SalString>();
			SalArray<SalString> sCurrentVisibilityArray = new SalArray<SalString>();
			SalNumber nPosition = 0;
			SalBoolean bProfileMustBeChanged = false;
            #endregion

            #region Actions
			if (((bool)(nEndLoc - nStartLoc + 1 == 20)) && __sProfileSection != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				Ifs.Fnd.ApplicationForms.Var.Profile.ValueStringGet(__sProfileSection, "ColVisibilityFin", Ifs.Fnd.ApplicationForms.Const.strNULL, ref __sVisibility);
				if (__sVisibility == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					bProfileMustBeChanged = true;
				}
				Ifs.Fnd.ApplicationForms.Var.Profile.ValueStringGet(__sProfileSection, "ColVisibility", Ifs.Fnd.ApplicationForms.Const.strNULL, ref sCurrentVisibility);
				// sCurrentVisibility can be different from __sVisibilityAtStart because user has changed the visibilty of some columns
				if (sCurrentVisibility != __sVisibilityAtStart) 
				{
					bProfileMustBeChanged = true;
					sCurrentVisibility.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, ",", sCurrentVisibilityArray);
					__sVisibilityAtStart.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, ",", sVisibilityAtStartArray);
					// processing columns that are before codepart columns
                    for (nPosition = 0; nPosition < nStartLoc; nPosition++)
					{
                        __sVisibilityArray[nPosition] = sCurrentVisibilityArray[nPosition];
					}
					nPosition = nStartLoc;     //now nPosition should be = nStartLoc anyway
					// processing codepart columns
                    for (SalNumber nCodePart = 0; nCodePart < lsDisplayCodePart.Length; nCodePart++)
                    {
						if (sVisibilityAtStartArray[nPosition] == "1" && sCurrentVisibilityArray[nPosition] == "0") 
                        {
							// Column has got invisible
							// Now check if it is because the Code Part is Not Used or because user has specifically changed it
							if (cFinlibServices.lsDisplayCodePart[nCodePart] == "Y") 
                            {
								// The column has become invisible because the user has specifically changed it. Therefore mark it as invisible
								__sVisibilityArray[nPosition] = "0";
                            }
						}
						else if (sVisibilityAtStartArray[nPosition] == "0" && sCurrentVisibilityArray[nPosition] == "1") 
                        {
							// Column has got visible
							// This has to be specifically set by user. Therefore mark it as Visible
							__sVisibilityArray[nPosition] = "1";
                        }
						else if (sVisibilityAtStartArray[nPosition] == "0" && sCurrentVisibilityArray[nPosition] == "0" && __sVisibilityArray[nPosition] == "1") 
						{
							__sVisibilityArray[nPosition] = "0";
                        }
						if (sVisibilityAtStartArray[nPosition + 1] == "1" && sCurrentVisibilityArray[nPosition + 1] == "0") 
						{
							// Column has got invisible
							// Now check if it is because the Code Part is Not Used or because user has specifically changed it
							if (cFinlibServices.lsDisplayCodePart[nCodePart] == "Y") 
                                {
								// The column has become invisible because the user has specifically changed it. Therefore mark it as invisible
								__sVisibilityArray[nPosition + 1] = "0";
                                }
                        }
						else if (sVisibilityAtStartArray[nPosition + 1] == "0" && sCurrentVisibilityArray[nPosition + 1] == "1") 
						{
							// Column has got visible
							// This has to be specifically set by user. Therefore mark it as Visible
							__sVisibilityArray[nPosition + 1] = "1";
						}
						else if (sVisibilityAtStartArray[nPosition + 1] == "0" && sCurrentVisibilityArray[nPosition + 1] == "0" && __sVisibilityArray[nPosition + 1] == "1") 
                        {
							__sVisibilityArray[nPosition + 1] = "0";
						}
						nPosition = nPosition + 2;
					}
					//now nPosition should be = nEndLoc + 1
                    // processing columns that are after codepart columns
					for (nPosition = nEndLoc + 1; nPosition < sCurrentVisibilityArray.Length; nPosition++) 
                    {
						__sVisibilityArray[nPosition] = sCurrentVisibilityArray[nPosition];
                	}
            	}
				if (bProfileMustBeChanged) 
				{
					__sVisibility = __sVisibilityArray[0];
					for (nPosition = 1; nPosition < __sVisibilityArray.Length; nPosition++) 
           			{
						__sVisibility = __sVisibility + "," + __sVisibilityArray[nPosition];
					}
					// Set the Finance specific profile variable 'ColVisibilityFin'
					Ifs.Fnd.ApplicationForms.Var.Profile.ValueSet(__sProfileSection, "ColVisibilityFin", __sVisibility);
				}
            }

            return 0;
            #endregion
        }
        // Bug 109903, End
        /// <summary>
        /// </summary>
        /// <param name="sCompany"></param>
        /// <returns></returns>
        public virtual SalString GetParallelCurrency(SalString sCompany)
        {
            #region Local Variables
            SalString sCurrencyData = "";
            SalString sAccCurr = "";
            SalString sParCurr = "";
            #endregion

            #region Actions
            cMessage CurrencyData = new cMessage();
                        
            if (Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("FIN_PAR_CURRENCY_DATA", ref sCurrencyData))
            {
                CurrencyData.Unpack(sCurrencyData);
                SalString sTempParCurr = "";
                sTempParCurr = CurrencyData.FindAttribute(sCompany, "!!!");
                if (sTempParCurr == "###") // Data has been fetched for the company but parallel currency not used
                {
                    return SalString.Null;
                }                
                else if (sTempParCurr != "!!!")  // Data has been fetched for the company and exist in cache
                {
                    return sTempParCurr;
                }
                // Else the company data has not been fetched yet or does not exist, then continue to get currency data
            }
            if (!GetCurrencyData(sCompany, ref sAccCurr, ref sParCurr))
            {
                return SalString.Null;
            }
            // return the parallel currency
            return sParCurr;
            #endregion
        }

        /// <summary>
        /// Returns the Accounting Currency for a company
        /// </summary>
        /// <param name="sCompany"></param>
        /// <returns>SalString</returns>
        public virtual SalString GetAccountingCurrency(SalString sCompany)
        {
            #region Local Variables
            SalString sCurrencyData = "";
            SalString sAccCurr = "";
            SalString sParCurr = "";
            #endregion

            #region Actions
            cMessage CurrencyData = new cMessage();                      
                        
            if (Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("FIN_ACC_CURRENCY_DATA", ref sCurrencyData))
            {
                CurrencyData.Unpack(sCurrencyData);
                SalString sTempCurr = "";
                sTempCurr = CurrencyData.FindAttribute(sCompany, "!!!");
                if (sTempCurr != "!!!")  // Data has been fetched for the company and exist in cache
                {
                    return sTempCurr;
                }
                // Else the company data has not been fetched yet or does not exist, then continue to get currency data
            }

            if (!GetCurrencyData(sCompany, ref sAccCurr, ref sParCurr))
            {
                return SalString.Null;
            }
            return sAccCurr;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sCompany"></param>
        /// <returns></returns>
        protected virtual SalBoolean GetCurrencyData(SalString sCompany, ref SalString sAccCurr, ref SalString sParCurr)
        {
            sAccCurr = SalString.Null;
            sParCurr = SalString.Null;
            if (!Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Company_Finance_API.Get_Parallel_Acc_Currency") ||
                !Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Company_Finance_API.Get_Currency_Code"))
                return false;

            Ifs.Fnd.ApplicationForms.Var.g_Bind.Clear();
            Ifs.Fnd.ApplicationForms.Var.g_Bind.s[0] = sCompany;

            if (!Ifs.Fnd.ApplicationForms.Var.g_Bind.DbPLSQLBlock(
                ":g_Bind.s[1] := &AO.Company_Finance_API.Get_Parallel_Acc_Currency(:g_Bind.s[0] IN, SYSDATE);" +
                ":g_Bind.s[2] := &AO.Company_Finance_API.Get_Currency_Code(:g_Bind.s[0] IN);"))
                return false;

            // set the output parameters
            sParCurr = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[1];
            sAccCurr = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[2];
            // clear global
            Ifs.Fnd.ApplicationForms.Var.g_Bind.Clear();

            // Updating caches
            SalString sCurrencyData = "";
            cMessage CurrencyData = new cMessage();

            // Fetch cache data for acc currency
            Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("FIN_ACC_CURRENCY_DATA", ref sCurrencyData);
            CurrencyData.Unpack(sCurrencyData);
            SalString sPackedMessage = "";

            if (sAccCurr != SalString.Null)
            {
                CurrencyData.SetAttribute(sCompany, sAccCurr);
                sPackedMessage = CurrencyData.Pack();
                Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("FIN_ACC_CURRENCY_DATA", sPackedMessage);
            }
            // if value is null then company just created in Enterp or company does not exist. Otherwise this should never happen.                 

            // reset variables
            CurrencyData.Construct();
            sCurrencyData = SalString.Null;
            sPackedMessage = SalString.Null;

            // Update the cache for the parallel currency Start                
            // Fetch cache data for parallel acc currency
            Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("FIN_PAR_CURRENCY_DATA", ref sCurrencyData);
            CurrencyData.Unpack(sCurrencyData);
            SalString sTemp = "";
            sTemp = sParCurr;
            SalBoolean bStoreInCache = true;
            if (sParCurr == SalString.Null)
            {
                // Check if the accounting currency if not null to know if the parallel currency is just not used in the company 
                // or if the company does exist or not defined in Accrul yet
                if (sAccCurr != SalString.Null)
                {
                    // Set a dummy value to indicate that data has been fetched for the company even though parallel currency is not used
                    sTemp = "###";
                }
                else
                {
                    bStoreInCache = false;
                }
            }
            if (bStoreInCache)
            {
                CurrencyData.SetAttribute(sCompany, sTemp);
                sPackedMessage = CurrencyData.Pack();
                Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("FIN_PAR_CURRENCY_DATA", sPackedMessage);
            }
            // Update the cache for the parallel currency End
            return true;
        }

        /// <summary>
        /// Return TRUE/FALSE if the given company is a master company or not
        /// </summary>
        /// <param name="sCompany"></param>
        /// <returns>SalString TRUE/FALSE</returns>
        public virtual SalString IsMasterCompany(SalString sCompany)
        {
            SalString sMasterCompanyData = "";
            SalString sMasterCompany = "";            

            if (Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("FIN_MASTER_COMPANY_DATA", ref sMasterCompanyData))
            {
                cMessage MasterCompanyData = new cMessage();
                MasterCompanyData.Unpack(sMasterCompanyData);
                SalString sTempMasterData = "";
                sTempMasterData = MasterCompanyData.FindAttribute(sCompany, "!!!");
                if (sTempMasterData != "!!!")  // Data has been fetched for the company and exist in cache
                {
                    return sTempMasterData;
                }
                // Else the company data has not been fetched yet or does not exist, then continue to get currency data
            }

            if (GetBasicData(sCompany, ref sMasterCompany))
                // return the parallel currency
                return sMasterCompany;

            return SalString.Null;
        }

        /// <summary>
        /// Method to fetch some basic data for the company that are not updatable in database and cache it in the client
        /// </summary>
        /// <param name="sCompany"></param>
        /// <returns>SalBoolean true/false if method succeded</returns>
        protected virtual SalBoolean GetBasicData(SalString sCompany, ref SalString sMasterCompany)
        {
            sMasterCompany = SalString.Null;
            if (!Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Company_API.Get_Master_Company_Db"))
                return false;

            Ifs.Fnd.ApplicationForms.Var.g_Bind.Clear();
            Ifs.Fnd.ApplicationForms.Var.g_Bind.s[0] = sCompany;

            if (!Ifs.Fnd.ApplicationForms.Var.g_Bind.DbPLSQLBlock(":g_Bind.s[1] := &AO.Company_API.Get_Master_Company_Db(:g_Bind.s[0]);"))
                return false;

            // set the output parameters
            sMasterCompany = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[1];
            // clear global
            Ifs.Fnd.ApplicationForms.Var.g_Bind.Clear();

            // Updating caches
            SalString sMasterCompanyData = "";
            cMessage MasterCompanyData = new cMessage();

            // Fetch cache data for acc currency
            Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("FIN_MASTER_COMPANY_DATA", ref sMasterCompanyData);
            MasterCompanyData.Unpack(sMasterCompanyData);
            SalString sPackedMessage = "";

            if (sMasterCompany != SalString.Null)
            {
                MasterCompanyData.SetAttribute(sCompany, sMasterCompany);
                sPackedMessage = MasterCompanyData.Pack();
                Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("FIN_MASTER_COMPANY_DATA", sPackedMessage);
            }

            // if value is null then company does not exist. Otherwise this should never happen.                 
            return true;
        }

		#endregion

        #region Properties

        public static string CurrentCompany
        {
            get { return cFinlibServices.currentCompany; }
            set { cFinlibServices.currentCompany = value; }
        }

        #endregion

        #region System Methods/Properties

        /// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cFinlibServices FromHandle(SalWindowHandle handle)
		{
			return ((cFinlibServices)SalWindow.FromHandle(handle, typeof(cFinlibServices)));
		}
		#endregion
	}
}
