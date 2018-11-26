using System;
using Caesar.AlternativeStuff;

namespace Caesar
{
    public class Supplier<T> : ISupplier<T>
    {
        public Func<T> SupplierFeature { get; set; }

        public T Get() => SupplierFeature.RequireNonNull($"{nameof(SupplierFeature)} is not defined")();
    }
}
