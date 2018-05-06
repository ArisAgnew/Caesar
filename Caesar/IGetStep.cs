namespace Caesar
{
    public interface IGetStep<THIS> where THIS : IGetStep<THIS>
    {
        TOutput Get<TOutput>(Function<THIS, TOutput> function);
        TOutput Get<TOutput>(Supplier<Function<THIS, TOutput>> functionSupplier);
        TOutput Log<TOutput>(TOutput value);
    }
}
