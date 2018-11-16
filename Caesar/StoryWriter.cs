using System;
using System.Collections.Generic;
using System.Text;

namespace Caesar
{
    public sealed class StoryWriter
    {
        public static (StepAction<T>, Action<T>) Action<T>(string description, Action<T> action)
        {
            var stepAction = new StepAction<T>()
            {
                Description = description,
                Action = action
            };

            return (stepAction, action);
        }

        public static Func<I, O> ToGet<I, O>(string description, Func<I, O> func)
        {
            return _input => {
                return default;
            };
        }
    }
}
