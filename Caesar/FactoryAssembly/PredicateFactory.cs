using System;

namespace Caesar.FactoryAssembly
{
    public static class PredicateFactory
    {
        /// <summary>
        /// There is boolean operation the short-circuiting 'AND' between two predicates.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="next"></param>
        /// <returns>Composed predicate</returns>
        public static Predicate<T> And<T>(this Predicate<T> first, Predicate<T> next) =>
            (T type) => (bool) first?.Invoke(type) && (bool) next?.Invoke(type);

        /// <summary>
        /// There is boolean operation the short-circuiting 'OR' between two predicates.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="next"></param>
        /// <returns>Composed predicate</returns>
        public static Predicate<T> Or<T>(this Predicate<T> first, Predicate<T> next) =>
            (T type) => (bool) first?.Invoke(type) || (bool) next?.Invoke(type);

        /// <summary>
        /// There is bool inversion of regular inward predicate's result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns>Inversion/negation of this Predicate</returns>
        public static Predicate<T> Not<T>(this Predicate<T> predicate) =>
            (T type) => (bool) !predicate?.Invoke(type);

        /// <summary>
        /// Determines whether the specified object is equal to the current object, having a result as Predicate<>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">
        /// the object reference with which to compare for equality, that may be null.
        /// </param>
        /// <returns>Equality of two objects</returns>
        public static Predicate<T> IsEqual<T>(object target) => 
            (T type) => (bool) target?.Equals(type);
    }
}
