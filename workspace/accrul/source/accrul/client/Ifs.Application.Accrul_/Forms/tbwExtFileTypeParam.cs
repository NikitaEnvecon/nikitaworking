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
	public partial class tbwExtFileTypeParam : cTableWindowFin
	{
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public tbwExtFileTypeParam()
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
		public new static tbwExtFileTypeParam FromHandle(SalWindowHandle handle)
		{
			return ((tbwExtFileTypeParam)SalWindow.FromHandle(handle, typeof(tbwExtFileTypeParam)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <param name="sLOV"></param>
		/// <returns></returns>
		public virtual SalBoolean ViewIsAvailable(SalString sLOV)
		{
			#region Local Variables
			SalString sOrgin = "";
			SalString sViewStatement = "";
			SalNumber nLength = 0;
			SalNumber nOffset = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sOrgin = sLOV;
				if (sOrgin.Right(1) == ")") 
				{
					nLength = sLOV.Length;
					nOffset = sOrgin.Scan("(");
					sViewStatement = sOrgin.Left(nOffset);
					return Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable(sViewStatement);
				}
				else
				{
					return Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable(sLOV);
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sFunc"></param>
		/// <returns></returns>
		public virtual SalBoolean FuncIsAvailable(SalString sFunc)
		{
			#region Local Variables
			SalString sOrgin = "";
			SalString sViewStatement = "";
			SalNumber nLength = 0;
			SalNumber nOffset = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sOrgin = sFunc;
				if (sOrgin.Right(1) == ")") 
				{
					nLength = sFunc.Length;
					nOffset = sOrgin.Scan("(");
					sViewStatement = sOrgin.Left(nOffset);
					return Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(sViewStatement);
				}
				else
				{
					return Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(sFunc);
				}
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
		private void tbwExtFileTypeParam_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.tbwExtFileTypeParam_OnPM_DataRecordNew(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
					this.tbwExtFileTypeParam_OnPM_DataRecordRemove(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tbwExtFileTypeParam_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
				if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam)) 
				{
					if (this.colExtFileTypeSystem_Defined.Text == "TRUE") 
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
		private void tbwExtFileTypeParam_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
				if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam)) 
				{
					if (this.colExtFileTypeSystem_Defined.Text == "TRUE") 
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
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void colsFileType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.colsFileType_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsFileType_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.colExtFileTypeSystem_Defined.Text == "TRUE") 
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
		private void colnParamNo_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.colnParamNo_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colnParamNo_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.colExtFileTypeSystem_Defined.Text == "TRUE") 
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
		private void colsParamId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.colsParamId_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsParamId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.colExtFileTypeSystem_Defined.Text == "TRUE") 
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
		private void colsDescription_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.colsDescription_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsDescription_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.colExtFileTypeSystem_Defined.Text == "TRUE") 
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
		private void colsBrowsableField_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.colsBrowsableField_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsBrowsableField_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.colExtFileTypeSystem_Defined.Text == "TRUE") 
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
		private void colsHelpText_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.colsHelpText_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsHelpText_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.colExtFileTypeSystem_Defined.Text == "TRUE") 
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
		private void colsValidateMethod_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.colsValidateMethod_OnPM_DataItemQueryEnabled(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.colsValidateMethod_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsValidateMethod_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.colExtFileTypeSystem_Defined.Text == "TRUE") 
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
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsValidateMethod_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.colsValidateMethod.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				if (!(this.FuncIsAvailable(this.colsValidateMethod.Text))) 
				{
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.ERROR_Method, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					this.colsValidateMethod.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
					e.Return = false;
					return;
				}
				e.Return = true;
				return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void colsLovView_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.colsLovView_OnPM_DataItemQueryEnabled(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.colsLovView_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsLovView_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.colExtFileTypeSystem_Defined.Text == "TRUE") 
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
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsLovView_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			// Bug 67699, Begin. Changed If condition and the Error msg.
			if (this.colsLovView.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && !(this.ViewIsAvailable(this.colsLovView.Text))) 
			{
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.ERROR_LovView, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
				e.Return = Sys.VALIDATE_Cancel;
				return;
			}
			// Bug 67699, End.
			e.Return = Sys.VALIDATE_Ok;
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void colsEnumerateMethod_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.colsEnumerateMethod_OnPM_DataItemQueryEnabled(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.colsEnumerateMethod_OnPM_DataItemValidate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsEnumerateMethod_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.colExtFileTypeSystem_Defined.Text == "TRUE") 
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
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsEnumerateMethod_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.colsEnumerateMethod.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable(this.colsEnumerateMethod.Text))) 
				{
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Ifs.Application.Accrul.Properties.Resources.ERROR_Method, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
					this.colsEnumerateMethod.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
					e.Return = false;
					return;
				}
				e.Return = true;
				return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void colsDataType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
					this.colsDataType_OnPM_DataItemQueryEnabled(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemQueryEnabled event handler.
		/// </summary>
		/// <param name="message"></param>
		private void colsDataType_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.colExtFileTypeSystem_Defined.Text == "TRUE") 
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
		#endregion
	}
}
