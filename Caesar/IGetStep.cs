using System;

namespace Caesar
{
    public interface IGetStep<THIS>
    {
        TOutput Get<TOutput>(Func<THIS, TOutput> function);
        TOutput Get<TOutput>(in Func<THIS, TOutput> function);
        TOutput Get<TOutput>(Func<Func<THIS, TOutput>> functionSupplier);
    }
}
