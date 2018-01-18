using SourceFilmMakerManager;
using System;
using System.Configuration;

//using System.IO.Compression.FileSystem;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {

    public partial class Settings : Form {

        //====
        private string VERSIONID = "Alice";

        //=====

        public Color WheelColor;

        public bool TopColor = false;
        public bool BKColor = false;
        public bool ButtonColor = false;

        public static string RealColor = "FFFFFFFF";
        private string AUTOCHECKUPDATE = ConfigurationManager.AppSettings["Auto_Check_For_Updates"];
        private string DownloadServer = ConfigurationManager.AppSettings["Download_Server"];
        public static string adWeb = ConfigurationManager.AppSettings["Show_Ad"];

        public Settings() {
            InitializeComponent();
            label8.Text = "SFManager\nVersion: " + VERSIONID;
            label10.Text = Form1.CurrentVer.ToString();
            textBox1.Text = ConfigurationManager.AppSettings["SFM_PATH"];
            // Enable drag and drop for this form
            // (this can also be applied to any controls)
            this.AllowDrop = false;

            // Add event handlers for the drag & drop functionality

            //Color For Form
            Colors();

            //RadioButtons...Duh
            RadioBottons();
        }

        public void RadioBottons() {
            bool autoupdate = Convert.ToBoolean(AUTOCHECKUPDATE);
            if (autoupdate == true) {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            } else {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }

            if (DownloadServer == "1") {
                radioButton3.Checked = true;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
            }
            if (DownloadServer == "2") {
                radioButton3.Checked = false;
                radioButton4.Checked = true;
                radioButton5.Checked = false;
            }
            if (DownloadServer == "3") {
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = true;
            }
            if (adWeb == "0") {
                radioButton6.Checked = true;
                radioButton7.Checked = false;
            } else {
                radioButton6.Checked = false;
                radioButton7.Checked = true;
            }
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
        }

        public void IgnoreExceptions(Action act) {
            try {
                act.Invoke();
            }
            catch { }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e) {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Blue, 22);
            g.DrawRectangle(p, this.tabPage1.Bounds);
        }

        public void colorWheelTR1_ValueChanged(object sender, Color e) {
            Color WheelColor = e;
            RealColor = System.Drawing.ColorTranslator.ToHtml(WheelColor);
        }

        private void button6_MouseHover(object sender, EventArgs e) {
            TopBarPew.BackColor = System.Drawing.ColorTranslator.FromHtml("#282828");
            BackPew.BackColor = System.Drawing.ColorTranslator.FromHtml("#181818");
            ButtonPew.BackColor = System.Drawing.ColorTranslator.FromHtml("#dc8628");
        }

        private void button6_Click(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["TopBar"].Value = "#282828";
            config.AppSettings.Settings["MainBG"].Value = "#181818";
            config.AppSettings.Settings["Button Color"].Value = "#dc8628";
            config.Save(ConfigurationSaveMode.Minimal);
            MessageBox.Show("Please Relaunch SFMM");
        }

        private void button7_MouseHover(object sender, EventArgs e) {
            TopBarPew.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF2C7C");
            BackPew.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF325F");
            ButtonPew.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF1882");
        }

        private void button7_Click(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["TopBar"].Value = "#FF2C7C";
            config.AppSettings.Settings["MainBG"].Value = "#FF325F";
            config.AppSettings.Settings["Button Color"].Value = "#FF1882";
            config.Save(ConfigurationSaveMode.Minimal);
            MessageBox.Show("Please Relaunch SFMM");
        }

        private void button5_MouseHover(object sender, EventArgs e) {
            TopBarPew.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF69B4");
            BackPew.BackColor = System.Drawing.ColorTranslator.FromHtml("#DB7093");
            ButtonPew.BackColor = System.Drawing.ColorTranslator.FromHtml("#613141");
        }

        private void button5_Click(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["TopBar"].Value = "#FF69B4";
            config.AppSettings.Settings["MainBG"].Value = "#DB7093";
            config.AppSettings.Settings["Button Color"].Value = "#613141";
            config.Save(ConfigurationSaveMode.Minimal);
            MessageBox.Show("Please Relaunch SFMM");
        }

        private void button4_MouseHover(object sender, EventArgs e) {
            TopBarPew.BackColor = System.Drawing.ColorTranslator.FromHtml("#007fab");
            BackPew.BackColor = System.Drawing.ColorTranslator.FromHtml("#00aae4");
            ButtonPew.BackColor = System.Drawing.ColorTranslator.FromHtml("#008080");
        }

        private void button4_Click(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["TopBar"].Value = "#007fab";
            config.AppSettings.Settings["MainBG"].Value = "#00aae4";
            config.AppSettings.Settings["Button Color"].Value = "#008080";
            config.Save(ConfigurationSaveMode.Minimal);
            MessageBox.Show("Please Relaunch SFMM");
        }

        private void button10_MouseHover(object sender, EventArgs e) {
            TopBarPew.BackColor = System.Drawing.ColorTranslator.FromHtml("#F6DB68");
            BackPew.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E9699");
            ButtonPew.BackColor = System.Drawing.ColorTranslator.FromHtml("#247577");
        }

        private void button10_Click(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["TopBar"].Value = "#F6DB68";
            config.AppSettings.Settings["MainBG"].Value = "#2E9699";
            config.AppSettings.Settings["Button Color"].Value = "#247577";
            config.Save(ConfigurationSaveMode.Minimal);
            MessageBox.Show("Please Relaunch SFMM");
        }

        private void button8_Click(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SFM_PATH"].Value = textBox1.Text;
            config.Save(ConfigurationSaveMode.Minimal);
            MessageBox.Show("Please Relaunch SFMM");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://www.patreon.com/BasicGirl");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://www.paypal.me/basicgirlnsfw");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Auto_Check_For_Updates"].Value = "false";
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Auto_Check_For_Updates"].Value = "true";
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private void button3_Click_1(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["TopBar"].Value = RealColor;
            config.Save(ConfigurationSaveMode.Minimal);
            //ConfigurationManager.RefreshSection("appSettings");
        }

        private void button1_Click_1(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["MainBG"].Value = RealColor;
            config.Save(ConfigurationSaveMode.Minimal);
            //ConfigurationManager.RefreshSection("appSettings");
        }

        private void button2_Click(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Button Color"].Value = RealColor;
            config.Save(ConfigurationSaveMode.Minimal);
            //ConfigurationManager.RefreshSection("appSettings");
        }

        private void label8_Click(object sender, EventArgs e) {
        }

        private void Settings_Load(object sender, EventArgs e) {
        }

        private void button9_Click(object sender, EventArgs e) {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true) {
                WebClient wc = new WebClient();
                try {
                    string Ver = wc.DownloadString("http://sfmm.hol.es/version.txt");

                    //
                    //CurrentVer is set to the current version....
                    //
                    if (Form1.CurrentVer < float.Parse(Ver)) {
                        DialogResult result1 = MessageBox.Show("Go To The Download Page?", "New Version Available", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes) {
                            Console.Write("Going To SFMMANAGER.TUMBLR");
                            System.Diagnostics.Process.Start("http://sfmmanager.tumblr.com/");
                        }
                    } else {
                        MessageBox.Show("Running The Newest Version");
                        Console.WriteLine(random.VR);
                    }
                }
                catch (System.Net.WebException) {
                    MessageBox.Show("Couldn't check for verison, Update Server Is Down.\n You can disable auto check in the config file");
                }
            }//End Internet Check
            else {
                MessageBox.Show("Couldn't check for verison, Your not connected to the internet.\n You can disable auto check in the config file");
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Download_Server"].Value = "1";
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Download_Server"].Value = "2";
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Download_Server"].Value = "3";
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("http://paypal.me/basicgirlnsfw");
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://www.patreon.com/BasicGirl");
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Show_Ad"].Value = "1";
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Show_Ad"].Value = "0";
            config.Save(ConfigurationSaveMode.Minimal);
        }
    }//Form End
}