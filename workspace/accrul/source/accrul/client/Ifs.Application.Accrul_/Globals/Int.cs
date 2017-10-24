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

using PPJ.Runtime;

namespace Ifs.Application.Accrul_
{
	
	public sealed class Int
	{
        public static bool IsIntLedInstalled
        {
            get { return Ifs.Fnd.ApplicationForms.Int.IsSystemComponentInstalled("INTLED"); }
        }

        public static bool IsFixAssInstalled
        {
            get { return Ifs.Fnd.ApplicationForms.Int.IsSystemComponentInstalled("FIXASS"); }
        }

		/// <summary>
		/// </summary>
		/// <returns></returns>
		public static SalNumber ShowAccrulReports()
		{
			#region Local Variables
			SalString lsTempAttr = "";
			#endregion
			
			#region Actions

			// IFS Accounting Rules Reports

			Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MODULE", "ACCRUL", ref lsTempAttr);
			Ifs.Fnd.ApplicationForms.Var.InfoService.ReportOrderDialogOpen(lsTempAttr, Ifs.Fnd.ApplicationForms.Const.strNULL, Ifs.Fnd.ApplicationForms.Const.strNULL, Ifs.Fnd.ApplicationForms.Const.strNULL);

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="dDate"></param>
		/// <param name="dStartDate"></param>
		/// <param name="dEndDate"></param>
		/// <returns></returns>
		public static SalNumber PalDateGetDayInterval(SalDateTime dDate, ref SalDateTime dStartDate, ref SalDateTime dEndDate)
		{
			#region Actions
			dStartDate = new SalDateTime(dDate.Year(), dDate.Month(), dDate.Day(), 0, 0, 0);
			dEndDate = new SalDateTime(dDate.Year(), dDate.Month(), dDate.Day(), 23, 59, 59);

			return 0;
			#endregion
		}
	}
}
