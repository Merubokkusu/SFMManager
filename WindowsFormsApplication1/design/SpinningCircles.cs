using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SourceFilmMakerManager.control {

    public class SpinningCircles : Control {
        private int increment = 2;
        private int radius = 2;
        private int n = 4;
        private int next = 0;
        private Timer timer;

        public SpinningCircles() {
            timer = new Timer();
            this.Size = new Size(100, 100);
            timer.Tick += (s, e) => this.Invalidate();
            if (!DesignMode)
                timer.Enabled = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (Parent != null && this.BackColor == Color.Transparent) {
                using (var bmp = new Bitmap(Parent.Width, Parent.Height)) {
                    Parent.Controls.Cast<Control>()
                          .Where(c => Parent.Controls.GetChildIndex(c) > Parent.Controls.GetChildIndex(this))
                          .Where(c => c.Bounds.IntersectsWith(this.Bounds))
                          .OrderByDescending(c => Parent.Controls.GetChildIndex(c))
                          .ToList()
                          .ForEach(c => c.DrawToBitmap(bmp, c.Bounds));

                    e.Graphics.DrawImage(bmp, -Left, -Top);
                }
            }
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            int length = Math.Min(Width, Height);
            PointF center = new PointF(length / 2, length / 2);
            int bigRadius = length / 2 - radius - (n - 1) * increment;
            float unitAngle = 360 / n;
            if (!DesignMode)
                next++;
            next = next >= n ? 0 : next;
            int a = 0;
            for (int i = next; i < next + n; i++) {
                int factor = i % n;
                float c1X = center.X + (float)(bigRadius * Math.Cos(unitAngle * factor * Math.PI / 180));
                float c1Y = center.Y + (float)(bigRadius * Math.Sin(unitAngle * factor * Math.PI / 180));
                int currRad = radius + a * increment;
                PointF c1 = new PointF(c1X - currRad, c1Y - currRad);
                e.Graphics.FillEllipse(Brushes.DimGray, c1.X, c1.Y, 2 * currRad, 2 * currRad);
                using (Pen pen = new Pen(Color.Black, 2))
                    e.Graphics.DrawEllipse(pen, c1.X, c1.Y, 2 * currRad, 2 * currRad);
                a++;
            }
        }

        protected override void OnVisibleChanged(EventArgs e) {
            timer.Enabled = Visible;
            base.OnVisibleChanged(e);
        }
    }
}