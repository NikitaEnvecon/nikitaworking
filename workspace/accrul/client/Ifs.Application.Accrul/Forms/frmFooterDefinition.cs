#region Copyright (c) IFS Research & Development
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
#endregion
#region History
// 14-01-02    Kanslk    Bug 114596 modified 'txtResult_MouseDown()'.
// 15-10-29    Hawalk    Bug 125488, Error "SplitterDistance must be between Panel1MinSize and Width - Panel2MinSize." must not arise from code,
// 15-10-29              either in direct assignments or in invocation to 'DockStyle.Fill'.
// 16-04-25    Chwtlk    Bug 128806, Modified AddField(). 
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;
using Ifs.Fnd.Windows.Forms;
using System.Collections;

namespace Ifs.Application.Accrul
{

    /// <summary>
    /// </summary>
    public partial class frmFooterDefinition : cFormWindow
    {
        #region Member Variables
        SalWindowHandle hWndSource;
        int ctr = 0;
        RichTextBox src_rtb;
        DBLayoutPanel src_tlp;

        FndSplitContainer mySpl;
        FndSplitContainer lastSpl;
        RichTextBox rtb;
        DBLayoutPanel[] arrPanel = new DBLayoutPanel[8];
        int distance = 0;

        List<String>[] footers = new List<String>[10];
        List<int>[] footer_width = new List<int>[10];
        String sFieldId = null;
        String sFooterText = null;
        String sHeaderText;
        Object src_Object;
        float[] col_width = new float[10];
        int def_width = 0;
        string[] profile = new string[10];
        string[] position = new string[10];
        SalBoolean bAllowDrop = false;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmFooterDefinition()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        public partial class DBLayoutPanel : TableLayoutPanel
        {
            public DBLayoutPanel()
            {
                //InitializeComponent();
                SetStyle(ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.UserPaint, true);
            }

            public DBLayoutPanel(IContainer container)
            {
                container.Add(this);
                //InitializeComponent();
                SetStyle(ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.UserPaint, true);
            }
        }
        public class TableLayoutPanelFooter : TableLayoutPanel
        {
            //public TableLayoutPanelFooter()
            //{
            //    this.DoubleBuffered = true;
            //}
        }

        public static class SuspendUpdate
        {
            private const int WM_SETREDRAW = 0x000B;

            public static void Suspend(Control control)
            {
                Message msgSuspendUpdate = Message.Create(control.Handle, WM_SETREDRAW, IntPtr.Zero,
                    IntPtr.Zero);

                NativeWindow window = NativeWindow.FromHandle(control.Handle);
                window.DefWndProc(ref msgSuspendUpdate);
            }

            public static void Resume(Control control)
            {
                // Create a C "true" boolean as an IntPtr
                IntPtr wparam = new IntPtr(1);
                Message msgResumeUpdate = Message.Create(control.Handle, WM_SETREDRAW, wparam,
                    IntPtr.Zero);

                NativeWindow window = NativeWindow.FromHandle(control.Handle);
                window.DefWndProc(ref msgResumeUpdate);

                control.Invalidate();
            }
        }

        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static frmFooterDefinition FromHandle(SalWindowHandle handle)
        {
            return ((frmFooterDefinition)SalWindow.FromHandle(handle, typeof(frmFooterDefinition)));
        }
        #endregion

        #region Properties

        #endregion

        #region Methods

        public SalBoolean FrameStartupUser()
        {
            #region Actions
            txtDummy.SendToBack();
            for (int x = 0; x < 10; x++)
            {
                footers[x] = new List<String>();
                footer_width[x] = new List<int>();
            }

            return base.FrameStartupUser();
            #endregion
        }

        public SalBoolean DataSourceSaveNew()
        {
            #region Actions
            bool bNew = false,bRemove = false;
            using (new SalContext(this))
            {
                if (this.i_nRecordState & Sys.ROW_New)
                    bNew = true;
                else if (this.i_nRecordState & Sys.ROW_MarkDeleted)
                    bRemove = true;

                if (base.DataSourceSaveNew())
                {
                    if (bNew)
                    {
                        Sal.SendMsg(tblFields, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        RefreshResult();
                    }
                    else if (bRemove)
                        ResetResult();

                    return true;
                }
            }
            return false;
            #endregion
        }

        public SalBoolean DataSourcePopulateIt(SalNumber nParam)
        {
            #region Actions
            base.vrtDataSourcePopulateIt(nParam);
            if (dfnNoOfColumns.Number == Sys.NUMBER_Null)
            {
                ResetResult();
            }
            return true;
            #endregion
        }

        public SalNumber DataRecordNew(SalNumber nWhat)
        {
            #region Actions
            base.DataRecordNew(nWhat);
            if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                ResetResult();
            return true;
            #endregion
        }

        public SalNumber FrameActivate()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (cmbFooterId.IsEmpty())
                    ResetResult();
                return base.FrameActivate();
            }
            #endregion
        }

