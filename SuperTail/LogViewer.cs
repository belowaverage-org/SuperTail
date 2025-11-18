using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace SuperTail
{
    public partial class LogViewer : UserControl
    {
        private List<string?> Log = new();
        private int Start = 0;
        private int Lines = 50;
        private bool ScrollToEnd = true;
        public LogViewer()
        {
            InitializeComponent();
        }
        public void Append(string? Line)
        {
            Log.Add(Line);
            if (ScrollToEnd)
            {
                Start = Log.Count - Lines;
            }
        }
        public void Clear()
        {
            Log.Clear();
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int v = 0;
            for (int i = Start; i < Start + Lines; i++)
            {
                v += 10;
                if (i >= Log.Count) continue;
                e.Graphics.DrawString(Log[i], Font, Brushes.Black, 0, v);
            }
        }
    }
}
