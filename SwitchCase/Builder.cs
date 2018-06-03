using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public class Builder<T> : ISwitchCaseDefault<T>
    {
        public Switch<T> BuildUp() => Switch<T>.SwitchDefaultAccess;
    }
}
