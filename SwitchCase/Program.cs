using System;
using static System.Console;

namespace SwitchCase
{
    public enum Colour { Red, Green, Blue }

    class Program
    {
        static void Main(string[] args)
        {
            ushort? j = 10;

            var _switch = Switch<ushort?>.OfNullable(j);

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
                .CaseOf(10).Accomplish(() => WriteLine("Eleven"))
                .CaseOf(101).Accomplish(() => WriteLine("Twelve"))
                .CaseOf(1033).Accomplish()
                .ChangeOverToDefault.Accomplish(() => WriteLine("Default"));

            //_switch.GetValuesAsTuple();

            Colour? colour = Colour.Blue;

            Switch<Colour?>.OfNullable(colour)
                .CaseOf(Colour.Blue).Accomplish(() => WriteLine(nameof(Colour.Blue)), true)
                .CaseOf(Colour.Green).Accomplish(() => WriteLine(nameof(Colour.Green)), false)
                .CaseOf(Colour.Red).Accomplish(() => WriteLine(nameof(Colour.Red)))
                .ChangeOverToDefault.Accomplish(() => WriteLine("Neither of them"));

            ReadKey();
        }        
    }
}
