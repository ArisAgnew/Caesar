using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public interface ISwitch<V>
    {
        V Value { get; set; }
        ISwitch<V> Peek(Action<V> action);
    }
}
