using System;

namespace Caesar
{
    public interface IPerformActionStep<THIS>
    {
        THIS Perform(Action<THIS> action);
        THIS Perform(Func<Action<THIS>> actionSupplier);
    }
}
