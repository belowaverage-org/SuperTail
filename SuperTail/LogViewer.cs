using Timer = System.Windows.Forms.Timer;

namespace SuperTail
{
    public partial class LogViewer : UserControl
    {
        public LogLines Log;
        private int LinesVisible => Height / LineHeight - 1;
        private int _Index = 0;
        private int Index
        {
            get => _Index;
            set
            {
                if (value < 0) value = 0;
                if (value > Log.Count) value = Log.Count;
                if (_Index != value)
                {
                    _Index = value;
                    vsbMain.Value = _Index;
                    Invalidate();
                }
            }
        }
        private int LineFileNameWidth = 0;
        private int LineTextWidth = 0;
        private int LineTotalWidth => LineFileNameWidth + LineTextWidth + vsbMain.Width;
        private int LineOverflowWidth
        {
            get
            {
                int overflow = LineTotalWidth - Width;
                return overflow > 0 ? overflow : 0;
            }
        }
        private int FileNameColumnOffset => LineFileNameWidth + HorizontalOffset;
        private int _HorizontalOffset = 0;
        private int HorizontalOffset
        {
            get => _HorizontalOffset;
            set
            {
                if (_HorizontalOffset != value)
                {
                    _HorizontalOffset = value;
                    hsbMain.Value = _HorizontalOffset * -1;
                    Invalidate();
                }
            }
        }
        private int LineHeight = 16;
        private Pen LinePen = Pens.LightGray;
        private Timer RefreshTimer = new Timer();
        public LogViewer()
        {
            InitializeComponent();
            Log = new LogLines(this);
            RefreshTimer.Interval = 500;
            RefreshTimer.Tick += RefreshTimer_Tick;
            RefreshTimer.Start();
        }

        private void RefreshTimer_Tick(object? sender, EventArgs e)
        {
            CalculateVerticalScrollBar();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            CalulateLineWidths();
            PaintRows(e.Graphics);
            PaintLogText(e.Graphics);
        }
        private void CalculateVerticalScrollBar()
        {
            vsbMain.Minimum = -LinesVisible;
            vsbMain.Maximum = Log.Count > 0 ? Log.Count : 0;
        }
        private void CalulateLineWidths()
        {
            LineFileNameWidth = 0;
            LineTextWidth = 0;
            int lines = LinesVisible;
            for (int i = Index; i < lines + Index && LineVisible(i); i++)
            {
                int fileNameWidth = TextRenderer.MeasureText(Log[i].FileName, Font).Width;
                if (LineFileNameWidth < fileNameWidth) LineFileNameWidth = fileNameWidth;
                int textWidth = TextRenderer.MeasureText(Log[i].Text, Font).Width;
                if (LineTextWidth < textWidth) LineTextWidth = textWidth;
            }
            hsbMain.Maximum = LineOverflowWidth + hsbMain.LargeChange;
        }
        private void PaintRows(Graphics g)
        {
            int lines = LinesVisible;
            for (int i = 0; i < lines; i++)
            {
                int y = i * LineHeight;
                g.DrawLine(LinePen, 0, y, Width, y);
            }
            g.DrawLine(LinePen, FileNameColumnOffset, 0, FileNameColumnOffset, Height);
        }
        private void PaintLogText(Graphics g)
        {
            int lines = LinesVisible;
            for (int i = Index; i < lines + Index && LineVisible(i); i++)
            {
                int line = i - Index;
                TextRenderer.DrawText(g, Log[i].FileName, Font, new Point(HorizontalOffset, line * LineHeight), ForeColor);
                TextRenderer.DrawText(g, Log[i].Text, Font, new Point(FileNameColumnOffset, line * LineHeight), ForeColor);
            }
        }
        public bool LineVisible(int LineIndex)
        {
            return LineIndex >= 0 && LineIndex < Log.Count && LineIndex >= Index && LineIndex < Index + LinesVisible;
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            Index -= e.Delta / 120;
        }
        private void Control_SizeChanged(object sender, EventArgs e)
        {
            ((Control)sender).Invalidate();
        }
        private void hsbMain_ValueChanged(object sender, EventArgs e)
        {
            HorizontalOffset = ((HScrollBar)sender).Value * -1;
        }
        private void vsbMain_ValueChanged(object sender, EventArgs e)
        {
            Index = ((VScrollBar)sender).Value;
        }
        public class LogLines : List<LogLine>
        {
            private LogViewer LogViewer;
            public LogLines(LogViewer LogViewer)
            {
                this.LogViewer = LogViewer;
            }
            public new void Clear()
            {
                base.Clear();
                LogViewer.Invalidate();
            }
            public void Add(string? FileName, string? Text)
            {
                Add(new LogLine(FileName, Text));
            }
            public new void Add(LogLine LogLine)
            {
                base.Add(LogLine);
                if (LogViewer.LineVisible(Count - 1))
                {
                    LogViewer.Invalidate();
                }
            }
        }
        public class LogLine
        {
            public string? FileName;
            public string? Text;
            public LogLine(string? FileName, string? Text)
            {
                this.FileName = FileName;
                this.Text = Text;
            }
        }
    }
}