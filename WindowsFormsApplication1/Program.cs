using SourceFilmMakerManager;
using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {

    internal static class Program {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args) {
            Guid guid = new Guid("{054C234F-471F-4F7D-A49E-7B85ACBBF5BD}");
            using (SingleInstance singleInstance = new SingleInstance(guid)) {
                if (singleInstance.IsFirstInstance) {
                    singleInstance.ArgumentsReceived += singleInstance_ArgumentsReceived;
                    singleInstance.ListenForArgumentsFromSuccessiveInstances();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(form = new Form1());
                    if (args.Length > 0) {
                        MessageBox.Show("SFMM Isn't running, please start it then click");
                        //downloader.SFMLabURL = args[0];
                        // downloader.Download(downloader.SFMLabURL.Remove(0, 5));
                    }
                }
                else
                    singleInstance.PassArgumentsToFirstInstance(Environment.GetCommandLineArgs());
            }
        }

        private static Form1 form;

        private static void singleInstance_ArgumentsReceived(object sender, ArgumentsReceivedEventArgs e) {
            if (form == null)
                return;

            Action<String[]> updateForm = arguments => {
                form.WindowState = FormWindowState.Normal;
                // form.OpenFiles(arguments);
                //downloader.SFMLabURL = arguments[1].ToString().Remove(0,5);
                downloader.Download(arguments[1].ToString().Remove(0, 5));
            };
            form.Invoke(updateForm, (Object)e.Args); //Execute our delegate on the forms thread!
        }
    }
}