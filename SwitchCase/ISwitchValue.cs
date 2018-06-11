using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public interface ISwitchValue<T>
    {
        T Value { get; set; }
    }
}
