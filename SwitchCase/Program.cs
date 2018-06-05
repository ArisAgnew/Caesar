using System;
using static System.Console;

namespace SwitchCase
{
    class Program
    {
        static void Main(string[] args)
        {
            int j = 10;

            var _switch = Switch<int>.OfNullable(j);

            _switch
                .CaseOf(10).Accomplish(() => WriteLine("Ten"), true)
                //.CaseOf(2).Accomplish(() => WriteLine("Two"), false)
                .DefaultTo.AccomplishDefault(() => WriteLine("Default"), true)
                .BuildUp();

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
