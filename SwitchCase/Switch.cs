using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>    /// 
    /// <remarks>
    /// 
    /// In C# 6, the match expression must be an expression that returns a value of the following types:
    /// a char.
    /// a string.
    /// a bool.
    /// an integral value, such as an int or a long.
    /// an enum value.
    /// 
    /// Starting with C# 7.0, the match expression can be any non-null expression.
    /// </remarks>
    public sealed class Switch<T> : ISwitchCaseDefault<T>
    {
        private static readonly Switch<T> EMPTY = new Switch<T>(default);
        private readonly T value;

        private Switch() { }
        private Switch(T arg) => value = arg;
                
        public static Switch<T> Empty => EMPTY;
        public static Switch<T> Of(T arg) => new Switch<T>(arg);
        public static Switch<T> OfNullable(T arg) => arg != null ? Of(arg) : Empty;
        public static Switch<T> OfNullable(Func<T> outputArg) => outputArg != null ? Of(outputArg()) : Empty;

        public static Switch<T> SwitchDefaultAccess => new Switch<T>();

        public Case<T> Case { get; private set; }
        public Default<T> Default { get; private set; }

        //public ISwitchCaseDefault<T> EndWith => new Default<T>(); //new Default<T>(); //explicit operator ?

    }
}
