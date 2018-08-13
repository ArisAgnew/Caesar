﻿using System;
using System.Collections.Immutable;
using System.Reflection;
using static System.Console;

namespace SwitchCase
{
    public enum Colour { Red, Green, Blue }

    class Program
    {
        static void Main(string[] args)
        {
            /*ushort? j = 10;

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

            Colour? colour = Colour.Blue;

            Switch<Colour?>.OfNullable(colour)
                .CaseOf(Colour.Blue).Accomplish(() => WriteLine(nameof(Colour.Blue)), true)
                .CaseOf(Colour.Green).Accomplish(() => WriteLine(nameof(Colour.Green)), false)
                .CaseOf(Colour.Red).Accomplish(() => WriteLine(nameof(Colour.Red)))
                .ChangeOverToDefault.Accomplish(() => WriteLine("Neither of them"));*/

            string str = ""; //resolve an issue of reading the object reference types 06/15/2018

            Switch<String>.OfNullable(str)
                .CaseOf("I Am").Accomplish(() => WriteLine("=> I Am"))
                .CaseOf("").Accomplish(() => WriteLine("=> Empty"))
                .ChangeOverToDefault.Accomplish(() => WriteLine("EMPTY"));

            Switch<ushort?> _test_ = 13;
            _test_
                .CaseOf(23).Accomplish(() => WriteLine("twenty three"))
                .CaseOf(13).Accomplish(u_short => WriteLine(u_short))
                .ChangeOverToDefault.Accomplish(de_fault => WriteLine($"Default: {de_fault}"));

            /*Switch<ushort?> w = j; //implicit operator Switch<V>(V value)

            {
                Object a = null;
                Object b = "not null";

                WriteLine((a ?? "null :(").ToString());
                WriteLine((b ?? default).ToString());
            }

            Switch<ushort?> _test_ = 13;
            _test_
                .CaseOf(23).Accomplish(() => WriteLine("twenty three"))
                .CaseOf(83).Accomplish(u_short => WriteLine(u_short))
                .ChangeOverToDefault.Accomplish(de_fault => WriteLine($"Default: {de_fault}"));*/

            /*Switch<String>.OfNullable(str)
                .CaseOf("I Am").Accomplish(() => WriteLine("=> I Am"))
                .CaseOf("the way").Accomplish(() => WriteLine("=> the way"))
                .ChangeOverToDefault.Accomplish(() => {
                    //ImmutableList.Create(10, 100, 1000).ForEach(i => WriteLine(i));
                    return "10, 100, 1000";
                }).Depict();*/

            ReadKey();
        }
    }

    public static class U
    {
        public static void Depict<T>(this T d) => WriteLine(d);
    }
}
