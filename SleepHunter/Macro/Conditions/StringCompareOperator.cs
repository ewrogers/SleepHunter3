namespace SleepHunter.Macro.Conditions
{
    public enum StringCompareOperator
    {
        Equal = 0,
        LessThan = -1,
        GreaterThan = 1,
        NotEqual = 2,
        Contains = 3,
        NotContains = -3,
        StartsWith = 4,
        NotStartsWith = -4,
        EndsWith = 5,
        NotEndsWith = -5
    }
}