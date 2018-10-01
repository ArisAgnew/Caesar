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
            StepAction<T> stepAction = new StepAction<T>();
            IPerformActionStep<T> performActionStep = this as T;
            ref var _this = ref performActionStep;

            bool IsPropertyEstablished = typeof(StepAction<T>)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .All(p => p.GetValue(stepAction) != default);

            try
            {
                action.RequireNonNull("Action is not defined").Invoke(this as T);                              
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (IsPropertyEstablished)
                {
                    stepAction.RequireNonNull("StepAction is not defined").Accept(this as T);
                }
            }
            return this as T;
        }

        public T Perform(in Action<T> action) => Perform(action);        

        public T Perform(Func<Action<T>> actionSupplier) => 
            Perform(actionSupplier.RequireNonNull("Supplier of action was not defined").Invoke());        
    }
}
