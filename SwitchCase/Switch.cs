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
    public sealed partial class Switch<V> :
                                    AbstractSwitch<V>,
                                    ISwitch<V>,
                                    ICase<V>,
                                    IDefault<V>
    {  
        private Switch() { }
        private Switch(V arg) => SwitchValue = arg;        

        public static implicit operator Switch<V>(V value) => OfNullable(value);
    }

    /// <summary>
    /// This part of the class contains all kind of constants and fields to be declared
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public sealed partial class Switch<V>
    {
        private const bool const_true = !default(bool);
        private const bool const_false = default(bool);

        private ImmutableList<V>.Builder argsBuilder = ImmutableList.CreateBuilder<V>();
        private Type genericType = typeof(Switch<>)
            .GetGenericArguments()
            .OfType<Type>()
            .FirstOrDefault();        
    }

    /// <summary>
    /// This part of the class contains all kind of auxillary properties 
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public sealed partial class Switch<V>
    {
        private Action ResetValue => () => {
            if (SwitchValue.GetType() == typeof(String) | 
                SwitchValue.GetType() == typeof(Delegate) | 
                SwitchValue.GetType() == typeof(Object))
            {
                return;
            }
            else
                SwitchValue = default;
        };

        private Action ResetCaseValue => () => {
            if (CaseValue.GetType() == typeof(String) | 
                CaseValue.GetType() == typeof(Delegate) | 
                CaseValue.GetType() == typeof(Object))
            {
                return;
            }
            else
                CaseValue = default;
        };

        private Action ResetArgumentList => () => argsBuilder?.Clear();

        public V SwitchValue { get; set; } = default;
        public V CaseValue { get; set; } = default;

        private bool IsNull => SwitchValue == null;
        private bool IsDefault => SwitchValue.Equals(default);
        private bool IsInterrupted => default;

        private bool IsValueType => (genericType ?? default).IsValueType;
        private bool IsReferenceType => !(genericType ?? default).IsValueType;
    }

    /// <summary>
    /// This part of the class contains main entrant point to be computed henceforward
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public sealed partial class Switch<V>
    {
        public static Switch<V> Empty { get; } = new Switch<V>(default);

        public static Switch<V> Of(V arg) => new Switch<V>(arg);
        public static Switch<V> OfNullable(V arg) => arg != null ? Of(arg) : Empty;
        public static Switch<V> OfNullable(Func<V> outputArg) => outputArg != null ? Of(outputArg()) : Empty;
    }

    /// <summary>
    /// This part of the class contains entrant points for henceforward computation and execution
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public sealed partial class Switch<V>
    {
        public ICase<V> CaseOf(V value)
        {
            if (!value.Equals(default))
            {
                CaseValue = value;
                argsBuilder?.Add(value);
            }
            return this;
        }

        public IDefault<V> ChangeOverToDefault => this;
    }

    /// <summary>
    /// This part of the class contains main private service executable entities
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public sealed partial class Switch<V>
    {
        private protected sealed override void Breaker() => new Action(() => { ResetValue(); ResetCaseValue(); })?.Invoke();

        private protected sealed override void Execution(Action action) => ExecutionBySwitchValue(v => action?.Invoke());

        private void ExecutionBySwitchValue(Action<V> actionBySwitchValue) => new Action(() => {
            if (!IsNull || !IsDefault)
                actionBySwitchValue?.Invoke(SwitchValue);
        })?.Invoke();

        private void ExecutionByCaseValue(Action<V> actionByCaseValue) => new Action(() => {
            if (!IsNull || !IsDefault)
                actionByCaseValue?.Invoke(CaseValue);
        })?.Invoke();

        private protected sealed override V Execution(Func<V> supplier) =>
            supplier.Equals(default)
                ? default
                : (!IsNull || !IsDefault)
                    ? supplier()
                    : default;
    }

    /// <summary>
    /// This part of the class contains main executable entities
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public sealed partial class Switch<V>
    {
        public ICase<V> Accomplish(Action action, bool enableBreak)
        {
            if (CaseValue.Equals(SwitchValue))
            {
                if (enableBreak)
                {
                    Execution(action ?? default);
                    Breaker();
                    return this;
                }
                else
                {
                    Execution(action ?? default);
                    return this;
                }
            }
            else return this;
        }

        public ICase<V> Accomplish(Action<V> action, bool enableBreak)
        {
            if (CaseValue.Equals(SwitchValue))
            {
                if (enableBreak)
                {
                    ExecutionByCaseValue(action ?? default);
                    Breaker();
                    return this;
                }
                else
                {
                    ExecutionByCaseValue(action ?? default);
                    return this;
                }
            }
            else return this;
        }

        IDefault<V> IDefault<V>.Accomplish(Action action, bool enableBreak)
        {
            if (!CaseValue.Equals(SwitchValue))
            {
                if (enableBreak)
                {
                    Execution(action ?? default);
                }
            }
            return this;
        }

        IDefault<V> IDefault<V>.Accomplish(Action<V> action, bool enableBreak)
        {
            if (!CaseValue.Equals(SwitchValue))
            {
                if (enableBreak)
                {
                    ExecutionBySwitchValue(action ?? default);
                }
            }
            return this;
        }

        V IDefault<V>.Accomplish(Func<V> supplier, bool enableBreak) => 
            CaseValue.Equals(SwitchValue)
                ? default
                : enableBreak
                    ? Execution(supplier)
                    : default;
    }

    /// <summary>
    /// This part of the class contains extra tools to be interacted with
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public sealed partial class Switch<V>
    {
        public Switch<V> FullEntitiesReset()
        {
            if (!IsNull && !IsDefault)
            {
                Breaker();
            }

            if (argsBuilder?.Count > 0)
            {
                ResetArgumentList();
            }

            return this;
        }

        public ISwitch<V> Peek(Action<V> action)
        {
            if (!IsNull || !IsDefault)
            {
                action?.Invoke(SwitchValue);
            }

            return this;
        }
    }

    /// <summary>
    /// This part of the class contains all kind of exctraction of information
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public sealed partial class Switch<V>
    {
        public V GetSwitchValue() => SwitchValue;
        public V GetCaseValue() => CaseValue;
        public V GetCustomized(Func<V, V> funcCustom) => !IsNull || !IsDefault ? funcCustom(SwitchValue) : default;
        public U GetCustomized<U>(Func<V, U> funcCustom) => !IsNull || !IsDefault ? funcCustom(SwitchValue) : default;

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
