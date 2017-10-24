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
using PPJ.Runtime.Vis;

namespace Ifs.Application.Fndmig_
{
	
	/// <summary>
	/// </summary>
	/// <param name="sExeIntfaceName"></param>
	/// <param name="sExeInfo"></param>
	public partial class dlgExecPlan : cDialogBox
	{
		#region Window Parameters
		public SalString sExeIntfaceName;
		public SalString sExeInfo;
		#endregion
		
		#region Window Variables
		public SalDateTime __dtOldScheduledDate = SalDateTime.Null;
		public SalDateTime __dtOldScheduledTime = SalDateTime.Null;
		public SalDateTime __dtOldRepeatedTime = SalDateTime.Null;
		public SalString __lsTmp = "";
		public SalBoolean bSceduledDateEnabled = false;
		public SalBoolean bSceduledTimeEnabled = false;
		public SalBoolean bRepeatedTimeEnabled = false;
		public SalString sInfo = "";
		public SalString sIntfaceName = "";
		public SalString sProcedureName = "";
		public SalString sExecPlan = "";
		public SalString sLookupValues = "";
		public SalArray<SalString> sValue = new SalArray<SalString>();
		public SalString sClientValue = "";
		public SalString sDbValue = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgExecPlan()
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
		public static SalNumber ModalDialog(Control owner, SalString sExeIntfaceName, ref SalString sExeInfo)
		{
			dlgExecPlan dlg = DialogFactory.CreateInstance<dlgExecPlan>();
			dlg.sExeIntfaceName = sExeIntfaceName;
			dlg.sExeInfo = sExeInfo;
			SalNumber ret = dlg.ShowDialog(owner);
			sExeInfo = dlg.sExeInfo;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgExecPlan FromHandle(SalWindowHandle handle)
		{
			return ((dlgExecPlan)SalWindow.FromHandle(handle, typeof(dlgExecPlan)));
		}
		#endregion
		
		#region Methods
		
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
				OnRadioButtonClick();
			}

