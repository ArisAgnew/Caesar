using Caesar.AlternativeStuff;

namespace Caesar
{
    public class GetStep<T> : IGetStep<T> where T : GetStep<T>
    {
        public TOutput Get<TOutput>(Function<T, TOutput> function) => 
            Log(function.RequireNonNull("Function is not defined").Invoke((T) this)); //why DescribedFunction needs to check out

        public TOutput Get<TOutput>(Supplier<Function<T, TOutput>> functionSupplier) =>
            Get(functionSupplier.RequireNonNull("Supplier is not defined").Invoke());        

        public TOutput Log<TOutput>(TOutput value) => value.RequireNonNull();
    }    
}
