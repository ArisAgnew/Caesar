using System;

namespace Caesar.AlternativeStuff
{
    public static class Preconditions
    {
        internal static T RequireNonNull<T>(this T input, string message = default)
        {
            try
            {
                if (!input.Equals(null) || !input.Equals(default))
                    return input;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException($"{e.Message}, {message}");
            }
            return default; //return NaN
        }

        internal static T RequireNonNull<T>(this T input, 
                                            Func<T, String, T> function,
                                            string message = default) => function.RequireNonNull(message)(input, message);

        internal static (T, T) RequireNonNullAsWellAs<T>(this T input,
                                                        T obj,
                                                        in string firstOperandMessage = "First operand is null",
                                                        in string secondOperandMessage = "Second operand is null") =>
            (input.RequireNonNull(firstOperandMessage), obj.RequireNonNull(secondOperandMessage));

        internal static (T, T) RequireNonNullAsWellAs<T>(this T input,
                                                        T obj,
                                                        Func<T, String, T> function,
                                                        in string firstOperandMessage = "First operand is null",
                                                        in string secondOperandMessage = "Second operand is null") =>
            (input.RequireNonNull(function, firstOperandMessage), obj.RequireNonNull(function, secondOperandMessage));

        //TODO: implement method {RequireNonNull} that takes up param string[] as a second parameter
    }
}
