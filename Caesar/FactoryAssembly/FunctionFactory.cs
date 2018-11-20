using System;
using Caesar.AlternativeStuff;

namespace Caesar.FactoryAssembly
{
    //try to implement the same stuff by no using extention technique
    public static class FunctionFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TIntermediate"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="after"></param>
        /// <param name="before"></param>
        /// <returns></returns>
        public static Func<TInput, TOutput> BackwardCompose<TInput, TIntermediate, TOutput>            
            (this Func<TIntermediate, TOutput> after, Func<TInput, TIntermediate> before) => 
            (TInput input) => after.RequireNonNull().Invoke(before.RequireNonNull().Invoke(input));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TIntermediate"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="before"></param>
        /// <param name="after"></param>
        /// <returns></returns>
        public static Func<TInput, TOutput> ForwardCompose<TInput, TIntermediate, TOutput>
            (this Func<TInput, TIntermediate> before, Func<TIntermediate, TOutput> after) => 
            (TInput input) => after.BackwardCompose(before).Invoke(input);
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Func<T, T> MirrorArgument<T>() => (T arg) => arg;
    }
}
