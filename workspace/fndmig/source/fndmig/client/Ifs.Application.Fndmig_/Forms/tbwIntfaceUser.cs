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
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Fndmig_
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("INTFACE_USER", "IntfaceUser")]
    public partial class tbwIntfaceUser : cTableWindow
    {
        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwIntfaceUser()
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
        public new static tbwIntfaceUser FromHandle(SalWindowHandle handle)
        {
            return ((tbwIntfaceUser)SalWindow.FromHandle(handle, typeof(tbwIntfaceUser)));
        }
        #endregion

        #region Event Handlers

        private void menuItem_Pr_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = this.AnyRows(Sys.ROW_Selected, 0) &&
                this.SourceStateQuery(Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Query) &&
                vrtDataSourceCreateWindow(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Pal.GetActiveInstanceName("frmIntfacePrUser"));
        }

        private void menuItem_Pr_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            vrtDataSourceCreateWindow(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Pal.GetActiveInstanceName("frmIntfacePrUser"));
        }

        #endregion
    }
}