        public int FindMax(List<int> myList)
        {
            #region Actions
            int max = Int32.MinValue;
            for (int i = 0; i < myList.Count; i++)
            {
                int val = myList[i];
                if (val > max)
                    max = val;
            }
            return max;
            #endregion
        }

        protected virtual void RefreshInfo(bool bSet)
        {
            #region Actions
            SalString sPosition = "";
            SalString sProfile = "";
            if (dfnNoOfColumns.Number > 1)
            {
                for (int n = 0; n < dfnNoOfColumns.Number - 1; n++)
                {
                    if (n == 0)
                    {
                        mySpl = (FndSplitContainer)this.panelResult.Controls[0];
                    }
                    else
                    {
                        mySpl = (FndSplitContainer)this.lastSpl.Panel2.Controls[0];
                    }
                    sPosition = sPosition + (mySpl.SplitterDistance).ToString() + ";";
                    sProfile = sProfile + ((mySpl.SplitterDistance) - def_width).ToString() + ";";
                    lastSpl = mySpl;
                }
                sPosition = sPosition + (mySpl.Width - mySpl.SplitterDistance).ToString() + ";";
                sProfile = sProfile + ((mySpl.Width - mySpl.SplitterDistance) - def_width).ToString() + ";";
            }
            else
            {
                sPosition = "800;";
                sProfile = "0;";
            }
                /*
            if (dfsLastPosition.Text == "")
            {
                dfsLastPosition.Text = sPosition;
                using (new SalContext(this))
                {
                    DbPLSQLTransaction(cSessionManager.c_hSql,
                        @"&AO.Footer_Definition_API.Update_Position(
                                :i_hWndFrame.frmFooterDefinition.dfsCompany IN,
                                :i_hWndFrame.frmFooterDefinition.cmbFooterId.i_sMyValue IN,
                                :i_hWndFrame.frmFooterDefinition.dfsLastPosition IN)");
                }
            }
             */



            dfsLastPosition.Text = sPosition;
            dfsLastProfile.Text = sProfile;
            if (bSet)
            {
                dfsLastPosition.EditDataItemSetEdited();
                dfsLastProfile.EditDataItemSetEdited();
                //Sal.SetFieldEdit(dfsLastPosition, true);
                //Sal.SetFieldEdit(dfsLastProfile, true);
            }
            profile = dfsLastProfile.Text.Split(new Char[] { ';' });


            //dfsLastPosition.Text = sTemp;
            //dfsLastPosition.EditDataItemSetEdited();

            /*
            sTemp = "";
            for (int n = 0; n < dfnNoOfColumns.Number; n++)
            {
                sTemp = sTemp + profile[n] + ";";
            }
            if (dfsLastProfile.Text == "")
            {
                dfsLastProfile.Text = sTemp;
                using (new SalContext(this))
                {
                    DbPLSQLTransaction(cSessionManager.c_hSql,
                        @"&AO.Footer_Definition_API.Update_Profile(
                                :i_hWndFrame.frmFooterDefinition.dfsCompany IN,
                                :i_hWndFrame.frmFooterDefinition.cmbFooterId.i_sMyValue IN,
                                :i_hWndFrame.frmFooterDefinition.dfsLastProfile IN)");
                }
            }
            if (bSet)
                Sal.SendMsg(dfsLastProfile, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sTemp.ToHandle());
            else
                Sal.SendMsg(dfsLastProfile, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 0, sTemp.ToHandle());
            //dfsLastProfile.Text = sTemp;
            //dfsLastProfile.EditDataItemSetEdited();
             */
            #endregion
        }

        protected virtual void ResetResult()
        {
            #region Actions
            position = new string[10];
            profile = new string[10];
            for (int x = 0; x < 10; x++)
            {
                footers[x] = new List<String>();
                footer_width[x] = new List<int>();
                col_width[x] = 0;
            }

            panelResult.Controls.Clear();
            txtResult.Text = "";
            #endregion
        }

