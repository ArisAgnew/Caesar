using System;
using System.Collections.Generic;
using System.Text;
using Caesar.AlternativeStuff;

namespace Caesar.FactoryAssembly
{
    public static class PredicateFactory
    {
        public static Predicate<T> And<T>(this Predicate<T> first, Predicate<T> next) =>
            (T type) => first.RequireNonNull().Invoke(type) && next.RequireNonNull().Invoke(type);        

        public static Predicate<T> Or<T>(this Predicate<T> first, Predicate<T> next) =>
            (T type) => first.RequireNonNull().Invoke(type) || next.RequireNonNull().Invoke(type);
        
        public static Predicate<T> Negate<T>(this Predicate<T> predicate) => 
            (T type) => !predicate.RequireNonNull().Invoke(type);        

        public static Predicate<T> IsEqual<T>(object target) => 
            (T type) => target.RequireNonNull().Equals(type);
    }
}
