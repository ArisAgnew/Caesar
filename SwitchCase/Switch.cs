using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SwitchCase
{
    /// <summary>
    /// Switch class is a functional wrapper of regular switch operator
    /// with other-following operators such as 'case', 'when', 'default';
    /// </summary>
    /// <typeparam name="T"></typeparam> 
    /// <remarks>
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

        private ImmutableList<V>.Builder argsBuilder = ImmutableList.CreateBuilder<V>();

        private Action ResetValue => () => Value = default;
        private Action ResetCaseValue => () => CaseValue = default;
        private Action ResetArgumentList => () => argsBuilder.Clear();

        public V Value { get; set; } = default;
        public V CaseValue { get; set; } = default;

        private bool IsNull => Value == null; // Check out for reference types as well as value types 06.18.2018
        private bool IsDefault => Value.Equals(default);
        private bool IsInterrupted => default;

        private Switch() { }
        private Switch(V arg) => Value = arg;

        public static Switch<V> Empty { get; } = new Switch<V>(default);

        public static Switch<V> Of(V arg) => new Switch<V>(arg);
        public static Switch<V> OfNullable(V arg) => arg != null ? Of(arg) : Empty;
        public static Switch<V> OfNullable(Func<V> outputArg) => outputArg != null ? Of(outputArg()) : Empty;

        protected override void Breaker()
        {
            ResetValue();
            ResetCaseValue();
        }

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

        public ICase<V> Accomplish(Action action, bool enableBreak)
        {
            if (CaseValue.Equals(Value))
            {
                if (enableBreak)
                {
                    Execution(action);
                    Breaker();
                    return this;
                }
                else
                {
                    Execution(action);
                    return this;
                }
            }
            else return this;
        }

        IDefault<V> IDefault<V>.Accomplish(Action action, bool enableBreak)
        {
            try
            {
                if (!CaseValue.Equals(Value))
                {
                    if (enableBreak)
                    {
                        Execution(action);
                    }
                }
            }
            catch
            {
                return this;
            }
            return this;
        }

        public X AccomplishDefault<X>(Func<X> action = default, bool enableBreak = const_true) =>
            CaseValue.Equals(Value)
                ? default
                : enableBreak
                    ? Execution(action)
                    : default;

        public Switch<V> FullEntitiesReset()
        {
            if (!IsNull && !IsDefault)
            {
                Breaker();
            }
            if (argsBuilder.Count > 0)
            {
                ResetArgumentList();
            }
            return this;
        }

        public ISwitch<V> Peek(Action<V> action)
        {
            if (!IsNull || !IsDefault)
            {
                action?.Invoke(Value);
            }
            return this;
        }

        public V GetCustomized(Func<V, V> funcCustom) => !IsNull || !IsDefault ? funcCustom(Value) : default;
        public U GetCustomized<U>(Func<V, U> funcCustom) => !IsNull || !IsDefault ? funcCustom(Value) : default;

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
