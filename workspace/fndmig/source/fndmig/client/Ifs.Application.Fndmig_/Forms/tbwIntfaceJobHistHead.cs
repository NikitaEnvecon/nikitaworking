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
	/// Overview - Interface History
	/// </summary>
    [FndWindowRegistration("INTFACE_JOB_HIST_HEAD", "IntfaceJobHistHead")]
    public partial class tbwIntfaceJobHistHead : cTableWindow
    {

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwIntfaceJobHistHead()
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
        public new static tbwIntfaceJobHistHead FromHandle(SalWindowHandle handle)
        {
            return ((tbwIntfaceJobHistHead)SalWindow.FromHandle(handle, typeof(tbwIntfaceJobHistHead)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="sFormName"></param>
        /// <returns></returns>
        public virtual SalBoolean PrepareLaunch(SalString sFormName)
        {
            #region Local Variables
            SalArray<SalString> sArray = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndArray = new SalArray<SalWindowHandle>();
            SalNumber nCurrentTableRow = 0;
            // Variables for printing report
            SalString lsReportAttr = "";
            SalString lsParameterAttr = "";
            SalNumber nResultKey = 0;
            SalString sPrintMode = "";
            SalString sReservResult = "";
            // Window handles for AlertBox
            SalNumber nReturn = 0;
            SalNumber hBtnPrint = 0;
            SalNumber hBtnPreview = 0;
            SalNumber hBtnCancel = 0;
            SalArray<SalNumber> hButtonArray = new SalArray<SalNumber>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                if (sFormName == Pal.GetActiveInstanceName("frmIntfaceJobHistHead"))
                {
                    sArray[0] = "INTFACE_NAME";
                    hWndArray[0] = colsIntfaceName;
                    sArray[1] = "EXECUTION_NO";
                    hWndArray[1] = colnExecutionNo;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("tbwIntfaceJobHistHead"), this, sArray, hWndArray);
                    SessionNavigate(Pal.GetActiveInstanceName("frmIntfaceJobHistHead"));
                    Sal.WaitCursor(false);
                    return true;
                }
                else
                {
                    Sal.WaitCursor(false);
                    return false;
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <param name="sMethod"></param>
        /// <returns></returns>
        public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (sMethod == Pal.GetActiveInstanceName("frmIntfaceJobHistHead"))
                        {
                            return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmIntfaceJobHistHead")) && Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0);
                        }
                        else
                        {
                            return false;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        if (sMethod == Pal.GetActiveInstanceName("frmIntfaceJobHistHead"))
                        {
                            return PrepareLaunch(sMethod);
                        }
                        else
                        {
                            return false;
                        }
                        break;
                }
            }

            return false;
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

        private void menuItem__Job_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)Pal.GetActiveInstanceName("frmIntfaceJobHistHead")).ToHandle());
        }

        private void menuItem__Job_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)Pal.GetActiveInstanceName("frmIntfaceJobHistHead")).ToHandle());
        }

        #endregion

    }
}