        protected virtual void RefreshResult()
        {
            float nTotWidth = 0;
            #region Actions
            if (dfnNoOfColumns.Number > 0)
            {
                int nColumn = dfnNoOfColumns.Number;
                int nWidth = panelResult.Size.Width / nColumn;
                def_width = nWidth;
                //nWidth = nWidth - 1;

                if (dfsLastPosition.Text != "")
                    position = dfsLastPosition.Text.Split(new Char[] { ';' });
                else
                {
                    for (int x = 0; x < nColumn - 1; x++)
                    {
                        position[x] = nWidth.ToString();
                    }
                }

                if (nColumn == 1)
                {
                    DBLayoutPanel tlpDummy;
                    tlpDummy = new DBLayoutPanel();
                    tlpDummy.RowStyles.Clear();
                    tlpDummy.ColumnStyles.Clear();
                    tlpDummy.AutoSize = true;
                    tlpDummy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                    //tlpDummy.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                    tlpDummy.ColumnCount = 1;
                    tlpDummy.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute));
                    tlpDummy.RowCount = 1;
                    tlpDummy.AllowDrop = true;
                    tlpDummy.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    tlpDummy.BackColor = System.Drawing.SystemColors.Window;
                    tlpDummy.Dock = DockStyle.Fill;
                    /*    ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                           | System.Windows.Forms.AnchorStyles.Left)
                                           | System.Windows.Forms.AnchorStyles.Right)));*/
                    tlpDummy.DragDrop += new System.Windows.Forms.DragEventHandler(this.tlpColumn_DragDrop);
                    tlpDummy.DragEnter += new System.Windows.Forms.DragEventHandler(this.tlpColumn_DragEnter);

                    panelResult.Controls.Add(tlpDummy);
                    arrPanel[0] = tlpDummy;
                    profile[0] = "0";
                }
                else
                {
                    for (int i = 0; i < nColumn - 1; i++)
                    {
                        nWidth = Convert.ToInt32(position[i]);
                        nWidth = nWidth - 3;
                        mySpl = new FndSplitContainer();
                        DBLayoutPanel tlpDummy;
                        tlpDummy = new DBLayoutPanel();
                        tlpDummy.RowStyles.Clear();
                        tlpDummy.ColumnStyles.Clear();
                        tlpDummy.AutoSize = true;
                        tlpDummy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                        //tlpDummy.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                        tlpDummy.ColumnCount = 1;
                        tlpDummy.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute));
                        tlpDummy.RowCount = 1;
                        tlpDummy.AllowDrop = true;
                        tlpDummy.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        tlpDummy.BackColor = System.Drawing.SystemColors.Window;
                        tlpDummy.Dock = DockStyle.Fill;
                        /*
                        tlpDummy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                               | System.Windows.Forms.AnchorStyles.Left)
                                               | System.Windows.Forms.AnchorStyles.Right)));
                         */
                        tlpDummy.DragDrop += new System.Windows.Forms.DragEventHandler(this.tlpColumn_DragDrop);
                        tlpDummy.DragEnter += new System.Windows.Forms.DragEventHandler(this.tlpColumn_DragEnter);
                        if (i == 0)
                        {
                            panelResult.Controls.Add(mySpl);
                        }
                        else
                        {
                            lastSpl.Panel2.Controls.Add(mySpl);
                        }
                        mySpl.FixedPanel = FixedPanel.Panel2;
                        this.mySpl.Panel1.Controls.Add(tlpDummy);
                        arrPanel[i] = tlpDummy;
                        this.mySpl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                        // Bug 125488, begin, 'try' and 'catch' writen for existing code.
                        try
                        {
                            // Note: Certain lengthy fields might cause subsequent columns not to be shown. If docking (which docks a container to its 
                            //       edges) is attempted to be performed on such, an error is raised. This may not be done otherwise since this.mySpl.Width
                            //       is adjusted internally (see below for other example).
                            this.mySpl.Dock = System.Windows.Forms.DockStyle.Fill;
                        }
                        catch
                        {
                        }
                        // Bug 125488, end

                        this.mySpl.Location = new System.Drawing.Point(0, 0);

                        // Bug 125488, begin, Conditional assignment.
                        // Note: 'Spliiter Distance' must be between 'Panel 1 MinSize' and 'Width - Panel 2 Min Size'.
                        if (nWidth < this.mySpl.Width - this.mySpl.Panel2MinSize - this.mySpl.Panel1MinSize)
                        {
                            if (nWidth > 0)
                            {
                                this.mySpl.SplitterDistance = nWidth;
                            }
                        }
                        // Bug 125488, end

