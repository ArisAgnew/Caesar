﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public class Default<T> : ISwitchCaseDefault<T>
    {
        public Default<T> Of() => default;
        public Switch<T> Then() => default; //Builder thereafter
    }
}
