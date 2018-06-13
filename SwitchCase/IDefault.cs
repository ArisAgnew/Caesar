using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public interface IDefault<V>
    {
        IDefault<V> Accomplish(Action action = default, bool enableBreak = true);
    }
}
