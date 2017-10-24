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
    public partial class tbwIntfaceGroup : cTableWindow
    {
        #region Window Variables
        public SalString lsExportInfo = "";
        public SalString sFileLoc = "";
        public SalString sExecPlan = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwIntfaceGroup()
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
        public new static tbwIntfaceGroup FromHandle(SalWindowHandle handle)
        {
            return ((tbwIntfaceGroup)SalWindow.FromHandle(handle, typeof(tbwIntfaceGroup)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual void PrepareLaunch()
        {
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                lsExportInfo = "GROUP_ID=" + colsGroupId.Text;
                colsExportGroup.Text = "FNDMIG_EXPORT";
                DbImmediate("SELECT &AO.Intface_File_Location_API.Encode(&AO.Intface_Header_API.Get_File_Location(:i_hWndFrame.tbwIntfaceGroup.colsExportGroup)) INTO :i_hWndFrame.tbwIntfaceGroup.sFileLoc FROM dual");
                sExecPlan = "ONLINE";
                Sal.WaitCursor(true);
                if (DbTransactionBegin())
                {
                    if (DbPLSQLBlock("&AO.Intface_Header_API.Start_Job(:i_hWndFrame.tbwIntfaceGroup.lsExportInfo IN, :i_hWndFrame.tbwIntfaceGroup.sExecPlan IN, :i_hWndFrame.tbwIntfaceGroup.colsExportGroup IN)"))
                    {
                        DbTransactionEnd();
                    }
                    else
                    {
                        DbCommit();
                        // gjohno 191199 Disabled so the rollback is not in function
                        // Call DbTransactionClear(c_hSql)
                        DbTransactionEnd();
                        Sal.WaitCursor(false);
                        return;
                    }
                    Sal.WaitCursor(false);
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(lsExportInfo, Properties.Resources.ALERT_TitleEx, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    if (sFileLoc != "1")
                    {
                        SalArray<SalString> sArray = new SalArray<SalString>();
                        SalArray<SalWindowHandle> hWndArray = new SalArray<SalWindowHandle>();

                        sArray[0] = "INTFACE_NAME";
                        hWndArray[0] = colsExportGroup;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("tbwIntfaceGroup"), this, sArray, hWndArray);
                        SessionNavigate(Pal.GetActiveInstanceName("frmIntfaceStart"));
                    }
                }
            }
        }

        #endregion

        #region Event Handlers

        private void menuItem__Export_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = (Ifs.Fnd.ApplicationForms.Int.PalTblCountRows(i_hWndSelf, Sys.ROW_Selected, 0) == 1) &&
                !vrtDataSourceIsDirty(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) &&
                vrtDataSourceCreateWindow(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Pal.GetActiveInstanceName("frmIntfaceStart"));
        }

        private void menuItem__Export_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            PrepareLaunch();
        }

        #endregion
    }
}
