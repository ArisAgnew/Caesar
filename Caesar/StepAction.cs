using System;
using System.Collections.Generic;
using System.Text;
using Caesar.AlternativeStuff;
using Caesar.FactoryAssembly;
using JetBrains.Annotations;
using Caesar.Utilities;

using static System.String;

namespace Caesar
{
    internal class StepAction<T>
    {
        private const string before_action_commentary = "before-action";
        private const string after_action_commentary = "before-action";

        private static readonly string comment = "It seems given consumer doesn't describe any before-action. Use method " +
                        "StoryWriter.action to describe the {0} or override the toString method";

        StepAction() { }

        [NotNull]
        public string Description { get; private set; }

        [NotNull]
        public Action<T> Action { get; private set; }

        [NotNull]
        public bool IsComplex { get; private set; }

        private static StepAction<T> GetSequentialDescribedAction(Action<T> before, Action<T> after)
        {
            before.RequireNonNull(Format(comment, before_action_commentary));
            after.RequireNonNull(Format(comment, before_action_commentary));

            return new StepAction<T>()
            {
                Description = $"{before}.\n\t And then {after}",  
                Action = t =>
                {                    
                    before?
                    .ForwardCompose(after)?
                    .Invoke(t);
                },
                IsComplex = !default(bool)
            };
        }
           
        public void Invoke(T type)
        {
            
        }
    }
}
