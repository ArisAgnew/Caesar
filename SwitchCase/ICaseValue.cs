using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public interface ICaseValue<T>
    {
        T CaseValue { get; set; }
    }
}
