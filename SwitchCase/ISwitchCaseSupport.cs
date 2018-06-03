using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public interface ISwitchCaseSupport<T>
    {
        ISwitchCaseSupport<T> Of(T arg);
    }
}
