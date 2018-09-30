using System;
using System.Linq;
using System.Reflection;
using Caesar.AlternativeStuff;

namespace Caesar
{
    public class PerformActionStep<T> : IPerformActionStep<T> where T : PerformActionStep<T>
    {
        public T Perform(Action<T> action)
        {
            StepAction<T> stepAction = new StepAction<T>();
            var performActionStep = this;
            ref var _this = ref performActionStep;

            bool IsPropertyEstablished = typeof(StepAction<T>)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .All(p => p.GetValue(stepAction) != default);

            if (!IsPropertyEstablished)
            {
                action.RequireNonNull("Action is not defined").Invoke((T) this);
            }
            else
            {
                stepAction.RequireNonNull("StepAction is not defined").Accept((T) this);
            }
            return (T) this;
        }

        public T Perform(in Action<T> action) => Perform(action);        

        public T Perform(Func<Action<T>> actionSupplier) => 
            Perform(actionSupplier.RequireNonNull("Supplier of action was not defined").Invoke());        
    }
}
