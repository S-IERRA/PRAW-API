using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAW
{
    internal static class Extension
    {
        internal static T Modify<T>(this T Generic, Action<T> _Action)
        {
            _Action(Generic);
            return Generic;
        }
    }
}
