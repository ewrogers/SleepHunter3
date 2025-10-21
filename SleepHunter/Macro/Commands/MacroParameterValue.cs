using System.Drawing;
using System.Windows.Forms;

namespace SleepHunter.Macro.Commands
{
    public class MacroParameterValue
    {
        public MacroParameterType Type { get; set; }
        public object Value { get; set; }

        public bool AsBoolean() => (bool)Value;
        public long AsInteger() => (long)Value;
        public double AsDouble() => (double)Value;
        public string AsString() => Value.ToString();
        public Keys[] AsKeystrokes() => (Keys[])Value;
        public Point AsPoint() => (Point)Value;
    }
}