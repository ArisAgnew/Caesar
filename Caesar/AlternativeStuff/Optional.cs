using Caesar.FactoryAssembly;
using System;

namespace Caesar.AlternativeStuff
{
    public sealed class Optional<T> : IOption<T>
    {
        private static readonly Optional<T> EMPTY = new Optional<T>();
        private readonly T value;

        private Optional() => value = default;
        private Optional(T arg) => value = arg.RequireNonNull("Value should be presented");

        public static Optional<T> Empty() => EMPTY;
        public static Optional<T> Of(T arg) => new Optional<T>(arg);
		public static Optional<T> OfNullable(T arg) => arg != null ? Of(arg) : Empty();
		public static Optional<T> OfNullable(Func<T> outputArg) => outputArg != null ? Of(outputArg()) : Empty();

		public bool HasValue => value != null;

        public void ForValuePresented(Action<T> action) => action.RequireNonNull()(value);

        public IOption<T> Where(Predicate<T> predicate) => HasValue 
            ? predicate.RequireNonNull()(value) ? this : Empty() : this;

        public IOption<TOut> Select<TOut>(Func<T, TOut> select) => HasValue 
            ? Optional<TOut>.OfNullable(select.RequireNonNull()(value)) 
            : Optional<TOut>.Empty();

        public IOption<IOption<TOut>> SelectMany<TOut>(Func<T, IOption<TOut>> select) => HasValue 
			? Optional<IOption<TOut>>.OfNullable(select.RequireNonNull()(value)) 
			: Optional<IOption<TOut>>.Empty();

        #region The set of 'Gets' different overload methods
        public T Get() => value;
        public T GetCustomized(Func<T, T> funcCustom) => funcCustom.Invoke(value);
        public V GetCustomized<V>(Func<T, V> funcCustom) => funcCustom.RequireNonNull()(value);

        public (T, V) GetTupleCustomized<V>(Func<T, V> funcTupleCustom) => 
            (Get(), funcTupleCustom.RequireNonNull()(value));

        public (T, (V, W)) GetTupleCustomized2<V, W>(TupleDelegate<T, V, W> funcTupleCustom) =>
            (Get(), funcTupleCustom.RequireNonNull()(value));

        public (T, (V, W, X)) GetTupleCustomized3<V, W, X>(TupleDelegate<T, V, W, X> funcTupleCustom) => 
            (Get(), funcTupleCustom.RequireNonNull()(value));

        public (T, (V, W, X, Y)) GetTupleCustomized4<V, W, X, Y>(TupleDelegate<T, V, W, X, Y> funcTupleCustom) => 
            (Get(), funcTupleCustom.RequireNonNull()(value));

        public (T, (V, W, X, Y, Z)) GetTupleCustomized5<V, W, X, Y, Z>(TupleDelegate<T, V, W, X, Y, Z> funcTupleCustom) => 
            (Get(), funcTupleCustom.RequireNonNull()(value));
        #endregion

        #region The set of 'OrElseGets' different overload methods
        public T OrElse(T other) => HasValue ? value : other.RequireNonNull();
        public T OrElseGet(Func<T> getOther) => HasValue ? value : getOther.RequireNonNull()();
        public T OrElseGetCustomized(Func<T, T> funcElseCustom) => HasValue ? value : funcElseCustom.RequireNonNull()(value);
        
        public (T, V) OrElseGetTupleCustomized<V>(Func<T, V> funcElseCustom) => 
            HasValue ? (value, default(V)) : (default(T), funcElseCustom.RequireNonNull()(value));

        public (T, (V, W)) OrElseGetTupleCustomized2<V, W>(TupleDelegate<T, V, W> funcTupleCustom) =>
            HasValue ? (value, (default(V), default(W))) : (default(T), funcTupleCustom.RequireNonNull()(value));

        public (T, (V, W, X)) OrElseGetTupleCustomized3<V, W, X>(TupleDelegate<T, V, W, X> funcTupleCustom) =>
            HasValue ? (value, (default(V), default(W), default(X))) : (default(T), funcTupleCustom.RequireNonNull()(value));

        public (T, (V, W, X, Y)) OrElseGetTupleCustomized4<V, W, X, Y>(TupleDelegate<T, V, W, X, Y> funcTupleCustom) =>
            HasValue ? (value, (default(V), default(W), default(X), default(Y))) : (default(T), funcTupleCustom.RequireNonNull()(value));

        public (T, (V, W, X, Y, Z)) OrElseGetTupleCustomized5<V, W, X, Y, Z>(TupleDelegate<T, V, W, X, Y, Z> funcTupleCustom) =>
            HasValue ? (value, (default(V), default(W), default(X), default(Y), default(Z))) : (default(T), funcTupleCustom.RequireNonNull()(value));

        public T OrElseThrow<E>(Func<E> exceptionSupplier) where E : Exception => HasValue ? value : throw exceptionSupplier();
        #endregion

        public static explicit operator T(Optional<T> optional) => optional.RequireNonNull().Get();
        public static implicit operator Optional<T>(T optional) => OfNullable(optional);

        public override bool Equals(object obj)
        {
            if (obj is Optional<T>) return true;
            if (!(obj is Optional<T>)) return false;
            return Equals(value, (obj as Optional<T>).value);
        }

        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => HasValue ? $"Optional has <{value}>" : $"Optional has no any value: <{value}>";
    }    
}
