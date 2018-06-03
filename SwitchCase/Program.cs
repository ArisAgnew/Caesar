using System;
using static System.Console;

namespace SwitchCase
{
    class Program
    {
        static void Main(string[] args)
        {
            int j = 10;

            Switch<int>.Of(j)
                .Case.Of(1).Accomplish(() => WriteLine("One"), false)
                .Case.Of(2).Accomplish(() => WriteLine("Two"), false)
                .Default.Accomplish(() => WriteLine("Default"), false)
                .BuildUp();
        }
    }
}
