using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace Caesar
{
    public class StepFunction<T, R>
    {
        private readonly SortedSet<dynamic> ignored = new SortedSet<dynamic>(); //todo

        public void Deconstruct(out string description,
                                out Func<T, R> function, 
                                out List<Func<dynamic, dynamic>> functions, 
                                out bool isComplex)
        {
            description = Description;
            function = Function;
            functions = Functions;
            isComplex = IsComplex;
        }

        [NotNull]
        public string Description { get; set; }

        [NotNull]
        public Func<T, R> Function { get; set; }

        [NotNull]
        public List<Func<dynamic, dynamic>> Functions { private get; set; }

        [NotNull]
        public bool IsComplex { get; private set; }

        public R Apply(T t) => Function.Invoke(t); //todo
    }
}
