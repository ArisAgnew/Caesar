using System;
using Caesar.AlternativeStuff;

namespace Caesar.FactoryAssembly
{
    public static class BiFunctionFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1Input"></typeparam>
        /// <typeparam name="T2Input"></typeparam>
        /// <typeparam name="TIntermediate"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="after"></param>
        /// <param name="before"></param>
        /// <returns></returns>
        public static Func<T1Input, T2Input, TOutput> BackwardCompose<T1Input, T2Input, TIntermediate, TOutput>
            (this Func<TIntermediate, TOutput> after, Func<T1Input, T2Input, TIntermediate> before) =>
            (T1Input t1, T2Input t2) => after.RequireNonNull().Invoke(before.RequireNonNull().Invoke(t1, t2));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1Input"></typeparam>
        /// <typeparam name="T2Input"></typeparam>
        /// <typeparam name="TIntermediate"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="before"></param>
        /// <param name="after"></param>
        /// <returns></returns>
        public static Func<T1Input, T2Input, TOutput> ForwardCompose<T1Input, T2Input, TIntermediate, TOutput>
            (this Func<T1Input, T2Input, TIntermediate> before, Func<TIntermediate, TOutput> after) =>
            (T1Input t1, T2Input t2) => after.BackwardCompose(before).Invoke(t1, t2);
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1Input"></typeparam>
        /// <typeparam name="T2Input"></typeparam>
        /// <typeparam name="TIntermediate"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="after"></param>
        /// <param name="before"></param>
        /// <returns></returns>
        public static Func<T1Input, Func<T2Input, TOutput>> BackwardComposeCurried<T1Input, T2Input, TIntermediate, TOutput>
            (this Func<TIntermediate, TOutput> after, Func<T1Input, T2Input, TIntermediate> before) =>
            (T1Input t1) => (T2Input t2) => after.Invoke(before.Invoke(t1, t2));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1Input"></typeparam>
        /// <typeparam name="T2Input"></typeparam>
        /// <typeparam name="TIntermediate"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="before"></param>
        /// <param name="after"></param>
        /// <returns></returns>
        public static Func<T1Input, Func<T2Input, TOutput>> ForwardComposeCurried<T1Input, T2Input, TIntermediate, TOutput>
            (this Func<T1Input, T2Input, TIntermediate> before, Func<TIntermediate, TOutput> after) =>
            (T1Input t1) => (T2Input t2) => after.BackwardComposeCurried(before).Invoke(t1).Invoke(t2);
    }
}
