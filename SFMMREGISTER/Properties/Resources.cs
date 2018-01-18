// Decompiled with JetBrains decompiler
// Type: SFMMREGISTER.Properties.Resources
// Assembly: SFMMREGISTER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B6C76C7B-07DD-421F-A980-E70EBFD16994
// Assembly location: E:\Desktop\SFM\Manager\Output\Portable\SFMMREGISTER.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace SFMMREGISTER.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (SFMMREGISTER.Properties.Resources.resourceMan == null)
          SFMMREGISTER.Properties.Resources.resourceMan = new ResourceManager("SFMMREGISTER.Properties.Resources", typeof (SFMMREGISTER.Properties.Resources).Assembly);
        return SFMMREGISTER.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return SFMMREGISTER.Properties.Resources.resourceCulture;
      }
      set
      {
        SFMMREGISTER.Properties.Resources.resourceCulture = value;
      }
    }

    internal static Bitmap SFMM
    {
      get
      {
        return (Bitmap) SFMMREGISTER.Properties.Resources.ResourceManager.GetObject(nameof (SFMM), SFMMREGISTER.Properties.Resources.resourceCulture);
      }
    }
  }
}
