using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam> 
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
    public class Switch<T> : ISwitchCaseDefault<T>
    {
        private static readonly Switch<T> EMPTY = new Switch<T>(default);
        public T Value { get; set; }

        public Switch() { }
        private Switch(T arg) => Value = arg;
                
        public static Switch<T> Empty => EMPTY;
        public static Switch<T> Of(T arg) => new Switch<T>(arg);
        public static Switch<T> OfNullable(T arg) => arg != null ? Of(arg) : Empty;
        public static Switch<T> OfNullable(Func<T> outputArg) => outputArg != null ? Of(outputArg()) : Empty;

        private bool IsNotNull => Value != null;
        private bool IsNotDefault => !Value.Equals(default);

        protected bool IsPresent => IsNotDefault;

        protected void CaseExecution(Action action)
        {
            if (IsNotNull)
                action?.Invoke();
        }

        protected void DefaultExecution(Action action)
        {
            if (IsNotNull)
                action?.Invoke();
        }

        protected void IfPresent(Action<T> action)
        {
            if (IsNotNull)
                action?.Invoke(Value);
        }  
        
        public T GetCustomized(Func<T, T> funcCustom) => funcCustom(Value);
        public V GetCustomized<V>(Func<T, V> funcCustom) => funcCustom(Value);

        public Case<T> Case => new Case<T>();
        //public Default<T> Default => new Default<T>();

        private protected T caseValue = default;

        public Switch<T> CaseOf(T t)
        {
            caseValue = t;
            return this;
        }

        public Switch<T> SoftDefaultTo => this; // it does not nullifies each members in class
        public Switch<T> HardDefaultTo => new Switch<T>(); // it nullifies each members in class

        private Switch<T> Breaker()
        {
            Console.WriteLine($"It has been broken with the matched value:" +
                $" {Value}");
            (caseValue, Value) = (default, default);
            return this;
        }

        public Switch<T> Accomplish(Action action, bool enableBreak)
        {
            if (caseValue.Equals(Value))
            {
                if (enableBreak)
                {
                    CaseExecution(action);
                    return Breaker();
                }
                else
                {
                    CaseExecution(action);
                    return this;
                }
            }
            else return this;
        }

        public Builder<T> AccomplishDefault(Action action, bool enableBreak)
        {
            if (!caseValue.Equals(Value))
            {
                if (enableBreak)
                {
                    action?.Invoke();
                    return new Builder<T>();
                }
                return new Builder<T>();
            }
            else return new Builder<T>();
        }







        //Builder
        //public ISwitchCaseDefault<T> EndWith => new Default<T>(); //new Default<T>(); //explicit operator ?

    }
}
