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

        (T, V) GetTupleCustomized<V>(Func<T, V> funcTupleCustom);

        T OrElse(T other);        
        T OrElseGet(Func<T> getOther);
        T OrElseGetCustomized(Func<T, T> funcElseCustom);
        V OrElseGetCustomized<V>(Func<T, V> funcElseCustom) where V : T;

        (T, V) OrElseGetTupleCustomized<V>(Func<T, V> funcElseCustom);

        T OrElseThrow<E>(Func<E> exceptionSupplier) where E : Exception;
    }
}
