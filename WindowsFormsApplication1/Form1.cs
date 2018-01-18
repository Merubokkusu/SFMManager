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
        public static float CurrentVer = 6.1f;
        public static string SFMPATH = ConfigurationManager.AppSettings["SFM_PATH"];
        public static string adWeb = ConfigurationManager.AppSettings["Show_Ad"];
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
        private int MValX;
        private int MValY;

        private int TogMove;

        public Form1() {
            var t = new Thread(Splashs);
            t.Start();
            Thread.Sleep(3000);

            InitializeComponent();

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

            //Ad
            if (adWeb == "0") {
                webBrowser1.Visible = false;
            } else {
                webBrowser1.Visible = true;
            }
            //Create The Log
            logTxt();

            //BorderLess.
            CreateMyBorderlessWindow();

            //Color For Form
            Colors();

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
            foreach (ListViewItem str in listView1.Items) {
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
            const string f = @"SFM\PuCE\";
            var FileSelect = listView1.SelectedItems[0].Text + ".PuCE";
            var PUCEFILE = f + FileSelect;
            string a;
            a = Interaction.InputBox("Type what you would like to name this file.", "Rename",
                listView1.SelectedItems[0].Text);

            var specialCharacters = @"/:*?<>|" + "\"";
            var specialCharactersArray = specialCharacters.ToCharArray();
            var index = a.IndexOfAny(specialCharactersArray);

            if (index == -1) {
                if (a.Length > 0) {
                    if (!File.Exists(f + a + ".PuCE")) {
                        Console.WriteLine("Renamed " + listView1.SelectedItems[0].Text + " To " + a);
                        File.Move(PUCEFILE, f + a + ".PuCE");
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

        public void CreateMyBorderlessWindow() {
            //this.FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            // Remove the control box so the form will only display client area.
            ControlBox = false;
            //listView1.AllowDrop = true;
        }

        public void Colors() {
            var MainBG = ConfigurationManager.AppSettings["MainBG"];
            var TopBar = ConfigurationManager.AppSettings["TopBar"];
            var ButtonColor = ConfigurationManager.AppSettings["Button Color"];

            var BGColor = ColorTranslator.FromHtml(MainBG);
            var TBColor = ColorTranslator.FromHtml(TopBar);
            var Button_Color = ColorTranslator.FromHtml(ButtonColor);

            pictureBox4.BackColor = BGColor;
            BackColor = BGColor;
            pictureBox1.BackColor = TBColor;
            pictureBox2.BackColor = TBColor;
            pictureBox3.BackColor = TBColor;
            label1.BackColor = TBColor;
            button1.BackColor = Button_Color;
            button3.BackColor = Button_Color;
            button4.BackColor = Button_Color;
            //button5.BackColor = Button_Color;
        }

        private void button1_Click(object sender, EventArgs e) {
            foreach (ListViewItem addonItem in listView1.SelectedItems) {
                if (listView1.Items.Count > 0) {
                    var result2 = MessageBox.Show("Delete Addon? " + addonItem.Text, "Are You Sure?", MessageBoxButtons.YesNo);
                    if (result2 == DialogResult.Yes) {
                        AddingStart = true;
                        AddingEnd = false;

                        const string f = @"SFM\PuCE\";

                        var FileSelect = addonItem.Text + ".PuCE";

                        var PUCEFILE = f + FileSelect;

                        var lines = new List<string>();
                        using (var r = new StreamReader(PUCEFILE)) {
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
                        File.Delete(@"SFM\PuCE\" + addonItem.Text + ".PuCE");
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
            var targetDirectory = @"SFM\PuCE\";

            // Process the list of files found in the directory.
            var fileEntries =
                Directory.GetFiles(targetDirectory, "*.PuCE")
                    .Select(Path.GetFileNameWithoutExtension)
                    .Select(p => p.Substring(0))
                    .ToArray();

            foreach (var fileName in fileEntries) {
                var listItem = new ListViewItem(fileName);
                var info = new FileInfo(targetDirectory + fileName + @".PuCE");

                // listItem.SubItems.Add(fileName.ToString());
                listItem.SubItems.Add(info.CreationTime.ToString());
                listView1.Items.Add(listItem);
            }
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
            Console.WriteLine(@"Crashed?, send this log file to basicgirlnsfw@gmail.com");
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
            var ci = new CultureInfo("en-US");
            if (string.IsNullOrEmpty(textBox1.Text.Trim()) == false) {
                listView1.Items.Clear();
                foreach (var str in list) {
                    if (str.StartsWith(textBox1.Text, true, ci)) {
                        listView1.Items.Add(str);
                    }
                }
            } else if (textBox1.Text.Trim() == "") {
                listView1.Items.Clear();

                AddonList();
                listView1.Sort();
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (RefreshAddon) {
                listView1.Items.Clear();
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

        //Form Controls
        protected override void WndProc(ref Message m) {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg) {
                case 0x0084 /*NCHITTEST*/:
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01 /*HTCLIENT*/) {
                        var screenPoint = new Point(m.LParam.ToInt32());
                        var clientPoint = PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE) {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13 /*HTTOPLEFT*/;
                            else if (clientPoint.X < Size.Width - RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)12 /*HTTOP*/;
                            else
                                m.Result = (IntPtr)14 /*HTTOPRIGHT*/;
                        } else if (clientPoint.Y <= Size.Height - RESIZE_HANDLE_SIZE) {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10 /*HTLEFT*/;
                            else if (clientPoint.X < Size.Width - RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)2 /*HTCAPTION*/;
                            else
                                m.Result = (IntPtr)11 /*HTRIGHT*/;
                        } else {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16 /*HTBOTTOMLEFT*/;
                            else if (clientPoint.X < Size.Width - RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)15 /*HTBOTTOM*/;
                            else
                                m.Result = (IntPtr)17 /*HTBOTTOMRIGHT*/;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
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
                SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e) {
            pictureBox3.BackColor = Color.Red;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e) {
            var TopBar = ConfigurationManager.AppSettings["TopBar"];
            var TBColor = ColorTranslator.FromHtml(TopBar);
            pictureBox3.BackColor = TBColor;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e) {
            pictureBox2.BackColor = Color.FromArgb(50, 50, 50, 50);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e) {
            var TopBar = ConfigurationManager.AppSettings["TopBar"];
            var TBColor = ColorTranslator.FromHtml(TopBar);
            pictureBox2.BackColor = TBColor;
        }

        private void pictureBox3_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e) {
            //cancel the current event
            e.Cancel = true;

            //this opens the URL in the user's default browser
            Process.Start(e.Url.ToString());
        }
    } //Form End
}