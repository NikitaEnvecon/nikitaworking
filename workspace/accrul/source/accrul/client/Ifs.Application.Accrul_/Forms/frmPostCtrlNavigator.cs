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

using System;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using Ifs.Application.Accrul;
using Ifs.Application.Appsrv;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Accrul_
{

    /// <summary>
    /// </summary>
    public partial class frmPostCtrlNavigator : cContainerTabFormWindowFin
    {
        #region Window Variables
        public cMessage msg = new cMessage();
        public SalString sModule = "";
        public SalString sPostingType = "";
        public SalString sPostingTypeDesc = "";
        public SalString sCodePart = "";
        public SalString sCodeName = "";
        public SalString sControlType = "";
        public SalString sControlTypeValue = "";
        public SalString sControlTypeValueDesc = "";
        public SalDateTime dPcValidFrom = SalDateTime.Null;
        public SalString sTemp = "";
        public SalDateTime dTemp = SalDateTime.Null;
        public SalNumber nTemp = 0;
        public SalDateTime dValidFrom = SalDateTime.Null;
        public SalArray<SalNumber> nTabNode = new SalArray<SalNumber>(6);
        public SalNumber nCurrentNode = 0;
        public SalString sCtrlTypeCategoryDb = "";
        public SalNumber nMsgReturn = 0;
        public SalNumber nRootNode = 0;
        public SalNumber i = 0;
        public SalDateTime dStartDate = SalDateTime.Null;
        public SalDateTime dEndDate = SalDateTime.Null;
        public SalDateTime dPCStartDate = SalDateTime.Null;
        public SalDateTime dPCEndDate = SalDateTime.Null;
        public SalString sNonPostingModule = "";
        public SalBoolean bSaveChanges = false;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmPostCtrlNavigator()
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
        public new static frmPostCtrlNavigator FromHandle(SalWindowHandle handle)
        {
            return ((frmPostCtrlNavigator)SalWindow.FromHandle(handle, typeof(frmPostCtrlNavigator)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="hItem"></param>
        /// <returns></returns>
        public virtual SalNumber CreateRootNode(SalNumber hItem)
        {
            #region Local Variables
            SalString sDate = "";
            SalString sFullName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                msg.Construct();
                msg.AddAttribute("DISPLAY_ATTR", Properties.Resources.TEXT_PostCtrlNavigator);
                nRootNode = tlbTree.TreeListNodeInsert(0, -1, msg, false);
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nNodeType"></param>
        /// <param name="hItem"></param>
        /// <returns></returns>
        public virtual SalNumber CreateModuleNode(SalNumber nNodeType, SalNumber hItem)
        {
            #region Local Variables
            SalNumber nFetch = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                DbPrepareAndExecute(cSessionManager.c_hSql, "SELECT DISTINCT post_module\r\n" +
                    "	INTO :i_hWndFrame.frmPostCtrlNavigator.sModule\r\n" +
                    "	FROM &AO.posting_ctrl_master\r\n" +
                    "	WHERE company = '" + i_sCompany + "'\r\n" +
                    "                ORDER BY post_module");
                while (DbFetchNext(cSessionManager.c_hSql, ref nFetch))
                {
                    msg.Construct();
                    msg.SetName(sModule);
                    msg.AddAttribute("DISPLAY_ATTR", sModule);
                    msg.AddAttribute("MODULE", sModule);
                    tlbTree.TreeListNodeInsert(nNodeType, hItem, msg, false);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nNodeType"></param>
        /// <param name="hItem"></param>
        /// <returns></returns>
        public virtual SalNumber CreatePostingTypeNode(SalNumber nNodeType, SalNumber hItem)
        {
            #region Local Variables
            SalNumber nFetch = 0;
            SalString sInfo = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                tlbTree.TreeListNodeGet(hItem, msg);
                sModule = msg.FindAttribute("MODULE", "");
                DbPrepareAndExecute(cSessionManager.c_hSql, "SELECT DISTINCT posting_type, posting_type_desc, sort_order\r\n" +
                    "	INTO :i_hWndFrame.frmPostCtrlNavigator.sPostingType, :i_hWndFrame.frmPostCtrlNavigator.sPostingTypeDesc, :i_hWndFrame.frmPostCtrlNavigator.nTemp\r\n" +
                    "	FROM &AO.posting_ctrl_master\r\n" +
                    "	WHERE company = '" + i_sCompany + "'\r\n" +
                    "	  AND  post_module = '" + sModule + "'" + " ORDER BY sort_order ");
                while (DbFetchNext(cSessionManager.c_hSql, ref nFetch))
                {
                    msg.Construct();
                    msg.AddAttribute("MODULE", sModule);
                    msg.AddAttribute("DISPLAY_ATTR", sPostingType + " - " + sPostingTypeDesc);
                    msg.AddAttribute("POSTING_TYPE", sPostingType);
                    msg.AddAttribute("MODULE", sModule);
                    tlbTree.TreeListNodeInsert(nNodeType, hItem, msg, false);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nNodeType"></param>
        /// <param name="hItem"></param>
        /// <returns></returns>
        public virtual SalNumber CreateCodePartNode(SalNumber nNodeType, SalNumber hItem)
        {
            #region Local Variables
            SalNumber nFetch = 0;
            SalString sInfo = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                tlbTree.TreeListNodeGet(hItem, msg);
                sModule = msg.FindAttribute("MODULE", "");
                sPostingType = msg.FindAttribute("POSTING_TYPE", "");
                DbPrepareAndExecute(cSessionManager.c_hSql, "SELECT DISTINCT code_part, code_name\r\n" +
                    "	INTO :i_hWndFrame.frmPostCtrlNavigator.sCodePart, :i_hWndFrame.frmPostCtrlNavigator.sCodeName\r\n" +
                    "	FROM &AO.posting_ctrl_master\r\n" +
                    "	WHERE company = '" + i_sCompany + "'\r\n" +
                    "	  AND  post_module = '" + sModule + "'\r\n" +
                    "	  AND  posting_type = '" + sPostingType + "'");
                while (DbFetchNext(cSessionManager.c_hSql, ref nFetch))
                {
                    msg.Construct();
                    msg.AddAttribute("MODULE", sModule);
                    msg.AddAttribute("POSTING_TYPE", sPostingType);
                    msg.AddAttribute("CODE_PART", sCodePart);
                    msg.AddAttribute("CODE_NAME", sCodeName);
                    msg.AddAttribute("DISPLAY_ATTR", sCodeName);
                    tlbTree.TreeListNodeInsert(nNodeType, hItem, msg, false);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nNodeType"></param>
        /// <param name="hItem"></param>
        /// <returns></returns>
        public virtual SalNumber CreatePcValidFromNode(SalNumber nNodeType, SalNumber hItem)
        {
            #region Local Variables
            SalNumber nFetch = 0;
            SalString sInfo = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                tlbTree.TreeListNodeGet(hItem, msg);
                sModule = msg.FindAttribute("MODULE", "");
                sPostingType = msg.FindAttribute("POSTING_TYPE", "");
                sCodeName = msg.FindAttribute("CODE_NAME", "");
                sCodePart = msg.FindAttribute("CODE_PART", "");
                // Bug 75985, Added Module
                DbPrepareAndExecute(cSessionManager.c_hSql, "SELECT DISTINCT pc_valid_from, ctrl_type_category_db, control_type,module\r\n" +
                    "	INTO :i_hWndFrame.frmPostCtrlNavigator.dfdTempDate, :i_hWndFrame.frmPostCtrlNavigator.sCtrlTypeCategoryDb, :i_hWndFrame.frmPostCtrlNavigator.sControlType,\r\n" +
                    "                          :i_hWndFrame.frmPostCtrlNavigator.sNonPostingModule\r\n" +
                    "	FROM &AO.posting_ctrl_master \r\n" +
                    "	WHERE company = '" + i_sCompany + "'\r\n" +
                    "	  AND  post_module = '" + sModule + "'\r\n" +
                    "	  AND  posting_type = '" + sPostingType + "'\r\n" +
                    "	  AND  code_part = '" + sCodePart + "'");
                // Bug 75985, End
                while (DbFetchNext(cSessionManager.c_hSql, ref nFetch))
                {
                    msg.Construct();
                    msg.AddAttribute("MODULE", sModule);
                    msg.AddAttribute("POSTING_TYPE", sPostingType);
                    msg.AddAttribute("CODE_PART", sCodePart);
                    msg.AddAttribute("CODE_NAME", sCodeName);
                    sTemp = dfdTempDate.DateTime.ToString();
                    msg.AddAttribute("PC_VALID_FROM", sTemp);
                    Sal.GetWindowText(dfdTempDate, ref sTemp, 30);
                    msg.AddAttribute("CTRL_TYPE_CATEGORY_DB", sCtrlTypeCategoryDb);
                    msg.AddAttribute("DISPLAY_ATTR", sTemp + " - " + sControlType);
                    // Bug 75985, Begin
                    msg.AddAttribute("CTRL_TYPE", sControlType);
                    msg.AddAttribute("NON_POST_MODULE", sNonPostingModule);
                    // Bug 75985, End
                    tlbTree.TreeListNodeInsert(nNodeType, hItem, msg, false);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nNodeType"></param>
        /// <param name="hItem"></param>
        /// <returns></returns>
        public virtual SalNumber CreateControlTypeValueNode(SalNumber nNodeType, SalNumber hItem)
        {
            #region Local Variables
            SalNumber nFetch = 0;
            SalString sInfo = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                tlbTree.TreeListNodeGet(hItem, msg);
                sModule = msg.FindAttribute("MODULE", "");
                sPostingType = msg.FindAttribute("POSTING_TYPE", "");
                sCodeName = msg.FindAttribute("CODE_NAME", "");
                sCodePart = msg.FindAttribute("CODE_PART", "");
                dPcValidFrom = msg.FindAttribute("PC_VALID_FROM", "").ToDate();
                sCtrlTypeCategoryDb = msg.FindAttribute("CTRL_TYPE_CATEGORY_DB", "");
                // Bug 75985, Added Module and control type
                // Bug 72497 Begin, Removed spec_ctrl_type_category_db and  :i_hWndFrame.frmPostCtrlNavigator.sCtrlTypeCategoryDb from the SELECT statement
                DbPrepareAndExecute(cSessionManager.c_hSql, "SELECT DISTINCT control_type_value, module,control_type,\r\n" +
                    "			&AO.Posting_Ctrl_Control_Type_API.Get_Control_Type_Value_Desc(company, control_type, control_type_value, module)\r\n" +
                    "	INTO :i_hWndFrame.frmPostCtrlNavigator.sControlTypeValue, \r\n" +
                    "                          :i_hWndFrame.frmPostCtrlNavigator.sNonPostingModule,\r\n" +
                    "                          :i_hWndFrame.frmPostCtrlNavigator.sControlType,\r\n" +
                    "                          :i_hWndFrame.frmPostCtrlNavigator.sControlTypeValueDesc\r\n" +
                    "	FROM &AO.posting_ctrl_detail\r\n" +
                    "	WHERE company = '" + i_sCompany + "'\r\n" +
                    "	  AND  posting_type = '" + sPostingType + "'\r\n" +
                    "	  AND  code_part = '" + sCodePart + "'\r\n" +
                    "	  AND  pc_valid_from = :i_hWndFrame.frmPostCtrlNavigator.dPcValidFrom\r\n" +
                    "	  AND  spec_control_type IS NOT NULL	\r\n" +
                    "	  AND spec_ctrl_type_category_db NOT IN ('FIXED', 'PREPOSTING')  ");
                // Bug 72497 End
                // Bug 75985, End
                while (DbFetchNext(cSessionManager.c_hSql, ref nFetch))
                {
                    if (sControlTypeValue != SalString.Null)
                    {
                        msg.Construct();
                        msg.AddAttribute("MODULE", sModule);
                        msg.AddAttribute("POSTING_TYPE", sPostingType);
                        msg.AddAttribute("CODE_PART", sCodePart);
                        msg.AddAttribute("CODE_NAME", sCodeName);
                        sTemp = dPcValidFrom.ToString();
                        msg.AddAttribute("PC_VALID_FROM", sTemp);
                        msg.AddAttribute("CONTROL_TYPE_VALUE", sControlTypeValue);
                        msg.AddAttribute("CTRL_TYPE_CATEGORY_DB", sCtrlTypeCategoryDb);
                        msg.AddAttribute("DISPLAY_ATTR", sControlTypeValue + " - " + sControlTypeValueDesc);
                        // Bug 75985, Begin
                        msg.AddAttribute("CTRL_TYPE", sControlType);
                        msg.AddAttribute("NON_POST_MODULE", sNonPostingModule);
                        // Bug 75985, End
                        tlbTree.TreeListNodeInsert(nNodeType, hItem, msg, false);
                    }
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nNodeType"></param>
        /// <param name="hItem"></param>
        /// <returns></returns>
        public virtual SalNumber CreateValidFromNode(SalNumber nNodeType, SalNumber hItem)
        {
            #region Local Variables
            SalNumber nFetch = 0;
            SalString sInfo = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                tlbTree.TreeListNodeGet(hItem, msg);
                sModule = msg.FindAttribute("MODULE", "");
                sPostingType = msg.FindAttribute("POSTING_TYPE", "");
                sCodeName = msg.FindAttribute("CODE_NAME", "");
                sCodePart = msg.FindAttribute("CODE_PART", "");
                dPcValidFrom = msg.FindAttribute("PC_VALID_FROM", "").ToDate();
                sControlTypeValue = msg.FindAttribute("CONTROL_TYPE_VALUE", "");
                sCtrlTypeCategoryDb = msg.FindAttribute("CTRL_TYPE_CATEGORY_DB", "");
                // Bug 75985, Added Module and control_type
                // Bug 72497 Begin, added spec_ctrl_type_category_db to SELECT line and :i_hWndFrame.frmPostCtrlNavigator.sCtrlTypeCategoryDb to INTO line
                DbPrepareAndExecute(cSessionManager.c_hSql, "SELECT DISTINCT valid_from, spec_control_type,spec_ctrl_type_category_db,module,control_type\r\n" +
                    "	INTO :i_hWndFrame.frmPostCtrlNavigator.dfdTempDate, :i_hWndFrame.frmPostCtrlNavigator.sControlType, :i_hWndFrame.frmPostCtrlNavigator.sCtrlTypeCategoryDb,\r\n" +
                    "                          :i_hWndFrame.frmPostCtrlNavigator.sNonPostingModule,\r\n" +
                    "                          :i_hWndFrame.frmPostCtrlNavigator.sControlType\r\n" +
                    "	FROM &AO.posting_ctrl_detail\r\n" +
                    "	WHERE company = '" + i_sCompany + "'\r\n" +
                    "	  AND  posting_type = '" + sPostingType + "'\r\n" +
                    "	  AND  code_part = '" + sCodePart + "'\r\n" +
                    "	  AND  pc_valid_from = :i_hWndFrame.frmPostCtrlNavigator.dPcValidFrom\r\n" +
                    "	  AND  control_type_value = :i_hWndFrame.frmPostCtrlNavigator.sControlTypeValue\r\n" +
                    "	  AND  spec_control_type IS NOT NULL	\r\n" +
                    "	  AND  spec_ctrl_type_category_db NOT IN ('FIXED', 'PREPOSTING') ");
                // Bug 72497 End
                // Bug 75985, End
                while (DbFetchNext(cSessionManager.c_hSql, ref nFetch))
                {
                    msg.Construct();
                    msg.AddAttribute("MODULE", sModule);
                    msg.AddAttribute("POSTING_TYPE", sPostingType);
                    msg.AddAttribute("CODE_PART", sCodePart);
                    msg.AddAttribute("CODE_NAME", sCodeName);
                    sTemp = dPcValidFrom.ToString();
                    msg.AddAttribute("PC_VALID_FROM", sTemp);
                    msg.AddAttribute("CONTROL_TYPE_VALUE", sControlTypeValue);
                    sTemp = dfdTempDate.DateTime.ToString();
                    msg.AddAttribute("VALID_FROM", sTemp);
                    Sal.GetWindowText(dfdTempDate, ref sTemp, 30);
                    msg.AddAttribute("CTRL_TYPE_CATEGORY_DB", sCtrlTypeCategoryDb);
                    msg.AddAttribute("DISPLAY_ATTR", sTemp + " - " + sControlType);
                    // Bug 75985, Begin
                    msg.AddAttribute("CTRL_TYPE", sControlType);
                    msg.AddAttribute("NON_POST_MODULE", sNonPostingModule);
                    // Bug 75985, End
                    tlbTree.TreeListNodeInsert(nNodeType, hItem, msg, true);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nNodeType"></param>
        /// <param name="hItem"></param>
        /// <returns></returns>
        public virtual SalNumber TreeListNodeExpand(SalNumber nNodeType, SalNumber hItem)
        {
            #region Local Variables
            SalString sDate = "";
            SalNumber nReturn = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                tlbTree.TreeListBeginLoad();
                switch (nNodeType)
                {
                    case Ifs.Fnd.ApplicationForms.Const.TREELIST_NodeTypeRoot:
                        CreateRootNode(hItem);
                        break;

                    case 0:
                        CreateModuleNode(nNodeType + 1, hItem);
                        break;

                    case 1:
                        CreatePostingTypeNode(nNodeType + 1, hItem);
                        break;

                    case 2:
                        CreateCodePartNode(nNodeType + 1, hItem);
                        break;

                    case 3:
                        CreatePcValidFromNode(nNodeType + 1, hItem);
                        break;

                    case 4:
                        CreateControlTypeValueNode(nNodeType + 1, hItem);
                        break;

                    case 5:
                        CreateValidFromNode(nNodeType + 1, hItem);
                        break;
                }
                tlbTree.TreeListEndLoad();
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalString GetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Properties.Resources.WH_frmPostCtrlNavigator;
            }
            #endregion
        }
        // Insert new code here...
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Actions
            using (new SalContext(this))
            {
                // Reset the form only when there's n Mark section provided.
                if (URL.GetMark().IsEmpty)
                {
                    i = 0;
                    while (i < 6)
                    {
                        nTabNode[i] = -1;
                        i = i + 1;
                    }
                    picTab.Enable(0, true);
                    picTab.Enable(1, false);
                    picTab.Enable(2, false);
                    picTab.Enable(3, false);
                    picTab.Enable(4, false);
                    tbwPostingCtrl.FromHandle(TabAttachedWindowHandleGet(0)).SetParentNavigator();
                    this.tlbTree.TreeListResetRoot();
                    // Bug 83576, Reset the where condition
                    tbwPostingCtrl.FromHandle(TabAttachedWindowHandleGet(0)).SetWhere("COMPANY = '" + i_sCompany + "'", SalDateTime.Null, SalDateTime.Null);
                }
                return base.Activate(URL);
            }
            #endregion

        }

        /// <summary>
        /// </summary>
        /// <param name="nTab"></param>
        /// <returns></returns>
        public virtual SalNumber RefreshTab(SalNumber nTab)
        {
            using (new SalContext(this))
            {
                picTab.Enable(0, nTab == 0);
                picTab.Enable(1, nTab == 1);
                picTab.Enable(2, nTab == 2);
                picTab.Enable(3, nTab == 3);
                picTab.Enable(4, nTab == 4);
                picTab.BringToTop(nTab, true);
                if (nTabNode[nTab] != nCurrentNode)
                {
                    nTabNode[nTab] = nCurrentNode;
                    tlbTree.TreeListNodeGet(nCurrentNode, msg);
                    SalString sWhere = SalString.Null;
                    sModule = msg.FindAttribute("MODULE", SalString.Null);
                    sPostingType = msg.FindAttribute("POSTING_TYPE", SalString.Null);
                    sCodePart = msg.FindAttribute("CODE_PART", SalString.Null);
                    dPcValidFrom = msg.FindAttribute("PC_VALID_FROM", "").ToDate();
                    dValidFrom = msg.FindAttribute("VALID_FROM", "").ToDate();
                    sControlTypeValue = msg.FindAttribute("CONTROL_TYPE_VALUE", SalString.Null);
                    // Bug 75985, Begin
                    sControlType = msg.FindAttribute("CTRL_TYPE", SalString.Null);
                    sCodeName = msg.FindAttribute("CODE_NAME", SalString.Null);
                    sCtrlTypeCategoryDb = msg.FindAttribute("CTRL_TYPE_CATEGORY_DB", SalString.Null);
                    sNonPostingModule = msg.FindAttribute("NON_POST_MODULE", SalString.Null);
                    // Bug 75985, End
                    sWhere = "COMPANY = '" + i_sCompany + "'";
                    SalString sWhereChild = "";

                    if (sPostingType != SalString.Null)
                    {
                        sWhere = sWhere + " AND POSTING_TYPE = '" + sPostingType + "' ";
                        sWhereChild = " POSTING_TYPE = '" + sPostingType + "' ";
                    }
                    else
                    {
                        if (sModule != SalString.Null)
                        {
                            sWhere = sWhere + " AND POST_MODULE = '" + sModule + "' ";
                        }
                    }
                    if (sCodePart != SalString.Null)
                    {
                        sWhere = sWhere + " AND CODE_PART = '" + sCodePart + "' ";
                        sWhereChild = sWhereChild + " AND CODE_PART = '" + sCodePart + "' ";
                    }
                    if (sControlTypeValue != SalString.Null)
                    {
                        if (nTab == 1)
                        {
                            sWhereChild = sWhereChild + "AND CONTROL_TYPE_VALUE = '" + sControlTypeValue + "' ";
                        }
                        else
                        {
                            sWhere = sWhere + " AND CONTROL_TYPE_VALUE = '" + sControlTypeValue + "' ";
                        }
                    }
                    switch (nTab)
                    {
                        case 0:
                            tbwPostingCtrl tabWindowtPostingCtrl = tbwPostingCtrl.FromHandle(TabAttachedWindowHandleGet(nTab));
                            tabWindowtPostingCtrl.SetWhere(sWhere, dValidFrom, dPcValidFrom);
                            tabWindowtPostingCtrl.SetParentNavigator();
                            PopulateTabWindow(tabWindowtPostingCtrl.Name);
                            break;

                        case 1:
                            frmPostCtrlDet tabWindowPostCtrlDet = frmPostCtrlDet.FromHandle(TabAttachedWindowHandleGet(nTab));
                            tabWindowPostCtrlDet.SetWhere(sWhere, sWhereChild, dValidFrom, dPcValidFrom);
                            tabWindowPostCtrlDet.RecivePostingCtrlNavAttribs(sControlType, sNonPostingModule, sCodeName, sCtrlTypeCategoryDb);
                            PopulateTabWindow(tabWindowPostCtrlDet.Name);
                            break;

                        case 2:
                            frmPostCtrlDetSpec tabWindowPostCtrlDetSpec = frmPostCtrlDetSpec.FromHandle(TabAttachedWindowHandleGet(nTab));
                            tabWindowPostCtrlDetSpec.SetWhere(sWhere, dValidFrom, dPcValidFrom);
                            PopulateTabWindow(tabWindowPostCtrlDetSpec.Name);
                            break;

                        case 3:
                            frmPostingCtrlCombDet tabWindowPostingCtrlCombDet = frmPostingCtrlCombDet.FromHandle(TabAttachedWindowHandleGet(nTab));
                            tabWindowPostingCtrlCombDet.SetWhere(sWhere, dValidFrom, dPcValidFrom);
                            PopulateTabWindow(tabWindowPostingCtrlCombDet.Name);
                            break;

                        case 4:
                            frmPostingCtrlCombDetSpec tabWindowPostingCtrlCombDetSpec = frmPostingCtrlCombDetSpec.FromHandle(TabAttachedWindowHandleGet(nTab));
                            tabWindowPostingCtrlCombDetSpec.SetWhere(sWhere, dValidFrom, dPcValidFrom);
                            PopulateTabWindow(tabWindowPostingCtrlCombDetSpec.Name);
                            break;
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// Creates the URL for the cContainerTabFormWindow and force a populate of the Tab Window
        /// </summary>
        /// <param name="tabWindowName">Name of the attached window control</param>
        /// <returns></returns>
        public virtual void PopulateTabWindow(SalString tabWindowName)
        {
            // Create the URL for the cContainerTabFormWindow...
            fcURL url = new fcURL(this.DataSourceConstructBaseURL());
            // ... setting its Mark section to the tab window name ...
            url.SetMark(tabWindowName);
            // ... and forcing a populate.
            url.iParameters.SetAttribute(Ifs.Fnd.ApplicationForms.Const.UrlAttribute_Action, Ifs.Fnd.ApplicationForms.Const.UrlAction_Populate);
            url.Go();
 
        }

        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void frmPostCtrlNavigator_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmPostCtrlNavigator_OnPM_DataSourceSave(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmPostCtrlNavigator_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nMsgReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && this.nMsgReturn == 1)
            {
                this.tlbTree.TreeListNodeGet(this.nCurrentNode, this.msg);
                this.sModule = this.msg.FindAttribute("MODULE", "");
                this.sPostingType = this.msg.FindAttribute("POSTING_TYPE", "");
                this.sCodeName = this.msg.FindAttribute("CODE_NAME", "");
                this.sCodePart = this.msg.FindAttribute("CODE_PART", "");
                this.dPcValidFrom = this.msg.FindAttribute("PC_VALID_FROM", "").ToDate();
                this.sControlTypeValue = this.msg.FindAttribute("CONTROL_TYPE_VALUE", "");
                this.sCtrlTypeCategoryDb = this.msg.FindAttribute("CTRL_TYPE_CATEGORY_DB", "");
                this.tlbTree.TreeListNodeRefresh(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, this.nCurrentNode, false);
            }
            e.Return = this.nMsgReturn;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tlbTree_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_TreeListNodeExpand:
                    e.Handled = true;
                    this.TreeListNodeExpand(Sys.wParam, Sys.lParam);
                    break;

                case Sys.SAM_Click:
                    this.tlbTree_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tlbTree_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            // Tabs:
            // 0 - Posting Control
            // 1 - Posting Control Details
            // 2 - Posting Control Details Specification
            // 3 - Posting Control Combination Details
            // 4 - Posting Control Combination Details Specification
            Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
            if (this.nCurrentNode != this.tlbTree.hItem)
            {
                this.bSaveChanges = Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
                if (!(this.bSaveChanges))
                {
                    tlbTree.SetListSelectedIndex(tlbTree.GetItemIndex(nCurrentNode));
                    e.Return = true;
                    return;
                }

                this.nCurrentNode = this.tlbTree.hItem;
                this.tlbTree.TreeListNodeGet(this.tlbTree.hItem, this.msg);
                switch (this.tlbTree.TreeListNodeTypeFromItem(this.tlbTree.hItem))
                {
                    case 4:
                        this.sCtrlTypeCategoryDb = this.msg.FindAttribute("CTRL_TYPE_CATEGORY_DB", "");
                        if (this.sCtrlTypeCategoryDb != "COMBINATION")
                        {
                            this.RefreshTab(1);
                        }
                        else
                        {
                            this.RefreshTab(3);
                        }
                        break;

                    case 5:
                        this.RefreshTab(1);
                        break;

                    case 6:
                        this.sCtrlTypeCategoryDb = this.msg.FindAttribute("CTRL_TYPE_CATEGORY_DB", "");
                        if (this.sCtrlTypeCategoryDb != "COMBINATION")
                        {
                            this.RefreshTab(2);
                        }
                        else
                        {
                            this.RefreshTab(4);
                        }
                        break;

                    default:
                        this.RefreshTab(0);
                        break;
                }
            }
            #endregion
        }
        #endregion

    }
}
