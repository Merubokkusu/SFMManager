using BrightIdeasSoftware;
using Microsoft.VisualBasic;
using SourceFilmMakerManager;
using SourceFilmMakerManager.Manager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

//using System.IO.Compression.FileSystem;

namespace WindowsFormsApplication1 {

    public partial class Form1 : Form {
        public static float CurrentVer = 6.2f;
        public static string SFMPATH = ConfigurationManager.AppSettings["SFM_PATH"];
        public static bool SplashOver = false;

        public static long completed = 0;
        public static double totalVal = 1;

        public static string SFMLabName;

        public static string[] FileList;

        public static bool RefreshAddon;
        public static bool Download_Start;
        public static bool Download_End;

        public static bool AddingStart;
        public static bool AddingEnd = true;
        private readonly ContextMenu cm;
        private readonly List<string> list = new List<string>();

        public Form1() {
            var t = new Thread(Splashs);
            t.Start();
            Thread.Sleep(3000);

            InitializeComponent();
            BringToFront();

            // Enable drag and drop for this form
            // (this can also be applied to any controls)
            AllowDrop = true;

            // Add event handlers for the drag & drop functionality
            DragEnter += Form_DragEnter;
            DragDrop += Form_DragDrop;

            //Menu Start
            cm = new ContextMenu();
            var CM_Rename = new MenuItem("Rename");
            var CM_Delete = new MenuItem("Delete");
            CM_Rename.Click += OnRenameClicked;
            CM_Delete.Click += button1_Click;

            var collection = new Menu.MenuItemCollection(cm);
            collection.Add(CM_Rename);
            collection.Add(CM_Delete);
            //Menus

            //Create The Log
            logTxt();

            //Refresh addons
            AddonList();

            //List Addons To String.

            ListToString();

            //modMan.FindFileLoc();
            
            
        }

       

        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }

        public void Splashs() {
            Application.Run(new Splash_scn());
        }

        private void ListToString() {
            list.Clear();
            foreach (OLVListItem str in addonListView.Items) {
                list.Add(str.Text);
            }
        }

        // Sort on this column.

