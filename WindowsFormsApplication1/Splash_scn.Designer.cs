namespace SourceFilmMakerManager
{
    partial class Splash_scn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash_scn));
            this.CheckFalse_time = new System.Windows.Forms.Timer(this.components);
            this.CheckTrue_time = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CheckFalse_time
            // 
            this.CheckFalse_time.Enabled = true;
            this.CheckFalse_time.Interval = 2999;
            this.CheckFalse_time.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CheckTrue_time
            // 
            this.CheckTrue_time.Enabled = true;
            this.CheckTrue_time.Interval = 1000;
            this.CheckTrue_time.Tick += new System.EventHandler(this.CheckTrue_time_Tick);
            // 
            // Splash_scn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(629, 326);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "Splash_scn";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.Splash_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer CheckFalse_time;
        private System.Windows.Forms.Timer CheckTrue_time;
    }
}