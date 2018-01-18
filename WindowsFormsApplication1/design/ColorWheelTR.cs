using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Controlz {

    public partial class ColorWheelTR : UserControl {
        private int colorpicked = 0;
        private bool ignore = false;
        private Bitmap bmp = new Bitmap(385, 120);
        private double MasterHue = 0;
        private double MasterSat = 0;
        private double MasterVal = 0;
        private int MasterAlpha = 255;

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified) {
            // Set a fixed height and width for the control.
            base.SetBoundsCore(x, y, 385, 120, specified);
        }

        public double hue {
            get { return MasterHue * 360; }
        }

        public double sat {
            get { return MasterSat * 100; }
        }

        public double val {
            get { return MasterVal * 100; }
        }

        public int alph {
            get { return MasterAlpha; }
        }

        public Color colorval {
            get { return HSVtoRGB(MasterAlpha, MasterHue, MasterSat, MasterVal); }
            set {
                Color _colorval = value;
                MasterHue = RGBtoHSV(_colorval, MasterHue).Hue;
                MasterSat = RGBtoHSV(_colorval, MasterHue).Sat;
                MasterVal = RGBtoHSV(_colorval, MasterHue).Value;
                // MasterAlpha = _colorval.A;
                setColors(true, true);
                this.Refresh();
                OnValueChanged(_colorval);
            }
        }

        public delegate void ValueChangedEventHandler(object sender, Color e);

        public event ValueChangedEventHandler ValueChanged;

        protected void OnValueChanged(Color e) {
            if (this.ValueChanged != null) this.ValueChanged(this, e);
        }

        private Color HSVtoRGB(int alpha, double h, double s, double v) {
            double r, g, b;
            if (s == 0) {
                r = v;
                g = v;
                b = v;
            } else {
                double varH = h * 6;
                double varI = Math.Floor(varH);
                double var1 = v * (1 - s);
                double var2 = v * (1 - (s * (varH - varI)));
                double var3 = v * (1 - (s * (1 - (varH - varI))));

                if (varI == 0) {
                    r = v;
                    g = var3;
                    b = var1;
                } else if (varI == 1) {
                    r = var2;
                    g = v;
                    b = var1;
                } else if (varI == 2) {
                    r = var1;
                    g = v;
                    b = var3;
                } else if (varI == 3) {
                    r = var1;
                    g = var2;
                    b = v;
                } else if (varI == 4) {
                    r = var3;
                    g = var1;
                    b = v;
                } else {
                    r = v;
                    g = var1;
                    b = var2;
                }
            }
            return Color.FromArgb(255, (int)(r * 255), (int)(g * 255), (int)(b * 255));
        }

        private HSVColor RGBtoHSV(Color c, double oldHue) {
            double r = (double)c.R / 255;
            double g = (double)c.G / 255;
            double b = (double)c.B / 255;
            double varMin = Math.Min(r, Math.Min(g, b));
            double varMax = Math.Max(r, Math.Max(g, b));
            double delMax = varMax - varMin;
            HSVColor hsv = new HSVColor();

            hsv.Value = varMax;

            if (delMax == 0) {
                hsv.Hue = oldHue;
                hsv.Sat = 0;
            } else {
                double delR = (((varMax - r) / 6) + (delMax / 2)) / delMax;
                double delG = (((varMax - g) / 6) + (delMax / 2)) / delMax;
                double delB = (((varMax - b) / 6) + (delMax / 2)) / delMax;

                hsv.Sat = delMax / varMax;

                if (r == varMax) {
                    hsv.Hue = delB - delG;
                } else if (g == varMax) {
                    hsv.Hue = (1.0 / 3) + delR - delB;
                } else //// if (b == varMax)
                  {
                    hsv.Hue = (2.0 / 3) + delG - delR;
                }

                if (hsv.Hue < 0) {
                    hsv.Hue += 1;
                }

                if (hsv.Hue > 1) {
                    hsv.Hue -= 1;
                }
            }

            return hsv;
        }

        public ColorWheelTR() {
            InitializeComponent();
        }

        private void GenColorWheel_Paint() {
            Rectangle myrect = new Rectangle(0, 0, 200, 100);
            int slim = myrect.Width / 10;

            Rectangle wrect = new Rectangle(2, 2, 100, 100);
            Rectangle mrect = new Rectangle(-1, -1, myrect.Width / 2 + 2, myrect.Height + 2);
            Rectangle Lrect = new Rectangle((int)(5.5f * slim), 0, slim, myrect.Height + 2);
            Rectangle Arect = new Rectangle((int)(7.5f * slim), 0, slim, myrect.Height + 2);
            Rectangle Crect = new Rectangle((int)(9 * slim) - 2, 2, slim, slim);

            #region create wheel

            GraphicsPath wheel_path = new GraphicsPath();
            wheel_path.AddEllipse(wrect);
            wheel_path.Flatten();

            float num_pts = wheel_path.PointCount;
            Color[] surround_colors = new Color[wheel_path.PointCount];
            for (float i = 0; i < num_pts; i++) {
                Color c = HSVtoRGB(255, i / num_pts, 1, 1);
                surround_colors[(int)i] = c;
            }

            #endregion create wheel

            using (Graphics g = Graphics.FromImage(bmp)) {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillRectangle(new SolidBrush(this.BackColor), 0, 0, 385, 120);
                using (Pen pen = new Pen(this.BackColor, 2f)) {
                    g.DrawEllipse(pen, mrect);
                }
                using (PathGradientBrush path_brush = new PathGradientBrush(wheel_path)) {
                    path_brush.CenterColor = Color.White;
                    path_brush.SurroundColors = surround_colors;

                    g.FillPath(path_brush, wheel_path);
                    using (Pen thick_pen = new Pen(this.BackColor, 1.5f)) {
                        g.DrawPath(thick_pen, wheel_path);
                    }
                }

                Color Color1 = HSVtoRGB(255, MasterHue, MasterSat, 1);

                //Draw Lightness Control
                using (LinearGradientBrush lgb = new LinearGradientBrush(Lrect, Color1, Color.Black, LinearGradientMode.Vertical)) {
                    Pen pen = new Pen(lgb);
                    g.FillRectangle(lgb, Lrect);
                    pen.Dispose();
                }

                //draw alpha control
                // HatchBrush hb = new HatchBrush(HatchStyle.LargeCheckerBoard, Color.LightGray, Color.White);
                // g.FillRectangle(hb, Arect);

                Color _colorval = HSVtoRGB(255, MasterHue, MasterSat, MasterVal);
                using (LinearGradientBrush lgb = new LinearGradientBrush(Arect, _colorval, Color.Transparent, LinearGradientMode.Vertical)) {
                    Pen pen = new Pen(lgb);
                    g.FillRectangle(lgb, Arect);
                    pen.Dispose();
                }

                //draw colorsample
                Color CB = _colorval;

                SolidBrush SB = new SolidBrush(CB);
                //  g.FillRectangle(hb, Crect);
                g.FillRectangle(SB, Crect);
                g.DrawRectangle(Pens.Black, Crect);
                //hb.Dispose();

                // set val markers
                int _val = (int)(MasterVal * 100);
                int mark = (int)(MasterVal * 255);

                _val = (_val > 100) ? 100 : _val;
                int valtop = myrect.Height - _val * myrect.Height / 100;

                Rectangle valMark = new Rectangle(Lrect.Left, valtop, Lrect.Width, 3);
                using (Pen valPen = new Pen(Color.FromArgb(255, 255 - mark, 255 - mark, 255 - mark))) {
                    g.DrawRectangle(valPen, valMark);
                }

                // set alpha markers
                // int alphtop = myrect.Height - MasterAlpha * myrect.Height / 255;
                //Rectangle alphMark = new Rectangle(Arect.Left, alphtop, slim, 3);
                // g.DrawRectangle(Pens.Black, alphMark);

                //set _hue and sat marker
                double hlfht = 50;

                double radius = MasterSat * (hlfht - 1);

                int _hueX = (int)(hlfht + radius * Math.Cos(MasterHue * Math.PI / .5));
                int _huey = (int)(hlfht + radius * Math.Sin(MasterHue * Math.PI / .5));
                Rectangle _hueMark = new Rectangle(_hueX, _huey, 5, 5);
                g.DrawEllipse(new Pen(Color.Black), _hueMark);
            }
        }

        private void GenColorWheel_MouseDown(object sender, MouseEventArgs e) {
            Panel p = (Panel)sender;

            Rectangle myrect = new Rectangle(0, 0, 200, 100);
            int slim = myrect.Width / 10;
            int hlfht = myrect.Height / 2;
            double offset = Math.Sqrt((e.Y - hlfht) * (e.Y - hlfht) + (e.X - hlfht) * (e.X - hlfht));
            Rectangle Lrect = new Rectangle((int)(5.5f * slim), 0, slim, myrect.Height + 2);
            Rectangle Arect = new Rectangle((int)(7.5f * slim), 0, slim, myrect.Height + 2);

            if (offset <= 53) {
                colorpicked = 1;
            } else if (Lrect.Contains(e.Location)) {
                colorpicked = 2;
            } else if (Arect.Contains(e.Location)) {
                colorpicked = 3;
                //}
                //else
                //{
                //    //colorpicked = 0;
            }

            GenColorWheel_MouseMove(sender, e);
        }

        private void GenColorWheel_MouseMove(object sender, MouseEventArgs e) {
            Panel p = (Panel)sender;
            if (colorpicked == 0) return;

            Rectangle myrect = new Rectangle(0, 0, 200, 100);
            int slim = myrect.Width / 10;
            int hlfht = myrect.Height / 2;
            double offset;
            offset = Math.Sqrt((e.Y - hlfht) * (e.Y - hlfht) + (e.X - hlfht) * (e.X - hlfht)) / (double)hlfht;
            Rectangle Lrect = new Rectangle((int)(5.5f * slim), 0, slim, myrect.Height);
            Rectangle Arect = new Rectangle((int)(7.5f * slim), 0, slim, myrect.Height);
            Rectangle Lrect2 = new Rectangle((int)(5.5f * slim), 0, slim, myrect.Height + 2);
            Rectangle Arect2 = new Rectangle((int)(7.5f * slim), 0, slim, myrect.Height + 2);

            if (offset < 1.4 && colorpicked == 1) {
                double rad = Math.Atan2(e.Y - hlfht, e.X - hlfht) * .5 / Math.PI;
                MasterHue = (rad < 0) ? rad + 1 : rad;

                //offset = Math.Sqrt((e.Y - hlfht) * (e.Y - hlfht) + (e.X - hlfht) * (e.X - hlfht)) / (double)hlfht;
                MasterSat = (offset > 1) ? 1 : offset;
            } else if (Lrect2.Contains(e.Location) && colorpicked == 2) {
                offset = 1 - (double)(e.Y - Lrect.Y) / (double)Lrect.Height;
                MasterVal = (offset < 0) ? 0 : offset;
            } else {
                //colorpicked = 0;
                return;
            }
            Color _colorval = HSVtoRGB(255, MasterHue, MasterSat, MasterVal);
            setColors(true, true);
            OnValueChanged(_colorval);
            this.Refresh();
        }

        private void GenColorWheel_MouseUp(object sender, MouseEventArgs e) {
            Panel p = (Panel)sender;
            Color _colorval = HSVtoRGB(MasterAlpha, MasterHue, MasterSat, MasterVal);
            OnValueChanged(_colorval);
            colorpicked = 0;
            this.Refresh();
        }

        private void setColors(bool rgb, bool hex) {
            ignore = true;
            Color _colorval = HSVtoRGB(MasterAlpha, MasterHue, MasterSat, MasterVal);
            if (rgb) {
                red1.Value = _colorval.R;
                green1.Value = _colorval.G;
                blue1.Value = _colorval.B;
            }
            Hue1.Value = (decimal)MasterHue * 360;
            Sat1.Value = (decimal)MasterSat * 100;
            Val1.Value = (decimal)MasterVal * 100;
            if (hex) hexBox.Text = _colorval.ToArgb().ToString("X8");
            ignore = false;
        }

        private void rgb_ValueChanged() {
            if (!ignore) {
                Color _colorval = Color.FromArgb((int)255,
                    (int)red1.Value, (int)green1.Value, (int)blue1.Value);
                MasterHue = RGBtoHSV(_colorval, MasterHue).Hue;
                MasterSat = RGBtoHSV(_colorval, MasterHue).Sat;
                MasterVal = RGBtoHSV(_colorval, MasterHue).Value;
                MasterAlpha = _colorval.A;
                setColors(false, true);
                this.Refresh();
                OnValueChanged(_colorval);
            }
        }

        private void HSV_ValueChanged() {
            if (!ignore) {
                MasterHue = (double)Hue1.Value / 360;
                MasterSat = (double)Sat1.Value / 100;
                MasterVal = (double)Val1.Value / 100;
                setColors(true, true);
                this.Refresh();
                Color _colorval = HSVtoRGB(MasterAlpha, MasterHue, MasterSat, MasterVal);
                OnValueChanged(_colorval);
            }
        }

        private void hexBox_Changed() {
            if (!ignore) {
                try {
                    ColorConverter c = new ColorConverter();
                    Color _colorval = (Color)c.ConvertFromString("#" + hexBox.Text);
                    MasterHue = RGBtoHSV(_colorval, MasterHue).Hue;
                    MasterSat = RGBtoHSV(_colorval, MasterHue).Sat;
                    MasterVal = RGBtoHSV(_colorval, MasterHue).Value;
                    MasterAlpha = _colorval.A;

                    setColors(true, false);
                    this.Refresh();
                    OnValueChanged(_colorval);
                }
                catch {
                    Color _colorval = HSVtoRGB(MasterAlpha, MasterHue, MasterSat, MasterVal);
                    hexBox.Text = _colorval.ToArgb().ToString("X8");
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
        }

        protected override void OnPaint(PaintEventArgs e) {
            GenColorWheel_Paint();
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void hexBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Return) hexBox_Changed();
        }

        private void hexBox_Leave(object sender, EventArgs e) {
            hexBox_Changed();
        }

        private void ARGB_MouseUp(object sender, MouseEventArgs e) {
            rgb_ValueChanged();
        }

        private void ARGB_Leave(object sender, EventArgs e) {
            rgb_ValueChanged();
        }

        private void Hex_MouseUp(object sender, MouseEventArgs e) {
            hexBox_Changed();
        }

        private void HSV_MouseUp(object sender, MouseEventArgs e) {
            HSV_ValueChanged();
        }

        private void HSV_Leave(object sender, EventArgs e) {
            HSV_ValueChanged();
        }

        private void ARGB_ValueChanged(object sender, EventArgs e) {
            rgb_ValueChanged();
        }

        private void HSV_ValueChanged(object sender, EventArgs e) {
            HSV_ValueChanged();
        }
    }

    public class HSVColor {

        public double Hue {
            get;
            set;
        }

        public double Sat {
            get;
            set;
        }

        public double Value {
            get;
            set;
        }
    }
}