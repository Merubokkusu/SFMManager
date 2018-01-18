namespace Controlz
{
    partial class ColorWheelTR
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.blue1 = new System.Windows.Forms.NumericUpDown();
            this.green1 = new System.Windows.Forms.NumericUpDown();
            this.red1 = new System.Windows.Forms.NumericUpDown();
            this.hexBox = new System.Windows.Forms.TextBox();
            this.Hue1 = new System.Windows.Forms.NumericUpDown();
            this.Sat1 = new System.Windows.Forms.NumericUpDown();
            this.Val1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.blue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.green1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.red1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Val1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 105);
            this.panel2.TabIndex = 17;
            this.panel2.Tag = "0";
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GenColorWheel_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GenColorWheel_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GenColorWheel_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(204, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Alpha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(204, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Blue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(204, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Green";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Red";

            // 
            // blue1
            // 
            this.blue1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blue1.Location = new System.Drawing.Point(241, 70);
            this.blue1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blue1.Name = "blue1";
            this.blue1.Size = new System.Drawing.Size(49, 20);
            this.blue1.TabIndex = 27;
            this.blue1.Tag = "0";
            this.blue1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.blue1.ValueChanged += new System.EventHandler(this.ARGB_ValueChanged);
            this.blue1.Leave += new System.EventHandler(this.ARGB_Leave);
            this.blue1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ARGB_MouseUp);
            // 
            // green1
            // 
            this.green1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.green1.Location = new System.Drawing.Point(241, 48);
            this.green1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.green1.Name = "green1";
            this.green1.Size = new System.Drawing.Size(49, 20);
            this.green1.TabIndex = 26;
            this.green1.Tag = "0";
            this.green1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.green1.ValueChanged += new System.EventHandler(this.ARGB_ValueChanged);
            this.green1.Leave += new System.EventHandler(this.ARGB_Leave);
            this.green1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ARGB_MouseUp);
            // 
            // red1
            // 
            this.red1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.red1.Location = new System.Drawing.Point(241, 25);
            this.red1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.red1.Name = "red1";
            this.red1.Size = new System.Drawing.Size(49, 20);
            this.red1.TabIndex = 25;
            this.red1.TabStop = false;
            this.red1.Tag = "0";
            this.red1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.red1.ValueChanged += new System.EventHandler(this.ARGB_ValueChanged);
            this.red1.Leave += new System.EventHandler(this.ARGB_Leave);
            this.red1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ARGB_MouseUp);
            // 
            // hexBox
            // 
            this.hexBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBox.Location = new System.Drawing.Point(323, 71);
            this.hexBox.Name = "hexBox";
            this.hexBox.Size = new System.Drawing.Size(60, 20);
            this.hexBox.TabIndex = 33;
            this.hexBox.Text = "FFFFFFFF";
            this.hexBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hexBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hexBox_KeyPress);
            this.hexBox.Leave += new System.EventHandler(this.hexBox_Leave);
            // 
            // Hue1
            // 
            this.Hue1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Hue1.DecimalPlaces = 1;
            this.Hue1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Hue1.Location = new System.Drawing.Point(332, 2);
            this.Hue1.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.Hue1.Name = "Hue1";
            this.Hue1.Size = new System.Drawing.Size(49, 20);
            this.Hue1.TabIndex = 25;
            this.Hue1.TabStop = false;
            this.Hue1.Tag = "0";
            this.Hue1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Hue1.ValueChanged += new System.EventHandler(this.HSV_ValueChanged);
            this.Hue1.Leave += new System.EventHandler(this.HSV_Leave);
            this.Hue1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HSV_MouseUp);
            // 
            // Sat1
            // 
            this.Sat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Sat1.DecimalPlaces = 1;
            this.Sat1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Sat1.Location = new System.Drawing.Point(332, 25);
            this.Sat1.Name = "Sat1";
            this.Sat1.Size = new System.Drawing.Size(49, 20);
            this.Sat1.TabIndex = 26;
            this.Sat1.Tag = "0";
            this.Sat1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Sat1.ValueChanged += new System.EventHandler(this.HSV_ValueChanged);
            this.Sat1.Leave += new System.EventHandler(this.HSV_Leave);
            this.Sat1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HSV_MouseUp);
            // 
            // Val1
            // 
            this.Val1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Val1.DecimalPlaces = 1;
            this.Val1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Val1.Location = new System.Drawing.Point(332, 48);
            this.Val1.Name = "Val1";
            this.Val1.Size = new System.Drawing.Size(49, 20);
            this.Val1.TabIndex = 27;
            this.Val1.Tag = "0";
            this.Val1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Val1.ValueChanged += new System.EventHandler(this.HSV_ValueChanged);
            this.Val1.Leave += new System.EventHandler(this.HSV_Leave);
            this.Val1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HSV_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(294, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Hue";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(294, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Sat";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(294, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Value";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(295, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Hex";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(321, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 30;
            this.label9.Text = "(AARRGGBB)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(202, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Red";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(291, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Hue";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(201, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Green";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(201, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Blue";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(201, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Alpha";
            // 
            // ColorWheelTR
            // 
            this.Controls.Add(this.hexBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Val1);
            this.Controls.Add(this.Sat1);
            this.Controls.Add(this.blue1);
            this.Controls.Add(this.Hue1);
            this.Controls.Add(this.green1);
            this.Controls.Add(this.red1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(385, 105);
            this.MinimumSize = new System.Drawing.Size(385, 105);
            this.Name = "ColorWheelTR";
            this.Size = new System.Drawing.Size(385, 105);

            ((System.ComponentModel.ISupportInitialize)(this.blue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.green1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.red1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Val1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.NumericUpDown alpha1;
        private System.Windows.Forms.NumericUpDown blue1;
        private System.Windows.Forms.NumericUpDown green1;
        private System.Windows.Forms.NumericUpDown red1;
        private System.Windows.Forms.TextBox hexBox;
        private System.Windows.Forms.NumericUpDown Hue1;
        private System.Windows.Forms.NumericUpDown Sat1;
        private System.Windows.Forms.NumericUpDown Val1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}
