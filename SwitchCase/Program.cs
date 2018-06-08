using System;
using static System.Console;

namespace SwitchCase
{
    class Program
    {
        static void Main(string[] args)
        {
            int? j = 10;

            var _switch = Switch<int?>.OfNullable(j);

            _switch
                .CaseOf(102).Accomplish(() => WriteLine("Ten"))
                //.CaseOf(102).Accomplish(() => WriteLine("Two"))
                .SoftDefaultTo.AccomplishDefault(() => WriteLine("Default"))
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
