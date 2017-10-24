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
// 120809  Kagalk  Bug 101446, Enabled to use Count Hits for Notes column
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
	public partial class cTableWindowCodePart : cTableWindowFin
	{
		#region Fields
		public SalString lsProjectCodePart = "";
		public SalString lsFixassCodePart = "";
		public SalBoolean bZoom = false;
		public SalNumber nCodeIndex = 0;
		public SalString i_sCode = "";
		public SalString sQualifier = "";
		public SalNumber __nItemIndexCompany = 0;
		public SalNumber __nRC = 0;
		public SalString __sTmp = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cTableWindowCodePart()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cTableWindowCodePart(ISalWindow derived)
		{
			// Attach derived instance.
			this._derived = derived;
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Attach actions handler to derived instance.
			this._derived.AttachMessageActions(this);
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Actions
			using (new SalContext(this))
			{
                this.GetChangedFinCompany(ref this.i_sCompany);
                this.vrtSetWindowTitle();
				return true;
			}
			#endregion
		}

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            #endregion

            LateBind lateBind = this._derived as LateBind;

            if (lateBind == null)
                return this.Activate(URL);
            else
                return lateBind.vrtActivate(URL);
        }

        public SalNumber Activate(fcURL URL)
        {
            SalBoolean bReturn;
            using (new SalContext(this))
            {
                //from sam_create
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeGet() == "ZOOM")
                {
                    this.bZoom = true;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[0] = i_sCode;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[1] = "COMPANY";
                    this.__nItemIndexCompany = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("VOUCHER_COMPANY");
                    if (this.__nItemIndexCompany >= 0)
                    {
                        this.__nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(this.__nItemIndexCompany, 0, ref this.__sTmp);
                    }
                    else
                    {
                        this.__nItemIndexCompany = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("COMPANY");
                        if (this.__nItemIndexCompany >= 0)
                        {
                            this.__nRC = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(this.__nItemIndexCompany, 0, ref this.__sTmp);
                        }
                    }
                    if (this.__sTmp != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        this.i_sCompany = this.__sTmp;
                        UserGlobalValueSet("COMPANY", this.i_sCompany);
                        Sal.SendMsgToChildren(this.i_hWndSelf, Ifs.Application.Accrul.Const.PAM_CallChanged, 0, 0);
                    }
                    else
                    {
                        this.UserGlobalValueGet("COMPANY", ref this.i_sCompany);
                    }
                    this.CheckCodePartFunction();
                    if (this.lsProjectCodePart == this.i_sCode.Right(1))
                    {
                        this.nCodeIndex = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet(this.i_sCode);
                        if (this.nCodeIndex == -1)
                        {
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[0] = "PROJECT_ID";
                        }
                        else
                        {
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[this.nCodeIndex] = "PROJECT_ID";
                        }
                        if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("tbwOverProjAcc")))
                        {
                            // Commented in Rising
                            // this.SessionCreateWindow("tbwOverProjAcc", Sys.hWndMDI);
                            // Sal.DestroyWindow(this.i_hWndFrame);    
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("CREATE_WINDOW");
                            SessionNavigate(Pal.GetActiveInstanceName("tbwOverProjAcc"), false);
                            return 1;            
                        }
                    }
                    if (this.lsFixassCodePart == this.i_sCode.Right(1))
                    {
                        // Bug 81950, Begin
						this.nCodeIndex = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet(this.i_sCode);
						if (this.nCodeIndex == -1) 
						{
							Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[0] = "OBJECT_ID";
						}
						else
						{
							Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[this.nCodeIndex] = "OBJECT_ID";
						}
						// Bug 81950, End
						if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("tbwObjectTab")))
                        {
                            // Commented in Rising
                            // this.SessionCreateWindow("tbwObjectTab", this.i_hWndParent);
                            // Sal.DestroyWindow(this.i_hWndFrame);   
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("CREATE_WINDOW");
                            SessionNavigate(Pal.GetActiveInstanceName("tbwObjectTab"),false);
                            return 1;            
                        }
                    }
                }
                //from framestartup
                if (bZoom)
                {
                    if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                    {
                        Sal.WaitCursor(true);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[0] = i_sCode;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[1] = "COMPANY";
                        if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemCountGet() > 2)
                        {
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[2] = "COMPANY";
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_hWndItems[2] = Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_hWndItems[1];
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sData[2] = Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sData[1];
                        }
                        // Bug 74262, Begin
                        if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sData[1] == SalString.Null)
                        {
                            UserGlobalValueGet("COMPANY", ref Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sData.GetArray(1)[1]);
                        }
                        // Bug 74262, End
                        InitFromTransferredData();
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                        Sal.WaitCursor(false);
                    }
				    // Bug ID 81950 - Begin.
				    if (lsFixassCodePart == i_sCode.Right(1)) 
				    {
					    if (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("tbwObjectTab")))) 
					    {
						    Ifs.Application.Accrul.Int.SetDataSourceReadOnly(i_hWndSelf);
					    }
				    }
                    this.SetWindowTitle();
                    return true;
				    // Bug ID 81950 - End.
                }
            }
            bReturn = base.Activate(URL);
            this.SetWindowTitle();
            return bReturn;
        }
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sMethod"></param>
		/// <returns></returns>
		public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
		{
			#region Local Variables
			SalString sName = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (sMethod == "CodestrCompl") 
				{
					return CodestrCompl(nWhat);
				}
				else if (sMethod == "Translation") 
				{
					return Translation(nWhat);
				}
				else if (sMethod == "ConnectAttribute") 
				{
					return ConnectAttribute(nWhat);
				}
				else if (sMethod == "FreeText") 
				{
					return FreeText(nWhat);
				}
				else if (sMethod == "ChangeCompany") 
				{
					return ChangeCompany(nWhat);
				}
				else
				{
					Sal.GetItemName(this, ref sName);
					Ifs.Fnd.ApplicationForms.Int.ErrorBox("DESIGN TIME ERROR for item " + sName + "\r\n" +
						"Function UserMethod handling method \"" + sMethod + "\" not written!");
					return 0;
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber CodestrCompl(SalNumber nWhat)
		{
			#region Local Variables
			SalArray<SalString> sItemNames = new SalArray<SalString>();
			SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) 
						{
							return 0;
						}
						if (!(Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0))) 
						{
							return 0;
						}
						return 1;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						Sal.WaitCursor(true);
						sItemNames[0] = "CODE_PART";
						hWndItems[0] = i_hWndChild[GetChildIndex("CODE_PART")];
						sItemNames[1] = "CODE_PART_VALUE";
						hWndItems[1] = i_hWndChild[GetChildIndex(i_sCode)];
						Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(p_sLogicalUnit, i_hWndFrame, sItemNames, hWndItems);
						SessionCreateWindow(Pal.GetActiveInstanceName("frmCdCompl"), Sys.hWndMDI);
						Sal.WaitCursor(false);
						return 1;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber Translation(SalNumber nWhat)
		{
			#region Local Variables
			SalNumber nRow = 0;
			SalString sModule = "";
			SalString sLu = "";
			SalString lsAttribute = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return !(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) && Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCompanyTranslation")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(
							Pal.GetActiveInstanceName("frmCompanyTranslation"));
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						Sal.WaitCursor(true);
						sModule = "ACCRUL";
						sLu = p_sLogicalUnit;
						lsAttribute = Ifs.Fnd.ApplicationForms.Const.strNULL;
						nRow = Sys.TBL_MinRow;
						while (true)
						{
							if (Sal.TblFindNextRow(i_hWndSelf, ref nRow, Sys.ROW_Selected, 0)) 
							{
								Sal.TblSetContext(i_hWndSelf, nRow);
								lsAttribute = lsAttribute + "'" + SalString.FromHandle(Sal.SendMsg(i_hWndChild[GetChildIndex(i_sCode)], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0)) + "'" + ",";
							}
							else
							{
								break;
							}
						}
						if (lsAttribute != Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							lsAttribute = lsAttribute.Left(lsAttribute.Length - 1);
						}
						Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_COMPANY", i_sCompany);
						Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_MODULE", sModule);
						Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_LU", sLu);
						Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_ATTRIBUTE", lsAttribute);
						SessionCreateWindow(Pal.GetActiveInstanceName("frmCompanyTranslation"), Sys.hWndMDI);
						Sal.WaitCursor(false);
						return 1;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber ConnectAttribute(SalNumber nWhat)
		{
			#region Local Variables
			SalArray<SalString> sItemNames = new SalArray<SalString>();
			SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) 
						{
							return 0;
						}
						// Bug 79351, Begin. Added IsDataSourceAvailable()
						if (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("tbwAttributeCon")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("tbwAttributeCon")))) 
						{
							return 0;
						}
						// Bug 79351, End
						if (!(Sal.TblAnyRows(i_hWndFrame, Sys.ROW_Selected, 0))) 
						{
							return 0;
						}
						return 1;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						Sal.WaitCursor(true);
						sItemNames[0] = "COMPANY";
						hWndItems[0] = i_hWndChild[GetChildIndex("COMPANY")];
						sItemNames[1] = "CODE_PART";
						hWndItems[1] = i_hWndChild[GetChildIndex("CODE_PART")];
						sItemNames[2] = "CODE_PART_VALUE";
						hWndItems[2] = i_hWndChild[GetChildIndex(i_sCode)];

						Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(p_sLogicalUnit, i_hWndFrame, sItemNames, hWndItems);
						SessionNavigate(Pal.GetActiveInstanceName("tbwAttributeCon"));
						Sal.WaitCursor(false);
						return 1;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber FreeText(SalNumber nWhat)
		{
			#region Local Variables
			SalNumber nRow = 0;
			SalString lsTemp = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						nRow = Sys.TBL_MinRow;
						if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0)) 
						{
							if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0)) 
							{
								return 0;
							}
							return 1;
						}
						return 0;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:

						Sal.WaitCursor(false);
						lsTemp = SalString.FromHandle(Sal.SendMsg(i_hWndChild[GetChildIndex("TEXT")], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0));
						if (dlgEditor.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, ref lsTemp, i_hWndChild[GetChildIndex("TEXT")], 1) == Sys.IDOK) 
						{
							Sal.SendMsg(i_hWndChild[GetChildIndex("TEXT")], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, lsTemp.ToHandle());
							if (SalString.FromHandle(Sal.SendMsg(i_hWndChild[GetChildIndex("TEXT")], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0)) != Ifs.Fnd.ApplicationForms.Const.strNULL) 
							{
								Sal.SendMsg(i_hWndChild[GetChildIndex("CB_TEXT")], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 0, ((SalString)"TRUE").ToHandle());
							}
							else
							{
								Sal.SendMsg(i_hWndChild[GetChildIndex("CB_TEXT")], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 0, ((SalString)"FALSE").ToHandle());
							}
						}
						return 1;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="p_nWhat"></param>
		/// <returns></returns>
		public virtual new SalNumber ChangeCompany(SalNumber p_nWhat)
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (p_nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
                    if (this.GetParent() == (SalWindowHandle)Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm)
                    {
                        return Sal.SendClassMessage(Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    }
                    else
                    {
                        bOk = Sal.SendMsg(this.GetParent(), Ifs.Application.Accrul.Const.PAM_ChangeCompany, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        Sal.TblSetFocusRow(i_hWndFrame, 0);
                        return bOk;
                    }
				}
				else
				{
					return !(bZoom) && !(Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0));
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CheckCodePartFunction()
		{
			#region Local Variables
			// Bug 69315, Begin
			SalString sCompany = "";
			// Bug 69315, End
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				// Bug 69315, Begin
				UserGlobalValueGet("COMPANY", ref sCompany);
				RefreshCodePartInfo(sCompany, cSessionManager.c_sDbPrefix);
				// Bug 69315, End
				lsProjectCodePart = GetCodePartFunction("PRACC");
				lsFixassCodePart = GetCodePartFunction("FAACC");
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// This Function returns the index of the child given by parameter sColumn
		/// </summary>
		/// <param name="sColumn"></param>
		/// <returns></returns>
		public virtual SalNumber GetChildIndex(SalString sColumn)
		{
			#region Local Variables
			SalNumber nIndex = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				nIndex = 0;
				while (nIndex <= i_nChildCount) 
				{
					if (cColumn.FromHandle(i_hWndChild[nIndex]).p_sSqlColumn == sColumn) 
					{
						return nIndex;
					}
					nIndex = nIndex + 1;
				}
				return nIndex;
			}
			#endregion
		}
		
		/// <summary>
		/// Get default values for new row
		/// </summary>
		/// <returns></returns>
		public new SalBoolean DataRecordPrepareNew()
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				bOk = ((cTableWindow)this).DataRecordPrepareNew();
				// Bug 71269, Removed the codes that automatically set the value of 'CONS_CODE_PART' as the the value of 'CODE_PART' when 'CONS_CODE_PART' is Null
				return bOk;
			}
			#endregion
		}
		// ! ! ! ! Override DataRecordNew and DataRecordRemove as a workaround for a bug in IFS/Client
		//   (new records can't be added to or removed from tablewindows on tabs in cContainerTabFormWindows)
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public new SalNumber DataRecordNew(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					return ((bool)(p_nSourceFlags & Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationNew)) && ((bool)(p_nSourceFlags & Ifs.Fnd.ApplicationForms.Const.SOURCE_Update));
				}
				else
				{
					return ((cTableWindow)this).DataRecordNew(nWhat);
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public new SalNumber DataRecordRemove(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					return ((bool)(p_nSourceFlags & Ifs.Fnd.ApplicationForms.Const.SOURCE_OperationRemove)) && ((bool)(p_nSourceFlags & Ifs.Fnd.ApplicationForms.Const.SOURCE_Update));
				}
				else
				{
					return ((cTableWindow)this).DataRecordRemove(nWhat);
				}
			}
			#endregion
		}

        /// <summary>
        /// Format Where Clause for Notes
        /// </summary>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public virtual SalString FormatWhereClause(SalNumber wParam, SalNumber lParam)
        {
            #region Local Variables
            SalString sWhere = "";
            SalString sFormattedWhere = "";
            SalNumber nOffset = 0;
            // Bug 101446, begin
            SalNumber nEnd = 0;
            SalNumber nLength = 0;
            SalString sStmt = "";
            SalString sModifiedStmt = "";
            // Bug 101446, end            
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sWhere = SalString.FromHandle(lParam);
                // Bug 101446, begin
                sStmt = "CB_TEXT = :_gBs@TRUE";
                nOffset = sWhere.Scan(sStmt);
                if (nOffset != -1)
                {
                    sModifiedStmt = "TEXT IS NOT NULL";
                }
                else
                {
                    sStmt = "CB_TEXT = :_gBs@FALSE";
                    nOffset = sWhere.Scan(sStmt);
                    if (nOffset != -1)
                    {
                        sModifiedStmt = "TEXT IS NULL";
                    }                    
                    else
                    {
                        sStmt = "upper( CB_TEXT ) = upper( :_gBs@TRUE )";
                        nOffset = sWhere.Scan(sStmt);
                        if (nOffset != -1)
                        {
                            sModifiedStmt = "TEXT IS NOT NULL";
                        }
                        else
                        {
                            sStmt = "upper( CB_TEXT ) = upper( :_gBs@FALSE )";
                            nOffset = sWhere.Scan(sStmt);
                            if (nOffset != -1)
                            {
                                sModifiedStmt = "TEXT IS NULL";
                            }
                        }
                    }
                }
                if (nOffset != -1)
                {
                    nLength = sStmt.Length;
                    sFormattedWhere = sWhere.Left(nOffset) + sModifiedStmt + sWhere.Right(sWhere.Length - (nOffset + nLength));
                    return sFormattedWhere;
                }
                // Bug 101446, end
                return sWhere;
            }

            return "";
            #endregion

        }

        /// <summary>
        /// Format Order By Clause for Notes
        /// </summary>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public virtual SalString FormatOrderByClause(SalNumber wParam, SalNumber lParam)
        {
            #region Local Variables
            SalString sOrderBy = "";
            SalString sFormattedOrderBy = "";
            SalNumber nOffset = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sOrderBy = SalString.FromHandle(lParam);
                nOffset = sOrderBy.Scan("CB_TEXT DESC");
                if (nOffset != -1)
                {
                    sFormattedOrderBy = sOrderBy.Replace(nOffset, 12, "TEXT");
                    return sFormattedOrderBy;
                }
                else
                {
                    nOffset = sOrderBy.Scan("CB_TEXT");
                    if (nOffset != -1)
                    {
                        sFormattedOrderBy = sOrderBy.Replace(nOffset, 7, "TEXT DESC");
                        return sFormattedOrderBy;
                    }
                }
                return sOrderBy;
            }

            return "";
            #endregion
        }
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cTableWindowCodePart_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.cTableWindowCodePart_OnSAM_Create(sender, e);
					break;
				
				case Sys.SAM_FetchRowDone:
					this.cTableWindowCodePart_OnSAM_FetchRowDone(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
					this.cTableWindowCodePart_OnPM_DataSourceSave(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
					this.cTableWindowCodePart_OnPM_DataSourceQueryFieldName(sender, e);
					break;
				
				case Ifs.Application.Accrul.Const.PAM_ShowInternalCP:
					e.Handled = true;
					e.Return = true;
					return;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere:
                    this.cTableWindowCodePart_OnPM_DataSourceUserWhere(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserOrderBy:
                    this.cTableWindowCodePart_OnPM_DataSourceUserOrderBy(sender, e);
                    break;
                // Bug 101446, begin
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceHitCount:
                    this.cTableWindowCodePart_OnPM_DataSourceHitCount(sender, e);
                    break;
                // Bug 101446, end

			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cTableWindowCodePart_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam)) 
			{
				this.sQualifier = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this.i_hWndSelf);
                if (this.GetParent() != (SalWindowHandle)Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm)
                {
                    Sal.TBarSetVisible(this, false);
                }
				e.Return = true;
				return;
			}
			e.Return = false;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_FetchRowDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cTableWindowCodePart_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam)) 
			{
				if (SalString.FromHandle(Sal.SendMsg(this.i_hWndChild[this.GetChildIndex("TEXT")], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0)) != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.SendMsg(this.i_hWndChild[this.GetChildIndex("CB_TEXT")], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 0, ((SalString)"TRUE").ToHandle());
				}
				// Bug 71269, Removed the codes that automatically set the value of 'CONS_CODE_PART' as the the value of 'CODE_PART' when 'CONS_CODE_PART' is Null
				Sal.SendMsg(this.i_hWndChild[this.GetChildIndex("CODE_PART")], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 0, this.i_sCode.Right(1).ToHandle());
				e.Return = true;
				return;
			}
			e.Return = false;
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourceSave event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cTableWindowCodePart_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				if ((this.i_nDataSourceState == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Changed) || (this.i_nDataSourceState == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_DetailChanged)) 
				{
					e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
					return;
				}
				e.Return = false;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourceQueryFieldName event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cTableWindowCodePart_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (SalString.FromHandle(Sys.lParam) == "CONS_CODE_PART") 
			{
				switch (Sys.wParam)
				{
					case Vis.DT_Handle:
						e.Return = SalWindowHandle.Null.ToNumber();
						return;
					
					default:
						// Bug 71269, Begin
						// Control must never reach this point because when lParam = 'CONS_CODE_PART' and wParam != DT_Handle,
						// the class object must handle the situtation. It must return 'N' if parent code part is NULL. (see tbwCodeB)
						e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName, Sys.wParam, Sys.lParam);
						return;
						// Bug 71269 End
						break;
				}
			}
			else
			{
				e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName, Sys.wParam, Sys.lParam);
				return;
			}
			#endregion
		}

        /// <summary>
        /// PM_DataSourceUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cTableWindowCodePart_OnPM_DataSourceUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            SalString sFormattedWhere = this.FormatWhereClause(Sys.wParam, Sys.lParam);
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Sys.wParam, sFormattedWhere.ToHandle());
            #endregion
        }

        /// <summary>
        /// PM_DataSourceUserOrderBy event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cTableWindowCodePart_OnPM_DataSourceUserOrderBy(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            SalString sFormattedOrderBy = this.FormatOrderByClause(Sys.wParam, Sys.lParam);
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserOrderBy, Sys.wParam, sFormattedOrderBy.ToHandle());
            #endregion
        }

        // Bug 101446, begin
		/// <summary>
		/// PM_DataSourceHitCount event handler.
		/// </summary>
		/// <param name="message"></param>
        private void cTableWindowCodePart_OnPM_DataSourceHitCount(object sender, WindowActionsEventArgs e)
		{
			#region Actions
            e.Handled = true;
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceHitCount, Sys.wParam, this.FormatWhereClause(Sys.wParam, Sys.lParam).ToHandle());
            return;
			#endregion
		}
        // Bug 101446, end
		#endregion

		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowCodePart to type cTableManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cTableManager(cTableWindowCodePart self)
		{
			return self._cTableManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowCodePart to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cTableWindowCodePart self)
		{
			return ((cSessionManager)self._cTableManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowCodePart to type cWindowTranslation.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cWindowTranslation(cTableWindowCodePart self)
		{
			return ((cWindowTranslation)self._cTableManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowCodePart to type SalToolTipManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator SalToolTipManager(cTableWindowCodePart self)
		{
			return self._SalToolTipManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowCodePart to type cFinlibServices.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cFinlibServices(cTableWindowCodePart self)
		{
			return self._cFinlibServices;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableManager to type cTableWindowCodePart.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowCodePart(cTableManager super)
		{
			return ((cTableWindowCodePart)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cTableWindowCodePart.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowCodePart(cSessionManager super)
		{
			return ((cTableWindowCodePart)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cWindowTranslation to type cTableWindowCodePart.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowCodePart(cWindowTranslation super)
		{
			return ((cTableWindowCodePart)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type SalToolTipManager to type cTableWindowCodePart.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowCodePart(SalToolTipManager super)
		{
			return ((cTableWindowCodePart)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cFinlibServices to type cTableWindowCodePart.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowCodePart(cFinlibServices super)
		{
			return ((cTableWindowCodePart)super._derived);
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cTableWindowCodePart FromHandle(SalWindowHandle handle)
		{
			return ((cTableWindowCodePart)SalWindow.FromHandle(handle, typeof(cTableWindowCodePart)));
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtDataRecordNew(SalNumber nWhat)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.DataRecordNew(nWhat);
			}
			else
			{
				return lateBind.vrtDataRecordNew(nWhat);
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtDataRecordPrepareNew()
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.DataRecordPrepareNew();
			}
			else
			{
				return lateBind.vrtDataRecordPrepareNew();
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtDataRecordRemove(SalNumber nWhat)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.DataRecordRemove(nWhat);
			}
			else
			{
				return lateBind.vrtDataRecordRemove(nWhat);
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtFrameStartupUser()
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.FrameStartupUser();
			}
			else
			{
				return lateBind.vrtFrameStartupUser();
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.UserMethod(nWhat, sMethod);
			}
			else
			{
				return lateBind.vrtUserMethod(nWhat, sMethod);
			}
		}
		#endregion
		
		#region Multiple Inheritance Late Bind Interface
		
		public interface LateBind
		{
			SalNumber vrtDataRecordNew(SalNumber nWhat);
			SalBoolean vrtDataRecordPrepareNew();
			SalNumber vrtDataRecordRemove(SalNumber nWhat);
			SalBoolean vrtFrameStartupUser();
			SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod);
            SalNumber vrtActivate(fcURL URL);
		}
		#endregion
	}
}
