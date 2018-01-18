// Decompiled with JetBrains decompiler
// Type: SFMMREGISTER.Form1
// Assembly: SFMMREGISTER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B6C76C7B-07DD-421F-A980-E70EBFD16994
// Assembly location: E:\Desktop\SFM\Manager\Output\Portable\SFMMREGISTER.exe

using Microsoft.Win32;
using SFMMREGISTER.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SFMMREGISTER
{
  public class Form1 : Form
  {
    private IContainer components;
    private Button button1;
    private Label label1;

    public Form1()
    {
      this.InitializeComponent();
    }

    private void RegisterMyProtocol(string myAppPath)
    {
      RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey("SFMM");

      if (registryKey == null)
      {
        RegistryKey subKey = Registry.ClassesRoot.CreateSubKey("SFMM");
        subKey.SetValue(string.Empty, (object) "URL:SFMManager");
        subKey.SetValue("URL Protocol", (object) string.Empty);
        registryKey = subKey.CreateSubKey("DefaultIcon");
        registryKey.SetValue(string.Empty, (object) (myAppPath + "SFMManager.exe \"%1\""));
        registryKey = subKey.CreateSubKey("shell\\open\\command");
        registryKey.SetValue(string.Empty, (object) (myAppPath + "SFMManager.exe \"%1\""));
      }
      registryKey.Close();
      this.label1.Text = "DONE";
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.RegisterMyProtocol(AppDomain.CurrentDomain.BaseDirectory);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.button1 = new Button();
      this.label1 = new Label();
      this.SuspendLayout();
      this.button1.BackColor = System.Drawing.Color.FromArgb(116, 20, 37);
      this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 128);
      this.button1.ForeColor = System.Drawing.Color.AliceBlue;
      this.button1.Location = new Point(87, 164);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 28);
      this.button1.TabIndex = 0;
      this.button1.Text = "Register ";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.FromArgb(116, 20, 37);
      this.label1.Font = new Font("Adobe Gothic Std B", 23.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 77);
      this.label1.ForeColor = System.Drawing.Color.FromArgb(146, 20, 37);
      this.label1.Location = new Point(149, 214);
      this.label1.Name = "label1";
      this.label1.Size = new Size(0, 39);
      this.label1.TabIndex = 1;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) Resources.SFMM;
      this.BackgroundImageLayout = ImageLayout.Zoom;
      this.ClientSize = new Size(258, 258);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.button1);
      this.ForeColor = SystemColors.ControlText;
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (Form1);
      this.Text = "SFMM - REG";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
