using SourceFilmMakerManager;
using System;
using System.Configuration;

//using System.IO.Compression.FileSystem;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {

    public partial class Settings : Form {
        private string AUTOCHECKUPDATE = ConfigurationManager.AppSettings["Auto_Check_For_Updates"];
        private string DownloadServer = ConfigurationManager.AppSettings["Download_Server"];

        public Settings() {
            InitializeComponent();
            idLabel.Text = "SFManager\nVersion: " + Form1.VERSIONID;
            id_numberLabel.Text = Form1.CurrentVer.ToString();
            textBox1.Text = ConfigurationManager.AppSettings["SFM_PATH"];
            // Enable drag and drop for this form
            // (this can also be applied to any controls)
            this.AllowDrop = false;

            // Add event handlers for the drag & drop functionality



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
        }

        private void Settings_Load(object sender, EventArgs e)
        {
        }

        public void IgnoreExceptions(Action act) {
            try {
                act.Invoke();
            }
            catch { }
        }


        private void button8_Click(object sender, EventArgs e) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SFM_PATH"].Value = textBox1.Text;
            config.Save(ConfigurationSaveMode.Minimal);
            MessageBox.Show("Please Relaunch SFMM");
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

        private void updateButton_Click(object sender, EventArgs e) {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true) {
                WebClient wc = new WebClient();
                try {
                    string Ver = wc.DownloadString("http://sfmm.merubokkusu.com/version.txt");

                    //
                    //CurrentVer is set to the current version....
                    //
                    if (Form1.CurrentVer < float.Parse(Ver)) {
                        DialogResult result1 = MessageBox.Show("Go To The Download Page?", "New Version Available", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes) {
                            Console.Write("Going To SFMMLab");
                            System.Diagnostics.Process.Start("https://sfmlab.com/item/1297/");
                        }
                    }
                    else {
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
    }//Form End
}