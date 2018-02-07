using SharpCompress.Common;
using SharpCompress.Readers;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WindowsFormsApplication1;

namespace SourceFilmMakerManager.Manager {

    public static class modMan {
        public static string managerDir = @"SFM\Manager\";
        public static string Source = null; 
        public static string Author = null;
        public static string fileLink = null;
        public static string[] Folders { get; private set; }

        public static bool IsDirectoryEmpty(string path) {
            string[] dirs = System.IO.Directory.GetDirectories(path);
            return dirs.Length == 0;
        }

        public static void Extract(string FilePath) {
            Form1.AddingStart = true;
            Form1.AddingEnd = false;
            BackgroundWorker bw = new BackgroundWorker();

            bw.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args) {
                try {
                    string AddonName;
                    AddonName = Path.GetFileNameWithoutExtension(FilePath);
                    AddonName = AddonName.Replace("_", " ");
                    AddonName = Regex.Replace(AddonName, "(?<=[a-z])([A-Z])", " $1");
                    string extensionName = Path.GetExtension(FilePath);
                    Console.WriteLine("Compressed addon is " + extensionName);
                    Console.WriteLine("Adding Addon " + AddonName);
                    Directory.CreateDirectory(managerDir + AddonName);
                    if (extensionName == ".7z") {
                        Console.WriteLine("Using 7za.exe");
                        string zPath = @"Resources\7za.exe";// change the path and give yours
                        try {
                            ProcessStartInfo pro = new ProcessStartInfo();
                            pro.WindowStyle = ProcessWindowStyle.Hidden;
                            pro.FileName = zPath;
                            pro.Arguments = "x \"" + FilePath + "\" -o" + "\"" + managerDir + AddonName + "\"";
                            Process x = Process.Start(pro);
                            x.WaitForExit();
                        }
                        catch (System.Exception Ex) {
                            Console.WriteLine("Error in .7z extraction " + Ex);
                            //DO logic here
                        }
                        DirCheckLister(AddonName);
                    }
                    else {
                        if (extensionName == ".bsp" || extensionName == ".py") {
                            Console.WriteLine("Since file is " + extensionName + " There is no extracting to be done, skipping to next task.");
                            CreateList(managerDir + AddonName, AddonName);
                        }
                        else {
                            using (Stream stream = File.OpenRead(FilePath)) {
                                var reader = ReaderFactory.Open(stream);
                                while (reader.MoveToNextEntry()) {
                                    if (!reader.Entry.IsDirectory) {
                                        reader.WriteEntryToDirectory(managerDir + AddonName, new ExtractionOptions() {
                                            ExtractFullPath = true,
                                            Overwrite = true
                                        });
                                    }
                                }
                            }
                            DirCheckLister(AddonName);
                        }
                    }
                    if (FilePath.Contains("Manager")) {
                        File.Delete(FilePath);
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine("An error occured in Extract: " + ex.Message);
                }
            });
            bw.RunWorkerAsync();
        }

