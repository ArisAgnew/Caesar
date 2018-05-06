﻿using System;

namespace Caesar.AlternativeStuff
{
    public sealed class Optional<T> : IOption<T>
    {
        private static readonly Optional<T> EMPTY = new Optional<T>();
        private readonly T value;

        private Optional() => value = default;
        private Optional(T arg) => value = arg.RequireNonNull("Value should be presented");

        public static Optional<T> Empty() => EMPTY;
        public static Optional<T> Of(T arg) => new Optional<T>(arg) ?? default;
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

        public T Get() => value;
        public T GetCustomized(Func<T, T> customized) => customized.RequireNonNull()(value);
        public U GetCustomized<U>(Func<T, U> customized) => customized.RequireNonNull()(value);

        public T OrElse(T other) => HasValue ? value : other;
        public T OrElseGet(Func<T> other) => HasValue ? value : other();
        public T OrElseThrow<E>(Func<E> exceptionSupplier) where E : Exception => HasValue ? value : throw exceptionSupplier();

        public static explicit operator T(Optional<T> optional) => OfNullable((T)optional).Get();
        public static implicit operator Optional<T>(T optional) => OfNullable(optional);

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (!(obj is Optional<T>)) return false;
            return Equals(value, (obj as Optional<T>).value);
        }

        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => HasValue ? $"Optional has <{value}>" : $"Optional has no any value: <{value}>";
    }
}
