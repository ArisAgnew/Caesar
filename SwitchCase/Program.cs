using System;

namespace SwitchCase
{
    class Program
    {
        static void Main(string[] args)
        {
            Switch<int>.Of(5)
                .Case.Of().Then()
                .Case.Of().Then()
                .Case.Of().When().Then()
                .Case.Of().When().Then()
                .Case.Of().When().Then()
                .Default.Then();
        }
    }
}
