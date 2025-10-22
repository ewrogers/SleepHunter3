using System.Collections.Generic;
using System.Windows.Forms;

namespace SleepHunter.Extensions
{
    public static class SelectedIndexCollectionExtensions
    {
        public static IReadOnlyList<int> ToList(this ListBox.SelectedIndexCollection collection)
        {
            var list = new List<int>();
            for (var i = 0; i < collection.Count; i++)
            {
                list.Add(collection[i]);
            }

            return list;
        }

        public static IReadOnlyList<int> ToList(this ListView.SelectedIndexCollection collection)
        {
            var list = new List<int>();
            for (var i = 0; i < collection.Count; i++)
            {
                list.Add(collection[i]);
            }

            return list;
        }
    }
}