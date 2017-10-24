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
	/// Tree view for Tax Book structure
	/// </summary>
	public partial class frmTaxBookStructureView : cFormWindowFin
	{
		#region Window Variables
		public SalString sCompany = "";
		public SalString sStructureId = "";
		public SalString sTmpMsg = "";
		public SalArray<SalString> sItemNode = new SalArray<SalString>();
		public SalArray<SalString> sItemAbove = new SalArray<SalString>();
		public SalArray<SalString> sItemType = new SalArray<SalString>();
		public SalArray<SalString> sItemDesc = new SalArray<SalString>();
		public SalString sDummy1 = "";
		public SalString sDummy2 = "";
		public SalString sDummy3 = "";
		public SalString sDummy4 = "";
		public SalBoolean bFirstTime = false;
		public SalNumber nTopNode = 0;
		public SalWindowHandle hWndTargetNode = SalWindowHandle.Null;
		public SalNumber nTargetNodeHandle = 0;
		public SalNumber nX = 0;
		public SalNumber nY = 0;
		public SalArray<SalString> sPrevNodeInfoArray = new SalArray<SalString>();
		public SalArray<SalString> sCurrentNodeInfoArray = new SalArray<SalString>();
		public SalString sCurItemNode = "";
		public SalString sDestItemNode = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmTaxBookStructureView()
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
		public new static frmTaxBookStructureView FromHandle(SalWindowHandle handle)
		{
			return ((frmTaxBookStructureView)SalWindow.FromHandle(handle, typeof(frmTaxBookStructureView)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <param name="nNodeType"></param>
		/// <param name="nItem"></param>
		/// <returns></returns>
		public virtual SalNumber TreeListNodeExpand(SalNumber nNodeType, SalNumber nItem)
		{
			#region Local Variables
			cMessage msgLocalMsg = new cMessage();
			SalNumber nFetch = 0;
			SalString sTmpInfo = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				lbStructure.TreeListBeginLoad();
				if (nNodeType != Ifs.Fnd.ApplicationForms.Const.TREELIST_NodeTypeRoot) 
				{
					nNodeType = nNodeType + 1;
				}
				switch (nNodeType)
				{
					case Ifs.Fnd.ApplicationForms.Const.TREELIST_NodeTypeRoot:
						if (sItemNode[0] != Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							msgLocalMsg.Construct();
							sTmpMsg = sItemNode[nTopNode];
							msgLocalMsg.SetName(sTmpMsg);
							msgLocalMsg.AddAttribute("NAME", sItemNode[nTopNode] + " - " + sItemDesc[nTopNode]);
							lbStructure.TreeListNodeInsert(0, -1, msgLocalMsg, false);
							Sal.SendMsg(lbStructure, Sys.SAM_Click, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
						}
						break;
					
					default:
						sTmpInfo = lbStructure.TreeListNodeIdFromItem(nItem);
						// Nodes
						nFetch = 0;
						while (sItemNode[nFetch] != Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							if (sItemAbove[nFetch] == sTmpInfo && sItemType[nFetch] == "NODE") 
							{
								msgLocalMsg.Construct();
								sTmpMsg = sItemNode[nFetch];
								msgLocalMsg.SetName(sTmpMsg);
								msgLocalMsg.AddAttribute("NAME", sItemNode[nFetch] + " - " + sItemDesc[nFetch]);
								lbStructure.TreeListNodeInsert(0, nItem, msgLocalMsg, false);
							}
							nFetch = nFetch + 1;
						}
						// CodeParts
						nFetch = 0;
						while (sItemNode[nFetch] != Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							if (sItemAbove[nFetch] == sTmpInfo && sItemType[nFetch] == "TAXBOOK") 
							{
								msgLocalMsg.Construct();
								sTmpMsg = sItemNode[nFetch];
								msgLocalMsg.SetName(sTmpMsg);
								msgLocalMsg.AddAttribute("NAME", sItemNode[nFetch] + " - " + sItemDesc[nFetch]);
								lbStructure.TreeListNodeInsert(1, nItem, msgLocalMsg, true);
							}
							nFetch = nFetch + 1;
						}
						break;
				}
				lbStructure.TreeListEndLoad();
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nParam"></param>
		/// <returns></returns>
		public new SalBoolean DataSourcePopulateIt(SalNumber nParam)
		{
			#region Actions
			using (new SalContext(this))
			{
				return Populate();
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean Populate()
		{
			#region Local Variables
			SalNumber a = 0;
			SalNumber nIndItem = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sCompany = frmTaxBookStructure.FromHandle(i_hWndParent).dfsCompany.Text;
				sStructureId = frmTaxBookStructure.FromHandle(i_hWndParent).cmbStructureId.Text;
				// Fetch Items
				if (!(DbPrepareAndExecute(cSessionManager.c_hSql, "SELECT name_value,item_above,structure_item_type_db,Description\r\n" +
					"INTO :i_hWndFrame.frmTaxBookStructureView.sDummy1,\r\n" +
					":i_hWndFrame.frmTaxBookStructureView.sDummy2,\r\n" +
					":i_hWndFrame.frmTaxBookStructureView.sDummy3,\r\n" +
					":i_hWndFrame.frmTaxBookStructureView.sDummy4\r\nFROM " + cSessionManager.c_sDbPrefix + "tax_book_structure_item WHERE company='" + sCompany + "' AND\r\n" +
					"structure_id='" + sStructureId + "'"))) 
				{
					return false;
				}
				sItemNode.SetUpperBound(1, -1);
				sItemAbove.SetUpperBound(1, -1);
				sItemType.SetUpperBound(1, -1);
				sItemDesc.SetUpperBound(1, -1);
				a = 0;
				while (DbFetchNext(cSessionManager.c_hSql, ref nIndItem)) 
				{
					sItemNode[a] = sDummy1;
					sItemAbove[a] = sDummy2;
					sItemType[a] = sDummy3;
					sItemDesc[a] = sDummy4;
					a = a + 1;
				}
				// Find the top node
				a = 0;
				while (sItemNode[a] != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					if (sItemAbove[a] == Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						nTopNode = a;
						break;
					}
					a = a + 1;
				}

				lbStructure.TreeListReset();
				TreeListNodeExpand(Ifs.Fnd.ApplicationForms.Const.TREELIST_NodeTypeRoot, 0);
				bFirstTime = false;
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nParam"></param>
		/// <returns></returns>
		public new SalBoolean DataSourceClearIt(SalNumber nParam)
		{
			#region Actions
			using (new SalContext(this))
			{
				sItemNode.SetUpperBound(1, -1);
				sItemAbove.SetUpperBound(1, -1);
				sItemType.SetUpperBound(1, -1);
				sItemDesc.SetUpperBound(1, -1);
				lbStructure.TreeListReset();
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// Performed  Cut / Paste server operation.
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CutPaste()
		{
			#region Actions
			using (new SalContext(this))
			{
				PrepareNodesData(nTargetNodeHandle);
                if (cTreeListBox.Clipboard.Cut) 
				{
					// For cut & paste operation
					return MoveBranch();
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// Get required data into two arrays for cut / copy operation.
		/// </summary>
		/// <param name="nItemHandle"></param>
		/// <returns></returns>
		public virtual SalNumber PrepareNodesData(SalNumber nItemHandle)
		{
			#region Local Variables
			SalString sNodeInfo1 = "";
			SalString sNodeInfo2 = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sPrevNodeInfoArray.SetUpperBound(1, -1);
				sCurrentNodeInfoArray.SetUpperBound(1, -1);
				// Get cut node information ( Source Node ).
				sNodeInfo1 = SalString.Null;
                sNodeInfo1 = lbStructure.TreeListNodeIdFromItem(cTreeListBox.Clipboard.ItemSource);
				sNodeInfo1.Tokenize(((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), sPrevNodeInfoArray);
				// Get paste node information ( Target Node ).
				sNodeInfo2 = SalString.Null;
				sNodeInfo2 = lbStructure.TreeListNodeIdFromItem(nItemHandle);
				sNodeInfo2.Tokenize(((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), sCurrentNodeInfoArray);
				// Assign needed values
				sCurItemNode = sPrevNodeInfoArray[0];
				sDestItemNode = sCurrentNodeInfoArray[0];
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean MoveBranch()
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("TAX_BOOK_STRUCTURE_ITEM_API.Move_Branch"))) 
				{
					return false;
				}
				Sal.WaitCursor(true);
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("TAX_BOOK_STRUCTURE_ITEM_API.Move_Branch", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					bOk = DbPLSQLTransaction(cSessionManager.c_hSql, "&APPOWNER.TAX_BOOK_STRUCTURE_ITEM_API.Move_Branch(" + " :i_hWndFrame.frmTaxBookStructureView.sCompany, :i_hWndFrame.frmTaxBookStructureView.sStructureId," + " :i_hWndFrame.frmTaxBookStructureView.sCurItemNode, :i_hWndFrame.frmTaxBookStructureView.sDestItemNode)");
				}
				Sal.WaitCursor(false);
				return bOk;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber RefreshStructure()
		{
			#region Local Variables
			SalNumber a = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				// Refresh the array
				a = 0;
				while (sItemNode[a] != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					if (sItemNode[a] == sCurItemNode) 
					{
						sItemAbove[a] = sDestItemNode;
						break;
					}
					a = a + 1;
				}
				// Refresh the other tabs
				Sal.SendMsg(i_hWndParent, Const.PAM_RefreshTabs1, 0, 0);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber CheckParentForm()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndParent) == Pal.GetActiveInstanceName("frmTaxBookStructure")) 
				{
					return true;
				}
				else
				{
					return false;
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
		private void frmTaxBookStructureView_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_User:
					this.frmTaxBookStructureView_OnPM_User(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_User event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmTaxBookStructureView_OnPM_User(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (SalString.FromHandle(Sys.lParam) == "SAVED") 
			{
				this.Populate();
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void lbStructure_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_TreeListNodeExpand:
					this.lbStructure_OnPM_TreeListNodeExpand(sender, e);
					break;
				
				case Sys.SAM_Create:
					this.lbStructure_OnSAM_Create(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_TreeListNodeMenu:
					this.lbStructure_OnPM_TreeListNodeMenu(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_Paste:
					this.lbStructure_OnPM_Paste(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_Cut:
					this.lbStructure_OnPM_Cut(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_PasteDone:
					this.lbStructure_OnPM_PasteDone(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_TreeListNodeExpand event handler.
		/// </summary>
		/// <param name="message"></param>
		private void lbStructure_OnPM_TreeListNodeExpand(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(this.bFirstTime)) 
			{
				this.TreeListNodeExpand(Sys.wParam, Sys.lParam);
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void lbStructure_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.bFirstTime = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			#endregion
		}
		
		/// <summary>
		/// PM_TreeListNodeMenu event handler.
		/// </summary>
		/// <param name="message"></param>
		private void lbStructure_OnPM_TreeListNodeMenu(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			// Add to disable RMB menu when no items in the structure
			if (this.sItemNode[0] != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_TreeListNodeMenu, Sys.wParam, Sys.lParam);
				return;
			}
			e.Return = false;
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_Paste event handler.
		/// </summary>
		/// <param name="message"></param>
		private void lbStructure_OnPM_Paste(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
				e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_Paste, Sys.wParam, Sys.lParam);
				return;
			}
			else if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				if (Sal.DragDropGetTarget(ref this.hWndTargetNode, ref this.nX, ref this.nY)) 
				{
					this.nTargetNodeHandle = this.lbStructure.GetItemHandle(Vis.ListGetIndexFromPoint(this.hWndTargetNode, this.nX, this.nY));
				}
				else
				{
					this.nTargetNodeHandle = this.lbStructure.hItem;
				}
                if (this.nTargetNodeHandle == this.lbStructure.GetParent(cTreeListBox.Clipboard.ItemSource)) 
				{
					e.Return = false;
					return;
				}
				else
				{
					if (this.CutPaste()) 
					{
						e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_Paste, Sys.wParam, Sys.lParam);
						return;
					}
					else
					{
						e.Return = false;
						return;
					}
				}
			}
			e.Return = false;
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_Cut event handler.
		/// </summary>
		/// <param name="message"></param>
		private void lbStructure_OnPM_Cut(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(this.CheckParentForm())) 
			{
				e.Return = false;
				return;
			}
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_PasteDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void lbStructure_OnPM_PasteDone(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.lbStructure.SetOutlineRedraw(true);
			Sal.SendMsg(this.lbStructure.i_hWndSelf, Sys.SAM_Click, Sys.wParam, Sys.lParam);
			this.nTargetNodeHandle = SalNumber.Null;
			this.RefreshStructure();
			e.Return = true;
			return;
			#endregion
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtDataSourceClearIt(SalNumber nParam)
		{
			return this.DataSourceClearIt(nParam);
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
