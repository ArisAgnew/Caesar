using System;
using System.Collections.Generic;
using System.Text;

using static System.Boolean;

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
        private const bool const_true = true;
        private const bool const_false = false;

        private static readonly Switch<T> EMPTY = new Switch<T>(default);
        
        public T Value { get; set; }
        private protected T CaseValue { get; set; } = default;

        public Switch() { }
        private Switch(T arg) => Value = arg;
                
        public static Switch<T> Empty => EMPTY;
        public static Switch<T> Of(T arg) => new Switch<T>(arg);
        public static Switch<T> OfNullable(T arg) => arg != null ? Of(arg) : Empty;
        public static Switch<T> OfNullable(Func<T> outputArg) => outputArg != null ? Of(outputArg()) : Empty;

        private bool IsNull => Value == null;
        private bool IsDefault => Value.Equals(default);
        private bool IsInterrupted => default; 

        protected void Execution(Action action)
        {
            if (!IsNull || !IsDefault)
                action?.Invoke();
        }

        protected X Execution<X>(Func<X> action) => 
            !action.Equals(default) 
                ? default 
                : (!IsNull || !IsDefault) 
                    ? action() 
                    : default;

        public T GetCustomized(Func<T, T> funcCustom) => funcCustom(Value);
        public V GetCustomized<V>(Func<T, V> funcCustom) => funcCustom(Value);

        public Case<T> Case => new Case<T>();
        //public Default<T> Default => new Default<T>();

        public Switch<T> CaseOf(T t)
        {
            CaseValue = t;
            return this;
        }

        public Switch<T> SoftDefaultTo => this; // it does not nullifies each members in class
        public Switch<T> HardDefaultTo => new Switch<T>(); // it nullifies each members in class

        private Switch<T> Breaker()
        {
            (CaseValue, Value) = (default, default);
            return this;
        }

        public Switch<T> Accomplish(Action action = default, bool enableBreak = const_true)
        {
            if (CaseValue.Equals(Value))
            {
                if (enableBreak)
                {
                    Execution(action);
                    return Breaker();
                }
                else
                {
                    Execution(action);
                    return this;
                }
            }
            else return this;
        }

        public void AccomplishDefault(Action action = default, bool enableBreak = const_true)
        {
            if (!CaseValue.Equals(Value))
            {
                if (enableBreak)
                {
                    Execution(action);                    
                }               
            }            
        }

        public X AccomplishDefault<X>(Func<X> action = default, bool enableBreak = const_true) => 
            CaseValue.Equals(Value) 
                ? default 
                : enableBreak 
                    ? Execution(action) 
                    : default;

        public virtual void Reset()
        {

        }

        public virtual V GetAllValues<V>() where V : class
        {
            return default;
        }
    }
}
