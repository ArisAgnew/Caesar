using Caesar.FactoryAssembly;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caesar.AlternativeStuff
{
    public interface IOption<T>
    {        
        bool HasValue { get; }        
        
        void ForValuePresented(Action<T> action);
        
        IOption<T> Where(Predicate<T> predicate);
        
        IOption<TOut> Select<TOut>(Func<T, TOut> select);
        
        IOption<IOption<TOut>> SelectMany<TOut>(Func<T, IOption<TOut>> select);

        T Get();
        T GetCustomized(Func<T, T> customized);
        V GetCustomized<V>(Func<T, V> funcCustom);

        (T, V) GetTupleCustomized1<V>(Func<T, V> funcTupleCustom);
        (T, (V, W)) GetTupleCustomized2<V, W>(TupleDelegate<T, V, W> funcTupleCustom);
        (T, (V, W, X)) GetTupleCustomized3<V, W, X>(TupleDelegate<T, V, W, X> funcTupleCustom);
        (T, (V, W, X, Y)) GetTupleCustomized4<V, W, X, Y>(TupleDelegate<T, V, W, X, Y> funcTupleCustom);
        (T, (V, W, X, Y, Z)) GetTupleCustomized5<V, W, X, Y, Z>(TupleDelegate<T, V, W, X, Y, Z> funcTupleCustom);

        T OrElse(T other);        
        T OrElseGet(Func<T> getOther);

        (T, V) OrElseGetTupleCustomized1<V>(Func<T, V> funcElseCustom);
        (T, (V, W)) OrElseGetTupleCustomized2<V, W>(TupleDelegate<T, V, W> funcTupleCustom);
        (T, (V, W, X)) OrElseGetTupleCustomized3<V, W, X>(TupleDelegate<T, V, W, X> funcTupleCustom);
        (T, (V, W, X, Y)) OrElseGetTupleCustomized4<V, W, X, Y>(TupleDelegate<T, V, W, X, Y> funcTupleCustom);
        (T, (V, W, X, Y, Z)) OrElseGetTupleCustomized5<V, W, X, Y, Z>(TupleDelegate<T, V, W, X, Y, Z> funcTupleCustom);

        T OrElseThrow<E>(Func<E> exceptionSupplier) where E : Exception;
    }
}
