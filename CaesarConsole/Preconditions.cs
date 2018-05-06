using System;
using System.Collections.Generic;
using System.Text;

namespace Caesar
{
    public static class Preconditions
    {
        internal static T RequireNonNull<T>(this T input, string message = default)
        {
            try
            {
                if (!input.Equals(null))
                    return input;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException($"{e.Message}, {message}");
            }
            return default; //return NaN
        }

        internal static T RequireNonNull<T>(this T input, Func<T, String, T> function, string message = default) =>
            function(input, message);

        internal static (T, T) RequireNonNullAsWellAs<T>(this T input, T obj) =>
            (input.RequireNonNull("First operand is null"), obj.RequireNonNull("Second operand is null"));

        internal static (T, T) RequireNonNullAsWellAs<T>(this T input, T obj, Func<T, String, T> function) =>
            (input.RequireNonNull(function, "First operand is null"), obj.RequireNonNull(function, "Second operand is null"));
    }
}
