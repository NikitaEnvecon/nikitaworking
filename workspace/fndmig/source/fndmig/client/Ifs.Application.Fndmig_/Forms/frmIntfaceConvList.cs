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

using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Fndmig_
{

    /// <summary>
    /// </summary>
    [FndWindowRegistration("INTFACE_CONV_LIST", "IntfaceConvList")]
    public partial class frmIntfaceConvList : cFormWindow
    {
        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmIntfaceConvList()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public new static frmIntfaceConvList FromHandle(SalWindowHandle handle)
        {
            return ((frmIntfaceConvList)SalWindow.FromHandle(handle, typeof(frmIntfaceConvList)));
        }
        #endregion
    }
}
