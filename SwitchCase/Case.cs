using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public class Case<T> : ISwitchCaseDefault<T>
    {
        ISwitchCaseDefault<T> @switch = Switch<T>.SwitchDefaultAccess;

        private protected T switchValue = Switch<T>.SwitchDefaultAccess.Get();
        private protected T caseValue = default;

        public Case<T> Of(T arg)
        {
            caseValue = arg;
            return this;
        }

        public Case<T> When()
        {
            return this;
        }

        public Switch<T> Accomplish(Action func, bool? enableBreak) => default;
        public Switch<T> Accomplish(Func<T> func, bool? enableBreak)
        {
            if (caseValue.Equals(default) & caseValue.Equals(switchValue))
            {
                if (enableBreak.HasValue) //true
                {
                    func?.Invoke();
                    //return build 
                    //break;
                }
                else //false
                {
                    func?.Invoke();
                }
            }            
            return (Switch<T>)@switch;
        }
    }
}
