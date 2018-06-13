using System;
using static System.Console;

namespace SwitchCase
{
    public enum Color { Red, Green, Blue }

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
                .CaseOf(102).Accomplish(() => WriteLine("Seven"))
                .CaseOf(192).Accomplish(() => WriteLine("Eight"))
                .CaseOf(210).Accomplish(() => WriteLine("Nine"))
                .CaseOf(4510).Accomplish(() => WriteLine("Ten"))
                .CaseOf(103).Accomplish(() => WriteLine("Eleven"))
                .CaseOf(10).Accomplish(() => WriteLine("Twelve"))
                .CaseOf(1033).Accomplish()
                .ChangeOverToDefault.Accomplish(() => WriteLine("Default"));

            _switch.GetValuesAsTuple();

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
