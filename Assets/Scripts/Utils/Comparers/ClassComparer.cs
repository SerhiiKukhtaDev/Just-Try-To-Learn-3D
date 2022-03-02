using System.Collections.Generic;
using Models;

namespace Utils.Comparers
{
    public class ClassComparer : IComparer<Class>
    {
        public int Compare(Class firstClass, Class secondClass)
        {
            var x = firstClass.Name;
            var y = secondClass.Name;
            
            if (x.GetIntByText() > y.GetIntByText()) return 1;
            if (x.GetIntByText() < y.GetIntByText()) return -1;

            return 0;
        }
    }
}
