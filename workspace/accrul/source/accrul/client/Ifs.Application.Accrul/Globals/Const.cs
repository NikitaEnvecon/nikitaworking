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
// 13-05-17    MAAYLK    Bug 108483, Added PAM_ChildTableSynchronizeProfile to refresh the visibility of Code Part columns of child table
// 13-07-01    MAAYLK    Bug 109903, Added PAM_FinFormFrameShutDownUser to inform child tables about FrameShutDown
#endregion

using PPJ.Runtime;

namespace Ifs.Application.Accrul
{
	
	public sealed class Const
	{
		
		/// <summary>
		/// for translate text of object according to Code Internam Name
		/// </summary>
		public const int PM_ACFieldEnabled = Ifs.Fnd.ApplicationForms.Const.PAM_User + 10;
		public const int PAM_SendParam = Sys.SAM_User + 5019;
		public const int PAM_AccntCheckUncheckCBText = Sys.SAM_User + 1;
		
		/// <summary>
		/// ExtFileTranslation
		/// </summary>
		public const int METHOD_ExtDisable = 1;
		public const int METHOD_ExtEnable = 2;
		public const int METHOD_ExtEnableDefault = 3;
		public const int PAM_ExtEnableDisable = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2003;
		public const int PAM_ExtTranslateTitle = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2002;
		
		/// <summary>
		/// FINLIB class messages
		/// </summary>
		public const int PAM_ACFieldEnabled = Ifs.Fnd.ApplicationForms.Const.PAM_User + 100;
		public const int PAM_GetAndSetDefaultCompany = Ifs.Fnd.ApplicationForms.Const.PAM_User + 101;
		public const int PAM_ChangedChildText = Ifs.Fnd.ApplicationForms.Const.PAM_User + 102;
		public const int PAM_CallChanged = Ifs.Fnd.ApplicationForms.Const.PAM_User + 103;
		public const int PAM_TranslateCodePartTab = Ifs.Fnd.ApplicationForms.Const.PAM_User + 104;
		public const int PAM_DlgSetLovState = Ifs.Fnd.ApplicationForms.Const.PAM_User + 105;
		public const int PAM_DlgFieldCheckState = Ifs.Fnd.ApplicationForms.Const.PAM_User + 106;
		public const int PAM_DlgSetCombo = Ifs.Fnd.ApplicationForms.Const.PAM_User + 107;
		public const int PAM_DlgCheckState = Ifs.Fnd.ApplicationForms.Const.PAM_User + 108;
		public const int PAM_DlgSetStatePbLov = Ifs.Fnd.ApplicationForms.Const.PAM_User + 109;
		public const int PAM_DlgSetDefPb = Ifs.Fnd.ApplicationForms.Const.PAM_User + 110;
		public const int PAM_DlgSetDataFieldValues = Ifs.Fnd.ApplicationForms.Const.PAM_User + 111;
		public const int PAM_DlgFocusFirst = Ifs.Fnd.ApplicationForms.Const.PAM_User + 112;
		public const int PAM_ChangeCompany = Sys.SAM_User + 5001;
		public const int PAM_DescriptionFind = Ifs.Fnd.ApplicationForms.Const.PAM_User + 113;
		public const int PAM_DescriptionFound = Ifs.Fnd.ApplicationForms.Const.PAM_User + 114;
		public const int PAM_DisableUnusedCodeParts = Ifs.Fnd.ApplicationForms.Const.PAM_User + 115;
		public const int PAM_ValidateCodePartValues = Ifs.Fnd.ApplicationForms.Const.PAM_User + 116;
		public const int PAM_SetCodePartValues = Ifs.Fnd.ApplicationForms.Const.PAM_User + 117;
		public const int PAM_CodePartBlocked = Ifs.Fnd.ApplicationForms.Const.PAM_User + 118;
		public const int PAM_CheckExternalProject = Ifs.Fnd.ApplicationForms.Const.PAM_User + 119;
		public const int PAM_VoucherDateGet = Ifs.Fnd.ApplicationForms.Const.PAM_User + 150;
		public const int PAM_UserGroupGet = Ifs.Fnd.ApplicationForms.Const.PAM_User + 151;
		public const int PAM_ShowInternalCP = Ifs.Fnd.ApplicationForms.Const.PAM_User + 200;
		
