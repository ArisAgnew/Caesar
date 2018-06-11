using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    internal abstract class AbstractSwitch<T>
    {
        protected abstract void Execution(Action action);
        protected abstract X Execution<X>(Func<X> action);
    }
}
