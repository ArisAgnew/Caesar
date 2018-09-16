using Caesar.AlternativeStuff;
using System;

namespace Caesar
{
    public class PerformActionStep<T> : IPerformActionStep<T> where T : IPerformActionStep<T>
    {
        public T Perform(Action<T> action)
        {
            IPerformActionStep<T> performActionStep = this;
            ref var _this = ref performActionStep;
            action.RequireNonNull("Action is not defined").Invoke((T) _this);
            return (T)_this;
        }

        public T Perform(Func<Action<T>> actionSupplier) => 
            Perform(actionSupplier.RequireNonNull("Supplier of action was not defined").Invoke());
    }
}
