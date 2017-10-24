#region Copyright (c) IFS Research & Development
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
#endregion
#region History
#endregion


using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace $rootnamespace$
{
    public class $safeitemname$
    {
	
		#region System Methods/Properties
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public static new $safeitemname$ FromHandle(SalWindowHandle handle)
		{
			return (($safeitemname$)SalWindow.FromHandle(handle, typeof($safeitemname$)));
		}
		#endregion

    }
}
