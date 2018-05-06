using Caesar.AlternativeStuff;

namespace Caesar
{
    public class PerformStep<T> : IPerformStep<T> where T : PerformStep<T>
    {
        public T Perform(Consumer<T> action)
        {
            action.RequireNonNull("Action is not defined").Invoke((T) this);
            return (T) this; //why DescribedFunction needs to check out
        }

        public T Perform(Supplier<Consumer<T>> actionSupplier) => Perform(actionSupplier.Invoke());
    }

    /*
     public class PerformStep : IPerformStep<PerformStep> 
    {
        public PerformStep Perform(Consumer<PerformStep> action)
        {
            action.RequireNonNull("Action is not defined").Invoke(this);
            return this; //why DescribedFunction needs to check out
        }

        public PerformStep Perform(Supplier<Consumer<PerformStep>> actionSupplier) => Perform(actionSupplier.Invoke());
    } 
     */
}
