using System;
using System.Linq;
using System.Reflection;
using Caesar.AlternativeStuff;

namespace Caesar
{
    public class GetStep<T> : IGetStep<T> where T : IGetStep<T>
    {
        public R Get<R>(Func<T, R> function)
        {
            StepFunction<T, R> stepFunction = default;
            IGetStep<T> getStep = this;
            ref var _this = ref getStep;

            bool IsPropertyEstablished = typeof(StepFunction<T, R>)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .All(p => p.GetValue(stepFunction) != default);

            if (IsPropertyEstablished)
            {
                stepFunction.RequireNonNull("StepFunction is not defined").Apply((T)_this);
            }

            function.RequireNonNull("Function is not defined").Invoke((T)_this);
            return default;            
        }

        public R Get<R>(in Func<T, R> function) => Get(function);

        public R Get<R>(Func<Func<T, R>> functionSupplier) =>
            Get(functionSupplier.Invoke());
    }    
}
