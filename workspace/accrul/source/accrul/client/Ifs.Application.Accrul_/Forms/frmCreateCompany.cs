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
// DATE        BY        NOTES
// YY-MM-DD
// 121123     Janblk     DANU-122, Parallel currency implementation
// 130123     NILILK     Set Field Parallel Currency read only.

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
	[FndWindowRegistration("COMPANY_FINANCE", "CompanyFinance")]
	[FndDynamicTabPage("frmCompany.picTab", "", "DOMAIN-frmCreateCompany", "WH_CreateCompany", 5)]
	public partial class frmCreateCompany : cMasterDetailTabFormWindowFin
	{
        private SalNumber nNum;        
        public SalArray<SalString> sRecords = new SalArray<SalString>();
        public SalArray<SalString> sUnits = new SalArray<SalString>();
        public SalString lsStmt = "";        
        public SalNumber nTemp  = 0;
        public SalArray<SalString> sItemNames = new SalArray<SalString>();
        public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        public SalString sFormName = "";
        public SalString sItemName1 = "";

		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmCreateCompany()
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
		public new static frmCreateCompany FromHandle(SalWindowHandle handle)
		{
			return ((frmCreateCompany)SalWindow.FromHandle(handle, typeof(frmCreateCompany)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean DataRecordGetDefaults()
		{
			#region Actions
			using (new SalContext(this))
			{
				dfCompany.Text = SalString.FromHandle(frmCompany.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).cmbIdentity.EditDataItemValueGet());
				dfCompany.EditDataItemSetEdited();
				dfDescription.Text = frmCompany.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).dfName.Text;
				dfDescription.EditDataItemSetEdited();
				return true;
			}
			#endregion
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void frmCreateCompany_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.frmCreateCompany_OnSAM_Create(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
					this.frmCreateCompany_OnPM_DataSourcePopulate(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans:
					this.frmCreateCompany_OnPM_DataSourceCreateWindowTrans(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
					this.frmCreateCompany_OnPM_DataSourceSave(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmCreateCompany_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam)) 
			{
				Sal.SetWindowText(this, Properties.Resources.WH_CreateCompany);
				e.Return = true;
				return;
			}
			else
			{
				e.Return = false;
				return;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourcePopulate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmCreateCompany_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam)) 
			{
				e.Return = true;
				return;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourceCreateWindowTrans event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmCreateCompany_OnPM_DataSourceCreateWindowTrans(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			// Set the global value to the selected company to fix zooming to the user global company
            // CONVERSION: Static code snippet replaced original source.
            // CONVERSION: Sparx bug. Should be reported and corrected in Sparx project.
			{
				// Bug 71319, Begin. Fully qualified dfsCompany.
				this.UserGlobalValueSet("COMPANY", frmCreateCompany.FromHandle(this.i_hWndFrame).dfCompany.Text);
				// Bug 71319, End.
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourceSave event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmCreateCompany_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
				e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
				return;
			}
			else if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam)) 
				{
					Sal.SendMsg(this.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, 0);
					e.Return = true;
					return;
				}
				else
				{
					e.Return = false;
					return;
				}
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfParallelAccCurrency_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				// Bug 84667, Begin
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.dfParallelAccCurrency_OnPM_DataItemQueryEnabled(sender, e);
					break;
				
				// Bug 84667, End
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfParallelAccCurrency_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("COMPANY_FINANCE_API.Modify__")) 
			{
				e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
				return;
			}
			else
			{
				e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
				return;
			}
			#endregion
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtDataRecordGetDefaults()
		{
			return this.DataRecordGetDefaults();
		}
		#endregion       


        private void dfsParallelRateType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.dfsParallelRateType_OnPM_DataItemLovDone(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.dfsParallelRateType_OnPM_DataItemLovUserWhere(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsParallelRateType_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsParallelRateType_OnPM_DataItemValidate(sender, e);
                    break;

				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.dfsParallelRateType_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        private void dfsParallelRateType_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsParallelBaseDb.Text != Sys.STRING_Null)
            {
                if (DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN \r\n " +
                    ":i_hWndFrame.frmCreateCompany.nTemp := Currency_Type_API.Is_Correct_Curr_Type(\r\n" +
                    ":i_hWndFrame.frmCreateCompany.dfCompany, \r\n" +
                    ":i_hWndFrame.frmCreateCompany.dfsParallelBaseDb, \r\n" +
                    ":i_hWndFrame.frmCreateCompany.dfsParallelRateType, \r\n" +
                    ":i_hWndFrame.frmCreateCompany.dfCurrencyCode); \r\n END;"))
                {
                    if (nTemp == 1)
                    {
                        e.Return = Sys.VALIDATE_Ok;
                    }
                    else
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul_.Properties.Resources.TEXT_IncorrectCurrType, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        e.Return = Sys.VALIDATE_Cancel;
                    }
                    return;
                }
                     
            }
            else
            {
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            #endregion
        }

        private void dfsParallelRateType_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsParallelBaseDb.Text == "TRANSACTION_CURRENCY")
            {
               e.Return = ((SalString)("RATE_TYPE_CATEGORY_DB = 'PARALLEL_CURRENCY'")).ToHandle();
            }
            if (this.dfsParallelBaseDb.Text == "ACCOUNTING_CURRENCY")
            {

                e.Return = ((SalString)("REF_CURRENCY_CODE = '" + this.dfCurrencyCode.Text + "'") + (SalString)(" AND RATE_TYPE_CATEGORY_DB != 'PROJECT'")).ToHandle();

            }
            return;            
            #endregion
        }

        private void dfsParallelRateType_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nNum = SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sRecords);
            this.nNum = this.sRecords[0].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
            if (this.sUnits[0] == "CURRENCY_TYPE")
            {
                this.dfsParallelRateType.Text = this.sUnits[1];
                Sal.SetFieldEdit(this.dfsParallelRateType, true);
            }            
            #endregion
        }

        private void dfsParallelRateType_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region
            e.Handled = true;
            if (this.dfsParallelBase.Text == Sys.STRING_Null)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            else
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsParallelRateType_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {           

            #region Actions
            e.Handled = true;

            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = ((Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("tbwCurrencyType"))) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("tbwCurrencyType"))) ;
                return;
            }

            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {                
                this.sFormName = Pal.GetActiveInstanceName("tbwCurrencyType");
                this.sItemNames[0] = "COMPANY";
                this.hWndItems[0] = dfCompany;
                this.sItemNames[1] = "CURRENCY_TYPE";
                this.hWndItems[1] = dfsParallelRateType;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Company", this, this.sItemNames, this.hWndItems);
                SessionNavigate(Pal.GetActiveInstanceName("tbwCurrencyType"));
                e.Return = true;
                return;             
            }
            
            #endregion
        }

	}
}
