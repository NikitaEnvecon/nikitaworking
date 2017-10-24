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
//  140701  Clstlk  PRFI-425, Merged Bug 116020.
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
	/// Created for Bug# 20944 - To define tasks to update the currency rates with the spot rates received in a text file.
	/// </summary>
	[FndWindowRegistration("EXT_CURRENCY_TASK", "ExtCurrencyCompany", FndWindowRegistrationFlags.HomePage)]
	public partial class frmAutoUpdateCurrency : cFormWindowFin
	{
		#region Window Variables
		public SalString lsStmt = "";
		public SalString sFormName = "";
		public SalString sCompany = "";
		public SalString sCurrType = "";
		public SalArray<SalString> strFilters = new SalArray<SalString>("0:5");
        public SalArray<SalString> sParams = new SalArray<SalString>(1);
		public SalString strFile = "";
		public SalString strPath = "";
		public SalNumber nIndex = 0;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmAutoUpdateCurrency()
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
		public new static frmAutoUpdateCurrency FromHandle(SalWindowHandle handle)
		{
			return ((frmAutoUpdateCurrency)SalWindow.FromHandle(handle, typeof(frmAutoUpdateCurrency)));
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
				strFilters[0] = "Text Files  (*.txt)";
				strFilters[1] = "*.txt";
				strFilters[2] = "All Files  (*.*)";
				strFilters[3] = "*.*";
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean ShowActiveCompany()
		{
			#region Actions
			using (new SalContext(this))
			{
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// Gets client default values for NEW records
		/// </summary>
		/// <returns></returns>
		public new SalBoolean DataRecordGetDefaults()
		{
			#region Actions
			using (new SalContext(this))
			{
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
		private void frmAutoUpdateCurrency_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
					this.frmAutoUpdateCurrency_OnPM_DataSourceSave(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourceSave event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmAutoUpdateCurrency_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;

            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (!(Sal.TblAnyRows(this.tblCurrencyDetail, 0, Sys.ROW_MarkDeleted)))
                {
                    sParams[0] = cmbTaskId.Text;
                    if (Sal.TblAnyRows(this.tblCurrencyDetail, 0, 0))
                    {
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.ERROR_NoDeletionOfAllRows, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_YesNo, sParams) == Sys.IDNO)
                        {
                            DataSourceDetailModified(false);
                            DataSourceRefresh(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
                            SalNumber nRow = Sal.TblQueryContext(this.tblCurrencyDetail);
                            Sal.TblSetFocusRow(this.tblCurrencyDetail, nRow);
                            e.Return = false;
                            return;
                        }
                    }                               
                }
            }
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
			return;
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
		public override SalBoolean vrtFrameStartupUser()
		{
			return this.FrameStartupUser();
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtShowActiveCompany()
		{
			return this.ShowActiveCompany();
		}
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Actions
            using (new SalContext(this))
            {
                UserGlobalValueGet("COMPANY", ref sCompany);
                return base.Activate(URL);
            }
            #endregion
        }
		#endregion
		
		#region tblCurrencyDetail	
			
		#region Window Variables
		public SalString sPrevCompany = "";
		#endregion

		#region Methods
			
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean GetCurrenyInfo()
		{
			#region Actions
		
			if (!(DbPLSQLBlock(@"{0} :=  &AO.Currency_Type_API.Get_Default_Type({1} IN);",
                this.QualifiedVarBindName("sCurrType"),this.tblCurrencyDetail_colsCompany.QualifiedBindName))) 
			{
				return false;
			}	
            tblCurrencyDetail_colsCurrencyType.EditDataItemValueSet(1, this.sCurrType.ToHandle());
			return true;
			
			#endregion
		}
			
		/// <summary>
		/// Get default values for new row
		/// </summary>
		/// <returns></returns>
        public virtual SalNumber tblCurrencyDetail_DataRecordGetDefaults()
		{
		    tblCurrencyDetail_colsCompany.EditDataItemValueSet(1, this.sCompany.ToHandle());
			return 0;
		}
		#endregion
			
		#region Window Actions
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCurrencyDetail_colsCompany_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblCurrencyDetail_colsCompany_OnPM_DataItemValidate(sender, e);
					break;
					
				case Sys.SAM_SetFocus:
					e.Handled = true;
                    this.sPrevCompany = this.tblCurrencyDetail_colsCompany.Text;
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCurrencyDetail_colsCompany_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {

        }
		#endregion
			
		#region window Events
        private void tblCurrencyDetail_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.tblCurrencyDetail_DataRecordGetDefaults();
        }
        #endregion
        #endregion
    }
}
