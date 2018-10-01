using Caesar.AlternativeStuff;
using System;
using System.Collections.Generic;
using System.Text;

using static System.Console;
using static System.Boolean;
using System.Reflection;
using System.Linq;

namespace Caesar
{
    public class Check : PerformActionStep<Check>
    {
        public Check() { }         
    }

    public class Some : PerformActionStep<Some>
    {
        public Some() { }
    }

    class Run
    {
        static void Main()
        {
            PerformActionStep<Check> per = new PerformActionStep<Check>();
            per.Perform(StoryWriter.Action<Check>("Some Desc", (check) => { WriteLine("GOT IT!"); }));
            
            ReadKey();

            StepAction<int> stepAction = new StepAction<int>
            {
                //stepAction.Description = "sdsadsd";
                Action = (int it) => { }
            };

            var a = typeof(StepAction<int>)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)[1]
                    .GetValue(stepAction) != default;

            var c = typeof(StepAction<int>)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .All(p => p.GetValue(stepAction) != default);

            WriteLine(a);
            WriteLine(c);
            ReadKey();
            /*string[] strs = new string[] { "one", "two", "three", "four", "five" };
            var (_, (a, b, c)) = Optional<string[]>.OfNullable(strs).Select(delegate (string[] array)
            {
                return array.Where(each => each.Length > 3);
            }).GetTupleCustomized(arr =>
            (
                arr.ToArray()[0],
                arr.ToArray()[1],
                arr.ToArray()[2]
            )); //var (_, (a, b, c))
            WriteLine($"{a}, {b}, {c}");
            WriteLine();
            
            Optional<string[]>.OfNullable(strs).Select(delegate (string[] array) {
                return array.Where(arr => arr.Length > 3);
            }).ForValuePresented(s => s.ToList().ForEach(s1 => WriteLine(s1)));

            var (l, (x, y)) = Optional<string[]>.OfNullable(strs).Select(delegate (string[] array) {
                return array.Where(arr => arr.Length > 7);
            }).OrElseGetTupleCustomized(s => (s.Count(), s.ToList().Last()));
            WriteLine($"{l}, | {x}, | {y}");
            ReadLine();*/

            //Try.Run(() => UInt64.MaxValue)
            //IMy instance = (IMy)Activator.CreateInstance(typeof(IMy).GetProperties().GetType());

            //foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
            //{
            //    if (t.GetInterface(nameof(IMy)) != null)
            //    {
            //        IMy instance = Activator.CreateInstance(t) as IMy;
            //        WriteLine($"IsEmpty => {instance.IsEmpty}");
            //        WriteLine("=====");
            //        WriteLine($"IsSuccess => {instance.IsSuccess}");
            //        WriteLine("=====");
            //        WriteLine($"IsFailure => {instance.IsFailure}");
            //    }
            //}

            //foreach (var instance1 in Assembly.GetCallingAssembly()
            //    .GetTypes()
            //    .Where(t => t.IsClass && t.GetInterface(nameof(IMy)) != null)
            //    .Select(Activator.CreateInstance)
            //    .OfType<IMy>())
            //{
            //    WriteLine(instance1.IsEmpty);
            //}
            var pros = new Cons();

            var i = Assembly.GetCallingAssembly()
                ?.GetTypes()
                .Where(t => t.IsClass && t.GetInterface(nameof(IMy)) != null)
                .Select(Activator.CreateInstance)
                .OfType<IMy>()
                .FirstOrDefault();

            WriteLine(i.IsFailure);

            //WriteLine(instance.IsEmpty);
            //WriteLine(instance.IsSuccess);
            //WriteLine(instance.IsFailure);
            Read();
        }
    }

    interface IMy
    {
        bool IsEmpty { get; }
        bool IsSuccess { get; }
        bool IsFailure { get; }
    }

    sealed class Pros : IMy
    {
        public Pros() { }

        public bool IsEmpty => Parse(FalseString);
        public bool IsSuccess => Parse(TrueString);
        public bool IsFailure => Parse(FalseString);
    }

    sealed class Cons : IMy
    {
        public Cons() { }

        public bool IsEmpty => Parse(TrueString);
        public bool IsSuccess => Parse(FalseString);
        public bool IsFailure => Parse(TrueString);
    }
}
