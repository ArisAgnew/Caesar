using System;

namespace Caesar
{
    public interface IPerformActionStep<T>
    {
        T Perform(Action<T> action);
        T Perform(in Action<T> action);
        T Perform(Func<Action<T>> actionSupplier);
    }
}