        public static void DirCheckLister(string AddonName) {
            Console.WriteLine("Starting Folder Checker");
            if (!Directory.Exists(managerDir + AddonName + "materials") && !Directory.Exists(managerDir + AddonName + "models") && Directory.Exists(managerDir + AddonName + "scripts")) {
                CreateList(managerDir + AddonName + @"scripts\sfm\animset\", AddonName);
                Console.WriteLine("Addon is a Script (py)");
            } else {
                if (IsDirectoryEmpty(managerDir + AddonName) == true) {
                    CreateList(managerDir + AddonName, AddonName);
                    Console.WriteLine("Addon is a Single File (Map Or RIG...If its anything else it works)");
                } else {
                    Console.WriteLine("Addon is a Normal");
                    GetSubDirectories(AddonName);
                }

                // GetSubDirectories();
            }
        }

        public static void CreateList(string AddonFiles, string AddonName) {
            BackgroundWorker bw = new BackgroundWorker();

            bw.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args) {
                try {
                    Directory.CreateDirectory(@"SFM\SFMM\" + AddonName);
                    FileStream fs1 = new FileStream(@"SFM\SFMM\" + AddonName + @"\" + AddonName + ".SFMM", FileMode.OpenOrCreate, FileAccess.Write);
                    var infoIni = new IniFile(@"SFM\SFMM\" + AddonName + @"\"+ "info.ini");
                    infoIni.Write("Date", DateTime.Now.ToString());
                    infoIni.Write("Source", Source);
                    infoIni.Write("Author", Author);
                    infoIni.Write("URL", fileLink);
                    StreamWriter writer = new StreamWriter(fs1);

                    var skipDirectory = AddonFiles.Length;

                    if (!AddonFiles.EndsWith("" + Path.DirectorySeparatorChar)) skipDirectory++;

                    var AllFiles = Directory
                                    .EnumerateFiles(AddonFiles, "*", SearchOption.AllDirectories)
                                    .Select(f => f.Substring(skipDirectory));

                    foreach (string ListAddon in AllFiles) {
                        if (!ListAddon.EndsWith(".bsp") && !ListAddon.EndsWith(".py")) {
                            writer.WriteLine(ListAddon);
                            Console.WriteLine(ListAddon);
                        }
                    }
                    var thisPath = managerDir + AddonName;
                    var skip2Directory = thisPath.Length;

                    if (!managerDir.EndsWith("" + Path.DirectorySeparatorChar)) skip2Directory++;

                    var OtherFiles = Directory
                                    .EnumerateFiles(managerDir, "*", SearchOption.AllDirectories)
                                    .Select(f => f.Substring(skip2Directory));

                    foreach (string ListAddon in OtherFiles) {
                        if (ListAddon.EndsWith(".py")) {
                            writer.WriteLine(@"scripts\sfm\animset\" + Path.GetFileName(ListAddon));
                            Console.WriteLine(@"scripts\sfm\animset\" + Path.GetFileName(ListAddon));
                        }
                        if (ListAddon.EndsWith(".bsp")) {
                            writer.WriteLine(@"maps\" + Path.GetFileName(ListAddon));
                            Console.WriteLine(@"maps\" + Path.GetFileName(ListAddon));
                        }
                    }
                    writer.Close();
                    FileTransfer(AddonFiles, Form1.SFMPATH, AddonName);
                }
                catch (Exception ex) {
                    Console.WriteLine("An error occured in CreateList: " + ex.Message);
                }
            });
            bw.RunWorkerAsync();
        }

        public static void FileTransfer(string SourcePath, string DestinationPath, string AddonName) {
            BackgroundWorker bw = new BackgroundWorker();

            bw.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args) {
                try {
                    Form1.AddingStart = true;
                    Form1.AddingEnd = false;
                    string[] directories = System.IO.Directory.GetDirectories(SourcePath, "*.*", SearchOption.AllDirectories);

                    Parallel.ForEach(directories, dirPath => {
                        Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));
                    });

                    string[] files = System.IO.Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories);

                    Parallel.ForEach(files, newPath => {
                        if (!newPath.EndsWith(".bsp") && !newPath.EndsWith(".py")) {
                            File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
                        }
                    });
                    //Find PY (AKA RIGS)
                    string[] Rigfiles = System.IO.Directory.GetFiles(managerDir + AddonName, "*.py", SearchOption.AllDirectories);
                    foreach (string rigPY in Rigfiles) {
                        File.Copy(rigPY, Form1.SFMPATH + @"\scripts\sfm\animset\" + Path.GetFileName(rigPY), true);
                    }

                    //Find .BSP (AKA MAPS)
                    string[] Mapfiles = System.IO.Directory.GetFiles(managerDir + AddonName, "*.bsp", SearchOption.AllDirectories);
                    foreach (string mapBSP in Mapfiles) {
                        File.Copy(mapBSP, Form1.SFMPATH + @"\maps\" + Path.GetFileName(mapBSP), true);
                    }

                    Form1.RefreshAddon = true;

                    Console.WriteLine("-Done Adding Addon-");
                    Source = null;
                    Author = null;
                    fileLink = null;

                    //DirectoryInfo di = new DirectoryInfo(managerDir+ AddonName);

                    Directory.Delete(managerDir + AddonName, true);

                    Form1.AddingStart = false;
                    Form1.AddingEnd = true;
                }
                catch (Exception ex) {
                    Console.WriteLine("An error occured in FileTransfer: " + ex.Message);
                }
            });
            bw.RunWorkerAsync();
        }

        //=====================//
        //=====================//
        //======Ref Codes======//
        //=====================//
        //=====================//
        public static void GetSubDirectories(string AddonName) {
            Console.WriteLine("Starting File Finder");
            string root = managerDir + AddonName;
            // Get all subdirectories
            string[] subdirectoryEntries = Directory.GetDirectories(root);
            // Loop through them to see if they have any other subdirectories
            foreach (string subdirectory in subdirectoryEntries)
                if (Directory.Exists(subdirectory)) {
                    LoadSubDirs(subdirectory, AddonName);
                }
        }

        public static void LoadSubDirs(string dir, string AddonName) {
            try {
                if (Directory.Exists(dir)) {
                    var Folders = Directory.GetDirectories(dir);

                    if (dir.EndsWith("materials")) {
                        Console.WriteLine("Found " + dir);
                        DirectoryInfo extractedAddonFolder = Directory.GetParent(dir);
                        CreateList(extractedAddonFolder.ToString(), AddonName);
                    }
                    if (dir.EndsWith("Materials")) {
                        Console.WriteLine("Found " + dir);
                        DirectoryInfo extractedAddonFolder = Directory.GetParent(dir);
                        CreateList(extractedAddonFolder.ToString(), AddonName);
                    }

                    //Sound
                    if (dir.EndsWith("sound")) {
                        Console.WriteLine("Found " + dir);
                        DirectoryInfo extractedAddonFolder = Directory.GetParent(dir);
                        CreateList(extractedAddonFolder.ToString(), AddonName);
                    }
                    if (dir.EndsWith("Sound")) {
                        Console.WriteLine("Found " + dir);
                        DirectoryInfo extractedAddonFolder = Directory.GetParent(dir);
                        CreateList(extractedAddonFolder.ToString(), AddonName);
                    }

                    string[] subdirectoryEntries = Folders;
                    foreach (string subdirectory in subdirectoryEntries) {
                        LoadSubDirs(subdirectory, AddonName);
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine("An error occured in LoadSubDirs: " + ex.Message);
            }
        }
    }
}