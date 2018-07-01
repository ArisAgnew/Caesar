using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public interface ISwitch<V>
    {
        V SwitchValue { get; set; }
        ISwitch<V> Peek(Action<V> action);
    }
}
