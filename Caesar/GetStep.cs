using Caesar.AlternativeStuff;
using System;

namespace Caesar
{
    public class GetStep<T> : IGetStep<T> where T : IGetStep<T>
    {
        public TOutput Get<TOutput>(Func<T, TOutput> function)
        {
            IGetStep<T> getStep = this;
            ref var _this = ref getStep;
            return default;            
        }

        public TOutput Get<TOutput>(Action<Func<T, TOutput>> functionSupplier)
        {
            return default;
        }
    }    
}
