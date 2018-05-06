using Caesar.AlternativeStuff;
using System;
using System.Collections.Generic;
using System.Linq;

using static System.Console;

namespace Caesar
{
    class Program
    {
        private protected static K GetKey<K, V>(IDictionary<K, V> dictionary, V valueOf) => dictionary
                .Where(pair => Equals(pair.Value, valueOf))
                .Select(pair => pair.Key)
                .SingleOrDefault();

        public static void Opt<K, V>(IDictionary<K, V> dictionary, V valueOf)
        {
            Optional<IEnumerable<K>>.OfNullable(dictionary
                .Where(pair => Equals(pair.Value, valueOf))
                .Select(pair => pair.Key)).OrElse(default);
        }
        
        static void Main(string[] args)
        {
            IReadOnlyDictionary<int, string> rdnOnlyMap = new Dictionary<int, string>()
            {
                { 1, "One" },
                { 2, "Two" },
                { 3, "Three" },
                { 4, "Four" },
                { 5, "Five" },
            };
                        
            WriteLine(GetKey((Dictionary<int, string>)rdnOnlyMap, "Four1").RequireNonNull());
            ReadKey();
        }
    }

    partial class Probe
    {
        public void CheckRequireNonNull()
        {
            string str1 = nameof(str1);
            string str2 = nameof(str2);

            string str3 = nameof(str3);

            var first = str1.RequireNonNullAsWellAs(str3).Item1;
            var second = str1.RequireNonNullAsWellAs(str2).Item2;

            var strfunc = str3.RequireNonNull(
                (input, message) => {
                    try
                    {
                        if (!input.Equals(null))
                            return input;
                    }
                    catch (NullReferenceException)
                    {
                        throw new NullReferenceException(message);
                    }
                    return default;
                },
                "operand is null");

            WriteLine($"{first} and {second}");
            WriteLine(strfunc);
            ReadLine();
        }        

        [Obsolete]
        public void AsyncFunction()
        {
            Func<int, int, int> f = (a, b) => a + b;
            int? result = null;
            IAsyncResult asyncResult = f.BeginInvoke(5, 3, null, null);
            if (asyncResult.IsCompleted)
            {
                result = f.EndInvoke(asyncResult);
            }

            WriteLine($"Result: {result}");
            ReadLine();
        }
    }

    partial class Probe : IDisposable
    {
        public void Dispose() { }
    }
}