		/// <summary>
		/// </summary>
		public const int PM_TranslateCodePartTab = Ifs.Fnd.ApplicationForms.Const.PAM_User + 15;
		public const int PAM_ZoomIn = Sys.SAM_User + 5018;
		public const int PAM_CellContentFind = Sys.SAM_User + 5022;
		public const int PAM_CellContentFound = Sys.SAM_User + 5023;
		
		/// <summary>
		/// </summary>
		public const int PAM_GetChildCompany = Sys.SAM_User + 5024;
		public const int PAM_SynchronizeWithProfile = Ifs.Fnd.ApplicationForms.Const.PAM_User + 8888;
		public const int PAM_GetMultiCompany = Sys.SAM_User + 8889;
		public const int PAM_SetCodePartValue = Ifs.Fnd.ApplicationForms.Const.PAM_User + 8890;
		public const int PAM_SetCodePartDesc = Ifs.Fnd.ApplicationForms.Const.PAM_User + 8891;
		public const int PAM_SetCodePartDescription = Ifs.Fnd.ApplicationForms.Const.PAM_User + 9000;
		public const int PAM_CodePartDescBlocked = Ifs.Fnd.ApplicationForms.Const.PAM_User + 8892;
		public const int PAM_FetchCodePartValue = Ifs.Fnd.ApplicationForms.Const.PAM_User + 8893;
		public const int PAM_SetAccYear = Ifs.Fnd.ApplicationForms.Const.PAM_User + 8887;
		public const int PAM_SetNullCodeParts = Ifs.Fnd.ApplicationForms.Const.PAM_User + 8890;
		
		/// <summary>
		/// Bug 108483, Begin
		/// </summary>
		public const int PAM_ChildTableSynchronizeProfile = Ifs.Fnd.ApplicationForms.Const.PAM_User + 8895;
		
		/// <summary>
		/// Bug 108483, End
		/// Bug 109903, Begin
		/// </summary>
		public const int PAM_FinFormFrameShutDownUser = Ifs.Fnd.ApplicationForms.Const.PAM_User + 8896;
		
		/// <summary>
		/// Bug 109903, End
		/// </summary>
		public const int PAM_ChangedCompany = Ifs.Fnd.ApplicationForms.Const.PAM_User + 8891;
		
		/// <summary>
		/// </summary>
		public const int PAM_ChangeLovTitle = Ifs.Fnd.ApplicationForms.Const.PAM_User + 8894;
		
		/// <summary>
		/// </summary>
		public const int PAM_CheckUncheckText = Sys.SAM_User + 1;
		
		/// <summary>
		/// </summary>
		public const int PAM_MCCheckUncheckText = Sys.SAM_User + 1;
		
		/// <summary>
		/// </summary>
		public const int PAM_GetIntPostingInfo = Ifs.Fnd.ApplicationForms.Const.PAM_User + 170;
		public const int PAM_GetSelectionInfo = Ifs.Fnd.ApplicationForms.Const.PAM_User + 90000;
		public const int PAM_SelTemplSetFocusField = Ifs.Fnd.ApplicationForms.Const.PAM_User + 90001;
		public const int PAM_GetOptionAttr = Ifs.Fnd.ApplicationForms.Const.PAM_User + 90002;
		public const int PAM_SaveSelectionTemplate = Ifs.Fnd.ApplicationForms.Const.PAM_User + 90003;
		public const int PAM_ValidateSelectionTemplate = Ifs.Fnd.ApplicationForms.Const.PAM_User + 90004;
		public const int PAM_SelTemplInitWindow = Ifs.Fnd.ApplicationForms.Const.PAM_User + 90005;        
		public const int QUERYACTION_ParentCompany = 50;
		public const int QUERYACTION_FocusField = 51;
		public const int QUERYACTION_GetObjectGroupId = 52;
		public const int QUERYACTION_GetObjectId = 53;
		public const int QUERYACTION_GetSelectionId = 54;
		public const int QUERYACTION_SetSelectionId = 55;
		public const int QUERYACTION_GetDefParameters = 56;
        public const int QUERYACTION_SetValues = 57;
	}
}
