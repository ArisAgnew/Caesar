using Caesar.AlternativeStuff;

using System;
using System.Linq;

using static Caesar.StoryWriter;
using static System.Reflection.BindingFlags;

namespace Caesar
{
    public class PerformActionStep<T> : IPerformActionStep<T> where T : PerformActionStep<T>
    {        
        public T Perform(Action<T> action)
        {
            (StepAction<T> stepAction, Action<T> _action) = Action(action?.ToString(), action);

            bool IsPropertyEstablished = typeof(StepAction<T>)
                    .GetProperties(Public | Instance)
                    .All(p => p.GetValue(stepAction) != default);

            if (IsPropertyEstablished)
            {
                stepAction.RequireNonNull($"{nameof(stepAction)} is not defined").Accept(this as T);
            }

            return this as T;
        }

        public T Perform((dynamic, Action<T>) actionTuple)
        {
            var (_, consumer) = actionTuple.RequireNonNull($"{nameof(actionTuple)} is not defined");
            return Perform(consumer);
        }

        public T Perform(in Action<T> action) => Perform(action);        

        public T Perform(Func<Action<T>> actionSupplier) => 
            Perform(actionSupplier.RequireNonNull($"{nameof(actionSupplier)} was not defined").Invoke());        
    }
}
