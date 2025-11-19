using System.Windows.Forms.Design;

namespace SuperTail
{
    public partial class LogViewer : UserControl
    {
        public Log Log;
        public int LinesVisible => Height / LineHeight - 1;
        public int Index = 0;
        private int LineFileNameWidth = 0;
        private int LineTextWidth = 0;
        private int LineTotalWidth => LineFileNameWidth + LineTextWidth + 20;
        private int LineOverflowWidth {
            get
            {
                int overflow = LineTotalWidth - Width;
                return overflow > 0 ? overflow : 0;
            }
        }
        private int VerticalOffset = -100;
        private int LineHeight = 16;
        private Pen LinePen = Pens.WhiteSmoke;
        public LogViewer()
        {
            InitializeComponent();
            Log = new Log(this);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            CalulateLineWidths();
            PaintRows(e.Graphics);
            PaintLogText(e.Graphics);
        }
        private void CalulateLineWidths()
        {
            LineFileNameWidth = 0;
            int lines = LinesVisible;
            for (int i = Index; i < lines + Index && LineVisible(i); i++)
            {
                int fileNameWidth = TextRenderer.MeasureText(Log[i].FileName, Font).Width;
                if (LineFileNameWidth < fileNameWidth) LineFileNameWidth = fileNameWidth;
                int textWidth = TextRenderer.MeasureText(Log[i].Text, Font).Width;
                if (LineTextWidth < textWidth) LineTextWidth = textWidth;
            }
            hsbMain.Maximum = LineOverflowWidth;
        }
        private void PaintRows(Graphics g)
        {
            int lines = LinesVisible;
            for (int i = 0; i < lines; i++)
            {
                int y = i * LineHeight;
                g.DrawLine(LinePen, 0, y, Width, y);
            }
            g.DrawLine(LinePen, LineFileNameWidth + VerticalOffset, 0, LineFileNameWidth + VerticalOffset, Height);
        }
        private void PaintLogText(Graphics g)
        {
            int lines = LinesVisible;
            for (int i = Index; i < lines + Index && LineVisible(i); i++)
            {
                TextRenderer.DrawText(g, Log[i].FileName, Font, new Point(VerticalOffset, i * LineHeight), ForeColor);
                TextRenderer.DrawText(g, Log[i].Text, Font, new Point(LineFileNameWidth + VerticalOffset, i * LineHeight), ForeColor);
            }
        }
        public bool LineVisible(int LineIndex)
        {
            return LineIndex >= 0 && LineIndex < Log.Count && LineIndex >= Index && LineIndex < Index + LinesVisible;
        }
        private void Control_SizeChanged(object sender, EventArgs e)
        {
            ((Control)sender).Invalidate();
        }

        private void hsbMain_ValueChanged(object sender, EventArgs e)
        {
            VerticalOffset = ((HScrollBar)sender).Value * -1;
            Invalidate();
        }
    }
    public class Log : List<LogLine>
    {
        private LogViewer LogViewer;
        public Log(LogViewer LogViewer)
        { 
            this.LogViewer = LogViewer;
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
