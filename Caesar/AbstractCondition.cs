using System;
using Caesar.AlternativeStuff;
using JetBrains.Annotations;

namespace Caesar
{
    internal abstract class AbstractCondition<T>
    {
        internal virtual Predicate<T> And(Predicate<T> another) => default;
        internal virtual Predicate<T> Or(Predicate<T> another) => default;
        internal virtual Predicate<T> Not(Predicate<T> another) => default;

        internal abstract bool Test(T t);
    }

    internal class Condition<T> : AbstractCondition<T>
    {
        [NotNull]
        public Predicate<T> Predicate { get; set; }

        public override string ToString() => base.ToString(); //todo

        internal override bool Test(T t) => Predicate.RequireNonNull($"{nameof(t)} is not defined")(t);
    }
}
