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
    class Run
    {
        static void Main()
        {            
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
