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
	public partial class frmPostCtrlDetSpec : cFormWindowFin
	{
		#region Window Variables
		public SalBoolean bReturn = false;
		public SalString sControlTypeName = "";
		public SalString sCodePartName = "";
		public SalString sCodePart = "";
		public SalString sView = "";
		public SalString sModule = "";
		public SalString sDescription = "";
		public SalString sCtrlTypeCategory = "";
		public SalString sPkgName = "";
		public SalString sControlType = "";
		public SalString sControlTypeValue = "";
		public SalString sControlTypeValueDesc = "";
		public SalString sSql = "";
		public SalString sCodePartValue = "";
		public SalString sCodePartValueDesc = "";
		public SalString sTempLovReference = "";
		public SalString sDummy1 = "";
		public SalString sDummy2 = "";
		public SalString sDummy3 = "";
		public SalString sDummy4 = "";
		public SalBoolean bBlockPopulate = false;
		public SalDateTime dPCStartDate = SalDateTime.Null;
		public SalDateTime dPCEndDate = SalDateTime.Null;
		public SalDateTime dStartDate = SalDateTime.Null;
		public SalDateTime dEndDate = SalDateTime.Null;
        public SalNumber nTemp1 = 0;
        public SalNumber nTemp2 = 0;
        public SalArray<SalString> sKeyCols = new SalArray<SalString>();
        public SalArray<SalString> sLovCols = new SalArray<SalString>();
        

		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmPostCtrlDetSpec()
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
		public new static frmPostCtrlDetSpec FromHandle(SalWindowHandle handle)
		{
			return ((frmPostCtrlDetSpec)SalWindow.FromHandle(handle, typeof(frmPostCtrlDetSpec)));
		}
		#endregion
		
		#region Methods
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    bBlockPopulate = false;
                    Sal.WaitCursor(true);
                    InitFromTransferredData();
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    GetControlTypeAttribs();
                    Sal.WaitCursor(false);
                    bBlockPopulate = true;
                    return false;
                }
                return base.Activate(URL);
            }
            #endregion
            
        }
		
		/// <summary>
		/// </summary>
		/// <param name="bPopulateSingle"></param>
		/// <returns></returns>
		public SalBoolean DataSourcePopulateIt(SalBoolean bPopulateSingle)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (((cDataSource)this).DataSourcePopulateIt(bPopulateSingle)) 
				{
					return GetControlTypeAttribs();
				}
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean GetControlTypeAttribs()
		{
			#region Actions
			using (new SalContext(this))
			{
				sControlType = dfsSpecControlType.Text;
				sModule = dfsSpecModule.Text;
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Posting_Ctrl_Control_Type_API.Get_Control_Type_Attri_") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Reference_SYS.Get_Lov_Properties")) 
				{
                    string stmt = @"DECLARE
	                                    view_			VARCHAR2(200); 
	                                    no_param_view_	VARCHAR2(200); 
	                                    temp_num_		NUMBER := 0; 
                                    BEGIN 
	                                    &AO.Posting_Ctrl_Control_Type_API.Get_Control_Type_Attri_({0} OUT, {1} OUT, {2} OUT, {3} OUT, {4} IN, {5} IN);
                                        view_ := {2};
	                                    temp_num_ := INSTR(view_, '('); 
	                                    IF temp_num_ > 0 THEN 
		                                    no_param_view_ := substr(view_,1,temp_num_ - 1); 
	                                    ELSE 
		                                    no_param_view_ := view_; 
	                                    END IF; 
	                                    &AO.Reference_SYS.Get_Lov_Properties( no_param_view_, {6} OUT, {7} OUT, {8} OUT, {9} OUT);
                                    END;";

                    if(!(DbPLSQLBlock(stmt, this.QualifiedVarBindName("sDescription"),
                                            this.QualifiedVarBindName("sCtrlTypeCategory"),
                                            this.QualifiedVarBindName("sView"),
                                            this.QualifiedVarBindName("sPkgName"),
                                            this.QualifiedVarBindName("sControlType"),
                                            this.QualifiedVarBindName("sModule"),
                                            this.QualifiedVarBindName("sDummy1"),
                                            this.QualifiedVarBindName("sDummy2"),
                                            this.QualifiedVarBindName("sDummy3"),
                                            this.QualifiedVarBindName("sDummy4"))))
                    {
                        return false;
                    }
                    

				}
				Sal.TblSetColumnTitle(tblPostCtrlDetSpec_colSpecControlTypeValue, sDescription);
				if (dfPostingType.Text == "IP3" || dfPostingType.Text == "PP18" || dfPostingType.Text == "PP44" || dfPostingType.Text == "PP48" || dfPostingType.Text == "PP49") 
				{
					if (dfsSpecControlType.Text == "AC7") 
					{
						sView = "STATUTORY_FEE_DEDUCTIBLE(COMPANY)";
					}
				}
				sCodePartName = dfsCodeName.Text;
				Sal.TblSetColumnTitle(tblPostCtrlDetSpec_colCodePartValue, sCodePartName);
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetControlTypeDesc()
		{
			#region Actions
			using (new SalContext(this))
			{
				// Bug 75985, Changes to Block
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Posting_Ctrl_Control_Type_API.Get_Control_Type_Desc_", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					DbPLSQLBlock(cSessionManager.c_hSql, " :i_hWndFrame.frmPostCtrlDetSpec.sControlTypeValueDesc := &AO.Posting_Ctrl_Control_Type_API.Get_Control_Type_Desc_(\r\n" +
						"                                                                    :i_hWndFrame.frmPostCtrlDetSpec.i_sCompany,\r\n" +
						"                                                                    :i_hWndFrame.frmPostCtrlDetSpec.sControlType,\r\n" +
						"                                                                    :i_hWndFrame.frmPostCtrlDetSpec.sControlTypeValue,\r\n" +
						"                                                                    :i_hWndFrame.frmPostCtrlDetSpec.sView,\r\n" +
						"                                                                    :i_hWndFrame.frmPostCtrlDetSpec.sPkgName,\r\n" +
						"                                                                    :i_hWndFrame.frmPostCtrlDetSpec.sModule)");
				}
				// Bug 75985, End
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// Called from Posting Control Navigator
		/// </summary>
		/// <param name="sWhere"></param>
		/// <param name="dValidFrom"></param>
		/// <param name="dPCValidFrom"></param>
		/// <returns></returns>
		public virtual SalNumber SetWhere(SalString sWhere, SalDateTime dValidFrom, SalDateTime dPCValidFrom)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (dValidFrom != SalDateTime.Null) 
				{
					Int.PalDateGetDayInterval(dValidFrom, ref dStartDate, ref dEndDate);
					sWhere = sWhere + " AND (VALID_FROM between :i_hWndFrame.frmPostCtrlDetSpec.dStartDate AND :i_hWndFrame.frmPostCtrlDetSpec.dEndDate) ";
				}
				if (dPCValidFrom != SalDateTime.Null) 
				{
					Int.PalDateGetDayInterval(dPCValidFrom, ref dPCStartDate, ref dPCEndDate);
					sWhere = sWhere + " AND (PC_VALID_FROM between :i_hWndFrame.frmPostCtrlDetSpec.dPCStartDate AND :i_hWndFrame.frmPostCtrlDetSpec.dPCEndDate) ";
				}
				p_lsDefaultWhere = sWhere;
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
		private void frmPostCtrlDetSpec_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
					this.frmPostCtrlDetSpec_OnPM_DataSourcePopulate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourcePopulate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmPostCtrlDetSpec_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.bBlockPopulate == true) 
			{
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
		private void tblPostCtrlDetSpec_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_FetchRowDone:
					this.tblPostCtrlDetSpec_OnSAM_FetchRowDone(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.tblPostCtrlDetSpec_OnPM_DataRecordNew(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
					this.tblPostCtrlDetSpec_OnPM_DataRecordDuplicate(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans:
					this.tblPostCtrlDetSpec_OnPM_DataSourceCreateWindowTrans(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_FetchRowDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlDetSpec_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.sControlTypeValue = this.tblPostCtrlDetSpec_colSpecControlTypeValue.Text;
			this.sControlType = this.dfsSpecControlType.Text;
			this.sModule = this.dfsSpecModule.Text;
			if (this.dfsSpecControlType.Text == "IC7") 
			{
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Income_Type_API.Get_Income_Type_Id")) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Income_Type_API.Get_Income_Type_Id", System.Data.ParameterDirection.Input);
						if (!(this.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
							"			    :i_hWndFrame.frmPostCtrlDetSpec.tblPostCtrlDetSpec_colSpecControlTypeValue := &AO.Income_Type_API.Get_Income_Type_Id(\r\n" +
							"			    :i_hWndFrame.frmPostCtrlDetSpec.tblPostCtrlDetSpec_colSpecControlTypeValue);\r\n" +
							"			   END;"))) 
						{
							e.Return = false;
							return;
						}
					}
				}
				this.sControlTypeValue = this.tblPostCtrlDetSpec_colSpecControlTypeValue.Text;
			}
			else if (this.dfsSpecControlType.Text == "IC8") 
			{
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Type1099_API.Get_Irs1099_Type_Id")) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Type1099_API.Get_Irs1099_Type_Id", System.Data.ParameterDirection.Input);
						if (!(this.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
							"			    :i_hWndFrame.frmPostCtrlDetSpec.tblPostCtrlDetSpec_colSpecControlTypeValue := &AO.Type1099_API.Get_Irs1099_Type_Id(\r\n" +
							"			    :i_hWndFrame.frmPostCtrlDetSpec.tblPostCtrlDetSpec_colSpecControlTypeValue);\r\n" +
							"			   END;"))) 
						{
							e.Return = false;
							return;
						}
					}
				}
				this.sControlTypeValue = this.tblPostCtrlDetSpec_colSpecControlTypeValue.Text;
			}
			if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Posting_Ctrl_Control_Type_API.Get_Control_Type_Info__") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Reference_SYS.Get_Lov_Properties")) 
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Posting_Ctrl_Control_Type_API.Get_Control_Type_Info__", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					hints.Add("Reference_SYS.Get_Lov_Properties", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output);
					if (!(this.DbPLSQLBlock(cSessionManager.c_hSql, "DECLARE\r\n" +
						"		view_ VARCHAR2(200);\r\n" +
						"BEGIN &AO.Posting_Ctrl_Control_Type_API.Get_Control_Type_Info__(\r\n" +
						" :i_hWndFrame.frmPostCtrlDetSpec.sControlTypeValueDesc,\r\n" +
						" view_,\r\n" +
						" :i_hWndFrame.frmPostCtrlDetSpec.sPkgName,\r\n" +
						" :i_hWndFrame.frmPostCtrlDetSpec.sCtrlTypeCategory,\r\n" +
						" :i_hWndFrame.frmPostCtrlDetSpec.sControlTypeName,\r\n" +
						" :i_hWndFrame.frmPostCtrlDetSpec.i_sCompany,\r\n" +
						" :i_hWndFrame.frmPostCtrlDetSpec.sControlType,\r\n" +
						" :i_hWndFrame.frmPostCtrlDetSpec.sControlTypeValue,\r\n" +
						" :i_hWndFrame.frmPostCtrlDetSpec.sModule);\r\n" +
						" :i_hWndFrame.frmPostCtrlDetSpec.sView := view_;\r\n" +
						" &AO.Reference_SYS.Get_Lov_Properties(\r\n" +
						" view_,\r\n" +
						" :i_hWndFrame.frmPostCtrlDetSpec.sDummy1,\r\n" +
						" :i_hWndFrame.frmPostCtrlDetSpec.sDummy2,\r\n" +
						" :i_hWndFrame.frmPostCtrlDetSpec.sDummy3,\r\n" +
						" :i_hWndFrame.frmPostCtrlDetSpec.sDummy4); END;"))) 
					{
						e.Return = false;
						return;
					}
				}
			}
			Sal.TblSetColumnTitle(this.tblPostCtrlDetSpec_colSpecControlTypeValue, this.sControlTypeName);
			if (this.tblPostCtrlDetSpec_colPostingType.Text == "IP3" || this.tblPostCtrlDetSpec_colPostingType.Text == "PP18" || this.tblPostCtrlDetSpec_colPostingType.Text == "PP44" || this.tblPostCtrlDetSpec_colPostingType.Text == "PP48" || this.tblPostCtrlDetSpec_colPostingType.Text == 
			"PP49") 
			{
				if (this.dfsSpecControlType.Text == "AC7") 
				{
					this.sView = "STATUTORY_FEE_DEDUCTIBLE(COMPANY)";
				}
			}
			this.GetControlTypeDesc();
			this.tblPostCtrlDetSpec_colSpecControlTypeValueDesc.Text = this.sControlTypeValueDesc;
			this.sCodePartValue = this.tblPostCtrlDetSpec_colCodePartValue.Text;
			this.sCodePart = this.dfCodePart.Text;
			e.Return = Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlDetSpec_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
				if (this.dfsSpecCtrlTypeCategoryDb.Text == "FIXED" || this.dfsSpecCtrlTypeCategoryDb.Text == "PREPOSTING") 
				{
					e.Return = false;
					return;
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordDuplicate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlDetSpec_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				this.bDuplicate = true;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourceCreateWindowTrans event handler.
		/// </summary>
		/// <param name="message"></param>

        private void tblPostCtrlDetSpec_OnPM_DataSourceCreateWindowTrans(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (this.sItemName1 == "tblPostCtrlDetSpec_colCodePartValue")
                {
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans, Sys.wParam, Sys.lParam);
                    return;
                }
                this.lsMessage = SalString.FromHandle(Sys.lParam);
                if (!(frmPostCtrlDetSpec.FromHandle(this.i_hWndFrame).sDummy1 == SalString.Null))
                {
                    this.nTemp1 = this.sDummy1.Tokenize("", ",", this.sKeyCols);
                    this.nTemp1 = this.sDummy2.Tokenize("", ",", this.sLovCols);
                    this.nTemp1 = 0;
                    this.nTemp2 = 0;
                    // To find the Key column of the view
                    while (true) // Outer
                    {
                        if (this.sKeyCols[this.nTemp1] != SalString.Null)
                        {
                            while (true)
                            {
                                if (this.sLovCols[this.nTemp2] != SalString.Null)
                                {
                                    if (this.sKeyCols[this.nTemp1] == this.sLovCols[this.nTemp2])
                                    {
                                        goto ExitOuter;
                                    }
                                    else
                                    {
                                        this.nTemp2 = this.nTemp2 + 1;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                        this.nTemp1 = this.nTemp1 + 1;
                        this.nTemp2 = 0;
                    }
                ExitOuter: ;
                    this.MessageKeys.Unpack(this.lsMessage);
                    this.nIndex = Vis.ArrayFindString(this.MessageKeys.m_sNames, this.tblPostCtrlDetSpec_colSpecControlTypeValue.p_sSqlColumn);
                    if (this.nIndex != -1)
                    {
                        this.MessageKeys.m_sNames[this.nIndex] = this.sKeyCols[this.nTemp1];
                        this.MessageKeys.m_sValues[this.nIndex] = this.sKeyCols[this.nTemp1];
                    }
                    this.nIndex = Vis.ArrayFindString(tblPostCtrlDetSpec.__sColumnName, this.tblPostCtrlDetSpec_colSpecControlTypeValue.p_sSqlColumn);
                    this.tblPostCtrlDetSpec.__sColumnName[this.nIndex] = this.sKeyCols[this.nTemp1];
                    this.bReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans, Sys.wParam, this.MessageKeys.Pack().ToHandle());
                    this.tblPostCtrlDetSpec.__sColumnName[this.nIndex] = this.tblPostCtrlDetSpec_colSpecControlTypeValue.p_sSqlColumn;
                }
                else
                {
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans, Sys.wParam, Sys.lParam);
                    return;
                }
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindowTrans, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }
        
        
        
        #endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtDataSourcePopulateIt(SalNumber nParam)
		{
			return this.DataSourcePopulateIt(nParam);
		}
        // Insert new code here...
		#endregion
		
		#region ChildTable-tblPostCtrlDetSpec
		
		#region Window Variables
		public SalBoolean bDuplicate = false;
		public cMessage MessageKeys = new cMessage();
		public SalString lsMessage = "";
		public SalNumber nIndex = 0;
		public SalArray<SalString> sItemNames = new SalArray<SalString>();
		public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
		public SalString sFormName = "";
		public SalString sItemName1 = "";
		public SalString sBaseCurrCode = "";
		public SalString sCountryDb = "";
		public SalString sStmt = "";
		#endregion
						
		#region Methods
			
		/// <summary>
		/// Gets default values for NEW records
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean DataRecordGetDefaults()
		{
		    tblPostCtrlDetSpec_colCompany.Text = this.dfCompany.Text;
		    tblPostCtrlDetSpec_colCompany.EditDataItemSetEdited();
		    tblPostCtrlDetSpec_colPostingType.Text = this.dfPostingType.Text;
		    tblPostCtrlDetSpec_colPostingType.EditDataItemSetEdited();
		    tblPostCtrlDetSpec_colCodePart.Text = this.dfCodePart.Text;
		    tblPostCtrlDetSpec_colCodePart.EditDataItemSetEdited();
		    tblPostCtrlDetSpec_colPcValidFrom.DateTime = this.dfPcValidFrom.DateTime;
		    tblPostCtrlDetSpec_colPcValidFrom.EditDataItemSetEdited();
		    tblPostCtrlDetSpec_colSpecControlType.Text = this.dfsSpecControlType.Text;
		    tblPostCtrlDetSpec_colSpecControlType.EditDataItemSetEdited();
		    tblPostCtrlDetSpec_colSpecModule.Text = this.dfsSpecModule.Text;
		    tblPostCtrlDetSpec_colSpecModule.EditDataItemSetEdited();
		    return true;
		}
			
		/// <summary>
		/// The framework calls the DataRecordPrepareNew function to retrive
		/// server default values for new records.
		/// </summary>
		/// <returns>The return value is TRUE if default values were sucessfully retrived, FALSE otherwise.</returns>
		public virtual SalBoolean DataRecordPrepareNew()
		{
		    if (((cChildTable)tblPostCtrlDetSpec).DataRecordPrepareNew()) 
		    {
			    if (bDuplicate) 
			    {
				    bDuplicate = false;
				    return true;
			    }
			    return true;
		    }
		    return false;

		}
			
		/// <summary>
		/// </summary>
		/// <param name="hItem"></param>
		/// <returns></returns>
		public virtual SalString GetItemName(SalWindowHandle hItem)
		{
		    SalString sItem = "";
		    Sal.GetItemName(hItem, ref sItem);
		    return sItem;
		}
		#endregion
			
		#region Window Actions
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblPostCtrlDetSpec_colSpecControlTypeValue_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.tblPostCtrlDetSpec_colSpecControlTypeValue_OnSAM_SetFocus(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblPostCtrlDetSpec_colSpecControlTypeValue_OnPM_DataItemValidate(sender, e);
					break;
					
				case Sys.SAM_AnyEdit:
					this.tblPostCtrlDetSpec_colSpecControlTypeValue_OnSAM_AnyEdit(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
					this.tblPostCtrlDetSpec_colSpecControlTypeValue_OnPM_DataItemLovUserWhere(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlDetSpec_colSpecControlTypeValue_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.WaitCursor(true);
			if (this.sView == "WORK_CENTER_NOSITE") 
			{
				this.tblPostCtrlDetSpec_colSpecControlTypeValue.p_sLovReference = "WORK_CENTER_DESC(COMPANY)";
			}
			else
			{
				this.tblPostCtrlDetSpec_colSpecControlTypeValue.p_sLovReference = this.sView;
			}
			Sal.WaitCursor(false);
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlDetSpec_colSpecControlTypeValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.sControlTypeValue = this.tblPostCtrlDetSpec_colSpecControlTypeValue.Text;
			this.GetControlTypeDesc();
			this.tblPostCtrlDetSpec_colSpecControlTypeValueDesc.Text = this.sControlTypeValueDesc;
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlDetSpec_colSpecControlTypeValue_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendMsg(this.tblPostCtrlDetSpec_colSpecControlTypeValue.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
			e.Return = Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemLovUserWhere event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlDetSpec_colSpecControlTypeValue_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.sView == "INCOME_TYPE_LOV(COUNTRY_CODE, CURRENCY_CODE)") 
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Company_Finance_API.Get_Accounting_Currency", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
					this.tblPostCtrlDetSpec_colSpecControlTypeValue.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
						"			&AO.Company_Finance_API.Get_Accounting_Currency(\r\n" +
						"                                     		:i_hWndFrame.frmPostCtrlDetSpec.tblPostCtrlDetSpec.sBaseCurrCode,\r\n" +
						"				:i_hWndFrame.frmPostCtrlDetSpec.tblPostCtrlDetSpec_colCompany );\r\n" +
						"		              END;");
				}
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Company_API.Get_Country_Db", System.Data.ParameterDirection.Input);
					this.tblPostCtrlDetSpec_colSpecControlTypeValue.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
						"			:i_hWndFrame.frmPostCtrlDetSpec.tblPostCtrlDetSpec.sCountryDb := &AO.Company_API.Get_Country_Db(\r\n" +
						"                                     		:i_hWndFrame.frmPostCtrlDetSpec.tblPostCtrlDetSpec_colCompany ); END;");
				}
				e.Return = ("COUNTRY_CODE='" + this.sCountryDb + "' and CURRENCY_CODE='" + this.sBaseCurrCode + "'").ToHandle();
				return;
			}
			if (this.sView == "TYPE1099_LOV(COUNTRY_CODE)") 
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Company_API.Get_Country_Db", System.Data.ParameterDirection.Input);
					this.tblPostCtrlDetSpec_colSpecControlTypeValue.DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
						"			:i_hWndFrame.frmPostCtrlDetSpec.tblPostCtrlDetSpec.sCountryDb := &AO.Company_API.Get_Country_Db(\r\n" +
						"                                     		:i_hWndFrame.frmPostCtrlDetSpec.tblPostCtrlDetSpec_colCompany ); END;");
				}
				e.Return = ("COUNTRY_CODE='" + this.sCountryDb + "'").ToHandle();
				return;
			}
			if (this.dfPostingType.Text == "M42" && this.dfsSpecControlType.Text == "C48") 
			{
				this.sStmt = " COMPANY = :i_hWndFrame.frmPostCtrlDetSpec.i_sCompany ";
				e.Return = this.sStmt.ToHandle();
				return;
			}
			if (this.sView == "STATUTORY_FEE_DEDUCTIBLE(COMPANY)" && (this.dfPostingType.Text == "PP48" || this.dfPostingType.Text == "PP49")) 
			{
				this.sStmt = " FEE_TYPE_DB ='IRS1099TX'";
				e.Return = this.sStmt.ToHandle();
				return;
			}
			#endregion
		}
			
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblPostCtrlDetSpec_colCodePartValue_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.tblPostCtrlDetSpec_colCodePartValue_OnPM_DataItemValidate(sender, e);
					break;
					
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
					this.tblPostCtrlDetSpec_colCodePartValue_OnPM_DataItemZoom(sender, e);
					break;
			}
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlDetSpec_colCodePartValue_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.sCodePart = this.dfCodePart.Text;
			this.sCodePartValue = this.tblPostCtrlDetSpec_colCodePartValue.Text;
			if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Part_Value_API.Get_Description")) 
			{
				this.sSql = ":i_hWndFrame.frmPostCtrlDetSpec.sCodePartValueDesc :=  " + cSessionManager.c_sDbPrefix + "Accounting_Code_Part_Value_API.Get_Description( :i_hWndFrame.frmPostCtrlDetSpec.i_sCompany,\r\n" +
				"				:i_hWndFrame.frmPostCtrlDetSpec.sCodePart, :i_hWndFrame.frmPostCtrlDetSpec.sCodePartValue )";
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Accounting_Code_Part_Value_API.Get_Description", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					if (!(this.tblPostCtrlDetSpec_colCodePartValue.DbPLSQLBlock(cSessionManager.c_hSql, this.sSql))) 
					{
						e.Return = false;
						return;
					}
				}
				this.tblPostCtrlDetSpec_colCodePartValueDesc.Text = this.sCodePartValueDesc;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
			
		/// <summary>
		/// PM_DataItemZoom event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblPostCtrlDetSpec_colCodePartValue_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				this.sItemName1 = this.GetItemName(this.tblPostCtrlDetSpec_colCodePartValue);
				if (this.tblPostCtrlDetSpec_colCodePart.Text == "A") 
				{
					this.sFormName = Pal.GetActiveInstanceName("tbwAccountOverview");
					this.sItemNames[0] = "COMPANY";
					this.hWndItems[0] = this.tblPostCtrlDetSpec_colCompany;
					this.sItemNames[1] = "ACCOUNT";
					this.hWndItems[1] = this.tblPostCtrlDetSpec_colCodePartValue;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("Account", tblPostCtrlDetSpec, this.sItemNames, this.hWndItems);
                    SessionNavigate(this.sFormName);
					e.Return = true;
					return;
				}
				else
				{
					this.bReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
					Sal.WaitCursor(false);
					this.sItemName1 = SalString.Null;
					e.Return = this.bReturn;
					return;
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		#endregion
			
		#region Window Events

        private void tblPostCtrlDetSpec_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordGetDefaults();
        }

        private void tblPostCtrlDetSpec_DataRecordPrepareNewEvent(object sender, FndReturnEventArgsSalBoolean e)
        {
            e.Handled = true;
            e.ReturnValue = this.DataRecordPrepareNew();
        }
		#endregion

        #endregion

    }
}
