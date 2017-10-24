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
	
	public sealed class Const
	{
		
		/// <summary>
		/// </summary>
		public const int PAM_CheckUncheckCBTextFr = Sys.SAM_User + 1;
		
		/// <summary>
		/// </summary>
		public const int PAM_BrowseFile = Ifs.Fnd.ApplicationForms.Const.PAM_User + 444;
		
		/// <summary>
		/// Pseudo Codes
		/// </summary>
		public const int PAM_GetUserGroup = Ifs.Fnd.ApplicationForms.Const.PAM_User + 220;
		
		/// <summary>
		/// flags used to enable codpart's editing
		/// </summary>
		public const int FLAG1_EnableCodeB = 0;
		public const int FLAG1_EnableCodeC = 1;
		public const int FLAG1_EnableCodeD = 2;
		public const int FLAG1_EnableCodeE = 3;
		public const int FLAG1_EnableCodeF = 4;
		public const int FLAG1_EnableCodeG = 5;
		public const int FLAG1_EnableCodeH = 6;
		public const int FLAG1_EnableCodeI = 7;
		public const int FLAG1_EnableCodeJ = 8;
		
		/// <summary>
		/// MAKRLK, Twin Peaks,Changes for Project Cost Element Setup ,Start
		/// </summary>
		public const int PAM_RefreshTabs1 = Ifs.Fnd.ApplicationForms.Const.PAM_User + 1;
        // TODO: following string constenets were added as a temerary solution to clear missing constent error from dlgVoucherTransfer.cs, 
        // TODO: these constent declarations were removed from __infoserv.apl    
        public const string __FNDINF_BatchExecInvalidTime = "__FNDINF_BatchExecInvalidTime: A valid time must be entered";
        public const string __FNDINF_BatchExecInvalidDate = "__FNDINF_BatchExecInvalidDate: A valid date must be entered"; 
	}
}
