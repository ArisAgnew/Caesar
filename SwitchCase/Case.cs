using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCase
{
    public class Case<T> : ISwitchCaseDefault<T>
    {
        ISwitchCaseDefault<T> @switch = Switch<T>.SwitchDefaultAccess;

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

        public Switch<T> Then(Func<T> func, bool? enableBreak, bool? enableGoTo)
        {
            if (enableBreak.HasValue) //true
            {
                if (!enableGoTo.HasValue) //false
                {
                    func?.Invoke();
                    //break;
                }
            }
            else //false
            {
                if (enableGoTo.HasValue) //true
                {
                    func?.Invoke();
                    //goto logic;
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
