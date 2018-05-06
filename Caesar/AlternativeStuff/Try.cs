using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Dynamic;

using static System.Boolean;

namespace Caesar.AlternativeStuff
{
    public abstract class TryAbstract<T> : ITry<T>
    {
        private protected virtual bool IsEmpty { get; }
        private protected virtual bool IsSuccess { get; }
        private protected virtual bool IsFailure { get; }

        private protected virtual Exception GetCause() => null;
    }

    public sealed class Try<T> : TryAbstract<T>
    {
        //public static ITry<E> Failed<E>() where E : Exception //bad implementation it needs to think about how to improve it
        //{
        //    if (TryAbstract.IsEmpty)
        //    {
        //        return new Success<E> { SuccessValue = (E)GetCause() };
        //    }
        //    else
        //    {
        //        return new Failure<E> { FailureCause = new NotSupportedException("Success |>> Failed") };
        //    }
        //}

        public ITry<T> Failure(Exception exception) => new Failure<T> { FailureCause = exception.RequireNonNull() };

        public ITry<T> Failure(Func<Exception> getException) => new Failure<T> { FailureCause = getException.RequireNonNull()() };

        public ITry<T> FailureCase<E>(Action<E> action) where E : Exception
        {
            throw new NotImplementedException();
        }

        public ITry<T> ForwardCompose(Action<T> actionToTry)
        {
            throw new NotImplementedException();
        }

        public ITry<T> ForwardCompose(Action actionToTry)
        {
            throw new NotImplementedException();
        }

        public T Get()
        {
            throw new NotImplementedException();
        }

        public T GetOrElseGet<E>(Func<E, T> func) where E : Exception
        {
            throw new NotImplementedException();
        }

        public T GetOrElseThrow<E, X>(Func<E, X> exceptionProvider)
            where E : Exception
            where X : Exception
        {
            throw new NotImplementedException();
        }

        public ITry<T> Narrow(ITry<T> @try)
        {
            throw new NotImplementedException();
        }

        public static ITry<T> Of(Func<T> actionToTry)
        {
            try
            {
                return new Success<T> { SuccessValue = actionToTry.RequireNonNull()() };
            }
            catch (Exception e)
            {
                return new Failure<T> { FailureCause = e }; // check up this properly!
            }
        }

        public ITry<T> OrElse(ITry<T> other)
        {
            throw new NotImplementedException();
        }

        public ITry<T> OrElse(Func<ITry<T>> other)
        {
            throw new NotImplementedException();
        }

        public T OrElseGet(Func<T> other)
        {
            throw new NotImplementedException();
        }

        public void OrElseRun<E>(Action<E> action) where E : Exception
        {
            throw new NotImplementedException();
        }

        public ITry<T> Peek(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public ITry<T> Recover<E>(Func<E, T> func) where E : Exception
        {
            throw new NotImplementedException();
        }

        public ITry<T> RecoverWith<E>(Func<E, ITry<T>> func) where E : Exception
        {
            throw new NotImplementedException();
        }

        public static ITry<T> Run(Action actionToTry)
        {
            try
            {
                actionToTry.RequireNonNull()();
                return new Success<T> { SuccessValue = default };
            }
            catch (Exception e)
            {
                return new Failure<T> { FailureCause = e }; // check up this properly!
            }
        }

        public ITry<U> Select<U>(Func<T, U> select)
        {
            throw new NotImplementedException();
        }

        public ITry<ITry<U>> SelectMany<U>(Func<T, ITry<U>> select)
        {
            throw new NotImplementedException();
        }

        public ITry<T> Success(T value) => new Success<T> { SuccessValue = value.RequireNonNull() };

        public ITry<T> Success(Func<T> getValue) => new Success<T> { SuccessValue = getValue.RequireNonNull()() };

        public ITry<T> SuccessCase(Action<T> action)
        {
            throw null;
        }

        public U Transform<U>(Func<ITry<T>, U> func)
        {
            throw new NotImplementedException();
        }

        public ITry<T> Where(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }        
    }

    /// <summary>
    /// A succeeded Try class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    sealed class Success<T> : TryAbstract<T>, ITry<T>
    {
        public string StringPrefix => "Success";

        public T SuccessValue { get; set; }

        private protected override Exception GetCause() => throw new NotSupportedException($"{nameof(GetCause)} for {StringPrefix}");

        private protected override bool IsEmpty => Parse(FalseString);
        private protected override bool IsSuccess => Parse(TrueString);
        private protected override bool IsFailure => Parse(FalseString);

        public override string ToString() => $"{StringPrefix}({SuccessValue})";
        public override bool Equals(object obj) => obj == this || (obj is Success<T> && Equals(SuccessValue, (obj as Success<T>).SuccessValue));
        public override int GetHashCode() => SuccessValue.GetHashCode();
    }

    /// <summary>
    /// A failed Try class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    sealed class Failure<T> : TryAbstract<T>, ITry<T>
    {
        public string StringPrefix => "Failure";

        public Exception FailureCause { get; set; }

        private protected override Exception GetCause() => FailureCause.GetBaseException();

        private protected override bool IsEmpty => Parse(TrueString);
        private protected override bool IsSuccess => Parse(FalseString);
        private protected override bool IsFailure => Parse(TrueString);

        public override string ToString() => $"{StringPrefix}({FailureCause.GetBaseException()})";
        public override bool Equals(object obj) => obj == this || (obj is Success<T> && Equals(FailureCause, (obj as Failure<T>).FailureCause));
        public override int GetHashCode() => FailureCause.GetHashCode();
    }
}
