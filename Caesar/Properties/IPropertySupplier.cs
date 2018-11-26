using System;
using System.Collections.Generic;
using System.Text;

namespace Caesar.Properties
{
    interface IPropertySupplier<T>
    {
        string GetPropertyValue { get; }
        string GetPropertyName { get; }
    }
}
