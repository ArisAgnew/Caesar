using System;
using System.Linq;
using System.Reflection;
using Caesar.AlternativeStuff;

namespace Caesar
{
    public class PerformActionStep<T> : IPerformActionStep<T> where T : PerformActionStep<T>, new()
    {
        public T Perform(Action<T> action)
        {
            StepAction<T> stepAction = default;
            IPerformActionStep<T> performActionStep = this as T;
            ref var _this = ref performActionStep;

            Action<T> intermediateAction = StoryWriter.Action(action.ToString(), action);
            intermediateAction.Invoke((T)this);

            bool IsPropertyEstablished = typeof(StepAction<T>)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .All(p => p.GetValue(new StepAction<T>()) != default);

            if (!IsPropertyEstablished)
            {
                stepAction.RequireNonNull("StepAction is not defined").Accept(this as T);
            }

            //action.RequireNonNull("Action is not defined").Invoke(this as T);                              
            
            return this as T;
        }

        public T Perform(in Action<T> action) => Perform(action);        

        public T Perform(Func<Action<T>> actionSupplier) => 
            Perform(actionSupplier.RequireNonNull("Supplier of action was not defined").Invoke());        
    }
}
