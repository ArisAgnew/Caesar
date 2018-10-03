using System;

namespace Caesar.FactoryAssembly
{
    public static class ActionFactory
    {
        /// <summary>
        /// This intermediate operation provides union of both Actions with the same inward parameter types, 
        /// first off fulfilling first action, thereafter next action.
        /// </summary>
        /// <remarks>Corresponding entity in Java is Consumer</remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="next"></param>
        /// <returns>Void</returns>
        public static Action<T> ForwardCompose<T>(this Action<T> first, Action<T> next) => 
            (T type) => 
            {
                first?.Invoke(type);
                next?.Invoke(type);
            };

        /// <summary>
        /// This intermediate operation provides union of both Actions with different inward parameter types, 
        /// first off fulfilling first action, thereafter next action.
        /// </summary>
        /// <remarks>Corresponding entity in Java is BiConsumer</remarks>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="first"></param>
        /// <param name="next"></param>
        /// <returns>Void</returns>
        public static Action<T1, T2> ForwardCompose<T1, T2>(this Action<T1> first, Action<T2> next) =>
            (T1 type1, T2 type2) =>
            {
                first?.Invoke(type1);
                next?.Invoke(type2);
            };
    }
}
