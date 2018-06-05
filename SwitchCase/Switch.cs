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
        private T _value;

        public Switch() { }
        private Switch(T arg) => _value = arg;
                
        public static Switch<T> Empty => EMPTY;
        public static Switch<T> Of(T arg) => new Switch<T>(arg);
        public static Switch<T> OfNullable(T arg) => arg != null ? Of(arg) : Empty;
        public static Switch<T> OfNullable(Func<T> outputArg) => outputArg != null ? Of(outputArg()) : Empty;

        protected bool IsPresent => _value != null || !_value.Equals(default(T));

        protected void IfPresent(Action action)
        {
            if (IsPresent)
                action?.Invoke();
        }

        protected void IfPresent(Action<T> action)
        {
            if (IsPresent)
                action?.Invoke(_value);
        }

        public T Value
        {
            get => _value;
            set => value = _value;
        }

        public ref T GetByRef()
        {
            ref T ref_value = ref _value;
            return ref ref_value;
        }        

        public T GetCustomized(Func<T, T> funcCustom) => funcCustom(_value);
        public V GetCustomized<V>(Func<T, V> funcCustom) => funcCustom(_value);

        public Case<T> Case => new Case<T>();
        //public Default<T> Default => new Default<T>();

        private protected T caseValue = default;

        public Switch<T> CaseOf(T t)
        {
            caseValue = t;
            return this;
        }

        public Switch<T> DefaultTo
        {
            get
            {
                
                return new Switch<T>();
            }
        }

        private Switch<T> Breaker()
        {
            Console.WriteLine($"It has been broken with the matched value:" +
                $" {Value}");
            _value = default;
            return this;
        }

        public Switch<T> Accomplish(Action action, bool enableBreak)
        {
            if (!caseValue.Equals(default) && caseValue.Equals(Value))
            {
                if (enableBreak) //true
                {
                    IfPresent(action);
                    return Breaker();                    
                }
                else //false
                {
                    IfPresent(action);
                    return this;
                }
            }
            else return this;
        }

        public Builder<T> AccomplishDefault(Action action, bool enableBreak)
        {
            if (!caseValue.Equals(default) && caseValue.Equals(Value))
            {
                if (enableBreak) //true
                {
                    IfPresent(action);
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
