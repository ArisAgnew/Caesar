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

        dynamic GetCustomized(Func<T, dynamic> customized);

        (T, dynamic) GetTupleCustomized(Func<T, dynamic> funcTupleCustom);

        T OrElse(T other);
        
        T OrElseGet(Func<T> getOther);
        
        T OrElseThrow<E>(Func<E> exceptionSupplier) where E : Exception;

        dynamic OrElseGetCustomized(Func<T, dynamic> funcElseCustom);               
    }
}
