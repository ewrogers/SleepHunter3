using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace SleepHunter.Properties
{

    [DebuggerNonUserCode]
    [CompilerGenerated]
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    internal class Resources
    {
        private static ResourceManager _resourceMan;
        private static CultureInfo _resourceCulture;

        internal Resources()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals((object)SleepHunter.Properties.Resources._resourceMan, (object)null))
                    SleepHunter.Properties.Resources._resourceMan = new ResourceManager("SleepHunter.Properties.Resources", typeof(SleepHunter.Properties.Resources).Assembly);
                return SleepHunter.Properties.Resources._resourceMan;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get => SleepHunter.Properties.Resources._resourceCulture;
            set => SleepHunter.Properties.Resources._resourceCulture = value;
        }
    }
}