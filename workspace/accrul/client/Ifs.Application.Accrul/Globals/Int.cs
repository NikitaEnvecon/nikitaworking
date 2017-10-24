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
// -------------------------------------------------------------
// 14-10-13    Samllk    PRFI-229 Modified FetchQueryConditionValue()
// 15-12-04    Waudlk    Bug 126027, Changed FetchQueryConditionValue. Do the substring only if length is greater than -1.

#endregion

using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;

namespace Ifs.Application.Accrul
{
	
	public sealed class Int
	{
        public static bool IsGenLedInstalled
        {
            get { return Ifs.Fnd.ApplicationForms.Int.IsSystemComponentInstalled("GENLED"); }
        }

		/// <summary>
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		public static SalNumber SetDataSourceReadOnly(SalWindowHandle hWnd)
		{
			#region Actions
			Ifs.Fnd.ApplicationForms.Var.Console.TextAdd(Ifs.Fnd.ApplicationForms.Const.CONS_Debug, "Set Data Source To Read Only");
			cTableWindow.FromHandle(hWnd).SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_Update, false);
			cTableWindow.FromHandle(hWnd).SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationNew, false);
			cTableWindow.FromHandle(hWnd).SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationModify, false);
			cTableWindow.FromHandle(hWnd).SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationRemove, false);
			cTableWindow.FromHandle(hWnd).SendMessageToChildren(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_DataItem, Ifs.Fnd.ApplicationForms.Const.PM_DataItemFlagSet, Ifs.Fnd.ApplicationForms.Const.FIELD_Update, 0);

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		public static SalNumber SetDataSourceReadOnlyAcc(SalWindowHandle hWnd)
		{
			#region Actions
			Ifs.Fnd.ApplicationForms.Var.Console.TextAdd(Ifs.Fnd.ApplicationForms.Const.CONS_Debug, "Set Data Source To Read Only");
			cTableWindowFin.FromHandle(hWnd).SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_Update, false);
			cTableWindowFin.FromHandle(hWnd).SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationNew, false);
			cTableWindowFin.FromHandle(hWnd).SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationModify, false);
			cTableWindowFin.FromHandle(hWnd).SourceFlagsSet(Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationRemove, false);
			cTableWindowFin.FromHandle(hWnd).SendMessageToChildren(Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_DataItem, Ifs.Fnd.ApplicationForms.Const.PM_DataItemFlagSet, Ifs.Fnd.ApplicationForms.Const.FIELD_Update, 0);

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="lsParameterAttr"></param>
		/// <returns></returns>
		public static SalString FinLibAttrToMessage(SalString lsParameterAttr)
		{
			#region Local Variables
			cMessage Msg = new cMessage();
			SalArray<SalString> strTokenArray = new SalArray<SalString>();
			SalArray<SalString> sValues = new SalArray<SalString>();
			SalNumber nNumTokens = 0;
			SalNumber nCount = 0;
			SalString s = "";
			#endregion
			
			#region Actions
			nNumTokens = lsParameterAttr.Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), strTokenArray);
			nCount = 0;
			while (nCount < nNumTokens) 
			{
				sValues.SetUpperBound(1, -1);
				strTokenArray[nCount].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), sValues);
				Msg.AddAttribute(sValues[0], sValues[1]);
				nCount = nCount + 1;
			}
			return Msg.Pack();
			#endregion
		}
        public static SalString FetchQueryConditionValue(SalString lsWhereClause, SalString sColumnNameIn)
        {
            #region Local Variables
            SalNumber nColumnNameIndex = 0;
            SalString lsWhereClauseTemp = "";
            SalString sQueryConditionValue = "";
            SalString sReturnValue = "";
            #endregion

            #region Actions
            lsWhereClauseTemp = lsWhereClause.ToUpper();
            nColumnNameIndex = lsWhereClauseTemp.Scan(sColumnNameIn);
            if (nColumnNameIndex != -1)
            {
                int nIndex = lsWhereClauseTemp.ToString().IndexOf("AND", nColumnNameIndex);
                if (nIndex >= 0)
                {
                    sQueryConditionValue = lsWhereClauseTemp.ToString().Substring(nColumnNameIndex, nIndex - nColumnNameIndex);
                }
                else
                {
                    sQueryConditionValue = lsWhereClauseTemp.ToString().Substring(nColumnNameIndex);
                }
                // Extract the query condition value
                int index1 = sQueryConditionValue.Scan("@");
                int index2 = sQueryConditionValue.Scan(Ifs.Fnd.ApplicationForms.Var.g_sCHAR_FS);
                // Bug 126027, begin
                int length = index2 - index1 - 1;
                if (length > -1)
                {
                    sReturnValue = sQueryConditionValue.ToString().Substring(index1 + 1, length);
                }
                // Bug 126027, end
            }
            return sReturnValue;
            #endregion
        }
	}
}
