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
    [FndWindowRegistration("INTFACE_DETAIL", "IntfaceDetail")]
    [FndDynamicTabPage("frmIntfaceHeader.picTab", "DETAILCONV", "tbwIntfaceDetailConversion", "TAB_NAME_DetailConversion", 0)]
    public partial class tbwIntfaceDetailConversion : cTableWindow
    {
        #region Window Variables
        public SalString lsOut = "";
        public SalString sProcedureName = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwIntfaceDetailConversion()
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
        public new static tbwIntfaceDetailConversion FromHandle(SalWindowHandle handle)
        {
            return ((tbwIntfaceDetailConversion)SalWindow.FromHandle(handle, typeof(tbwIntfaceDetailConversion)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns>
        /// Applications should return FALSE to skip standard window startup logic (such
        /// as exectuing the "startup behavior" settings), or TRUE to allow standard logic.
        /// </returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                DbImmediate("SELECT " + cSessionManager.c_sDbPrefix + "Intface_Direction_API.Get_Client_Value(1)\r\n" +
                    "                                  INTO :i_hWndFrame.tbwIntfaceDetail.lsOut FROM dual");
                return true;
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
                if (sMethod == "ConvCols")
                {
                    return ConvCols(nWhat);
                }
                return false;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sFormName"></param>
        /// <returns></returns>
        public virtual SalBoolean PrepareLaunch(SalString sFormName)
        {
            #region Local Variables
            SalString sSourceName = "";
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalWindowHandle hWndSource = SalWindowHandle.Null;
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                hWndSource = this;
                sSourceName = "INTFACE_DETAIL";
                sItemNames[0] = "CONV_LIST_ID";
                hWndItems[0] = colsConvListId;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(sSourceName, hWndSource, sItemNames, hWndItems);
                SessionNavigate(sFormName);
                Sal.WaitCursor(false);
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean ConvCols(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        // Should only be available if colsIntfaceName and colsColumnName has a value
                        if (Sal.IsNull(colsIntfaceName) && Sal.IsNull(colsColumnName))
                        {
                            return false;
                        }
                        else if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            return false;
                        }
                        else if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable("frmIntfaceConvList.tblIntfaceConvListCols")))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        return PrepareLaunch(Pal.GetActiveInstanceName("frmIntfaceConvList"));

                    default:
                        return false;
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckConvList()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (colsConvListId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }
        #endregion

        #region Event Handlers

        private void menuItem_Convert_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Checked = Sal.TblAnyRows(Sys.hWndForm, Sys.ROW_Selected, 0) && ((bool)Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"ConvCols").ToHandle()));
            ((FndCommand)sender).Enabled = CheckConvList();
        }

        private void menuItem_Convert_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Sal.PostMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ConvCols").ToHandle());
        }

        private void menuTbwMethods_menuTranslation_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sModule = new SalArray<SalString>();
            SalArray<SalString> sLu = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sModule[0] = "FNDMIG";
                sLu[0] = "IntfaceDetail";
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet(Pal.GetActiveInstanceName("tbwIntfaceDetailConversion"));
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("MODULE", sModule);
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("LU", sLu);
                SessionNavigate(Pal.GetActiveInstanceName("frmBasicDataTranslation"));
            }
            #endregion
        }

        private void menuTbwMethods_menuTranslation_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            #region Action
            if (i_hWndParent != null && i_hWndParent.GetName().Value == Pal.GetActiveInstanceName("frmIntfaceHeader"))
            {
                frmIntfaceHeader header = (frmIntfaceHeader)i_hWndParent;
                if (header.dfsProcedureName.Text == "EXCEL_MIGRATION")
                {
                    ((FndCommand)sender).Enabled = true;
                }
                else
                {
                    ((FndCommand)sender).Enabled = false;
                }
            }
            else
            {
                using (new SalContext(this))
                {
                    if (DbImmediate("SELECT " + cSessionManager.c_sDbPrefix + "Intface_Header_API.Get_Procedure_Name(:i_hWndFrame.tbwIntfaceDetailConversion.colsIntfaceName)\r\n" +
                                    "                                  INTO :i_hWndFrame.tbwIntfaceDetailConversion.sProcedureName FROM dual"))
                    {
                        if (sProcedureName == "EXCEL_MIGRATION")
                        {
                            ((FndCommand)sender).Enabled = true;
                        }
                        else
                        {
                            ((FndCommand)sender).Enabled = false;
                        }
                    }
                    else
                    {
                        ((FndCommand)sender).Enabled = false;
                    }
                }
            }
            #endregion
        }
        #endregion
    }
}
