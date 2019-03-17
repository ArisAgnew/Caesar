using System;

namespace Caesar.FactoryAssembly
{
    //try to implement the same stuff by no using extention technique
    public static class FunctionFactory
    {
        /// <summary>
        /// This method combines a regular function in company with another one regular function.
        /// The <paramref name="before"/> function is applied first, then
        /// The <paramref name="after"/> function is applied second
        /// </summary>
        /// <typeparam name="In"></typeparam>
        /// <typeparam name="Mid"></typeparam>
        /// <typeparam name="Out"></typeparam>
        /// <param name="after"></param>
        /// <param name="before"></param>
        /// <returns></returns>
        public static Func<Out, Mid> BackwardCompose<In, Mid, Out>
            (this Func<In, Mid> after, Func<Out, In> before) =>
            (Out input) => after.Invoke(before.Invoke(input));

        /// <summary>
        /// This method combines a regular function in company with another one regular function.
        /// The <paramref name="before"/> function is applied first, then
        /// The <paramref name="after"/> function is applied second
        /// </summary>
        /// <typeparam name="In"></typeparam>
        /// <typeparam name="Mid"></typeparam>
        /// <typeparam name="Out"></typeparam>
        /// <param name="before"></param>
        /// <param name="after"></param>
        /// <returns></returns>
        public static Func<In, Out> ForwardCompose<In, Mid, Out>
            (this Func<In, Mid> before, Func<Mid, Out> after) =>
            (In input) => after.Invoke(before.Invoke(input));

        /// <summary>
        /// This method that always returns its input parameter/argument
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Func<T, T> MirrorArgument<T>() => (T arg) => arg;
    }
}
