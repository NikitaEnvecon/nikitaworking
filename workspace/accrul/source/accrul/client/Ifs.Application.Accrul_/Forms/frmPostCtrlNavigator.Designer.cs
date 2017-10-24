#region Copyright (c) IFS Research & Development // ====================================================================================================== // //                 IFS Research & Development // //  This program is protected by copyright law and by international //  conventions. All licensing, renting, lending or copying (including //  for private use), and all other use of the program, which is not //  explicitly permitted by IFS, is a violation of the rights //  of IFS. Such violations will be reported to the //  appropriate authorities. // //  VIOLATIONS OF ANY COPYRIGHT IS PUNISHABLE BY LAW AND CAN LEAD //  TO UP TO TWO YEARS OF IMPRISONMENT AND LIABILITY TO PAY DAMAGES. // ====================================================================================================== #endregion #region History #endregion  using System; using System.Text; using System.Drawing; using System.Diagnostics; using System.Collections; using System.Windows.Forms; using System.ComponentModel; using Ifs.Application.Accrul; using Ifs.Application.Appsrv; using Ifs.Application.Enterp; using Ifs.Fnd.ApplicationForms; using PPJ.Runtime; using PPJ.Runtime.Sql; using PPJ.Runtime.Vis; using PPJ.Runtime.Windows; using PPJ.Runtime.Windows.QO;  namespace Ifs.Application.Accrul_ { 	 	public partial class frmPostCtrlNavigator 	{ 		 		/// <summary> 		/// Required designer variable. 		/// </summary> 		private System.ComponentModel.IContainer components = null; 		 		#region Window Controls 		public cTreeListBox tlbTree; 		public cDataField dfdTempDate; 		public cResizeSplitter cSplitter;         public cPanel cPanelLeft; 		#endregion 		 		#region Windows Form Designer generated code 		 		/// <summary> 		/// Required method for Designer support - do not modify 		/// the contents of this method with the code editor. 		/// </summary> 		private void InitializeComponent() 		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPostCtrlNavigator));
            this.tlbTree = new Ifs.Fnd.ApplicationForms.cTreeListBox();
            this.dfdTempDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cSplitter = new Ifs.Fnd.ApplicationForms.cResizeSplitter();
            this.cPanelLeft = new Ifs.Fnd.ApplicationForms.cPanel();
            this.cPanelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cTabManager
            // 
            resources.ApplyResources(this._cTabManager, "_cTabManager");
            // 
            // picTab
            // 
            resources.ApplyResources(this.picTab, "picTab");
            // 
            // tlbTree
            // 
            resources.ApplyResources(this.tlbTree, "tlbTree");
            this.tlbTree.LineColor = System.Drawing.Color.Black;
            this.tlbTree.Name = "tlbTree";
            this.tlbTree.NamedProperties.Put("AllowedEditing", "FALSE");
            this.tlbTree.NamedProperties.Put("AutoActivate", "TRUE");
            this.tlbTree.NamedProperties.Put("AutoExpand", "TRUE");
            this.tlbTree.NamedProperties.Put("NodeCount", "7");
            this.tlbTree.NamedProperties.Put("NodeType0", "!0\n$NODELABEL=Root\n$NODEPICNOTSELECT=NavigatorIcon_FolderTop\n$NODEPICSELECT=Navig" +
                    "atorIcon_FolderTop\n$NODEDISATTRIB=DISPLAY_ATTR\n$NODEALLOWCUT=FALSE\n$NODEALLOWCOP" +
                    "Y=FALSE\n$NODEPASTEFLAGS=!0\n-$0=0\n-$1=0\n-$2=0\n-$3=0\n-$4=0\n-$5=0\n-$6=0\n-\n");
            this.tlbTree.NamedProperties.Put("NodeType1", "!1\n$NODELABEL=Module\n$NODEPICNOTSELECT=NavigatorIcon_Folder\n$NODEPICSELECT=Naviga" +
                    "torIcon_Folder\n$NODEDISATTRIB=DISPLAY_ATTR\n$NODEALLOWCUT=FALSE\n$NODEALLOWCOPY=FA" +
                    "LSE\n$NODEPASTEFLAGS=!1\n-$0=0\n-$1=0\n-$2=0\n-$3=0\n-$4=0\n-$5=0\n-$6=0\n-\n");
            this.tlbTree.NamedProperties.Put("NodeType2", "!2\n$NODELABEL=Posting Type\n$NODEPICNOTSELECT=NavigatorIcon_Folder\n$NODEPICSELECT=" +
                    "NavigatorIcon_Folder\n$NODEDISATTRIB=DISPLAY_ATTR\n$NODEALLOWCUT=FALSE\n$NODEALLOWC" +
                    "OPY=FALSE\n$NODEPASTEFLAGS=!2\n-$0=0\n-$1=0\n-$2=0\n-$3=0\n-$4=0\n-$5=0\n-$6=0\n-\n");
            this.tlbTree.NamedProperties.Put("NodeType3", "!3\n$NODELABEL=Code Name\n$NODEPICNOTSELECT=NavigatorIcon_PartStructureTop\n$NODEPIC" +
                    "SELECT=NavigatorIcon_PartStructureTop\n$NODEDISATTRIB=DISPLAY_ATTR\n$NODEALLOWCUT=" +
                    "FALSE\n$NODEALLOWCOPY=FALSE\n$NODEPASTEFLAGS=!3\n-$0=0\n-$1=0\n-$2=0\n-$3=0\n-$4=0\n-$5=" +
                    "0\n-$6=0\n-\n");
            this.tlbTree.NamedProperties.Put("NodeType4", @"!4
$NODELABEL=Valid From
$NODEPICNOTSELECT=NavigatorIcon_PartStructureMiddle
$NODEPICSELECT=NavigatorIcon_PartStructureMiddle
$NODEDISATTRIB=DISPLAY_ATTR
$NODEALLOWCUT=FALSE
$NODEALLOWCOPY=FALSE
$NODEPASTEFLAGS=!4
-$0=0
-$1=0
-$2=2
-$3=0
-$4=1
-$5=0
-$6=0
-
");
            this.tlbTree.NamedProperties.Put("NodeType5", "!5\n$NODELABEL=Spec Control Type\n$NODEPICNOTSELECT=NavigatorIcon_PartStructureMidd" +
                    "le\n$NODEPICSELECT=NavigatorIcon_Item7\n$NODEDISATTRIB=DISPLAY_ATTR\n$NODEALLOWCUT=" +
                    "FALSE\n$NODEALLOWCOPY=FALSE\n$NODEPASTEFLAGS=!5\n-$0=0\n-$1=0\n-$2=0\n-$3=0\n-$4=0\n-$5=" +
                    "0\n-$6=0\n-\n");
            this.tlbTree.NamedProperties.Put("NodeType6", "!6\n$NODELABEL=Valid From\n$NODEPICNOTSELECT=NavigatorIcon_PartStructureLeaf\n$NODEP" +
                    "ICSELECT=NavigatorIcon_PartStructureLeaf\n$NODEDISATTRIB=DISPLAY_ATTR\n$NODEALLOWC" +
                    "UT=FALSE\n$NODEALLOWCOPY=FALSE\n$NODEPASTEFLAGS=!6\n-$0=0\n-$1=0\n-$2=0\n-$3=0\n-$4=0\n-" +
                    "$5=0\n-$6=0\n-\n");
            this.tlbTree.NamedProperties.Put("ResizeableChildObject", "MFMM");
            this.tlbTree.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tlbTree_WindowActions);
            // 
            // dfdTempDate
            // 
            this.dfdTempDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdTempDate.Format = "d";
            resources.ApplyResources(this.dfdTempDate, "dfdTempDate");
            this.dfdTempDate.Name = "dfdTempDate";
            this.dfdTempDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdTempDate.NamedProperties.Put("LovReference", "");
            this.dfdTempDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdTempDate.NamedProperties.Put("SqlColumn", "");
            this.dfdTempDate.NamedProperties.Put("ValidateMethod", "");
            // 
            // cSplitter
            // 
            resources.ApplyResources(this.cSplitter, "cSplitter");
            this.cSplitter.Name = "cSplitter";
            this.cSplitter.NamedProperties.Put("First", "obj");
            this.cSplitter.NamedProperties.Put("frmSecond", "");
            this.cSplitter.NamedProperties.Put("objFirst", "cPanelLeft");
            this.cSplitter.NamedProperties.Put("objSecond", "picTab");
            this.cSplitter.NamedProperties.Put("Second", "obj");
            // 
            // cPanelLeft
            // 
            this.cPanelLeft.Controls.Add(this.tlbTree);
            this.cPanelLeft.Name = "cPanelLeft";
            resources.ApplyResources(this.cPanelLeft, "cPanelLeft");
            // 
            // frmPostCtrlNavigator
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cPanelLeft);
            this.Controls.Add(this.cSplitter);
            this.Controls.Add(this.dfdTempDate);
            this.Name = "frmPostCtrlNavigator";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmPostCtrlNavigator_WindowActions);
            this.Controls.SetChildIndex(this.dfdTempDate, 0);
            this.Controls.SetChildIndex(this.cSplitter, 0);
            this.Controls.SetChildIndex(this.cPanelLeft, 0);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.cPanelLeft.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		} 		#endregion 		 		#region System Methods/Properties 		 		/// <summary> 		/// Release global reference. 		/// </summary> 		/// <param name="disposing"></param> 		protected override void Dispose(bool disposing) 		{ 			if (disposing && (components != null))  			{ 				components.Dispose(); 			}  			base.Dispose(disposing); 		} 		#endregion           	} } 