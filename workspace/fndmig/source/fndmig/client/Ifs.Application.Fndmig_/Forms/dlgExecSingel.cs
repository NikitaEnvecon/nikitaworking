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
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Fndmig_
{
	
	/// <summary>
	/// </summary>
	/// <param name="sExeIntfaceName"></param>
	/// <param name="bNoError"></param>
	/// <param name="bDirection"></param>
	/// <param name="bJobOk"></param>
	/// <param name="bFileReady"></param>
	/// <param name="sExecInfo"></param>
	public partial class dlgExecSingel : cDialogBox
	{
		#region Window Parameters
		public SalString sExeIntfaceName;
		public SalBoolean bNoError;
		public SalBoolean bDirection;
		public SalBoolean bJobOk;
		public SalBoolean bFileReady;
		public SalString sExecInfo;
		#endregion
		
		#region Window Variables
		public SalDateTime __dtDateTime = SalDateTime.Null;
		public SalDateTime __dtOldScheduledDate = SalDateTime.Null;
		public SalDateTime __dtOldScheduledTime = SalDateTime.Null;
		public SalDateTime __dtOldRepeatedTime = SalDateTime.Null;
		public SalString __lsTmp = "";
		public SalArray<SalString> sPrinters = new SalArray<SalString>();
		public SalString sName = "";
		public SalString sExecPlan = "";
		public SalNumber i_nPrinterCount = 0;
		public SalNumber i_nMessageSelected = 0;
		public SalNumber i_nPrinterSelected = 0;
		public SalBoolean bSceduledDateEnabled = false;
		public SalBoolean bSceduledTimeEnabled = false;
		public SalBoolean bRepeatedTimeEnabled = false;
		public SalString sInfo = "";
		public SalString sIntfaceName = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgExecSingel()
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
		public static SalNumber ModalDialog(Control owner, SalString sExeIntfaceName, SalBoolean bNoError, SalBoolean bDirection, SalBoolean bJobOk, SalBoolean bFileReady, ref SalString sExecInfo)
		{
			dlgExecSingel dlg = DialogFactory.CreateInstance<dlgExecSingel>();
			dlg.sExeIntfaceName = sExeIntfaceName;
			dlg.bNoError = bNoError;
			dlg.bDirection = bDirection;
			dlg.bJobOk = bJobOk;
			dlg.bFileReady = bFileReady;
			dlg.sExecInfo = sExecInfo;
			SalNumber ret = dlg.ShowDialog(owner);
			sExecInfo = dlg.sExecInfo;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgExecSingel FromHandle(SalWindowHandle handle)
		{
			return ((dlgExecSingel)SalWindow.FromHandle(handle, typeof(dlgExecSingel)));
		}
		#endregion
		
		#region Methods
		
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
				if (sMethod == "StartProcedure") 
				{
					return UM_Start(nWhat);
				}
				else if (sMethod == "RestartProcedure") 
				{
					return UM_Restart(nWhat);
				}
				else if (sMethod == "Cancel") 
				{
					return UM_Cancel(nWhat);
				}
				return 0;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sTypeOfExecution"></param>
		/// <returns></returns>
		public virtual SalBoolean ExecuteJob(SalString sTypeOfExecution)
		{
			#region Local Variables
			SalBoolean bCommandOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				Sal.WaitCursor(true);
				sIntfaceName = sExeIntfaceName;
				if (sTypeOfExecution == "Start") 
				{
					sInfo = Ifs.Fnd.ApplicationForms.Const.strNULL;
				}
				else
				{
					sInfo = "RESTART";
				}
				if (DbTransactionBegin(ref cSessionManager.c_hSql)) 
				{
					ParseExecutionPlan();
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Intface_Header_API.Start_Job", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Intface_Header_API.Start_Job" + "( :i_hWndFrame.dlgExecSingel.sInfo,\r\n" +
							"                                :i_hWndFrame.dlgExecSingel.sExecPlan, :i_hWndFrame.dlgExecSingel.sIntfaceName)")) 
						{
							DbTransactionEnd(cSessionManager.c_hSql);
						}
						else
						{
							bCommandOk = DbCommit(cSessionManager.c_hSql);
							// gjohno 191199 Disabled so the rollback is not in function
							// Call DbTransactionClear(c_hSql)
							DbTransactionEnd(cSessionManager.c_hSql);
						}
					}
				}
				// If sExecPlan = 'ONLINE'
				// Call i_hWndParent.frmIntfaceStart.Refresh( METHOD_Execute )
				Sal.WaitCursor(false);
				sExecInfo = sInfo;
				Sal.EndDialog(i_hWndSelf, Sys.IDOK);
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean StartupUser()
		{
			#region Local Variables
			SalString lsValue = "";
			SalArray<SalString> sArray = new SalArray<SalString>();
			SalNumber n = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				// boolean flags used to workaround Centura bugg, SalIsWindowEnabled( ).
				bSceduledDateEnabled = true;
				bSceduledTimeEnabled = true;
				bRepeatedTimeEnabled = true;
				if (GetValue("JOB_ID", ref lsValue)) 
				{
					if (lsValue != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						Sal.DisableWindow(rbOnline);
					}
					else
					{
						Sal.EnableWindow(rbOnline);
					}
				}
				else
				{
					Sal.EnableWindow(rbOnline);
				}
				DisableAll();
				if (GetValue("BATCH_TYPE", ref lsValue)) 
				{
					if (lsValue == "ONLINE" || lsValue == Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						__dtOldScheduledDate = SalDateTime.Current;
						__dtOldScheduledTime = SalDateTime.Current;
						__dtOldRepeatedTime = SalDateTime.Current;
					}
					else
					{
						SetExecutionPlan(lsValue);
						// get batch setup
					}
				}
				else
				{
					__dtOldScheduledDate = SalDateTime.Current;
					__dtOldScheduledTime = SalDateTime.Current;
					__dtOldRepeatedTime = SalDateTime.Current;
				}
				// If GetValue( 'JOB_NAME', lsValue )
				// Set dfJobName = lsValue
				// gjohno - next six commented
				// Call SalListInsert( cmbMessage, -1, TranslateConstant( FNDINF_MessageNone ) )
				// Call SalListInsert( cmbMessage, -1, TranslateConstant( FNDINF_MessageSocketMessage ) )
				// Call SalListInsert( cmbMessage, -1, TranslateConstant( FNDINF_MessageEmail ) )
				// If DbPLSQLBlock( c_hSql, c_sDbPrefix || 'Print_Server_SYS.Enumerate_Printer_Id( :i_hWndFrame.dlgBatchOrder.__lsTmp )' )
				// If __lsTmp != strNULL
				// Set i_nPrinterCount = SalStrTokenize( SalNumberToChar( CHAR_US ) || __lsTmp, SalNumberToChar( CHAR_US ), SalNumberToChar( CHAR_US ), sPrinters )
				// While n < i_nPrinterCount
				// Call SalStrTokenize( ',' || sPrinters[n] || ',', ',', ',', sArray )
				// Call SalListInsert( cmbPrinter, -1, sArray[0] || ' ' || TranslateConstant( __FNDINF_PrintToken_ON_ ) || ' ' || sArray[2] )
				// Set n = n + 1
				// Call SalListInsert( cmbMessage, -1, TranslateConstant( FNDINF_MessagePrintServer ) )
				// If GetValue( 'MESSAGE_TYPE', lsValue )
				// If lsValue = 'NONE'
				// Set i_nMessageSelected = 0
				// Set i_nPrinterSelected = -1
				// Else If lsValue = 'SOCKETMSG'
				// Set i_nMessageSelected = 1
				// Set i_nPrinterSelected = -1
				// Else If lsValue = 'EMAIL'
				// Set i_nMessageSelected = 2
				// Set i_nPrinterSelected = -1
				// Else If lsValue = 'PRINTER'
				// Set i_nMessageSelected = 3
				// If GetValue( 'PRINTER_ID', lsValue )
				// Set i_nPrinterSelected = VisArrayFindString( sPrinters, lsValue )
				// Else
				// Set i_nPrinterSelected = -1
				// Else
				// Set i_nMessageSelected = 1
				// Set i_nPrinterSelected = -1
				// Else
				// Set i_nMessageSelected = 1
				// Set i_nPrinterSelected = -1
				OnRadioButtonClick();
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sItem"></param>
		/// <param name="lsValue"></param>
		/// <returns></returns>
		public virtual SalBoolean GetValue(SalString sItem, ref SalString lsValue)
		{
			#region Local Variables
			SalString lsItemValue = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				lsItemValue = SalString.FromHandle(Sal.SendMsg(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf), Ifs.Fnd.ApplicationForms.Const.AM_TabMaster, Ifs.Fnd.ApplicationForms.Const.FNDINF_MasterValueGet, sItem.ToHandle()));
				if (sItem + "=" == lsItemValue.Left(sItem.Length + 1)) 
				{
					lsValue = lsItemValue.Right(lsItemValue.Length - sItem.Length - 1);
					return true;
				}
				lsValue = Ifs.Fnd.ApplicationForms.Const.strNULL;
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sItem"></param>
		/// <param name="lsValue"></param>
		/// <returns></returns>
		public virtual SalBoolean SetValue(SalString sItem, SalString lsValue)
		{
			#region Actions
			using (new SalContext(this))
			{
				return Sal.SendMsg(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf), Ifs.Fnd.ApplicationForms.Const.AM_TabMaster, Ifs.Fnd.ApplicationForms.Const.FNDINF_MasterValueSet, (sItem + "=" + lsValue).ToHandle());
			}
			#endregion
		}
		
		/// <summary>
		/// return the execution plan
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ParseExecutionPlan()
		{
			// Receive String: sExecPlan
			
			#region Local Variables
			SalString sDate = "";
			SalString sTime = "";
			SalString sDays = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (rbOnline.Checked) 
				{
					sExecPlan = "ONLINE";
					return true;
				}
				else if (rbAsap.Checked) 
				{
					sExecPlan = "ASAP";
					return true;
				}
				else if (rbScheduled.Checked) 
				{
					if (GetScheduledDate(ref sDate)) 
					{
						if (GetScheduledTime(ref sTime)) 
						{
							sExecPlan = "ON " + sDate + " AT " + sTime;
							return true;
						}
						else
						{
							Ifs.Fnd.ApplicationForms.Int.ErrorBox(Properties.Resources.FNDMIG_BatchExecInvalidTime);
						}
					}
					else
					{
						Ifs.Fnd.ApplicationForms.Int.ErrorBox(Properties.Resources.FNDMIG_BatchExecInvalidDate);
					}
					return false;
				}
				// Else If rbDaily
				// If GetRepeatedTime( sTime )
				// Set sExecPlan = 'WEEKLY ON mon;tue;wed;thu;fri;sat;sun AT ' || sTime
				// Return TRUE
				// Call ErrorBox( TranslateConstant( __FNDINF_BatchExecInvalidTime ) )
				// Return FALSE
				// Else If rbWeekly
				// If GetRepeatedDays( sDays )
				// If GetRepeatedTime( sTime )
				// Set sExecPlan = 'WEEKLY ON ' || sDays || ' AT ' || sTime
				// Return TRUE
				// Else
				// Call ErrorBox( TranslateConstant( __FNDINF_BatchExecInvalidTime ) )
				// Else
				// Call ErrorBox( TranslateConstant( __FNDINF_BatchExecInvalidDays ) )
				// Return FALSE
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sReturn"></param>
		/// <returns></returns>
		public virtual SalBoolean GetScheduledTime(ref SalString sReturn)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.IsNull(dfScheduledTime)) 
				{
					return false;
				}
				sReturn = dfScheduledTime.DateTime.ToString("hhhh:mm");
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sReturn"></param>
		/// <returns></returns>
		public virtual SalBoolean GetScheduledDate(ref SalString sReturn)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.IsNull(dfScheduledDate)) 
				{
					return false;
				}
				sReturn = dfScheduledDate.DateTime.ToString("yyyy-MM-dd");
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean OnRadioButtonClick()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (rbOnline.Checked) 
				{
					// Call SalDisableWindowAndLabel( dfJobName )
					// Call SalDisableWindowAndLabel( cmbMessage )
					// Call SalDisableWindowAndLabel( cmbPrinter )
					// Call SalListSetSelect( cmbPrinter, -1 )
					// Call SalListSetSelect( cmbMessage, -1 )
					SetValue("BATCH_TYPE", "ONLINE");
				}
				else
				{
					// Call SalEnableWindowAndLabel( dfJobName )
					// Call SalEnableWindowAndLabel( cmbMessage )
					// Call SalListSetSelect( cmbPrinter, i_nPrinterSelected )
					// Call SalListSetSelect( cmbMessage, i_nMessageSelected )
					// If SalListQuerySelection( cmbMessage ) = 3
					// Call SalEnableWindowAndLabel( cmbPrinter )
					if (rbAsap.Checked) 
					{
						SetValue("BATCH_TYPE", "ASAP");
					}
					else if (rbScheduled.Checked) 
					{
						SetValue("BATCH_TYPE", "ON");
					}
					// Else If rbDaily
					// Call SetValue( 'BATCH_TYPE', 'WEEKLY' )
					// Else If rbWeekly
					// Call SetValue( 'BATCH_TYPE', 'WEEKLY' )
				}
				SetScheduledTimeEnable();
				SetScheduledDateEnable();
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber DisableAll()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.DisableWindowAndLabel(dfScheduledTime);
				Sal.DisableWindowAndLabel(dfScheduledDate);
				bSceduledDateEnabled = false;
				bSceduledTimeEnabled = false;
				bRepeatedTimeEnabled = false;
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SetScheduledTimeEnable()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (rbScheduled.Checked) 
				{
					if (!(bSceduledTimeEnabled))  // SalIsWindowEnabled( dfScheduledTime )
					{
						dfScheduledTime.DateTime = __dtOldScheduledTime;
						Sal.EnableWindowAndLabel(dfScheduledTime);
						bSceduledTimeEnabled = true;
					}
				}
				else
				{
					if (bSceduledTimeEnabled)  // SalIsWindowEnabled( dfScheduledTime )
					{
						__dtOldScheduledTime = dfScheduledTime.DateTime;
						Sal.ClearField(dfScheduledTime);
						Sal.DisableWindowAndLabel(dfScheduledTime);
						bSceduledTimeEnabled = false;
					}
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SetScheduledDateEnable()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (rbScheduled.Checked) 
				{
					if (!(bSceduledDateEnabled))  // SalIsWindowEnabled( dfScheduledDate )
					{
						dfScheduledDate.DateTime = __dtOldScheduledDate;
						Sal.EnableWindowAndLabel(dfScheduledDate);
						bSceduledDateEnabled = true;
					}
				}
				else
				{
					if (bSceduledDateEnabled)  // SalIsWindowEnabled( dfScheduledDate )
					{
						__dtOldScheduledDate = dfScheduledDate.DateTime;
						Sal.ClearField(dfScheduledDate);
						Sal.DisableWindowAndLabel(dfScheduledDate);
						bSceduledDateEnabled = false;
					}
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sExecPlan"></param>
		/// <returns></returns>
		public virtual SalBoolean SetExecutionPlan(SalString sExecPlan)
		{
			#region Local Variables
			SalString sDate = "";
			SalString sTime = "";
			SalNumber nPos = 0;
			SalNumber nHour = 0;
			SalNumber nMinute = 0;
			SalNumber nYear = 0;
			SalNumber nMonth = 0;
			SalNumber nDay = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (sExecPlan == "ASAP ") 
				{
					__dtOldScheduledDate = SalDateTime.Current;
					__dtOldScheduledTime = SalDateTime.Current;
					__dtOldRepeatedTime = SalDateTime.Current;
					rbAsap.Checked = true;
					return true;
				}
				nPos = sExecPlan.Scan(" AT ");
				if (nPos >= 0) 
				{
					sTime = sExecPlan.Right(sExecPlan.Length - nPos - 4);
					nHour = sTime.Left(2).ToNumber();
					nMinute = sTime.Right(2).ToNumber();
				}
				else
				{
					nHour = 0;
					nMinute = 0;
					nPos = sExecPlan.Length;
				}
				if (sExecPlan.Left(3) == "ON ") 
				{
					sDate = sExecPlan.Mid(3, nPos - 3);
					nYear = sDate.Left(4).ToNumber();
					nMonth = sDate.Mid(5, 2).ToNumber();
					nDay = sDate.Mid(8, 2).ToNumber();
					__dtOldScheduledDate = new SalDateTime(nYear, nMonth, nDay, nHour, nMinute, 0);
					__dtOldScheduledTime = __dtOldScheduledDate;
					__dtOldRepeatedTime = SalDateTime.Current;
					rbScheduled.Checked = true;
					return true;
				}
				return false;
			}
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
						return Sal.EndDialog(i_hWndSelf, Sys.IDCANCEL);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Start(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (bDirection) 
						{
							return true;
						}
						else if (bNoError || bJobOk) 
						{
							return false;
						}
						else if (bFileReady) 
						{
							return false;
						}
						else
						{
							return true;
						}
						goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						return ExecuteJob("Start");
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Restart(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (!(bNoError)) 
						{
							return false;
						}
						else
						{
							return true;
						}
						goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						return ExecuteJob("Restart");
				}
			}

			return false;
			#endregion
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dlgExecSingel_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				// ----------------------------------------
				
				// SQLWindows messages (SAL)
				
				// ----------------------------------------
				
				case Sys.SAM_Create:
					this.dlgExecSingel_OnSAM_Create(sender, e);
					break;
				
				case Sys.SAM_CreateComplete:
					this.dlgExecSingel_OnSAM_CreateComplete(sender, e);
					break;
				
				// ----------------------------------------
				
				// Public IFS/Client messages (PM)
				
				// ----------------------------------------
				
				// ----------------------------------------
				
				// Private IFS/Client messages (AM)
				
				// ----------------------------------------
				
				case Ifs.Fnd.ApplicationForms.Const.AM_DataSourceGet:
					e.Handled = true;
					e.Return = Sal.SendMsg(Sal.ParentWindow(this), Ifs.Fnd.ApplicationForms.Const.AM_DataSourceGet, Sys.wParam, Sys.lParam);
					return;
				
				// ----------------------------------------
				
				// Windows API messages (WM, EM, WN)
				
				// ----------------------------------------
				
				case Ifs.Fnd.ApplicationForms.Const.WM_PASTE:
					e.Handled = true;
					e.Return = false;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgExecSingel_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			// Ordinary startup through FramStartupUser does not work!!
			Sal.PostMsg(this.i_hWndSelf, Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// SAM_CreateComplete event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgExecSingel_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam);
			// Ordinary startup through FramStartupUser does not work!!
			this.StartupUser();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void rbOnline_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					e.Handled = true;
					this.OnRadioButtonClick();
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void rbAsap_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					e.Handled = true;
					this.OnRadioButtonClick();
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void rbScheduled_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					e.Handled = true;
					this.OnRadioButtonClick();
					break;
			}
			#endregion
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
		{
			return this.UserMethod(nWhat, sMethod);
		}
		#endregion
	}
}
