using System;
using System.Collections.Generic;
using System.Text;

namespace Caesar
{
    public sealed class StoryWriter
    {
        public static Action<T> Action<T>(string description, Action<T> action)
        {
            return _action => {
                new StepAction<T>()
                {
                    Description = description,
                    Action = action
                };
            };
        }

        public static Func<I, O> ToGet<I, O>(string description, Func<I, O> func)
        {
            return _input => {
                return default;
            };
        }
    }
}
