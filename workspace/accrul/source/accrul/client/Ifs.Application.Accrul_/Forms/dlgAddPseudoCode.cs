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
	public partial class dlgAddPseudoCode : cDialogBoxFin
	{
		#region Window Variables
		public SalWindowHandle hLastWithFocus = SalWindowHandle.Null;
		public SalString sCompany = "";
		public SalString sAccount = "";
		public SalString sCodeB = "";
		public SalString sCodeC = "";
		public SalString sCodeD = "";
		public SalString sCodeE = "";
		public SalString sCodeF = "";
		public SalString sCodeG = "";
		public SalString sCodeH = "";
		public SalString sCodeI = "";
		public SalString sCodeJ = "";
		public SalString sProcessCode = "";
		public SalNumber nQuantity = 0;
        private SalString sProjectActivityId = "";
        public SalString sParam = "";
        private SalString sProjectOrigin = "";
        public SalString sIsProjectCodePart = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgAddPseudoCode()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Shows the modal dialog.
		/// </summary>
		/// <param name="owner"></param>
		/// <returns></returns>
		public static SalNumber ModalDialog(Control owner)
		{
			dlgAddPseudoCode dlg = DialogFactory.CreateInstance<dlgAddPseudoCode>();
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgAddPseudoCode FromHandle(SalWindowHandle handle)
		{
			return ((dlgAddPseudoCode)SalWindow.FromHandle(handle, typeof(dlgAddPseudoCode)));
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
				this.HideUnusedCodeParts();
                sIsProjectCodePart = GetCodePartFunction("PRACC");
				Sal.SendMsg(tblCurrPseudoCode, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
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
				if (sMethod == "OK") 
				{
					return UM_Ok(nWhat);
				}
				else if (sMethod == "Cancel") 
				{
					return UM_Cancel(nWhat);
				}
				else if (sMethod == "Save") 
				{
					return UM_Save(nWhat);
				}
				else if (sMethod == "List") 
				{
					return UM_List(nWhat);
				}
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalString GetWindowTitle()
		{
			#region Actions
			using (new SalContext(this))
			{
				return Properties.Resources.WH_tbwPseudoCode;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber RefreshButtonsState()
		{
			#region Actions
			using (new SalContext(this))
			{
				pbOK.MethodInvestigateState();
				pbCancel.MethodInvestigateState();
				pbSave.MethodInvestigateState();
				pbList.MethodInvestigateState();
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Ok(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (Sal.SendMsg(tblCurrPseudoCode, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) 
						{
							switch (DataSourceInquireSave())
							{
								case Sys.IDCANCEL:
									return false;
								
								case Sys.IDYES:
									if (Sal.SendMsg(tblCurrPseudoCode, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0)) 
									{
										return Sal.EndDialog(this, 1);
									}
									return false;
								
								case Sys.IDNO:
									if (Sal.IsNull(tblCurrPseudoCode_colsPseudoCode)) 
									{
										Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_PseudoCode, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
										return false;
									}
									return Sal.EndDialog(this, 1);
							}
						}
						return Sal.EndDialog(this, 1);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Cancel(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						return Sal.EndDialog(this, 0);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Save(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (Sal.SendMsg(tblCurrPseudoCode, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0)) 
						{
							Ifs.Fnd.ApplicationForms.Var.bReturn = true;
							return true;
						}
						return false;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_List(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return Sal.SendMsg(hLastWithFocus, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						Sal.SendMsg(hLastWithFocus, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
						Sal.TblSetFocusCell(tblCurrPseudoCode, Sal.TblQueryContext(tblCurrPseudoCode), hLastWithFocus, 0, 0);
						Sal.SendMsg(hLastWithFocus, Sys.SAM_Validate, 0, 0);
						break;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber ReceiveData()
		{
			#region Local Variables
			SalNumber nNoOfItems = 0;
			SalNumber nCurrentPos = 0;
			SalNumber nUpperBound = 0;
			SalString sWindowParameters = "";
			SalString sRS = "";
			SalString sUS = "";
			SalArray<SalString> Attr = new SalArray<SalString>();
			SalArray<SalString> sTheParameter = new SalArray<SalString>();
			SalArray<SalString> sParameterArray = new SalArray<SalString>();
			SalNumber nSubTokens = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				nNoOfItems = Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet();
				if (nNoOfItems > 0) 
				{
					Attr.SetBounds(0, -1);
					sRS = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
					sUS = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter();
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("AddPseudoCode"), 0, ref sWindowParameters);
					sWindowParameters.Tokenize(sRS, sRS, sParameterArray);
					nCurrentPos = 0;
					nUpperBound = sParameterArray.GetUpperBound(1);
					while (nCurrentPos <= nUpperBound) 
					{
						nSubTokens = sParameterArray[nCurrentPos].Tokenize("", sRS + sUS, sTheParameter);
						if (nSubTokens < 2) 
						{
							sTheParameter[1] = "";
						}
						if (sTheParameter[0] == "COMPANY") 
						{
							sCompany = sTheParameter[1];
						}
						else if (sTheParameter[0] == "ACCOUNT") 
						{
							sAccount = sTheParameter[1];
						}
						else if (sTheParameter[0] == "CODE_B") 
						{
							sCodeB = sTheParameter[1];
						}
						else if (sTheParameter[0] == "CODE_C") 
						{
							sCodeC = sTheParameter[1];
						}
						else if (sTheParameter[0] == "CODE_D") 
						{
							sCodeD = sTheParameter[1];
						}
						else if (sTheParameter[0] == "CODE_E") 
						{
							sCodeE = sTheParameter[1];
						}
						else if (sTheParameter[0] == "CODE_F") 
						{
							sCodeF = sTheParameter[1];
						}
						else if (sTheParameter[0] == "CODE_G") 
						{
							sCodeG = sTheParameter[1];
						}
						else if (sTheParameter[0] == "CODE_H") 
						{
							sCodeH = sTheParameter[1];
						}
						else if (sTheParameter[0] == "CODE_I") 
						{
							sCodeI = sTheParameter[1];
						}
						else if (sTheParameter[0] == "CODE_J") 
						{
							sCodeJ = sTheParameter[1];
						}
						else if (sTheParameter[0] == "PROCESS_CODE") 
						{
							sProcessCode = sTheParameter[1];
						}
						else if (sTheParameter[0] == "QUANTITY") 
						{
							if (sTheParameter[1] == SalString.Null) 
							{
								nQuantity = SalNumber.Null;
							}
							else
							{
								nQuantity = sTheParameter[1].ToNumber();
							}
						}
                        else if (sTheParameter[0] == "PROJECT_ACTIVITY_ID")
                        {
                            sProjectActivityId = sTheParameter[1];
                        }
						nCurrentPos = nCurrentPos + 1;
					}
				}
				Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
			}

			return 0;
			#endregion
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dlgAddPseudoCode_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_CreateComplete:
					this.dlgAddPseudoCode_OnSAM_CreateComplete(sender, e);
					break;
				
				case Sys.SAM_Create:
					this.dlgAddPseudoCode_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_CreateComplete event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgAddPseudoCode_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.i_sCompany = this.sCompany;
			Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgAddPseudoCode_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			Sal.CenterWindow(this.i_hWndFrame);
			this.ReceiveData();
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
		public override SalString vrtGetWindowTitle()
		{
			return this.GetWindowTitle();
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
		{
			return this.UserMethod(nWhat, sMethod);
		}
		#endregion
		
		#region ChildTable-ChildTAbletblCurrPseudoCode

		#region Window Variables
		public SalString sFndUserId = "";
		public SalString sCodePartUsed = "";
		public cSessionManager dbConnection = new cSessionManager();
		public SalArray<SalString> lsDisplayCodePart = new SalArray<SalString>();
		public SalNumber nCodePartNameCount = 0;
		public SalString sNotAllowed = "";
		#endregion
					
		#region Methods
			
		/// <summary>
		/// The framework calls the DataRecordGetDefaults function to retrive
		/// client default values for new records.
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean DataRecordGetDefaults()
		{
			tblCurrPseudoCode_colsCompany.Text = this.sCompany;
			tblCurrPseudoCode_colsAccount.Text = this.sAccount;
			tblCurrPseudoCode_colsCodeB.Text = this.sCodeB;
			tblCurrPseudoCode_colsCodeC.Text = this.sCodeC;
			tblCurrPseudoCode_colsCodeD.Text = this.sCodeD;
			tblCurrPseudoCode_colsCodeE.Text = this.sCodeE;
			tblCurrPseudoCode_colsCodeF.Text = this.sCodeF;
			tblCurrPseudoCode_colsCodeG.Text = this.sCodeG;
			tblCurrPseudoCode_colsCodeH.Text = this.sCodeH;
			tblCurrPseudoCode_colsCodeI.Text = this.sCodeI;
			tblCurrPseudoCode_colsCodeJ.Text = this.sCodeJ;
			tblCurrPseudoCode_colsProcessCode.Text = this.sProcessCode;
			tblCurrPseudoCode_colnQuantity.Number = this.nQuantity;

            if (sProjectActivityId != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                tblCurrPseudoCode_colnProjectActivityId.Number = this.sProjectActivityId.ToNumber();
                tblCurrPseudoCode_colnProjectActivityId.EditDataItemSetEdited();
            }

			tblCurrPseudoCode_colsCompany.EditDataItemSetEdited();
			tblCurrPseudoCode_colsUserId.EditDataItemSetEdited();
			tblCurrPseudoCode_colsAccount.EditDataItemSetEdited();
			tblCurrPseudoCode_colsCodeB.EditDataItemSetEdited();
			tblCurrPseudoCode_colsCodeC.EditDataItemSetEdited();
			tblCurrPseudoCode_colsCodeD.EditDataItemSetEdited();
			tblCurrPseudoCode_colsCodeE.EditDataItemSetEdited();
			tblCurrPseudoCode_colsCodeF.EditDataItemSetEdited();
			tblCurrPseudoCode_colsCodeG.EditDataItemSetEdited();
			tblCurrPseudoCode_colsCodeH.EditDataItemSetEdited();
			tblCurrPseudoCode_colsCodeI.EditDataItemSetEdited();
			tblCurrPseudoCode_colsCodeJ.EditDataItemSetEdited();
			tblCurrPseudoCode_colsProcessCode.EditDataItemSetEdited();
			tblCurrPseudoCode_colnQuantity.EditDataItemSetEdited();
            tblCurrPseudoCode_colsPseudoCodeOwnership.EditDataItemSetEdited();
			return true;
		}
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber HideUnusedCodeParts()
		{
		
			SalNumber nInd = 0;
	

			if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("Accounting_Code_Parts"))) 
			{
				return false;
			}
			string sSql =string.Format( @"SELECT code_part_used_db FROM &AO.ACCOUNTING_CODE_PARTS
				                            INTO {0}
				 	                        WHERE company = {1} 
                                            ORDER BY code_part",
                                            this.QualifiedVarBindName("sCodePartUsed"),
                                            this.QualifiedVarBindName("i_sCompany"));

			if (DbPrepareAndExecute(sSql)) 
			{
				nCodePartNameCount = 0;
				while (DbFetchNext(cSessionManager.c_hSql, ref nInd)) 
				{
					lsDisplayCodePart[nCodePartNameCount] = sCodePartUsed;
					nCodePartNameCount = 1 + nCodePartNameCount;
				}
				if (lsDisplayCodePart[1] == "N") 
				{
					Sal.HideWindowAndLabel(tblCurrPseudoCode_colsCodeB);
				}
				else
				{
					Sal.ShowWindowAndLabel(tblCurrPseudoCode_colsCodeB);
				}
				if (lsDisplayCodePart[2] == "N") 
				{
					Sal.HideWindowAndLabel(tblCurrPseudoCode_colsCodeC);
				}
				else
				{
					Sal.ShowWindowAndLabel(tblCurrPseudoCode_colsCodeC);
				}
				if (lsDisplayCodePart[3] == "N") 
				{
					Sal.HideWindowAndLabel(tblCurrPseudoCode_colsCodeD);
				}
				else
				{
					Sal.ShowWindowAndLabel(tblCurrPseudoCode_colsCodeD);
				}
				if (lsDisplayCodePart[4] == "N") 
				{
					Sal.HideWindowAndLabel(tblCurrPseudoCode_colsCodeE);
				}
				else
				{
					Sal.ShowWindowAndLabel(tblCurrPseudoCode_colsCodeE);
				}
				if (lsDisplayCodePart[5] == "N") 
				{
					Sal.HideWindowAndLabel(tblCurrPseudoCode_colsCodeF);
				}
				else
				{
					Sal.ShowWindowAndLabel(tblCurrPseudoCode_colsCodeF);
				}
				if (lsDisplayCodePart[6] == "N") 
				{
					Sal.HideWindowAndLabel(tblCurrPseudoCode_colsCodeG);
				}
				else
				{
					Sal.ShowWindowAndLabel(tblCurrPseudoCode_colsCodeG);
				}
				if (lsDisplayCodePart[7] == "N") 
				{
					Sal.HideWindowAndLabel(tblCurrPseudoCode_colsCodeH);
				}
				else
				{
					Sal.ShowWindowAndLabel(tblCurrPseudoCode_colsCodeH);
				}
				if (lsDisplayCodePart[8] == "N") 
				{
					Sal.HideWindowAndLabel(tblCurrPseudoCode_colsCodeI);
				}
				else
				{
					Sal.ShowWindowAndLabel(tblCurrPseudoCode_colsCodeI);
				}
				if (lsDisplayCodePart[9] == "N") 
				{
					Sal.HideWindowAndLabel(tblCurrPseudoCode_colsCodeJ);
				}
				else
				{
					Sal.ShowWindowAndLabel(tblCurrPseudoCode_colsCodeJ);
				}
			}
			return 0;

		}

        protected virtual SalBoolean EnableDisableProjectActivityId(SalString sCodePartValue)
        {
            #region Actions
            using (new SalContext(this))
            {
                sParam = sCodePartValue;
                if (sParam != SalString.Null)
                {
                    if (Ifs.Application.Accrul.Int.IsGenLedInstalled && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Project_Api.Get_Externally_Created"))
                    {
                        if (!(DbPLSQLBlock(@"{0}:= &AO.Accounting_Project_Api.Get_Externally_Created( {1} IN, {2} IN ) ;",
                                        this.tblCurrPseudoCode_colsProjectActivityIdEnabled.QualifiedBindName,
                                        this.QualifiedVarBindName("i_sCompany"),
                                        this.QualifiedVarBindName("sParam"))))
                        {
                            return false;
                        }

                    }
                    else
                    {
                        tblCurrPseudoCode_colsProjectActivityIdEnabled.Text = "Y";
                    }

                    if (Ifs.Application.Accrul.Int.IsGenLedInstalled && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("ACCOUNTING_PROJECT_API.Get_Project_Origin_Db"))
                    {
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            if (!(DbPLSQLBlock(@"{0} := &AO.ACCOUNTING_PROJECT_API.Get_Project_Origin_Db( {1} IN, {2} IN ) ;",
                                 this.QualifiedVarBindName("sProjectOrigin"),
                                 this.tblCurrPseudoCode_colsCompany.QualifiedBindName,
                                 this.QualifiedVarBindName("sParam"))))
                            {
                                return false;
                            }
                        }
                    }

                    if (sProjectOrigin == "JOB")
                    {
                        tblCurrPseudoCode_colsProjectActivityIdEnabled.Text = "N";
                        tblCurrPseudoCode_colnProjectActivityId.Number = 0;
                    }
                    else if (sProjectOrigin == "FINPROJECT")
                    {
                        tblCurrPseudoCode_colsProjectActivityIdEnabled.Text = "N";
                        tblCurrPseudoCode_colnProjectActivityId.Number = Sys.NUMBER_Null;
                    }
                    else
                    {

                        if (tblCurrPseudoCode_colsProjectActivityIdEnabled.Text == "Y")
                        {
                            SetValueOfProjectID();
                        }
                        else
                        {
                            tblCurrPseudoCode_colnProjectActivityId.Number = Sys.NUMBER_Null;
                        }
                    }
                }

                tblCurrPseudoCode_colnProjectActivityId.EditDataItemSetEdited();
                return true;

            }
            #endregion
        }

        public virtual SalNumber EnableSeqId()
        {
            SalString sProjectCodePart = Ifs.Application.Accrul.Var.FinlibServices.GetCodePartFunction("PRACC");
            if (sProjectCodePart == "B")
            {
                if (tblCurrPseudoCode_colsCodeB.Text != Sys.STRING_Null)
                {
                    if (tblCurrPseudoCode_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblCurrPseudoCode_colsCodeB.Text);
                    }
                }
            }
            if (sProjectCodePart == "C")
            {
                if (tblCurrPseudoCode_colsCodeC.Text != Sys.STRING_Null)
                {
                    if (tblCurrPseudoCode_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblCurrPseudoCode_colsCodeC.Text);
                    }
                }
            }
            if (sProjectCodePart == "D")
            {
                if (tblCurrPseudoCode_colsCodeD.Text != Sys.STRING_Null)
                {
                    if (tblCurrPseudoCode_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblCurrPseudoCode_colsCodeD.Text);
                    }
                }
            }
            if (sProjectCodePart == "E")
            {
                if (tblCurrPseudoCode_colsCodeE.Text != Sys.STRING_Null)
                {
                    if (tblCurrPseudoCode_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblCurrPseudoCode_colsCodeE.Text);
                    }
                }
            }
            if (sProjectCodePart == "F")
            {
                if (tblCurrPseudoCode_colsCodeF.Text != Sys.STRING_Null)
                {
                    if (tblCurrPseudoCode_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblCurrPseudoCode_colsCodeF.Text);
                    }
                }
            }
            if (sProjectCodePart == "G")
            {
                if (tblCurrPseudoCode_colsCodeG.Text != Sys.STRING_Null)
                {
                    if (tblCurrPseudoCode_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblCurrPseudoCode_colsCodeG.Text);
                    }
                }
            }
            if (sProjectCodePart == "H")
            {
                if (tblCurrPseudoCode_colsCodeH.Text != Sys.STRING_Null)
                {
                    if (tblCurrPseudoCode_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblCurrPseudoCode_colsCodeH.Text);
                    }
                }
            }
            if (sProjectCodePart == "I")
            {
                if (tblCurrPseudoCode_colsCodeI.Text != Sys.STRING_Null)
                {
                    if (tblCurrPseudoCode_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblCurrPseudoCode_colsCodeI.Text);
                    }
                }
            }
            if (sProjectCodePart == "J")
            {
                if (tblCurrPseudoCode_colsCodeJ.Text != Sys.STRING_Null)
                {
                    if (tblCurrPseudoCode_colsProjectActivityIdEnabled.Text == Sys.STRING_Null)
                    {
                        EnableDisableProjectActivityId(tblCurrPseudoCode_colsCodeJ.Text);
                    }
                }
            }
            return 0;
        }

        public virtual SalNumber SetValueOfProjectID()
        {
            SalNumber nChildCount = 0;
            while (nChildCount < tblCurrPseudoCode.i_nChildCount)
            {
                if (tblCurrPseudoCode.i_nChildType[nChildCount] & Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_DataItem)
                {
                    if ((Sal.WindowClassName(tblCurrPseudoCode.i_hWndChild[nChildCount]) == "cColumnCodePartFin") && (cColumn.FromHandle(tblCurrPseudoCode.i_hWndChild[nChildCount]).p_sSqlColumn == "CODE_" + this.sIsProjectCodePart))
                    {
                        tblCurrPseudoCode_colsProjectId.Text = SalString.FromHandle(Sal.SendMsg(tblCurrPseudoCode.i_hWndChild[nChildCount], Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0));
                        break;
                    }
                }
                nChildCount = nChildCount + 1;
            }
            return 0;
        }
		#endregion
			
		#region Window Actions
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCurrPseudoCode_colsPseudoCode_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblCurrPseudoCode_colsPseudoCode_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsPseudoCode_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblCurrPseudoCode_colsPseudoCode;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCurrPseudoCode_colsDescription_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblCurrPseudoCode_colsDescription_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsDescription_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblCurrPseudoCode_colsPseudoCode;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCurrPseudoCode_colsAccount_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblCurrPseudoCode_colsAccount_OnSAM_SetFocus(sender, e);
					break;
					
				case Sys.SAM_KillFocus:
					e.Handled = true;
					this.tblCurrPseudoCode_colsAccount.EditDataItemSetEdited();
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsAccount_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblCurrPseudoCode_colsAccount;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCurrPseudoCode_colsCodeB_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblCurrPseudoCode_colsCodeB_OnPM_DataItemQueryEnabled(sender, e);
					break;
					
				case Sys.SAM_SetFocus:
					this.tblCurrPseudoCode_colsCodeB_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeB_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsNull(this.tblCurrPseudoCode_colsAccount)) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeB_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblCurrPseudoCode_colsCodeB;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCurrPseudoCode_colsCodeC_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblCurrPseudoCode_colsCodeC_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblCurrPseudoCode_colsCodeC_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeC_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblCurrPseudoCode_colsCodeC;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeC_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsNull(this.tblCurrPseudoCode_colsAccount)) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCurrPseudoCode_colsCodeD_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblCurrPseudoCode_colsCodeD_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblCurrPseudoCode_colsCodeD_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeD_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblCurrPseudoCode_colsCodeD;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeD_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsNull(this.tblCurrPseudoCode_colsAccount)) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCurrPseudoCode_colsCodeE_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblCurrPseudoCode_colsCodeE_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblCurrPseudoCode_colsCodeE_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeE_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblCurrPseudoCode_colsCodeE;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeE_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsNull(this.tblCurrPseudoCode_colsAccount)) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCurrPseudoCode_colsCodeF_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblCurrPseudoCode_colsCodeF_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblCurrPseudoCode_colsCodeF_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeF_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblCurrPseudoCode_colsCodeF;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeF_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsNull(this.tblCurrPseudoCode_colsAccount)) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCurrPseudoCode_colsCodeG_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblCurrPseudoCode_colsCodeG_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblCurrPseudoCode_colsCodeG_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeG_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblCurrPseudoCode_colsCodeG;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeG_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsNull(this.tblCurrPseudoCode_colsAccount)) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCurrPseudoCode_colsCodeH_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblCurrPseudoCode_colsCodeH_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblCurrPseudoCode_colsCodeH_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeH_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblCurrPseudoCode_colsCodeH;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeH_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsNull(this.tblCurrPseudoCode_colsAccount)) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCurrPseudoCode_colsCodeI_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblCurrPseudoCode_colsCodeI_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblCurrPseudoCode_colsCodeI_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeI_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblCurrPseudoCode_colsCodeI;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeI_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsNull(this.tblCurrPseudoCode_colsAccount)) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCurrPseudoCode_colsCodeJ_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblCurrPseudoCode_colsCodeJ_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.tblCurrPseudoCode_colsCodeJ_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeJ_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblCurrPseudoCode_colsCodeJ;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsCodeJ_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsNull(this.tblCurrPseudoCode_colsAccount)) 
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCurrPseudoCode_colsProcessCode_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblCurrPseudoCode_colsProcessCode_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsProcessCode_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblCurrPseudoCode_colsProcessCode;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCurrPseudoCode_colsText_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblCurrPseudoCode_colsText_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colsText_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblCurrPseudoCode_colsPseudoCode;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCurrPseudoCode_colnQuantity_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblCurrPseudoCode_colnQuantity_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrPseudoCode_colnQuantity_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.tblCurrPseudoCode_colsPseudoCode;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}

        private void tblCurrPseudoCode_colnProjectActivityId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.tblCurrPseudoCode_colnProjectActivityId_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblCurrPseudoCode_colnProjectActivityId_OnPM_DataItemQueryEnabled(sender, e);
                    break;

            }
            #endregion
        }

        private void tblCurrPseudoCode_colnProjectActivityId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.IsNull(this.tblCurrPseudoCode_colnProjectActivityId))
            {
                if (SalString.FromHandle(this.tblCurrPseudoCode_colsProjectActivityIdEnabled.EditDataItemValueGet()) == "Y")
                {
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("PROJECT_ACTIVITY_POSTABLE")))
                    {
                        e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                        return;
                    }
                    else
                    {
                        e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
                        return;
                    }
                }
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void tblCurrPseudoCode_colnProjectActivityId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.hLastWithFocus = this.tblCurrPseudoCode_colnProjectActivityId;
            if ((this.tblCurrPseudoCode_colnProjectActivityId.Number == Sys.NUMBER_Null) && (this.tblCurrPseudoCode_colsProjectActivityIdEnabled.Text == Sys.STRING_Null))
            {
                this.EnableSeqId();
            }
            if (Sal.IsNull(this.tblCurrPseudoCode_colnProjectActivityId) || this.tblCurrPseudoCode_colnProjectActivityId.Number == 0)
            {

                if (this.tblCurrPseudoCode_colsProjectActivityIdEnabled.Text == "Y" && this.sProjectOrigin != "FINPROJECT")
                {
                    this.SetValueOfProjectID();
                    this.RefreshButtonsState();
                    e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
                    return;
                }
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
            this.SetValueOfProjectID();
            this.RefreshButtonsState();
            e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
		#endregion
			
		#region Window Events
			
        private void tblCurrPseudoCode_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordGetDefaults();
        }
        #endregion

        private void tblCurrPseudoCode_EnableDisableProjectActivityIdEvent(object sender, cChildTableFin.cChildTableFinEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = this.EnableDisableProjectActivityId(e.sCodePartValue);
        }
        #endregion
    }
}
