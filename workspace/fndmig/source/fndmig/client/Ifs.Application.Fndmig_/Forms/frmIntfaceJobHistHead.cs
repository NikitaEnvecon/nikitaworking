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
    [FndWindowRegistration("INTFACE_JOB_HIST_HEAD", "IntfaceJobHistHead")]
    public partial class frmIntfaceJobHistHead : cFormWindow
    {
        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmIntfaceJobHistHead()
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
        public new static frmIntfaceJobHistHead FromHandle(SalWindowHandle handle)
        {
            return ((frmIntfaceJobHistHead)SalWindow.FromHandle(handle, typeof(frmIntfaceJobHistHead)));
        }
        #endregion

        #region Overrides

        public override SalBoolean vrtDataSourcePopulateIt(SalNumber nParam)
        {
            bool bOk = base.vrtDataSourcePopulateIt(nParam);
            SetTitle();
            return bOk;
        }

        public override SalBoolean vrtDataSourceClearIt(SalNumber nParam)
        {
            bool bOk = base.vrtDataSourceClearIt(nParam);
            SetTitle();
            return bOk;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the proper window title
        /// </summary>
        protected virtual void SetTitle()
        {
            string title = string.Empty;
            if (this.SourceStateQuery(Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Query))
            {
                SalArray<SalString> sParamArray = new SalArray<SalString>();
                sParamArray[0] = SalString.FromHandle(ecmbIntfaceName.EditDataItemValueGet());
                title = Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams(Properties.Resources.WH_frmIntfaceJobHistHead, sParamArray);
            }
            else
            {
                title = Properties.Resources.WH_frmIntfaceJobHistHeadClear;
            }
            Sal.SetWindowText(this, title);
        }

        #endregion
    }
}
