﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    internal abstract class AbstractSwitch<V>
    {
        protected abstract void Breaker();
        protected abstract void Execution(Action action);
        protected abstract X Execution<X>(Func<X> action);
    }
}
