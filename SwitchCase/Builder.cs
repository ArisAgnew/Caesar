using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public class Builder<T> : ISwitchCaseDefault<T>
    {
        internal Switch<T> BuildUp() => new Switch<T>(); //expand a logic
    }
}
