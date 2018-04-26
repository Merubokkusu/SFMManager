using SourceFilmMakerManager;
using System;
using System.Configuration;

//using System.IO.Compression.FileSystem;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {

    public partial class Settings : Form {
        private IniFile configIni = new IniFile("config.ini");

        public Settings() {
            InitializeComponent();
            idLabel.Text = "SFManager\nVersion: " + Form1.VERSIONID;
            id_numberLabel.Text = Form1.CurrentVer.ToString();
            textBox1.Text = configIni.Read("SFMPATH");
            this.AllowDrop = false;

            //RadioButtons...Duh
            RadioBottons();
        }

        public void RadioBottons() {
            bool autoupdate = Convert.ToBoolean(configIni.Read("AutoUpdate"));
            if (autoupdate == true) {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            } else {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }

            if (configIni.Read("DownloadServer") == "1") {
                radioButton3.Checked = true;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
            }
            if (configIni.Read("DownloadServer") == "2") {
                radioButton3.Checked = false;
                radioButton4.Checked = true;
                radioButton5.Checked = false;
            }
            if (configIni.Read("DownloadServer") == "3") {
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = true;
            }
        }


        public void IgnoreExceptions(Action act) {
            try {
                act.Invoke();
            }
            catch { }
        }


        private void button8_Click(object sender, EventArgs e) {
            configIni.Write("SFMPATH",textBox1.Text);
            MessageBox.Show("Please Relaunch SFMM");
        }

        private void AutoUpdateTrue_Checked(object sender, EventArgs e) {
            configIni.Write("AutoUpdate", "true");
        }
        private void AutoUpdateFalse_Checked(object sender, EventArgs e) {
            configIni.Write("AutoUpdate", "false");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) {
            configIni.Write("DownloadServer", "1");
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e) {
            configIni.Write("DownloadServer", "2");
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e) {
            configIni.Write("DownloadServer", "3");
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