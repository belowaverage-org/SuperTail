namespace SuperTail
{
    partial class LogViewer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            vsbMain = new VScrollBar();
            hsbMain = new HScrollBar();
            SuspendLayout();
            // 
            // vsbMain
            // 
            vsbMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            vsbMain.LargeChange = 1;
            vsbMain.Location = new Point(133, 0);
            vsbMain.Name = "vsbMain";
            vsbMain.Size = new Size(17, 133);
            vsbMain.TabIndex = 0;
            vsbMain.ValueChanged += vsbMain_ValueChanged;
            vsbMain.SizeChanged += Control_SizeChanged;
            // 
            // hsbMain
            // 
            hsbMain.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            hsbMain.LargeChange = 100;
            hsbMain.Location = new Point(0, 133);
            hsbMain.Name = "hsbMain";
            hsbMain.Size = new Size(133, 17);
            hsbMain.SmallChange = 10;
            hsbMain.TabIndex = 1;
            hsbMain.ValueChanged += hsbMain_ValueChanged;
            hsbMain.SizeChanged += Control_SizeChanged;
            // 
            // LogViewer
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(hsbMain);
            Controls.Add(vsbMain);
            DoubleBuffered = true;
            Name = "LogViewer";
            SizeChanged += Control_SizeChanged;
            ResumeLayout(false);
        }

        #endregion

        private VScrollBar vsbMain;
        private HScrollBar hsbMain;
    }
}
