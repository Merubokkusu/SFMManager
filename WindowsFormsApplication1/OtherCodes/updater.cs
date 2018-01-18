using System;
using System.Configuration;
using System.Net;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace SourceFilmMakerManager.OtherCodes {

    public static class updater {

        public static void VersionCheck() {
            float CurrentVer = Form1.CurrentVer;
            bool AUTOCHECKUPDATE = Convert.ToBoolean(ConfigurationManager.AppSettings["Auto_Check_For_Updates"]);

            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true) {
                WebClient wc = new WebClient();
                try {
                    string Ver = wc.DownloadString("http://sfmm.hol.es/version.txt");

                    //
                    //CurrentVer is set to the current version....
                    //
                    if (CurrentVer < float.Parse(Ver)) {
                        DialogResult result1 = MessageBox.Show("Go To The Download Page?", "New Version Available", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes) {
                            Console.Write("Going To SFMMANAGER.TUMBLR");
                            System.Diagnostics.Process.Start("http://sfmmanager.tumblr.com/");
                            //Run

                            Application.Exit();
                        } else {
                            //Run
                        }
                    } else {
                        Console.WriteLine(random.VR);
                        //Run
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
    }
}