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

        public static (StepFunction<In, Out>, Func<In, Out>) ToGet<In, Out>(string description, Func<In, Out> function)
        {
            var stepFunction = new StepFunction<In, Out>()
            {
                Description = description,
                Function = function
            };

            return (stepFunction, function);
        }

        public static (dynamic, Predicate<T>) Condition<T>(string description, Predicate<T> predicate)
        {
            return (default, default);
        }
    }
}
