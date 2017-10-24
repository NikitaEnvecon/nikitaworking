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
	[FndWindowRegistration("CURRENCY_TYPE_BASIC_DATA", "CurrencyTypeBasicData")]
	public partial class frmCurrencyTypeBasic : cFormWindowFin
	{
		#region Window Variables
		public SalString sRefCurrencyCode = "";
		public SalString sEmuCurrency = "";
		public SalString sEur = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmCurrencyTypeBasic()
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
		public new static frmCurrencyTypeBasic FromHandle(SalWindowHandle handle)
		{
			return ((frmCurrencyTypeBasic)SalWindow.FromHandle(handle, typeof(frmCurrencyTypeBasic)));
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
                dfsCompany.Text = SalString.FromHandle(frmCompany.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame).GetParent()).cmbIdentity.EditDataItemValueGet());
				dfsCompany.EditDataItemSetEdited();
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sType"></param>
		/// <returns></returns>
		public virtual SalBoolean ValidateRefCurrency(SalString sType)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sType == "BUY") 
				{
					if (Sal.IsNull(dfsBuy)) 
					{
						return Sys.VALIDATE_Ok;
					}
					else
					{
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Currency_Type_API.Get_Ref_Currency_Code", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmCurrencyTypeBasic.sRefCurrencyCode:= &AO.Currency_Type_API.Get_Ref_Currency_Code(:i_hWndFrame.frmCurrencyTypeBasic.dfsCompany,:i_hWndFrame.frmCurrencyTypeBasic.dfsBuy)");
						}
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Currency_Code_API.Get_Emu", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmCurrencyTypeBasic.sEmuCurrency:= &AO.Currency_Code_API.Get_Emu(:i_hWndFrame.frmCurrencyTypeBasic.dfsCompany,:i_hWndFrame.frmCurrencyTypeBasic.dfsRefCurrencyCode)");
						}
						if (sEmuCurrency == "TRUE" && sRefCurrencyCode == "EUR") 
						{
							return Sys.VALIDATE_Ok;
						}
						else if (sRefCurrencyCode != dfsRefCurrencyCode.Text) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_CurrencyTypeMsgBuy, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
							return Sys.VALIDATE_Cancel;
						}
						else
						{
							return Sys.VALIDATE_Ok;
						}
					}
				}
				else if (sType == "TAXBUY") 
				{
					if (Sal.IsNull(dfsTaxBuy)) 
					{
						return Sys.VALIDATE_Ok;
					}
					else
					{
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Currency_Type_API.Get_Ref_Currency_Code", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmCurrencyTypeBasic.sRefCurrencyCode:= &AO.Currency_Type_API.Get_Ref_Currency_Code(:i_hWndFrame.frmCurrencyTypeBasic.dfsCompany,:i_hWndFrame.frmCurrencyTypeBasic.dfsTaxBuy)");
						}
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Currency_Code_API.Get_Emu", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmCurrencyTypeBasic.sEmuCurrency:= &AO.Currency_Code_API.Get_Emu(:i_hWndFrame.frmCurrencyTypeBasic.dfsCompany,:i_hWndFrame.frmCurrencyTypeBasic.dfsRefCurrencyCode)");
						}
						if (sEmuCurrency == "TRUE" && sRefCurrencyCode == "EUR") 
						{
							return Sys.VALIDATE_Ok;
						}
						else if (sRefCurrencyCode != dfsRefCurrencyCode.Text) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_CurrTypeMsgTaxBuy, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
							return Sys.VALIDATE_Cancel;
						}
						else
						{
							return Sys.VALIDATE_Ok;
						}
					}
				}
				else if (sType == "TAXSELL") 
				{
					if (Sal.IsNull(dfsTaxSell)) 
					{
						return Sys.VALIDATE_Ok;
					}
					else
					{
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Currency_Type_API.Get_Ref_Currency_Code", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmCurrencyTypeBasic.sRefCurrencyCode:= &AO.Currency_Type_API.Get_Ref_Currency_Code(:i_hWndFrame.frmCurrencyTypeBasic.dfsCompany,:i_hWndFrame.frmCurrencyTypeBasic.dfsTaxSell)");
						}
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Currency_Code_API.Get_Emu", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmCurrencyTypeBasic.sEmuCurrency:= &AO.Currency_Code_API.Get_Emu(:i_hWndFrame.frmCurrencyTypeBasic.dfsCompany,:i_hWndFrame.frmCurrencyTypeBasic.dfsRefCurrencyCode)");
						}
						if (sEmuCurrency == "TRUE" && sRefCurrencyCode == "EUR") 
						{
							return Sys.VALIDATE_Ok;
						}
						else if (sRefCurrencyCode != dfsRefCurrencyCode.Text) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_CurrTypeMsgTaxSell, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
							return Sys.VALIDATE_Cancel;
						}
						else
						{
							return Sys.VALIDATE_Ok;
						}
					}
				}
				else
				{
					if (Sal.IsNull(dfsSell)) 
					{
						return Sys.VALIDATE_Ok;
					}
					else
					{
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Currency_Type_API.Get_Ref_Currency_Code", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmCurrencyTypeBasic.sRefCurrencyCode:= &AO.Currency_Type_API.Get_Ref_Currency_Code(:i_hWndFrame.frmCurrencyTypeBasic.dfsCompany,:i_hWndFrame.frmCurrencyTypeBasic.dfsSell)");
						}
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Currency_Code_API.Get_Emu", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
							DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmCurrencyTypeBasic.sEmuCurrency:= &AO.Currency_Code_API.Get_Emu(:i_hWndFrame.frmCurrencyTypeBasic.dfsCompany,:i_hWndFrame.frmCurrencyTypeBasic.dfsRefCurrencyCode)");
						}
						if (sEmuCurrency == "TRUE" && sRefCurrencyCode == "EUR") 
						{
							return Sys.VALIDATE_Ok;
						}
						if (sRefCurrencyCode != dfsRefCurrencyCode.Text) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_CurrencyTypeMsgSell, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
							return Sys.VALIDATE_Cancel;
						}
						else
						{
							return Sys.VALIDATE_Ok;
						}
					}
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber CreateUserWhere()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Currency_Code_API.Get_Emu", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmCurrencyTypeBasic.sEmuCurrency:= &AO.Currency_Code_API.Get_Emu(:i_hWndFrame.frmCurrencyTypeBasic.dfsCompany,:i_hWndFrame.frmCurrencyTypeBasic.dfsRefCurrencyCode)");
				}
				if (sEmuCurrency == "TRUE") 
				{
					sEur = "EUR";
                    return ((SalString)"(REF_CURRENCY_CODE= " + "'" + this.dfsRefCurrencyCode.Text + "'" + "OR REF_CURRENCY_CODE= '" + sEur + "')").ToHandle();
				}
				else
				{
                    return ((SalString)"REF_CURRENCY_CODE= " + "'" + this.dfsRefCurrencyCode.Text + "'").ToHandle();
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="bFlag"></param>
		/// <returns></returns>
		public virtual SalNumber RefreshTaxRates(SalBoolean bFlag)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (bFlag) 
				{
					EnableTaxRates();
					Sal.SendMsg(dfsTaxSell, Ifs.Fnd.ApplicationForms.Const.PM_DataItemFlagSet, Ifs.Fnd.ApplicationForms.Const.FIELD_Required, 1);
					Sal.SendMsg(dfsTaxBuy, Ifs.Fnd.ApplicationForms.Const.PM_DataItemFlagSet, Ifs.Fnd.ApplicationForms.Const.FIELD_Required, 1);
				}
				else
				{
					DisableTaxRates();
					dfsTaxSell.EditDataItemSetEdited();
					Sal.SendMsg(dfsTaxSell, Ifs.Fnd.ApplicationForms.Const.PM_DataItemFlagSet, Ifs.Fnd.ApplicationForms.Const.FIELD_Required, 0);
					Sal.SendMsg(dfsTaxBuy, Ifs.Fnd.ApplicationForms.Const.PM_DataItemFlagSet, Ifs.Fnd.ApplicationForms.Const.FIELD_Required, 0);
					dfsTaxBuy.EditDataItemSetEdited();
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber EnableTaxRates()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.EnableWindowAndLabel(dfsTaxSell);
				Sal.EnableWindow(dfsTaxSellDescription);
				Sal.EnableWindowAndLabel(dfsTaxBuy);
				Sal.EnableWindow(dfsTaxBuyDescription);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber DisableTaxRates()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.DisableWindowAndLabel(dfsTaxSell);
				Sal.ClearField(dfsTaxSell);
				Sal.DisableWindow(dfsTaxSellDescription);
				Sal.ClearField(dfsTaxSellDescription);
				Sal.DisableWindowAndLabel(dfsTaxBuy);
				Sal.ClearField(dfsTaxBuy);
				Sal.DisableWindow(dfsTaxBuyDescription);
				Sal.ClearField(dfsTaxBuyDescription);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nParam">
		/// Populate options
		/// Options for the poulate. Specify 0 for normal populate, POPULATE_Single - populate the data items only (ingorning record selection
		/// combo boxes), POPULATE_UseQueryDialog - will launch a query dialog for the user before the populate, POPULATE_NoConfirm -
		/// if the population should be performed by ignoring changes or POPULATE_KeepFocus - Used to populate for instance a child table
		/// and forcing the focus to stay in calling field.
		/// POPULATE_NoConfirm
		/// Do not ask user to confirm changes before populating
		/// POPULATE_UseQueryDialog
		/// Launch query dialog before populating
		/// POPULATE_Single
		/// Do not fill control selection boxes also
		/// Fill only data field part of all items
		/// </param>
		/// <returns></returns>
		public new SalBoolean DataSourcePopulateIt(SalNumber nParam)
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				bOk = ((cFormWindowFin)this).DataSourcePopulateIt(nParam);
				if (cbUseTaxRates.Checked) 
				{
					EnableTaxRates();
				}
				else
				{
					DisableTaxRates();
				}
				return bOk;
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
		private void frmCurrencyTypeBasic_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.frmCurrencyTypeBasic_OnPM_DataRecordNew(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans:
					this.frmCurrencyTypeBasic_OnPM_DataSourceCreateWindowTrans(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmCurrencyTypeBasic_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
				frmCurrencyTypeBasic.FromHandle(this.i_hWndFrame).dfsCompany.Text = frmCreateCompany.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndSelf)).dfCompany.Text;
				this.dfsCompany.EditDataItemSetEdited();
				frmCurrencyTypeBasic.FromHandle(this.i_hWndFrame).dfsRefCurrencyCode.Text = frmCreateCompany.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndSelf)).dfCurrencyCode.Text;
			}
			else
			{
				Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
				if (Sal.IsNull(this.dfsCompany)) 
				{
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
		/// PM_DataSourceCreateWindowTrans event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmCurrencyTypeBasic_OnPM_DataSourceCreateWindowTrans(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			// Set the global value to the selected company to fix zooming to the user global company
            // CONVERSION: Static code snippet replaced original source.
            // CONVERSION: Sparx bug. Should be reported and corrected in Sparx project.
			{
				// Bug 71319, Begin. Fully qualified dfsCompany.
				this.UserGlobalValueSet("COMPANY", frmCurrencyTypeBasic.FromHandle(this.i_hWndFrame).dfsCompany.Text);
				// Bug 71319, End.
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsBuy_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
					e.Handled = true;
					e.Return = this.CreateUserWhere();
					return;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					e.Handled = true;
					e.Return = this.ValidateRefCurrency("BUY");
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsSell_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
					e.Handled = true;
					// Return SalHStringToNumber('REF_CURRENCY_CODE= :i_hWndFrame.frmCurrencyTypeBasic.dfsRefCurrencyCode')
					e.Return = this.CreateUserWhere();
					return;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					e.Handled = true;
					e.Return = this.ValidateRefCurrency("SELL");
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsTaxBuy_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
					e.Handled = true;
					e.Return = this.CreateUserWhere();
					return;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					e.Handled = true;
					e.Return = this.ValidateRefCurrency("TAXBUY");
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsTaxSell_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
					e.Handled = true;
					e.Return = this.CreateUserWhere();
					return;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					e.Handled = true;
					e.Return = this.ValidateRefCurrency("TAXSELL");
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbUseTaxRates_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.cbUseTaxRates_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbUseTaxRates_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.IsNull(this.dfsCompany)) 
			{
				e.Return = Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
				return;
			}
			this.RefreshTaxRates(this.cbUseTaxRates.Checked);
			if (this.cbUseTaxRates.Checked) 
			{
				this.cbUseTaxRates.EditDataItemValueSet(1, ((SalString)"TRUE").ToHandle());
			}
			else
			{
				this.cbUseTaxRates.EditDataItemValueSet(1, ((SalString)"FALSE").ToHandle());
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
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtDataSourcePopulateIt(SalNumber nParam)
		{
			return this.DataSourcePopulateIt(nParam);
		}
		#endregion
	}
}
