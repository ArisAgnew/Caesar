using System;
using Caesar.AlternativeStuff;

namespace Caesar
{
    public class Supplier<T> : ISupplier<T>
    {
        public Func<T> SupplierProperty { get; set; }

        public T Get() => SupplierProperty.RequireNonNull($"{nameof(SupplierProperty)} is not defined")();
    }
}
