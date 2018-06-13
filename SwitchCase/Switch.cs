using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
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
    internal sealed class Switch<V> : 
                                    AbstractSwitch<V>,
                                    ISwitch<V>,
                                    ICase<V>,
                                    IDefault<V>
    {
        private const bool const_true = !default(bool);
        private const bool const_false = default(bool);
        
        private static readonly Switch<V> EMPTY = new Switch<V>(default);

        private readonly ImmutableList<V>.Builder argsBuilder = ImmutableList.CreateBuilder<V>();

        private Action ResetAction => () => (Value, CaseValue) = (default, default);

        public V Value { get; set; }
        public V CaseValue { get; set; } = default;

        private bool IsNull => Value == null;
        private bool IsDefault => Value.Equals(default);
        private bool IsInterrupted => default;

        private Switch() { }
        private Switch(V arg) => Value = arg;
                
        public static Switch<V> Empty => EMPTY;
        public static Switch<V> Of(V arg) => new Switch<V>(arg);
        public static Switch<V> OfNullable(V arg) => arg != null ? Of(arg) : Empty;
        public static Switch<V> OfNullable(Func<V> outputArg) => outputArg != null ? Of(outputArg()) : Empty;
        
        protected override void Execution(Action action)
        {
            if (!IsNull || !IsDefault)
                action?.Invoke();
        }

        protected override X Execution<X>(Func<X> action) => 
            !action.Equals(default) 
                ? default 
                : (!IsNull || !IsDefault) 
                    ? action() 
                    : default;

        public V GetCustomized(Func<V, V> funcCustom) => funcCustom(Value);
        public U GetCustomized<U>(Func<V, U> funcCustom) => funcCustom(Value);

        public ICase<V> CaseOf(V t)
        {
            if (!t.Equals(default))
            {
                CaseValue = t;
                argsBuilder.Add(t);
            }
            return this;
        }

        public IDefault<V> ChangeOverToDefault
        {
            get
            {
                // some extra logic to be added later on
                return this;
            }
        }

        private Switch<V> Breaker()
        {
            ResetAction();
            return this;
        }

        public ICase<V> Accomplish(Action action, bool enableBreak)
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

        public void CarryOut(Action action = default, bool enableBreak = const_true)
        {
            if (!CaseValue.Equals(Value))
            {
                if (enableBreak)
                {
                    Execution(action);                    
                }               
            }            
        }

        IDefault<V> IDefault<V>.Accomplish(Action action, bool enableBreak)
        {
            CarryOut(action, enableBreak);
            return this;
        }

        public X AccomplishDefault<X>(Func<X> action = default, bool enableBreak = const_true) => 
            CaseValue.Equals(Value) 
                ? default 
                : enableBreak 
                    ? Execution(action) 
                    : default;

        public Switch<V> Reset() => default; //still in development
               
        public ImmutableHashSet<V> GetCaseValuesAsImmutableSet() => argsBuilder.ToImmutableHashSet() ?? default;
        public ImmutableList<V> GetCaseValuesAsImmutableList() => argsBuilder.ToImmutable() ?? default;
        public ImmutableSortedSet<V> GetCaseValuesAsImmutableSortedSet() => argsBuilder.ToImmutableSortedSet() ?? default;
        
        public void GetValuesAsTuple() // implement it properly 06/13/2018
        {
            GetCaseValuesAsImmutableList().ForEach(v => Console.WriteLine(v));
            var V = GetCaseValuesAsImmutableList()
                .Select(eachValue => Tuple.Create(eachValue)).ToList();

            V.ForEach(v => Console.WriteLine(v));

            var ar = new List<int>(new int[] { 5, 7, 9 });            
            Tuple<List<int>> result = Tuple.Create(ar);

            Console.WriteLine(result.Item1);
        }
    }
}
