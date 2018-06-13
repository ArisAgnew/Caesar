using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SwitchCase
{
    public class Case<T> : ISwitchCaseDefault<T>
    {
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

        /*public Switch<V> Accomplish(Action action, bool enableBreak)
        {
            
            if (!caseValue.Equals(default) & caseValue.Equals(switchValue))
            {
                if (enableBreak) //true
                {
                    action?.Invoke();
                    return new Breaker<V>();
                }
                else //false
                {
                    action?.Invoke();
                }
            }
            else return new Switch<V>();           
        }*/

        //public Switch<V> Accomplish(Func<V> func, bool enableBreak) => default;
        //public Switch<V> Accomplish(Func<V, V> func, bool enableBreak) => default;
    }
}
