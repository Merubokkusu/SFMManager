using System;
using System.Configuration;
using System.Diagnostics;

//using System.IO.Compression.FileSystem;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {

    public partial class Tools : Form {
        private int TogMove;
        private int MValX;
        private int MValY;
        private string SFMPATH = ConfigurationManager.AppSettings["SFM_PATH"];

        public Tools() {
            InitializeComponent();
            // Enable drag and drop for this form
            // (this can also be applied to any controls)
            this.AllowDrop = true;

            // Add event handlers for the drag & drop functionality

            //Colors
            CreateMyBorderlessWindow();

            //Color For Form
            Colors();
        }

        public void CreateMyBorderlessWindow() {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            // Remove the control box so the form will only display client area.
            this.ControlBox = false;
        }

        public void Colors() {
            string MainBG = ConfigurationManager.AppSettings["MainBG"];
            string TopBar = ConfigurationManager.AppSettings["TopBar"];
            string ButtonColor = ConfigurationManager.AppSettings["Button Color"];

            Color BGColor = System.Drawing.ColorTranslator.FromHtml(MainBG);
            Color TBColor = System.Drawing.ColorTranslator.FromHtml(TopBar);
            Color Button_Color = System.Drawing.ColorTranslator.FromHtml(ButtonColor);

            BackColor = BGColor;
            pictureBox1.BackColor = TBColor;
            pictureBox2.BackColor = TBColor;
            pictureBox4.BackColor = TBColor;
            label1.BackColor = TBColor;
            button1.BackColor = BGColor;
            button1.ForeColor = BGColor;
            button2.BackColor = BGColor;
            button2.ForeColor = BGColor;
            button3.BackColor = BGColor;
            button3.ForeColor = BGColor;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            TogMove = 0;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (TogMove == 1) {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e) {
            pictureBox4.BackColor = Color.Red;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e) {
            string TopBar = ConfigurationManager.AppSettings["TopBar"];
            Color TBColor = System.Drawing.ColorTranslator.FromHtml(TopBar);
            pictureBox4.BackColor = TBColor;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e) {
            pictureBox2.BackColor = Color.FromArgb(50, 50, 50, 50);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e) {
            string TopBar = ConfigurationManager.AppSettings["TopBar"];
            Color TBColor = System.Drawing.ColorTranslator.FromHtml(TopBar);
            pictureBox2.BackColor = TBColor;
        }

        private void pictureBox4_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click_1(object sender, EventArgs e) {
        }

        private void Form1_Load(object sender, EventArgs e) {
            Console.WriteLine("=============================");
            Console.WriteLine("==========LOG START==========");
            Console.WriteLine("=============================");
        }

        public void IgnoreExceptions(Action act) {
            try {
                act.Invoke();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e) {
            var BinPath = Directory.GetParent(SFMPATH) + @"\bin\";
            Process.Start(BinPath + "hammer.exe");
        }

        private void button2_Click(object sender, EventArgs e) {
            var BinPath = Directory.GetParent(SFMPATH) + @"\bin\";
            Process.Start(BinPath + "hlmv.exe");
        }

        private void button3_Click(object sender, EventArgs e) {
            var BinPath = Directory.GetParent(SFMPATH);
            Process.Start(BinPath + "/sfm.exe");
        }
    }//Form End
}