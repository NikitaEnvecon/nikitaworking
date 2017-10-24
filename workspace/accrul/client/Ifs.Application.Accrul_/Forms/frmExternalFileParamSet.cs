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
// 30042013  JARALK  Bug 109752, Changed the comboBox dropdown style property of colsenumvalue Column from dropdownlist to dropdown so the text field
//                   property of the combo box is editable. Added validation so the field is not editable when the sytem defined check box is checked.
// 07052013  JARALK  Bug 109752, Added validation so the colums are not editable when the sytem defined check box is checked.
// 160527    Nudilk  Bug 129482, Corrected in PopulateValues.
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
	public partial class frmExternalFileParamSet : cFormWindow
	{
		#region Window Variables
		public SalString sFuncToCall = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmExternalFileParamSet()
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
		public new static frmExternalFileParamSet FromHandle(SalWindowHandle handle)
		{
			return ((frmExternalFileParamSet)SalWindow.FromHandle(handle, typeof(frmExternalFileParamSet)));
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void frmExternalFileParamSet_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
					this.frmExternalFileParamSet_OnPM_DataSourcePopulate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourcePopulate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmExternalFileParamSet_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam)) 
				{
					this.PopulateValues();
					e.Return = true;
					return;
				}
				e.Return = false;
				return;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsFileType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.dfsFileType_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsFileType_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.cbSystemDefined.Checked) 
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
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfExtFileTypeDescription_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsSetId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.dfsSetId_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsSetId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.cbSystemDefined.Checked) 
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
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsDescription_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.dfsDescription_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsDescription_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.cbSystemDefined.Checked) 
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
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbSetIdDefault_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbSystemDefined_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					e.Handled = true;
					e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblExtFileParamPerSet_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.tblExtFileParamPerSet_OnPM_DataRecordNew(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
					this.tblExtFileParamPerSet_OnPM_DataRecordRemove(sender, e);
					break;
				
				case Sys.SAM_RowHeaderClick:
					this.tblExtFileParamPerSet_OnSAM_RowHeaderClick(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblExtFileParamPerSet_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
				if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam)) 
				{
					if (this.cbSystemDefined.Checked == true) 
					{
						e.Return = false;
						return;
					}
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordRemove event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblExtFileParamPerSet_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
				if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam)) 
				{
					if (this.cbSystemDefined.Checked == true) 
					{
						e.Return = false;
						return;
					}
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_RowHeaderClick event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblExtFileParamPerSet_OnSAM_RowHeaderClick(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.tblExtFileParamPerSet_colEnumerate_Method.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(this.tblExtFileParamPerSet_colEnumerate_Method.Text))) 
				{
					Sal.ListClear(this.tblExtFileParamPerSet_colsEnumValue);
					this.tblExtFileParamPerSet_colsEnumValue.p_sEnumerateMethod = Ifs.Fnd.ApplicationForms.Const.strNULL;
				}
				else
				{
					this.tblExtFileParamPerSet_colsEnumValue.p_sEnumerateMethod = cSessionManager.c_sDbPrefix + this.tblExtFileParamPerSet_colEnumerate_Method.Text;
					this.tblExtFileParamPerSet_colsEnumValue.LookupInit();
				}
			}
			else
			{
				Sal.ListClear(this.tblExtFileParamPerSet_colsEnumValue);
				this.tblExtFileParamPerSet_colsEnumValue.p_sEnumerateMethod = Ifs.Fnd.ApplicationForms.Const.strNULL;
			}
			#endregion
		}
		#endregion

        #region ChildTable-tblExtFileParamPerSet

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean GetDbValue()
        {
            #region Local Variables
            SalString sPackage = "";
            SalString sOrginal = "";
            SalNumber nOffset = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nOffset = ((SalString)tblExtFileParamPerSet_colEnumerate_Method.Text).Scan(".");
                sPackage = ((SalString)tblExtFileParamPerSet_colEnumerate_Method.Text).Left(nOffset);
                this.sFuncToCall = sPackage + ".Encode";
                sOrginal = tblExtFileParamPerSet_colsDefaultValue.Text;
                
                if (!(DbPLSQLBlock( "{0} := &AO."+ this.sFuncToCall + "({1} IN)",
                        tblExtFileParamPerSet_colsDefaultValue.QualifiedBindName,
                        tblExtFileParamPerSet_colsEnumValue.QualifiedBindName)))
                {
                    return false;
                } 
                if (tblExtFileParamPerSet_colsEnumValue.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    return false;
                }
                if (sOrginal != tblExtFileParamPerSet_colsDefaultValue.Text)
                {
                    tblExtFileParamPerSet_colsDefaultValue.EditDataItemSetEdited();
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean GetClientValue()
        {
            #region Local Variables
            SalString sPackage = "";
            SalNumber nOffset = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nOffset = ((SalString)tblExtFileParamPerSet_colEnumerate_Method.Text).Scan(".");
                sPackage = ((SalString)tblExtFileParamPerSet_colEnumerate_Method.Text).Left(nOffset);
                this.sFuncToCall = sPackage + ".Decode";
            
                if (!(DbPLSQLBlock("{0} := &AO." + this.sFuncToCall + "({1} IN)",
                    tblExtFileParamPerSet_colsEnumValue.QualifiedBindName,
                    tblExtFileParamPerSet_colsDefaultValue.QualifiedBindName)))
                {
                    return false;
                }
                if (tblExtFileParamPerSet_colsEnumValue.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    return false;
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber PopulateValues()
        {
            #region Local Variables
            SalNumber nCountRow = 0;
            SalNumber nCurrentRow = 0;
            SalString sTempValue = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                // Bug 129482,begin, corrected the context.
                nCountRow = Sal.TblSetRow(this.tblExtFileParamPerSet, Sys.TBL_SetLastRow);
                nCurrentRow = Sal.TblSetRow(this.tblExtFileParamPerSet, Sys.TBL_SetFirstRow);
                while (nCurrentRow <= nCountRow)
                {
                    if (Sal.TblSetContext(this.tblExtFileParamPerSet, nCurrentRow))
                    {
                        if (tblExtFileParamPerSet_colsDefaultValue.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && tblExtFileParamPerSet_colEnumerate_Method.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            GetClientValue();
                        }
                        if (tblExtFileParamPerSet_colsDefaultValue.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && tblExtFileParamPerSet_colEnumerate_Method.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            tblExtFileParamPerSet_colsEnumValue.Text = tblExtFileParamPerSet_colsDefaultValue.Text;
                        }
                    }
                    nCurrentRow = nCurrentRow + 1;
                }
                // Bug 129482,end.
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
        private void tblExtFileParamPerSet_colsFileType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileParamPerSet_colsFileType_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileParamPerSet_colsFileType_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileParamPerSet_colsSetId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileParamPerSet_colsSetId_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileParamPerSet_colsSetId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileParamPerSet_colnParamNo_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileParamPerSet_colnParamNo_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileParamPerSet_colnParamNo_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileParamPerSet_colExtFileTypeParamDescription_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileParamPerSet_colExtFileTypeParamDescription_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileParamPerSet_colExtFileTypeParamDescription_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileParamPerSet_colsEnumValue_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // Bug 109752, Begin, Added another case for PM_DataItemQueryEnabled
                case Sys.SAM_Click:
                    this.tblExtFileParamPerSet_colsEnumValue_OnSAM_Click(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    this.tblExtFileParamPerSet_colsEnumValue_OnSAM_AnyEdit(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileParamPerSet_colsEnumValue_OnPM_DataItemQueryEnabled(sender, e);
                    break;
                // Bug 109752, End
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileParamPerSet_colsEnumValue_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.tblExtFileParamPerSet_colEnumerate_Method.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(this.tblExtFileParamPerSet_colEnumerate_Method.Text)))
                {
                    Sal.ListClear(tblExtFileParamPerSet_colsEnumValue.i_hWndSelf);
                    this.tblExtFileParamPerSet_colsEnumValue.p_sEnumerateMethod = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
                else
                {
                    this.tblExtFileParamPerSet_colsEnumValue.p_sEnumerateMethod = cSessionManager.c_sDbPrefix + this.tblExtFileParamPerSet_colEnumerate_Method.Text;
                    this.tblExtFileParamPerSet_colsEnumValue.LookupInit();
                }
            }
            else
            {
                Sal.ListClear(tblExtFileParamPerSet_colsEnumValue.i_hWndSelf);
                this.tblExtFileParamPerSet_colsEnumValue.p_sEnumerateMethod = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileParamPerSet_colsEnumValue_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions

            // Should always be possible to change the default value
            // Bug 109752,Begin, Added method to make the field uneditable when sytem defined check box is checked
            if (!this.cbSystemDefined.Checked)
            {
                e.Handled = true;
                if (this.tblExtFileParamPerSet_colEnumerate_Method.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    this.tblExtFileParamPerSet_colsDefaultValue.Text = this.tblExtFileParamPerSet_colsEnumValue.Text;
                    this.tblExtFileParamPerSet_colsDefaultValue.EditDataItemSetEdited();
                }
                else
                {
                    if (this.GetDbValue())
                    {
                        Sal.SendMsg(tblExtFileParamPerSet, Ifs.Fnd.ApplicationForms.Const.PM_DataItemStateSet, Ifs.Fnd.ApplicationForms.Const.EDIT_Empty, 0);
                    }
                    else
                    {
                        this.tblExtFileParamPerSet_colsDefaultValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        this.tblExtFileParamPerSet_colsEnumValue.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    }
                }
            #endregion

            }
            // Bug 109752, End

        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        // Bug 109752,Begin, Added method to make the field uneditable when sytem defined check box is checked
        private void tblExtFileParamPerSet_colsEnumValue_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        // Bug 109752,End

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblExtFileParamPerSet_colsMandatoryParam_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileParamPerSet_colsMandatoryParam_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileParamPerSet_colsMandatoryParam_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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

        // Bug 109752,Begin, Added method to make the field uneditable when sytem defined check box is checked
        private void tblExtFileParamPerSet_colsShowAtLoad_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileParamPerSet_colsShowAtLoad_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion

        }
        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileParamPerSet_colsShowAtLoad_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        // Bug 109752, End

        // Bug 109752,Begin, Added method to make the field uneditable when sytem defined check box is checked

        private void tblExtFileParamPerSet_colsInputableAtLoad_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblExtFileParamPerSet_colsInputableAtLoad_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion

        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblExtFileParamPerSet_colsInputableAtLoad_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.cbSystemDefined.Checked)
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
        // Bug 109752,End
        #endregion

        #endregion

        

      
	}
}
