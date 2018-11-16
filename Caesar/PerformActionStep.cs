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
            var _this = this as T;
            (StepAction<T> stepAction, Action<T> intermediateAction) = StoryWriter.Action(action.ToString(), action);

            bool IsPropertyEstablished = typeof(StepAction<T>)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .All(p => p.GetValue(stepAction) != default);

            if (IsPropertyEstablished)
            {
                stepAction.RequireNonNull("StepAction is not defined").Accept(_this);
            }

            return this as T;
        }

        public T Perform(in Action<T> action) => Perform(action);        

        public T Perform(Func<Action<T>> actionSupplier) => 
            Perform(actionSupplier.RequireNonNull("Supplier of action was not defined").Invoke());        
    }
}
