using System;
using static System.Console;

namespace SwitchCase
{
    class Program
    {
        static void Main(string[] args)
        {
            int? j = 10;

            Switch<int?>.OfNullable(j)
                .CaseOf(102).Accomplish(() => WriteLine("Ten"))
                .CaseOf(102).Accomplish(() => WriteLine("Two"))
                .CaseOf(10).Accomplish(() => WriteLine("Three"))
                .Default.AccomplishDefault(() => WriteLine("Default"));
            
            /*int _value = default;
            WriteLine(_value);
            WriteLine(_value.Equals(default(int)));*/

            /*WriteLine(Switch<int>.OfNullable(j).Get());

            var _switch = Switch<int>.OfNullable(j);
            WriteLine(_switch.Get());
            WriteLine(new Switch<int>().Get());*/

            ReadKey();
        }
    }
}
