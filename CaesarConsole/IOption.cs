using System;
using System.Collections.Generic;
using System.Text;

namespace Caesar.AlternativeStuff
{
    public interface IOption<T>
    {
        /// <summary>
        /// 
        /// </summary>
        bool HasValue { get; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        void ForValuePresented(Action<T> action);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IOption<T> Where(Predicate<T> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="select"></param>
        /// <returns></returns>
        IOption<TOut> Select<TOut>(Func<T, TOut> select);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="select"></param>
        /// <returns></returns>
        IOption<IOption<TOut>> SelectMany<TOut>(Func<T, IOption<TOut>> select);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        T OrElse(T other);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        T OrElseGet(Func<T> other);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="exceptionSupplier"></param>
        /// <returns></returns>
        T OrElseThrow<E>(Func<E> exceptionSupplier) where E : Exception;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Get();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customized"></param>
        /// <returns></returns>
        T GetCustomized(Func<T, T> customized);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="customized"></param>
        /// <returns></returns>
        U GetCustomized<U>(Func<T, U> customized);
    }
}
