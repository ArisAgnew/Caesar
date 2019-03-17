using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCore.Functions.JavaScript
{
    interface IFunc<in In, out Out>
    {
        Out Apply(In @in);
    }
}