			return false;
			#endregion
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
				if (sMethod == "Cancel") 
				{
					return UM_Cancel(nWhat);
				}
				if (sMethod == "OK") 
				{
					return UM_OK(nWhat);
				}
				return 0;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ExecutePlan()
		{
			#region Local Variables
			SalBoolean bCommandOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				Sal.WaitCursor(true);
				sIntfaceName = sExeIntfaceName;
				sInfo = Ifs.Fnd.ApplicationForms.Const.strNULL;
				if (DbTransactionBegin(ref cSessionManager.c_hSql)) 
				{
					ParseExecutionPlan();
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Intface_Header_API.Start_Job", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						if (DbPLSQLBlock(cSessionManager.c_hSql, cSessionManager.c_sDbPrefix + "Intface_Header_API.Start_Job" + "( :i_hWndFrame.dlgExecPlan.sInfo,\r\n" +
							"                                :i_hWndFrame.dlgExecPlan.sExecPlan, :i_hWndFrame.dlgExecPlan.sExeIntfaceName)")) 
						{
							DbTransactionEnd(cSessionManager.c_hSql);
						}
						else
						{
							bCommandOk = DbCommit(cSessionManager.c_hSql);
							// gjohno 191199 Disabled so the rollback is not in function
							// Call DbTransactionClear(c_hSql)
							DbTransactionEnd(cSessionManager.c_hSql);
							Sal.WaitCursor(false);
							return false;
						}
					}
				}
				Sal.WaitCursor(false);
				sExeInfo = sInfo;
				Sal.EndDialog(i_hWndSelf, Sys.IDOK);
				return true;
			}
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
			SalString sIntervalSum = "";
			SalString sInterval = "";
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
				else if (rbDaily.Checked) 
				{
					if (GetRepeatedTime(ref sTime)) 
					{
						sExecPlan = "WEEKLY ON mon;tue;wed;thu;fri;sat;sun AT " + sTime;
						return true;
					}
					Ifs.Fnd.ApplicationForms.Int.ErrorBox(Properties.Resources.FNDMIG_BatchExecInvalidTime);
					return false;
				}
				else if (rbWeekly.Checked) 
				{
					if (GetRepeatedDays(ref sDays)) 
					{
						if (GetRepeatedTime(ref sTime)) 
						{
							sExecPlan = "WEEKLY ON " + sDays + " AT " + sTime;
							return true;
						}
						else
						{
							Ifs.Fnd.ApplicationForms.Int.ErrorBox(Properties.Resources.FNDMIG_BatchExecInvalidTime);
						}
					}
					else
					{
						Ifs.Fnd.ApplicationForms.Int.ErrorBox(Ifs.Fnd.ApplicationForms.Properties.Resources.__FNDINF_BatchExecInvalidDays);
					}
					return false;
				}
				else if (rbInterval.Checked) 
				{
					sIntervalSum = GetIntervalType();
					sInterval = dfnInterval.Number.ToString(0);
					sExecPlan = "SYSDATE+" + sInterval + "/" + sIntervalSum;
					return true;
				}
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
		/// <param name="sReturn"></param>
		/// <returns></returns>
		public virtual SalBoolean GetRepeatedTime(ref SalString sReturn)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Sal.IsNull(dfRepeatedTime)) 
				{
					return false;
				}
				sReturn = dfRepeatedTime.DateTime.ToString("hhhh:mm");
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sReturn"></param>
		/// <returns></returns>
		public virtual SalBoolean GetRepeatedDays(ref SalString sReturn)
		{
			#region Local Variables
			SalString sDelim = "";
			SalString sValue = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (cbMonday.Checked) 
				{
					sValue = sValue + sDelim + "mon";
					sDelim = ";";
				}
				if (cbTuesday.Checked) 
				{
					sValue = sValue + sDelim + "tue";
					sDelim = ";";
				}
				if (cbWednesday.Checked) 
				{
					sValue = sValue + sDelim + "wed";
					sDelim = ";";
				}
				if (cbThursday.Checked) 
				{
					sValue = sValue + sDelim + "thu";
					sDelim = ";";
				}
				if (cbFriday.Checked) 
				{
					sValue = sValue + sDelim + "fri";
					sDelim = ";";
				}
				if (cbSaturday.Checked) 
				{
					sValue = sValue + sDelim + "sat";
					sDelim = ";";
				}
				if (cbSunday.Checked) 
				{
					sValue = sValue + sDelim + "sun";
				}
				sReturn = sValue;
				return sValue != Ifs.Fnd.ApplicationForms.Const.strNULL;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sDays"></param>
		/// <returns></returns>
		public virtual SalBoolean SetRepeatedDays(SalString sDays)
		{
			#region Local Variables
			SalString sTmp = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sTmp = (sDays + ";").ToUpper();
				cbMonday.Checked = sTmp.Scan("MON;") >= 0;
				cbTuesday.Checked = sTmp.Scan("TUE;") >= 0;
				cbWednesday.Checked = sTmp.Scan("WED;") >= 0;
				cbThursday.Checked = sTmp.Scan("THU;") >= 0;
				cbFriday.Checked = sTmp.Scan("FRI;") >= 0;
				cbSaturday.Checked = sTmp.Scan("SAT;") >= 0;
				cbSunday.Checked = sTmp.Scan("SUN;") >= 0;
				return sDays != Ifs.Fnd.ApplicationForms.Const.strNULL;
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
					else if (rbDaily.Checked) 
					{
						SetValue("BATCH_TYPE", "WEEKLY");
					}
					else if (rbWeekly.Checked) 
					{
						SetValue("BATCH_TYPE", "WEEKLY");
					}
				}
				SetScheduledTimeEnable();
				SetScheduledDateEnable();
				SetRepeatedIntervalEnable();
				SetRepeatedTimeEnable();
				SetRepeatedDaysEnable();
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
				Sal.DisableWindowAndLabel(dfRepeatedTime);
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
		public virtual SalNumber SetRepeatedTimeEnable()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (rbDaily.Checked || rbWeekly.Checked) 
				{
					if (!(bRepeatedTimeEnabled))  // SalIsWindowEnabled( dfRepeatedTime )
					{
						dfRepeatedTime.DateTime = __dtOldRepeatedTime;
						Sal.EnableWindowAndLabel(dfRepeatedTime);
						bRepeatedTimeEnabled = true;
					}
				}
				else
				{
					if (bRepeatedTimeEnabled)  // SalIsWindowEnabled( dfRepeatedTime )
					{
						__dtOldRepeatedTime = dfRepeatedTime.DateTime;
						Sal.ClearField(dfRepeatedTime);
						Sal.DisableWindowAndLabel(dfRepeatedTime);
						bRepeatedTimeEnabled = false;
					}
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SetRepeatedDaysEnable()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (rbWeekly.Checked) 
				{
					Sal.EnableWindow(cbMonday);
					Sal.EnableWindow(cbTuesday);
					Sal.EnableWindow(cbWednesday);
					Sal.EnableWindow(cbThursday);
					Sal.EnableWindow(cbFriday);
					Sal.EnableWindow(cbSaturday);
					Sal.EnableWindow(cbSunday);
				}
				else
				{
					Sal.DisableWindow(cbMonday);
					Sal.DisableWindow(cbTuesday);
					Sal.DisableWindow(cbWednesday);
					Sal.DisableWindow(cbThursday);
					Sal.DisableWindow(cbFriday);
					Sal.DisableWindow(cbSaturday);
					Sal.DisableWindow(cbSunday);
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
				if (sExecPlan.Left(9) == "DAILY AT ") 
				{
					__dtOldScheduledDate = SalDateTime.Current;
					__dtOldScheduledTime = SalDateTime.Current;
					__dtOldRepeatedTime = new SalDateTime(SalDateTime.Current.Year(), SalDateTime.Current.Month(), SalDateTime.Current.Day(), nHour, nMinute, 0);
					rbDaily.Checked = true;
					return true;
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
				if (sExecPlan.Left(10) == "WEEKLY ON ") 
				{
					if (SetRepeatedDays(sExecPlan.Mid(10, nPos - 10))) 
					{
						__dtOldScheduledDate = SalDateTime.Current;
						__dtOldScheduledTime = SalDateTime.Current;
						__dtOldRepeatedTime = new SalDateTime(SalDateTime.Current.Year(), SalDateTime.Current.Month(), SalDateTime.Current.Day(), nHour, nMinute, 0);
						rbWeekly.Checked = true;
						return true;
					}
				}
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SetRepeatedIntervalEnable()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (!(rbInterval.Checked)) 
				{
					Sal.DisableWindow(dfnInterval);
					Sal.DisableWindow(cmbInterval);
				}
				else
				{
					Sal.EnableWindow(dfnInterval);
					Sal.EnableWindow(cmbInterval);
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber LoadInvervals()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("INTFACE_EXEC_INTERVAL_TYPE_API.Enumerate", System.Data.ParameterDirection.Output);
					if (DbPLSQLBlock(cSessionManager.c_hSql, "&AO.INTFACE_EXEC_INTERVAL_TYPE_API.Enumerate(:i_hWndSelf.dlgExecPlan.sLookupValues)")) 
					{
						sLookupValues.Tokenize(((SalNumber)31).ToCharacter(), ((SalNumber)31).ToCharacter(), sValue);
						Vis.ListArrayPopulate(cmbInterval, sValue);
						Sal.SetWindowText(cmbInterval, sValue[0]);
						// Select the value that was populated before lookup
						// If _LookupFormatPlSqlEnumerate( ':i_hWndSelf.cComboBox.__lsLookupValues', lsStmt )
						// Set __lsLookupValues = strNULL
						// If DbPLSQLBlock( c_hSql, lsStmt )
						// Call SalStrTokenize( __lsLookupValues, SalNumberToChar(31), SalNumberToChar(31), sValue )
						// Save currently populated value
						// Set sOldValue =  MyValue
						// Save edit flag
						// Set bEditFlag = SalQueryFieldEdit( i_hWndSelf )
						// Populate list
						// Call SalListClear( i_hWndSelf )
						// Call VisListArrayPopulate( i_hWndSelf, sValue )
						// Select the value that was populated before lookup
						// Call SalSetWindowText( i_hWndSelf, sOldValue )
						// Restore edit flag
						// Call SalSetFieldEdit( i_hWndSelf, bEditFlag )
					}
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// Applications override the FrameStartupUser function to perform
		/// actions when a window has been started.
		/// COMMENTS:
		/// Common actions to perform at this time is populating the window
		/// with special data, changeing the window title etc.
		/// 
		/// The FrameStartupUser is called by the framework after a window
		/// has been complete created and is visible on the screen, but before
		/// the framework executes any startup behvior according to the properties
		/// for that window.
		/// 
		/// Note: If this function is overriden on a form or table window some code
		/// must be supplied in order to support the standard framework functionality
		/// DataTransfer.
		/// EXAMPLE:
		/// Function: FrameStartupUser
		/// 	Actions
		/// 		Call SetWindowTitle( )
		/// 		If DataTransfer.RecCountGet( ) > 0
		/// 			Call SalWaitCursor( TRUE )
		/// 			Call InitFromTransferredData( )
		/// 			Call DataTransfer.Reset( )
		/// 			Call SalWaitCursor( FALSE )
		/// 			Return FALSE
		/// 		Else
		/// 			Call SalWaitCursor( FALSE )
		/// 			Return TRUE
		/// 		Return TRUE
		/// </summary>
		/// <returns>
		/// Applications should return FALSE to skip standard window startup logic (such
		/// as exectuing the "startup behavior" settings), or TRUE to allow standard logic.
		/// </returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Actions
			using (new SalContext(this))
			{
				LoadInvervals();
				SetRepeatedDaysEnable();
				SetRepeatedIntervalEnable();
				SetRepeatedTimeEnable();
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalString GetIntervalType()
		{
			#region Actions
			using (new SalContext(this))
			{
				return GetDbValue("INTFACE_EXEC_INTERVAL_TYPE_API", cmbInterval.Text);
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sPackage"></param>
		/// <param name="sParamClientValue"></param>
		/// <returns></returns>
		public virtual SalString GetDbValue(SalString sPackage, SalString sParamClientValue)
		{
			#region Local Variables
			SalBoolean bResult = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sClientValue = sParamClientValue;
				bResult = DbPLSQLBlock(cSessionManager.c_hSql, "\r\n" +
					"BEGIN\r\n" +
					"	:i_hWndFrame.dlgExecPlan.sDbValue := &AO." + sPackage + ".ENCODE(:i_hWndFrame.dlgExecPlan.sClientValue);\r\nEND;");
				return sDbValue;
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
		public virtual SalBoolean UM_OK(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						return ExecutePlan();
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
		private void dlgExecPlan_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				// ----------------------------------------
				
				// SQLWindows messages (SAL)
				
				// ----------------------------------------
				
				case Sys.SAM_Create:
					this.dlgExecPlan_OnSAM_Create(sender, e);
					break;
				
				case Sys.SAM_CreateComplete:
					this.dlgExecPlan_OnSAM_CreateComplete(sender, e);
					break;
				
				// ! ----------------------------------------
				
				// ! Public IFS/Client messages (PM)
				
				// ! ----------------------------------------
				
				// ! ----------------------------------------
				
				// ! Private IFS/Client messages (AM)
				
				// ! ----------------------------------------
				
				case Ifs.Fnd.ApplicationForms.Const.AM_DataSourceGet:
					e.Handled = true;
					e.Return = Sal.SendMsg(Sal.ParentWindow(this), Ifs.Fnd.ApplicationForms.Const.AM_DataSourceGet, Sys.wParam, Sys.lParam);
					return;
				
				// ! ----------------------------------------
				
				// ! Windows API messages (WM, EM, WN)
				
				// ! ----------------------------------------
				
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
		private void dlgExecPlan_OnSAM_Create(object sender, WindowActionsEventArgs e)
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
		private void dlgExecPlan_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
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
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void rbInterval_WindowActions(object sender, WindowActionsEventArgs e)
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
		private void rbDaily_WindowActions(object sender, WindowActionsEventArgs e)
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
		private void rbWeekly_WindowActions(object sender, WindowActionsEventArgs e)
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
		public override SalBoolean vrtFrameStartupUser()
		{
			return this.FrameStartupUser();
		}
		
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
