using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public interface ICase<V>
    {
        V CaseValue { get; set; }
        ICase<V> CaseOf(V t);
        ICase<V> Accomplish(Action action = default, bool enableBreak = true);
        IDefault<V> ChangeOverToDefault { get; }
    }
}
