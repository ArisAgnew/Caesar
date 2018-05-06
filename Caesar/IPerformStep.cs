namespace Caesar
{
    public interface IPerformStep<THIS> where THIS : IPerformStep<THIS>
    {
        THIS Perform(Consumer<THIS> action);
        THIS Perform(Supplier<Consumer<THIS>> actionSupplier);
    }
}