                        this.mySpl.SplitterWidth = 1;
                        if (i == nColumn - 2)
                        {
                            tlpDummy = new DBLayoutPanel();
                            tlpDummy.RowStyles.Clear();
                            tlpDummy.ColumnStyles.Clear();
                            tlpDummy.AutoSize = true;
                            tlpDummy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                            //tlpDummy.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                            tlpDummy.ColumnCount = 1;
                            tlpDummy.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute));
                            tlpDummy.RowCount = 1;
                            tlpDummy.AllowDrop = true;
                            tlpDummy.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                            tlpDummy.BackColor = System.Drawing.SystemColors.Window;
                            tlpDummy.Dock = DockStyle.Fill;
                            /*
                            tlpDummy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                   | System.Windows.Forms.AnchorStyles.Left)
                                                   | System.Windows.Forms.AnchorStyles.Right)));
                             */
                            tlpDummy.DragDrop += new System.Windows.Forms.DragEventHandler(this.tlpColumn_DragDrop);
                            tlpDummy.DragEnter += new System.Windows.Forms.DragEventHandler(this.tlpColumn_DragEnter);
                            this.mySpl.Panel2.Controls.Add(tlpDummy);
                            arrPanel[i + 1] = tlpDummy;
                        }
                        lastSpl = mySpl;
                    }

                    // Bug 125488, begin, Conditional assignment.
                    int nTempSlitterDist = Convert.ToInt32(position[nColumn - 2]);

                    if (nTempSlitterDist < this.mySpl.Width - this.mySpl.Panel2MinSize - this.mySpl.Panel1MinSize)
                    {
                        if (nTempSlitterDist > 0)
                        {
                            this.mySpl.SplitterDistance = nTempSlitterDist;
                        }
                    }
                    // Bug 125488, end
                }

                for (int i = 0; i < nColumn - 1; i++)
                {
                    if (i == 0)
                    {
                        mySpl = (FndSplitContainer)this.panelResult.Controls[0];
                    }
                    else
                    {
                        mySpl = (FndSplitContainer)this.lastSpl.Panel2.Controls[0];
                    }
                    mySpl.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.split_SplitterMoved);
                    lastSpl = mySpl;
                }
            }
            #endregion
        }

        protected virtual void GenerateResult(Boolean bResize)
        {
            #region Local Variables
            String sText = "";
            String sHeader = "";
            #endregion

            #region Actions
            SuspendUpdate.Suspend(panelResult);

            if (dfsLastProfile.Text != "")
            {
                profile = dfsLastProfile.Text.Split(new Char[] { ';' });
            }
            // add column 1 footer fields
            if (dfsColumn1Field.Text != "")
            {
                sText = dfsColumn1Field.Text;
                src_tlp = arrPanel[0];
                AddColumn(src_tlp, sText, 0);
            }
            // add column 2 footer fields
            if (dfsColumn2Field.Text != "")
            {
                src_tlp = arrPanel[1];
                sText = dfsColumn2Field.Text;
                AddColumn(src_tlp, sText, 1);
            }
            // add column 3 footer fields
            if (dfsColumn3Field.Text != "")
            {
                src_tlp = arrPanel[2];
                sText = dfsColumn3Field.Text;
                AddColumn(src_tlp, sText, 2);
            }
            // add column 4 footer fields
            if (dfsColumn4Field.Text != "")
            {
                src_tlp = arrPanel[3];
                sText = dfsColumn4Field.Text;
                AddColumn(src_tlp, sText, 3);
            }
            // add column 5 footer fields
            if (dfsColumn5Field.Text != "")
            {
                src_tlp = arrPanel[4];
                sText = dfsColumn5Field.Text;
                AddColumn(src_tlp, sText, 4);
            }
            // add column 6 footer fields
            if (dfsColumn6Field.Text != "")
            {
                src_tlp = arrPanel[5];
                sText = dfsColumn6Field.Text;
                AddColumn(src_tlp, sText, 5);
            }
            // add column 7 footer fields
            if (dfsColumn7Field.Text != "")
            {
                src_tlp = arrPanel[6];
                sText = dfsColumn7Field.Text;
                AddColumn(src_tlp, sText, 6);
            }
            // add column 8 footer fields
            if (dfsColumn8Field.Text != "")
            {
                src_tlp = arrPanel[7];
                sText = dfsColumn8Field.Text;
                AddColumn(src_tlp, sText, 7);
            }
            SuspendUpdate.Resume(panelResult);
            panelResult.Refresh();
            // free text
            if (dfsFreeText.Text != "")
            {
                txtResult.Text = dfsFreeText.Text;
            }
//            RefreshInfo(false);
            #endregion
        }


        protected virtual void AddColumn(DBLayoutPanel source, String sFields, int col)
        {
            #region Actions
            TableLayoutPanelCellPosition cell = new TableLayoutPanelCellPosition();

            int i = 0, n = 0;
            cell.Column = col;
            while (n != -1)
            {
                n = sFields.IndexOf(",", 0);
                if (n != -1)
                {
                    sFieldId = sFields.Substring(0, n);
                    sFields = sFields.Substring(n + 1);
                }
                else
                {
                    sFieldId = sFields;
                }
                cell.Row = i;
                AddField(cell, source, GetHeaderText(), false);
                i++;
            }
            #endregion
        }

        protected virtual void AddField(TableLayoutPanelCellPosition cell, TableLayoutPanel src_Column, String header, Boolean bAutoSize)
        {
            #region Local Variables
            RichTextBox rtb = new RichTextBox();
            FndSplitContainer splitParent;
            SplitterPanel splitPanel;
            TableLayoutPanelCellPosition pos = new TableLayoutPanelCellPosition(0, 0);
            int nTemp = 0;
            int splitWidth = 0;
            int diff = 0;
            #endregion

            #region Actions
            //src_Column.AutoSize = true;
            src_Column.Controls.Add(rtb, 0, cell.Row);
            rtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            rtb.ScrollBars = RichTextBoxScrollBars.None;
            rtb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtb_MouseDown);
            rtb.GotFocus += new EventHandler(this.rtb_GotFocus);
            rtb.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(rtb_ContentsResized);

            if (header != "" && header != null)
            {
                rtb.SelectionFont = new Font("Arial", 8f, FontStyle.Bold);
                rtb.AppendText(header + "\n");
            }
            rtb.SelectionFont = new Font("Arial", 8f, FontStyle.Regular);
            this.GetFooterText();
            if  (this.sFooterText != null) 
			{
                rtb.AppendText(this.GetFooterText());
            }
                //rtb.Dock = DockStyle.Fill;

            //pos = tlpParent.GetCellPosition(src_Column);
            footers[cell.Column].Add(sFieldId);



            StringFormat sFormat = new StringFormat(StringFormat.GenericTypographic);

            using (Graphics g = rtb.CreateGraphics())
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                nTemp = (int)g.MeasureString(rtb.Text + "__", rtb.SelectionFont, new Size(Width - Padding.Vertical, Height - Padding.Horizontal), sFormat).Width;
                nTemp = nTemp + 13;
                if (bAutoSize)
                {
                    if (this.dfnNoOfColumns.Number > 1)
                    {
                        splitParent = (FndSplitContainer)rtb.Parent.Parent.Parent;
                        splitPanel = (SplitterPanel)rtb.Parent.Parent;
                        if (splitPanel == splitParent.Panel1)
                            splitWidth = splitParent.SplitterDistance + 2;
                        else
                            splitWidth = splitParent.Width - (splitParent.SplitterDistance + 2);

                        if (nTemp > splitWidth)
                        {
                            // Bug 128806, Begin, Assigned the absolute value for splitParent.SplitterDistance. SplitterDistance can't be negative.
                            if (rtb.Parent.Parent == splitParent.Panel1)
                                splitParent.SplitterDistance = nTemp;
                            else
                                splitParent.SplitterDistance = Math.Abs(splitParent.Width - nTemp - 2);
                            // Bug 128806 End.

                        }
                    }



                }
                
                //diff = splitParent.SplitterDistance - def_width;
                //profile[pos.Column] = diff.ToString();
                //profile[pos.Column + 1] = (Convert.ToInt32(profile[pos.Column + 1]) - diff).ToString();
            }

            footer_width[cell.Column].Add(nTemp);
            /*
            if (cell.Row == 0 | nTemp > (int)(tlpParent.ColumnStyles[pos.Column].Width + 0.5f))
                col_width[pos.Column] = nTemp;

            footer_width[pos.Column].Add(nTemp);

            //dfsLastProfile.Text = FindMax(footer_width[pos.Column]).ToString();
            //rtb.Width = col_width[pos.Column];
            RearrangeColumn(pos.Column);
             */


            rtb.Dock = DockStyle.Fill;
            //rtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //                       | System.Windows.Forms.AnchorStyles.Left)
            //                       | System.Windows.Forms.AnchorStyles.Right)));
            src_Column.RowCount++;
            src_Column.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            #endregion
        }

        /*
        private void RearrangeColumn(int pos)
        {
            #region Local Variables
            int n;
            float nAvailableWidth = 0;
            float nNeededWidth = 0;
            float nWidth = 0;
            #endregion

            #region Actions
            if ((int)(tlpParent.ColumnStyles[pos].Width + 0.5f) < col_width[pos])
            {
                // Rearrange backward
                n = pos - 1;
                nNeededWidth = col_width[pos] - (int)(tlpParent.ColumnStyles[pos].Width + 0.5f);
                while (n >= 0 && nNeededWidth > 0)
                {
                    nWidth = (int)(tlpParent.ColumnStyles[n].Width + 0.5f);
                    nAvailableWidth = nWidth - col_width[n];
                    if (nAvailableWidth > 0)
                    {
                        if (nNeededWidth > nAvailableWidth)
                        {
                            nWidth = col_width[n];
                            nNeededWidth = nNeededWidth - nAvailableWidth;
                        }
                        else
                        {
                            nWidth = nWidth - nNeededWidth;
                            nNeededWidth = 0;
                        }
                        tlpParent.ColumnStyles[n].Width = nWidth;
                        profile[n] = (tlpParent.ColumnStyles[n].Width - def_width).ToString();
                    }
                    n--;
                }

                // Rearrange forward
                n = pos + 1;
                while (n <= tlpParent.ColumnCount && nNeededWidth > 0)
                {
                    nWidth = (int)(tlpParent.ColumnStyles[n].Width + 0.5f);
                    nAvailableWidth = nWidth - col_width[n];
                    if (nAvailableWidth > 0)
                    {
                        if (nNeededWidth > nAvailableWidth)
                        {
                            nWidth = col_width[n];
                            nNeededWidth = nNeededWidth - nAvailableWidth;
                        }
                        else
                        {
                            nWidth = nWidth - nNeededWidth;
                            nNeededWidth = 0;
                        }
                        tlpParent.ColumnStyles[n].Width = nWidth;
                        profile[n] = (tlpParent.ColumnStyles[n].Width - def_width).ToString();
                    }
                    n++;
                }

                tlpParent.ColumnStyles[pos].Width = col_width[pos];
            }

            profile[pos] = (tlpParent.ColumnStyles[pos].Width - def_width).ToString();

            //RefreshInfo();
            #endregion
        }
        */

        protected virtual String GetHeaderText()
        {
            #region Local Variables
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                DbPLSQLBlock(cSessionManager.c_hSql,
                    @"BEGIN
                        :i_hWndFrame.frmFooterDefinition.sHeaderText := 
                            &AO.Footer_Field_API.Get_Footer_Field_Desc(
                                :i_hWndFrame.frmFooterDefinition.dfsCompany IN,
                                :i_hWndFrame.frmFooterDefinition.sFieldId IN);
                      END;");
            }
            return this.sHeaderText;
            #endregion
        }

        protected virtual String GetFooterText()
        {
            #region Local Variables
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                this.sFooterText = null;
                DbPLSQLBlock(cSessionManager.c_hSql,
                    @"BEGIN
                        :i_hWndFrame.frmFooterDefinition.sFooterText := 
                            &AO.Footer_Field_API.Get_Footer_Text(
                                :i_hWndFrame.frmFooterDefinition.dfsCompany IN,
                                :i_hWndFrame.frmFooterDefinition.sFieldId IN);
                      END;");
            }
            
            return this.sFooterText;
            #endregion
        }

        protected virtual void SetColumnFields()
        {
            #region Actions
            SalString sFooter = "";
            sFooter = string.Join(",", footers[0].ToArray());
            Sal.SendMsg(dfsColumn1Field, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sFooter.ToHandle());
            sFooter = string.Join(",", footers[1].ToArray());
            Sal.SendMsg(dfsColumn2Field, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sFooter.ToHandle());
            sFooter = string.Join(",", footers[2].ToArray());
            Sal.SendMsg(dfsColumn3Field, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sFooter.ToHandle());
            sFooter = string.Join(",", footers[3].ToArray());
            Sal.SendMsg(dfsColumn4Field, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sFooter.ToHandle());
            sFooter = string.Join(",", footers[4].ToArray());
            Sal.SendMsg(dfsColumn5Field, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sFooter.ToHandle());
            sFooter = string.Join(",", footers[5].ToArray());
            Sal.SendMsg(dfsColumn6Field, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sFooter.ToHandle());
            sFooter = string.Join(",", footers[6].ToArray());
            Sal.SendMsg(dfsColumn7Field, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sFooter.ToHandle());
            sFooter = string.Join(",", footers[7].ToArray());
            Sal.SendMsg(dfsColumn8Field, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sFooter.ToHandle());
            sFooter = string.Join(",", footers[8].ToArray());
            Sal.SendMsg(dfsColumn9Field, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sFooter.ToHandle());
            sFooter = string.Join(",", footers[9].ToArray());
            Sal.SendMsg(dfsColumn10Field, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, sFooter.ToHandle());
            #endregion
        }

        private void tblFields_OnDragStart(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalNumber nXPos = 0;
            SalNumber nYPos = 0;
            #endregion

            #region Actions
            e.Handled = true;
            Sal.DragDropGetSource(ref hWndSource, ref nXPos, ref nYPos);
            bAllowDrop = true;
            e.Return = true;
            return;
            #endregion
        }

        private void tblFields_OnDragCanAutoStart(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = true;
            return;
            #endregion
        }

        private void tblFields_OnDragEnd(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            bAllowDrop = false;
            e.Return = true;
            return;
            #endregion
        }

        public virtual SalNumber OnDragMove(SalNumber wParam, SalNumber lParam)
        {
            #region Local Variables
            SalWindowHandle hWndTarget;
            SalNumber nXPos = 0;
            SalNumber nYPos = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.TimerSet(this, 1, 100);
                Sal.CursorSet(hWndSource, Ifs.Fnd.ApplicationForms.Res.curDragEnabled, Sys.CURSOR_DragDrop);
            }
            return 0;
            #endregion
        }

        private void tlpColumn_DragEnter(object sender, DragEventArgs e)
        {
            #region Actions
            if (colsFreeText.Text == "FALSE" && bAllowDrop)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            #endregion
        }

        private void tlpColumn_DragDrop(object sender, DragEventArgs e)
        {
            #region Local Variables
            src_tlp = (DBLayoutPanel)sender;
            TableLayoutPanelCellPosition cell = GetCellPos(src_tlp);
            #endregion

            #region Actions
            cell.Column = Array.IndexOf(arrPanel, src_tlp);
            sFieldId = colsFieldId.Text;
            AddField(cell, src_tlp, colsHeaderText.Text, true);
            this.SetColumnFields();
            RefreshInfo(true);
            #endregion
        }

        private void rtb_MouseDown(object sender, MouseEventArgs e)
        {
            #region Actions
            src_rtb = (RichTextBox)sender;
            src_Object = (RichTextBox)sender; 
            src_rtb.DoDragDrop(src_rtb.Text, DragDropEffects.Copy);
            #endregion
        }

        private void rtb_GotFocus(object sender, EventArgs e)
        {
            panelResult.Focus();
        }

        private void rtb_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            #region Actions
            src_rtb = (RichTextBox)sender;
            src_rtb.Height = e.NewRectangle.Height;
            #endregion
        }

        protected virtual TableLayoutPanelCellPosition GetCellPos(TableLayoutPanel panel)
        {
            #region Actions
            //mouse position
            Point p = panel.PointToClient(Control.MousePosition);
            //Cell position
            TableLayoutPanelCellPosition pos = new TableLayoutPanelCellPosition(0, 0);
            //Panel size.
            Size size = panel.Size;
            //average cell size.
            SizeF cellAutoSize = new SizeF(size.Width / panel.ColumnCount, size.Height / panel.RowCount);

            int[] columnWidth = panel.GetColumnWidths();
            int[] rowHeight = panel.GetRowHeights();

            int columnPosition = -1;
            int left = p.X;
            for (int i = 0; i < columnWidth.Length; i++)
            {
                if (left < columnWidth[i])
                {
                    columnPosition = i;

                    break;
                }
                else
                    left -= columnWidth[i];
            }

            int rowPosition = -1;
            int top = p.Y;
            for (int i = 0; i < rowHeight.Length; i++)
            {
                if (top < rowHeight[i])
                {
                    rowPosition = i;
                    break;
                }
                else
                    top -= rowHeight[i];
            }

            pos.Column = columnPosition;
            pos.Row = rowPosition;

/*


            //Get the cell row.
            //y coordinate
            float y = 0;
            for (int i = 0; i < panel.RowCount; i++)
            {
                //Calculate the summary of the row heights.
                SizeType type = panel.RowStyles[i].SizeType;
                float height = panel.RowStyles[i].Height;
                switch (type)
                {
                    case SizeType.Absolute:
                        y += height;
                        break;
                    case SizeType.Percent:
                        y += height / 100 * size.Height;
                        break;
                    case SizeType.AutoSize:
                        y += cellAutoSize.Height;
                        break;
                }
                //Check the mouse position to decide if the cell is in current row.
                if ((int)y > p.Y)
                {
                    pos.Row = i;
                    break;
                }
            }

            //Get the cell column.
            //x coordinate
            float x = 0;
            for (int i = 0; i < panel.ColumnCount; i++)
            {
                //Calculate the summary of the row widths.
                SizeType type = panel.ColumnStyles[i].SizeType;
                float width = panel.ColumnStyles[i].Width;
                switch (type)
                {
                    case SizeType.Absolute:
                        x += width;
                        break;
                    case SizeType.Percent:
                        x += width / 100 * size.Width;
                        break;
                    case SizeType.AutoSize:
                        x += cellAutoSize.Width;
                        break;
                }
                //Check the mouse position to decide if the cell is in current column.
                if ((int)x > p.X)
                {
                    pos.Column = i;
                    break;
                }
            }
 */ 
 
            //return the mouse position.
            return pos;
            #endregion
        }

        private void btTraceCan_DragDrop(object sender, DragEventArgs e)
        {
            #region Local Variables
            int[] arr_column = new int[10];
            int max_width = 0;
            int del_width = 0;
            int nWidth;
            int need_width;
            int current;
            int nCurrentChange;
            int n;
            FndSplitContainer currentPanel;
            FndSplitContainer tempPanel;
            #endregion

            #region Actions
            String type = src_Object.GetType().ToString();
            if (type.IndexOf("RichTextBox") != -1)
            {
                src_rtb = (RichTextBox)src_Object;
                TableLayoutPanelCellPosition pos = new TableLayoutPanelCellPosition(0, 0);
                DBLayoutPanel src_tlp = (DBLayoutPanel)src_rtb.Parent;
                pos = src_tlp.GetCellPosition(src_rtb);
                src_tlp.RowCount--;
                src_tlp.RowStyles.RemoveAt(pos.Row);
                src_tlp.Controls.Remove(src_rtb);

                for (int i = pos.Row; i < src_tlp.Controls.Count; i++)
                {
                    src_tlp.SetRow(src_tlp.Controls[i], src_tlp.GetRow(src_tlp.Controls[i]) - 1);
                }

                ctr = Array.IndexOf(arrPanel, src_tlp);

                arr_column = footer_width[ctr].ToArray();
                del_width = arr_column[pos.Row];

                footers[ctr].RemoveAt(pos.Row);
                footer_width[ctr].RemoveAt(pos.Row);
                max_width =  FindMax(footer_width[ctr]);
                this.SetColumnFields();

                current = ctr;

                //if (max_width < del_width)
                int nChange = Int32.Parse(profile[current]);
                if (nChange > 0)
                {
                    if (del_width - max_width - nChange < 0)
                        nChange = (int)(del_width - max_width);
                    int nCtr = nChange;
                    // Rearrange backward
                    n = current - 1;
                    nWidth = del_width - max_width;
                    while (n >= 0 && nCtr > 0)
                    {
                        nCurrentChange = Int32.Parse(profile[n]);
                        currentPanel = (FndSplitContainer)arrPanel[n].Parent.Parent;
                        if (nCurrentChange < 0)
                        {
                            if (nCurrentChange + nCtr > 0)
                            {
                                currentPanel.SplitterDistance = currentPanel.SplitterDistance + Math.Abs(nCurrentChange);
                                profile[n] = "0";
                                nCtr = nCtr + nCurrentChange;
                            }
                            else
                            {
                                currentPanel.SplitterDistance = currentPanel.SplitterDistance + nCtr;
                                profile[n] = (nCurrentChange + nChange).ToString();
                                nCtr = nCtr + nCurrentChange;
                            }
                        }
                        n--;
                    }
                    // Rearrange forward
                    n = current + 1;
                    while (n <= dfnNoOfColumns.Number && nCtr > 0)
                    {
                        nCurrentChange = Int32.Parse(profile[n]);
                        currentPanel = (FndSplitContainer)arrPanel[n].Parent.Parent;
                        if (nCurrentChange < 0)
                        {
                            if (nCurrentChange + nCtr > 0)
                            {
                                currentPanel.SplitterDistance = currentPanel.SplitterDistance + Math.Abs(nCurrentChange);
                                nCtr = nCtr + nCurrentChange;
                                profile[n] = "0";
                            }
                            else
                            {
                                currentPanel.SplitterDistance = currentPanel.SplitterDistance + nCtr;
                                profile[n] = (nCurrentChange + nCtr).ToString();
                                nCtr = nCtr + nCurrentChange;
                            }
                        }
                        n++;
                    }

                    if (nChange > 0)
                    {
                        currentPanel = (FndSplitContainer)arrPanel[current].Parent.Parent;
                        currentPanel.SplitterDistance = currentPanel.SplitterDistance - nChange;
                        profile[current] = (Int32.Parse(profile[current]) - nChange).ToString();
                    }
                    //
                    RefreshInfo(true);
                    //
                }
            }
            else if (type.IndexOf(".TextBox") != -1)
            {
                txtResult.Text = "";
                dfsFreeText.Text = "";
                dfsFreeText.EditDataItemSetEdited();
            }
            #endregion
        }

        private void btTraceCan_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void txtResult_MouseDown(object sender, MouseEventArgs e)
        {
            #region Actions
            src_Object = (TextBox)sender;
            if (src_rtb != null )
                txtResult.DoDragDrop(src_rtb.Text, DragDropEffects.Copy);
            #endregion
        }

        private void txtResult_DragDrop(object sender, DragEventArgs e)
        {
            #region Actions
            sFieldId = colsFieldId.Text;
            txtResult.Text = this.GetFooterText();
            dfsFreeText.Text = txtResult.Text;
            dfsFreeText.EditDataItemSetEdited();
            #endregion
        }

        private void txtResult_DragEnter(object sender, DragEventArgs e)
        {
            #region Actions
            if (colsFreeText.Text != "FALSE")
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            #endregion
        }

        private void split_SplitterMoved(object sender, SplitterEventArgs e)
        {
            RefreshInfo(true);
        }
        #endregion

        #region Overrides

        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }

        public override SalBoolean vrtDataSourceSaveNew()
        {
            return this.DataSourceSaveNew();
        }

        public override SalBoolean vrtDataSourcePopulateIt(SalNumber nParam)
        {
            return this.DataSourcePopulateIt(nParam);
        }
        public override SalNumber vrtDataRecordNew(SalNumber nWhat)
        {
            return this.DataRecordNew(nWhat);
        }

        public override SalNumber vrtFrameActivate()
        {
            return this.FrameActivate();
        }

        #endregion

        #region Message Actions

        private void tblFields_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_DragStart:
                    this.tblFields_OnDragStart(sender, e);
                    break;
                case Sys.SAM_DragCanAutoStart:
                    this.tblFields_OnDragCanAutoStart(sender, e);
                    break;

                case Sys.SAM_DragEnd:
                    this.tblFields_OnDragEnd(sender, e);
                    break;

                case Sys.SAM_DragEnter:
                    e.Handled = true;
                    break;

                case Sys.SAM_DragExit:
                    e.Handled = true;
                    break;

                case Sys.SAM_DragMove:
                    e.Handled = true;
                    this.OnDragMove(Sys.wParam, Sys.lParam);
                    break;

                case Sys.SAM_DragNotify:
                    e.Handled = true;
                    break;
            }

            #endregion
        }

        private void cmbFooterId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    //e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam);
                    this.cmbFooterId_OnPM_DataItemPopulate(sender, e);
                    break;
            }
            #endregion
        }

        private void cmbFooterId_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam))
            {
                ResetResult();
                RefreshResult();
                GenerateResult(false);
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }


        private void dfnNoOfColumns_WindowActions(object sender, WindowActionsEventArgs e)
        {
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                this.dfnNoOfColumns_OnPM_DataItemValidate(sender, e);
                break;
            }
        }

        private void dfnNoOfColumns_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                
                if ( dfnNoOfColumns.Number > 8) 
                {
                   Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_DocFooterNoofColumns, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                   e.Return = Sys.VALIDATE_Cancel;
                   return;
                }
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            e.Return = Sys.VALIDATE_Cancel;
            return;
            #endregion
        }

        #endregion

        #region Event Handlers
        #endregion

        #region Menu Event Handlers

        #endregion
    }
}
