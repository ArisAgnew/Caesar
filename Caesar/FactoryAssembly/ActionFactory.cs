using System;
using System.Collections.Generic;
using System.Text;
using Caesar.AlternativeStuff;

namespace Caesar.FactoryAssembly
{
    public static class ActionFactory
    {
        public static Action<T> ForwardCompose<T>(this Action<T> first, Action<T> next) => 
            (T type) => 
            {
                first.RequireNonNull().Invoke(type);
                next.RequireNonNull().Invoke(type);
            };
    }
}
