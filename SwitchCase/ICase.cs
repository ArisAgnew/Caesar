using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public interface ICase<V>
    {
        V CaseValue { get; set; }
        ICase<V> CaseOf(V v);
        ICase<V> Accomplish(Action action = default, bool enableBreak = !default(bool));
        IDefault<V> ChangeOverToDefault { get; }
    }
}
