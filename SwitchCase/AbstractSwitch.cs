using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public abstract class AbstractSwitch<V>
    {
        private protected abstract void Breaker();
        private protected abstract void Execution(Action action);
        private protected abstract V Execution(Func<V> supplier);
    }
}
