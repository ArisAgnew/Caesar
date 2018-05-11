using System;

namespace Caesar.AlternativeStuff
{
    public interface ITry<T>
    {
        bool IsEmpty { get; }
        bool IsSuccess { get; }
        bool IsFailure { get; }
        /*ITry<T> Of(Func<T> actionToTry);
		ITry<T> Run(Action actionToTry);

		ITry<T> Success(T value);
		ITry<T> Success(Func<T> getValue);
        ITry<T> Failure(Exception exception);
        ITry<T> Failure(Func<Exception> getException);

        ITry<T> Narrow(ITry<T> @try);

		ITry<T> ForwardCompose(Action<T> actionToTry);
		ITry<T> ForwardCompose(Action actionToTry);

		ITry<E> Failed<E>() where E : Exception;

		ITry<T> Where(Predicate<T> predicate);
		ITry<U> Select<U>(Func<T, U> select);
		ITry<ITry<U>> SelectMany<U>(Func<T, ITry<U>> select);

		T Get();

		ITry<T> SuccessCase(Action<T> action);
		ITry<T> FailureCase<E>(Action<E> action) where E : Exception;

		ITry<T> OrElse(ITry<T> other);
		ITry<T> OrElse(Func<ITry<T>> other);
		T OrElseGet(Func<T> other);
		T GetOrElseGet<E>(Func<E, T> func) where E : Exception;
		void OrElseRun<E>(Action<E> action) where E : Exception;
		T GetOrElseThrow<E, X>(Func<E, X> exceptionProvider) where E : Exception where X : Exception;

		ITry<T> Peek(Action<T> action);
		ITry<T> Recover<E>(Func<E, T> func) where E : Exception;
		ITry<T> RecoverWith<E>(Func<E, ITry<T>> func) where E : Exception;

		U Transform<U>(Func<ITry<T>, U> func);*/
    }
}
