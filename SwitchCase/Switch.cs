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
                                    ISwitchCaseDefault<V>,
                                    ISwitchValue<V>,
                                    ICaseValue<V>
    {
        private const bool const_true = !default(bool);
        private const bool const_false = default(bool);
        
        private static readonly Switch<V> EMPTY = new Switch<V>(default);
        private ImmutableList<V>.Builder argsBuilder = ImmutableList.CreateBuilder<V>();

        public V Value { get; set; }
        public V CaseValue { get; set; } = default;

        public Switch() { }
        private Switch(V arg) => Value = arg;
                
        public static Switch<V> Empty => EMPTY;
        public static Switch<V> Of(V arg) => new Switch<V>(arg);
        public static Switch<V> OfNullable(V arg) => arg != null ? Of(arg) : Empty;
        public static Switch<V> OfNullable(Func<V> outputArg) => outputArg != null ? Of(outputArg()) : Empty;

        private bool IsNull => Value == null;
        private bool IsDefault => Value.Equals(default);
        private bool IsInterrupted => default; 

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

        public Case<V> Case => new Case<V>();
        //public Default<V> Default => new Default<V>();

        public Switch<V> CaseOf(V t)
        {
            if (!t.Equals(default))
            {
                CaseValue = t;
                argsBuilder.Add(t);
            }
            return this;
        }

        public Switch<V> Default
        {
            get
            {
                // some extra logic to be added later on
                return this;
            }
        }

        public Switch<V> SoftDefaultTo => this; // it does not nullifies each members in class
        public Switch<V> HardDefaultTo => new Switch<V>(); // it nullifies each members in class

        private Action ResetAction => () => (Value, CaseValue) = (default, default);

        private Switch<V> Breaker()
        {
            ResetAction();
            return this;
        }

        public Switch<V> Accomplish(Action action = default, bool enableBreak = const_true)
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

        public Switch<V> CarryOutTo(Action action = default, bool enableBreak = const_true)
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

        public Switch<V> BuildUp()
        {
            ImmutableList<V> imListOfArgs = argsBuilder?.ToImmutable();
            imListOfArgs.ForEach(delegate(V element) {
                Console.WriteLine(element);
            });
            return this;
        }
        
        public ImmutableHashSet<V>   GetImmutableSet()       => argsBuilder.ToImmutableHashSet()   ?? default;
        public ImmutableList<V>      GetImmutableList()      => argsBuilder.ToImmutable()          ?? default;
        public ImmutableSortedSet<V> GetImmutableSortedSet() => argsBuilder.ToImmutableSortedSet() ?? default;
        
        public void GetValuesAsTuple() // implement properly 06/13/2018
        {
            GetImmutableList().ForEach(v => Console.WriteLine(v));
            var V = GetImmutableList()
                .Select(eachValue => Tuple.Create(eachValue)).ToList();

            V.ForEach(v => Console.WriteLine(v));

            var ar = new List<int>(new int[] { 5, 7, 9 });            
            Tuple<List<int>> result = Tuple.Create(ar);

            Console.WriteLine(result.Item1);
        }
    }
}
