using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SwitchCase
{
    public class Case<T> : ISwitchCaseDefault<T>
    {
        ISwitchCaseDefault<T> @switch = Switch<T>.SwitchDefaultAccess;

        private protected T switchValue = Switch<T>.SwitchDefaultAccess.Get();
        private protected T caseValue = default;

        private protected static IList<T> regularList = new List<T>();

        public ReadOnlyCollection<T> ImmutableValueList => new ReadOnlyCollection<T>(regularList);
        public T CaseValue => caseValue;

        public virtual Case<T> Of(T arg)
        {
            caseValue = arg;
            return this;
        }

        public virtual Case<T> When() => this;

        public Switch<T> Accomplish(Action action, bool enableBreak)
        {
            if (caseValue.Equals(default) & caseValue.Equals(switchValue))
            {
                if (enableBreak) //true
                {
                    action?.Invoke();
                    return new Breaker<T>();
                }
                else //false
                {
                    action?.Invoke();
                }
            }
            return Switch<T>.SwitchDefaultAccess;
        }

        public Switch<T> Accomplish(Func<T> func, bool enableBreak) => default;
        public Switch<T> Accomplish(Func<T, T> func, bool enableBreak) => default;
    }
}
