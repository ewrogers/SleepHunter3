using SleepHunter.Macro.Conditions;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SleepHunter.Macro.Commands
{
    public class MacroParameterValue
    {
        public MacroParameterType Type { get; set; }
        public object Value { get; set; }

        public bool AsBoolean() => (bool)Value;
        public long AsInteger() => (long)Value;
        public double AsFloat() => (double)Value;
        public string AsString() => Value.ToString();
        public Keys[] AsKeystrokes() => (Keys[])Value;
        public Point AsPoint() => (Point)Value;
        public CompareOperator AsCompareOperator() => (CompareOperator)Value;
        public LogicalOperator AsLogicalOperator() => (LogicalOperator)Value;
        public StringCompareOperator AsStringCompareOperator() => (StringCompareOperator)Value;

        public static MacroParameterValue Boolean(bool value) => new MacroParameterValue { Type = MacroParameterType.Boolean, Value = value };
        public static MacroParameterValue Integer(long value) => new MacroParameterValue { Type = MacroParameterType.Integer, Value = value };
        public static MacroParameterValue Float(long value) => new MacroParameterValue { Type = MacroParameterType.Float, Value = value };
        public static MacroParameterValue String(string value) => new MacroParameterValue { Type = MacroParameterType.String, Value = value };

        public static MacroParameterValue Keys(IEnumerable<Keys> keys) => new MacroParameterValue { Type = MacroParameterType.Keystrokes, Value = keys.ToArray() };
        public static MacroParameterValue Point(Point point) => new MacroParameterValue { Type = MacroParameterType.Point, Value = point };
        public static MacroParameterValue CompareOperator(CompareOperator op) => new MacroParameterValue { Type = MacroParameterType.CompareOperator, Value = op };
        public static MacroParameterValue LogicalOperator(LogicalOperator op) => new MacroParameterValue { Type = MacroParameterType.LogicalOperator, Value = op };
        public static MacroParameterValue StringCompareOperator(StringCompareOperator op) => new MacroParameterValue { Type = MacroParameterType.StringCompareOperator, Value = op };
    }
}