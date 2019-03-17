using Caesar.AlternativeStuff;

namespace Caesar
{
    public abstract class GetSupplier<T, R, THIS> where THIS : GetSupplier<T, R, THIS>
    {
        private Function<T, R> function;
        private protected virtual Function<T, R> Function
        {
            get => function;
            set => function = value;
        }

        public override string ToString()
        {
            return Optional<Function<T, R>>.OfNullable(function)
                .Select(func => func.ToString())
                .OrElse(string.Empty);
        }
    }
}
