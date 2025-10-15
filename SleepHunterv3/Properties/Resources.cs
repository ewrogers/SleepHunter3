// Decompiled with JetBrains decompiler
// Type: SleepHunterv3.Properties.Resources
// Assembly: SleepHunterv3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DFF5A8C7-0B65-4F11-B7C9-8CFDED4A0FFA

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace SleepHunterv3.Properties;

[DebuggerNonUserCode]
[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
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
      if (object.ReferenceEquals((object) SleepHunterv3.Properties.Resources.resourceMan, (object) null))
        SleepHunterv3.Properties.Resources.resourceMan = new ResourceManager("SleepHunterv3.Properties.Resources", typeof (SleepHunterv3.Properties.Resources).Assembly);
      return SleepHunterv3.Properties.Resources.resourceMan;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static CultureInfo Culture
  {
    get => SleepHunterv3.Properties.Resources.resourceCulture;
    set => SleepHunterv3.Properties.Resources.resourceCulture = value;
  }
}
