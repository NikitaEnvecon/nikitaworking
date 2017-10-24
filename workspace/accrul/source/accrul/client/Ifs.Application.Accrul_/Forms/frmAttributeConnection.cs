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
	[FndWindowRegistration("ACCOUNTING_ATTRIBUTE_CON2", "AccountingAttributeCon", FndWindowRegistrationFlags.HomePage)]
	public partial class frmAttributeConnection : cFormWindowFin
	{

		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmAttributeConnection()
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
		public new static frmAttributeConnection FromHandle(SalWindowHandle handle)
		{
			return ((frmAttributeConnection)SalWindow.FromHandle(handle, typeof(frmAttributeConnection)));
		}
		#endregion
		
		#region ChildTable-tblCodePartValues
					
		#region Window Variables
		public SalString lsCommonAttr = "";
		public SalString lsInfoAttr = "";
		public SalString sObjid = "";
		public SalString sObjversion = "";
		#endregion
									
		#region Methods
			
		/// <summary>
		/// The DataRecordExecuteModify function performs server update of
		/// modified records.
		/// COMMENTS:
		/// DataRecordExecuteModify is called once for each modified record by the
		/// DataSourceExecuteSqlUpdate function during the save process.
		/// </summary>
		/// <param name="hSql"></param>
		/// <returns></returns>
		public virtual SalBoolean DataRecordExecuteModify(SalSqlHandle hSql)
		{
			#region Actions
			using (new SalContext(this))
			{
                if (Sal.IsNull(tblCodePartValues.__colObjid) && (!(Sal.IsNull(tblCodePartValues_colsAttributeValue)))) 
				{
					// -----------New: Attribute Connection------------------
					Ifs.Fnd.ApplicationForms.Var.Console.Add("New: Attribute Connection");
					lsInfoAttr = SalString.Null;
					lsCommonAttr = SalString.Null;
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COMPANY", tblCodePartValues_colsCompany.Text, ref lsCommonAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ATTRIBUTE", tblCodePartValues_colsAttribute.Text, ref lsCommonAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("CODE_PART", tblCodePartValues_colsCodePart.Text, ref lsCommonAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("CODE_PART_VALUE", tblCodePartValues_colsCodePartValue.Text, ref lsCommonAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ATTRIBUTE_VALUE", tblCodePartValues_colsAttributeValue.Text, ref lsCommonAttr);
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("&AO.ACCOUNTING_ATTRIBUTE_CON_API.NEW__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
                        if (DbPLSQLBlock(hSql, "&AO.ACCOUNTING_ATTRIBUTE_CON_API.NEW__( \r\n" +
						"	:i_hWndFrame.frmAttributeConnection.lsInfoAttr, \r\n" +
						"	:i_hWndFrame.frmAttributeConnection.sObjid, \r\n" +
						"	:i_hWndFrame.frmAttributeConnection.sObjversion, \r\n" +
						"	:i_hWndFrame.frmAttributeConnection.lsCommonAttr, \r\n 'DO' )")) 
					    {
						    if (HandleSqlResult(lsInfoAttr)) 
						    {
                                Sal.SetWindowText(tblCodePartValues.__colObjid, sObjid);
                                tblCodePartValues.__lsObjversion = sObjversion;
							    return true;
						    }
						    else
						    {
							    return false;
						    }
					    }
					    else
					    {
						    return false;
					    }
                    }
				}
                else if ((!(Sal.IsNull(tblCodePartValues.__colObjid))) && (!(Sal.IsNull(tblCodePartValues_colsAttributeValue)))) 
				{
					// -----------Modify: Attribute Connection------------------
					Ifs.Fnd.ApplicationForms.Var.Console.Add("Modify: Attribute Connection");
					return ((cChildTable)tblCodePartValues).DataRecordExecuteModify(hSql);
				}
                else if ((!(Sal.IsNull(tblCodePartValues.__colObjid))) && Sal.IsNull(tblCodePartValues_colsAttributeValue)) 
				{
					// -----------Remove: Attribute Connection------------------
					Ifs.Fnd.ApplicationForms.Var.Console.Add("Remove: Attribute Connection");
					lsInfoAttr = SalString.Null;
                    sObjid = tblCodePartValues.__colObjid.Text;
                    sObjversion = tblCodePartValues.__colObjversion.Text;
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("&AO.ACCOUNTING_ATTRIBUTE_CON_API.REMOVE__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (DbPLSQLBlock(hSql, "&AO.ACCOUNTING_ATTRIBUTE_CON_API.REMOVE__( \r\n" +
						"	:i_hWndFrame.frmAttributeConnection.lsInfoAttr,\r\n" +
						"	:i_hWndFrame.frmAttributeConnection.sObjid, \r\n" +
						"	:i_hWndFrame.frmAttributeConnection.sObjversion,\r\n	'DO' )")) 
					    {
                            if (HandleSqlResult(lsInfoAttr)) 
						    {
                                Sal.ClearField(tblCodePartValues.__colObjid);
                                tblCodePartValues.__lsObjversion = SalString.Null;
							    return true;
						    }
						    else
						    {
							    return false;
						    }
					    }
					    else
					    {
						    return false;
					    }
                    }
				}
				return true;
			}
			#endregion
		}
		#endregion
			
		#region Window Events

        private void tblCodePartValues_DataRecordExecuteModifyEvent(object sender, cDataSource.DataRecordExecuteModifyEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = DataRecordExecuteModify(e.hSql);
        }
		#endregion

		#endregion
	}
}
