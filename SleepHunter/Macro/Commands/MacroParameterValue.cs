using SleepHunter.Macro.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SleepHunter.Macro.Commands
{
    public class MacroParameterValue
    {
        public MacroParameterType Type { get; set; }
        public object Value { get; set; }

        public bool AsBoolean() => Convert.ToBoolean(Value);
        public int AsInteger() => Convert.ToInt32(Value);
        public long AsLong() => Convert.ToInt64(Value);
        public float AsFloat() => Convert.ToSingle(Value);
        public double AsDouble() => Convert.ToDouble(Value);
        public string AsString() => Value.ToString();
        public Keys[] AsKeystrokes() => (Keys[])Value;
        public CompareOperator AsCompareOperator() => (CompareOperator)Value;
        public LogicalOperator AsLogicalOperator() => (LogicalOperator)Value;
        public StringCompareOperator AsStringCompareOperator() => (StringCompareOperator)Value;

        public static MacroParameterValue Boolean(bool value) => new MacroParameterValue { Type = MacroParameterType.Boolean, Value = value };
        public static MacroParameterValue Integer(int value) => new MacroParameterValue { Type = MacroParameterType.Integer, Value = value };
        public static MacroParameterValue Long(long value) => new MacroParameterValue { Type = MacroParameterType.Integer, Value = value };
        public static MacroParameterValue Float(float value) => new MacroParameterValue { Type = MacroParameterType.Float, Value = value };
        public static MacroParameterValue Double(double value) => new MacroParameterValue { Type = MacroParameterType.Float, Value = value };
        public static MacroParameterValue String(string value) => new MacroParameterValue { Type = MacroParameterType.String, Value = value };

        public static MacroParameterValue Keys(IEnumerable<Keys> keys) => new MacroParameterValue { Type = MacroParameterType.Keystrokes, Value = keys.ToArray() };
        public static MacroParameterValue CompareOperator(CompareOperator op) => new MacroParameterValue { Type = MacroParameterType.CompareOperator, Value = op };
        public static MacroParameterValue LogicalOperator(LogicalOperator op) => new MacroParameterValue { Type = MacroParameterType.LogicalOperator, Value = op };
        public static MacroParameterValue StringCompareOperator(StringCompareOperator op) => new MacroParameterValue { Type = MacroParameterType.StringCompareOperator, Value = op };
    }
}