        private void listView1_ColumnClick_1(object sender, ColumnClickEventArgs e) {
            var sorter = listView1.ListViewItemSorter as ItemComparer;
            if (sorter == null) {
                sorter = new ItemComparer(e.Column);
                sorter.Order = SortOrder.Ascending;
                listView1.ListViewItemSorter = sorter;
            }
            // if clicked column is already the column that is being sorted
            if (e.Column == sorter.Column) {
                // Reverse the current sort direction
                if (sorter.Order == SortOrder.Ascending)
                    sorter.Order = SortOrder.Descending;
                else
                    sorter.Order = SortOrder.Ascending;
            } else {
                // Set the column number that is to be sorted; default to ascending.
                sorter.Column = e.Column;
                sorter.Order = SortOrder.Ascending;
            }
            listView1.Sort();
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                var item = listView1.GetItemAt(e.Location.X, e.Location.Y);
                if (item != null) {
                    // listView1.SelectedIndices[0] = item.Index;
                    cm.Show(listView1, e.Location);
                }
            }
        }

        public void OnRenameClicked(object sender, EventArgs e) {
            const string f = @"SFM\SFMM\";
            var FileSelect = listView1.SelectedItems[0].Text + ".SFMM";
            var SFMMFILE = f + FileSelect;
            string a;
            a = Interaction.InputBox("Type what you would like to name this file.", "Rename",
                listView1.SelectedItems[0].Text);

            var specialCharacters = @"/:*?<>|" + "\"";
            var specialCharactersArray = specialCharacters.ToCharArray();
            var index = a.IndexOfAny(specialCharactersArray);

            if (index == -1) {
                if (a.Length > 0) {
                    if (!File.Exists(f + a + ".SFMM")) {
                        Console.WriteLine("Renamed " + listView1.SelectedItems[0].Text + " To " + a);
                        File.Move(SFMMFILE, f + a + ".SFMM");
                        listView1.Items.Clear();
                        AddonList();
                        ListToString();
                        // ok
                    } else {
                        Console.WriteLine("File Named " + a + " Already Exists, Couldnt Rename.");
                        MessageBox.Show("File Named " + a + " Already Exists, Couldnt Rename.");
                    }
                }
            } else {
                MessageBox.Show(@"A filename cannot contain any of the following characters: \ / : * ?  < > |" + " \"");
            }
        }

        public static void logTxt() {
            var time = DateTime.Now; // Use current time.
            var format = "M-d h-mm-ss";

            var filestream = new FileStream(@"SFM\SFMM.Log", FileMode.Create);
            var streamwriter = new StreamWriter(filestream);
            streamwriter.AutoFlush = true;
            Console.SetOut(streamwriter);
            Console.SetError(streamwriter);
            Console.WriteLine(time.ToString(format));
        }
        
        private void button1_Click(object sender, EventArgs e) {
            

            foreach (OLVListItem addonItem in addonListView.SelectedItems) {
                if (addonListView.Items.Count > 0) {
                    var result2 = MessageBox.Show("Delete Addon? " + addonItem.Text, "Are You Sure?", MessageBoxButtons.YesNo);
                    if (result2 == DialogResult.Yes) {
                        AddingStart = true;
                        AddingEnd = false;

                        const string f = @"SFM\SFMM\";
                        var FileSelect = "";

                        if (Directory.Exists(f+ addonItem.Text + @"\")){
                            FileSelect = addonItem.Text + @"\" + addonItem.Text + ".SFMM";
                        }
                        else {
                            FileSelect = addonItem.Text + ".SFMM";
                        }

                        

                        var SFMMFILE = f + FileSelect;

                        var lines = new List<string>();
                        using (var r = new StreamReader(SFMMFILE)) {
                            // 3
                            // Use while != null pattern for loop
                            string line;
                            while ((line = r.ReadLine()) != null) {
                                lines.Add(line);
                            }
                        }

                        // 5
                        // Print out all the lines.
                        foreach (var s in lines) {
                            if (File.Exists(SFMPATH + @"\" + s)) {
                                if (s.EndsWith("y")) {
                                    var ConfirmDeleteRig = MessageBox.Show("Delete Rig " + Path.GetFileName(s) + "?",
                                        "WARNING", MessageBoxButtons.YesNo);
                                    if (ConfirmDeleteRig == DialogResult.Yes) {
                                        File.Delete(SFMPATH + @"\" + s);
                                    }
                                } else {
                                    Console.WriteLine("Removing " + s);
                                    File.Delete(SFMPATH + @"\" + s);
                                }
                            } else {
                                Console.WriteLine("COULDNT FIND " + s + " YOU MUST HAVE MOVED THE FILE.");
                            }
                        }
                        File.Delete(@"SFM\SFMM\"+ addonItem.Text + @"\" + addonItem.Text + ".SFMM");
                        Directory.Delete(@"SFM\SFMM\" + addonItem.Text);
                        processDirectory(SFMPATH + @"\models");
                        processDirectory(SFMPATH + @"\materials");
                        listView1.Items.Clear();
                        AddonList();
                        ListToString();
                        AddingStart = false;
                        AddingEnd = true;
                    }
                }
            }
        }

        private static void processDirectory(string startLocation) {
            foreach (var directory in Directory.GetDirectories(startLocation)) {
                processDirectory(directory);
                if (Directory.GetFiles(directory).Length == 0 &&
                    Directory.GetDirectories(directory).Length == 0) {
                    Directory.Delete(directory, false);
                }
            }
        }

        public void AddonList() {
            var targetDirectory = @"SFM\SFMM\";

            // Process the list of files found in the directory.
            var fileEntries =
                Directory.GetFiles(targetDirectory, "*.SFMM", SearchOption.AllDirectories)
                    .Select(Path.GetFileNameWithoutExtension)
                    .Select(p => p.Substring(0))
                    .ToArray();

          //  List<AddToList> masterList = new List<AddToList>();
            foreach (var fileName in fileEntries) {

                //masterList.Add(new AddToList("Potato"));

                // var listItem = new ListViewItem(fileName);
                if(File.Exists(targetDirectory + fileName + @"\" + "info.ini")) { 
                var infoIni = new IniFile(targetDirectory + fileName + @"\" + "info.ini");
                var Date = infoIni.Read("Date");
                var Source = infoIni.Read("Source");
                var Author = infoIni.Read("Author");
                var URL = infoIni.Read("URL");

                // listItem.SubItems.Add(fileName.ToString());
               // listItem.SubItems.Add(info.CreationTime.ToString());
                //listView1.Items.Add(listItem);*/
                AddToList newObject = new AddToList(fileName.ToString(), "Model", Date, Source, Author, URL);
                addonListView.AddObject(newObject);
                }
                else {
                    var info = new FileInfo(targetDirectory + fileName + @".SFMM");
                    AddToList newObject = new AddToList(fileName.ToString(), "Model", info.CreationTime.ToString(), "?", "?", "?");
                    addonListView.AddObject(newObject);
                }
            }
            
            //addonListView.SetObjects(AddToList.GET());

        }

        private void loading() {
            Application.Run(new loading_bar());
        }

        //Form Drag_Start
        private void Form_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // Okay
            else
                e.Effect = DragDropEffects.None; // Unknown data, ignore it
        }

        private void Form_DragDrop(object sender, DragEventArgs u) {
            // Extract the data from the DataObject-Container into a string list
            //var FileList = (string[]) u.Data.GetData(DataFormats.FileDrop, false);
            //  modMan.Extract(FileList[0]);
        } //FormDragEnd

        //ListDragStart
        private void listView1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // Okay
            else
                e.Effect = DragDropEffects.None; // Unknown data, ignore it
        }

        private void listView1_DragDrop(object sender, DragEventArgs u) {
            var FileList = (string[])u.Data.GetData(DataFormats.FileDrop, false);
            foreach (string FileAddon in FileList) {
                modMan.Extract(FileAddon);
            }
        }

        //ListDragEnd

        private void Form1_Load(object sender, EventArgs e) {
            Console.WriteLine("=============================");
            Console.WriteLine("==========LOG START==========");
            Console.WriteLine("=============================");
            Console.WriteLine("");
            Console.WriteLine(@"Crashed?, Open an issue to https://github.com/Merubokkusu/SFMManager/issues");
            Console.WriteLine("");
        }

        private void button3_Click(object sender, EventArgs u) {
            var myDialog = new OpenFileDialog();
            myDialog.Filter = "Compressed Files(*.ZIP;*.RAR;*.7ZIP;*.7Z)|*.ZIP;*.RAR;*.7ZIP;*.7Z|All files (*.*)|*.*";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            //  myDialog.ShowDialog();

            if (myDialog.ShowDialog() == DialogResult.OK) {
                foreach (string AddonFile in myDialog.FileNames) {
                    modMan.Extract(AddonFile);
                }
            }
        }

        //End

        public void IgnoreExceptions(Action act) {
            try {
                act.Invoke();
            }
            catch {
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            var BinPath = Directory.GetParent(SFMPATH) + @"\bin";
            using (var ToolsForm = new Tools()) {
                ToolsForm.StartPosition = FormStartPosition.CenterParent;
                ToolsForm.ShowDialog(this);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e) {
            using (var f2 = new Settings()) {
                f2.StartPosition = FormStartPosition.CenterParent;
                f2.ShowDialog(this);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            addonListView.ModelFilter = TextMatchFilter.Contains(addonListView, textBox1.Text);

            /*
            var ci = new CultureInfo("en-US");
            if (string.IsNullOrEmpty(textBox1.Text.Trim()) == false) {
                addonListView.Items.Clear();
                foreach (var str in list) {
                    if (str.StartsWith(textBox1.Text, true, ci)) {
                        addonListView.Items.Add(str);
                    }
                }
            } else if (textBox1.Text.Trim() == "") {
                addonListView.Items.Clear();

                AddonList();
                addonListView.Sort();
            }*/
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (RefreshAddon) {
                //listView1.Items.Clear();
                addonListView.Items.Clear();
                AddonList();
                ListToString();
                RefreshAddon = false;
            }
            if (Download_Start) {
                notifyIcon1.BalloonTipText = "Download Started";
                notifyIcon1.ShowBalloonTip(2000);
                Download_Start = false;
            }
            if (Download_End) {
                notifyIcon1.BalloonTipText = "Download Finished";
                notifyIcon1.ShowBalloonTip(2000);
                Download_End = false;
            }
            if (AddingStart) {
                spinningCircles1.Visible = true;
            }
            if (AddingEnd) {
                spinningCircles1.Visible = false;
            }
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e) {
            //cancel the current event
            e.Cancel = true;

            //this opens the URL in the user's default browser
            Process.Start(e.Url.ToString());
        }

    } //Form End
}