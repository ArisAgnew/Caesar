using System;
using System.Linq;
using Caesar.AlternativeStuff;

using static Caesar.StoryWriter;
using static System.Reflection.BindingFlags;

namespace Caesar
{
    public class GetStep<T> : IGetStep<T> where T : GetStep<T>
    {
        public R Get<R>(Func<T, R> function)
        {
            (StepFunction<T, R> stepFunction, Func<T, R> _function) = ToGet(function?.ToString(), function);

            bool IsPropertyEstablished = typeof(StepFunction<T, R>)
                    .GetProperties(Public | Instance)
                    .All(p => p.GetValue(stepFunction) != default);

            if (IsPropertyEstablished)
            {
                return stepFunction.RequireNonNull($"{nameof(stepFunction)} is not defined").Apply(this as T);
            }
            else return default;                       
        }

        public R Get<R>((dynamic, Func<T, R>) functionTuple)
        {
            var (_, function) = functionTuple.RequireNonNull($"{nameof(functionTuple)} is not defined");
            return Get(function);
        }

        public R Get<R>(in Func<T, R> function) => Get(function);

        public R Get<R>(Func<Func<T, R>> functionSupplier) =>
            Get(functionSupplier.RequireNonNull($"{nameof(functionSupplier)} was not defined")?.Invoke());
    }    
}
