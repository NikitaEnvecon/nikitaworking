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
// Date    By      Notes
// ------  ------  -------------------------------------------------------------------------------------
// 091023  Nirplk  Bug 85809, Corrected the zooming behaviour
// 091023  Maaylk  Bug 84036, Corrected the error of opening of wrong consolidation Code Part Value in wrong company when zoomed
// 120219  Samblk  SFI-2399 - merged Bug 100920 
// 141212  Clstlk  PRFI-4008 merged LCS Bug 120136, Modified ConnectCodePart().
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
    [FndWindowRegistration("ACCOUNTING_CODE_PART_VALUE,ACCOUNTING_CODE_PART_VALUE_LOV", "AccountingCodePartValue", FndWindowRegistrationFlags.HomePage)]
	public partial class frmCodeParts : cContainerTabFormWindowFin
	{
		#region Window Variables
		public SalString lsProjectCodePart = "";
		public SalString lsFixassCodePart = "";
		public SalWindowHandle hWnd = SalWindowHandle.Null;
		public SalBoolean bOk = false;
		public SalNumber nRow = 0;
		public SalNumber nDataTransfer = 0;
		public SalString sCompanyTransfer = "";

        // Bug 85809, Begin
        public SalWindowHandle hWinHandle = SalWindowHandle.Null;
        public SalString sWindow = "";
        // Bug 85809, End

		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmCodeParts()
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
		public new static frmCodeParts FromHandle(SalWindowHandle handle)
		{
			return ((frmCodeParts)SalWindow.FromHandle(handle, typeof(frmCodeParts)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean SetWindowTitle()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.SetWindowText(i_hWndSelf, i_sCompany + " - " + Properties.Resources.WH_TabFreeCode);
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CheckCodePartFunction()
		{
			#region Actions
			using (new SalContext(this))
			{
				lsProjectCodePart = GetCodePartFunction("PRACC");
				lsFixassCodePart = GetCodePartFunction("FAACC");
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// Add tab on tab form for code part given by input parameter 'sCode'
		/// </summary>
		/// <param name="sCode"></param>
		/// <returns></returns>
		public virtual SalNumber AddCodePartTab(SalString sCode)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sCode == "B") 
				{
					picTab.AddPage("Name0", Pal.GetActiveInstanceName("tbwCodeB"), SalWindowHandle.Null);
					picTab.SetLabel(0, cFinlibServices.sCodePartName[1], false);
				}
				else if (sCode == "C") 
				{
					picTab.AddPage("Name1", Pal.GetActiveInstanceName("tbwCodeC"), SalWindowHandle.Null);
					picTab.SetLabel(1, cFinlibServices.sCodePartName[2], false);
				}
				else if (sCode == "D") 
				{
					picTab.AddPage("Name2", Pal.GetActiveInstanceName("tbwCodeD"), SalWindowHandle.Null);
					picTab.SetLabel(2, cFinlibServices.sCodePartName[3], false);
				}
				else if (sCode == "E") 
				{
					picTab.AddPage("Name3", Pal.GetActiveInstanceName("tbwCodeE"), SalWindowHandle.Null);
					picTab.SetLabel(3, cFinlibServices.sCodePartName[4], false);
				}
				else if (sCode == "F") 
				{
					picTab.AddPage("Name4", Pal.GetActiveInstanceName("tbwCodeF"), SalWindowHandle.Null);
					picTab.SetLabel(4, cFinlibServices.sCodePartName[5], false);
				}
				else if (sCode == "G") 
				{
					picTab.AddPage("Name5", Pal.GetActiveInstanceName("tbwCodeG"), SalWindowHandle.Null);
					picTab.SetLabel(5, cFinlibServices.sCodePartName[6], false);
				}
				else if (sCode == "H") 
				{
					picTab.AddPage("Name6", Pal.GetActiveInstanceName("tbwCodeH"), SalWindowHandle.Null);
					picTab.SetLabel(6, cFinlibServices.sCodePartName[7], false);
				}
				else if (sCode == "I") 
				{
					picTab.AddPage("Name7", Pal.GetActiveInstanceName("tbwCodeI"), SalWindowHandle.Null);
					picTab.SetLabel(7, cFinlibServices.sCodePartName[8], false);
				}
				else if (sCode == "J") 
				{
					picTab.AddPage("Name8", Pal.GetActiveInstanceName("tbwCodeJ"), SalWindowHandle.Null);
					picTab.SetLabel(8, cFinlibServices.sCodePartName[9], false);
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber ConnectCodePart()
		{
			#region Local Variables
			SalNumber nCount = 0;
			SalString sCode = "";
			SalString sPosition = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				CheckCodePartFunction();             
                picTab.ClearPages();                
				nCount = 0;
				while (nCount < 9) 
				{
					sCode = (nCount + 66).ToCharacter();
					sPosition = nCount.ToString(0);
					if (lsProjectCodePart == sCode) 
					{
						if (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("tbwOverProjAcc")))) 
						{
                            AddCodePartTab(sCode);
						}
						else
						{
							cFinlibServices.lsDisplayCodePart[nCount + 1] = "Y";
							picTab.AddPage("Name" + sPosition, Pal.GetActiveInstanceName("tbwOverProjAcc"), SalWindowHandle.Null);
							picTab.SetLabel(nCount, cFinlibServices.sCodePartName[nCount + 1], true);
						}
					}
					else if (lsFixassCodePart == sCode) 
					{
						if (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("tbwObjectTab")))) 
						{
							cFinlibServices.lsDisplayCodePart[nCount + 1] = "N";
						}
						else
						{
							cFinlibServices.lsDisplayCodePart[nCount + 1] = "Y";
							picTab.AddPage("Name" + sPosition, Pal.GetActiveInstanceName("tbwObjectTab"), SalWindowHandle.Null);
							picTab.SetLabel(nCount, cFinlibServices.sCodePartName[nCount + 1], true);
						}
					}
					else
					{
						AddCodePartTab(sCode);
					}
					nCount = nCount + 1;
				}
				if (cFinlibServices.lsDisplayCodePart[1] == "N") 
				{
					picTab.Enable(0, false);
				}
				else
				{
					picTab.Enable(0, true);
				}
				if (cFinlibServices.lsDisplayCodePart[2] == "N") 
				{
					picTab.Enable(1, false);
				}
				else
				{
					picTab.Enable(1, true);
				}
				if (cFinlibServices.lsDisplayCodePart[3] == "N") 
				{
					picTab.Enable(2, false);
				}
				else
				{
					picTab.Enable(2, true);
				}
				if (cFinlibServices.lsDisplayCodePart[4] == "N") 
				{
					picTab.Enable(3, false);
				}
				else
				{
					picTab.Enable(3, true);
				}
				if (cFinlibServices.lsDisplayCodePart[5] == "N") 
				{
					picTab.Enable(4, false);
				}
				else
				{
					picTab.Enable(4, true);
				}
				if (cFinlibServices.lsDisplayCodePart[6] == "N") 
				{
					picTab.Enable(5, false);
				}
				else
				{
					picTab.Enable(5, true);
				}
				if (cFinlibServices.lsDisplayCodePart[7] == "N") 
				{
					picTab.Enable(6, false);
				}
				else
				{
					picTab.Enable(6, true);
				}
				if (cFinlibServices.lsDisplayCodePart[8] == "N") 
				{
					picTab.Enable(7, false);
				}
				else
				{
					picTab.Enable(7, true);
				}
				if (cFinlibServices.lsDisplayCodePart[9] == "N") 
				{
					picTab.Enable(8, false);
				}
				else
				{
					picTab.Enable(8, true);
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber ZoomCodeParts()
		{
			#region Local Variables
			SalString sCodePart = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0) 
				{
					if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeGet() == "ZOOM" && Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemCountGet() > 2) 
					{
						sCodePart = Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sData[2];
						nDataTransfer = 1;
						sCompanyTransfer = Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sData[1];
						dfCompany.Text = sCompanyTransfer;
						if (sCodePart == "B") 
						{
							picTab.BringToTop(0, true);

                            if (sCodePart != lsFixassCodePart && sCodePart != lsProjectCodePart)
                            {
                                hWinHandle = (TabAttachedWindoHandleGet(0));
                                sWindow = Pal.GetActiveInstanceName("tbwCodeB");
                            } 

                            if (sCodePart != lsFixassCodePart && sCodePart != lsProjectCodePart)
                            {
                                hWinHandle = (TabAttachedWindoHandleGet(0));
                                sWindow = Pal.GetActiveInstanceName("tbwCodeB");
                            } 

						}
						else if (sCodePart == "C") 
						{
							picTab.BringToTop(1, true);
                            if (sCodePart != lsFixassCodePart && sCodePart != lsProjectCodePart)
                            {
                            hWinHandle = (TabAttachedWindoHandleGet(1));
                            sWindow = Pal.GetActiveInstanceName("tbwCodeC");
                            } 
						}
						else if (sCodePart == "D") 
						{
							picTab.BringToTop(2, true);
                            if (sCodePart != lsFixassCodePart && sCodePart != lsProjectCodePart)
                            {
                                hWinHandle = (TabAttachedWindoHandleGet(2));
                                sWindow = Pal.GetActiveInstanceName("tbwCodeD");
                            } 
						}
						else if (sCodePart == "E") 
						{
							picTab.BringToTop(3, true);
                            if (sCodePart != lsFixassCodePart && sCodePart != lsProjectCodePart)
                            {
                                hWinHandle = (TabAttachedWindoHandleGet(3));
                                sWindow = Pal.GetActiveInstanceName("tbwCodeE");
                            } 
						}
						else if (sCodePart == "F") 
						{
							picTab.BringToTop(4, true);
                            if (sCodePart != lsFixassCodePart && sCodePart != lsProjectCodePart)
                            {
                                hWinHandle = (TabAttachedWindoHandleGet(4));
                                sWindow = Pal.GetActiveInstanceName("tbwCodeF");
                            } 
						}
						else if (sCodePart == "G") 
						{
							picTab.BringToTop(5, true);
                            if (sCodePart != lsFixassCodePart && sCodePart != lsProjectCodePart)
                            {
                                hWinHandle = (TabAttachedWindoHandleGet(5));
                                sWindow = Pal.GetActiveInstanceName("tbwCodeG");
                            } 
						}
						else if (sCodePart == "H") 
						{
							picTab.BringToTop(6, true);
                            if (sCodePart != lsFixassCodePart && sCodePart != lsProjectCodePart)
                            {
                                hWinHandle = (TabAttachedWindoHandleGet(6));
                                sWindow = Pal.GetActiveInstanceName("tbwCodeH");
                            } 
						}
						else if (sCodePart == "I") 
						{
							picTab.BringToTop(7, true);
                            if (sCodePart != lsFixassCodePart && sCodePart != lsProjectCodePart)
                            {
                                hWinHandle = (TabAttachedWindoHandleGet(7));
                                sWindow = Pal.GetActiveInstanceName("tbwCodeI");
                            } 
						}
						else if (sCodePart == "J") 
						{
							picTab.BringToTop(8, true);
                            if (sCodePart != lsFixassCodePart && sCodePart != lsProjectCodePart)
                            {
                                hWinHandle = (TabAttachedWindoHandleGet(8));
                                sWindow = Pal.GetActiveInstanceName("tbwCodeJ");
                            } 
						}
					}
				}
			}

			return 0;
			#endregion
		}

        // Bug 85809,Introduced PopulateZoomData()
        public virtual SalNumber PopulateZoomData(fcURL URL)
		{		
			#region Actions
			using (new SalContext(this))
			{
                if (sWindow != "")
                {
                    if (sWindow == Pal.GetActiveInstanceName("tbwCodeB"))
                    {
                        tbwCodeB.FromHandle(hWinHandle).Activate(URL);
                    }
                    if (sWindow == Pal.GetActiveInstanceName("tbwCodeC"))
                    {
                        tbwCodeC.FromHandle(hWinHandle).Activate(URL);
                    }
                    if (sWindow == Pal.GetActiveInstanceName("tbwCodeD"))
                    {
                        tbwCodeD.FromHandle(hWinHandle).Activate(URL);
                    }
                    if (sWindow == Pal.GetActiveInstanceName("tbwCodeE"))
                    {
                        tbwCodeE.FromHandle(hWinHandle).Activate(URL);
                    }
                    if (sWindow == Pal.GetActiveInstanceName("tbwCodeF"))
                    {
                        tbwCodeF.FromHandle(hWinHandle).Activate(URL);
                    }
                    if (sWindow == Pal.GetActiveInstanceName("tbwCodeG"))
                    {
                        tbwCodeG.FromHandle(hWinHandle).Activate(URL);
                    }
                    if (sWindow == Pal.GetActiveInstanceName("tbwCodeH"))
                    {
                        tbwCodeH.FromHandle(hWinHandle).Activate(URL);
                    }
                    if (sWindow == Pal.GetActiveInstanceName("tbwCodeI"))
                    {
                        tbwCodeI.FromHandle(hWinHandle).Activate(URL);
                    }
                    if (sWindow == Pal.GetActiveInstanceName("tbwCodeJ"))
                    {
                        tbwCodeJ.FromHandle(hWinHandle).Activate(URL);
                    }
                }
                sWindow = "";	
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
		private void frmCodeParts_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
					this.frmCodeParts_OnPM_DataSourceSave(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourceSave event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmCodeParts_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
                this.nRow = Sal.TblQueryContext(this.TabAttachedWindowHandleGet(this.picTab.GetTop()));
				this.bOk = Sal.SendMsgToChildren(this.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
				e.Return = this.bOk;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void picTab_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
			}
			#endregion
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtSetWindowTitle()
		{
			return this.SetWindowTitle();
		}
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            // Bug 85809, Removed the declaration of nReturnValue.
            //Bug 84036, Begin
            string dataTransfer;
            //Bug 84036, End
            #endregion
            
            #region Actions
            //Bug 84036, Begin
            if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeGet() == "ZOOM" && Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemCountGet() > 2)
                {
                    sCompanyTransfer = Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sData[1];
                }
            }
            if (sCompanyTransfer != SalString.Null)
            {
                UserGlobalValueSet("COMPANY", sCompanyTransfer);
            }
            UserGlobalValueGet("COMPANY",ref i_sCompany);
            //Bug 84036, End

			// Code from PM_UserProfileChanged
			this.dfCompany.Text = this.i_sCompany;
            //Code Part details are updated everytime so if a code part is enabled or dissabled, it will get affected in this form immediatly
            cFinlibServices.nCodePartNameCount = 0;
            if (this.nInit == 1)
            {
                this.nInit = 0;
                this.GetCodePartNames(this.i_sCompany, cSessionManager.c_sDbPrefix);
                this.nInit = 1;
            }
            else
            {
                this.GetCodePartNames(this.i_sCompany, cSessionManager.c_sDbPrefix);
            }
			this.RefreshCodePartInfo(this.i_sCompany, cSessionManager.c_sDbPrefix);
			this.picTab.BringToTop(1, true);
			this.ConnectCodePart();
			this.picTab.Redraw();            
			this.picTab.BringToTop(0, true);          

            //Code moved from picTab_OnSAM_Create
            Sal.SendMsg(this, Ifs.Application.Accrul.Const.PM_TranslateCodePartTab, Sys.wParam, Sal.WindowHandleToNumber(this.picTab));
            
            //Code moved from FrameStartupUser

            // Bug 85809, Removed the code nReturnValue
            //Bug 84036, Begin
            dataTransfer = iURL.iParameters.FindAttribute("DATA_TRANSFER", SalString.Null);
            if (dataTransfer != SalString.Null)
            {
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Deserialize(dataTransfer);
            }
            //Bug 84036, End
           	ZoomCodeParts();
            if (nDataTransfer == 1)
            {
                if (sCompanyTransfer == SalString.Null)
                {
                    dfCompany.Text = i_sCompany;
                }
                else
                {
                    dfCompany.Text = sCompanyTransfer;
                    i_sCompany = sCompanyTransfer;
                }
                nDataTransfer = 0;
            }
            else
            {
                dfCompany.Text = i_sCompany;
            }
            SetWindowTitle();
           
            // Bug 85809, returned 0    
            return PopulateZoomData(URL);
            #endregion
        }
		#endregion
	}
}
