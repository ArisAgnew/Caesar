using Caesar.AlternativeStuff;

using System;

namespace Caesar.FactoryAssembly
{
    public static class BiFunctionFactory
    {
        #region BiFunction with reference to regular Function
        /// <summary>
        /// This method combines a regular function in company with bifunction
        /// </summary>
        /// <typeparam name="T1Input"></typeparam>
        /// <typeparam name="T2Input"></typeparam>
        /// <typeparam name="TIntermediate"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="after">a regular function</param>
        /// <param name="before">a bifunction</param>
        /// <returns></returns>
        [Obsolete] public static Func<T1Input, T2Input, TOutput> BackwardCompose<T1Input, T2Input, TIntermediate, TOutput>
            (this Func<TIntermediate, TOutput> after, Func<T1Input, T2Input, TIntermediate> before) =>
            (T1Input t1, T2Input t2) => after.RequireNonNull().Invoke(before.RequireNonNull().Invoke(t1, t2));

        /// <summary>
        /// This method combines a bifunction in company with a regular function
        /// </summary>
        /// <typeparam name="T1Input"></typeparam>
        /// <typeparam name="T2Input"></typeparam>
        /// <typeparam name="TIntermediate"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="before">a bifunction</param>
        /// <param name="after">a regular function</param>
        /// <returns></returns>
        [Obsolete] public static Func<T1Input, T2Input, TOutput> ForwardCompose<T1Input, T2Input, TIntermediate, TOutput>
            (this Func<T1Input, T2Input, TIntermediate> before, Func<TIntermediate, TOutput> after) =>
            (T1Input t1, T2Input t2) => after.BackwardCompose(before).Invoke(t1, t2);
        #endregion

        #region BiFunction with reference to another one BiFunction
        /// <summary>
        /// This method combines a bifunction in company with another one bifunction
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="Mid1"></typeparam>
        /// <typeparam name="Mid2"></typeparam>
        /// <typeparam name="Out"></typeparam>
        /// <param name="after"></param>
        /// <param name="before"></param>
        /// <returns></returns>
        public static Func<Out, Mid2, Mid1> BackwardComposeFull<T1, T2, Mid1, Mid2, Out>
            (this Func<T1, T2, Mid1> after, Func<Out, Mid2, T1> before) =>
            (Out @out, Mid2 mid2) => after.RequireNonNull().Invoke(before.RequireNonNull().Invoke(@out, mid2), default);

        /// <summary>
        /// This method combines a bifunction in company with another one bifunction
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="Mid1"></typeparam>
        /// <typeparam name="Mid2"></typeparam>
        /// <typeparam name="Out"></typeparam>
        /// <param name="before"></param>
        /// <param name="after"></param>
        /// <returns></returns>
        public static Func<T1, T2, Out> ForwardComposeFull<T1, T2, Mid1, Mid2, Out>
            (this Func<T1, T2, Mid1> before, Func<Mid1, Mid2, Out> after) =>
            (T1 t1, T2 t2) => after.RequireNonNull().Invoke(before.RequireNonNull().Invoke(t1, t2), default);
        #endregion
        
        #region Curried composed
        /// <summary>
        /// This is analogy of <seealso cref="BackwardCompose"/>
        /// </summary>
        /// <typeparam name="T1Input"></typeparam>
        /// <typeparam name="T2Input"></typeparam>
        /// <typeparam name="TIntermediate"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="after">a regular function</param>
        /// <param name="before">a bifunction</param>
        /// <returns></returns>
        [Obsolete] public static Func<T1Input, Func<T2Input, TOutput>> BackwardComposeCurried<T1Input, T2Input, TIntermediate, TOutput>
            (this Func<TIntermediate, TOutput> after, Func<T1Input, T2Input, TIntermediate> before) =>
            (T1Input t1) => (T2Input t2) => after.RequireNonNull().Invoke(before.RequireNonNull().Invoke(t1, t2));

        /// <summary>
        /// This is analogy of <seealso cref="ForwardCompose"/>
        /// </summary>
        /// <typeparam name="T1Input"></typeparam>
        /// <typeparam name="T2Input"></typeparam>
        /// <typeparam name="TIntermediate"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="before">a bifunction</param>
        /// <param name="after">a regular function</param>
        /// <returns></returns>
        [Obsolete] public static Func<T1Input, Func<T2Input, TOutput>> ForwardComposeCurried<T1Input, T2Input, TIntermediate, TOutput>
            (this Func<T1Input, T2Input, TIntermediate> before, Func<TIntermediate, TOutput> after) =>
            (T1Input t1) => (T2Input t2) => after.BackwardComposeCurried(before).Invoke(t1).Invoke(t2);

        /// <summary>
        /// This is analogy of <seealso cref="BackwardComposeFull"/>
        /// </summary>
        /// <typeparam name="T1Input"></typeparam>
        /// <typeparam name="T2Input"></typeparam>
        /// <typeparam name="TIntermediate1"></typeparam>
        /// <typeparam name="TIntermediate2"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="after">a bifunction</param>
        /// <param name="before">a bifunction</param>
        /// <returns></returns>
        [Obsolete] public static Func<T1Input, Func<T2Input, TOutput>> BackwardComposeFullCurried<T1Input, T2Input, TIntermediate1, TIntermediate2, TOutput>
            (this Func<TIntermediate1, TIntermediate2, TOutput> after, Func<T1Input, T2Input, TIntermediate1> before) =>
            (T1Input t1) => (T2Input t2) => after.RequireNonNull().Invoke(before.RequireNonNull().Invoke(t1, t2), default);

        /// <summary>
        /// This is analogy of <seealso cref="ForwardComposeFull"/>
        /// </summary>
        /// <typeparam name="T1Input"></typeparam>
        /// <typeparam name="T2Input"></typeparam>
        /// <typeparam name="TIntermediate1"></typeparam>
        /// <typeparam name="TIntermediate2"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="before">a bifunction</param>
        /// <param name="after">a bifunction</param>
        /// <returns></returns>
        [Obsolete] public static Func<T1Input, Func<T2Input, TOutput>> ForwardComposeFullCurried<T1Input, T2Input, TIntermediate1, TIntermediate2, TOutput>
            (this Func<T1Input, T2Input, TIntermediate1> before, Func<TIntermediate1, TIntermediate2, TOutput> after) =>
            (T1Input t1) => (T2Input t2) => after.BackwardComposeFullCurried(before).Invoke(t1).Invoke(t2);
        #endregion
    }
}
