// Decompiled with JetBrains decompiler
// Type: SFMMREGISTER.Program
// Assembly: SFMMREGISTER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B6C76C7B-07DD-421F-A980-E70EBFD16994
// Assembly location: E:\Desktop\SFM\Manager\Output\Portable\SFMMREGISTER.exe

using System;
using System.Windows.Forms;

namespace SFMMREGISTER
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
