using System;
using Caesar.AlternativeStuff;
using JetBrains.Annotations;

namespace Caesar.Properties
{
    public abstract class PropertySupplier<T> : IPropertySupplier<T>, ISupplier<T>
    {
        [NotNull]
        public Action<string> Action { get; set; }

        [NotNull]
        public Func<T> Supplier { get; set; }
                
        public string GetPropertyValue
        {
            get
            {
                var property = GetPropertyName;
                return default; //todo 11/26/2018
            }
        }

        [NotNull]
        public abstract string GetPropertyName { get; }

        protected internal Optional<string> ReturnOptionalFromEnvironment() => GetPropertyValue;

        public void Accept(in string value)
        {
            //todo 11/26/2018
            Action?.Invoke(value.RequireNonNull($"New value of the {GetPropertyName} should not be blank"));
        }

        public T Get() => Supplier.RequireNonNull($"{nameof(Supplier)} is not defined")();
    }
}
