using System;

namespace SwitchCase
{
    class Program
    {
        static void Main(string[] args)
        {
            int j = 10;
            /*Switch<int>.Of(j)
                .Case.Of().Then()
                .Case.Of().Then()
                .Case.Of().When().Then()
                .Case.Of().When().Then()
                .Case.Of().When().Then()
                .Default.Then();*/

            Switch<int>.Of(j)
                .Case.Of(1).Accomplish(delegate() { return default }, false)
                .Case.Of(2).Accomplish(delegate() { return default }, false)
                .Default.Accomplish(delegate() { }, false)
                .Build();
        }
    }
}
