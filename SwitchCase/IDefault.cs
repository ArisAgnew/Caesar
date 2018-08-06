using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public interface IDefault<V>
    {
        IDefault<V> Accomplish(Action action = default, bool enableBreak = !default(bool));
        IDefault<V> Accomplish(Action<V> action = default, bool enableBreak = !default(bool));
        V Accomplish(Func<V> supplier = default, bool enableBreak = !default(bool));
    }
}
