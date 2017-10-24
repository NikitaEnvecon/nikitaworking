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
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Fndmig_
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("INTFACE_REPL_DB_OBJECTS", "intfaceReplDbObjects", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwIntfaceReplDbObjects : cTableWindow
    {

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwIntfaceReplDbObjects()
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
        public new static tbwIntfaceReplDbObjects FromHandle(SalWindowHandle handle)
        {
            return ((tbwIntfaceReplDbObjects)SalWindow.FromHandle(handle, typeof(tbwIntfaceReplDbObjects)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// The framework calls the UserMethod function on arrival of the
        /// PM_UserMethod message to perform an application defined method.
        /// Applications should override this function to implement the
        /// methods.
        /// COMMENTS:
        /// The nWhat and sMethod parameters correspont to the wParam and
        /// lParam parameters for the PM_UserMethod message received by
        /// the framework.
        /// EXAMPLE:
        /// Function: UserMethod
        /// 	Actions
        /// 		If sMethod = 'check credit'
        /// 			Return UM_CheckCredit( nWhat )
        /// 		If sMethod = 'update statistics'
        /// 			Return UM_UpdateStatistics( nWhat )
        /// 		Else
        /// 			Return FALSE
        /// </summary>
        /// <param name="nWhat">
        /// Standard method parameter
        /// Standard method parameter. Possible values are METHOD_Inquire, METHOD_Execute, METHOD_GetType
        /// </param>
        /// <param name="sMethod">
        /// Method name
        /// Name of the method to be executed.
        /// </param>
        /// <returns>
        /// When nWhat = METHOD_Inquire: the return value should be TRUE if the
        /// method is available (possible to execute), FALSE otherwise.
        /// When nWhat = METHOD_Execute: the return value should be TRUE if the method
        /// is completed sucessfully, FALSE otherwise.
        /// </returns>
        public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (sMethod == "ShowSourceText")
                {
                    return ShowSourceText(nWhat);
                }
                return 0;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber ShowSourceText(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (Sal.IsNull(colsObjectName))
                        {
                            return false;
                        }
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("INTFACE_REPL_MAINT_UTIL_API.Show_Source_Text", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
                            if (DbPLSQLBlock(cSessionManager.c_hSql, "&AO.INTFACE_REPL_MAINT_UTIL_API.Show_Source_Text(:i_hWndFrame.tbwIntfaceReplDbObjects.colsHiddenSqlStatement,\r\n" +
                                "                                :i_hWndFrame.tbwIntfaceReplDbObjects.colsObjectName)"))
                            {
                                // Snippet Comment: Editor is replaced in APF grid to its own drop down editor, So we need to call editor manually.
                                this.colsHiddenSqlStatement.EditLaunchEditor();
                            }
                        }
                        Sal.WaitCursor(false);
                        return true;
                }
            }

            return 0;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }
        #endregion

        #region Event Handlers

        private void menuItem_Show_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"ShowSourceText").ToHandle());
        }

        private void menuItem_Show_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ShowSourceText").ToHandle());
        }

        #endregion

    }
}
