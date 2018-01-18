using System;

namespace SourceFilmMakerManager {

    public partial class loading_bar : System.Windows.Forms.Form {

        public loading_bar() {
            InitializeComponent();
            progressBar1.Maximum = Convert.ToInt32(WindowsFormsApplication1.Form1.totalVal);
            progressBar1.Value = 0;
        }

        private void progressBar1_Click(object sender, EventArgs e) {
        }

        private void timer1_Tick(object sender, EventArgs e) {
            progressBar1.Maximum = Convert.ToInt32(WindowsFormsApplication1.Form1.totalVal);

            progressBar1.Value = unchecked((int)WindowsFormsApplication1.Form1.completed);
            label1.Text = progressBar1.Value.ToString() + "/" + progressBar1.Maximum.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e) {
            if (progressBar1.Value == progressBar1.Maximum) {
                this.Close();
                WindowsFormsApplication1.Form1.totalVal = 0;
                WindowsFormsApplication1.Form1.completed = 0;
            }
        }
    }
}