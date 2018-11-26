using System;
using Caesar.AlternativeStuff;

namespace Caesar.Properties
{
    public abstract class PropertySupplier<T> : IPropertySupplier<T>, ISupplier<T>
    {
        public Action<string> Action { get; set; }
        public Func<T> Supplier { get; set; }
        
        public string GetPropertyValue
        {
            get
            {
                var property = GetPropertyName;
                return default; //todo 11/26/2018
            }
        }

        public abstract string GetPropertyName { get; }

        protected internal Optional<string> ReturnOptionalFromEnvironment() => GetPropertyValue;

        public void Accept(in string value)
        {
            //todo 11/26/2018
            Action?.Invoke(value);
        }

        public T Get() => Supplier.RequireNonNull($"{nameof(Supplier)} is not defined")();
    }
}
