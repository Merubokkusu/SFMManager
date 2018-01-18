using System;
using System.IO;
//using System.IO.Compression.FileSystem;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using SourceFilmMakerManager;
using System.Threading;
using Microsoft.VisualBasic;
using SharpCompress.Common;
using SharpCompress.Archive;
using Microsoft.Win32;
using System.Net;
using SourceFilmMakerManager.Manager;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int TogMove;
        int MValX;
        int MValY;
        public static float CurrentVer = 4.5f;
       string SFMPATH = ConfigurationManager.AppSettings["SFM_PATH"];
        ContextMenu cm;
        public static bool SplashOver = false;
        List<string> list = new List<string>();

        public static long completed = 0;
        public static double totalVal = 1;

        public static string SFMLabName;
        public static string SFMLabURL;

        public static string[] FileList;

        public Form1()
        {
            Thread t = new Thread(new ThreadStart(Splashs));
            t.Start();
            Thread.Sleep(3000);
           if(SplashOver == true) {

                InitializeComponent();
            }
            // Enable drag and drop for this form
            // (this can also be applied to any controls)
            this.AllowDrop = true;

            // Add event handlers for the drag & drop functionality
            this.DragEnter += new DragEventHandler(Form_DragEnter);
            this.DragDrop += new DragEventHandler(Form_DragDrop);


            //Menu Start
            cm = new ContextMenu();
            MenuItem CM_Rename = new MenuItem("Rename");
            MenuItem CM_Delete = new MenuItem("Delete");
            CM_Rename.Click += OnRenameClicked;
            CM_Delete.Click += button1_Click;

            Menu.MenuItemCollection collection = new Menu.MenuItemCollection(cm);
            collection.Add(CM_Rename);
            collection.Add(CM_Delete);
            //Menus




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

            modMan.FindFileLoc();

        }
        public static void SFMLABDownloader() {

            
            //MessageBox.Show(SFMLabURL.Remove(0, 5));
            Console.WriteLine("Trying to download file from "+SFMLabURL.Remove(0, 5));

            using (var client = new WebClient()) {
                client.DownloadFile(SFMLabURL.Remove(0, 5), "a.mpeg");
            }

        }
        void SFMLABVersion() {

        }

        
           
            
        

        public void Splashs() {
            Application.Run(new Splash_scn());
        }

        private void ListToString()
        {
            list.Clear();
            foreach (ListViewItem str in listView1.Items)
            {
             list.Add(str.Text);
                
            }
        }
        private ColumnHeader SortingColumn = null;

        // Sort on this column.

        private void listView1_ColumnClick_1(object sender, ColumnClickEventArgs e) {
            ItemComparer sorter = listView1.ListViewItemSorter as ItemComparer;
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
            }
            else {
                // Set the column number that is to be sorted; default to ascending.
                sorter.Column = e.Column;
                sorter.Order = SortOrder.Ascending;
            }
            listView1.Sort();
        }
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = listView1.GetItemAt(e.Location.X, e.Location.Y);
                if (item != null) {

                   // listView1.SelectedIndices[0] = item.Index;
                    cm.Show(listView1, e.Location);
                }
            }
        }
        public void OnRenameClicked(object sender, EventArgs e)
        {

            const string f = @"SFM\PuCE\";
            string FileSelect = listView1.SelectedItems[0].Text + ".PuCE";
            string PUCEFILE = f + FileSelect;
            string a;
            a = Interaction.InputBox("Type what you would like to name this file.", "Rename", listView1.SelectedItems[0].Text);

            string specialCharacters = @"/:*?<>|" + "\"";
            char[] specialCharactersArray = specialCharacters.ToCharArray();
            int index = a.IndexOfAny(specialCharactersArray);

            if (index == -1)
            {
                if (a.Length > 0)
                {
                    if(!File.Exists (f + a + ".PuCE")){

                        
                    Console.WriteLine("Renamed " + listView1.SelectedItems[0].Text + " To " + a);
                    File.Move(PUCEFILE, f + a + ".PuCE");
                    listView1.Items.Clear();
                    AddonList();
                    ListToString();
                        // ok
                    }
                    else
                    {
                        Console.WriteLine("File Named " + a + " Already Exists, Couldnt Rename.");
                        MessageBox.Show("File Named " + a + " Already Exists, Couldnt Rename.");

                    }
                }
                else
                {
                    // cancel
                }
            }
            else
            {
                MessageBox.Show(@"A filename cannot contain any of the following characters: \ / : * ?  < > |" + " \"");


            }

        }
        public static void logTxt()
        {
            DateTime time = DateTime.Now;             // Use current time.
            string format = "M-d h-mm-ss";

            FileStream filestream = new FileStream(@"SFM\"+ time.ToString(format)+ "-Log.Log", FileMode.Create);
            var streamwriter = new StreamWriter(filestream);
            streamwriter.AutoFlush = true;
            Console.SetOut(streamwriter);
            Console.SetError(streamwriter);
        }
    
        public void CreateMyBorderlessWindow()
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            // Remove the control box so the form will only display client area.
            this.ControlBox = false;
            listView1.AllowDrop = true;
        }



       

        public void Colors(){
            string MainBG = ConfigurationManager.AppSettings["MainBG"];
            string TopBar = ConfigurationManager.AppSettings["TopBar"];
            string ButtonColor = ConfigurationManager.AppSettings["Button Color"];

            Color BGColor = System.Drawing.ColorTranslator.FromHtml(MainBG);
            Color TBColor = System.Drawing.ColorTranslator.FromHtml(TopBar);
            Color Button_Color = System.Drawing.ColorTranslator.FromHtml(ButtonColor);

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // find, open, read files
            }
            catch (FileNotFoundException) { }
            catch (NotSupportedException) { }

            if (listView1.Items.Count > 0)
            {


                //This Is The Delete Button.

                DialogResult result2 = MessageBox.Show("Delete This Addon?", "Are You Sure?", MessageBoxButtons.YesNo);
                if (result2 == DialogResult.Yes)
                {





                    const string f = @"SFM\PuCE\";

                    string FileSelect = listView1.SelectedItems[0].Text + ".PuCE";

                    string PUCEFILE = f + FileSelect;

                    List<string> lines = new List<string>();
                    using (StreamReader r = new StreamReader(PUCEFILE))
                    {
                        // 3
                        // Use while != null pattern for loop
                        string line;
                        while ((line = r.ReadLine()) != null)
                        {
                            lines.Add(line);
                        }
                    }

                    // 5
                    // Print out all the lines.
                    foreach (string s in lines)
                    {

                            if (File.Exists(SFMPATH + @"\" + s))
                            {
                            if (s.EndsWith("y"))
                            {
                                DialogResult ConfirmDeleteRig = MessageBox.Show("Delete Rig " + Path.GetFileName(s) + "?", "WARNING", MessageBoxButtons.YesNo);
                                if (ConfirmDeleteRig == DialogResult.Yes)
                                {
                                    File.Delete(SFMPATH + @"\" + s);

                                }
                            }
                            else {
                                Console.WriteLine("Removing " + s);
                                File.Delete(SFMPATH + @"\" + s);
                            }
                            }
                            else
                            {
                                Console.WriteLine("COULDNT FIND " + s + " YOU MUST HAVE MOVED THE FILE.");
                            }
                        }
                        File.Delete(@"SFM\PuCE\" + listView1.SelectedItems[0].Text + ".PuCE");
                        processDirectory(SFMPATH + @"\models");
                        processDirectory(SFMPATH + @"\materials");
                        listView1.Items.Clear();
                        AddonList();
                    ListToString();
                }
                }
            }
        
       

        private static void processDirectory(string startLocation)
        {
            foreach (var directory in Directory.GetDirectories(startLocation))
            {
                processDirectory(directory);
                if (Directory.GetFiles(directory).Length == 0 &&
                    Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                }
            }
        }




        void AddonList()
        {
            string targetDirectory = @"SFM\PuCE\";

            // Process the list of files found in the directory. 
            string[] fileEntries = Directory.GetFiles(targetDirectory, "*.PuCE").Select(Path.GetFileNameWithoutExtension).Select(p => p.Substring(0)).ToArray();

            foreach (string fileName in fileEntries)
            {
                ListViewItem listItem = new ListViewItem(fileName);
                FileInfo info = new FileInfo(targetDirectory + fileName + @".PuCE");

               // listItem.SubItems.Add(fileName.ToString());
                listItem.SubItems.Add(info.CreationTime.ToString());
                listView1.Items.Add(listItem);

            }

            
        }
        

        void loading() {
            Application.Run(new loading_bar());
        }
        //Form Drag_Start
        void Form_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // Okay
            else
                e.Effect = DragDropEffects.None; // Unknown data, ignore it

        }
        void Form_DragDrop(object sender, DragEventArgs u)
        {
            // Extract the data from the DataObject-Container into a string list
            string[] FileList = (string[])u.Data.GetData(DataFormats.FileDrop, false);


            string SFMPATH = ConfigurationManager.AppSettings["SFM_PATH"];
            foreach (string AddonFile in FileList)
                    if (File.Exists(AddonFile)) {
                    SFMLabName = Path.GetFileNameWithoutExtension(AddonFile);
                    SFMLABVersion();
                        // Will always overwrite if target filenames already exist

                        var archive = ArchiveFactory.Open(AddonFile);
                    double totalSize = archive.Entries.Where(e => !e.IsDirectory).Sum(e => e.Size);

                    Thread t = new Thread(new ThreadStart(loading));
                    t.Start();


                    FileStream fs1 = new FileStream(@"SFM\PuCE\" + Path.GetFileNameWithoutExtension(AddonFile) + ".PuCE", FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(fs1);


                        foreach (var entry in archive.Entries) {
                            if (!entry.IsDirectory) {
                                Console.WriteLine(entry.FilePath);
                                entry.WriteToDirectory(SFMPATH, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);

                                completed += entry.Size;
                                totalVal = totalSize;
                                var percentage = completed / totalSize;

                            //Console.WriteLine(Path.GetFileName(entry.FilePath));
                            //Console.WriteLine(totalSize.ToString());
                            


                            if (entry.FilePath.EndsWith(@"l")) {
                                    writer.Write(entry.FilePath + "\n");
                                }
                                if (entry.FilePath.EndsWith(@"t")) {
                                    writer.Write(entry.FilePath + "\n");
                                }
                                if (entry.FilePath.EndsWith(@"f")) {
                                    writer.Write(entry.FilePath + "\n");
                                }
                                if (entry.FilePath.EndsWith(@"d")) {
                                    writer.Write(entry.FilePath + "\n");
                                }
                                if (entry.FilePath.EndsWith(@"x")) {
                                    writer.Write(entry.FilePath + "\n");
                                }
                                if (entry.FilePath.EndsWith(@"y")) {

                                    if (File.Exists(SFMPATH + @"\" + Path.GetFileName(entry.FilePath))) {
                                        Console.WriteLine(SFMPATH + @"\" + Path.GetFileName(entry.FilePath));
                                        writer.Write(@"scripts/sfm/animset/" + Path.GetFileName(entry.FilePath) + "\n");

                                        if (!File.Exists(SFMPATH + @"/scripts/sfm/animset/" + Path.GetFileName(entry.FilePath))) {
                                            File.Move(SFMPATH + @"\" + Path.GetFileName(entry.FilePath), SFMPATH + @"/scripts/sfm/animset/" + Path.GetFileName(entry.FilePath));
                                        }
                                        else {
                                            DialogResult result2 = MessageBox.Show("File " + Path.GetFileName(entry.FilePath) + " Exists, overwrite this file?", "WARNING", MessageBoxButtons.YesNo);
                                            if (result2 == DialogResult.Yes) {
                                                File.Delete(SFMPATH + @"\scripts\sfm\animset\" + Path.GetFileName(entry.FilePath));
                                                File.Move(SFMPATH + @"\" + Path.GetFileName(entry.FilePath), SFMPATH + @"/scripts/sfm/animset/" + Path.GetFileName(entry.FilePath));
                                            }
                                        }

                                    }//End First If
                                    else {
                                        writer.Write(entry.FilePath + "\n");
                                    }



                                }//END
                                if (entry.FilePath.EndsWith("p")) {

                                    if (File.Exists(SFMPATH + @"\" + Path.GetFileName(entry.FilePath))) {
                                        writer.Write(@"maps/" + Path.GetFileName(entry.FilePath) + "\n");

                                        if (!File.Exists(SFMPATH + @"\maps\" + Path.GetFileName(entry.FilePath))) {
                                            File.Move(SFMPATH + @"\" + Path.GetFileName(entry.FilePath), SFMPATH + @"\maps\" + Path.GetFileName(entry.FilePath));
                                        }
                                        else {
                                            Console.WriteLine("Map" + Path.GetFileName(entry.FilePath) + "Exists, Writing it to file to be able to delete though");
                                        }
                                    }
                                    else {
                                        writer.Write(entry.FilePath + "\n");
                                    }
                                }//Map End

                            }

                        }
                        writer.Close();

                        listView1.Items.Clear();
                        AddonList();
                        ListToString();

                    }
       
             }//FormDragEnd

        //ListDragStart
        private void listView1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // Okay
            else
                e.Effect = DragDropEffects.None; // Unknown data, ignore it
        }
        private void listView1_DragDrop(object sender, DragEventArgs u) {
            // Extract the data from the DataObject-Container into a string list
            string[] FileList = (string[])u.Data.GetData(DataFormats.FileDrop, false);


            string SFMPATH = ConfigurationManager.AppSettings["SFM_PATH"];
            foreach (string AddonFile in FileList)
                if (File.Exists(AddonFile)) {
                    SFMLabName = Path.GetFileNameWithoutExtension(AddonFile);
                    SFMLABVersion();
                    // Will always overwrite if target filenames already exist

                    var archive = ArchiveFactory.Open(AddonFile);
                    double totalSize = archive.Entries.Where(e => !e.IsDirectory).Sum(e => e.Size);

                    Thread t = new Thread(new ThreadStart(loading));
                    t.Start();


                    FileStream fs1 = new FileStream(@"SFM\PuCE\" + Path.GetFileNameWithoutExtension(AddonFile) + ".PuCE", FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs1);


                    foreach (var entry in archive.Entries) {
                        if (!entry.IsDirectory) {
                            Console.WriteLine(entry.FilePath);
                            entry.WriteToDirectory(SFMPATH, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);

                            completed += entry.Size;
                            totalVal = totalSize;
                            var percentage = completed / totalSize;

                            //Console.WriteLine(Path.GetFileName(entry.FilePath));
                            //Console.WriteLine(totalSize.ToString());



                            if (entry.FilePath.EndsWith(@"l")) {
                                writer.Write(entry.FilePath + "\n");
                            }
                            if (entry.FilePath.EndsWith(@"t")) {
                                writer.Write(entry.FilePath + "\n");
                            }
                            if (entry.FilePath.EndsWith(@"f")) {
                                writer.Write(entry.FilePath + "\n");
                            }
                            if (entry.FilePath.EndsWith(@"d")) {
                                writer.Write(entry.FilePath + "\n");
                            }
                            if (entry.FilePath.EndsWith(@"x")) {
                                writer.Write(entry.FilePath + "\n");
                            }
                            if (entry.FilePath.EndsWith(@"y")) {

                                if (File.Exists(SFMPATH + @"\" + Path.GetFileName(entry.FilePath))) {
                                    Console.WriteLine(SFMPATH + @"\" + Path.GetFileName(entry.FilePath));
                                    writer.Write(@"scripts/sfm/animset/" + Path.GetFileName(entry.FilePath) + "\n");

                                    if (!File.Exists(SFMPATH + @"/scripts/sfm/animset/" + Path.GetFileName(entry.FilePath))) {
                                        File.Move(SFMPATH + @"\" + Path.GetFileName(entry.FilePath), SFMPATH + @"/scripts/sfm/animset/" + Path.GetFileName(entry.FilePath));
                                    }
                                    else {
                                        DialogResult result2 = MessageBox.Show("File " + Path.GetFileName(entry.FilePath) + " Exists, overwrite this file?", "WARNING", MessageBoxButtons.YesNo);
                                        if (result2 == DialogResult.Yes) {
                                            File.Delete(SFMPATH + @"\scripts\sfm\animset\" + Path.GetFileName(entry.FilePath));
                                            File.Move(SFMPATH + @"\" + Path.GetFileName(entry.FilePath), SFMPATH + @"/scripts/sfm/animset/" + Path.GetFileName(entry.FilePath));
                                        }
                                    }

                                }//End First If
                                else {
                                    writer.Write(entry.FilePath + "\n");
                                }



                            }//END
                            if (entry.FilePath.EndsWith("p")) {

                                if (File.Exists(SFMPATH + @"\" + Path.GetFileName(entry.FilePath))) {
                                    writer.Write(@"maps/" + Path.GetFileName(entry.FilePath) + "\n");

                                    if (!File.Exists(SFMPATH + @"\maps\" + Path.GetFileName(entry.FilePath))) {
                                        File.Move(SFMPATH + @"\" + Path.GetFileName(entry.FilePath), SFMPATH + @"\maps\" + Path.GetFileName(entry.FilePath));
                                    }
                                    else {
                                        Console.WriteLine("Map" + Path.GetFileName(entry.FilePath) + "Exists, Writing it to file to be able to delete though");
                                    }
                                }
                                else {
                                    writer.Write(entry.FilePath + "\n");
                                }
                            }//Map End

                        }

                    }
                    writer.Close();

                    listView1.Items.Clear();
                    AddonList();
                    ListToString();

                }
        }

   


        //ListDragEnd

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("=============================");
            Console.WriteLine("==========LOG START==========");
            Console.WriteLine("=============================");


        }

        private void button3_Click(object sender, EventArgs u)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Compressed Files(*.ZIP;*.RAR;*.7ZIP)|*.ZIP;*.RAR;*.7ZIP|All files (*.*)|*.*";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = false;
            //  myDialog.ShowDialog();

            if (myDialog.ShowDialog() == DialogResult.OK) {
                string AddonFile = myDialog.FileName;

                if (File.Exists(AddonFile)) {

                    // Will always overwrite if target filenames already exist

                    var archive = ArchiveFactory.Open(AddonFile);

                    double totalSize = archive.Entries.Where(e => !e.IsDirectory).Sum(e => e.Size);

                    Thread t = new Thread(new ThreadStart(loading));
                    t.Start();


                    FileStream fs1 = new FileStream(@"SFM\PuCE\" + Path.GetFileNameWithoutExtension(AddonFile) + ".PuCE", FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs1);


                    foreach (var entry in archive.Entries) {
                        if (!entry.IsDirectory) {
                            Console.WriteLine(entry.FilePath);
                            entry.WriteToDirectory(SFMPATH, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);

                            completed += entry.Size;
                            totalVal = totalSize;
                            var percentage = completed / totalSize;

                            if (entry.FilePath.EndsWith(@"l")) {
                                writer.Write(entry.FilePath + "\n");
                            }
                            if (entry.FilePath.EndsWith(@"t")) {
                                writer.Write(entry.FilePath + "\n");
                            }
                            if (entry.FilePath.EndsWith(@"f")) {
                                writer.Write(entry.FilePath + "\n");
                            }
                            if (entry.FilePath.EndsWith(@"d")) {
                                writer.Write(entry.FilePath + "\n");
                            }
                            if (entry.FilePath.EndsWith(@"x")) {
                                writer.Write(entry.FilePath + "\n");
                            }
                            if (entry.FilePath.EndsWith(@"y")) {

                                if (File.Exists(SFMPATH + @"\" + Path.GetFileName(entry.FilePath))) {
                                    Console.WriteLine(SFMPATH + @"\" + Path.GetFileName(entry.FilePath));
                                    writer.Write(@"scripts/sfm/animset/" + Path.GetFileName(entry.FilePath) + "\n");

                                    if (!File.Exists(SFMPATH + @"/scripts/sfm/animset/" + Path.GetFileName(entry.FilePath))) {
                                        File.Move(SFMPATH + @"\" + Path.GetFileName(entry.FilePath), SFMPATH + @"/scripts/sfm/animset/" + Path.GetFileName(entry.FilePath));
                                    }
                                    else {
                                        DialogResult result2 = MessageBox.Show("File " + Path.GetFileName(entry.FilePath) + " Exists, overwrite this file?", "WARNING", MessageBoxButtons.YesNo);
                                        if (result2 == DialogResult.Yes) {
                                            File.Delete(SFMPATH + @"\scripts\sfm\animset\" + Path.GetFileName(entry.FilePath));
                                            File.Move(SFMPATH + @"\" + Path.GetFileName(entry.FilePath), SFMPATH + @"/scripts/sfm/animset/" + Path.GetFileName(entry.FilePath));
                                        }
                                    }
                                }//End First If
                                else {
                                    writer.Write(entry.FilePath + "\n");
                                }


                            }//END
                            if (entry.FilePath.EndsWith("p")) {

                                if (File.Exists(SFMPATH + @"\" + Path.GetFileName(entry.FilePath))) {
                                    writer.Write(@"maps/" + Path.GetFileName(entry.FilePath) + "\n");

                                    if (!File.Exists(SFMPATH + @"\maps\" + Path.GetFileName(entry.FilePath))) {
                                        File.Move(SFMPATH + @"\" + Path.GetFileName(entry.FilePath), SFMPATH + @"\maps\" + Path.GetFileName(entry.FilePath));
                                    }
                                    else {
                                        Console.WriteLine("Map" + Path.GetFileName(entry.FilePath) + "Exists, Writing it to file to be able to delete though");
                                    }
                                }
                                else {
                                    writer.Write(entry.FilePath + "\n");
                                }
                            }//Map End

                        }

                    }
                    writer.Close();

                    listView1.Items.Clear();
                    AddonList();
                    ListToString();

                }
            }
        }
        //End


        public void IgnoreExceptions(Action act)
        {
            try
            {
                act.Invoke();
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var BinPath = Directory.GetParent(SFMPATH) + @"\bin";
            using (Tools ToolsForm = new Tools())
            {
                ToolsForm.StartPosition = FormStartPosition.CenterParent;
                ToolsForm.ShowDialog(this);
            }

        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            using (Settings f2 = new Settings())
            {
                f2.StartPosition = FormStartPosition.CenterParent;
                f2.ShowDialog(this);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var ci = new System.Globalization.CultureInfo("en-US");
            if (String.IsNullOrEmpty(textBox1.Text.Trim()) == false)
            {
                listView1.Items.Clear();
                foreach (string str in list)
                {
                    if (str.StartsWith(textBox1.Text,true,ci))
                    {
                        listView1.Items.Add(str);
                    }
                }

            }
            else if (textBox1.Text.Trim() == "")
            {
                listView1.Items.Clear();

                foreach (string str in list)
                {
                    listView1.Items.Add(str);
                }
            }

        }









        //Form Controls
        protected override void WndProc(ref Message m) {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg) {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/) {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE) {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE)) {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }

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

        private void pictureBox3_MouseHover(object sender, EventArgs e) {
            pictureBox3.BackColor = Color.Red;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e) {
            string TopBar = ConfigurationManager.AppSettings["TopBar"];
            Color TBColor = System.Drawing.ColorTranslator.FromHtml(TopBar);
            pictureBox3.BackColor = TBColor;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e) {
            pictureBox2.BackColor = Color.FromArgb(50, 50, 50, 50);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e) {
            string TopBar = ConfigurationManager.AppSettings["TopBar"];
            Color TBColor = System.Drawing.ColorTranslator.FromHtml(TopBar);
            pictureBox2.BackColor = TBColor;
        }

        private void pictureBox3_Click(object sender, EventArgs e) {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

    }//Form End
}
