using System;

namespace Caesar
{
    public interface IGetStep<THIS>
    {
        TOutput Get<TOutput>(Func<THIS, TOutput> function);
        TOutput Get<TOutput>(Action<Func<THIS, TOutput>> functionSupplier);
    }
}
