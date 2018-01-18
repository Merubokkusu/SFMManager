using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceFilmMakerManager.Manager
{
    public static class modMan
    {
       public static string managerDir = @"SFM\Manager\";
       public static void Extract(string FilePath) {
            
        }
       public static void FindFileLoc() {
            string ThisDir;

            if (Directory.Exists(managerDir + "models")) {

                FileTransfer(managerDir);
            }
            else {
            ThisDir = Directory.GetDirectories(managerDir)[0];
            if (Directory.Exists(ThisDir + @"\models")) {
                    FileTransfer(ThisDir);
                }
            else {
            if (Directory.Exists(Directory.GetDirectories(ThisDir)[0] + @"\models")) {
                        FileTransfer(Directory.GetDirectories(ThisDir)[0]);
                    }

            }
            }
}

        public static void FileTransfer(string addonContentFolder) {

            MessageBox.Show(addonContentFolder);


        }

   }
}
