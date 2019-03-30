using Caesar.AlternativeStuff;
using Caesar.FactoryAssembly;

using System;

using static System.TimeSpan;

namespace CaesarCore.Conditions
{
    internal class ToGetConditionalHelper
    {
        private static readonly Predicate<dynamic> NON_NULL = d => d != null;
        internal static Predicate<dynamic> AS_IS = d => !default(bool);

        internal static Predicate<T> CheckUpOnCondition<T>(in Predicate<T> condition) =>
            condition.RequireNonNull("Predicate is not defined");

        internal static Func<T, R> CheckUpOnFunction<T, R>(in Func<T, R> func) =>
            func.RequireNonNull("Function is not defined");

        internal static TimeSpan CheckUpOnSleepingTime(in TimeSpan time)
        {
            if (time.CompareTo(Zero) < 0)
            {
                throw new ArgumentException("Sleeping time should be positive");
            }

            return time.RequireNonNull("Sleeping time is not defined");
        }

        internal static TimeSpan CheckUpOnWaitingTime(in TimeSpan time)
        {
            if (time.CompareTo(Zero) < 0)
            {
                throw new ArgumentException("Waiting time for some valuable result should be positive");
            }

            return time.RequireNonNull("Waiting time for some valuable result is not defined");
        }

        internal static Predicate<T> NotNullAnd<T>(in Predicate<T> condition)
        {
            return (NON_NULL as Predicate<T>).And(condition);
        }

        internal static bool ConsoleErrorAndFalse(in Exception e)
        {
            Console.Error.WriteLine(e.RequireNonNull().Message);
            return default;
        }

        internal static Func<SystemException> CheckUpOnExceptionSupplier(Func<SystemException> exceptionSupplier) => 
            exceptionSupplier.RequireNonNull("Exception supplier to be thrown is not defined");

        internal static Func<T, F> FluentWaitFunction<T, F>(Func<T, F> originFunc, 
                                                            TimeSpan? waitingTime, 
                                                            TimeSpan? sleepingTime, 
                                                            Predicate<F> upTo, 
                                                            Func<SystemException> exceptionUpOnTimeOut)
        {
            var _waitingTime = waitingTime ?? FromMilliseconds(default);
            var _sleepingTime = sleepingTime ?? FromMilliseconds(50D);

            F result(T t)
            {
                return default;
            }

            return default;
        }
    }
}
