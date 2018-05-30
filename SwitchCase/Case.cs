using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public class Case<T> : ISwitchCaseDefault<T>
    {
        public Case<T> Of() => default;
        public Case<T> When() => default;
        public Switch<T> Then() => Switch<T>.SwitchDefaultAccess;
    }
}
