using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public class Default<T> : ISwitchCaseDefault<T>
    {
        public Builder<T> Accomplish(Action action, bool? enableBreak) => default; //Builder thereafter
        public Builder<T> Accomplish(Func<T> func, bool? enableBreak) => default;
    }
}
