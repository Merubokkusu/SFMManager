namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.addonContainer = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.searchBarBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.addAddonButton = new System.Windows.Forms.ToolStripSplitButton();
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFromURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteButton = new System.Windows.Forms.ToolStripButton();
            this.categoryButton = new System.Windows.Forms.ToolStripButton();
            this.toolButton = new System.Windows.Forms.ToolStripSplitButton();
            this.sFMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hLMVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hammerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.spinningCircles1 = new SourceFilmMakerManager.control.SpinningCircles();
            this.addonListView = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.addonContainer)).BeginInit();
            this.addonContainer.Panel1.SuspendLayout();
            this.addonContainer.Panel2.SuspendLayout();
            this.addonContainer.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addonListView)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(96, 100);
            this.webBrowser1.TabIndex = 15;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipTitle = "SFMM";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SFMM";
            this.notifyIcon1.Visible = true;
            // 
            // addonContainer
            // 
            this.addonContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addonContainer.BackColor = System.Drawing.Color.White;
            this.addonContainer.Location = new System.Drawing.Point(49, 43);
            this.addonContainer.Name = "addonContainer";
            // 
            // addonContainer.Panel1
            // 
            this.addonContainer.Panel1.Controls.Add(this.addonListView);
            // 
            // addonContainer.Panel2
            // 
            this.addonContainer.Panel2.Controls.Add(this.webBrowser1);
            this.addonContainer.Panel2Collapsed = true;
            this.addonContainer.Size = new System.Drawing.Size(1119, 462);
            this.addonContainer.SplitterDistance = 923;
            this.addonContainer.TabIndex = 19;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(34, 34);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolButton,
            this.settingsButton,
            this.toolStripButton1,
            this.searchBarBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1168, 41);
            this.toolStrip1.TabIndex = 20;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // searchBarBox
            // 
            this.searchBarBox.Name = "searchBarBox";
            this.searchBarBox.Size = new System.Drawing.Size(100, 41);
            this.searchBarBox.TextChanged += new System.EventHandler(this.searchBarBox_TextChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(34, 34);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAddonButton,
            this.DeleteButton,
            this.categoryButton});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(0, 41);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip2.Size = new System.Drawing.Size(46, 468);
            this.toolStrip2.TabIndex = 21;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // addAddonButton
            // 
            this.addAddonButton.AutoSize = false;
            this.addAddonButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addAddonButton.DropDownButtonWidth = 8;
            this.addAddonButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFileToolStripMenuItem,
            this.addFromURLToolStripMenuItem});
            this.addAddonButton.Image = global::SourceFilmMakerManager.Properties.Resources.plus;
            this.addAddonButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.addAddonButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addAddonButton.Name = "addAddonButton";
            this.addAddonButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.addAddonButton.Size = new System.Drawing.Size(45, 38);
            this.addAddonButton.Text = "toolStripDropDownButton1";
            this.addAddonButton.ToolTipText = "Add addon from file";
            this.addAddonButton.ButtonClick += new System.EventHandler(this.addAddonButton_ButtonClick);
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Image = global::SourceFilmMakerManager.Properties.Resources.plus;
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(170, 40);
            this.addFileToolStripMenuItem.Text = "Add From File";
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.addFileToolStripMenuItem_Click);
            // 
            // addFromURLToolStripMenuItem
            // 
            this.addFromURLToolStripMenuItem.Image = global::SourceFilmMakerManager.Properties.Resources.plus;
            this.addFromURLToolStripMenuItem.Name = "addFromURLToolStripMenuItem";
            this.addFromURLToolStripMenuItem.Size = new System.Drawing.Size(170, 40);
            this.addFromURLToolStripMenuItem.Text = "Add From URL";
            this.addFromURLToolStripMenuItem.ToolTipText = "Download a file from SFMLab";
            this.addFromURLToolStripMenuItem.Click += new System.EventHandler(this.addFromURLToolStripMenuItem_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Image = global::SourceFilmMakerManager.Properties.Resources.cancel;
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(43, 38);
            this.DeleteButton.Text = "toolStripButton2";
            this.DeleteButton.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.DeleteButton.ToolTipText = "Delete addon";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // categoryButton
            // 
            this.categoryButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.categoryButton.Enabled = false;
            this.categoryButton.Image = global::SourceFilmMakerManager.Properties.Resources.tag;
            this.categoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.categoryButton.Name = "categoryButton";
            this.categoryButton.Size = new System.Drawing.Size(43, 38);
            this.categoryButton.Text = "categoryButton";
            this.categoryButton.ToolTipText = "Category";
            this.categoryButton.Click += new System.EventHandler(this.categoryButton_Click);
            // 
            // toolButton
            // 
            this.toolButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sFMToolStripMenuItem,
            this.hLMVToolStripMenuItem,
            this.hammerToolStripMenuItem});
            this.toolButton.Image = global::SourceFilmMakerManager.Properties.Resources.diskette;
            this.toolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButton.Name = "toolButton";
            this.toolButton.Size = new System.Drawing.Size(122, 38);
            this.toolButton.Text = "Launch SFM";
            this.toolButton.ToolTipText = "Quick Launch";
            this.toolButton.ButtonClick += new System.EventHandler(this.toolButton_ButtonClick);
            // 
            // sFMToolStripMenuItem
            // 
            this.sFMToolStripMenuItem.Image = global::SourceFilmMakerManager.Properties.Resources.diskette;
            this.sFMToolStripMenuItem.Name = "sFMToolStripMenuItem";
            this.sFMToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.sFMToolStripMenuItem.Text = "SFM";
            this.sFMToolStripMenuItem.Click += new System.EventHandler(this.sFMToolStripMenuItem_Click);
            // 
            // hLMVToolStripMenuItem
            // 
            this.hLMVToolStripMenuItem.Image = global::SourceFilmMakerManager.Properties.Resources.worldwide;
            this.hLMVToolStripMenuItem.Name = "hLMVToolStripMenuItem";
            this.hLMVToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.hLMVToolStripMenuItem.Text = "HLMV";
            this.hLMVToolStripMenuItem.Click += new System.EventHandler(this.hLMVToolStripMenuItem_Click);
            // 
            // hammerToolStripMenuItem
            // 
            this.hammerToolStripMenuItem.Image = global::SourceFilmMakerManager.Properties.Resources.star;
            this.hammerToolStripMenuItem.Name = "hammerToolStripMenuItem";
            this.hammerToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.hammerToolStripMenuItem.Text = "Hammer";
            this.hammerToolStripMenuItem.Click += new System.EventHandler(this.hammerToolStripMenuItem_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingsButton.Image = global::SourceFilmMakerManager.Properties.Resources.settings;
            this.settingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(38, 38);
            this.settingsButton.ToolTipText = "Settings";
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::SourceFilmMakerManager.Properties.Resources.help;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(38, 38);
            this.toolStripButton1.Text = "helpButton";
            this.toolStripButton1.ToolTipText = "Help";
            this.toolStripButton1.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // spinningCircles1
            // 
            this.spinningCircles1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spinningCircles1.BackColor = System.Drawing.Color.Transparent;
            this.spinningCircles1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.spinningCircles1.Location = new System.Drawing.Point(3, 470);
            this.spinningCircles1.Name = "spinningCircles1";
            this.spinningCircles1.Size = new System.Drawing.Size(43, 39);
            this.spinningCircles1.TabIndex = 17;
            this.spinningCircles1.Text = "spinningCircles1";
            // 
            // addonListView
            // 
            this.addonListView.AllColumns.Add(this.olvColumn1);
            this.addonListView.AllColumns.Add(this.olvColumn2);
            this.addonListView.AllColumns.Add(this.olvColumn3);
            this.addonListView.AllColumns.Add(this.olvColumn4);
            this.addonListView.AllColumns.Add(this.olvColumn5);
            this.addonListView.AllColumns.Add(this.olvColumn6);
            this.addonListView.AllowDrop = true;
            this.addonListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addonListView.CellEditUseWholeCell = false;
            this.addonListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5,
            this.olvColumn6});
            this.addonListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.addonListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addonListView.FullRowSelect = true;
            this.addonListView.Location = new System.Drawing.Point(0, 0);
            this.addonListView.Name = "addonListView";
            this.addonListView.ShowGroups = false;
            this.addonListView.Size = new System.Drawing.Size(1119, 462);
            this.addonListView.TabIndex = 18;
            this.addonListView.UseCompatibleStateImageBehavior = false;
            this.addonListView.UseFiltering = true;
            this.addonListView.UseHyperlinks = true;
            this.addonListView.View = System.Windows.Forms.View.Details;
            this.addonListView.SelectedIndexChanged += new System.EventHandler(this.addonListView_SelectedIndexChanged);
            this.addonListView.Click += new System.EventHandler(this.addonListView_Click);
            this.addonListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.addonListView_DragDrop);
            this.addonListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.addonListView_DragEnter);
            this.addonListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.addonListView_MouseDown);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.Text = "Name";
            this.olvColumn1.Width = 129;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Category";
            this.olvColumn2.Text = "Category";
            this.olvColumn2.Width = 106;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Date";
            this.olvColumn3.Text = "Install Date";
            this.olvColumn3.Width = 122;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Source";
            this.olvColumn4.Text = "Source";
            this.olvColumn4.Width = 84;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "Author ";
            this.olvColumn5.Text = "Author ";
            this.olvColumn5.Width = 95;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "URL";
            this.olvColumn6.Hyperlink = true;
            this.olvColumn6.Text = "URL";
            this.olvColumn6.Width = 145;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1168, 509);
            this.Controls.Add(this.spinningCircles1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.addonContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MinimumSize = new System.Drawing.Size(687, 509);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.addonContainer.Panel1.ResumeLayout(false);
            this.addonContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addonContainer)).EndInit();
            this.addonContainer.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addonListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        public SourceFilmMakerManager.control.SpinningCircles spinningCircles1;
        private BrightIdeasSoftware.ObjectListView addonListView;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private System.Windows.Forms.SplitContainer addonContainer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox searchBarBox;
        private System.Windows.Forms.ToolStripButton settingsButton;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton DeleteButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton categoryButton;
        private System.Windows.Forms.ToolStripSplitButton addAddonButton;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFromURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolButton;
        private System.Windows.Forms.ToolStripMenuItem sFMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hLMVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hammerToolStripMenuItem;
    }
}

