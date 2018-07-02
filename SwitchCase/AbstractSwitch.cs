using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    internal abstract class AbstractSwitch<V>
    {
        private protected abstract void Breaker();
        private protected abstract void Execution(Action action);
        private protected abstract X Execution<X>(Func<X> action);
    }
}
