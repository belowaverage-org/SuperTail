namespace SuperTail
{
    partial class fMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            rtbMain = new RichTextBox();
            ssMain = new StatusStrip();
            tsslSelected = new ToolStripStatusLabel();
            tsslSpacer = new ToolStripStatusLabel();
            tsslCPU = new ToolStripStatusLabel();
            tsslMemory = new ToolStripStatusLabel();
            msMain = new MenuStrip();
            tsmiFile = new ToolStripMenuItem();
            tsmiExit = new ToolStripMenuItem();
            tsmiView = new ToolStripMenuItem();
            tsmiFont = new ToolStripMenuItem();
            tssView1 = new ToolStripSeparator();
            tsmiShowFileTree = new ToolStripMenuItem();
            scMain = new SplitContainer();
            tlpFileTree = new TableLayoutPanel();
            tbFilter = new TextBox();
            tvMain = new TreeView();
            tbPath = new TextBox();
            tlpMain = new TableLayoutPanel();
            ssMain.SuspendLayout();
            msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scMain).BeginInit();
            scMain.Panel1.SuspendLayout();
            scMain.Panel2.SuspendLayout();
            scMain.SuspendLayout();
            tlpFileTree.SuspendLayout();
            tlpMain.SuspendLayout();
            SuspendLayout();
            // 
            // rtbMain
            // 
            rtbMain.BackColor = Color.White;
            rtbMain.DetectUrls = false;
            rtbMain.Dock = DockStyle.Fill;
            rtbMain.HideSelection = false;
            rtbMain.Location = new Point(0, 0);
            rtbMain.Margin = new Padding(0);
            rtbMain.Name = "rtbMain";
            rtbMain.ReadOnly = true;
            rtbMain.ShortcutsEnabled = false;
            rtbMain.Size = new Size(527, 475);
            rtbMain.TabIndex = 0;
            rtbMain.Text = "";
            rtbMain.WordWrap = false;
            // 
            // ssMain
            // 
            ssMain.Font = new Font("Consolas", 9F);
            ssMain.Items.AddRange(new ToolStripItem[] { tsslSelected, tsslSpacer, tsslCPU, tsslMemory });
            ssMain.Location = new Point(0, 502);
            ssMain.Name = "ssMain";
            ssMain.Size = new Size(784, 22);
            ssMain.TabIndex = 1;
            // 
            // tsslSelected
            // 
            tsslSelected.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            tsslSelected.BorderStyle = Border3DStyle.SunkenOuter;
            tsslSelected.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsslSelected.Margin = new Padding(2);
            tsslSelected.Name = "tsslSelected";
            tsslSelected.Size = new Size(88, 18);
            tsslSelected.Text = "Selected: 0";
            // 
            // tsslSpacer
            // 
            tsslSpacer.DisplayStyle = ToolStripItemDisplayStyle.None;
            tsslSpacer.Name = "tsslSpacer";
            tsslSpacer.Size = new Size(535, 17);
            tsslSpacer.Spring = true;
            // 
            // tsslCPU
            // 
            tsslCPU.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            tsslCPU.BorderStyle = Border3DStyle.SunkenOuter;
            tsslCPU.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsslCPU.Margin = new Padding(2);
            tsslCPU.Name = "tsslCPU";
            tsslCPU.Size = new Size(60, 18);
            tsslCPU.Text = "CPU: 0%";
            // 
            // tsslMemory
            // 
            tsslMemory.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            tsslMemory.BorderStyle = Border3DStyle.SunkenOuter;
            tsslMemory.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsslMemory.Margin = new Padding(2);
            tsslMemory.Name = "tsslMemory";
            tsslMemory.Size = new Size(74, 18);
            tsslMemory.Text = "Mem: 0 MB";
            // 
            // msMain
            // 
            msMain.Font = new Font("Consolas", 9F);
            msMain.Items.AddRange(new ToolStripItem[] { tsmiFile, tsmiView });
            msMain.Location = new Point(0, 0);
            msMain.Name = "msMain";
            msMain.Size = new Size(784, 24);
            msMain.TabIndex = 2;
            // 
            // tsmiFile
            // 
            tsmiFile.DropDownItems.AddRange(new ToolStripItem[] { tsmiExit });
            tsmiFile.Name = "tsmiFile";
            tsmiFile.Size = new Size(47, 20);
            tsmiFile.Text = "&File";
            // 
            // tsmiExit
            // 
            tsmiExit.Name = "tsmiExit";
            tsmiExit.ShortcutKeyDisplayString = "ALT + F4";
            tsmiExit.Size = new Size(165, 22);
            tsmiExit.Text = "E&xit";
            tsmiExit.Click += tsmiExit_Click;
            // 
            // tsmiView
            // 
            tsmiView.DropDownItems.AddRange(new ToolStripItem[] { tsmiFont, tssView1, tsmiShowFileTree });
            tsmiView.Name = "tsmiView";
            tsmiView.Size = new Size(47, 20);
            tsmiView.Text = "View";
            // 
            // tsmiFont
            // 
            tsmiFont.Name = "tsmiFont";
            tsmiFont.Size = new Size(172, 22);
            tsmiFont.Text = "Font...";
            // 
            // tssView1
            // 
            tssView1.Name = "tssView1";
            tssView1.Size = new Size(169, 6);
            // 
            // tsmiShowFileTree
            // 
            tsmiShowFileTree.Checked = true;
            tsmiShowFileTree.CheckState = CheckState.Checked;
            tsmiShowFileTree.Name = "tsmiShowFileTree";
            tsmiShowFileTree.Size = new Size(172, 22);
            tsmiShowFileTree.Text = "Show file tree";
            tsmiShowFileTree.Click += tsmiShowFileTree_Click;
            // 
            // scMain
            // 
            scMain.Dock = DockStyle.Fill;
            scMain.FixedPanel = FixedPanel.Panel1;
            scMain.Location = new Point(3, 25);
            scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            scMain.Panel1.Controls.Add(tlpFileTree);
            scMain.Panel1MinSize = 200;
            // 
            // scMain.Panel2
            // 
            scMain.Panel2.Controls.Add(rtbMain);
            scMain.Panel2MinSize = 300;
            scMain.Size = new Size(778, 475);
            scMain.SplitterDistance = 250;
            scMain.SplitterWidth = 1;
            scMain.TabIndex = 4;
            // 
            // tlpFileTree
            // 
            tlpFileTree.ColumnCount = 1;
            tlpFileTree.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpFileTree.Controls.Add(tbFilter, 0, 2);
            tlpFileTree.Controls.Add(tvMain, 0, 1);
            tlpFileTree.Controls.Add(tbPath, 0, 0);
            tlpFileTree.Dock = DockStyle.Fill;
            tlpFileTree.Location = new Point(0, 0);
            tlpFileTree.Margin = new Padding(0);
            tlpFileTree.Name = "tlpFileTree";
            tlpFileTree.RowCount = 3;
            tlpFileTree.RowStyles.Add(new RowStyle());
            tlpFileTree.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpFileTree.RowStyles.Add(new RowStyle());
            tlpFileTree.Size = new Size(250, 475);
            tlpFileTree.TabIndex = 4;
            // 
            // tbFilter
            // 
            tbFilter.Dock = DockStyle.Fill;
            tbFilter.Location = new Point(0, 453);
            tbFilter.Margin = new Padding(0);
            tbFilter.Name = "tbFilter";
            tbFilter.Size = new Size(250, 22);
            tbFilter.TabIndex = 7;
            tbFilter.Text = "^(.*\\.txt|.*\\.log)$";
            // 
            // tvMain
            // 
            tvMain.CheckBoxes = true;
            tvMain.Dock = DockStyle.Fill;
            tvMain.Location = new Point(0, 22);
            tvMain.Margin = new Padding(0);
            tvMain.Name = "tvMain";
            tvMain.Size = new Size(250, 431);
            tvMain.TabIndex = 5;
            tvMain.BeforeCheck += tvMain_BeforeCheck;
            // 
            // tbPath
            // 
            tbPath.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbPath.AutoCompleteSource = AutoCompleteSource.FileSystemDirectories;
            tbPath.Dock = DockStyle.Fill;
            tbPath.Location = new Point(0, 0);
            tbPath.Margin = new Padding(0);
            tbPath.Name = "tbPath";
            tbPath.Size = new Size(250, 22);
            tbPath.TabIndex = 6;
            tbPath.Text = "\\";
            tbPath.TextChanged += tbPath_TextChanged;
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(scMain, 0, 0);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(0, 22, 0, 21);
            tlpMain.RowCount = 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 481F));
            tlpMain.Size = new Size(784, 524);
            tlpMain.TabIndex = 5;
            // 
            // fMain
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 524);
            Controls.Add(ssMain);
            Controls.Add(msMain);
            Controls.Add(tlpMain);
            Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = msMain;
            MinimumSize = new Size(800, 563);
            Name = "fMain";
            Text = "Super Tail";
            ssMain.ResumeLayout(false);
            ssMain.PerformLayout();
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            scMain.Panel1.ResumeLayout(false);
            scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scMain).EndInit();
            scMain.ResumeLayout(false);
            tlpFileTree.ResumeLayout(false);
            tlpFileTree.PerformLayout();
            tlpMain.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbMain;
        private StatusStrip ssMain;
        private MenuStrip msMain;
        private ToolStripMenuItem tsmiFile;
        private ToolStripMenuItem tsmiExit;
        private SplitContainer scMain;
        private TableLayoutPanel tlpMain;
        private ToolStripMenuItem tsmiView;
        private ToolStripMenuItem tsmiFont;
        private TableLayoutPanel tlpFileTree;
        private TreeView tvMain;
        private TextBox tbPath;
        private ToolStripStatusLabel tsslSelected;
        private TextBox tbFilter;
        private ToolStripSeparator tssView1;
        private ToolStripMenuItem tsmiShowFileTree;
        private ToolStripStatusLabel tsslMemory;
        private ToolStripStatusLabel tsslSpacer;
        private ToolStripStatusLabel tsslCPU;
    }
}
