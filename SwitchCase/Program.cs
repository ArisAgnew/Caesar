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
                .CaseOf(150).Accomplish(() => WriteLine("Two"))
                .CaseOf(130).Accomplish(() => WriteLine("Three"))
                .CaseOf(1340).Accomplish(() => WriteLine("Four"))
                .CaseOf(153).Accomplish(() => WriteLine("Five"))
                .CaseOf(18765).Accomplish(() => WriteLine("Six"))
                .CaseOf(10).Accomplish(() => WriteLine("Seven"))
                .CaseOf(192).Accomplish(() => WriteLine("Eight"))
                .CaseOf(210).Accomplish(() => WriteLine("Nine"))
                .CaseOf(4510).Accomplish(() => WriteLine("Ten"))
                .CaseOf(3510).Accomplish(() => WriteLine("Eleven"))
                .CaseOf(6210).Accomplish(() => WriteLine("Twelve"))
                .Default.CarryOutTo(() => WriteLine("Default"));

            _switch.GetAllValuesAsTuple();

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
